use SocIpiTesting
go

create or alter procedure spCreateRecTrl
as
begin
drop table if exists RecTrl

select
	  Id
	, FileId
	, substring(Text, 1, 3) as RecType
	, substring(Text, 4, 5) as GrCnt
	, substring(Text, 9, 8) as TransCnt
	, substring(Text, 17, 8) as RecCnt
into RecTrl
from FullDumpFileRecords
where substring(Text, 1, 3) = 'TRL'

end

-- exec spCreateRecTrl