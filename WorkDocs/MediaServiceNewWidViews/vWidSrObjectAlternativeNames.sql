use MediaService
go

create or alter view vWidSrObjectAlternativeNames
as
select 
	  Wic		as Wic
	, cast(SeqNr as smallint)		as SeqNr
	, AltTtl	as AltTtl
from SocWid..WidAltTtl
go


