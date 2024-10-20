-- Each IPA hase not more that 1 BDN - YES
select t1.IpBaseNr, count(*)
from RecIpa t1
	join RecBdn t2 on t1.FileId = t2.FileId and t1.TransSeqNr = t2.TransSeqNr
group by t1.IpBaseNr
having count(*) > 1

-- Each IPA always has BDN - YES
select *
from RecIpa t1
	join RecBdn t2 on t1.FileId = t2.FileId and t1.TransSeqNr = t2.TransSeqNr
where t1.Id is null

-- Each IPA hase not more that 1 STN - NO, any number happens< max 10 observed for IpBaseNr = I-000677793-9
select t1.IpBaseNr, count(*)
from RecIpa t1
	join RecStn t2 on t1.FileId = t2.FileId and t1.TransSeqNr = t2.TransSeqNr
group by t1.IpBaseNr
having count(*) > 1
order by count(*) desc

-- Each IPA always has STN - YES
select *
from RecIpa t1
	left join RecStn t2 on t1.FileId = t2.FileId and t1.TransSeqNr = t2.TransSeqNr
where t1.Id is null

-- Example of many STN
select *
from RecIpa t1
	join RecStn t2 on t1.FileId = t2.FileId and t1.TransSeqNr = t2.TransSeqNr
where t1.IpBaseNr = 'I-000677793-9'

-- NCN - list of alternative names for interested party, related to interested party through TransSeqNr
select top 1000 *
from RecIpa t1
	left join RecNcn t2 on t1.FileId = t2.FileId and t1.TransSeqNr = t2.TransSeqNr
order by t1.FileId, t1.TransSeqNr

-- NUN - extra information related to IpNameNr, never used for Royalty calculation
select top 1000 *
from RecNun t1
order by t1.FileId, t1.TransSeqNr

-- MAN - agreement with society SocCde per CreClsCde/RolCde/RgtCde during time between ValidFrom-ValidTo for share Shr
select top 1000 *	   
from RecIpa t1		   
	left join RecMan t2 on t1.FileId = t2.FileId and t1.TransSeqNr = t2.TransSeqNr
order by t1.FileId, t1.TransSeqNr

-- TMA - after MAN always follow TMA !!!YES
select *   
from RecMan t1		   
	left join RecTma t2 on t1.FileId = t2.FileId 
		and t1.TransSeqNr = t2.TransSeqNr
		and cast(t1.RecSeqNr as int)  = cast(t2.RecSeqNr as int) - 1
where t2.Id is null

-- TMA - after MAN always follow SINGLE TMA !!!YES
select *   
from RecMan t1		   
	join RecTma t2 on t1.FileId = t2.FileId 
		and t1.TransSeqNr = t2.TransSeqNr
		and cast(t1.RecSeqNr as int)  = cast(t2.RecSeqNr as int) - 2

-- Create sequence of MAN records
drop table if exists RecManList
select
	  t1.FileId
	, t1.TransSeqNr
	, t1.RecSeqNr
	, ( 
		select min(t2.RecSeqNr) 
		from RecMan t2 
		where t2.FileId = t1.FileId
			and t2.TransSeqNr = t1.TransSeqNr
			and t2.RecSeqNr > t1.RecSeqNr
	  ) as NextRecSeqNr
into RecManList
from RecMan t1

/*
	 Base records from new full update that are missing in current SocIpi
*/
drop table if exists IpiBaseMissing
select t1.*
into IpiBaseMissing
from IpiBase t1
	left join SocIpi..IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
where t2.Id is null

-- Check that they are present in transactions - NO MENTIONING !!!
select * 
from IpiBaseMissing t1
   left join SocIpi..UpdTrans t2 on t1.IpBaseNr = t2.IpBaseNr
order by t1.AmdDt desc

select * 
from IpiBaseMissing t1
   left join SocIpi..UpdTrans t2 on t1.IpBaseNr = t2.IpBaseNrRef
order by t1.AmdDt desc

-- ===============================================================================

/*
	 Base records NOT PRESENT in new full update that are AVAILABLE in current SocIpi
*/
drop table if exists IpiBaseExcessive
select t2.*
into IpiBaseExcessive
from IpiBase t1
	right join SocIpi..IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
where t1.Id is null

-- !!! GREAT - All of them are mentioned ONLY in transactions after latest DUM
select t2.* 
from IpiBaseExcessive t1
   left join SocIpi..UpdTrans t2 on t1.IpBaseNr = t2.IpBaseNr
order by t2.TransD

-- !!! GREAT - No base records missded from updates
select t2.* 
from IpiBaseExcessive t1
   right join SocIpi..UpdTrans t2 on t1.IpBaseNr = t2.IpBaseNr
where t2.TransD > datefromparts(2024, 8, 31)


/*
	 Field by field comparison
*/
----------------- IpType Diff
select top 1 t2.*
from IpiBaseCur t1
	join IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
where t1.IpType <> t2.IpType

-- IDENTICAL

------------------------------------------
select top 1000 t1.BirthD, t2.BirthD
from SocIpi..IpiBase t1
	join IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
where t1.BirthD <> t2.BirthD

select top 1000 t1.DeathD, t2.DeathD
from SocIpi..IpiBase t1
	join IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
where t1.DeathD <> t2.DeathD

---------------------- BirthPlace Diff
select t1.IpBaseNr, t1.BirthPlace as CurValue, t2.BirthPlace as NewValue
--into IpiBaseNr_BirthPlace_Diff
from IpiBaseCur t1
	join IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
where t1.BirthPlace <> t2.BirthPlace

-- IDENTICAL
--

-- BirthState
select t1.IpBaseNr, t1.BirthState, t2.BirthState
from IpiBaseCur t1
	join IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
where t1.BirthState <> t2.BirthState

-- ============================


