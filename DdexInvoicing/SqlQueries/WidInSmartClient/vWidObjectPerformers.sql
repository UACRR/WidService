/*
select 
	  Wic			as Wic
	, SeqNr			as SeqNr
	, LstNa + FstNa as PerformerName 
from [WID_IPI].[dbo].[TblArtist]
*/

select 
	  Wic							as Wic
	, SeqNr							as SeqNr
	, concat(PerfArtistLstName
		, ' '
		, PerfArtistFstName)		as PerformerName 
from SocWid..WidArtist