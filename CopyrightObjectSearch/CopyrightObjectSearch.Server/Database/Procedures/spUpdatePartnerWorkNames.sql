use CopyrightObjectSearch
go

create or alter procedure spUpdatePartnerWorkNames
as
begin

drop table if exists TmpInitialNames
select 
	  Id			 as MwId
	, Title			 as Names
into TmpInitialNames
from Ddex..IdentMw

delete from PartnerWorkNames
insert PartnerWorkNames (Name)
select distinct left(Names, 64)
from TmpInitialNames

update t1
set t1.NameId = t3.Id
from TmpPartnerWorks t1
	join TmpInitialNames t2 on t1.MwId = t2.MwId
	join PartnerWorkNames t3 on t2.Names = t3.Name

end

-- exec spUpdatePartnerWorkNames