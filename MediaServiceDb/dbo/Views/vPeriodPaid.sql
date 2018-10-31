/*==============================================================*/
/* View: vPeriodPaid                                            */
/*==============================================================*/
CREATE view [dbo].[vPeriodPaid] as
with MM as 
( 
select t1.custId, t1.amount, t2.licId, t2.periodId, sum(t2.amount) as sPaid
from 
PaidPeriod t0 
join MoneyPeriodLink t2 on t0.periodId = t2.periodId and t0.status<>6
join MoneyReceived t1 on t1.paidId = t2.paidId 
group by t1.custId, t1.amount, t2.licId, t2.periodId
) 
select 
t0.amount as AgrAmount, t0.distribamount, t0.undistribamount, t0.beginDate, t0.endDate, t0.periodName, t0.periodType,
t0.fagFirst, t0.status, 
t1.*,  
(Case When (t0.amount - t1.sPaid) >= 0  Then t0.amount - t1.sPaid Else 0 end) as PaidDebt, 
(Case When (t0.amount - t1.sPaid) <=0  Then t0.amount - t1.sPaid Else 0 end) as PaidOver
from MM t1 
join PaidPeriod t0 on t1.periodId = t0.periodId and t1.custId = t0.custId and isnull(t1.licId,0) = isnull(t0.licId,0)
GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Общая сумма оплат нек закрітым по периодам', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPeriodPaid';

