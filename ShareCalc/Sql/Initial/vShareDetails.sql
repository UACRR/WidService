USE [ShareCalc]
GO

/****** Object:  View [dbo].[vShares]    Script Date: 19.07.2026 20:50:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create or alter view [dbo].[vShareDetails]
as
select
	  t1.Id								as Id
	, t1.ObjId							as ObjId
	, t1.CustId							as RhCustId
	, t2.ShortName						as RhName
	, isnull(t3.InterCode, 99)			as PerSocCode
	, isnull(t4.ShortName, 'NS')		as PerSocName
	, t1.PerShr							as RhPerShr
	, t1.PerShrRes						as RhPerShrRes
	, isnull(t5.InterCode, 99)			as MecSocCode
	, isnull(t6.ShortName, 'NS')		as MecSocName
	, t1.MecShr							as RhMecShr
	, t1.MecShrRes						as RhMecShrRes
from Shares t1
	join MediaService..vCustomerNamesShort t2 on t1.CustId = t2.CustId
	left join MediaService..Community t3 on t1.PerSoc = t3.InterCode
	left join MediaService..vCustomerNamesShort t4 on t3.CustId = t4.CustId
	left join MediaService..Community t5 on t1.MecSoc = t5.InterCode
	left join MediaService..vCustomerNamesShort t6 on t5.CustId = t6.CustId
GO


