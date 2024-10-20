-- **********************************  IpiBaseNr
-- Records match both ways - OK
select *
from IpiBase t1
	full join SocIpi_2024_08_31..IpiBase t2 on t1.IpbaseNr = t2.IpBaseNr
where t1.IpBaseNr is null or t2.IpBaseNr is null
 -- IpType - Ok
select *
from IpiBase t1
	join SocIpi_2024_08_31..IpiBase t2 on t1.IpbaseNr = t2.IpBaseNr
where t1.IpType <> t2.IpType
 -- BirthD - OK, difference is for last transactions added from new way created data from dump
select t1.IpBaseNr, t1.BirthD as FromNewLoad, t2.BirthD as FromStandardLoad
from IpiBase t1
	join SocIpi_2024_08_31..IpiBase t2 on t1.IpbaseNr = t2.IpBaseNr
where t1.BirthD <> t2.BirthD
 -- DeathD - OK
select t1.IpBaseNr, t1.DeathD as FromNewLoad, t2.DeathD as FromStandardLoad
from IpiBase t1
	join SocIpi_2024_08_31..IpiBase t2 on t1.IpbaseNr = t2.IpBaseNr
where t1.DeathD <> t2.DeathD
-- BirthPlace - OK
select t1.IpBaseNr, t1.BirthPlace as FromNewLoad, t2.BirthPlace as FromStandardLoad
from IpiBase t1
	join SocIpi_2024_08_31..IpiBase t2 on t1.IpbaseNr = t2.IpBaseNr
where t1.BirthPlace <> t2.BirthPlace
-- BirthState - OK, just last records correction was wrong
select t1.IpBaseNr, t1.BirthState as FromNewLoad, t2.BirthState as FromStandardLoad
from IpiBase t1
	join SocIpi_2024_08_31..IpiBase t2 on t1.IpbaseNr = t2.IpBaseNr
where t1.BirthState <> t2.BirthState
-- BirthTisNr - OK
select t1.IpBaseNr, t1.BirthTisNr as FromNewLoad, t2.BirthTisNr as FromStandardLoad
from IpiBase t1
	join SocIpi_2024_08_31..IpiBase t2 on t1.IpbaseNr = t2.IpBaseNr
where t1.BirthTisNr <> t2.BirthTisNr
-- TisNrFromD - OK
select t1.IpBaseNr, t1.TisNrFromD as FromNewLoad, t2.TisNrFromD as FromStandardLoad
from IpiBase t1
	join SocIpi_2024_08_31..IpiBase t2 on t1.IpbaseNr = t2.IpBaseNr
where t1.TisNrFromD <> t2.TisNrFromD
-- BirthTisan - OK
select t1.IpBaseNr, t1.BirthTisan as FromNewLoad, t2.BirthTisan as FromStandardLoad
from IpiBase t1
	join SocIpi_2024_08_31..IpiBase t2 on t1.IpbaseNr = t2.IpBaseNr
where t1.BirthTisan <> t2.BirthTisan
-- TisanFromD - OK
select t1.IpBaseNr, t1.TisanFromD as FromNewLoad, t2.TisanFromD as FromStandardLoad
from IpiBase t1
	join SocIpi_2024_08_31..IpiBase t2 on t1.IpbaseNr = t2.IpBaseNr
where t1.TisanFromD <> t2.TisanFromD
-- TisanFromD - OK
select t1.IpBaseNr, t1.Sex as FromNewLoad, t2.Sex as FromStandardLoad
from IpiBase t1
	join SocIpi_2024_08_31..IpiBase t2 on t1.IpbaseNr = t2.IpBaseNr
where t1.Sex <> t2.Sex
-- AmdDt - OK
select t1.IpBaseNr, t1.AmdDt as FromNewLoad, t2.AmdDt as FromStandardLoad
from IpiBase t1
	join SocIpi_2024_08_31..IpiBase t2 on t1.IpbaseNr = t2.IpBaseNr
where t1.AmdDt <> t2.AmdDt