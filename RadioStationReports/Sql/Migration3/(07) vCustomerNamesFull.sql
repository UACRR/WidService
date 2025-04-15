USE [MediaService]
GO

/****** Object:  View [dbo].[vCustomerNames]    Script Date: 03.04.2025 16:27:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create or alter view [dbo].[vCustomerNamesFull] as 
select custId, Name, ShortName
from AnketaCompany
union
select custId, concat(lastName, case when firstName is null then '' else concat(' ', firstName) end) Name, '' as ShortName
from AnketaPerson
union
select custId, Name, '' as ShortName
from AnketaExternal
GO


