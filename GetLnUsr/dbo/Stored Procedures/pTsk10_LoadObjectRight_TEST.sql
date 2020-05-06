CREATE PROCEDURE [dbo].[pTsk10_LoadObjectRight_TEST]  
as
begin

---Загрузка ОП и правообладания

SET NOCOUNT ON;
declare @RetCode integer = 0, @date datetime = getdate()
declare @accuracy float = 0.4, @precision float = 0.001;

/*
drop table #TmpObjectRight 
drop table #TmpObjectAuthor
drop table #TmpSeekObject 
drop table #TmpPerformer
drop table #TmpId 
*/
------------------------------------------------------
/*
---Далее забираю из процедуры
create table #TmpTabObjectRight 
(WIC integer not null, 
 objId integer,
 objIdNew integer, 
 genreType integer,  --41
 name varchar(254),
 iswc varchar(11), 
 author varchar(254),
 lyrics varchar(254),
 composers varchar(256),
 performers varchar(254),
 genre varchar(254), 
 specType integer,   --MOD = 3, ORI = 1 
 duration time 
 primary key (WIC)
)
--drop table #TmpTabObjectAuthor
create table #TmpTabObjectAuthor
(WIC integer not null, 
 seqNr smallint not null, 
 IP_BASE_NR varchar(13), 
 lstName varchar(254),
 fstName varchar(254),
 authorName varchar(254), 
 IPInr varchar(11), 
 authorRole varchar(100), 
 roleCode integer, 
 ratePER numeric(10,5), 
 rateMEC numeric(10,5), 
 rhCustId integer,
 custIdNew integer, 
 perId integer,  --Исполнитель
 cRightId integer null, 
 objid integer null, 
 id integer not null identity, 
 custIdSub integer, 
 dateEndSub date
primary key (WIC, seqNr) 
)

create table #TmpTabPerformer
(id integer not null identity primary key, 
 WIC integer, 
 seqNr smallint,
 name varchar(254), 
 ISRC varchar(20), 
 perId integer null
)

create table #TmpTabSeekObject 
( WIC integer, 
  name varchar(100), 
  codeI integer, 
  primary key (WIC, name) 
)
*/

Print 'pTsk10_InputWID' 
--Вношу ОП 

--drop table #TmpId 
create table #TmpId 
(id integer, loadId_S varchar(20), loadId_I integer)

--drop table #TmpObjectRight 
create table #TmpObjectRight 
(WIC integer not null, 
 objId integer,
 objIdNew integer, 
 genreType integer,  --41
 name varchar(254),
 iswc varchar(11), 
 author varchar(254),
 lyrics varchar(254),
 composers varchar(256),
 performers varchar(254),
 genre varchar(254), 
 specType integer,   --MOD = 3, ORI = 1 
 duration time 
 primary key (WIC)
)
--drop table #TmpObjectAuthor
create table #TmpObjectAuthor
(WIC integer not null, 
 seqNr smallint not null, 
 IP_BASE_NR varchar(13), 
 lstName varchar(254),
 fstName varchar(254),
 authorName varchar(254), 
 IPInr varchar(11), 
 authorRole varchar(100), 
 roleCode integer, 
 ratePER numeric(10,5), 
 rateMEC numeric(10,5), 
 rhCustId integer,
 custIdNew integer, 
 perId integer,  --Исполнитель
 cRightId integer null, 
 objid integer null, 
 id integer, -- not null identity, 
 custIdSub integer, 
 dateEndSub date
primary key (WIC, seqNr) 
)
--drop table #TmpPerformer
create table #TmpPerformer
(id integer not null, -- identity primary key, 
 WIC integer, 
 seqNr smallint,
 name varchar(254), 
 ISRC varchar(20), 
 perId integer null
)
--drop table #TmpSeekObject 
create table #TmpSeekObject 
(WIC integer, 
 name varchar(100), 
 codeI integer, 
 primary key (WIC, name) 
)

