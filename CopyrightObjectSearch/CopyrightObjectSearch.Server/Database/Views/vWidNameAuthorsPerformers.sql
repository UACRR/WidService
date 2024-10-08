use CopyrightObjectSearch
go

create or alter view vWidNameAuthorsPerformers
as
select
	  t1.Wic as FoundCde
	, 'W' as FoundIn
	, t1.WrkTtl as Name
	, t2.Authors as Authors
	, t3.Performers as Performers
from SocWid..widTitle t1
	join vWidAuthorAgg t2 on t1.Wic = t2.Wic
	join vWidPerformerAgg t3 on t1.Wic = t3.Wic
go

-- select * from vWidNameAuthorsPerformers
