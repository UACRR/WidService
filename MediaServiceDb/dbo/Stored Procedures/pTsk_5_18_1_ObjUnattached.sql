CREATE procedure  [dbo].[pTsk_5_18_1_ObjUnattached] (@date date = NULL)
as
begin
--exec [pTsk_5_18_1_ObjUnattached]
--drop table #RT

 create  TABLE #RT
( id integer not null identity primary key, 
  objid integer  null, 
  objName varchar(256) NULL, 
  performer varchar(512) null, 
  authorMus  nvarchar(2048) null, 
  authorText nvarchar(2048) null, 
  rHolder varchar(2048) null, 
  fullRate numeric(6,3) null,
  amountCollect money null, 
  amountNoshare money null,    
  comment nvarchar(2048) null
)
create  table  #tmpTab1
(
id integer not null identity primary key, 
objid integer not null, 
rolecode integer not null, 
roleName varchar(200), 
custid integer not null, 
custName varchar(200), 
rate numeric(5,2), 
isRh smallint null
)

create  table #tmpTab2 
(objid integer not null, 
 rate numeric(5,2), 
 rest30 money null, 
 rest31 money null, 
 agrStatus integer null, 
 agrStatusName varchar(200) null, 
 primary key (objid )
 )
 --drop table #TabAuthors
create table   #TabAuthors 
 (
 objId		int,
 roleCode	int, 
 custid		int, 
 rate		numeric(5,2), 
 isRh		int
 )
 

 --Звіт про неприв'язані та в пошуку об'єкти права (Малі права)
 set @date = isnull(@date, convert(date, getdate()))
 

--Отбираю авторов с процентом и ролью
insert  #TabAuthors  
select t1.objId, roleCode, t1.custid, rate, 1 as isRh
from copyright t1 , objectRight t2 ,account t3
where
 t1.objid = t2.objid and 
 t2.categoryCode = 5 and
 t3.objid=t2.objid 
 and t3.balscode=31 and
@date between isnull(t1.beginDate,'1900-01-01') and    isnull(t1.endDate, '3000-01-01')
-- '20190227' between isnull(t1.beginDate,'1900-01-01') and isnull(t1.endDate, '3000-01-01')
--order by 1
union 
select t1.objId, roleCode, t1.custid, 0 as rate, 0 as isRh
from Authors t1 , objectRight t2 ,account t3
where 
	t1.objid = t2.objid and 
	t2.categoryCode = 5
	and t3.objid=t2.objid 
 and t3.balscode=31 

--order by 1

delete #tmpTab1
insert into #tmpTab1 (objid, roleCode, roleName, custId, custName, rate, isRh)
select objid, rolecode, max(t3.name) as roleName, t1.custid, max(t2.name) as custName, sum(rate) as rate, max(isRh) as isRh
from #TabAuthors t1 , vCustomer t2 ,CreativeRoleType t3
where
 t1.custId = t2.custId	and
 t1.roleCode = t3.codeI
group by objid, t1.custId, rolecode

create table #TMPRate(
objid		int,
rate		numeric(5,2),
status		int,
primary key (objid)
)
--select * from #tmpTab1

 ---Отбираю сюда все дефектные
insert #TMPRate 
 select t1.objid, sum(isnull(rate,0)) as rate, max(t2.agrStatus) as status
 from 
  CopyRight t1, AgreementMaster t2 
  where
   t1.custId = t2.custId and
@date between isnull(t1.beginDate,'1900-01-01') and    isnull(t1.endDate, '3000-01-01')
--'20190227' between isnull(t1.beginDate,'1900-01-01') and    isnull(t1.endDate, '3000-01-01')
 group by t1.objId
 having sum(isnull(rate,0)) <100
 union 
 select t1.objid, sum(isnull(rate,0)) as rate, max(t2.agrStatus) as status
 from 
  CopyRight t1, AgreementMaster t2 
  where
   t1.custId = t2.custId and 
   (isnull(t2.agrStatus ,0) <> 2 or isnull(t1.status,0) <> 1) and
    @date between isnull(t1.beginDate,'1900-01-01') and isnull(t1.endDate, '3000-01-01') 
--'20190227' between isnull(t1.beginDate,'1900-01-01') and 	isnull(t1.endDate, '3000-01-01') 
 group by t1.objId
 having sum(isnull(rate,0)) >= 100 
 
create table #TabRest(
objid	int,
Rest30	money,
Rest31	money,
primary key (objid)
)

insert #TabRest  
select t1.objid,  sum((Case T2.balsCode When 30 Then isnull(t3.rest,0) else 0 end )) as Rest30, 
sum((Case T2.balsCode When 31 Then isnull(t3.rest,0) else 0 end )) as Rest31
from #TMPRate t1 ,Account t2 ,SaldoDay t3
where 
t1.objid = t2.objid	and
t3.accId = t2.accId and 
getdate() between t3.dateBegin and t3.dateEnd
group by t1.objid

