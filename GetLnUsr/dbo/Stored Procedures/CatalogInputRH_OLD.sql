CREATE PROCEDURE [dbo].[CatalogInputRH_OLD] @fileId integer, @result  varchar(100) OUT, @RetCode integer OUTPUT
as
begin
---Загрузка каталога Авторов
--Обрабатываю только status = 1 
--Алгоритм. 
--1) Если есть такой объект с др.% - закрываю и создаю новый crightId. 
--2) Если у Автора есть объекты, которых нет в каталоге - открываю эти объекты. 
--3) Если проставлены проценты по соавторам нашего ОКУ - добавляю в crightId все права. Автор каталога - подтвержден, соавторы - не подтвержден. 
--4) Если у соавтора др.% - не вношу его % из реестра. Это ошибка. 
--5) Если передан объект права с % = 0 по Автору. Все как обычно (создаю объект права, если нет). Если владелец каталога - закрываю его права. Если по соавтору %=0 - ничего не делаю, просто добавляю в авторы. 


SET NOCOUNT ON;
--declare @RetCode integer
set @RetCode = 0

--Ищу объекты, которые уже есть в базе - название, авторы (исполнитель не играет роли - 25-04-2019)
--Даже если проставлены ключи - все равно пересматриваю.

  if exists (select  1 from CatalogFile where fileId = @fileId and isnull(status,0) <> 1 ) --виконано/вилучений 
   BEGIN 
    print 'Статус файлу не для обробки - status in (0,3,4) ) --новий/виконано/вилучений'
    set @result = (select  'Статус файлу не для обробки! ' 
	     +(CASE WHEN isnull(status,0) =0 THEN 'Виконайте контроль!'  
	            ELSE 
		        ( CASE WHEN  isnull(status,0) = 3 THEN 'Файл вже оброблено!'  
				        ELSE 
						   (CASE WHEN  isnull(status,0) = 2  THEN 'Є помилки!' ELSE 'Вже вилучено!' END ) END ) END ) -- status in (0,3,4) ) --новий/виконано/вилучений' 
	   from CatalogFile 
	   where fileId = @fileId )
    set @RetCode = 1
    Return 
   END 

declare @getdate datetime = getdate() 

--для ключей новых договоров
create table #TmpId 
(itemCode varchar(50) not null primary key, 
 objId integer)

 declare @countChCright integer = 0, @countclCright integer = 0, @countNewObj integer = 0, @author varchar(254), @custId integer, 
         @userId varchar(48), @fileName varchar(100)
----------------------------------------------------------
--Запоминаю автора - владельца рееста/каталога
select @author = name, @custId = t1.custId, @userId = t1.userId, @fileName = t1.fileName
    from CatalogFile t1 
      join vcustomer t2 on t1.custId = t2.custId 
	 where t1.fileId = @fileId 
----------------------------------------------------------
update RHCatalogItem set errComment = NULL where fileId = @fileId

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
    perId integer, 
	genreCode int NULL,
	roleCode int NULL,
	cmCustId int NULL,
	cRightId int NULL,
	status int NULL,
	errComment varchar(200) NULL,
 PRIMARY KEY  (itemId)
)

--Для работы, чтобы потом одной транзакцией записать изменения контроля, чтобы не блокировать базу
 delete #TmpRH
 insert into #TmpRH ( itemId, fileId, itemCode, iswc, objName, duration, genreName, roleName, authorName, rate, cmName, comment, 
                      objId, custId, genreCode, roleCode, cmCustId, cRightId, status, errComment, rhCustId)
 select itemId, fileId, itemCode, iswc, objName, duration, genreName, roleName, authorName, rate, cmName, comment, 
                      objId, custId, genreCode, roleCode, cmCustId, cRightId, status, errComment, rhCustId
   from RHCatalogItem 
    where fileId = @fileId 

 update #TmpRH set folkType = 3 
     where authorName like 'народ%'

 --Таблица произведений. 
--drop table #TmpObject 
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
 insert into #TmpObject ( itemId, itemCode, iswc, objName, duration, genreName, meAuthor )
  select min(itemId),  itemCode, max(iswc), max(objName), max(duration), max(genreName), @author  
    from #TmpRH 
	 where isnull(status,0) = 1
	   and isnull(objid,0) = 0
    group by itemCode 

-------- Формирование списка авторов-------
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

 begin Transaction ImportCatalog
	BEGIN TRY

