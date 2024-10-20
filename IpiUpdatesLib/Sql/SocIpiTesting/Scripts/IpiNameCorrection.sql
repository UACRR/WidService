; with TmpMissing as (
	select t1.IpNameNr 
	from IpiName t1
		left join SocIpi_2024_08_31..IpiName t2 on t1.IpNameNr = t2.IpNameNr
	where t2.IpNameNr is null
)
insert SocIpi_2024_08_31..IpiName (
	  IpBaseNr
	, IpNameNr
	, IpNameNrRef
	, IpBaseNrRef
	, Name
	, FstName
	, NameType
	, CreDt
	, AmdDt
	, IsDeleted
)
select 
	  t2.IpBaseNr
	, t2.IpNameNr
	, t2.IpNameNrRef
	, t2.IpBaseNrRef
	, t2.Name
	, t2.FstName
	, t2.NameType
	, t2.CreDt
	, t2.AmdDt
	, t2.IsDeleted
from TmpMissing t1
	join IpiName t2 on t1.IpNameNr = t2.IpNameNr

