use SocIpiTesting
go

create or alter procedure spCreateRecIpa
as
begin
drop table if exists RecIpa

select
	  Id
	, FileId
	, substring(Text, 1,   3) as RecType
    , substring(Text, 4,   8) as TransSeqNr
    , substring(Text, 12,  8) as RecSeqNr
    , substring(Text, 20,  8) as TransD
    , substring(Text, 28,  6) as TransT
    , substring(Text, 34,  3) as RemitSocCde
    , substring(Text, 37, 20) as RemitSocName
    , substring(Text, 57, 13) as IpBaseNr
    , substring(Text, 70,  1) as SttCde
    , substring(Text, 71, 11) as IpNameNr
    , substring(Text, 82,  2) as NameType
    , substring(Text, 84, 13) as IpBaseNrRef
    , substring(Text, 97,  1) as SttCdeRef
    , substring(Text, 98, 11) as IpNameNrRef
    , substring(Text, 109, 2) as NameTypeRef
into RecIpa
from FullDumpFileRecords
where substring(Text, 1, 3) = 'IPA'

end

-- exec spCreateRecIpa