--Открываю новые объекты
  insert into objectRight (categoryCode, genreType, name, author, performer, status, modifyDate, modifyLogin, createDate, loadid, specType, innerCode, sourceName)
  output inserted.objId, inserted.loadid into #TmpId (objid, itemCode)
  select 5, t2.genreCode, t2.objName, t2.authors, t2.performers, 0, @getdate, @userId, @getdate, t2.itemCode, 1, t2.itemCode, @fileName
  --select 5, t2.genreCode, t2.objName, t2.authors, t2.performers, 0, getdate(), '', getdate(), t2.itemCode, 1, t2.itemCode, 'f1'
     from #TmpObject t2 
	 where  isnull(t2.objid,0) = 0

 set @countNewObj = @@ROWCOUNT 	 

insert into mediatrack (objId,iswc,name,lyrics,composers,performers, genre, modifyDate, modifyLogin)
select t1.objid, t2.iswc, t2.objName, t2.lyrics, t2.composers, t2.performers,  t2.genreName, @getdate, @userId
  from #TmpId t1 
  join  #TmpObject t2 on  t2.itemCode = t1.itemCode 

------------ Объекты и авторы ---------
 update #TmpRH set objId = t2.objid 
   from #TmpRH t1 
    join #TmpId t2 on t2.itemCode = t1.itemCode

 update RHCatalogItem set objid = t2.objid 
   from  RHCatalogItem t1 
     join #TmpId t2 on t2.itemCode = t1.itemCode

 insert into Authors (objId, roleCode, custId, authorName, isFolkOrUnknown, folkType)
  select  t1.objId, t1.roleCode, rhCustId, t1.authorName, NULL, isnull(folkType,1)
    from #TmpRH t1
	where t1.roleCode <> 3 
	  and not exists (select  1 from Authors t2 where t2.objid = t1.objid and (t2.custId = t1.custId or REPLACE(t2.authorName, ' ','') = REPLACE(t1.authorName, ' ', '')))

--------------------------------------
---Исполнители
create table #TmpPerId 
 (perName varchar(200) not null primary key, perId integer ) 

create table #TmpPerformer 
(id integer not null identity, 
 perId integer, 
 perName varchar(200) )

insert into #TmpPerformer (pername) 
 select distinct authorName 
   from #TmpRH 
    where rolecode = 3 

 update #TmpPerformer set perId = t2.perId 
    from #TmpPerformer t1 
	 join Performer t2 on replace(t2.perName, ' ','') = replace(t1.perName, ' ','')
 
 --Исполнители new
 insert into Performer (perName) 
 output inserted.perId, inserted.perName into #TmpPerId (perId, perName )
 select perName
   from #TmpPerformer 
   where isnull(perId,0) = 0

 update #TmpPerformer set perId = t2.perId 
    from #TmpPerformer t1 
	  join #TmpPerId t2 on Replace(t2.perName, ' ', '') = Replace(t1.perName, ' ','')

 update #TmpRH set perId = t2.perId 
    from #TmpRH t1
	   join #TmpPerId t2 on replace(t2.perName, ' ','') = replace(t1.authorName, ' ','') and t1.roleCode = 3

 insert into RelObjPerformer  (objId, perId) 
 select  distinct t1.objid, t1.perId 
   from #TmpRH t1 
   where t1.roleCode = 3 and isnull(t1.perId,0) <> 0  

--Вношу для поиска. Так это показывается у правообладателя. 
insert into SeekObject (codeI, objid, name) 
select distinct 2 as codei, objid, pername 
from vRelObjPerformer t1 
  where isnull(pername,'') <> '' 
    and  not exists (select  1 from SeekObject t2 where t2.codei=2 and t2.objid = t1.objid 
	and replace(t2.name,' ','' ) = replace(t1.pername,' ','' ) 
	) order by 3  
-----------------------------

---CopyRight --Сразу проверить %

--Проверяю на >100%, чтобы не допустить
create table #TmpCO (objid integer not null primary key, rate decimal(10,5)) 

--все объекты права реестра
insert into #TmpCO  (objId) 
 select distinct objId 
     from #TmpRH 

--Проверка что получится при вставке - > 100%
create table #TmpCr 
 (id integer identity not null, 
  cRightId integer, 
  rhCustId integer, 
  objId integer, 
  rate decimal(10,5), 
  rateNew decimal(10,5), 
  itemId integer) 

