use SocWidSubmitEx
go

create or alter view vMsRightHoldersActive
as
select 
	  t1.custId			as CustId
	, t1.InterCode		as IpBaseNr
	, t1.IPIBase		as IpNameNr
	, t3.Name			as Name
	, t3.FstName		as FstName
	, t3.NameForWid		as NameForWid
	, t3.FstNameForWid	as FstNameForWid
	, cast(1 as bit)	as IsOwn
	, cast(1 as bit)	as IsActive
from MediaService..RightHolder t1
	join MediaService..AgreementAddRH t2 on t1.custId = t2.custId
	join vCustomerNamesForWid t3 on t2.CustId = t3.CustId
where t2.agrStatus = 2
	and (t2.dateBegin is null or t2.dateBegin <= getdate())
	and (t2.dateEnd is null or t2.dateEnd >= getdate())
go

