USE [MediaService]
GO

/****** Object:  View [dbo].[vtsk_3_OR_01_WID_short]    Script Date: 2/9/2023 12:00:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create or alter view [dbo].[vtsk_3_OR_01_WID_short] AS
with Shares AS
(
	SELECT wic,
		   sum(case RightType when 'PER' then isnull(Shares, 0) else 0 end) rateTotalPER,
		   sum(case RightType when 'MEC' then isnull(Shares, 0) else 0 end) rateTotalMEC
	FROM SocWid..WidShares
	GROUP BY wic
),
	ObjectsR AS
(
	SELECT wic,
		   WrkTtl as Name,
		   dbo.small_to_time(isnull(DurHr,0), isnull(DurMm,0), isnull(DurSs,0)) duration,
		   VerType specName,
		   MwDistrCat GenreType
	FROM SocWid..WidTitle
)
SELECT t1.WIC,
	   t1.Name,
	   t1.specName,
	   t1.GenreType as GenreName,
	   t1.duration,
	   t2.rateTotalMEC,
	   t2.rateTotalPER 
FROM ObjectsR t1
  left join Shares t2 on (t1.WIC = t2.WIC)
GO

--select * from vtsk_3_OR_01_WID_short_OLD_OM
--select top 100 * from vtsk_3_OR_01_WID_short