--Забираю для обновления ОП
insert into #TmpObjectRight (WIC, objId, genreType, name, iswc, author, lyrics,  composers,  performers, genre, duration, specType ) --MOD = 3, ORI = 1 
  select WIC, objId, genreType, name, iswc, author, lyrics,  composers,  performers, genre, duration, specType 
    from ##TmpTabObjectRight 
	
 insert into #TmpPerformer (id, WIC, seqNr, name, ISRC, perId)
  select id, WIC, seqNr, name, ISRC, perId  
  from ##TmpTabPerformer

 insert into #TmpSeekObject  (WIC, name, codeI)
  select WIC, name, codeI 
  from  ##TmpTabSeekObject 

 insert into #TmpObjectAuthor ( WIC, seqNr, IP_BASE_NR, lstName, fstName, authorName, IPInr, authorRole, roleCode, ratePER, rateMEC, rhCustId ,
  custIdNew, perId, cRightId, objid, id, custIdSub, dateEndSub) 
 select  WIC, seqNr, IP_BASE_NR, lstName, fstName, authorName, IPInr, authorRole, roleCode, ratePER, rateMEC, rhCustId ,
  custIdNew, perId, cRightId, objid, id, custIdSub, dateEndSub 
  from ##TmpTabObjectAuthor

------Идентификация-----------
--ПРоверяю по таблице соответствия --главная проверка
 update #TmpObjectRight set objid = t2.objid 
   from #TmpObjectRight t1 
    join MSWIC t2 on t2.WIC = t1.WIC
   where isnull(t1.objid,0) = 0

--ПРоверяю если есть такие ОП  - по ISWC 
 update  #TmpObjectRight set objid = t2.objid 
   from #TmpObjectRight  t1 
    join MediaTrack t2 on t2.iswc = t1.iswc 

--ПРоверяю если есть такие ОП  - по WID 
 update  #TmpObjectRight set objid = t2.objid 
   from #TmpObjectRight  t1 
    join ObjectRight t2 on cast(t2.loadid as integer) = t1.WIC and sourceName = 'WID_IPI'
   where isnull(t1.objid,0) = 0

--!!! --Нужно усилить контроль
--Проверяю если есть такие ОП - по Наименованию (полное совпадение) и авторам 
;with TabObjCoef as 
(select t1.WIC, t2.objId, max([dbo].[Ft_tsk_3_Accurace]( t4.authorName, t3.authorName,  0.001 ))*count(*) as coeff
--select distinct t1.WIC, t2.objid, t4.authorName, t3.authorName,([dbo].[Ft_tsk_3_Accurace_strong]( t4.authorName, t3.authorName,  0.001 ))--, *
   from #TmpObjectRight  t1 
    join ObjectRight t2 on t1.name = t2.name 
	join #TmpObjectAuthor t3 on t3.WIC = t1.WIC
	join Authors t4 on t4.objid = t2.objid and t4.roleCode <> 8 and t3.roleCode <> 8
	and left(t4.authorName,3) like left(t3.authorName,3)+'%' and [dbo].[Ft_tsk_3_Accurace_strong]( t4.authorName, t3.authorName,  0.001 ) > 0.90
 where isnull(t1.objId,0) = 0
 group by t1.WIC, t2.objId  
 ), 
 TabCoeff as 
 (select WIC, max(coeff) as coeff
   from TabObjCoef 
   group by WIC
 ), 
 TabWIC as 
 (select t1.WIC, max(t2.objId) as objid
   from TabCoeff t1 
    join TabObjCoef t2 on t1.WIC = t2.WIC and t1.coeff = t2.coeff
   group by t1.WIC
 )
update #TmpObjectRight set objid = t2.objid 
   from #TmpObjectRight t1 
     join TabWIC  t2 on t1.WIC = t2.WIC 

--#TmpObjectAuthor - заменяю издателя на субиздателя и добавляю издателя с 0-м процентом. 
--Субиздатель - смотрю актуальные даты
 update #TmpObjectAuthor set custIdSub = t2.custIdSub, dateEndSub = t2.dateEnd
    from #TmpObjectAuthor t1 
	  join RelSubPublish t2 on t2.custIdPub = t1.rhCustId 
	where getdate() between isnull(t2.dateBegin,'1900-01-01') and isnull(dateEnd, '3000-01-01')

