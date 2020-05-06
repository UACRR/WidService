

CREATE PROCEDURE [dbo].[CatalogControlRhAF] @fileId integer, @result  varchar(500) OUT, @RetCode integer OUTPUT 
as
begin

---Контроль каталога издателей
---Контроль каталога издателей
--1) Объект уже открыт; 2) % > 100 
--Алгоритм. 1) Если есть такой объект - ошибка 2) Открываю новые объекты с crightId с подтвержденным статусом. 
--3) Если у Автора % = 0 - закрываю право. 
--4) Если у соавтора % = 0 прописываю в авторы. 
--5) Если у соавтора % <> 0 и он с договором - прописываю право без подтверждения.
--6) Если у соавтора подтверждены др.% - не вношу его %. Это ошибка. 
--7) Дописываю исполнителя (если такого нет) для поиска из отчетов.
--18-06-2019 Убираю кавычки, если они в начале и в конце 
--23-09-2019 - разделенный алгоритм
SET NOCOUNT ON;
declare @comment varchar(512), @author varchar(254), @custId integer --имя автора реестра
--declare @RetCode integer, @fileId integer = 2078, @result varchar(512)
set @RetCode = 0

--Запоминаю автора реестра
select @author = name, @custId = t1.custId 
    from CatalogFile t1 
      join vCustomerRHolder t2 on t1.custId = t2.custId 
	 where t1.fileId = @fileId 

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

 update RHCatalogItem set status = 0, errComment = NULL, objid = NULL, cRightId = NULL
   where fileId = @fileId

--Проверяю на дубли в реестре
;with TabDbl as 
(  select count(*) as cntRc, 
  max(itemId) as itemId, fileId, custId, max(itemCode) as itemCode, iswc, objName, isnull(genreName,'') as genreName, 
  isnull(roleName, '') as roleName, 
  isnull(authorName,'') as authorName
 from  RHCatalogItem
  where fileid = @fileId
  group by fileId, custId, iswc, objName, genreName, roleName, authorName
  having count(*) > 1 
)
 update RHCatalogItem set status = 2, errComment = 'Знайдено дубль запису!'
  from RHCatalogItem t1, 
   TabDbl t2 
  where t1.fileId = @fileId 
        and t2.authorName = isnull(t1.authorName,'') and t2.roleName = isnull(t1.roleName,'') and t2.genreName = isnull(t1.genreName,'')
        and t2.objName = t1.objName and isnull(t2.iswc,'') = isnull(t1.iswc,'')

  --Проверка статус   
  if exists (select  1 from RHCatalogItem where fileId = @fileId and isnull(status,0) in (2) ) --Дубли 
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

