use MediaService
go

create or alter view vWidSrObjectAuthorsCommunities
as
select
	  t1.IpBaseNr							as IP_BASE_NR
	, t1.SocCde								as SOC_CDE
	--, t3.name								as OKU_NAME
	, isnull(t4.Name, '')					as OKU_NAME
	, t1.RolCde								as ROL_CDE
	, t1.RgtCde								as RGT_CDE
	, t1.FromDt								as AGR_VALID_FROM_DT
	, t1.Shr								as MBR_SHARE
	, t2.Tisan 
from 
	SocIpi..IpiAgreement t1
	join	  SocIpi..IpiTerritory	t2		on  t1.IpAgreeNr = t2.IpAgreeNr
	left join vCustomerRholder		t3		on  t1.SocCde	= t3.interCode 
		and t3.rHolderType = 2
	left join SocIpi..DicSoc		t4		on t1.SocCde = t4.Cde
go

--select * from vWidSrObjectAuthorsCommunities where IP_BASE_NR in ('I-001766530-2', 'I-000639378-6')


