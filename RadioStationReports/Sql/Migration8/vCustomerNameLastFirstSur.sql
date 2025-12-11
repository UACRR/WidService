USE [MediaService]
GO



create or alter view [dbo].[vCustomerNameLastFirstSur] as 
select
	  custId
	, ShortName as Name
from AnketaCompany
union
select 
	  custId
	, concat(
		  trim(lastName)
		, case when firstName is null then '' else concat(' ', trim(firstName)) end
		, case when surName is null then '' else concat(' ', trim(surName)) end
	  )  as Name
from AnketaPerson
GO

-- select * from vCustomerNameLastFirstSur


