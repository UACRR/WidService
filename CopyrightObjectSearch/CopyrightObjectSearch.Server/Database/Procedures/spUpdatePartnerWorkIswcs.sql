use CopyrightObjectSearch
go

create or alter procedure spUpdatePartnerWorkIswcs
as
begin

drop table if exists TmpInitialNames
select 
	  Id			 as MwId
	, Iswc			 as Names
into TmpInitialNames
from Ddex..IdentMw

delete from PartnerWorkIswcs
insert PartnerWorkIswcs (Name)
select distinct left(Names, 13)
from TmpInitialNames

update t1
set t1.IswcId = t3.Id
from TmpPartnerWorks t1
	join TmpInitialNames t2 on t1.MwId = t2.MwId
	join PartnerWorkIswcs t3 on t2.Names = t3.Name

end

-- exec spUpdatePartnerWorkIswcs