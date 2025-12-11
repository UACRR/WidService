use CWR
go

create or alter view vWrongRoleRightHolders
as
with Customers as (
	select t2.CustId, count(*) as CntWrongWorks
	from TmpObjIdsInitial t1
		join vWorkRightHoldersCurrent t2 on t1.ObjId = t2.ObjId
		left join Z_CopyRightHistoryOutline t3 on t2.CopyRightId = t3.CopyRightId
	where dbo.fnCheckRoleDefined(t2.RightHolderType, t2.RoleCode) = 0
		and (t3.CopyRightId is null or t3.CopyRightRoleNew = 0)
	group by t2.CustId
)
select t2.*, t1.CntWrongWorks
from Customers t1
	 join MediaService..vCustomerNames t2 on t1.CustId = t2.CustId
go

--select * from vWrongRoleRightHolders order by Name
/*
select 
	  t2.CustId
	, sum(case when t2.roleCode = 1 then 1 else 0 end) as CntA
	, sum(case when t2.roleCode = 2 then 1 else 0 end) as CntC
	, sum(case when t2.roleCode = 7 then 1 else 0 end) as CntAR
	, sum(case when t2.roleCode = 8 then 1 else 0 end) as CntE
	, sum(case when t2.roleCode = 10 then 1 else 0 end) as CntCA
	, sum(case when t2.roleCode not in (1, 2, 7, 10) then 1 else 0 end) as Wrong
from vWrongRoleRightHolders t1
	join MediaService..CopyRight t2 on t1. CustId = t2.CustId
--where t3.rHolderType = 1
--where dbo.fnCheckRoleDefined(t3.rHolderType, t2.roleCode) = 1
	--and t2.CustId = 39689
group by t2.CustId
--order by t1.Cnt desc, t1.CustId, t2.ObjId
*/


