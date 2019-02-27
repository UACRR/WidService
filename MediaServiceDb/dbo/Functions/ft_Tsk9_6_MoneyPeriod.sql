CREATE function  ft_Tsk9_6_MoneyPeriod  (@paidId integer)
--Клієнт. Портал.
---Платежі за період -розподіл (paidId)
RETURNS @RT TABLE
(
id integer not null identity primary key,
clCustId integer,
paidId integer, 
periodId integer, 
licId integer, 
licNum varchar(25),
licDate date, 
periodName varchar(100), 
periodAmount money,  --сума періоду
linkAmount money,    --звязана сума
distribAmount money,  --розподілена сума, 
statusName varchar(100)
)
as
BEGIN

insert into @RT ( clCustId,paidId, periodId, licId, licNum,licDate, periodName, periodAmount,linkAmount, distribAmount, statusName )
select t2.custId, t1.paidId, t1.periodId, t2.licId, t3.licNum, t3.licDate, t4.periodName, t4.amount as periodAmount, t1.amount as linkAmount, t4.distribamount, t5.name as statusName
from MoneyPeriodLink t1 
 join LicenseAgreement t2 on t2.licId = t1.licId 
 join LicenseAgrParam t3 on t3.licId = t2.licId and t3.licVersion = t2.licVersion
 join PaidPeriod t4 on t4.periodId = t1.periodId
 join PeriodStatus t5 on t5.codeI = t4.status 
where t1.paidId = @paidId

RETURN
END

--select * from ft_Tsk9_6_MoneyPeriod (6) order by periodId
--select * from MoneyPeriodLink 
--select * from MoneyReceived where custId = 134