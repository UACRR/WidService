CREATE FUNCTION ft_Tsk_5_18_1_ObjUnattached (@date date = NULL)
RETURNS @RT TABLE 
( id integer not null identity primary key, 
  objid integer  null, 
  objName varchar(100) NULL, 
  performer varchar(200) null, 
  authorMus  varchar(1024) null, 
  authorText varchar(1024) null, 
  rHolder varchar(1024) null, 
  fullRate numeric(10,5) null,
  amountCollect money null, 
  amountNoshare money null,    
  comment varchar(1024) null
)
  as
  BEGIN 
--Звіт про неприв'язані та в пошуку об'єкти права (Малі права)
 set @date = isnull(@date, convert(date, getdate()))
 
declare @tmpTab1 table  
(
id integer not null identity primary key, 
objid integer not null, 
rolecode integer not null, 
roleName varchar(200), 
custid integer not null, 
custName varchar(200), 
rate numeric(5,2), 
isRh smallint null)

--Отбираю авторов с процентом и ролью
;with TabAuthors as 
(
select t1.objId, roleCode, custid, rate, 1 as isRh
from copyright t1 
join objectRight t2 on t1.objid = t2.objid and t2.categoryCode = 5
where @date between isnull(t1.beginDate,'1900-01-01') and isnull(t1.endDate, '3000-01-01')
--order by 1
union 
select t1.objId, roleCode, custid, 0 as rate, 0 as isRh
from Authors t1 
join objectRight t2 on t1.objid = t2.objid and t2.categoryCode = 5
--order by 1
)
insert into @tmpTab1 (objid, roleCode, roleName, custId, custName, rate, isRh)
select objid, rolecode, max(t3.name) as roleName, t1.custid, max(t2.name) as custName, sum(rate) as rate, max(isRh) as isRh
from TabAuthors t1 
join vCustomer t2 on t1.custId = t2.custId
join CreativeRoleType t3 on t1.roleCode = t3.codeI
group by objid, t1.custId, rolecode


declare @TmpTab2 table 
(objid integer not null, 
 rate numeric(10,5), 
 rest30 money null, 
 rest31 money null, 
 agrStatus integer null, 
 agrStatusName varchar(200) null, 
 primary key (objid ))

 ---Отбираю сюда все дефектные
; with TMPRate as 
 (
 select t1.objid, sum(isnull(rate,0)) as rate, max(t2.agrStatus) as status
 from 
  CopyRight t1 
  join AgreementMaster t2 on t1.custId = t2.custId
 where @date between isnull(t1.beginDate,'1900-01-01') and isnull(t1.endDate, '3000-01-01')
 group by t1.objId
 having sum(isnull(rate,0)) <100
 union 
 select t1.objid, sum(isnull(rate,0)) as rate, max(t2.agrStatus) as status
 from 
  CopyRight t1 
   join AgreementMaster t2 on t1.custId = t2.custId and (isnull(t2.agrStatus ,0) <> 2 or isnull(t1.status,0) <> 1)
 where @date between isnull(t1.beginDate,'1900-01-01') and isnull(t1.endDate, '3000-01-01') 
 group by t1.objId
 having sum(isnull(rate,0)) >= 100 
 ),
TabRest as 
(
select t1.objid,  sum((Case T2.balsCode When 30 Then t3.rest else 0 end )) as Rest30, 
sum((Case T2.balsCode When 31 Then t3.rest else 0 end )) as Rest31
from TMPRate t1 
join Account t2 on t1.objid = t2.objid
join SaldoDay t3 on t3.accId = t2.accId and getdate() between t3.dateBegin and t3.dateEnd
group by t1.objid
)
insert into @tmpTab2 (objid, rate, rest30, rest31, agrStatus, agrStatusName)
select t1.objid, t1.rate, t2.Rest30, t2.Rest31, t1.status as agrStatus, t4.name as AgrstatusName
from TMPRate t1 
join ObjectRight t3 on t1.objid = t3.objId
left join TabRest t2 on t1.objid = t2.objid 
left join AgreementStatus t4 on t1.status = t4.codeI

