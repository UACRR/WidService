use AutoSearch
go

create or alter view vFoundWorksInMs
as
	select t2.Title, t2.ComposerAuthor, t2.DisplayArtistName, t3.Name, t3.Author, t3.Performer
	from AutoSearch..FoundWorksInMs t1
		join Ddex..IdentMw t2 on t1.SourceWorkId = t2.Id
		join MediaService..ObjectRight t3 on t1.TargetObjId = t3.ObjId
go
