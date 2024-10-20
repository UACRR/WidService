use SocIpiTesting
go

create or alter view vRecIpaWithBdn
as
select t1.IpBaseNr, t2.*
from RecIpa t1
	join RecBdn t2 on t1.FileId = t2.FileId
		and t1.TransSeqNr = t2.TransSeqNr
-- select * from vRecIpaWithBdn