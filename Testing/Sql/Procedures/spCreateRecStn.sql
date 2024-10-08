use SocIpiTesting
go

create or alter procedure spCreateRecStn
as
begin
drop table if exists RecStn

select
	  Id
	, FileId
	, substring(Text, 1,   3) as RecType
	, substring(Text, 4,   8) as TransSeqNr
	, substring(Text, 12,  8) as RecSeqNr
	, substring(Text, 20, 13) as IpBaseNrRef
	, substring(Text, 33,  1) as SttCde
	, substring(Text, 34,  8) as ValidFromD
	, substring(Text, 42,  6) as ValidFromT
	, substring(Text, 48,  8) as ValidToD
	, substring(Text, 56,  6) as ValidToT
	, substring(Text, 62,  8) as AmdD
	, substring(Text, 70,  6) as AmdT
into RecStn
from FullDumpFileRecords
where substring(Text, 1, 3) = 'STN'

end

-- exec spCreateRecStn