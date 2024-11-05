use CopyrightObjectSearch
go

create or alter procedure spUpdatePartnerWorks
as
begin

	drop table if exists TmpPartnerWorks
	create table TmpPartnerWorks (
		  MwId			int
		, AlbumId		int
		, NameId		int
		, AuthorsId		int
		, PerformersId	int
		, IswcId		int
		, FoundObjId	int
		, FoundWic		int
		, FoundIswc		varchar(13)
		, FoundVia		varchar(8)
		, CreatedAt		datetime2(7)
		, UpdatedAt		datetime2(7)
	)

	insert TmpPartnerWorks (
		  MwId		
		, AlbumId		
		, NameId		
		, AuthorsId	
		, PerformersId
		, IswcId		
		, FoundObjId	
		, FoundWic	
		, FoundIswc	
		, FoundVia	
		, CreatedAt	
		, UpdatedAt	
	)
	select
		  Id											as MwId		
		, 0												as AlbumId		
		, 0												as NameId		
		, 0												as AuthorsId	
		, 0												as PerformersId
		, 0												as IswcId		
		, isnull(ObjId, 0)								as FoundObjId	
		, isnull(Wic, 0)								as FoundWic	
		, ''											as FoundIswc	
		, case 
			when isnull(ObjId, 0) > 0 then 'SMART'
			when isnull(Wic, 0)   > 0 then 'LOCALWID'
			else                           ''
		  end
														as FoundVia	
		, getdate()										as CreatedAt	
		, getdate()										as UpdatedAt	
	from Ddex..IdentMw

	exec spUpdatePartnerWorkAlbums
	exec spUpdatePartnerWorkNames
	exec spUpdatePartnerWorkAuthors
	exec spUpdatePartnerWorkPerformers
	exec spUpdatePartnerWorkIswcs

end
go

-- exec spUpdatePartnerWorks
