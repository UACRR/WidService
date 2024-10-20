use SocIpiTesting
go

create or alter procedure spCreateRecMun
as
begin
drop table if exists RecMun

select
	  Id
	, FileId
	, substring(Text, 1,   3) as RecType
	, substring(Text, 4,   8) as TransSeqNr
	, substring(Text, 12,  8) as RecSeqNr
	, substring(Text, 20, 11) as IpNameNr
	, substring(Text, 20, 11) as IpBaseNr
	, substring(Text, 31,  2) as CreClsCde
	, substring(Text, 33,  2) as RolCde
into RecMun
from FullDumpFileRecords
where substring(Text, 1, 3) = 'MUN'

end

-- exec spCreateRecMun