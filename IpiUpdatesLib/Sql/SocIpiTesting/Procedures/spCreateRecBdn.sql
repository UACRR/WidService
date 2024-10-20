use SocIpiTesting
go

create or alter procedure spCreateRecBdn
as
begin
drop table if exists RecBdn

select
	  Id
	, FileId
	, substring(Text, 1,    3) as RecType
	, substring(Text, 4,    8) as TransSeqNr
	, substring(Text, 12,   8) as RecSeqNr
	, substring(Text, 20,   1) as IpType
	, substring(Text, 21,   4) as BirthYy
	, substring(Text, 25,   2) as BirthMm
	, substring(Text, 27,   2) as BirthDd
	, substring(Text, 29,   4) as DeathYy
	, substring(Text, 33,   2) as DeathMm
	, substring(Text, 35,   2) as DeathDd
	, substring(Text, 37,  30) as BirthPlace
	, substring(Text, 67,  30) as BirthState
	, substring(Text, 97,   4) as BirthTisNr
	, substring(Text, 101,  8) as TisNrValidFrom
	, substring(Text, 109, 20) as BirthTisan
	, substring(Text, 129,  8) as TisanValidFrom
	, substring(Text, 137,  1) as Sex
	, substring(Text, 138,  8) as AmdD
	, substring(Text, 146,  6) as AmdT
into RecBdn
from FullDumpFileRecords
where substring(Text, 1, 3) = 'BDN'

end

-- exec spCreateRecBdn