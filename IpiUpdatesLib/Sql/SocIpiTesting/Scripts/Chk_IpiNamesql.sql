select *
from SocIpi_2024_06_01..IpiName
where IsDeleted = 1

-- 2 excesive names, however there where no updates where name had to be deleted
drop table if exists #Missing
select t1.*
into #Missing
from SocIpi_2024_06_01..IpiName t1
	left join SocIpi_2024_08_31..IpiName t2 on t1.IpNameNr = t2.IpNameNr and t1.IpBaseNr = t2.IpBaseNr
where t1.IsDeleted = 0 
	and t2.IpNameNr is null
order by t1.NameType

select *
from #Missing t1
	left join UpdTrans t2 on t1.IpBaseNr = t2.IpBaseNr
where t2.RecType = 'NCD'
order by t1.IpBaseNr
drop table if exists #Missing
---------------------------------------------------------------------

-- Missing names after update
drop table if exists #Missing
select t2.*
into #Missing
from SocIpi_2024_06_01..IpiName t1
	right join SocIpi_2024_08_31..IpiName t2 on t1.IpNameNr = t2.IpNameNr and t1.IpBaseNr = t2.IpBaseNr
where t1.IpNameNr is null

-- Right holders for missing names - 177 total
drop table if exists #MissingIpBaseNr
select distinct IpBaseNr
into #MissingIpBaseNr
from #Missing

-- Update transactions for mentioned right holders (406)
select *
from #MissingIpBaseNr t1
	left join UpdTrans t2 on t1.IpBaseNr = t2.IpBaseNr
order by t1.IpBaseNr

-- No update transactions (3)
select *
from #MissingIpBaseNr t1
	left join UpdTrans t2 on t1.IpBaseNr = t2.IpBaseNr
where t2.IpBaseNr is null
order by t1.IpBaseNr

-- Right holders of Update transactions requesting adding name (4)
select distinct t1.IpBaseNr
from #MissingIpBaseNr t1
	left join UpdTrans t2 on t1.IpBaseNr = t2.IpBaseNr
where t2.RecType in ('NCA', 'NPA')
order by t1.IpBaseNr

select *
from #Missing t1
	left join UpdTrans t2 on t1.IpBaseNr = t2.IpBaseNr
	left join RecNcn t3 on t2.UpdFileId = t3.UpdFileId and t2.GrId = t3.GrId and t2.TransSeqNr = t3.TransSeqNr
where t2.RecType in ('NCA', 'NPA')
order by t1.IpBaseNr
drop table if exists #Missing

-- CONCLUSION: no way to add missing names from updates
-- =========================================================================

--=================== Field by field
-- IpNameNrRef - OK
select t2.IpNameNr, t1.IpNameNrRef as Old, t2.IpNameNrRef as New
from SocIpi_2024_06_01..IpiName t1
	join SocIpi_2024_08_31..IpiName t2 on t1.IpNameNr = t2.IpNameNr and t1.IpBaseNr = t2.IpBaseNr
where t1.IpNameNrRef <> t2.IpNameNrRef
	and t1.IsDeleted = 0

-- IpBaseNrRef - OK
select t2.IpNameNr, t1.IpBaseNrRef as Old, t2.IpBaseNrRef as New
from SocIpi_2024_06_01..IpiName t1
	join SocIpi_2024_08_31..IpiName t2 on t1.IpNameNr = t2.IpNameNr and t1.IpBaseNr = t2.IpBaseNr
where t1.IpBaseNrRef <> t2.IpBaseNrRef
	and t1.IsDeleted = 0

-- Name - OK
select t2.IpNameNr, t1.Name as Old, t2.Name as New
from SocIpi_2024_06_01..IpiName t1
	join SocIpi_2024_08_31..IpiName t2 on t1.IpNameNr = t2.IpNameNr and t1.IpBaseNr = t2.IpBaseNr
where t1.Name <> t2.Name

-- FstName - OK
select t2.IpNameNr, t1.FstName as Old, t2.FstName as New
from SocIpi_2024_06_01..IpiName t1
	join SocIpi_2024_08_31..IpiName t2 on t1.IpNameNr = t2.IpNameNr and t1.IpBaseNr = t2.IpBaseNr
where t1.FstName <> t2.FstName
	and t1.IsDeleted = 0

-- NameType - 3 wrong
select t2.IpBaseNr, t2.IpNameNr, t1.NameType as Old, t2.NameType as New
from SocIpi_2024_06_01..IpiName t1
	join SocIpi_2024_08_31..IpiName t2 on t1.IpNameNr = t2.IpNameNr and t1.IpBaseNr = t2.IpBaseNr
where t1.NameType <> t2.NameType
	and t1.IsDeleted = 0
order by t2.IpBaseNr

select * from SocIpi_2024_08_31..IpiName where IpBaseNr = 'I-007026909-7' order by IpNameNr
select * from SocIpi_2024_06_01..IpiName where IpBaseNr = 'I-007026909-7' order by IpNameNr
--select * from UpdTrans where IpBaseNr = 'I-007026909-7'
select * from RecNcn where UpdFileId = 81 and Grid = '00162' and TransSeqNr = '00000000' order by IpNameNr
select * from RecNco where UpdFileId = 81 and Grid = '00162' and TransSeqNr = '00000000' order by IpNameNr

-- 1256177444
select * 
from RecNcn t1
	join UpdTrans t2 on t2.UpdFileId = t1.UpdFileId and t2.GrId = t1.GrId and t2.TransSeqNr = t1.TransSeqNr
where t1.IpNameNr = 1256177444
--select * from RecNco where IpNameNr = 1256177444

/*
select * from RecMcn where IpNameNr = 1256177444
select * from RecMco where IpNameNr = 1256177444

select * from RecNun where IpNameNr = 1256177444
select * from RecNuo where IpNameNr = 1256177444
*/

select * 
from RecOnn t1
	join UpdTrans t2 on t2.UpdFileId = t1.UpdFileId and t2.GrId = t1.GrId and t2.TransSeqNr = t1.TransSeqNr
where t1.IpNameNr = 1256177444

select * 
from RecOno t1
	join UpdTrans t2 on t2.UpdFileId = t1.UpdFileId and t2.GrId = t1.GrId and t2.TransSeqNr = t1.TransSeqNr
where t1.IpNameNr = 1256177444

-- CreDt - OK
select t2.IpBaseNr, t2.IpNameNr, t1.CreDt as Old, t2.CreDt as New
from SocIpi_2024_06_01..IpiName t1
	join SocIpi_2024_08_31..IpiName t2 on t1.IpNameNr = t2.IpNameNr and t1.IpBaseNr = t2.IpBaseNr
where t1.CreDt <> t2.CreDt
	and t1.IsDeleted = 0
order by t2.IpBaseNr

-- AmdDt - 267 wrong
select t2.IpBaseNr, t2.IpNameNr, t1.AmdDt as Old, t2.AmdDt as New
from SocIpi_2024_06_01..IpiName t1
	join SocIpi_2024_08_31..IpiName t2 on t1.IpNameNr = t2.IpNameNr and t1.IpBaseNr = t2.IpBaseNr
where t1.AmdDt <> t2.AmdDt
	and t1.IsDeleted = 0
order by t2.IpBaseNr