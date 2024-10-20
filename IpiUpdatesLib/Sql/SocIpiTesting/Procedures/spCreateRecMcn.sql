use SocIpiTesting
go

create or alter procedure spCreateRecMcn
as
begin
drop table if exists RecMcn

select
	  Id
	, FileId
	, substring(Text, 1,    3) as RecType
	, substring(Text, 4,    8) as TransSeqNr
	, substring(Text, 12,   8) as RecSeqNr
	, substring(Text, 20,  11) as IpNameNr
	, substring(Text, 31,  90) as Name
	, substring(Text, 121,  2) as NameType
	, substring(Text, 123,  8) as CreD
	, substring(Text, 131,  6) as CreT
	, substring(Text, 137,  8) as AmdD
	, substring(Text, 145,  6) as AmdT
	, substring(Text, 151, 13) as IpBaseNr
into RecMcn
from FullDumpFileRecords
where substring(Text, 1, 3) = 'MCN'

end

-- exec spCreateRecMcn