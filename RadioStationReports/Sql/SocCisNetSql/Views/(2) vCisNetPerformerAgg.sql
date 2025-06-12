use MediaService
go

create or alter view vCisNetPerformerAgg
as
with PerformerDistinct as (
	select 
		  WorkId										  as WorkId
		, trim(concat(trim(FstName), ' ', trim(LstName))) as Name
	from SocCisNet..WorkPerformers
)
select
	  WorkId										 as WorkId
	, string_agg(convert(varchar(max), Name), ', ')	 as Performers
from PerformerDistinct
group by WorkId
go

-- select * from vCisNetPerformerAgg




