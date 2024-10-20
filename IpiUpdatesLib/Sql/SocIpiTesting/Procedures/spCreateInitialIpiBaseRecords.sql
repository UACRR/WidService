use SocIpiTesting
go

create or alter procedure spCreateInitialIpiBaseNrRecords
as
begin

truncate table IpiBase

insert IpiBase (
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
	  t1.IpBaseNr															as IpBaseNr
	, trim(t2.IpType)														as IpType
	, dbo.fncGetDateFromStringsLower(t2.BirthYy, t2.BirthMm, t2.BirthDd)	as BirthD
	, dbo.fncGetDateFromStringsLower(t2.DeathYy, t2.DeathMm, t2.DeathDd)    as DeathD
	, trim(t2.BirthPlace)													as BirthPlace
	, trim(t2.BirthState)													as BirthState
	, trim(t2.BirthTisNr)													as BirthTisNr
	, dbo.fncGetDateFromString(t2.TisNrValidFrom)							as TisNrFromD
	, trim(t2.BirthTisan)						 							as BirthTisan
	, dbo.fncGetDateFromString(t2.TisanValidFrom)							as TisanFromD
	, trim(t2.Sex)															as Sex
	, dbo.fncGetDateTimeFromStrings(t2.AmdD, t2.AmdT)						as AmdDt
from RecIpa t1
	join RecBdn t2 on t1.FileId = t2.FileId and t1.TransSeqNr = t2.TransSeqNr
end

-- exec spCreateInitialIpiBaseNrRecords