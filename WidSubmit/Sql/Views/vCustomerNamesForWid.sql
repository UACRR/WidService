use SocWidSubmitEx
go

create or alter view vCustomerNamesForWid as 
select 
	  custId								 as CustId
	, isnull(shortName, '')					 as Name
	, ''									 as FstName
	, dbo.ClrTranslitFromUkrToLat(
		isnull(shortName, '')
	  )										 as NameForWid
	, ''									 as FstNameForWid
from MediaService..AnketaCompany
union
select 
	  custId															as CustId
	, isnull(lastName, '')												as Name
	, trim(concat(isnull(firstName, ''), ' ', isnull(surName, '')))		as FstName
	, dbo.ClrTranslitFromUkrToLat(isnull(lastName, ''))					as NameForWid
	, dbo.ClrTranslitFromUkrToLat(
		trim(concat(isnull(firstName, ''), ' ', isnull(surName, '')))
	  )																	as FstNameForWid
from MediaService..AnketaPerson
union
select
	  custId											as CustId
	, isnull(name, '')									as Name
	, ''												as FstName
	, dbo.ClrTranslitFromUkrToLat(isnull(name, ''))		as NameForWid
	, ''												as FstNameForWid
from MediaService..AnketaExternal
go


