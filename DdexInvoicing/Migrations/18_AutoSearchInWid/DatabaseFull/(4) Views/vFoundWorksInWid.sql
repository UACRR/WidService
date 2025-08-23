use AutoSearch
go

create or alter view vFoundWorksInWid
as
	select 
		  t2.Title
		, t3.WrkTtl
		, isnull(t2.ComposerAuthor, '') as sAuthors
		, isnull(t4.Authors, '')	as tAuthors
		, isnull(t2.DisplayArtistName, '') as sPerformers
		, isnull(t5.Performers, '') as tPerformers
		, t2.Status
	from FoundWorksInWid t1
		join Ddex..IdentMw t2 on t1.SourceWorkId = t2.Id
		join SocWid..WidTitle t3 on t1.TargetWic = t3.Wic
		left join MediaService..vWidAuthorAgg t4 on t3.Wic = t4.Wic
		left join MediaService..vWidPerformerAgg t5 on t3.Wic = t5.Wic
go

-- select * from vFoundWorksWid where Status <> 2