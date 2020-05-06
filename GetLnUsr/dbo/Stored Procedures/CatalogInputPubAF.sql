

CREATE PROCEDURE [dbo].[CatalogInputPubAF] @fileId integer, @result  varchar(100) OUT, @RetCode integer OUTPUT
as
begin
--11-05-2019. Добавила в SeekObject
---Загрузка каталога издателей
--Обрабатываю только status = 1 
--Алгоритм. 
--1) Если есть такой объект с др.% - закрываю и создаю новый crightId. 
--2) Если у издателя есть объекты, которых нет в каталоге - закрываю эти crightId. 
--3) Открываю новые объекты с crightId.
--4) Исполнителей произведений дописываем (если такого нет).
--27-05-2019 insert into Authors 
--03-06-2019 - в кол-во закрытых прав, если нет в каталоге
--18-06-2019 - народные
--23-07-2019 -- ИСПОЛНИТЕЛЬ ОГРАНИЧЕНИЕ О ДЛИНЕ
--16-09-2019 -- разделение алгоритмов
SET NOCOUNT ON;
--declare @RetCode integer
set @RetCode = 0

--Ищу объекты, которые уже есть в базе - название, авторы (исполнитель не играет роли - 25-04-2019)
--Даже если проставлены ключи - все равно пересматриваю.

  if exists (select  1 from CatalogFile where fileId = @fileId and isnull(status,0) in (0,2,3,4) ) --виконано/вилучений/помилки
   BEGIN 
    print 'Статус файлу не для обробки - status in (0,3,4) ) --новий/виконано/вилучений'
    set @result = 'Статус файлу не для обробки! ' +' Виконайте контроль!'  
    set @RetCode = 1
    Return 
   END 


declare @getdate datetime = getdate() 
create table #TmpId 
(itemId integer, 
 objId integer)

------------Авторы. Распарсить и положить в AUTHORS------------------------
create table #TmpAuthor 
 (id integer not null identity primary key, 
  itemId integer, 
  roleType integer,   ---1-music, 2-lyric, 3-performer
  objId integer, 
  custId integer, 
  authorName varchar(254), 
  perId integer )

delete #TmpAuthor 
 
 declare @itemId integer, @itemCode varchar(50), @authorName varchar(254), @authorText varchar(254), @authorMusic varchar(254),
         @performer varchar(254), @simb char(1), @index integer, @simbRep char(1), @objId integer

set @simb = ','
set @simbRep = ';'

declare cur cursor for  select t1.itemId, t1.authorMusic, t1.authorText, t1.performer, t1.objId
                               from pubCatalogItem  t1 
                                                  where fileId = @fileId and status = 1 --and isnull(t1.objId,0) = 0 --чтобы отобрать новых исполнителей
open cur 
           fetch cur into   @itemId, @authorMusic, @authorText, @performer, @objid
                                                  
    while @@fetch_status = 0                                                   
    BEGIN 

----
		 insert into #TmpAuthor ( itemId, roleType,  authorName, objid )
         select @itemId, 1, outStr, @objId  
 	       from dbo.ft_ParceTab (@authorText, @simb)

		 insert into #TmpAuthor ( itemId, roleType,  authorName, objid )
         select @itemId, 2, outStr, @objId  
 	       from dbo.ft_ParceTab (@authorMusic, @simb)

		 insert into #TmpAuthor ( itemId, roleType,  authorName, objid )
         select @itemId, 3, outStr, @objId  
 	       from dbo.ft_ParceTab (@performer, @simb)

    fetch cur into @itemId, @authorMusic, @authorText, @performer, @objid
END                                                   
 close cur   
 deallocate cur      
----------------------------
---Исполнители 
create table #TmpPerId 
 (perName varchar(200) not null primary key, perId integer ) 

create table #TmpPerformer 
(id integer not null identity, 
 perId integer, 
 perName varchar(200) )

update #TmpAuthor set perId = t2.perId 
    from #TmpAuthor t1 
        join vRelObjPerformer t2 on t2.objid = t1.objId and replace(replace(t2.perName,'.',''),' ','') = replace(replace(t1.authorName,'.',''), ' ','')
       where roleType = 3

update #TmpAuthor set perId = t2.perId 
    from #TmpAuthor t1 
        join Performer t2 on replace(replace(t2.perName,'.',''),' ','') = replace(replace(t1.authorName,'.',''), ' ','')
       where roleType = 3 and isnull(objid,0) = 0

-- delete from #TmpAuthor where isnull(objid,0) <> 0  and isnull(perId,0) <> 0 

