USE [CopyrightObjectSearch]
GO

/****** Object:  View [dbo].[vwPartnerWorks]    Script Date: 21.12.2024 21:19:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create or alter view vPartnerWorks
as
	select 
		  t1.*
		, t2.Name as Album	
		, t3.Name as Name		
		, t4.Name as Authors		
		, t5.Name as Performers	
		, t6.Name as Iswc		
	from PartnerWorks t1
		join PartnerWorkAlbums		t2 on t1.AlbumId		= t2.Id
		join PartnerWorkNames		t3 on t1.NameId			= t3.Id
		join PartnerWorkAuthors		t4 on t1.AuthorsId		= t4.Id
		join PartnerWorkPerformers	t5 on t1.PerformersId	= t5.Id
		join PartnerWorkIswcs		t6 on t1.IswcId			= t6.Id
GO


