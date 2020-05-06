CREATE PROCEDURE [dbo].[CatalogInputPub_n] @fileId integer, @result  varchar(100) OUT, @RetCode integer OUTPUT
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
(itemId integer not null primary key, 
 objId integer)

------------Авторы. Распарсить и положить в AUTHORS------------------------
 create table #TmpAuthor 
 (id integer not null identity, 
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
    set @index = 1
    while @index > 0 
    begin
     set @authorName = (select dbo.ParseStr (REPLACE(@authorText,@simbRep,@simb), @simb, @index)) 
	 print @authorName+'  '+@simb
       IF isnull(@authorName,'') = ''
	           set @index = -10
         insert into #TmpAuthor ( itemId, roleType,  authorName, objid )
         select @itemId, 1, @authorName, @objId  
	         where @index>0 and not exists ( select  1 from #TmpAuthor t2 where t2.itemId = @itemId and t2.roleType = 1 and t2.authorName = @authorName)
         set @index = @index + 1
    end
	

    set @index = 1
    while @index > 0 
    begin
     set @authorName = (select dbo.ParseStr (REPLACE(@authorMusic,@simbRep,@simb), @simb, @index)) 
     if isnull(@authorName,'') = '' 
       set @index = -10
       insert into #TmpAuthor ( itemId, roleType,  authorName, objId )
       select @itemId, 2, @authorName, @objId  
	     where @index>0 and not exists ( select  1 from #TmpAuthor t2 where t2.itemId = @itemId and t2.roleType = 2 and t2.authorName = @authorName)
       set @index = @index + 1
    end

    set @index = 1
    while @index > 0 
    begin
     set @authorName = (select dbo.ParseStr (REPLACE(@performer,@simbRep,@simb), @simb, @index)) 
     if isnull(@authorName,'') = '' 
       set @index = -10
       insert into #TmpAuthor ( itemId, roleType,  authorName, objId )
       select @itemId,  3, @authorName, @objId  
	     where @index>0 and not exists ( select  1 from #TmpAuthor t2 where t2.itemId = @itemId and t2.roleType = 3 and t2.authorName = @authorName)
       set @index = @index + 1
    end

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
 select distinct authorName 
   from #TmpAuthor 
   where perId is NULL and roleType = 3 and isnull(authorName,'') <> ''

--select * from  #TmpAuthor 
--select * from  #TmpPerformer
 declare @countChCright integer = 0, @countclCright integer = 0, @countNewObj integer = 0
 ----------------------------------------------------------
 begin Transaction ImportCatalog
	BEGIN TRY
  
---Закрываю владение по rate = 0 
--14-06-2019 по протоколу от Дудки - открываю, если это народная песня -> ниже
--Если 0, не народная и есть в базе - закрываю владение 
delete #TmpId
 update CopyRight set endDate = (CASE WHEN beginDate <=  convert(date, dateadd(day, -1, getdate()) ) THEN beginDate ELSE convert(date, dateadd(day, -1, getdate()) )  END ) 
  from CopyRight t1 
     join pubCatalogItem t2 on t2.objId = t1.objId and t2.custId = t1.custId 
	where t2.fileId = @fileId 
	      and t2.status = 1 
		  and t1.rate = 0 
	      and (t2.authorText not like 'народ%' and authorMusic not like 'народ%') 
 
 set @countclCright = @@ROWCOUNT 

--Статус обработки
 update pubCatalogItem set status = 3 
   from pubCatalogItem t1 
    join CopyRight t2 on t2.objId = t1.objId and t2.custId = t1.custId 
	                   and t2.endDate = (CASE WHEN beginDate <=  convert(date, dateadd(day, -1, getdate()) ) THEN beginDate ELSE convert(date, dateadd(day, -1, getdate()) )  END ) --t2.endDate = cast (@getdate as date) 
	where t1.fileId = @fileId and t1.status = 1 and t1.rate = 0 
	    and (t1.authorText not like 'народ%' and t1.authorMusic not like 'народ%') 

---Закрываю владение по rate = 100 другого
-----Ниже открою права со всеми
 update CopyRight set endDate = (CASE WHEN beginDate <=  convert(date, dateadd(day, -1, getdate()) ) THEN beginDate ELSE convert(date, dateadd(day, -1, getdate()) )  END ) 
  from CopyRight t1 
     join pubCatalogItem t2 on t2.objId = t1.objId and t1.custId <> t2.custId
	where t2.fileId = @fileId and t2.status = 1 and t2.rate = 100
  set @countChCright = @countChCright + @@ROWCOUNT
  
---Закрываю владение по rate <> 100 свои (если процент был больше, а стал меньше)
-----Ниже открою права со всеми
create table #TmpCrId (cRightId integer, loadId integer)

 delete #TmpCrId
 update CopyRight set endDate = (CASE WHEN beginDate <=  convert(date, dateadd(day, -1, getdate()) ) THEN beginDate ELSE convert(date, dateadd(day, -1, getdate()) )  END ) 
  output inserted.cRightId  into #TmpCrId ( cRightId )
  from CopyRight t1 
     join pubCatalogItem t2 on t2.objId = t1.objId and t1.custId = t2.custId
	where t2.fileId = @fileId and t2.status = 1 and t1.rate > t2.rate 

  set @countChCright = @countChCright + @@ROWCOUNT

---Нужно обнулить для открытия с новым процентом
  update pubCatalogItem set cRightId = NULL 
    from pubCatalogItem t1  
	 join #TmpCrId  t2 on t2.cRightId = t1.cRightId 

 --set @countChCright = @@ROWCOUNT 
-------------------------------------------------
--Открываю новые объекты
  insert into objectRight (categoryCode,genreType,name,author,performer,status,modifyDate,modifyLogin,createDate,loadid,specType,innerCode,sourceName)
  output inserted.objId, inserted.loadid into #TmpId (objid, itemId)
  select 5, t2.genreCode, t2.objName, t2.authorMusic+','+t2.authorText, t2.performer, 0, @getdate, t3.userId, @getdate, t2.itemId, 1, t2.itemCode, t3.fileName
     from pubCatalogItem t2 
	  join CatalogFile t3 on t3.fileId = t2.fileId
	 where t2.fileId = @fileId 
	       and t2.status = 1 
	       and isnull(t2.objid,0) = 0

 set @countNewObj = @@ROWCOUNT 	 

insert into mediatrack (objId,iswc,name,lyrics,composers,performers, genre, modifyDate,modifyLogin)
select t1.objid, t2.iswc, t2.objName, t2.authorText, t2.authorMusic, t2.performer,  t2.genreName, @getdate, t3.userId
  from #TmpId t1 
  join  pubCatalogItem t2 on t2.fileId = @fileId and t2.itemId = t1.itemId 
  join CatalogFile t3 on t3.fileId = t2.fileId 

------------Авторы ---------
 update #TmpAuthor set objId = t2.objid 
   from #TmpAuthor t1 
    join #TmpId t2 on t2.itemId = t1.itemId 
	  
 insert into Authors (objId, roleCode, custId, authorName, isFolkOrUnknown, folkType)
  select  t1.objId, t1.roleType, NULL, t1.authorName, NULL, (CASE When t1.authorName like 'народ%' Then 3 else 1 END)
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
 create table #TmpNewPF (objid integer, perId integer primary key (objid, perid))

 insert into RelObjPerformer  (objId, perId) 
 output inserted.objId, inserted.perId into #TmpNewPF (objid, perId )
 select  distinct t1.objid, t1.perId 
   from #TmpAuthor t1 
   where t1.roleType = 3 and isnull(t1.perId,0) <> 0  
    and not exists ( select 1 from RelObjPerformer t3 where t3.objid = t1.objid and t3.perId = t1.perId )

--Вношу для поиска. Так это показывается у правообладателя. 
insert into SeekObject (codeI, objid, name) 
select distinct 2 as codei, objid, pername 
from vRelObjPerformer t1 
  where isnull(pername,'') <> '' 
    and  not exists (select  1 from SeekObject t2 where t2.codei=2 and t2.objid = t1.objid 
	and replace(t2.name,' ','' ) = replace(t1.pername,' ','' ) 
	) order by 3  
----------------
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
 select objid, performers
   from TabPF

update objectRight set performer = t2.performers 
   from objectRight t1 
     join #TmpObjPerf t2 on t2.objid = t1.objid 

update MediaTrack set performers = t2.performers 
   from MediaTrack t1 
     join #TmpObjPerf t2 on t2.objid = t1.objid 

---------------------------------------------------------
---CopyRight --Сразу проверить %
insert into #TmpId (objId, itemId) 
select t1.objId, t1.itemId 
    from pubCatalogItem t1
	where fileId = @fileId  
	    and isnull(t1.objid,0) <> 0
		and t1.status = 1 
		and rate <> 0 
		and isnull(t1.cRightId,0) = 0
	    and not exists (select 1 from #TmpId t2 where t2.objId = t1.objid and t2.itemid = t1.itemId)

insert into CopyRight 
 (custId, objId, lBasis, rate, beginDate, endDate, createDate,modifyDate, modifyLogin, roleCode,status, loadId, sourceName) 
output inserted.cRightId, inserted.loadId into #TmpCrId (cRightId, loadId)
select t1.custId, t2.objId, 2, t1.rate, cast(getdate() as date), '3000-01-01', @getdate, @getdate, t3.userId, t1.roleCode, 1, t1.itemId, t3.fileName
   from pubCatalogItem t1 
   join #TmpId t2 on t2.itemId = t1.itemId
   join CatalogFile t3 on t3.fileId = @fileId and t3.fileId = t1.fileId 
   where isnull(t1.cRightId,0) = 0

   ---
  update pubCatalogItem set cRightId = t2.cRightId
   from  pubCatalogItem t1 
     join #TmpCrId t2 on t2.loadId = t1.itemId 
	where t1.fileId = @fileId 


 set @countChCright = (select count(*) from  #TmpCrId )

 
 
/*---Контроль на 100% --Позже! таких быть не должно
;with Tab100 as 
(select sum(rate) as rate, objid 
    from copyright t1 
	join #TmpCrId t2 on t1.loadId = t2.loadId 
	group by t1.objid 
)
 update copyRight set status = 1 
   from  copyRight t1 
     join Tab100 t2 on t2.objId = t1.objId
	where t2.rate <=100
*/

--Признак обработки
  update pubCatalogItem set objid = t2.objid, status = 3 
   from  pubCatalogItem t1 
     join #TmpId t2 on t2.itemId = t1.itemId 
	where t1.fileId = @fileId 

---Нужно закрыть все права по правообладателю для тех объектов, которых нет в каталоге. 
  update CopyRight set endDate = (CASE WHEN beginDate >=  convert(date, dateadd(day, -1, getdate()) ) THEN beginDate ELSE convert(date, dateadd(day, -1, getdate()) )  END ) 
    from CopyRight t1 
	  join CatalogFile t2 on t2.fileId = 2088--@fileId  
	       and t2.custId = t1.custId 
 	  where not exists (select  1 from PubCatalogItem t3 where t3.fileId = 2088 --@fileId 
	                                                           and t3.objid = t1.objid and t3.custid = t1.custId)
	and t1.endDate >='3000-01-01'-- convert(date, dateadd(day, -1, getdate()) )

  set @countClCright  = isnull(@countClCright,0) + @@ROWCOUNT

 --если отработала, но ничего не изменила в базе (повторный файл) 
  update pubCatalogItem set status = 3 
     where isnull(objid,0) <> 0 and isnull(cRightId,0) <> 0

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
 set @result = 'Закрито правоволодіння-'+rtrim(convert(char(20), @countClCright))+'; Створено прав-'+rtrim(convert(char(20), @countChCright))+'; Нових об''єктів права-'+rtrim(convert(char(20), @countNewObj))+'.  Статус - виконано!'

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
exec CatalogInputPub_n 2088, @result OUTPUT, @RetCode  OUTPUT
--exec CatalogControlPub 2088, @result OUTPUT, @RetCode  OUTPUT
select @result, @retCode
*/

--select * from pubCatalogItem where fileid=2088
--select * from catalogFile where fileid=1057
--select * from vcopyRightSH where objid in (106781, 106780) order by name
--update pubCatalogItem set status = 0, objid = NULL, cRightId=NULL where fileId = 2088
--update CatalogFile set status = 0 where fileId = 2088


