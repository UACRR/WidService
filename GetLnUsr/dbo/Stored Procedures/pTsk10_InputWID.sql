
CREATE  PROCEDURE [dbo].[pTsk10_InputWID]  
as
begin

---Вызываемая процедура загрузки из WID_IPI

SET NOCOUNT ON;
declare @RetCode integer = 0, @date datetime = getdate()
declare @accuracy float = 0.4, @precision float = 0.001;

create table #TmpId 
(id integer, loadId_S varchar(20), loadId_I integer)
------------------------------------------------------
/*
---Далее забираю из WIC
create table #TmpObjectRight 
(WIC integer not null, 
 objId integer,
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
 id integer not null identity, 
 custIdSub integer, 
 dateEndSub date
primary key (WIC, seqNr) 
)
--drop table #TmpAuthors 
create table #TmpAuthors 
(IPInr varchar(11) not null,
 IP_BASE_NR varchar(13), 
 lstName varchar(254),
 fstName varchar(254),
 authorName varchar(254), 
 rhCustId integer,
 custIdNew integer, 
 roleCode integer,
 CmCodePER varchar(10), --community
 CmCodeMEC varchar(10), --community
 CmCustIdPER integer, --community
 CmCustIdMEC integer, --community
 isAnk smallint null --открывать анкету
primary key (IPInr ) 
)
 
create table #TmpPerformer
(id integer not null identity primary key, 
 WIC integer, 
 seqNr smallint,
 name varchar(254), 
 ISRC varchar(20), 
 perId integer null
)

*/
Print 'pTsk10_InputWID' 
--Вношу ОП 
 insert into ObjectRight  (categoryCode, genreType, name, author, performer,
    modifyDate, modifyLogin, createDate,  loadid, specType,  innerCode, sourceName)
 output inserted.objid, inserted.loadId into #TmpId (id, loadId_S)
 select 5, genreType, name, author, performers,  @date, 'REPORT', @date, WIC, specType, objid, 'WID_IPI'
  from #TmpObjectRight 
  where isnull(objid,0) = 0

update #TmpObjectRight set objid = t2.id 
  from #TmpObjectRight t1 
    join #TmpId t2 on t2.loadId_S = cast(t1.WIC as varchar(20))

update #TmpObjectAuthor set objid = t2.id 
  from #TmpObjectAuthor t1 
    join #TmpId t2 on t2.loadId_S = cast(t1.WIC as varchar(20))

insert into Mediatrack 
 (objId, iswc, name, lyrics, composers, performers, genre, modifyDate,modifyLogin,duration)
 select objid, iswc, name, lyrics, composers, performers, genre, @date, 'REPORT', duration
  from #TmpObjectRight t1
      join #TmpId t2 on t2.loadId_S = cast(t1.WIC as varchar(20))

-------------------------------------
delete #TmpId
--Правообладатели - Открываю не найденные
 insert into Customer (custType, status, loadId)
  output inserted.custId, inserted.loadId into #TmpId (Id, loadId_I)
  select 5, 0,  convert(integer, IPInr)
    from #TmpAuthors 
    where isnull(rhCustId,0) = 0

 update #TmpAuthors set rhCustId = t2.id, custIdNew = t2.id
   from #TmpAuthors t1,  
        #TmpId t2 
     where  convert(integer, t1.IPInr) = t2.loadId_I 

--Проставить признак правообладателя, чтобы открывать ему внешнюю анкету, если есть хоть где-то проценты (пока открываю всем внешнюю) 

 update #TmpObjectAuthor set rhCustId = t2.rhCustId, custIdNew = t2.custIdNew
   from #TmpObjectAuthor t1 
      join #TmpAuthors t2 on t2.IPInr = t1.IPInr 
	where isnull(t1.rhCustId,0) = 0 
 update #TmpObjectAuthor set rhCustId = t2.rhCustId, custIdNew = t2.custIdNew
   from #TmpObjectAuthor t1 
      join #TmpAuthors t2 on t2.Ip_base_NR = t1.Ip_base_NR
	where isnull(t1.rhCustId,0) = 0 

 insert into RightHolder (custId, rHolderType, interCode, innerCode, IPIBase, comment,  aroundWord) 
   select custIdNew, (Case When roleCode = 8 Then 3 Else 1 END), t1.IP_BASE_NR, custIdNew, t1.IPInr, 'WID_IPI', NULL 
    from #TmpAuthors t1  
	where isnull(t1.custIdNew,0) <> 0

 insert into AnketaExternal (custId, name, firstName, countryCode) 
   select custIdNew, lstName, fstName, NULL
    from #TmpAuthors t1  
	where isnull(custIdNew,0) <> 0