---Для открытия исполнителей
insert into #TmpPerformer  (perName) 
 select distinct left(authorName, 200) 
   from #TmpAuthor 
   where perId is NULL and roleType = 3 and isnull(authorName,'') <> ''

--select * from  #TmpAuthor 
--select * from  #TmpPerformer
declare @countChCright integer = 0, @countclCright integer = 0, @countNewObj integer = 0
----------------------------------------------------------
create table #TmpCrId (cRightId integer, loadId integer)

begin Transaction ImportCatalog
       BEGIN TRY

--Открываю новые объекты
  insert into objectRight (categoryCode,genreType,name,author,performer,status,modifyDate,modifyLogin,createDate,loadid,specType,innerCode,sourceName)
  output inserted.objId, inserted.loadid into #TmpId (objid, itemId)
  select 5, t2.genreCode, left(t2.objName, 254), left(t2.authorMusic+','+t2.authorText, 254) , t2.performer, 0, @getdate, t3.userId, @getdate, t2.itemId, 1, t2.itemCode, t3.fileName
     from pubCatalogItem t2 
         join CatalogFile t3 on t3.fileId = t2.fileId
       where t2.fileId = @fileId 
              and t2.status = 1 
              and isnull(t2.objid,0) = 0

set @countNewObj = @@ROWCOUNT     

insert into mediatrack (objId,iswc,name,lyrics,composers,performers, genre, modifyDate,modifyLogin)
select t1.objid, t2.iswc, left(t2.objName, 100), left(t2.authorText, 254), left(t2.authorMusic, 254), left(t2.performer, 254),  t2.genreName, @getdate, t3.userId
  from #TmpId t1 
  join  pubCatalogItem t2 on t2.fileId = @fileId and t2.itemId = t1.itemId 
  join CatalogFile t3 on t3.fileId = t2.fileId 

------------Авторы ---------
update #TmpAuthor set objId = t2.objid 
   from #TmpAuthor t1 
    join #TmpId t2 on t2.itemId = t1.itemId 
         
 insert into Authors (objId, roleCode, custId, authorName, isFolkOrUnknown, folkType)
  select  t1.objId, t1.roleType, NULL, left(t1.authorName,100), NULL, (CASE When t1.authorName like 'народ%' Then 3 else 1 END)
    from #TmpAuthor t1
       join #TmpId t2 on t2.objId = t1.objId
       where t1.roleType <> 3 
          and not exists (select  1 from Authors t3 where t3.objid = t1.objid and (t3.authorName = t1.authorName or t3.custId = t1.custId))
       
--Исполнители new
insert into Performer (perName) 
 output inserted.perId, inserted.perName into #TmpPerId (perId, perName )
select perName
   from #TmpPerformer 
   where perId is null 

update #TmpPerformer set perId = t2.perId 
    from #TmpPerformer t1 
         join #TmpPerId t2 on t2.perName = t1.perName 
         where isnull(t1.perId,0) = 0

update #TmpAuthor set perId = t2.perId 
    from #TmpAuthor t1
          join #TmpPerId t2 on t2.perName = t1.authorName
          where isnull(t1.perId,0) = 0


--Новые исполнители для старых объектов (исполнитель уже может быть в базе)
--В данной версии невозможно,  но оставляю на будущее
create table #TmpNewPF (objid integer, perId integer primary key (objid, perid))

insert into RelObjPerformer  (objId, perId) 
 output inserted.objId, inserted.perId into #TmpNewPF (objid, perId )
select  distinct t1.objid, t1.perId 
   from #TmpAuthor t1 
   where t1.roleType = 3 and isnull(t1.perId,0) <> 0  
    and not exists ( select 1 from RelObjPerformer t3 where t3.objid = t1.objid and t3.perId = t1.perId )

--Вношу для поиска. Так это показывается у правообладателя. 
insert into SeekObject (codeI, objid, name) 
select distinct 2 as codei, objid, left(pername, 200) 
from vRelObjPerformer t1 
  where isnull(pername,'') <> '' 
    and  not exists (select  1 from SeekObject t2 where t2.codei=2 and t2.objid = t1.objid 
       and replace(t2.name,' ','' ) = replace(t1.pername,' ','' ) 
       ) order by 3  
-------------------
---Для тех objid, что в #TmpNewPF переписать строки performers учититывая тех, что уже записаны
create table #TmpPerf 
(objid integer not null, 
 perName varchar(254) null, 
 perId integer not null, 
 primary key (objid, perId) )

create table #TmpObjPerf 
(objid integer not null, 
 performers varchar(254) null
primary key (objid) )

