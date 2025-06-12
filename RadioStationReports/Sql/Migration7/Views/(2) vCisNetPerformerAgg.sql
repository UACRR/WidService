use MediaService
go

create or alter view vCisNetPerformerAgg
as
with PerformerDistinct as (
	select 
		  WorkCode										  as WorkCode
		, trim(concat(trim(FstName), ' ', trim(LstName))) as Name
	from SocCisNet..WorkPerformers
)
select
	  WorkCode										 as WorkCode
	, string_agg(convert(varchar(max), Name), ', ')	 as Performers
from PerformerDistinct
group by WorkCode
go

-- select * from vCisNetPerformerAgg




