use CopyrightObjectSearch
go

create or alter procedure spUpdatePartnerWorkAuthors
as
begin

drop table if exists TmpInitialNames
select 
	  Id			 as MwId
	, ComposerAuthor as Names
into TmpInitialNames
from Ddex..IdentMw

exec spNormalizeNames

delete from PartnerWorkAuthors
insert PartnerWorkAuthors (Name)
select distinct left(Names, 256)
from TmpNormalizedNames

update t1
set t1.AuthorsId = t3.Id
from TmpPartnerWorks t1
	join TmpInitialNames t2 on t1.MwId = t2.MwId
	join PartnerWorkAuthors t3 on t2.Names = t3.Name

end

-- exec spUpdatePartnerWorkAuthors