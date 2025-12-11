USE [CWR]
GO

/****** Object:  View [dbo].[vWrongRoleAuthorsStat]    Script Date: 05.11.2025 14:57:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create or alter view [dbo].[vWrongRoleAuthorsStat]
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
		, t1.CntWrongWorks									as CntWrong
	from vWrongRoleRightHolders t1
		join MediaService..CopyRight t2 on t1. CustId = t2.CustId
		join MediaService..RightHolder t3 on t2.CustId = t3.CustId
	group by t3.CustId, t3.rHolderType, t1.CntWrongWorks
)
select t2.CustId, t2.Name, t1.rHolderType, t1.CntA, t1.CntC, t1.CntAR, t1.CntE, t1.CntCA, t1.CntWRong
from Stat t1
	join MediaService..vCustomerNames t2 on t1.CustId = t2.CustId
GO

/*
select * from vWrongRoleRightHolders order by Name --
where CustId = 91827
select * from vWrongRoleAuthorsStat where CustId = 91827
select * from vWorkRightHoldersCurrent where CustId = 91827

select * 
from MediaService..CopyRight 
where CustId = 91827 
	and dbo.fnCheckRoleDefined(1, roleCode) = 0

select distinct t2.*, t1.* 
from TmpWrongWorks t1
	join vWorkInfo t2 on t1.ObjId = t2.ObjId
	join vWorkRightHoldersCurrent t3 on t2.ObjId = t3.ObjId
where UndefRole = 1 and CustId = 91827
	and dbo.fnCheckRoleDefined(t3.RightHolderType, t3.RoleCode) = 0
order by t2.Name
*/