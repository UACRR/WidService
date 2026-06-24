use SocCisNet
go

create or alter view vCisNetPerformerAgg
as
with PerformerDistinct as (
	select 
		  WorkId			as WorkId
		, trim(Name)		as Name
	from WorkPerformers
)
select
	  WorkId										 as WorkId
	, string_agg(convert(varchar(max), Name), ', ')	 as Performers
from PerformerDistinct
group by WorkId
go

-- select * from vCisNetPerformerAgg