--Все исполнители по объекту с новым исполнителем
;with TabO as 
(select  distinct objid from #TmpNewPF )
insert into #TmpPerf  (objid, perName, perId) 
 select t1.objid, t1.perName, t1.perId
    from vRelObjPerformer t1 
         join TabO t2 on t2.objid = t1.objid 

--объекты с исполнителями
;with TabPF as 
(
select max(t1.objid) as objid, 
            performers = STUFF (
                        (SELECT distinct  ', '+ t2.pername from #TmpPerf t2 where t2.objid = t1.objid FOR XML PATH ('') ), 1, 1, ''
                              )
from #TmpPerf t1 
   group by t1.objid
)
insert into #TmpObjPerf (objid, performers)
select objid, left(performers,254)
   from TabPF

update objectRight set performer = left(t2.performers, 254)
   from objectRight t1 
     join #TmpObjPerf t2 on t2.objid = t1.objid 

update MediaTrack set performers = left(t2.performers, 254)
   from MediaTrack t1 
     join #TmpObjPerf t2 on t2.objid = t1.objid 

---------------------------------------------------------
---CopyRight --Сразу проверить %
insert into CopyRight 
 (custId, objId, lBasis, rate, beginDate, endDate, createDate, modifyDate, modifyLogin, roleCode,status, loadId, sourceName) 
output inserted.cRightId, inserted.loadId into #TmpCrId (cRightId, loadId)
select t1.custId, t2.objId, 2, t1.rate, isnull(t1.dateBegin, @getdate), '3000-01-01', --isnull(t1.dateEnd, '3000-01-01'), --всегда открытая дата для каталога (Оля, 18-09-2019)  
       @getdate,  @getdate, t3.userId, t1.roleCode, 0,  --25-09-2019 Оля попросила в вайбере 
	   t1.itemId, t3.fileName
   from pubCatalogItem t1 
   join #TmpId t2 on t2.itemId = t1.itemId
   join CatalogFile t3 on t3.fileId = @fileId and t3.fileId = t1.fileId 
   where isnull(t1.cRightId,0) = 0

--27-05-2019
--Вношу в авторы этого же издателя
declare @custId integer 
set @custId = (select custId from CatalogFile where fileId = @fileId) 
       
 insert into Authors (objId, roleCode, custId, authorName, isFolkOrUnknown, folkType)
  select  t1.objId, t3.roleCode, t3.custID, t2.name, NULL, 1
  from #TmpId t1 
  join CopyRight t3 on t3.objID = t1.objId and custId = @custId 
  join vcustomer t2 on t2.custId = t3.custId 
  where not exists (select 1 from Authors t4 where t4.objid = t3.objid and t4.custId = t3.custId and t4.roleCode = t3.roleCode) 

  ---
  update pubCatalogItem set cRightId = t2.cRightId
   from  pubCatalogItem t1 
     join #TmpCrId t2 on t2.loadId = t1.itemId 
       where t1.fileId = @fileId 


set @countChCright = (select count(*) from  #TmpCrId )

--Признак обработки
  update pubCatalogItem set objid = t2.objid, status = 3 
   from  pubCatalogItem t1 
     join #TmpId t2 on t2.itemId = t1.itemId 
       where t1.fileId = @fileId 

update CatalogFile set status = 3 
   where fileId = @fileId and exists (select  1 from PubCatalogItem where fileId = @fileId and status = 3)

;with tabZap as 
(
select  fileId, (case when  isnull(status,0) = 3 Then 1 Else 0 END ) as countOk, (case when  isnull(status,0) = 2 Then 1 Else 0 END ) as countErr 
          from PubCatalogItem 
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
 set @result = 'Створено прав-'+rtrim(convert(char(20), @countChCright))+'; Нових об''єктів права-'+rtrim(convert(char(20), @countNewObj))+'.  Статус - виконано!'

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
exec CatalogInputPub 2225, @result OUTPUT, @RetCode  OUTPUT
--exec CatalogControlPub 2225, @result OUTPUT, @RetCode  OUTPUT
select @result, @retCode
--select * from PubCatalogItem where fileId = 2225
--select * from CatalogFile

--delete pubcatalogItem where fileId = 2225 and status = 2

--Удаление каталога
delete DeleteObjectRight
insert into DeleteObjectRight
( objId, genreType, name, author, performer, categoryCode, actCode, loadId, sourceName, status )
select objId, genreType, name, author, performer, categoryCode, actCode, loadId, sourceName, 0 
   from ObjectRight 
   where sourceName = 'ТОВ УМИГ МЬЮЗІК 123.xlsx'
   --where objid in (7860, 7862)
exec  DelObjectRightTable
update pubCatalogItem set status = 0, objid = NULL, cRightId=NULL where fileId = 2225
update CatalogFile set status = 0 where fileId = 2225
*/

