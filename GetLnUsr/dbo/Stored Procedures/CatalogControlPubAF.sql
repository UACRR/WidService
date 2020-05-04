

--Ускоренная ! версия 
CREATE PROCEDURE [dbo].[CatalogControlPubAF] @fileId integer, @result  varchar(100) OUT, @RetCode integer OUTPUT 
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
--16-09-2019 -- алгоритм 1
SET NOCOUNT ON;
--declare @RetCode integer
set @RetCode = 0
declare @rhCustId integer, @rhName varchar(254) 
set @rhCustId = (select max(custId) from CatalogFile where fileId = @fileId)
set @rhName = (select max(custName) from CatalogFile where fileId = @fileId)

 
 ---Проверка статус   
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

--Проверяю на дубли в каталоге
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
 
-- drop table #TmpAuthor 
 create table #TmpAuthor 
 (id integer not null identity primary key, 
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
  perId integer, 
  coeffMatch float
  )


PRINT 'Parcer Begin!'
delete #TmpAuthor 

--declare @FileId integer = 2203, @rhName varchar(200) = 'УМИГ'
--declare @index int;
---Список авторов
 declare @itemId integer, @itemCode varchar(50), @authorName varchar(254), @authorText varchar(254), @authorMusic varchar(254),
         @objName varchar(254), @performer varchar(254), @iswc varchar(100), @simb char(1), @simbRep char(1)
		 --,@index integer

--Замена символов в каталоге
set @simb = ','
set @simbRep = ';'

 update PubCatalogItem set authorText = REPLACE(authorText, @simbRep, @simb),  
                           authorMusic = REPLACE(authorMusic, @simbRep, @simb), 
						   performer = REPLACE(performer,@simbRep,@simb)
    where fileId = @fileId

 
 declare cur cursor for  select itemId, itemCode, authorMusic, authorText, objName, performer, iswc from pubCatalogItem  where fileId = @fileId
 open cur 
           fetch cur into   @itemId, @itemCode, @authorMusic, @authorText, @objName, @performer, @iswc
                                                  
    while @@fetch_status = 0                                                   
    BEGIN 

----
       insert into #TmpAuthor ( itemId, itemCode,  objName, iswc,  roleType,  authorName )
       select @itemId, @itemCode, @objName, @iswc,  1, outStr
	     from dbo.ft_ParceTab (@authorText, @simb)

       insert into #TmpAuthor ( itemId, itemCode,  objName, iswc,  roleType,  authorName )
       select @itemId, @itemCode, @objName, @iswc,  2, outStr
	     from dbo.ft_ParceTab (@authorMusic, @simb) 

       insert into #TmpAuthor ( itemId, itemCode,  objName, iswc,  roleType,  authorName )
       select @itemId, @itemCode, @objName, @iswc,  3, outStr
	     from dbo.ft_ParceTab (@performer, @simb)  

    ---Добавляю издателя как правообладателя --23-09-2019
    insert into #TmpAuthor ( itemId, itemCode,  objName, iswc,  roleType,  authorName )
    select @itemId, @itemCode, @objName, @iswc,  8, @rhName  

   fetch cur into @itemId, @itemCode, @authorMusic, @authorText, @objName, @performer, @iswc
 END                                                   
 close cur   
 deallocate cur      
   
   delete #TmpAuthor where authorName = ''
 --select * from #TmpAuthor

---Идентификация. Контроль на наличие в базе
declare @accuracy float = 0.4, @precision float = 0.001;

  BEGIN Transaction ImportCatalog
  BEGIN TRY

