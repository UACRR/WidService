use AppleMusic
go

create or alter procedure spCreateClaimedContentReport
	@rightType char(3)
as
begin
	truncate table ClaimedContentReport
	insert ClaimedContentReport (
		TrackAdamId
      ,	RepRatio
      ,	Tunecode
      ,	Iswc
      ,	ComposersAuthors
      ,	PublisherNames
	)
	select
		 TrackDspId as TrackAdamId
      ,	 case when @rightType = 'PER' then PerShr else MecShr end as RepRatio
      ,	 ObjId as Tunecode
      ,	 '' as Iswc
      ,	 '' as ComposersAuthors
      ,	 '' as PublisherNames
	from TrackShares

	update t1
	set t1.Iswc = t2.Iswc
	from ClaimedContentReport t1
		join MediaService..MediaTrack t2 on t1.Tunecode = t2.ObjId
	where trim(isnull(t2.Iswc, '')) <> ''
		and dbo.fnCheckIswc(t2.Iswc) = 1


	drop table if exists #AuthorNames
	select
		  ObjId									  as ObjId
		, dbo.ClrRefineText(trim(value))		  as AuthorName
	into #AuthorNames
	from MediaService..ObjectRight
		cross apply string_split(Author, ',')
	where ObjId in (select Tunecode from ClaimedContentReport)
		and trim(value) <> ''

	; with AuthorAgg as (
		select ObjId, string_agg(AuthorName, '|') as Authors
		from #AuthorNames
		where AuthorName <> ''
		group by ObjId
	)
	update t1
	set t1.ComposersAuthors = t2.Authors
	from ClaimedContentReport t1
		join AuthorAgg t2 on t1.Tunecode = t2.ObjId

	; with Publishers as (
		select distinct t1.Tunecode, t4.shortName as Name
		from ClaimedContentReport t1
			join MediaService..CopyRight t2 on t1.Tunecode = t2.ObjId
			join MediaService..RightHolder t3 on t2.CustId = t3.CustId
			join MediaService..vCustomerNamesShort t4 on t2.CustId = t4.CustId
		where t3.rHolderType = 3
	),
	PublisherAgg as (
		select Tunecode, string_agg(Name, '|') as Publishers
		from Publishers
		group by Tunecode
	)
	update t1
	set t1.PublisherNames = t2.Publishers
	from ClaimedContentReport t1
		join PublisherAgg t2 on t1.Tunecode = t2.Tunecode

	update ClaimedContentReport
	set PublisherNames = 'NGO-UACRR'
	where PublisherNames in ('UNKNOWN PUBLISHER', '') 
		
end
go

-- exec spCreateClaimedContentReport 'MEC'
-- select * from ClaimedContentReport where cast(RepRatio as decimal) > 0 and ComposersAuthors = ''
-- select * from ClaimedContentReport where cast(RepRatio as decimal) > 0 and ComposersAuthors like '%||%'
