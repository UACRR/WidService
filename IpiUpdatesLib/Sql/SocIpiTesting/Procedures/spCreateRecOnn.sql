use SocIpiTesting
go

create or alter procedure spCreateRecOnn
as
begin
drop table if exists RecOnn

select
	  Id
	, FileId
	, substring(Text, 1,    3) as RecType
	, substring(Text, 4,    8) as TransSeqNr
	, substring(Text, 12,   8) as RecSeqNr
	, substring(Text, 20,  11) as IpNameNr
	, substring(Text, 31,  90) as Name
	, substring(Text, 121, 45) as FstName
	, substring(Text, 166,  2) as NameType
	, substring(Text, 168,  8) as CreD
	, substring(Text, 176,  6) as CreT
	, substring(Text, 182,  8) as AmdD
	, substring(Text, 190,  6) as AmdT
	, substring(Text, 196, 11) as IpNameNrRef
	into RecOnn
from FullDumpFileRecords
where substring(Text, 1, 3) = 'ONN'

end

-- exec spCreateRecOnn