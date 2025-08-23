use AutoSearch
go

create or alter view vFoundWorksWid
as
	select t2.Title, t3.WrkTtl, t2.ComposerAuthor, t4.Authors, t2.DisplayArtistName, t5.Performers, t2.Status
	from FoundWorksInWid t1
		join Ddex..IdentMw t2 on t1.SourceWorkId = t2.Id
		join SocWid..WidTitle t3 on t1.TargetWorkId = t3.Wic
		join MediaService..vWidAuthorAgg t4 on t3.Wic = t4.Wic
		join MediaService..vWidPerformerAgg t5 on t3.Wic = t5.Wic
go

-- select * from vFoundWorksWid where Status <> 2