----
--Убираю кавычки, если они в начале и в конце 
  update RHCatalogItem set objName = substring(ltrim(rtrim(objName)),2, len(ltrim(rtrim(objName)))-2)
      where fileId =  @fileId
	    and left(objName,1) in ('"', '''', '«') and right(rtrim(objName),1) in ('"', '''', '»')

  --Если один код на разные названия объекта - ошибка
 ; with   TabOb1 as 
 (select itemCode, objName 
      from RHCatalogItem 
      where fileId = @fileId 
      group by itemCode, objName ), 
  TabOb2 as 
  (
  select count(*) as cnt, itemCode 
    from TabOb1
	group by itemCode 
    having count(*) > 1 
	) 
  update RHCatalogItem  set status = 2, errComment = isnull(t1.errComment, '') +  'Помилки кодів твору! '
    from RHCatalogItem t1 
      join TabOb2 t2 on t2.itemCode = t1.itemCode 
     where t1.fileId = @fileId

--declare @comment varchar(512), @author varchar(254), @custId integer --имя автора реестра
--declare @RetCode integer, @fileId integer = 5008, @result varchar(512)
--set @RetCode = 0

--Запоминаю автора реестра
select @author = name, @custId = t1.custId 
    from CatalogFile t1 
      join vCustomerRHolder t2 on t1.custId = t2.custId 
	 where t1.fileId = @fileId 

  --если в по коду произведения нет нашего Автора - может быть ошибка нумерации произведения, а м.б. указан просто чужой автор. 
  ; with   TabOb1 as 
  (select itemCode,   MAX(CASE When replace(authorName,' ','') = replace(@author,' ','') Then 1 Else 0 ENd) as isAuthor
      from RHCatalogItem 
      where fileId = @fileId 
      group by itemCode 
   )
   update RHCatalogItem  set status = 2, errComment = isnull(errComment, '') + 'Помилки кодів твору або Автора! '
     from RHCatalogItem t1 
      join TabOb1 t2 on t1.itemCode = t2.itemCode and isnull(t2.isAuthor,0) = 0 
    where t1.fileId = @fileId

-------Genre
 update RHCatalogItem set genreCode = t2.codei
    from RHCatalogItem t1 
     join GenreType t2 on upper(Replace(t1.genreName,' ','')) = upper(Replace(t2.name,' ','')) collate Ukrainian_100_CI_AS
          and genreCode is null
          and fileId = @fileId;

 update RHCatalogItem set status = 2, errComment = isnull(errComment,'')+'Помилка Жанру! '  
    where genreCode is null 
        and fileId = @fileId;

-------Role
 update RHCatalogItem set roleCode = t2.codei
    from RHCatalogItem t1 
	   join CreativeRoleType t2 on upper(Replace(t1.roleName,' ','')) = upper(Replace(t2.name,' ','')) collate Ukrainian_100_CI_AS
       and roleCode is NULL 
       and fileId = @fileId;

 update RHCatalogItem set status = 2, errComment = isnull(errComment,'')+'Помилка Ролі! '  
    where roleCode is null 
        and fileId = @fileId;

 update RHCatalogItem set status = 2, errComment = isnull(errComment,'')+'Помилка ФІО Автора! '  
    where replace(isnull(authorName,''),' ','') = '' 
        and fileId = @fileId;

 update RHCatalogItem set status = 2, errComment = isnull(errComment,'')+'Помилка Назви! '  
    where replace(isnull(objName,''),' ','') = ''
        and fileId = @fileId;

   if exists (select  1 
          from RHCatalogItem 
	      where fileId = @fileId  and status = 2 ) 
        BEGIN 
	update CatalogFile set status = 2, Comment = 'Помилки заповнення інформації ! ' 
	  where fileId = @fileId 

    print 'Помилки заповнення інформації ! '
    set @result = (select  'Помилки заповнення інформації ! Обробку перервано! '
	   from CatalogFile 
	   where fileId = @fileId )
    set @RetCode = 1
    Return 
   END 

------------------------------------------------------------------------
 --drop table #TmpRH
 CREATE TABLE #TmpRH
(
	itemId integer NOT NULL,
	fileId integer NULL,
	itemCode varchar(50) NULL,
	iswc varchar(100) NULL,
	objName varchar(254) NULL,
	duration time(7) NULL,
	genreName varchar(100) NULL,
	roleName varchar(100) NULL,
	authorName varchar(200) NULL,
	rate numeric(10, 5) NULL,
	cmName varchar(100) NULL,
	comment varchar(1024) NULL,
        folkType integer,    --3-народ
	objId int NULL,
	custId int NULL,
        rhCustId  integer null, 
        rateOld numeric(10,5) NULL,
	genreCode int NULL,
	roleCode int NULL,
	cmCustId int NULL,
	cRightId int NULL,
	status int NULL,
	errComment varchar(200) NULL,
 PRIMARY KEY  (itemId)
)
create index ii0 on #TmpRH (itemCode, objid)

--Для работы, чтобы потом одной транзакцией записать изменения контроля, чтобы не блокировать базу
 delete #TmpRH
 insert into #TmpRH ( itemId, fileId, itemCode, iswc, objName, duration, genreName, roleName, authorName, rate, cmName, comment, objId, custId, genreCode, roleCode, cmCustId, cRightId, status, errComment)
 select itemId, fileId, itemCode, iswc, objName, duration, genreName, roleName, authorName, rate, cmName, comment, NULL, NULL, genreCode, roleCode, NULL, NULL, 1, NULL
   from RHCatalogItem 
    where fileId = @fileId 
 
 --Проставляю custId Авторов
  update #TmpRH set rhCustId = @custId where authorName = @author 
  --update #TmpRH set rhCustId = 20 where authorName = 'Правовласник з Товариством' 
  
  update #TmpRH set rhCustId  = t2.custId 
      from #TmpRH t1 
        join vCustomer t2 on replace(t2.name,' ','') = replace(t1.authorName,' ','')
      where isnull(t1.rhCustId,0) = 0 

  update #TmpRH set folkType = 3 
     where authorName like 'народ%'

 --Таблица произведений. 
 create table #TmpObject 
(	itemId integer NOT NULL,
	itemCode varchar(50) NOT NULL,
	iswc varchar(100) NULL,
	objName varchar(254) NULL,
	duration time(7) NULL,
	genreName varchar(100) NULL,
	authors varchar(254) NULL,
	meAuthor varchar(254) NULL,
        composers  varchar(254) NULL,
        lyrics varchar(254) NULL,
        performers varchar(254) NULL,
	objId int NULL,
	genreCode int NULL,
	status int NULL,
	errComment varchar(200) NULL,
 PRIMARY KEY  (itemCode)
)
 
 delete #TmpObject
 insert into #TmpObject ( itemId, itemCode, iswc, objName, duration, genreName, genreCode, meAuthor )
  select min(itemId),  itemCode, max(iswc), max(objName), max(duration), max(genreName), max(genreCode), @author  
  --select min(itemId),  itemCode, max(iswc), max(objName), max(duration), max(genreName),  max(genreCode), 'Правовласник з Товариством'
    from #TmpRH
    group by itemCode 
 
 --Дальше использую ключ itemId 
-------- Формирование списка авторов-------
--TEST
 ;with TabL1 as 
 (
 select max(t1.itemId) as itemId, t1.itemCode, 
            lyrics = STUFF (
                        (SELECT distinct ', '+ t2.authorName from #TmpRH t2 where t2.itemCode = t1.itemCode and t2.roleCode in (1,10) FOR XML PATH ('') ), 1, 1, ''
			          ), 
            composers = STUFF (
                        (SELECT distinct  ', '+t2.authorName from #TmpRH t2 where t2.itemCode = t1.itemCode and t2.roleCode in (2,10) FOR XML PATH ('') ), 1, 1, ''
			          ), 
            performers = STUFF (
                        (SELECT distinct  ', '+ t2.authorName from #TmpRH t2 where t2.itemCode = t1.itemCode and t2.roleCode in (3) FOR XML PATH ('') ), 1, 1, ''
			          ),
            authors = STUFF (
                        (SELECT distinct ', '+ t2.authorName from #TmpRH t2 where t2.itemCode = t1.itemCode and t2.roleCode not in (3) FOR XML PATH ('') ), 1, 1, ''
			          )
 from #TmpRH t1 group by t1.itemCode
 )
 update #TmpObject 
  set lyrics = left(ltrim(t2.lyrics), 254), 
     composers = left(ltrim(t2.composers),254), 
	 performers = left(ltrim(t2.performers),254), 
	 authors = left(ltrim(t2.authors),254)
    from #TmpObject t1 
    join TabL1 t2 on t2.itemCode = t1.itemCode
-----------------------------------------------------------  
--Ищу объекты, которые уже есть в базе - название, авторы (исполнитель не играет роли - 25-04-2019)
--Если название и хоть 1 автор автор совпали - ошибка.  
--Сначала поиск по iswc 
  update #TmpObject set objid = t2.objid, status = 2, errComment = isnull(errComment,'')+'Схожий твір! (ISWC)'
     from #TmpObject t1 
      join objectRight t2 on replace(t2.name,' ','') = REPLACE(t1.objName, ' ','') 
      join MediaTrack t3 on t3.objId = t2.objId and t3.iswc = t1.iswc 
 
---Идентификация
declare @accuracy float = 0.4, @precision float = 0.001;

;with TabCoeff as 
(select itemCode, t2.objId,   
   max(dbo.Ft_tsk_3_Accurace ( t1.ObjName, t2.name, @precision )+
   dbo.Ft_tsk_3_Accurace ( t1.authorName, t2.author, @precision )) as coeffMatch
  from #TmpRH t1 
   join ObjectRight t2 on t1.objName = t2.name 
   where dbo.Ft_tsk_3_Accurace ( t1.objName, t2.name, @precision ) > @accuracy 
     and dbo.Ft_tsk_3_Accurace ( t1.authorName, t2.author, @precision ) > @accuracy 
	 --and t1.authorName not like 'народ%'
   group by t1.itemCode, t2.objId)
/*
update RHCatalogItem set objid = t2.objId, status = 2, errComment = isnull(errComment,'') + 'Помилка! Знайдено схожий твір!'   
  from RHCatalogItem t1 
   join TabCoeff t2 on t2.itemCode = t1.itemCode
  where fileId = @fileId
     and t2.coeffMatch > 1.75 
*/
update #TmpRH set objid = t2.objId, status = 2, errComment = isnull(errComment,'') + 'Помилка! Знайдено схожий твір!'   
  from #TmpRH t1 
   join TabCoeff t2 on t2.itemCode = t1.itemCode
  where fileId = @fileId
     and t2.coeffMatch > 1.75 

-----------------------

--------------------
--Проверка процентов в каталоге
; with TabPrc as 
 (select itemCode, sum(rate) as rate 
   from  #TmpRH
  group by itemCode 
  having sum(rate) <= 0 or sum(rate) > 100
 )
  update  #TmpRH set status = 2, errComment = isnull(errComment,'') + 'Помилка процентів!' 
    from  #TmpRH t1  
     join TabPrc t2 on t2.itemCode = t1.itemCode 

/* -- ПОКА не нужно 
 ---Формирую новые данные по Copyright 
 create table #TmpCopyRight 
 (id integer not null identity primary key, 
  cRightId integer, 
  objid integer, 
  rate decimal(10,5), 
  rateNew decimal(10,5),
  custId integer, 
  roleCode integer) 

 insert into  #TmpCopyRight (cRightId, objId, custId, rate, roleCOde) 
 select  t2.cRightId, t2.objId, t2.custId, t2.rate, t2.roleCode 
  from #TmpRelNew t1 
  join CopyRight t2 on t2.objId = t1.objId and getdate() between isnull(t2.beginDate, '1900-01-01') and isnull(t2.endDate, '3000-01-01')

  update  #TmpCopyRight set rateNew = t2.rate 
    from #TmpCopyRight t1  
        join #TmpRH t2 on t2.objId = t1.objId and t1.custId = t2.custId 

---Проверка процентов после изменений
; with TabPrc as 
 (select objId, sum(rate) as rate 
   from  #TmpCopyRight
  group by objId 
  --having sum(rate) <0 and sum(rate) > 100
  having sum(rate) > 100
 )
  update  #TmpRH set status = 2, errComment = isnull(errComment,'')+ 'Помилка процентів після!' 
    from  #TmpRH t1  
     join TabPrc t2 on t2.objId = t1.objId 


--6) Если у соавтора установлены др.% - не вношу его %. Это ошибка. 
 update #TmpRH set status = 2, errComment = isnull(errComment,'') + 'У Соавтора інші проценти!' 
  where isnull(cRightId,0) <> 0 and rhCustId <> @custId and rate <> isnull(rateOld,0) and  isnull(rateOld,0) <> 0 


 update #TmpRH set errComment = isnull(errComment,'') + 'Без змін' 
  where isnull(cRightId,0) <> 0 and rate = rateOld  

 update #TmpRH set errComment = isnull(errComment,'') + 'Твір ід-ий.' 
  where isnull(objId,0) <> 0 

 update #TmpRH set  errComment = isnull(errComment,'') + 'Автор без договору!' 
  where isnull(rhCustid,0) = 0  

 update #TmpRH set status = 1, errComment = isnull(errComment,'') + 'Готовий до завантаження' 
  where isnull(status,0) = 0 
*/
-------------------
  BEGIN Transaction ControlRHCatalog
  BEGIN TRY

--Рез-т контроля
  update RHCatalogItem 
    set status = t2.status, errComment = isnull(t1.errComment,'') + t2.errComment, 
        rhCustId = t2.rhCustId, objId = t2.objId, cRightId = t2.cRightId 
    from RHCatalogItem t1 
     join #TmpRH t2 on t1.fileId = @fileId and t1.itemId = t2.itemId 

   update CatalogFile set  status = 1 
     where fileId = @fileId

  update CatalogFile set status = 2 
    where fileId = @fileId and exists (select  1 from RHCatalogItem where fileId = @fileId and status = 2)

;with tabZap as 
(
 select  fileId, (case when  isnull(status,0) = 1 Then 1 Else 0 END ) as countOk, (case when  isnull(status,0) = 2 Then 1 Else 0 END ) as countErr 
          from RHCatalogItem 
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

declare @countOldObj integer, @countNewObj integer, @countOk integer, @countErr integer

set  @countOldObj = ( select count(distinct itemCode) from RHCatalogItem where fileId = @fileId and isnull(objid,0) <> 0 )
set  @countNewObj = ( select count(distinct itemCode) from RHCatalogItem where fileId = @fileId and isnull(objid,0) = 0 )
set  @countOk = ( select count(*) from RHCatalogItem where fileId = @fileId and errComment like '%Без змін%' )
set  @countErr = ( select count(*) from RHCatalogItem where fileId = @fileId and status = 2 )
set  @result = 'Помилок - '+rtrim(convert(char(20), @countErr))+'. '+
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
DECLARE @result VARCHAR(500), @RetCode integer;
exec CatalogControlRhAF 53, @result OUTPUT, @RetCode  OUTPUT
select @result, @retCode
*/

