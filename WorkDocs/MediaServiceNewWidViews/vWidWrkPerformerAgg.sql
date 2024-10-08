use MediaService
go

create or alter view vWidWrkPerformerAgg
as
select
	  Wic as Wic
	, substring(string_agg(
		  convert(varchar(max)
			, trim(concat(PerfArtistLstName, ' ', PerfArtistFstName))
		  )
		, ', '
	  ), 1, 254) as Performers
from SocWid..WidArtist
group by Wic
go