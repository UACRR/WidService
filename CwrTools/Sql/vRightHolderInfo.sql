use CWR
go

create or alter view vRightHolderInfo
as
select
	  t1.cRightId		as [CopyRightId]
	, t1.ObjId			as [ObjId]
	, t1.CustId			as [CustId]
	, t4.ShortName		as [Name]
	, t2.rHolderType	as [Type]
	, t5.Name			as [TypeName]
	, t1.roleCode		as [Role]
	, t6.Name			as [RoleName]
	, t1.Rate			as [PerShr]
	, t1.RateMech		as [MecShr]
from MediaService..CopyRight t1
	join MediaService..RightHolder t2 on t1.CustId = t2.CustId
	left join MediaService..AgreementAddRH t3 on t2.CustId = t3.CustId
	join MediaService..vCustomerNamesShort t4 on t1.CustId = t4.CustId
	join MediaService..RHolderType t5 on t2.rHolderType = t5.CodeI
	join MediaService..CreativeRoleType t6 on t6.CodeI = t1.roleCode
where dbo.fnIsDateInInterval(getdate(), t1.BeginDate, t1.EndDate) = 1
	--and t3.agrStatus = 2
	--and dbo.fnIsDateInInterval(getdate(), t3.DateBegin, t3.DateEnd) = 1
go

-- select * from vRightHolderInfo where ObjId = 978114
