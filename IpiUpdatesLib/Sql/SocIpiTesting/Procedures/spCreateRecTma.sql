use SocIpiTesting
go

create or alter procedure spCreateRecTma
as
begin
drop table if exists RecTma

select
	  Id
	, FileId
	, substring(Text, 1,   3) as RecType
	, substring(Text, 4,   8) as TransSeqNr
	, substring(Text, 12,  8) as RecSeqNr
	, substring(Text, 20,  4) as TisNr
	, substring(Text, 24,  8) as TisNrValidFrom
	, substring(Text, 32, 20) as Tisan
	, substring(Text, 52,  8) as TisanValidFrom
	, substring(Text, 60,  1) as IncExcInd
into RecTma
from FullDumpFileRecords
where substring(Text, 1, 3) = 'TMA'

end

-- exec spCreateRecTma