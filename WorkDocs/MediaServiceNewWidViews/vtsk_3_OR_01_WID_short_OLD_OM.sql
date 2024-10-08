USE [MediaService]
GO

/****** Object:  View [dbo].[vtsk_3_OR_01_WID_short]    Script Date: 2/9/2023 12:00:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create or alter view [dbo].[vtsk_3_OR_01_WID_short_OLD_OM] AS
with Shares AS
(
	SELECT t12.wic,
		   sum(cASe t12.RgtTyp when 'PER' then isnull(t12.Shares,0) else 0 end) rateTotalPER,
		   sum(cASe t12.RgtTyp when 'MEC' then isnull(t12.Shares,0) else 0 end) rateTotalMEC
	FROM [WID_IPI_].[dbo].[TblShares] t12
	GROUP BY t12.wic
),
	ObjectsR AS
(
	SELECT t12.wic,
		   t12.Ttl as Name, 
		   [WID_IPI_].[dbo].[small_to_time](isnull(DurHr,0), isnull(DurMm,0), isnull(DurSs,0)) duration,
		   t12.VrTyp specName,
		   DisCat GenreType
	FROM [WID_IPI_].[dbo].[TblTitle] t12
)
SELECT t1.WIC,
	   t1.Name,
	   t1.specName,
	   t1.GenreType as GenreName,
	   t1.duration,
	   t4.rateTotalMEC,
	   t4.rateTotalPER 
FROM ObjectsR t1
  left join Shares t4 on (t1.WIC = t4.WIC)
GO


