use SocWidSubmitEx
go

create or alter procedure spZ_CreateRhUndefRoleInfo
as
begin

drop table if exists Z_RhUndefRoleInfo
; with CustWorks as ( -- Активні автори товариства і їх проблемні твори
	select distinct t4.CustId, t1.ObjId
	from Z_CheckList t1
		join MediaService..CopyRight t2 on t1.ObjId = t2.ObjId
			and getdate() between t2.BeginDate and t2.EndDate
		join MediaService..RightHolder t3 on t2.CustId = t3.CustId
			and t3.AroundWord = 1
		join MediaService..AgreementAddRH t4 on t2.CustId = t4.CustId
			and t4.AgrStatus = 2 
	where t1.RolesDefined = 0
)
select
	  t1.CustId			as AuthorCode
	, t4.FullName		as AuthorName
	, t1.ObjId			as WorkCode
	, t5.Name			as WorkName
	, t2.CustId			as CoAuthorCode
	, t6.FullName		as CoAuthorName
	, t3.RHolderType	as RhType
	, t7.Name			as RhTypeName
	, t2.RoleCode		as RhRole
	, t8.Name			as RhRoleName
into Z_RhUndefRoleInfo
from CustWorks t1
	join MediaService..CopyRight t2 on t1.ObjId = t2.ObjId
		and getdate() between t2.BeginDate and t2.EndDate
	join MediaService..RightHolder t3 on t2.CustId = t3.CustId
			and dbo.fnGetWidRole(t3.RHolderType, t2.RoleCode) = ''
	join MediaService..vCustomerNameDetailed t4 on t1.CustId = t4.CustId
	join MediaService..MediaTrack t5 on t2.ObjId = t5.ObjId
	join MediaService..vCustomerNameDetailed t6 on t2.CustId = t6.CustId
	join MediaService..RHolderType t7 on t3.rHolderType = t7.CodeI
	join MediaService..CreativeRoleType t8 on t2.roleCode = t8.CodeI
end
go
-- exec spZ_CreateRhUndefRoleInfo

--select distinct WorkCode, WorkName, CoAuthorCode, CoAuthorName, RhTypeName, RhRoleName
--from Z_RhUndefRoleInfo
----where RhType = 1 and RhRole in (8, 9)
--order by RhTypeName, RhRoleName, CoAuthorName

--select distinct RhType, RhTypeName, RhRole, RhRoleName
--from Z_RhUndefRoleInfo
----where RhType = 1 and RhRole in (8, 9)
--order by RhType, RhRole