---Идентификация
/*
--1-й вариант, работает не совсем правильно, но быстро
;with TabCoeff as 
--просуммировать коеффициенты и взять максимальный
(select itemCode, t2.objId,   
   sum(dbo.Ft_tsk_3_Accurace ( t1.ObjName, t2.name, @precision )+
   dbo.Ft_tsk_3_Accurace ( t1.authorName, t2.author, @precision )) as coeffMatch
  from #TmpAuthor t1 
   join ObjectRight t2 on t1.objName = t2.name 
   where dbo.Ft_tsk_3_Accurace ( t1.objName, t2.name, @precision ) > @accuracy 
     and dbo.Ft_tsk_3_Accurace ( t1.authorName, t2.author, @precision ) > @accuracy 
	 --and t1.authorName not like 'народ%'
   group by t1.itemCode, t2.objId)

--2-й вариант, работает 2 минуты на 250тыс.
;with TabCoeff as 
(
declare @accuracy float = 0.4, @precision float = 0.001;
select itemCode, t2.objId,   
   sum(dbo.Ft_tsk_3_Accurace ( t1.ObjName, t2.name, @precision )+
   dbo.Ft_tsk_3_Accurace ( t1.authorName, t2.author, @precision )) as coeffMatch
  from #TmpAuthor t1 
   join ObjectRight t2 on t1.objName = t2.name 
   where dbo.Ft_tsk_3_Accurace ( t1.objName, t2.name, @precision ) > @accuracy 
     and dbo.Ft_tsk_3_Accurace ( t1.authorName, t2.author, @precision ) > @accuracy 
	 --and itemId = 406720
   group by t1.itemCode, t2.objId --order by 1,2,3
   ),
TabMax as 
(select itemCode as itemCode, max(objId) as objId, max(coeffMatch) as  coeffMatch
  from TabCoeff t1
  where coeffMatch  = (select max(coeffMatch) from TabCoeff t2 where t2.itemCode = t1.itemCOde)
  group by t1.itemCode
)
update PubCatalogItem set objid = t2.objId, status = 2, errComment = isnull(errComment,'') + 'Помилка! Знайдено схожий твір!'   
  from PubCatalogItem t1 
   join TabMax t2 on t2.itemCode = t1.itemCode
  where fileId = 2225--@fileId
     and t2.coeffMatch >= 1.75

*/

create table #TmpCoeff 
(itemCode integer not null, 
 objid integer not null, 
 coeffMatch float
 primary key (itemCode, objId)
 )

delete #TmpCoeff 
--declare @accuracy float = 0.4, @precision float = 0.001;
insert into #TmpCoeff (itemCode, objid, coeffMatch)
select itemCode, t2.objId,   
   sum(dbo.Ft_tsk_3_Accurace ( t1.ObjName, t2.name, @precision )+
   dbo.Ft_tsk_3_Accurace ( t1.authorName, t2.author, @precision )) as coeffMatch
  from #TmpAuthor t1 
   join ObjectRight t2 on t1.objName = t2.name 
   where t1.authorName not like 'народ%'  --09-10-2019
     and t1.roleType not in (3,8)         --09-10-2019
     and dbo.Ft_tsk_3_Accurace ( t1.objName, t2.name, @precision ) > @accuracy 
     and dbo.Ft_tsk_3_Accurace ( t1.authorName, t2.author, @precision ) > @accuracy 
	 --and itemId = 406720
   group by t1.itemCode, t2.objId --order by 1,2,3
   
;with TabMax as 
(select itemCode as itemCode, max(objId) as objId, max(coeffMatch) as  coeffMatch
  from #TmpCoeff t1
  where t1.coeffMatch  = (select max(coeffMatch) from #TmpCoeff t2 where t2.itemCode = t1.itemCOde)
  group by t1.itemCode
)
update PubCatalogItem set objid = t2.objId, status = 2, errComment = isnull(errComment,'') + 'Помилка! Знайдено схожий твір!'   
--select * 
  from PubCatalogItem t1 
   join TabMax t2 on t2.itemCode = t1.itemCode
  where fileId = @fileId
     and t2.coeffMatch >= 1.75
---Чтобы не допустить дубли по издателю - не проверяю not like 'народ%'

--Новий виконавець - просто повідомлення
  update PubCatalogItem set errComment = isnull(errComment,'') + 'Новий виконавець '   
    from  PubCatalogItem t1 
         join #TmpAuthor t2 on t2.objid = t1.objid and t2.roleType = 3 
    where fileId = @fileId 
	     and not exists (select  1 from seekObject t3 where t3.objid = t1.objid and t3.name = t2.authorName )          

---Проверка на 100% у издателя
 update pubCatalogItem set status = 2, errComment = isnull(errComment,'')+'Помилка %! '  
    where (rate > 100 or rate <= 0) -- Патлякевич добавил скобки 
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

---Если для нового объекта процент = 0
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


set  @countOldObj = ( select count(distinct itemCode) from PubCatalogItem where fileId = @fileId and isnull(objid,0) <> 0 )
set  @countNewObj = ( select count(distinct itemCode) from PubCatalogItem where fileId = @fileId and isnull(objid,0) = 0 )
set  @countOk = ( select count(*) from PubCatalogItem where fileId = @fileId and errComment like '%Без змін%' )
set  @result = 'Помилок - '+rtrim(convert(char(20), @countErr))+'; '+
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
exec [dbo].[CatalogControlPubAF] 56, @result OUTPUT, @RetCode  OUTPUT
select @result, @retCode
*/