--что уже есть
 insert into #TmpCr (cRightId, rhCustId, objid, rate )
  select  cRightId, custId, t1.objid, t1.rate 
   from CopyRight t1 
    join #TmpCO t2 on t2.objId = t1.objId 

 update #TmpCr set rateNew = t2.rate, itemId = t2.itemId 
   from #TmpCr t1 
     join #TmpRH t2 on t2.rhCustId = t1.rhCustId and t1.objid = t2.objId 
	 where t2.rhCustId = t2.custId  --только свои

 insert into #TmpCr (itemId, rhCustId, objid, rateNew )
  select  itemId, rhCustId, t1.objid, t1.rate 
   from #TmpRH  t1 
    join #TmpCO t2 on t2.objId = t1.objId 
   where not exists (select  1 from #TmpCr t3 where t3.objId = t1.objId and t3.rhCustId = t1.rhCustId)

;with TabPrc as 
(select  sum(isnull(rateNew, rate)) as rateNew, objid 
  from #TmpCr 
  group by objid
)
 update #TmpCO set rate = t2.rateNew 
  from #TmpCO t1 
   join TabPrc  t2 on t2.objid = t1.objid 

---Ошибки 
update RHCatalogItem set status = 2, errComment = 'Помилка загального %!'
  from RHCatalogItem t1 
   join #TmpCO t2 on t2.objid = t1.objId 
  where fileId = @fileId and isnull(t2.rate,0) > 100

IF exists (select  1 from RHCatalogItem where fileId = @fileId  and status = 2 ) 
 BEGIN 
  update CatalogFile set status = 3, comment = 'Увага! Помилка загального %! ' 
   from RHCatalogItem t1 
   join #TmpCO t2 on t2.objid = t1.objId 
  set @result = isnull(@result,'') + 'Помилка загального %!'
  END

-------------------------Права-------------------
----Правильное вставляю 

---Закрываю владение по rate = 0 только для владельца каталога
 update CopyRight set endDate = cast (dateadd(day, -1, getdate()) as date) 
  from CopyRight t1 
     join RhCatalogItem t2 on t2.objId = t1.objId and t2.custId = t1.custId 
	where t2.fileId = @fileId and t2.status = 1 and t1.rate = 0 
              
 set @countclCright = @@ROWCOUNT 

--Статус обработки
 update RhCatalogItem set status = 3, errComment = isnull(errComment,'')+'Закрито право.'
   from RhCatalogItem t1 
    join CopyRight t2 on t2.objId = t1.objId and t2.custId = t1.custId and t2.endDate = cast (dateadd(day, -1, getdate()) as date) --t2.endDate = cast (@getdate as date) 
	where t1.fileId = @fileId and t1.status = 1 and t1.rate = 0 

---Закрываю владение по rate, если процент изменился
-----Ниже открою права со всеми
 create table #TmpCrId (cRightId integer, loadId integer)

 delete #TmpCrId
 update CopyRight set endDate = (CASE WHEN beginDate <=  convert(date, dateadd(day, -1, getdate()) ) THEN beginDate ELSE convert(date, dateadd(day, -1, getdate()) )  END ) 
  output inserted.cRightId  into #TmpCrId ( cRightId )
  from CopyRight t1 
     join RhCatalogItem t2 on t2.objId = t1.objId and t2.custId = t1.custId and t2.cRightId = t1.cRightId
	where t2.fileId = @fileId and 
	 t2.status = 1 and t1.rate <> t2.rate and isnull(t2.rate,0) <> 0 
	 and t2.custId = t2.rhCustId  --только свои права

  --set @countChCright = @countChCright + @@ROWCOUNT

---Нужно обнулить для открытия с новым процентом только для своего реестра
  update RhCatalogItem set cRightId = NULL, errComment = isnull(errComment,'')+'Зміна %'
    from RhCatalogItem t1  
	 join #TmpCrId  t2 on t2.cRightId = t1.cRightId 
	where t1.rhCustId = t1.custId

  update RhCatalogItem set status = 4, errComment = isnull(errComment,'') + 'СпівАвтор має інший %! Без змін!'
    from RhCatalogItem t1  
	 join CopyRight t2 on t2.cRightId = t1.cRightId 
	where t1.fileId = @fileId and 
	 t1.status = 1 and t1.rate <> t2.rate and isnull(t1.rate,0) <> 0 and t1.custId <> t1.rhCustId 

--------Новые права
insert into #TmpId (objId, itemCode) 
select t1.objId, t1.itemId 
    from RhCatalogItem t1
	where fileId = @fileId  
	    and isnull(t1.objid,0) <> 0
		and t1.status = 1 
		and isnull(t1.cRightId,0) = 0
		and rate <> 0 
	    and not exists (select 1 from #TmpId t2 where t2.objId = t1.objid and t2.itemCode = t1.itemCode)

delete #TmpCrId
insert into CopyRight 
 (custId, objId, lBasis, rate, beginDate, endDate, createDate,modifyDate, modifyLogin, roleCode,status, loadId, sourceName) 
output inserted.cRightId, inserted.loadId into #TmpCrId (cRightId, loadId)
select t1.rhCustId, t1.objId, 2, t1.rate, cast(getdate() as date), '3000-01-01', @getdate, @getdate, t3.userId, t1.roleCode, 
    (Case WHEN t1.rhCustId = t1.custId Then 1 Else 0 END ),  --свой реестр с подтверждением 
	 t1.itemId, t3.fileName
   from RhCatalogItem t1 
   join CatalogFile t3 on t3.fileId = @fileId 
        and t3.fileId = t1.fileId 
--   join #TmpId t2 on t2.itemCode = t1.itemCode --єт о только новые
   where isnull(t1.cRightId,0) = 0 
          and t1.status = 1 
		  and isnull(rhCustId,0) <> 0

 ----Проставляю права-------------
  update RhCatalogItem set cRightId = t2.cRightId, errComment  = isnull(errComment, '' ) + 'Право встановлено!' 
   from  RhCatalogItem t1 
     join #TmpCrId t2 on t2.loadId = t1.itemId 
	where t1.fileId = @fileId 

 set @countChCright = (select count(*) from  #TmpCrId )
 
--Признак обработки
  update RhCatalogItem 
    set status = 3, 
        errComment = isnull(errComment,'')+
		             (CASE when errComment is NULL and isnull(cRightId,0) <> 0 then 'Без змін!' ELSE '' END) + 
					 (CASE when cRightId is NULL then 'Без правоволодіння!' ELSE '' END)
   from  RhCatalogItem t1 
	where t1.fileId = @fileId 
	 and status = 1 


 update CatalogFile set status = 3 
   where fileId = @fileId and exists (select  1 from RhCatalogItem where fileId = @fileId and status = 3)

;with tabZap as 
(
 select  fileId, (case when  isnull(status,0) = 3 Then 1 Else 0 END ) as countOk, (case when  isnull(status,0) = 2 Then 1 Else 0 END ) as countErr 
          from RhCatalogItem 
          where fileId = @fileId
)
, 
tabZapSum as 
( select fileId, sum(countOk) as countOk, sum(countErr) as countErr  
   from tabZap  
   group by fileId )
 update CatalogFile set countOk = t2.countOk, countErr = t2.countErr, modifyDate = @getdate, 
                         comment = 'Закрито-'+rtrim(convert(char(20), @countClCright))+'; Створено прав-'+rtrim(convert(char(20), @countChCright))+'; Нових Об''єктів-'+rtrim(convert(char(20), @countNewObj))+'. '+ isnull(comment ,'')
    from CatalogFile t1 
       join tabZapSum  t2 on t2.fileId = t1.fileId 
 set @result = isnull(@result, '')+'Закрито правоволодіння-'+rtrim(convert(char(20), @countClCright))+'; Створено прав-'+rtrim(convert(char(20), @countChCright))+'; Нових об''єктів права-'+rtrim(convert(char(20), @countNewObj))+'.  Статус - виконано!'


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
	   
 set @result  = 'Операцію перервано! Зміни не прийнято!'
 set @Retcode = 1

END CATCH
return --@Retcode

END

/*
DECLARE @result VARCHAR(100), @RetCode integer;
exec CatalogInputRH 5011, @result OUTPUT, @RetCode  OUTPUT
--exec CatalogControlRH 5011, @result OUTPUT, @RetCode  OUTPUT
select @result, @retCode
--
update catalogFile set status = 0 where fileId = 5011
update RhCatalogItem set objId = NULL, rHcustId = NULL, cRightId = null, status = 0 where fileId = 5011

select * from catalogFile where fileId = 5011
select * from RhCatalogItem where fileId = 5011

update RhCatalogItem  set rate = 20 where fileId = 5011 and itemid in (1083, 1084)
select * from CopyRight where objid = 5025 and custid = 20 --cRightId = 7039
update copyright set endDate = '3000-01-01' where cRightId = 6042
update RHCatalogItem set cRightId = NULL where cRightId = 7040
delete CopyRight where cRightId = 7040
*/
