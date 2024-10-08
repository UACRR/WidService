USE [RadioStationReports]
GO

/****** Object:  StoredProcedure [dbo].[spSearchMatchingWorksInWid]    Script Date: 8/7/2024 2:06:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE     procedure [dbo].[spSearchMatchingWorksInWid]
	  @reportId int
as
begin

drop table if exists #Found
select t1.Id, t2.Wic, 'W' as FoundInDb, 'M' as MainOrAlt
into #Found
from ReportLines t0
	join Works t1 on t0.WorkId = t1.Id
	join SocWid..widTitle t2 on t1.NameT = t2.WrkTtl
where t0.ReportId = @reportId
	and t1.IsProcessed is null

insert #Found
select t1.Id, t2.Wic, 'W' as FoundInDb, 'M' as MainOrAlt
from ReportLines t0
	join Works t1 on t0.WorkId = t1.Id
	join SocWid..widTitle t2 on 
		trim(
			substring( t1.NameT
				, 1
				, case when charindex('(', t1.NameT) = 0 then len(t1.NameT) else charindex('(', t1.NameT) - 1  end)
		)
		= t2.WrkTtl
where t0.ReportId = @reportId
	and t1.IsProcessed is null
	and t2.Wic not in (select Wic from #Found tt where tt.id = t1.Id)

insert #Found
select t1.Id, t2.Wic, 'W' as FoundInDb, 'A' as MainOrAlt
from ReportLines t0
	join Works t1 on t0.WorkId = t1.Id
	join SocWid..widAltTtl t2 on t1.NameT = t2.AltTtl
where t0.ReportId = @reportId
	and t1.IsProcessed is null
	and t2.Wic not in (select Wic from #Found tt where tt.id = t1.Id)

insert #Found
select t1.Id, t2.Wic, 'W' as FoundInDb, 'A' as MainOrAlt
from ReportLines t0
	join Works t1 on t0.WorkId = t1.Id
	join SocWid..widAltTtl t2 on
		trim(
			substring( t1.NameT
				, 1
				, case when charindex('(', t1.NameT) = 0 then len(t1.NameT) else charindex('(', t1.NameT) - 1  end)
		)
		= t2.AltTtl
where t0.ReportId = @reportId
	and t1.IsProcessed is null
	and t2.Wic not in (select Wic from #Found tt where tt.id = t1.Id)

;with AuthorDistinct as (
	select 
		  t1.Wic												as Wic
		, trim(concat(trim(t2.FstName), ' ', trim(t2.Name)))	as Name
	from SocWid..widIntrPty t1
		join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
	where t1.IpRole in ('C', 'A', 'CA')
),
Authors as (
	select
		  Wic											 as Wic
		, string_agg(convert(varchar(max), Name), ', ')	 as Authors
	from AuthorDistinct
	group by Wic
),
PerformerDistinct as (
	select 
		  Wic																  as Wic
		, trim(concat(trim(PerfArtistFstName), ' ', trim(PerfArtistLstName))) as Name
	from SocWid..widArtist
),
Performers as (
	select
		  Wic											 as Wic
		, string_agg(convert(varchar(max), Name), ', ')	 as Performers
	from PerformerDistinct
	group by Wic
)

insert MatchingWorks (
      WorkId
    , Name
    , Authors
    , Performers
    , FoundInDb
    , MainOrAlt
    , FoundId
	, IsStrongMatch
)
select 
	  t1.Id as DdexPreSearchReportWorkId
	, t2.WrkTtl
	, left(t3.Authors, 1000)
	, left(t4.Performers, 1000)
	, t1.FoundInDb
	, t1.MainOrAlt
	, t1.Wic
	, 0 as IsStrongMatch
from #Found t1
	join SocWid..widTitle t2 on t1.Wic = t2.Wic
	join Authors t3 on t1.Wic = t3.Wic
	join Performers t4 on t1.Wic = t4.Wic

end
GO