insert into #tmpTab2 (objid, rate, rest30, rest31, agrStatus, agrStatusName)
select t1.objid, t1.rate, isnull(t2.Rest30,0), isnull(t2.Rest31,0), t1.status as agrStatus, t4.name as AgrstatusName
from #TMPRate t1 
join ObjectRight t3 on t1.objid = t3.objId
left join #TabRest t2 on t1.objid = t2.objid 
left join AgreementStatus t4 on t1.status = t4.codeI

--Результат
insert into #RT 
( objid, objName, performer, authorMus, authorText, rHolder, fullRate, amountCollect, amountNoshare, comment)
SELECT t2.objid, max(t3.name), max(t3.performer), 
    AuthorMus  = STUFF( (SELECT ',' + custName+'='+convert(varchar(10),rate) FROM #TmpTab1 t1 where t1.objid = t2.objId and roleCode = 1  FOR XML PATH ('')), 1, 1, '' ), 
	AuthorText =  STUFF( (SELECT ',' + custName+'='+convert(varchar(10),rate) FROM #TmpTab1 t1 where t1.objid = t2.objId and roleCode = 2  FOR XML PATH ('')), 1, 1, '' ), 
	Author     =  STUFF( (SELECT ',' + custName+'='+convert(varchar(10),rate) FROM #TmpTab1 t1 where t1.objid = t2.objId and roleCode not in (1,2)  FOR XML PATH ('')), 1, 1, '' ) , 
	0, 0, 0, ''
FROM #TmpTab1 t2 
join ObjectRight t3 on t2.objid = t3.objId
join #tmpTab2 t4 on t3.objid = t4.objid
GROUP BY t2.objid

update #RT set 
 fullRate = t2.rate, 
 amountCollect = t2.rest30, 
 amountNoshare = t2.rest31, 
 comment = ''
 from #RT t1, 
  #tmpTab2 t2 
 where t1.objid = t2.objid 
--drop table #TmpComm

 create table #TmpComm 
 (objid integer not null, 
  comment nvarchar(2048) null, 
  primary key (objid) 
 )

----Не підтверджений договір з правовласником 
-- drop table #TmpStatus
create table #TmpStatus(
objid			int,
custName		nvarchar(256),
primary key (objid,custName)
)



insert #TmpStatus 
select distinct t2.objid, t4.name as custName  
 from #RT t1 ,copyright t2 , AgreementMaster t3,vCustomer t4 
 where
	t1.objid = t2.objid and 
	@date between isnull(t2.beginDate,'1900-01-01') and isnull(t2.endDate, '3000-01-01')	and
--'20190227' between isnull(t2.beginDate,'1900-01-01') and 	isnull(t2.endDate, '3000-01-01')  and
    t2.custId = t3.custId and 
	t3.agrStatus <> 2	and
    t3.custId = t4.custId
 

insert #TmpComm  
select t2.objid,  
 comment = STUFF ((select ','+ t1.custName from #TmpStatus t1 where t1.objid = t2.objId FOR XML PATH ('')), 1, 1, '' )
  from #TmpStatus t2 group by t2.objid 

update #RT set comment = 'Відсутня угода з правовласником -' + t2.comment
  from #RT t1 
  join #TmpComm t2 on t1.objid = t2.objid 

----Не підтверджений процент володіння 
delete #tmpComm
delete #TmpStatus

insert #TmpStatus 
select distinct t2.objid, t4.name as custName  
 from #RT t1 ,copyright t2,vCustomer t4
	where
  t1.objid = t2.objid and @date between isnull(t2.beginDate, '1900-01-01') and isnull(t2.endDate, '3000-01-01') and 
--  t1.objid = t2.objid and '20190227' between isnull(t2.beginDate, '1900-01-01') and isnull(t2.endDate, '3000-01-01') and 
  isnull(t2.status,0) <> 1 and
  t2.custId = t4.custId
   
insert #TmpComm
select distinct t2.objid,  
 comment = STUFF ((select ','+ t1.custName from #TmpStatus t1 where t1.objid = t2.objId FOR XML PATH ('')), 1, 1, '' )
  from #TmpStatus t2 group by t2.objid 


update #RT set comment = isnull(t1.comment,'')  + 'Не підтверджено володіння - ' + isnull(t2.comment,'')
  from #RT t1 
  join #TmpComm t2 on t1.objid = t2.objid 

  select * from #RT
RETURN ;
END;

--exec pTsk_5_18_1_ObjUnattached NULL

/*
select t1.custid, rate, t2.name, t3.agrStatus, t1.status
from CopyRight t1
join vCustomer t2 on t1.custid = t2.custId
join AgreementMaster t3 on t1.custId = t3.custId
where objid = 5843
*/