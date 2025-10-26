use CWR
go

-- NOT USED
create or alter procedure spCreateTmpCopyRightRoles
as
begin
	drop table if exists TmpCopyRightRoles
	select 
		  t1.cRightId
		, t1.RoleCode as RoleCode
		, t2.rHolderType
		, dbo.fnCheckRoleDefined(t2.rHolderType, t1.RoleCode) as IsDefined
		, 0 as RoleCodeNew
		, 0 as IsInherited
	into TmpCopyRightRoles
	from MediaService..CopyRight t1
		join MediaService..RightHolder t2 on t1.CustId = t2.CustId

	update t1
	set t1.IsInherited = 1
	from TmpCopyRightRoles t1
		join MediaService..CopyRightHistory t2 on t1.cRightId = t2.ChildId

	select * from TmpCopyRightRoles where IsInherited = 1
end
go

