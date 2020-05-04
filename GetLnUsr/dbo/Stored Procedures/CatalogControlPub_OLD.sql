
CREATE PROCEDURE [dbo].[CatalogControlPub_OLD] @fileId integer, @result  varchar(100) OUT, @RetCode integer OUTPUT 
as
begin

---Контроль каталога издателей
--1) Объект уже открыт; 2) % > 100 
--Алгоритм. 1) Если есть такой объект с др.% - закрываю и создаю новый crightId. 2)Если у издателя есть объекты, которых нет в каталоге - закрываю crightId. 3) Открываю новые объекты с crightId.
--4) Исполнителей дописываем (если такого нет) для поиска из отчетов.
--20-05-2019
--27-05-31 --оптимизация, контроль издателя
--17-06-2019 кавычки
--12.07.2019 - дубли
--19-07-2019 - пробелі в названии правообладателя
SET NOCOUNT ON;
--declare @RetCode integer
set @RetCode = 0

  --Проверка статус   
  if exists (select  1 from CatalogFile where fileId = @fileId and isnull(status,0) in (3,4) ) --виконано/вилучений 
   BEGIN 
    print 'Статус файлу не для обробки - status in (0,3,4) ) --новий/виконано/вилучений'
    set @result = (select  'Статус файлу не для обробки! Файл вже оброблено!' 
	   from CatalogFile 
	   where fileId = @fileId )
    set @RetCode = 1
    Return 
   END 

   if exists (select  1 
          from CatalogFile t1 
		       join vcustomerRHolder t2 on t2.custId = t1.custId 
			   join  PubCatalogItem t3 on t3.fileId = t1.fileId 
			    and REPLACE(isnull(t3.rhName,''),' ', '') <> REPLACE(t2.name, ' ','')
              where t1.fileId = @fileId )
   --Проверяю на соответствие названию
   BEGIN 
    update pubCatalogItem set status = 2, errComment = 'Помилка назви Правовласника! ' 
	  from pubCatalogItem t1 
		  join vcustomerRHolder t2 on t2.custId = t1.custId 
	   where t1.fileId = @fileId 
	     and REPLACE(isnull(t1.rhName,''),' ', '') <> REPLACE(t2.name, ' ','')
    
	update CatalogFile set status = 2, Comment = 'Помилка назви Правовласника! ' 
	  where fileId = @fileId 

    print 'Помилка назви Правовласника! '
    set @result = (select  'Помилка назви Правовласника! ' 
	   from CatalogFile 
	   where fileId = @fileId )
    set @RetCode = 1
    Return 
   END 


  declare @index int;
 -- declare @fio varchar(100) = 'test qwerty asdf'
  --declare @str varchar(100) = 'test qwerty asdf'
  --declare @fileId integer = 2088

 update PubCatalogItem set status = 0, errComment = NULL, objid = NULL, cRightId = NULL
   where fileId = @fileId

--Проверяю на дубли
;with TabDbl as 
(  select count(*) as cntRc, 
  max(itemId) as itemId, fileId, custId, max(itemCode) as itemCode, iswc, objName, isnull(genreName,'') as genreName, 
  isnull(authorMusic,'') as authorMusic, isnull(authorText,'')  as authorText
 from  PubCatalogItem
  where fileid = @fileId
  group by fileId, custId, iswc, objName, genreName, authorMusic, authorText
  having count(*) > 1 
)
 update PubCatalogItem set status = 2, errComment = 'Знайдено дубль запису!'
  from PubCatalogItem t1, 
   TabDbl t2 
  where t1.fileId = @fileId 
        and t2.authorMusic = isnull(t1.authorMusic,'') and t2.authorText = isnull(t1.authorText,'') and t2.genreName = isnull(t1.genreName,'')
        and t2.objName = t1.objName and isnull(t2.iswc,'') = isnull(t1.iswc,'')

  --Проверка статус   
  if exists (select  1 from PubCatalogItem where fileId = @fileId and isnull(status,0) in (2) ) --Дубли 
   BEGIN 
   update CatalogFile set status = 2, comment = 'Дублі записів!'
	       where fileId = @fileId 

    print 'Контроль перервано - знайдено дублі записів!'
    set @result = (select  'Контроль перервано - знайдено дублі записів!' 
	   from CatalogFile 
	   where fileId = @fileId )
    set @RetCode = 1
    Return 
   END 


