use MediaService
go

create or alter view vWidSrObjectPerformers
as
select 
	  Wic								as Wic
	, case 
		when SeqNr < 30000 
		then cast(SeqNr as smallint) 
		else cast(30000 as smallint) 
	  end								as SeqNr
	, concat(PerfArtistLstName
		, ' '
		, PerfArtistFstName)			as PerformerName 
from SocWid..WidArtist
go

/*
select 
	  Wic			as Wic
	, SeqNr			as SeqNr
	, LstNa + FstNa as PerformerName 
from [WID_IPI].[dbo].[TblArtist]
*/
