use SocWidSubmit
go

create or alter view vWidSubmRhRights
as
select distinct
	  WidSubmGroupId										as WidSubmGroupId
	, IpBaseNr												as IpBaseNr
	, IpNameNr												as IpNameNr
	, RhType												as RhType
	, RhRole												as RhRole
	, dbo.fnGetIpiRole(RhType, RhRole)						as IpiRole
	, AggrLocal												as AggrLocal
	, AggrIpiPer											as CurIpiPerAgree
	, AggrIpiMec											as CurIpiMecAgree
	, dbo.fnHasIpiAgreement(IpBaseNr, RhType, RhRole, 'PR') as NewIpiPerAgree
	, dbo.fnHasIpiAgreement(IpBaseNr, RhType, RhRole, 'MR') as NewIpiMecAgree
from WidSubmGroupWorkShare
go
