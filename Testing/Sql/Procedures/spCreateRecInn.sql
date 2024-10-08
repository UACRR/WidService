use SocIpiTesting
go

create or alter procedure spCreateRecInn
as
begin
drop table if exists RecInn

select
	  Id
	, FileId
	, substring(Text, 1,   3) as RecType
	, substring(Text, 4,   8) as TransSeqNr
	, substring(Text, 12,  8) as RecSeqNr
	, substring(Text, 20, 11) as IpNameNr
	, substring(Text, 31,  2) as CreClsCde
	, substring(Text, 33,  2) as RolCde
into RecInn
from FullDumpFileRecords
where substring(Text, 1, 3) = 'INN'

end

-- exec spCreateRecInn