-- добавляю субиздателя с процентом издателя, а издателю ставлю проценты 0 
insert into #TmpObjectAuthor (WIC, seqNr, IP_BASE_NR, lstName, fstName, authorName, IPInr, authorRole, roleCode, ratePER, rateMEC, rhCustId, custIdNew, perId, cRightId, objid, custIdSub, dateEndSub )
select  WIC, seqNr, t2.InterCode as IP_BASE_NR, t2.name, '', t2.name, 
         t2.IPIBase, t1.authorRole, t1.roleCode, t1.ratePER, t1.rateMEC, t1.custIdSub, t1.custIdNew, t1.perId, t1.cRightId, t1.objid, NULL, t1.dateEndSub
  from #TmpObjectAuthor t1
  join vCustomerRHolder t2 on t1.custIdSub = t2.custId
  where isnull(t1.custIdSub,0) <> 0 --издатели с субиздателями

update #TmpObjectAuthor set rateMEC = 0, ratePER = 0 
  where isnull(custIdSub,0) <> 0 --издатели

--одинаковые права по идентифицированным удаляю
delete #TmpObjectAuthor 
  from #TmpObjectAuthor t1 
    join CopyRight t2 on t1.objid = t2.objId and t1.rhCustId = t2.custId and t1.roleCode = t2.roleCode and t1.rateMEC = t2.rateMech and t1.ratePER = t2.rate 
  where getdate() between t2.beginDate and t2.endDate


BEGIN TRANSACTION LoadObject
	BEGIN TRY
    RAISERROR (N'pTsk10_LoadObject - BEGIN!', 0, 127) WITH NOWAIT

-------Создаю новые объекты -----------------------
--declare @date date = getdate()

delete #TmpId
 insert into ObjectRight  (categoryCode, genreType, name, author, performer,
    modifyDate, modifyLogin, createDate,  loadid, specType,  innerCode, sourceName)
 output inserted.objid, inserted.loadId into #TmpId (id, loadId_S)
 select 5, genreType, name, author, performers,  @date, 'REPORT', @date, WIC, specType, objid, 'WID_IPI'  --источник может коррект.
  from #TmpObjectRight 
  where isnull(objid,0) = 0

insert into MediaTrack 
 (objId, iswc, name, lyrics, composers, performers, genre, modifyDate,modifyLogin,duration)
 select objid, iswc, name, lyrics, composers, performers, genre, @date, 'REPORT', duration
  from #TmpObjectRight t1
      join #TmpId t2 on t2.loadId_S = cast(t1.WIC as varchar(20))

--проставляю ключ objid
update #TmpObjectRight set objid = t2.id, objidNew = t2.id 
  from #TmpObjectRight t1 
    join #TmpId t2 on t2.loadId_S = cast(t1.WIC as varchar(20))

update #TmpObjectAuthor set objid = t2.objid 
  from #TmpObjectAuthor t1 
    join #TmpObjectRight t2 on t1.WIC = t2.WIC
-------------------------------------
--Алгоритм. Одинаковых удаляю из #TmpObjectAuthor, недостающих добавляю в CopyRight, если в CopyRight есть лишние - закрываю. Если общий процент больше 100 -> status = 0 -> в журнал
--
create table #TmpIdCR (id integer, loadId integer, loadSecNr integer, typeWork integer)  --1-delete

