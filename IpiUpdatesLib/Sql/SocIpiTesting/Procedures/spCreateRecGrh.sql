use SocIpiTesting
go

create or alter procedure spCreateRecGrh
as
begin
drop table if exists RecGrh

select
	  Id
	, FileId
	, substring(Text, 1, 3 ) as RecType
	, substring(Text, 4, 3 ) as TransType
	, substring(Text, 7, 5 ) as GrId
	, substring(Text, 12, 5) as VerNr
into RecGrh
from FullDumpFileRecords
where substring(Text, 1, 3) = 'GRH'

end

-- exec spCreateRecGrh