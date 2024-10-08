use RadioStationReports
go

create or alter view vCustomerNamesShort as 
select custId, shortName
from MediaService..AnketaCompany
union
select 
	  custId
	, concat(
		  trim(isnull(lastName, ''))
		, case when trim(isnull(firstName, '')) = '' then '' else ' ' end
		, trim(isnull(firstName, ''))
		, case when trim(isnull(surName, '')) = '' then '' else ' ' end
		, trim(isnull(surName, ''))
	  ) as Name
from MediaService..AnketaPerson
union
select
	  custId
	, concat(
		  trim(isnull(Name, ''))
		, case when trim(isnull(Name, '')) = '' then '' else ' ' end
		, trim(isnull(firstName, ''))
	  ) as Name
from MediaService..AnketaExternal
GO

-- select * from vCustomerNamesShort


