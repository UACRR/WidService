use MediaService
go

drop view if exists vWidPerformerAgg
go

create view vWidPerformerAgg
as
with PerformerDistinct as (
	select 
		  Wic																  as Wic
		, trim(concat(trim(PerfArtistFstName), ' ', trim(PerfArtistLstName))) as Name
	from SocWid..widArtist
)
select
	  Wic											 as Wic
	, string_agg(convert(varchar(max), Name), ', ')	 as Performers
from PerformerDistinct
group by Wic
go

-- select top 100 * from vWidPerformerAgg