USE [CWR]
GO

/****** Object:  View [dbo].[vRightHoldersOwnActive]    Script Date: 04.10.2025 20:13:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create or alter view [dbo].[vRightHoldersOwnActive]
as
select t1.*
from MediaService..RightHolder t1
	join MediaService..AgreementAddRH t2 on t1.CustId = t2.CustId
where 
	    t2.agrStatus = 2 
	and dbo.fnIsDateInInterval(getdate(), t2.DateBegin, t2.DateEnd) = 1
GO


