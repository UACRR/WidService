use SocIpiTesting
go

create or alter procedure spCreateRecGrt
as
begin
drop table if exists RecGrt

select
	  Id
	, FileId
	, substring(Text, 1,  3) as RecType
	, substring(Text, 4,  5) as GrId
	, substring(Text, 9,  8) as TransCnt
	, substring(Text, 17, 8) as RecCnt
into RecGrt
from FullDumpFileRecords
where substring(Text, 1, 3) = 'GRT'

end

-- exec spCreateRecGrt