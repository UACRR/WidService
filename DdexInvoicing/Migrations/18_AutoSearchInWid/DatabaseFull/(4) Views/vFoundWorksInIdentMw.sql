use AutoSearch
go

create or alter view vFoundWorksInIdentMw
as
	select 
		  t2.Title as sTitle
		, t2.ComposerAuthor as sComposerAuthor
		, t2.DisplayArtistName as sDisplayArtistName
		, t3.Title as tTitle
		, t3.ComposerAuthor as tComposerAuthor
		, t3.DisplayArtistName as tDisplayArtistName
    from AutoSearch..FoundWorksInIdentMw t1
        join Ddex..IdentMw t2 on t1.SourceWorkId = t2.Id
        join Ddex..IdentMw t3 on t1.TargetWorkId = t3.Id
go

-- select * from vFoundWorksWid where Status <> 2