delete #TmpIdCR
--Закрываю, чего нет в #TmpObjectAuthor
--declare @date date = getdate()
 update CopyRight set endDate = convert(date, getdate()) 
 output inserted.cRightId, inserted.loadId, inserted.loadSeqNr, 1  into #TmpIdCR (id, loadId, loadSecNr, typeWork)
    from CopyRight t1
	join #TmpObjectRight  t2 on t2.objid = t1.objid 
	where not exists (select  1 from #TmpObjectAuthor t3 where t3.objid = t1.objid and t3.rhCustId = t1.custId and t3.roleCode = t1.roleCode and t1.rateMech = t3.rateMEC and t1.rate = t3.ratePER)
	  and exists (select  1 from #TmpObjectAuthor t4 where t4.objid = t2.objId)

insert into SystemMessage (modifydate, nameMain, name, keyObj, text, sysname, custId)
select  getdate(), 'Transfer Object', 'Закрито правоволодіння ', NULL, 'Закрито правоволодіння - '+ (select  cast(count(*) as varchar(10)) from #TmpIdCR), 'pTsk10_LoadObject', NULL

--Добавляю чего нет в CopyRight. Для новых объектов beginDate = сегодня, для старых - завтра.
delete #TmpIdCR 
insert into CopyRight ( custId, objId, lBasis, rate, rateMech, beginDate, endDate, 
  createDate, modifyDate, modifyLogin, permCode, parentId, roleCode, status,
  loadId,  sourceName,  loadSeqNr)
output inserted.cRightId, inserted.loadId, inserted.loadSeqNr, 2  into #TmpIdCR (id, loadId, loadSecNr, typeWork)
select t1.rhCustId, t1.objId, NULL, t1.ratePER, t1.rateMEC, 
 (Case WHEN isnull(t0.objIdNew,0) = 0 Then @date ELSE dateadd(day, 1, @date) END) as beginDate, 
 '3000-01-01',  --нужно проставить даты!!!
 @date, @date, 'Transfer', NULL, NULL, roleCode, 
 NULL, --статус
 t1.WIC,
 'WID_IPI', 
  t1.SeqNr 
  from  #TmpObjectRight t0 
   join #TmpObjectAuthor t1 on t1.objid = t0.objid
 where isnull(t1.rhcustId, 0) >0   --таких не должно быть

--Проставляю ключи
 Update #TmpObjectAuthor set crightId = t2.id 
    from #TmpObjectAuthor t1 
    join #TmpIdCR t2 on t2.loadId = t1.WIC and t2.loadSecNr = t1.SeqNr

--Статус Если >100% - status=0
create table #TmpPrs 
( objId integer, 
  rateMec money, 
  ratePer money
 primary key (objId)) 

insert into #TmpPrs (objId, rateMec, ratePer) 
select  t2.objId, sum(t2.rateMech) as rateMec, sum(t2.rate) as ratePer
   from #TmpObjectRight  t1 
     join copyRight t2 on t1.objid = t2.objId and getdate() between t2.beginDate and t2.endDate
  group by t2.objId 

 update CopyRight set status = (CASE WHEN (rateMec > 100 or ratePer > 100) Then NULL Else 1 END)
   from CopyRight t1 
    join #TmpPrs t2 on t2.objid = t1.objId 
 
 update CopyRight set status = 0 
  from CopyRight t1 
    join #TmpPrs t2 on t2.objid = t1.objId 
   where status is NULL 

--Записываю ошибки
insert into SystemMessage (modifydate, nameMain, name, keyObj, text, sysname, custId)
select  getdate(), 'Transfer Object', 'Перевищено % правоволодіння >100', t1.objId,  'Правоволодіння (>100%) - '+t2.name, 'pTsk10_LoadObject', NULL
  from #TmpPrs t1 
    join objectRight t2 on t1.objid = t2.objId 
   where (t1.rateMec > 100 or t1.ratePer > 100)

--Записываю количественные изменения в журнал
insert into SystemMessage (modifydate, nameMain, name, keyObj, text, sysname, custId)
select  getdate(), 'Transfer Object', 'Відкрито ОП', NULL, 'Відкрито ОП - '+ (select  cast(count(*) as varchar(10)) from #TmpObjectRight where isnull(objidNew,0) <> 0 ), 'pTsk10_LoadObject', NULL 

insert into SystemMessage (modifydate, nameMain, name, keyObj, text, sysname, custId)
select  getdate(), 'Transfer Object', 'Відкрито ОП', objid, 'Відкрито ОП - '+ name, 'pTsk10_LoadObject', NULL 
  from  #TmpObjectRight where isnull(objidNew,0) <> 0 

insert into SystemMessage (modifydate, nameMain, name, keyObj, text, sysname, custId)
select  getdate(), 'Transfer Object', 'Зміни в ОП ', t1.objId, 'Зміни ОП - '+ t1.name+' -'+t2.authorName, 'pTsk10_LoadObject', t2.rhCustId 
  from #TmpObjectRight t1
     join #TmpObjectAuthor t2 on t1.WIC = t2.WIC
  where isnull(objIdNew,0)=0

--Добавляю в таблмцу авторов
insert into Authors (objId, roleCode, custId, authorName, folkType)
 select t1.objid,  roleCode, rhCustId, authorName,  1
  from #TmpObjectAuthor t1 
  where not exists (select  1 from Authors t2 where t2.objid = t1.objid  and t2.custId = t1.rhCustId and t2.roleCode = t1.roleCode) 
    and isnull(t1.objid,0) <> 0

----! Придумать! Записать в журнал ошибки процентов, открытые объекты и копирайты по каждому отчету. 

--Альтернативные названия
insert into seekObject (codei, objid, name) 
 select 1, t2.objId, t1.Name  
   from  #TmpSeekObject t1
     join #TmpObjectRight  t2 on t2.WIC = t1.WIC 
   where not exists (select  1 from seekObject t3 where t3.codeI=1 and t2.objId = t3.objId and t1.name = t3.name)

--Исполнители + Альтернативные исполнители
insert into seekObject (codei, objid, name) 
 select 2, t2.objId, t1.Name  
   from  #TmpPerformer t1
     join #TmpObjectRight  t2 on t2.WIC = t1.WIC 
  where not exists (select  1 from seekObject t3 where t3.codeI = 2 and t2.objId = t3.objId and t1.name = t3.name)

--Performer можно и не писать, но пока не отменили
create table #TmpPerId (id integer, name varchar(254) not null primary key) 
 insert into Performer (perName) 
 output inserted.perId, inserted.perName into #TmpPerId (id, name)
 select distinct name from #TmpPerformer 
   where isnull(name,'') <> '' 

 update #TmpPerformer set perId = t2.id 
   from #TmpPerformer t1, 
         #TmpPerId t2 
	where t1.name = t2.name 

 insert into relObjPerformer(objid, perId) 
  select distinct t1.objid, t2.perId 
    from #TmpObjectRight t1 
	 join #TmpPerformer t2 on t2.WIC = t1.WIC 
	   and isnull(t2.perId,0) <> 0  

--Записываю ключи в таблицу
 update ##TmpTabObjectRight set objid = t2.objId 
   from ##TmpTabObjectRight t1 
     join #TmpObjectRight t2 on t1.WIC = t2.WIC 

 update ##TmpTabObjectAuthor set objid = t2.objid, cRightId = t2.cRightId
    from ##TmpTabObjectAuthor t1 
      join #TmpObjectAuthor t2 on t1.WIC = t2.WIC and t1.seqNr = t2.seqNr

--------------------------------------------------------------------
--Журналы WID для дальнейшей синхронизации данных
--Записываю в таблицы соответствия)
 insert into RepMSWIC (WIC, objId, dateCreate)
   select distinct WIC, objId, @date
     from #TmpObjectRight t1
	 where isnull(WIC,0)<>0  
	   and isnull(objId,0)<>0 
	   and not exists (select  1 from RepMSWIC t2 where t2.objId = t1.objId and t2.WIC = t1.WIC)

;with TabAuthors as 
(select  max(rhCustId) as custId, max(IP_BASE_NR) as IP_BASE_NR, max(IPInr) as IPInr
from #TmpObjectAuthor
group by IP_BASE_NR 
)
  insert into RepMSIPI (custId, IP_BASE_NR, IPInr, dateCreate) 
  select t1.custId, t1.IP_BASE_NR, t1.IPInr, @date
    from TabAuthors t1 
	 where not exists (select  1 from repMSIPI t2 where t2.custId = t1.custId and t2.IP_BASE_NR = t1.IP_BASE_NR)

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
 --return @Retcode
 END CATCH

---Нужно записать в журнал синхронизации

return @Retcode
END

-----------------------------------------------
--exec pTsk10_LoadObjectRight_TEST

