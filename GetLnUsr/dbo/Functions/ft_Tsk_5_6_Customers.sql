CREATE function  [dbo].[ft_Tsk_5_6_Customers]  (@beginDate date = NULL, @endDate date = NULL)
RETURNS TABLE
AS
RETURN  
--Користувачі
with TabTurn as
(
 select t2.custId, sum(t1.amount) as amount
  from payTurn t1 
  join account t2 on t2.accId = t1.accIdDebet
 where dateWork between @beginDate and @endDate and
 t1.accDebet like '22%' and accCredit like '10%'
 group by t2.custId  
),
TabCntLic as 
(
select t1.custId, count(*) as cntDog 
from customer t1 
join LicenseAgreement t2 on t1.custId = t2.custId and t2.licStatus = 2 and licCode <> 28
group by t1.custId
) 
select t2.custId, t3.name as custName, t3.INNOKPO,  t2.cntDog, isnull(t1.amount,0) as amount
from TabCntLic t2
left join  TabTurn t1  on t1.custId = t2.custId
left join vCustomer t3 on t3.custId = t2.custId

--select  * from ft_Tsk_5_6_Customers ('2018-01-01', '2019-01-31')


