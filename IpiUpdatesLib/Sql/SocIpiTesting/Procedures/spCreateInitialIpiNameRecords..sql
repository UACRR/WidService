use SocIpiTesting
go

create or alter procedure spCreateInitialIpiNameRecords
as
begin

truncate table IpiName

insert IpiName (
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
	  t1.IpBaseNr										as IpBaseNr
	, t2.IpNameNr										as IpNameNr
	, null												as IpNameNrRef
	, null												as IpBaseNrRef
	, trim(t2.Name)										as Name
	, trim(t2.FstName)									as FstName
	, t2.NameType										as NameType
	, dbo.fncGetDateTimeFromStrings(t2.CreD, t2.CreT)	as CreDt
	, dbo.fncGetDateTimeFromStrings(t2.AmdD, t2.AmdT)	as AmdDt
	, 0	as IsDeleted
from RecIpa t1
	join RecNcn t2 on t1.FileId = t2.FileId and t1.TransSeqNr = t2.TransSeqNr

insert IpiName (
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
	  t1.IpBaseNr										as IpBaseNr
	, t2.IpNameNr										as IpNameNr
	, t1.IpNameNrRef								    as IpNameNrRef
	, t2.IpBaseNr										as IpBaseNrRef
	, trim(t2.Name)										as Name
	, '' 												as FstName
	, t2.NameType										as NameType
	, dbo.fncGetDateTimeFromStrings(t2.CreD, t2.CreT)	as CreDt
	, dbo.fncGetDateTimeFromStrings(t2.AmdD, t2.AmdT)	as AmdDt
	, 0	as IsDeleted
from RecIpa t1
	join RecMcn t2 on t1.FileId = t2.FileId and t1.TransSeqNr = t2.TransSeqNr

insert IpiName (
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
	  t1.IpBaseNr										as IpBaseNr
	, t2.IpNameNr										as IpNameNr
	, t2.IpNameNrRef								    as IpNameNrRef
	, null												as IpBaseNrRef
	, trim(t2.Name)										as Name
	, trim(t2.FstName)									as FstName
	, t2.NameType										as NameType
	, dbo.fncGetDateTimeFromStrings(t2.CreD, t2.CreT)	as CreDt
	, dbo.fncGetDateTimeFromStrings(t2.AmdD, t2.AmdT)	as AmdDt
	, 0	as IsDeleted
from RecIpa t1
	join RecOnn t2 on t1.FileId = t2.FileId and t1.TransSeqNr = t2.TransSeqNr
end

-- exec spCreateInitialIpiNameRecords