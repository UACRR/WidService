use CopyrightObjectSearch
go

create or alter procedure spUpdatePartnerWorkPerformers
as
begin

drop table if exists TmpInitialNames
select 
	  Id			    as MwId
	, DisplayArtistName as Names
into TmpInitialNames
from Ddex..IdentMw

exec spNormalizeNames

insert PartnerWorkPerformers (Name)
select distinct left(Names, 256)
from TmpNormalizedNames

update t1
set t1.PerformersId = t3.Id
from TmpPartnerWorks t1
	join TmpInitialNames t2 on t1.MwId = t2.MwId
	join PartnerWorkPerformers t3 on t2.Names = t3.Name

end

-- exec spUpdatePartnerWorkPerformers