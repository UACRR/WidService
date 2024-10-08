use CopyrightObjectSearch
go

create or alter procedure spImportExternalObjectsFromDdex
as
begin
	insert ExternalObjects(
		  Title
		, Authors
		, Performers
		, Iswc
		, FoundObjId
		, FoundWic
		, FoundIswc
		, FoundVia
		, CreatedAt
		, UpdatedAt
	)

	select distinct
		  left(trim(t1.Title), 64)				as Title
		, left(trim(t1.ComposerAuthor), 256)	as Authors
		, left(trim(t1.DisplayArtistName), 256)	as Performers
		, left(trim(t1.Iswc), 13)				as Iswc
		, 0										as FoundObjId
		, 0										as FoundWic
		, ''									as FoundIswc
		, ''									as FoundVia
		, datefromparts(1900, 1, 1)				as CreatedAt
		, datefromparts(1900, 1, 1)				as UpdatedAt
	from Ddex..IdentMw t1
		left join ExternalObjects t2 on
			    left(trim(t1.Title), 64)				= t2.Title
			and left(trim(t1.ComposerAuthor), 256)		= t2.Authors
			and left(trim(t1.DisplayArtistName), 256)	= t2.Performers
			and left(trim(t1.Iswc), 13)					= t2.Iswc
	where t2.Id is null

	update t2
	set
		  t2.FoundObjId = isnull(t1.ObjId, 0)
		, t2.FoundWic	= isnull(t1.Wic, 0)
		, t2.CreatedAt	= getdate()
		, t2.UpdatedAt	= getdate()
	from Ddex..IdentMw t1
		left join ExternalObjects t2 on
			    left(trim(t1.Title), 64)				= t2.Title
			and left(trim(t1.ComposerAuthor), 256)		= t2.Authors
			and left(trim(t1.DisplayArtistName), 256)	= t2.Performers
			and left(trim(t1.Iswc), 13)					= t2.Iswc
end
go

-- exec spImportExternalObjectsFromDdex
-- truncate table ExternalObjects

