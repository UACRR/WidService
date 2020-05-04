CREATE function [dbo].[ft_Tsk9_5_Object]  (@objid integer)
--тнплю днундш б пюгпеге бхднб опюб:
RETURNS @RT TABLE
(
 id integer not null identity primary key, 
 objid integer  null, 
 roleName varchar(200), 
 folkType varchar(100), 
 custIdName varchar(200), 
 isRholder bit, 
 status bit, 
 rate decimal (5,2), 
 dateBegin date, 
 dateEnd date,
 custId integer )
AS
BEGIN  

--declare @objid integer = 2
;with TabRate as 
(
select objid, t1.custId, t5.name as custIdName, roleCode, rate, roleRate, 
 isnull(beginDate,'1900-01-01') as beginDate, isnull(endDate, '3000-01-01') as endDate,
 t1.status, 1 as folkType
 from copyRight t1 
 join vCustomer t5 on t1.custId = t5.custId
 where  t1.objid = @objid and getdate() between isnull(beginDate,'1900-01-01') and isnull(endDate, '3000-01-01')
  union 
 select  t1.objid, t1.custId, t1.authorName, t1.roleCode, 0 as rate, 0 as roleRate, 
  '1900-01-01' as beginDate, '3000-01-01' as endDate,
 NULL as status, t1.folkType
  from Authors t1 
  where t1.objid = @objid and t1.custId is NULL 
  )
insert into @RT ( objid, custId, custIdName, roleName, folkType, isRholder, status, rate, dateBegin, dateEnd)
select t1.objId, t1.custId, t1.custIdName as rhName, 
       t2.name as roleName, 
	   t4.name as folkType, 
	   (Case t1.folkType when 1 Then 1 else 0 end ) as isRholder, 
	   t1.status, 
	   t1.rate, t1.beginDate, t1.endDate
 from TabRate t1 
 join creativeRoleType t2 on t1.roleCode = t2.codeI
 left join FolkType t4 on t4.codeI = t1.folkType 

 RETURN
END


/*
select * from ft_Tsk9_5_Object (5849)
*/

GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk9_5_Object] TO [ReportUser]
    AS [dbo];

