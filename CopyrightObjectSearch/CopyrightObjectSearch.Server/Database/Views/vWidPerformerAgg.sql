use CopyrightObjectSearch
go

create or alter view vWidPerformerAgg
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
GO


