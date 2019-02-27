create view  vTsk9_5_Object as
with TabRate as 
(
select objid, t1.custId, t5.name as custIdName, roleCode, rate, roleRate, 
 isnull(beginDate,'1900-01-01') as beginDate, isnull(endDate, '3000-01-01') as endDate,
 t1.status, 1 as folkType
 from copyRight t1 
 join vCustomer t5 on t1.custId = t5.custId
 where  getdate() between isnull(beginDate,'1900-01-01') and isnull(endDate, '3000-01-01')
  union 
 select  t1.objid, t1.custId, t1.authorName, t1.roleCode, 0 as rate, 0 as roleRate, 
  '1900-01-01' as beginDate, '3000-01-01' as endDate,
 NULL as status, t1.folkType
  from Authors t1 
  where t1.custId is NULL 
  )
select t1.objId, t1.custId, t1.custIdName as rhName, 
       t2.name as roleName, t4.name as folkType, 
	   (Case t1.folkType when 1 Then 1 else 0 end ) as isRholder, 
	   t1.status, 
	   t1.rate, t1.beginDate, t1.endDate
 from TabRate t1 
 join creativeRoleType t2 on t1.roleCode = t2.codeI
 right join FolkType t4 on t4.codeI = t1.folkType 

--select * from vTsk9_CopyRight where objid = 5859