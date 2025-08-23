USE [AutoSearch]
GO

/****** Object:  View [dbo].[vTargetWorks]    Script Date: 04.08.2025 14:30:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create   view [dbo].[vTargetWorksWid]
as

select 
	  t2.WorkId as WorkWic
	, t1.TargetNameId as TargetNameId
	, t1.Name as WorkName
	, t4.Name as AuthorNamePart
	, t6.Name as PerformerNamePart
from TargetNamesWid t1
	join TargetNameWorksWid t2 on t1.TargetNameId = t2.TargetNameId
	join TargetAuthorPartWorksWid t3 on t2.WorkId = t3.WorkId
	join TargetAuthorPartsWid t4 on t3.TargetAuthorPartId = t4.TargetAuthorPartId
	join TargetPerformerPartWorksWid t5 on t2.WorkId = t5.WorkId
	join TargetPerformerPartsWid t6 on t5.TargetPerformerPartId = t6.TargetPerformerPartId
--where t1.Name = '×È ÒÈ ÏÎ×ÓÂ for Mariupol'

GO