----------------------
--Субиздатель - смотрю актуальные даты
 update #TmpObjectAuthor set custIdSub = t2.custIdSub, dateEndSub = t2.dateEnd
    from #TmpObjectAuthor t1 
	  join RelSubPublish t2 on t2.custIdPub = t1.rhCustId 
	where getdate() between isnull(t2.dateBegin,'1900-01-01') and isnull(dateEnd, '3000-01-01')
---------------------------

insert into Authors (objId, roleCode, custId, authorName, folkType)
 select t1.objid,  roleCode, rhCustId, authorName,  1
  from #TmpObjectAuthor t1 
  where not exists (select  1 from Authors t2 where t2.objid = t1.objid  and t2.custId = t1.rhCustId and t2.roleCode = t1.roleCode) 

--Добавляю субиздателей
   insert into Authors (objid, roleCode, custId, authorName, folkType)
   select t1.objid, t1.roleCode, t1.custIdSub, t3.name, 1
     from #TmpObjectAuthor t1, 
		  vCustomer t3 
	 where t1.custIdSub = t3.custId 
	  and isnull(t1.custIdSub,0) <> 0
	  and not exists (select  1 from Authors t2 where t2.objid = t1.objid  and t2.custId = t3.custId and t2.roleCode = t1.roleCode) 

Print 'CopyRight Begin'
------Субиздатель
--Если есть субиздатель - издателю в CopRight rate = 0, субиздателя вношу в Copyright c rate <> 0 и в авторы как правообладателя
--сумма процентов > 100 - статус не подтвержденные
------Правообладание
delete #TmpId
;with TabPrc as 
(select t1.WIC, sum(isnull(ratePER,0)) as ratePER_S, sum(isnull(rateMEC,0)) as rateMEC_S 
 from #TmpObjectAuthor t1 
 group by t1.WIC)
insert into CopyRight ( custId, objId, lBasis, rate, rateMech, beginDate, endDate, 
  createDate, modifyDate, modifyLogin, permCode, parentId, roleCode, status,
  loadId, 
  sourceName, 
  lBasisComment)
output inserted.cRightId, inserted.loadId into #TmpId (id, loadId_I)
select t1.rhCustId, t1.objId, NULL, t1.ratePER, t1.rateMEC, @date, '3000-01-01',  --нужно проставить даты!!!
  @date, @date, 'ADMIN', NULL, NULL, roleCode, 
  (CASE WHEN t2.rateMEC_S>100 or t2.ratePER_S>100 THEN 0 Else 1 END) as status, 
   t1.id,
  'WID_IPI', 
   cast(t1.WIC as numeric(30))*1000000+seqNr 
  from #TmpObjectAuthor t1 
      join TabPrc t2 on t2.WIC = t1.WIC

update #TmpObjectAuthor set cRightId = t2.id 
    from #TmpObjectAuthor t1 
	  join #TmpId t2 on t2.loadId_I = t1.id

---Субиздатель - добавляю с процентами издателя
insert into CopyRight ( custId, objId, lBasis, rate, rateMech, beginDate, endDate, 
  createDate, modifyDate, modifyLogin, permCode, roleCode, status,
  loadId, sourceName, lBasisComment, parentId)
select t1.custIdSub, t1.objId, NULL, t1.ratePER, t1.rateMEC, @date, '3000-01-01',  --нужно проставить даты!!!
  @date, @date, 'ADMIN', NULL, t1.roleCode, t2.status, 
   id, 'WID_IPI', cast(t1.WIC as numeric(30))*1000000+seqNr, t1.cRightId 
  from #TmpObjectAuthor t1 
    join CopyRight t2 on t2.cRightId = t1.cRightId
   where isnull(t1.custIdSub,0) <> 0 

---Издателю устанавливаю 0 проценты
 update CopyRight set rate = 0, rateMech = 0 
   from CopyRight t1
	 join #TmpObjectAuthor t3 on t3.cRightId = t1.cRightId
   where isnull(t3.custIdSub,0) <> 0 

Print 'CopyRight End'
RAISERROR (N'CopyRight End!', 0, 127) WITH NOWAIT

----! Придумать! Записать в журнал ошибки процентов, открытые объекты и копирайты по каждому отчету. 

