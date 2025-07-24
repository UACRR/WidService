use MediaService
go

if not exists (select null from Category where CodeI = 18)
	insert Category (CodeI, Name)
	values (18, 'Спеціальний твір ТІКТОК для заявлення роялті неідентифікованих творів')
go

if not exists (select null from CustomerType where CodeI = 7)
	insert CustomerType (CodeI, Name)
	values (7, 'Системний правовласник ТІКТОК')
go

if not exists (select null from Customer where CustType = 7)
	insert Customer(custType, status, ankVersion)
	values (7, 2, 1)

declare @custId int = (select custId from Customer where custType = 7)

--select * from vCustomerNames where custId = @custId

if not exists (select null from RightHolder where CustId = @custId)
	insert RightHolder (
	  custId
	, signP
	, aroundWord
	, interCode
	, innerCode
	, rHolderType
	, IPIBase
	, comment
	, datePassed
)
values (
	  @custId -- custId
	, null -- signP
	, 0 -- aroundWord
	, null -- interCode
	, @custId -- innerCode
	, 2 -- rHolderType (Товариство)
	, null -- IPIBase
	, 'Забриає надлишок ТІКТОКУ за твір після виключень' -- comment
	, null -- datePassed
)

if not exists (select null from AnketaExternal where CustId = @custId)
	insert AnketaExternal (
		  CustId
		, Name
		, countryCode
		, innOkpo
		, firstName
	)
	values (
		  @custId -- CustId
		, 'Отримувач залишку роялті від ТІКТОК' -- Name
		, '804' -- countryCode (Україна)
		, null -- innOkpo
		, '' -- ShortName
	)

	

go