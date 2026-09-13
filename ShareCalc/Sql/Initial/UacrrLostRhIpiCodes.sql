drop table if exists UacrrLostRhIpiCodes
select 
	  t1.CustId
	, t3.Name
	, t3.FirstName
	, t3.SurName
	, format(t2.AgrDate, 'yyyy-MM-dd') as AgrDate
	, concat(t4.Name, ' (', t2.AgrStatus, ')') as AgrStatus
	, t1.AroundWord
	, format(t2.DateBegin, 'yyyy-MM-dd') as DateBegin
	, format(t2.DateEnd, 'yyyy-MM-dd') as DateEnd
	, format(t2.ModifyDate, 'yyyy-MM-dd') as ModifyDate
	, cast(0 as bit) IsProcessed
into UacrrLostRhIpiCodes
from MediaService..RightHolder t1
	join MediaService..AgreementAddRH t2 on t1.CustId = t2.CustId
	join MediaService..vCustomerNameDetailed t3 on t1.CustId = t3.CustId
	join MediaService..AgreementStatus t4 on t2.AgrStatus = t4.CodeI
where isnull(t1.InterCode, '') = ''
	and isnull(t3.Name, '') <> ''

	select * from UacrrLostRhIpiCodes order by Name
