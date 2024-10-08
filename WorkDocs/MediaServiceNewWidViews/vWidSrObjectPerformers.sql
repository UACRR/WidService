use MediaService
go

create or alter view vWidSrObjectPerformers
as
select 
	  Wic																		as Wic
	, cast(row_number() over (partition by Wic order by SeqNr ) as smallint)
																				as SeqNr -- щоб зняти проблему великих значень
	, concat(PerfArtistLstName
		, ' '
		, PerfArtistFstName)													as PerformerName 
from SocWid..WidArtist
go

-- select * from vWidSrObjectPerformers order by Wic