--Результат
insert into @RT 
( objid, objName, performer, authorMus, authorText, rHolder, fullRate, amountCollect, amountNoshare, comment)
SELECT t2.objid, max(t3.name), max(t3.performer), 
    AuthorMus  = STUFF( (SELECT ',' + custName+'='+convert(varchar(10),rate) FROM @TmpTab1 t1 where t1.objid = t2.objId and roleCode = 1  FOR XML PATH ('')), 1, 1, '' ), 
	AuthorText =  STUFF( (SELECT ',' + custName+'='+convert(varchar(10),rate) FROM @TmpTab1 t1 where t1.objid = t2.objId and roleCode = 2  FOR XML PATH ('')), 1, 1, '' ), 
	Author     =  STUFF( (SELECT ',' + custName+'='+convert(varchar(10),rate) FROM @TmpTab1 t1 where t1.objid = t2.objId and roleCode not in (1,2)  FOR XML PATH ('')), 1, 1, '' ) , 
	0, 0, 0, ''
FROM @TmpTab1 t2 
join ObjectRight t3 on t2.objid = t3.objId
join @tmpTab2 t4 on t3.objid = t4.objid
GROUP BY t2.objid

update @RT set 
 fullRate = t2.rate, 
 amountCollect = t2.rest30, 
 amountNoshare = t2.rest31, 
 comment = ''
 from @RT t1, 
  @TmpTab2 t2 
 where t1.objid = t2.objid 

 declare @TmpComm table 
 (objid integer not null, 
  comment varchar(512) null, 
  primary key (objid) 
 )

----Не підтверджений договір з правовласником 
;with TmpStatus as
(select t2.objid, t4.name as custName  
 from @RT t1 
  join copyright t2 on t1.objid = t2.objid and @date between isnull(t2.beginDate,'1900-01-01') and isnull(t2.endDate, '3000-01-01')
  join AgreementMaster t3 on t2.custId = t3.custId and t3.agrStatus <> 2
  join vCustomer t4 on t3.custId = t4.custId
  ), 
TmpComm as 
(select t2.objid,  
 comment = STUFF ((select ','+ t1.custName from TmpStatus t1 where t1.objid = t2.objId FOR XML PATH ('')), 1, 1, '' )
  from TmpStatus t2 group by t2.objid 
)
insert into @tmpComm (objid, comment) 
select objid, comment 
from TmpComm

update @RT set comment = 'Відсутня угода з правовласником -' + t2.comment
  from @RT t1 
  join @TmpComm t2 on t1.objid = t2.objid 

----Не підтверджений процент володіння 
delete @tmpComm

;with TmpStatus as
(select t2.objid, t4.name as custName  
 from @RT t1 
  join copyright t2 on t1.objid = t2.objid and @date between isnull(t2.beginDate, '1900-01-01') and isnull(t2.endDate, '3000-01-01') and isnull(t2.status,0) <> 1
  join vCustomer t4 on t2.custId = t4.custId
  ), 
TmpComm as 
(select t2.objid,  
 comment = STUFF ((select ','+ t1.custName from TmpStatus t1 where t1.objid = t2.objId FOR XML PATH ('')), 1, 1, '' )
  from TmpStatus t2 group by t2.objid 
)
insert into @tmpComm (objid, comment) 
select objid, comment 
from TmpComm

update @RT set comment = isnull(t1.comment,'')  + 'Не підтверджено володіння - ' + isnull(t2.comment,'')
  from @RT t1 
  join @TmpComm t2 on t1.objid = t2.objid 

  
RETURN ;
END;

--select * from ft_Tsk_5_18_1_ObjUnattached (NULL)

/*
select t1.custid, rate, t2.name, t3.agrStatus, t1.status
from CopyRight t1
join vCustomer t2 on t1.custid = t2.custId
join AgreementMaster t3 on t1.custId = t3.custId
where objid = 5843
*/