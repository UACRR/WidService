use CopyrightObjectSearch
go

create or alter procedure spUpdatePartnerWorkAlbums
as
begin

-- do not normalize names here
drop table if exists TmpInitialNames
select 
	  Id			           as MwId
	, left(ResourceTitle, 64)  as Names
into TmpInitialNames
from Ddex..IdentMw

delete from PartnerWorkAlbums
insert PartnerWorkAlbums (Name)
select distinct Names
from TmpInitialNames

update t1
set t1.AlbumId = t3.Id
from TmpPartnerWorks t1
	join TmpInitialNames t2 on t1.MwId = t2.MwId
	join PartnerWorkAlbums t3 on t2.Names = t3.Name

end

-- exec spUpdatePartnerWorkAlbums