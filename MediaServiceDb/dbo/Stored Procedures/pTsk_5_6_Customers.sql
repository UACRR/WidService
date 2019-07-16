CREATE procedure   [dbo].[pTsk_5_6_Customers]  (@beginDate date = NULL, @endDate date = NULL)
AS
Begin 
--Користувачі

set @beginDate = isnull(@beginDate, (select convert(date, (convert(char(4),year(getdate()))+'-01-01'))))
set @endDate = isnull(@endDate, getdate())

if @beginDate>@endDate
		return

declare @result table(
	custId	int,
	custName		nvarchar(250),
	INNOKPO		nvarchar(20),
	cntDog			int,
	amount			money,
	primary key  (custId)
)

insert @result
 (	custId,	custName	,INNOKPO,	cntDog,	amount)
select  TabCntLic.custId, vCustomer.name as custName, vCustomer.INNOKPO,  TabCntLic.cntDog,
 isnull(TabTurn.amount,0) as amount from 
(
select t1.custId, count(*) as cntDog 
from customer t1 
join LicenseAgreement t2 on t1.custId = t2.custId and t2.licStatus = 2 and licCode <> 28
group by t1.custId
) TabCntLic 
 left  join 
(
 select t2.custId, sum(t1.amount) as amount
  from payTurn t1 
  join account t2 on t2.accId = t1.accIdDebet
 where dateWork between @beginDate and @endDate and
 t1.accDebet like '22%' and accCredit like '10%'
 group by t2.custId  
)	TabTurn on (TabTurn.custId = TabCntLic.custId)
 left join 
 vCustomer on (vCustomer.custId = TabCntLic.custId)

 select * from @result


END
--exec  pTsk_5_6_Customers null, null
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pTsk_5_6_Customers] TO [ReportUser]
    AS [dbo];

