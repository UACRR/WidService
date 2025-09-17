use MediaService
go

create view vCustomerNamesLastAndFirst as 
select custId, Name as LastName, '' as FirstName
from AnketaCompany
union
select custId, lastName Name, firstName
from AnketaPerson
union
select custId, Name, null
from AnketaExternal
GO

select * from vCustomerNamesLastAndFirst