--Проставляю жанр и роль для непроставленых
  update PubCatalogItem set genreName = 'ПІСНЯ' where fileId = @fileId and isnull(genreName,'') = ''
  update PubCatalogItem set roleName = 'ПРАВОВЛАСНИК' where fileId = @fileId and isnull(roleName,'') = ''

--Убираю кавычки, если они в начале и в конце 
  update PubCatalogItem set objName = substring(ltrim(rtrim(objName)),2, len(ltrim(rtrim(objName)))-2)
      where fileId =  @fileId
	    and left(objName,1) in ('"', '''', '«') and right(rtrim(objName),1) in ('"', '''', '»')

--Ищу объекты, которые уже есть в базе - название, авторы (исполнитель не играет роли - 25-04-2019)
--Создаю таблицу типа CopyRight для дальнейшего сравнения объектов и авторов
 
 create table #TmpAuthor 
 (id integer not null identity, 
  itemId integer, 
  itemCode varchar(50), 
  objName varchar(254),
  iswc varchar(100), 
  roleType integer,   ---1-music, 2-lyric, 3-performer
  objId integer, 
  cRightId integer,   
  rate decimal(10,5), 
  custId integer, 
  authorName varchar(254), 
  perId integer
  )

delete #TmpAuthor 
 
 declare @itemId integer, @itemCode varchar(50), @authorName varchar(254), @authorText varchar(254), @authorMusic varchar(254),
         @objName varchar(254), @performer varchar(254), @iswc varchar(100), @simb char(1), @simbRep char(1)
		 --,@index integer
 
set @simb = ','
set @simbRep = ';'

 declare cur cursor for  select itemId, itemCode, authorMusic, authorText, objName, performer, iswc from pubCatalogItem  where fileId = @fileId
 open cur 
           fetch cur into   @itemId, @itemCode, @authorMusic, @authorText, @objName, @performer, @iswc
                                                  
    while @@fetch_status = 0                                                   
    BEGIN 

----
    set @index = 1
    while @index > 0 
    begin
     set @authorName = (select dbo.ParseStr (REPLACE(@authorText,@simbRep,@simb), @simb, @index)) 

     IF isnull(@authorName,'') = ''
	           set @index = -10
         insert into #TmpAuthor ( itemId, itemCode,  objName, iswc,  roleType,  authorName )
         select @itemId, @itemCode, @objName, @iswc,  1, @authorName  
	         where @index>0 and not exists ( select  1 from #TmpAuthor t2 where t2.itemId = @itemId and t2.itemCode = @itemCode and t2.roleType = 1 and t2.authorName = @authorName)
         set @index = @index + 1
    end

    set @index = 1
    while @index > 0 
    begin
     set @authorName = (select dbo.ParseStr (REPLACE(@authorMusic,@simbRep,@simb), @simb, @index)) 
     if isnull(@authorName,'') = '' 
       set @index = -10
       insert into #TmpAuthor ( itemId, itemCode,  objName, iswc,  roleType,  authorName )
       select @itemId, @itemCode, @objName, @iswc,  2, @authorName  
	     where @index>0 and not exists ( select  1 from #TmpAuthor t2 where t2.itemId = @itemId and t2.itemCode = @itemCode and t2.roleType = 2 and t2.authorName = @authorName)
       set @index = @index + 1
    end

    set @index = 1
    while @index > 0 
    begin
     set @authorName = (select dbo.ParseStr (REPLACE(@performer,@simbRep,@simb), @simb, @index)) 
     if isnull(@authorName,'') = '' 
       set @index = -10
       insert into #TmpAuthor ( itemId, itemCode,  objName, iswc,  roleType,  authorName )
       select @itemId, @itemCode, @objName, @iswc,  3, @authorName  
	     where @index>0 and not exists ( select  1 from #TmpAuthor t2 where t2.itemId = @itemId and t2.itemCode = @itemCode and t2.roleType = 3 and t2.authorName = @authorName)
       set @index = @index + 1
    end

   fetch cur into @itemId, @itemCode, @authorMusic, @authorText, @objName, @performer, @iswc
 END                                                   
 close cur   
 deallocate cur      
 
 --select * from #TmpAuthor
 --/* 20-05-19
-- ( select distinct  t1.itemId, t4.authorName, t1.objName, t2.objid, t3.authorName as aAuthorName   
--Поиск объектов
--drop table #TmpRel
--Поиск объектов
 --drop table #TmpRel 
 create table #TmpRel 
 (itemId integer, 
  authorName varchar(254), 
  objName varchar(254), 
  objid integer, 
  aAuthorName varchar(254) 
  )

--сколько авторов по твору в каталоге
 ;with TabCntTmpA as 
(select itemId, count(*)  as cntItem
    from #TmpAuthor 
    where roleType <> 3
	group by itemId
 ), 
--сколько авторов по твору в базе
TabCntObj as 
(select t3.objId, count(distinct t3.authId) as cntA, max(name) as name  
     from PubCatalogItem t1 
      join ObjectRight t2 on t2.name = t1.objName 
	  join Authors t3 on t3.objid = t2.objid and t3.roleCode <> 8
	where t1.fileId = @fileId 
	group by t3.objId
 )
 insert into #TmpRel (itemId, authorName, objName, objid, aAuthorName)
 select distinct  t1.itemId, t4.authorName, t1.objName, t2.objid, t3.authorName as aAuthorName   
    from #TmpAuthor t4 
	 inner  join PubCatalogItem t1 on t1.itemId = t4.itemId and t1.itemCode = t4.itemCode and t1.fileId = @fileId
	 inner join TabCntTmpA t7 on t7.itemId = t1.itemId 
	 inner  join TabCntObj t2 on replace(t1.objname,' ','') =  replace(t2.name, ' ', '') and t2.cntA = t7.cntItem
	 inner  join Authors t3 on t3.objid = t2.objid and replace(replace(t3.authorName,'.',''),' ','') = replace(replace(t4.authorName,'.',''), ' ','') 
	     and t3.roleCode <>8 --нужно по справочнику 'правообладатель'
		 and t4.roleType <>3 --не исполнитель

--drop table #TmpRelNew 
create table #TmpRelNew  (objid integer, itemId integer )

;with TabT1 as 
(select itemId, objid, count (*) as cntObj 
 from #TmpRel 
  group by itemId, objid 
 ),  
 TabT2 as 
(
 select itemId, max(cntObj) as maxCnt
   from TabT1 t1 
   group by t1.itemId 
  )
 insert into #TmpRelNew (itemId, objId )
  select t1.itemId, t1.objId 
   from TabT1 t1 join TabT2 t2 on t1.itemId = t2.itemId and t1.cntObj = t2.maxCnt

 update #TmpAuthor set objid = t2.objid 
   from   #TmpAuthor t1 
    join #TmpRelNew t2 on t2.itemId = t1.itemId
--*/ 20-05-19   

--select * from #TmpAuthor

  BEGIN Transaction ImportCatalog
  BEGIN TRY
/*
--Здесь можно усилить совпадение авторов.Уже!
 update PubCatalogItem set objid = t3.objid,
   errComment = (CASE WHEN countAllA<>isnull(countA,0) THEN isnull(errComment,'')+'Знайдено авторів '+convert(varchar(10),countA)+' з '+convert(varchar(10),countAllA)+'. ' END)
    from PubCatalogItem t1 
	join (select itemId, count(*) as countAllA from #TmpAuthor where roleType <> 3 group by itemId ) t2 on t2.itemId = t1.itemId 
	join (select itemId, objid, count(*) as countA from #TmpAuthor where roleType <> 3 and isnull(objid,0) <> 0  group by itemId, objid ) t3 on t3.itemId = t1.itemId 
	where t1.fileId = @fileId and t1.itemId = t2.itemId and t1.itemId = t3.itemId and countAllA = countA
*/
  update PubCatalogItem set objid = t2.objid 
    from PubCatalogItem t1 
	 join (select itemId, min(isnull(objid,0)) as objid from #TmpAuthor where roleType <> 3 group by itemId ) t2 on t2.itemId = t1.itemId 
    where t1.fileId = @fileId

--Поиск CopyRight. Их не трогаю.
  update PubCatalogItem set cRightId = t2.cRightId, errComment = isnull(errComment,'') + 'Без змін. '
     from PubCatalogItem t1 
	  join CopyRight t2 on t2.objId = t1.objId and t2.custId = t1.custId and t1.rate = t2.rate and getdate() between isnull(t2.beginDate, '1900-01-01') and isnull(t2.endDate, '3000-01-01')
     where t1.fileId = @fileId

--Новий виконавець - просто повідомлення
  update PubCatalogItem set errComment = isnull(errComment,'') + 'Новий виконавець '   
    from  PubCatalogItem t1 
         join #TmpAuthor t2 on t2.objid = t1.objid and t2.roleType = 3 
    where fileId = @fileId 
	     and not exists (select  1 from seekObject t3 where t3.objid = t1.objid and t3.name = t2.authorName )          

--Найти объекты, у которых есть %, а у нашего издателя нет 100% - такие не вношу, т.к. не знаю кого исключать или просто добавить.
;with TabCR as 
(
select sum(isnull(t1.rate,0)) as rateCR, t1.objId, max(t2.rate) as rateCG  
  from copyRight t1 
    join PubCatalogItem t2 on t2.fileId = @fileId and t2.objid = t1.objid and t2.rate<100 and t2.custid <> t1.custId  
  where getdate() between isnull(t1.beginDate, '1900-01-01') and isnull(t1.endDate, '3000-01-01')
  group by t1.objId
  having  sum(isnull(t1.rate,0)) > 0  --sum(t1.rate) > max(t2.rate) 
 )
 update PubCatalogItem set status = 2, errComment = isnull(errComment,'') + 'Є інші правовласники, %<>100. '
     from PubCatalogItem t1 
	  join TabCR t2 on t2.objId = t1.objId 
	 where t1.fileId = @fileId;


---Проверка на 100% у издателя
 update pubCatalogItem set status = 2, errComment = isnull(errComment,'')+'Помилка %! '  
    where (rate > 100 or rate < 0) -- Патлякевич добавил скобки 
    and fileId = @fileId;

-------Genre
 update pubCatalogItem set genreCode = t2.codei
    from pubCatalogItem t1 
     join GenreType t2 on upper(Replace(t1.genreName,' ','')) = upper(Replace(t2.name,' ','')) collate Ukrainian_100_CI_AS
          and genreCode is null
          and fileId = @fileId;

 update pubCatalogItem set status = 2, errComment = isnull(errComment,'')+'Помилка Жанру! '  
    where genreCode is null 
        and fileId = @fileId;

-------Role
 update pubCatalogItem set roleCode = t2.codei
    from pubCatalogItem t1 
	   join CreativeRoleType t2 on upper(Replace(t1.roleName,' ','')) = upper(Replace(t2.name,' ','')) collate Ukrainian_100_CI_AS
       and roleCode is NULL 
       and fileId = @fileId;

 update pubCatalogItem set status = 2, errComment = isnull(errComment,'')+'Помилка Ролі! '  
    where roleCode is null 
        and fileId = @fileId;

 update pubCatalogItem set status = 2, errComment = isnull(errComment,'')+'Помилка Авторів! '  
    where replace(isnull(authorMusic,''),' ','') = '' and replace(isnull(authorText,''),' ','') = ''
        and fileId = @fileId;

 update pubCatalogItem set status = 2, errComment = isnull(errComment,'')+'Помилка Назви! '  
    where replace(isnull(authorMusic,''),' ','') = '' and replace(isnull(objName,''),' ','') = ''
        and fileId = @fileId;

---Если для ного объекта процент = 0
 update pubCatalogItem set status = 2, errComment = isnull(errComment,'')+'Помилка -0%! '  
    where isnull(rate,0) = 0 and isnull(objid,0) = 0 
	    and (authorMusic not like 'народ%' or authorText not like 'народ%' )
        and fileId = @fileId;

declare @countErr integer = 0, @countOk integer = 0, @countNewObj integer = 0, @countOldObj integer = 0
--Остальные прошли контроль - готовы
  update pubCatalogItem set  status = 1 
     where isnull(status,0) = 0 
          and fileId = @fileId
  set @countOk = @@ROWCOUNT  

  set @countErr = (select count(*) from pubCatalogItem where fileId = @fileId and status = 2)

    update CatalogFile set  status = 1 
     where fileId = @fileId

 update CatalogFile set status = 2 
   where fileId = @fileId and exists (select  1 from PubCatalogItem where fileId = @fileId and status = 2)


;with tabZap as 
(
 select  fileId, (case when  isnull(status,0) = 1 Then 1 Else 0 END ) as countOk, (case when  isnull(status,0) = 2 Then 1 Else 0 END ) as countErr 
          from PubCatalogItem 
          where fileId = @fileId
)
, 
tabZapSum as 
( select fileId, sum(countOk) as countOk, sum(countErr) as countErr  
   from tabZap  
   group by fileId )
 update CatalogFile set countOk = t2.countOk, countErr = t2.countErr 
    from CatalogFile t1 
       join tabZapSum  t2 on t2.fileId = t1.fileId 


set  @countOldObj = ( select count(distinct objid) from PubCatalogItem where fileId = @fileId and isnull(objid,0) <> 0 )
set  @countNewObj = ( select count(distinct itemCode) from PubCatalogItem where fileId = @fileId and isnull(objid,0) = 0 )
set  @countOk = ( select count(*) from PubCatalogItem where fileId = @fileId and errComment like '%Без змін%' )
set  @result = 'Помилок - '+rtrim(convert(char(20), @countErr))+'; Без змін -'+rtrim(convert(char(20), @countOk))+'. '+
    'Об''єктів нових: '+ +rtrim(convert(char(20), @countNewObj))+'; знайдених: '+ +rtrim(convert(char(20), @countOldObj))+'. '+
    'Статус файлу-' + 
    (Case When isnull(@countErr,0) <> 0 Then 'ПОМИЛКИ!' ElSE 'Готовий до завантаження!' end)

IF @@TRANCOUNT > 0 commit tran
END TRY

BEGIN CATCH
  IF @@TRANCOUNT > 0 rollback tran
  
   SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_SEVERITY() AS ErrorSeverity  
        ,ERROR_STATE() AS ErrorState  
        ,ERROR_PROCEDURE() AS ErrorProcedure  
        ,ERROR_LINE() AS ErrorLine  
        ,ERROR_MESSAGE() AS ErrorMessage;  
 	   
 set @Retcode = 1
 set @result  = 'Операцію перервано! Контроль не пройдено!'
 
END CATCH
return --@Retcode
END
/*
DECLARE @result VARCHAR(100), @RetCode integer;
exec CatalogControlPub 6014, @result OUTPUT, @RetCode  OUTPUT
select @result, @retCode
*/

