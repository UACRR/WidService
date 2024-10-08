use MediaService
go

create or alter view vWidSrObjectAlternativeNames
as
select 
	  Wic						as Wic
	, cast(SeqNr as smallint)	as SeqNr
	, AltTtl					as AltTtl
from SocWid..WidAltTtl
go

/*
select 
	  Wic		as Wic
	, SeqNr		as SeqNr
	, AltTtl	as AltTtl
from [WID_IPI].[dbo].[TblAltTtl]
*/
