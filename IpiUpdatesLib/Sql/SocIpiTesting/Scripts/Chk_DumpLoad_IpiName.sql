-- **********************************  IpiBaseNr
-- Records match both ways - OK
select *
from IpiName t1
	full join SocIpi_2024_08_31..IpiName t2 on t1.IpBaseNr = t2.IpBaseNr and t1.IpNameNr = t2.IpNameNr
where t1.IpNameNr is null or t2.IpNameNr is null

select *
from IpiName t1
	join SocIpi_2024_08_31..IpiName t2 on t1.IpBaseNr = t2.IpBaseNr and t1.IpNameNr = t2.IpNameNr
where t1.IpNameNrRef <> t2.IpNameNrRef

select t1.IpNameNr, t1.IpBaseNrRef New, t2.IpBaseNrRef Old
from IpiName t1
	join SocIpi_2024_08_31..IpiName t2 on t1.IpBaseNr = t2.IpBaseNr and t1.IpNameNr = t2.IpNameNr
where t1.IpBaseNrRef <> t2.IpBaseNrRef

select t1.IpNameNr, t1.Name New, t2.Name Old
from IpiName t1
	join SocIpi_2024_08_31..IpiName t2 on t1.IpBaseNr = t2.IpBaseNr and t1.IpNameNr = t2.IpNameNr
where t1.Name <> t2.Name

select t1.IpNameNr, t1.FstName New, t2.FstName Old
from IpiName t1
	join SocIpi_2024_08_31..IpiName t2 on t1.IpBaseNr = t2.IpBaseNr and t1.IpNameNr = t2.IpNameNr
where t1.FstName <> t2.FstName


select t1.IpNameNr, t1.NameType New, t2.NameType Old
from IpiName t1
	join SocIpi_2024_08_31..IpiName t2 on t1.IpBaseNr = t2.IpBaseNr and t1.IpNameNr = t2.IpNameNr
where t1.NameType <> t2.NameType

select t1.IpNameNr, t1.CreDt New, t2.CreDt Old
from IpiName t1
	join SocIpi_2024_08_31..IpiName t2 on t1.IpBaseNr = t2.IpBaseNr and t1.IpNameNr = t2.IpNameNr
where t1.CreDt <> t2.CreDt

select t1.IpNameNr, t1.AmdDt New, t2.AmdDt Old
from IpiName t1
	join SocIpi_2024_08_31..IpiName t2 on t1.IpBaseNr = t2.IpBaseNr and t1.IpNameNr = t2.IpNameNr
where t1.AmdDt <> t2.AmdDt


