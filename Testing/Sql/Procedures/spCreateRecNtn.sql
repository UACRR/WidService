use SocIpiTesting
go

create or alter procedure spCreateRecNtn
as
begin
drop table if exists RecNtn

select
	  Id
	, FileId
	, substring(Text, 1, 3) as ecType
	, substring(Text, 4, 8) as ransSeqNr
	, substring(Text, 12, 8) as ecSeqNr
	, substring(Text, 20, 4) as isNr
	, substring(Text, 24, 8) as isNrValidFrom
	, substring(Text, 32, 20) as isan
	, substring(Text, 52, 8) as isanValidFrom
	, substring(Text, 60, 8) as alidFromD
	, substring(Text, 68, 8) as alidToD
into RecNtn
from FullDumpFileRecords
where substring(Text, 1, 3) = 'NTN'

end

-- exec spCreateRecNtn