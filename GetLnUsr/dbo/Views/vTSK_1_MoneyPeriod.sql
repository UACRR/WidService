create view vTSK_1_MoneyPeriod as 
select t1.periodId, t1.custId, t1.periodName, t1.licId, t4.licNum, t4.licDate, 
t5.numberInvoice, t5.dateInvoice, t2.amount, t5.goalInvoice, t1.amount as periodAmount, 
(Case When isnull(t5.destribAmount,0) < t5.amount Then 'Не закріплено' Else 'Закріплено' end ) as statusMoney
from PaidPeriod t1 
join MoneyPeriodLink t2 on t1.periodId = t2.periodId
join LicenseAgreement t3 on t3.licId = t2.licId 
join LicenseAgrParam t4 on t3.licId = t4.licId and t3.licVersion = t4.licVersion
join MoneyReceived t5 on t2.paidId = t5.paidId
where t1.status <> 6

