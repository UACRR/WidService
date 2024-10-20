; with TmpMissing as (
	select t1.* 
	from IpiBase t1
		left join SocIpi_2024_08_31..IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
	where t2.IpBaseNr is null
)
insert SocIpi_2024_08_31..IpiBase (
	  IpBaseNr
	, IpType
	, BirthD
	, DeathD
	, BirthPlace
	, BirthState
	, BirthTisNr
	, TisNrFromD
	, BirthTisan
	, TisanFromD
	, Sex
	, AmdDt
)
select 
	  t2.IpBaseNr
	, t2.IpType
	, t2.BirthD
	, t2.DeathD
	, t2.BirthPlace
	, t2.BirthState
	, t2.BirthTisNr
	, t2.TisNrFromD
	, t2.BirthTisan
	, t2.TisanFromD
	, t2.Sex
	, t2.AmdDt
from TmpMissing t1
	join IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr

