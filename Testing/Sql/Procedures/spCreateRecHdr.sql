use SocIpiTesting
go

create or alter procedure spCreateRecHdr
as
begin
drop table if exists RecHdr

select
	  Id
	, FileId
	, substring(Text, 1,   3) as RecType
	, substring(Text, 4,   2) as SenderType
	, substring(Text, 6,   9) as SenderId
	, substring(Text, 15, 45) as SenderName
	, substring(Text, 60,  5) as StdVerNr
	, substring(Text, 65,  8) as CreD
	, substring(Text, 73,  6) as CreT
	, substring(Text, 79,  8) as TransmitD
into RecHdr
from FullDumpFileRecords
where substring(Text, 1, 3) = 'HDR'

end

-- exec spCreateRecHdr