--drop table if exists #Missing
select t2.*
--into #Missing
from SocIpi_2024_06_01..IpiBase t1
	full join SocIpi_2024_08_31..IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
where t1.IpBaseNr is null or t2.IpBaseNr is null
--drop table if exists #Missing

select t2.IpBaseNr, t1.IpType as Old, t2.IpType as New
from SocIpi_2024_06_01..IpiBase t1
	join SocIpi_2024_08_31..IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
where t1.IpType <> t2.IpType

select t2.IpBaseNr, t1.BirthD as Old, t2.BirthD as New
from SocIpi_2024_06_01..IpiBase t1
	join SocIpi_2024_08_31..IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
where t1.BirthD <> t2.BirthD

------------- WRONG - just a few cases related to incomplete dates, info is not used by UACRR, will not fix
select t2.IpBaseNr, t1.DeathD as Old, t2.DeathD as New, t3.*
from SocIpi_2024_06_01..IpiBase t1
	join SocIpi_2024_08_31..IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
--	left join UpdTrans t3 on t2.IpBaseNr = t3.IpBaseNr
where t1.DeathD <> t2.DeathD
order by t1.IpBaseNr

/*
I-000001108-3
2000-12-01 -- Old
2000-01-01 -- New

90	00587	NTA
90	00586	BDU
90	00577	BDU
90	00588	NUA
90	00590	MAA
90	00589	MAD

select * from RecBdo where UpdFileId = 90 and GrId = 00586 and TransSeqNr = 0
select * from RecBdn where UpdFileId = 90 and GrId = 00586 and TransSeqNr = 0
*/
--------------------------------------------------------------

select t2.IpBaseNr, t1.BirthPlace as Old, t2.BirthPlace as New
from SocIpi_2024_06_01..IpiBase t1
	join SocIpi_2024_08_31..IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
where t1.BirthPlace <> t2.BirthPlace

select t2.IpBaseNr, t1.BirthState as Old, t2.BirthState as New
from SocIpi_2024_06_01..IpiBase t1
	join SocIpi_2024_08_31..IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
where t1.BirthState <> t2.BirthState

select t2.IpBaseNr, t1.BirthTisNr as Old, t2.BirthTisNr as New
from SocIpi_2024_06_01..IpiBase t1
	join SocIpi_2024_08_31..IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
where t1.BirthTisNr <> t2.BirthTisNr

select t2.IpBaseNr, t1.TisNrFromD as Old, t2.TisNrFromD as New
from SocIpi_2024_06_01..IpiBase t1
	join SocIpi_2024_08_31..IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
where t1.TisNrFromD <> t2.TisNrFromD

select t2.IpBaseNr, t1.BirthTisan as Old, t2.BirthTisan as New
from SocIpi_2024_06_01..IpiBase t1
	join SocIpi_2024_08_31..IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
where t1.BirthTisan <> t2.BirthTisan

select t2.IpBaseNr, t1.TisanFromD as Old, t2.TisanFromD as New
from SocIpi_2024_06_01..IpiBase t1
	join SocIpi_2024_08_31..IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
where t1.TisanFromD <> t2.TisanFromD

select t2.IpBaseNr, t1.Sex as Old, t2.Sex as New
from SocIpi_2024_06_01..IpiBase t1
	join SocIpi_2024_08_31..IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
where t1.Sex <> t2.Sex

select t2.IpBaseNr, t1.AmdDt as Old, t2.AmdDt as New
from SocIpi_2024_06_01..IpiBase t1
	join SocIpi_2024_08_31..IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
where t1.AmdDt <> t2.AmdDt
