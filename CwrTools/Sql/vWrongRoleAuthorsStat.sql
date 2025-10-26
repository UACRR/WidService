use CWR
go

create or alter view vWrongRoleAuthorsStat
as
with Stat as (
	select 
		  t3.CustId
		, t3.rHolderType
		, sum(case when t2.roleCode = 1 then 1 else 0 end) as CntA
		, sum(case when t2.roleCode = 2 then 1 else 0 end) as CntC
		, sum(case when t2.roleCode = 7 then 1 else 0 end) as CntAR
		, sum(case when t2.roleCode = 8 then 1 else 0 end) as CntE
		, sum(case when t2.roleCode = 10 then 1 else 0 end) as CntCA
		, sum(case when dbo.fnCheckRoleDefined(t3.rHolderType, t2.roleCode) = 0 then 1 else 0 end) as CntWrong
	from vWrongRoleRightHolders t1
		join MediaService..CopyRight t2 on t1. CustId = t2.CustId
		join MediaService..RightHolder t3 on t2.CustId = t3.CustId
	--where t3.rHolderType = 1
	--where dbo.fnCheckRoleDefined(t3.rHolderType, t2.roleCode) = 1
		--and t2.CustId = 39689
	group by t3.CustId, t3.rHolderType
)
select t2.CustId, t2.Name, t1.rHolderType, t1.CntA, t1.CntC, t1.CntAR, t1.CntE, t1.CntCA, t1.CntWRong
from Stat t1
	join MediaService..vCustomerNames t2 on t1.CustId = t2.CustId
go

/*
select * from TmpRightHolderRoleCorrections

select *
from vWrongRoleAuthorsStat t1
where t1.rHolderType = 1
order by t1.Name
*/