--Альтернативные названия
/*--заполнение #TmpseekObject в главной процедуре
insert into seekObject (codei, objid, name) 
  select 1, t2.objid, t1.name  
    from WID_IPI..wSeekObject t1 
	   join #TmpObjectRight  t2 on t2.WIC = t1.WIC 
*/
--Исполнители
--!!#TmpPerformer
/*--заполнение #TmpPerformer в главной процедуре
insert into seekObject (codei, objid, name) 
  select 2, t2.objid, ltrim(t1.lstNa+isnull(' '+t1.fstNa,''))
    from WID_IPI..wSeekPerformer t1
	   join #TmpObjectRight  t2 on t2.WIC = t1.WIC 
*/

--Альтернативніе названия
insert into seekObject (codei, objid, name) 
 select 1, t2.objId, t1.Name  
   from  #TmpSeekObject t1
     join #TmpObjectRight  t2 on t2.WIC = t1.WIC 

--Исполнители + Альтернативные исполнители
insert into seekObject (codei, objid, name) 
 select 2, t2.objId, t1.Name  
   from  #TmpPerformer t1
     join #TmpObjectRight  t2 on t2.WIC = t1.WIC 

--select * from performer 
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


---Вношу права по обществам
  
--Если %=0 по механике - без группы 2. Если %=0 по публичке - без групп 1, 2, 4, 5.
declare @myCmCode char(3) 
set @myCmCode = (select left(max(interCode),3) from vMyAnk) 

---Устанавливаю коды соответствия публички и механики
declare @KindGroupPER integer, @KindGroupMEC integer
set @KindGroupPER = (select  max(crGroupCode) from vRelSchemaKindCode where CDE = 'PER' )
set @KindGroupMEC = (select  max(crGroupCode) from vRelSchemaKindCode where CDE = 'MEC' )

---TermsOfService 
--Мой сервис = 1,  0 - не мой сервис
 insert into TermsOfService (custId, crKindCode, ourService) 
   select  rHcustId, t2.codeI, 
        (Case WHEN isnull(t1.CmCodePER,0) = @myCmCode and t2.crGroupCode = @KindGroupPER THEN 1 
		  ELSE (CASE WHEN isnull(t1.CmCodeMEC,0) = @myCmCode and t2.crGroupCode = @KindGroupMEC THEN 1 ELSE  0 END ) END )
     from #TmpAuthors t1 
	 full outer join CopyrightKind t2 on t2.codei <> 0
	 where isnull(custIdNew,0) <> 0 

--CustCmRight
insert CustCmRight (custId, cRKindCode, cmCustId, dateBegin, dateEnd) 
select  t1.rhCustId, t2.codeI, t3.custId, cast(getdate() as date), '3000-01-01' 
   from #TmpAuthors t1 
	 inner join CopyrightKind t2 on t2.crGroupCode = @KindGroupMEC
	 join Community t3 on t3.interCode = t1.CmCodeMEC 
  where isnull(custIdNew,0) <> 0 

insert CustCmRight (custId, cRKindCode, cmCustId, dateBegin, dateEnd) 
select  t1.rhCustId, t2.codeI, t3.custId, cast(getdate() as date), '3000-01-01' 
   from #TmpAuthors t1 
	 inner join CopyrightKind t2 on t2.crGroupCode = @KindGroupPER
	 join Community t3 on t3.interCode = t1.CmCodePER 
   where isnull(custIdNew,0) <> 0 

    
--------------------------------------------------------------------
--Журналы WID для дальнейшей синхронизации данных
--Записываю в таблицы соответствия)
 insert into RepMSWIC (WIC, objId, dateCreate)
   select distinct WIC, objId, @date
     from #TmpObjectRight t1
	 where isnull(WIC,0)<>0  
	   and isnull(objId,0)<>0 
	   and not exists (select  1 from RepMSWIC t2 where t2.objId = t1.objId and t2.WIC = t1.WIC)

  insert into RepMSIPI (custId, IP_BASE_NR, IPInr, dateCreate) 
  select distinct  t1.custIdNew, t1.IP_BASE_NR, t1.IPInr, @date
    from #TmpAuthors t1 
	where isnull(custIdNew,0) <> 0 
	  and not exists (select  1 from repMSIPI t2 where t2.custId = t1.custIdNew and t2.IP_BASE_NR = t1.IP_BASE_NR)

return @Retcode
END

-----------------------------------------------
--exec pTsk10_InputWID 

