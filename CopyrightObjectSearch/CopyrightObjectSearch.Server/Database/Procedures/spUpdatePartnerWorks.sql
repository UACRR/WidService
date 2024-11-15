use CopyrightObjectSearch
go

create or alter procedure spUpdatePartnerWorks
as
begin

	exec spUpdatePartnerWorkSources

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

	-- Commit to main table PartnerWorks skipping duplicates
	delete from PartnerWorks

	; with _Rated  as (
		select
			  row_number() over(
				partition by
					  AlbumId
					, NameId
					, AuthorsId
					, PerformersId
					, IswcId
				order by
					  FoundObjId desc
					, FoundWic	 desc
					, MwId       desc
				)						as RowNumber
			, MwId						as MwId
		from TmpPartnerWorks
	)
	insert PartnerWorks (
		  AlbumId		
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
		  AlbumId		
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
	from TmpPartnerWorks t1
		join _Rated t2 on t1.MwId = t2.MwId
	where t2.RowNumber = 1

	-- Link works to sources
	delete from PartnerWorkToSources
	insert PartnerWorkToSources (
		  PartnerWorkSourceId
		, PartnerWorkId
	)
	select
		  t4.Id as PartnerWorkSourceId
		, t2.Id	as PartnerWorkId
	from TmpPartnerWorks t1
		join PartnerWorks t2 on
				t1.AlbumId		= t2.AlbumId		
			and t1.NameId		= t2.NameId		
			and t1.AuthorsId	= t2.AuthorsId	
			and t1.PerformersId	= t2.PerformersId
			and t1.IswcId		= t2.IswcId		
		join Ddex..IdentBacklog t3 on t1.MwId = t3.mwId
		join PartnerWorkSources t4 on t3.DdexReportId = t4.SourceId

    -- Drop temp tables
	drop table TmpInitialNames
	drop table TmpNormalizedNames
	drop table TmpPartnerWorks

end
go

-- exec spUpdatePartnerWorks
