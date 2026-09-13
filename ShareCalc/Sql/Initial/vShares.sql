use ShareCalc
go

create or alter view vShares
as
select
	  t1.Id
	,  t1.ObjId
	, t1.CustId

	, concat('(', t2.CustId, ') ', t2.ShortName) as Правовласник
	
	, concat('('
		, isnull(t3.InterCode, '099')
		, ') '
		, isnull(t4.ShortName, 'N/A')
		, ': '
		, t1.PerShr
		,  '/'
		, t1.PerShrRes
	) as [Проценти пуб]

	, concat('('
		, isnull(t5.InterCode, '099')
		, ') '
		, isnull(t6.ShortName, 'N/A')
		, ': '
		, t1.MecShr
		,  '/'
		, t1.MecShrRes
	) as [Проценти мех]
--,* 
from Shares t1
	join MediaService..vCustomerNamesShort t2 on t1.CustId = t2.CustId
	left join MediaService..Community t3 on t1.PerSoc = t3.InterCode
	left join MediaService..vCustomerNamesShort t4 on t3.CustId = t4.CustId
	left join MediaService..Community t5 on t1.MecSoc = t5.InterCode
	left join MediaService..vCustomerNamesShort t6 on t5.CustId = t6.CustId
go

-- select * from vShares
