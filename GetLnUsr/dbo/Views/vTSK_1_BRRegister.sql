CREATE view [dbo].[vTSK_1_BRRegister] as 
with tabAvanses as 
(select t3.rmId, sum(isnull(t1.prepaySum,0)) as prepaySum
from 
 RegisterCount t1 
 join Register t2 on t1.regId = t2.regId 
 join RegisterRatedList t3 on t3.rmId = t2.rmId
 group by t3.rmId
 )
select t3.custId, t1.periodId, t3.periodName, t1.createDate, 
t1.amount as fullAmount,
t1.royalty as rAmount, 
isnull(t3.distribamount,0)+isnull(t3.undistribamount,0) as PaidAmount, --сума закріплених коштів
--isnull(t3.distribamount,0) as distribamount, 
isnull(t1.paidAmount,0) as distribamount, 
t3.amount - (isnull(t3.distribamount,0)+isnull(t3.undistribamount,0)) as borg, 
isnull(t4.prepaySum, 0) as prepaySum,
t1.status, 
t5.name as statusName, t1.rmId
from RegisterRatedList t1 
join PaidPeriod t3 on t3.periodId = t1.periodId
left join tabAvanses t4 on t1.rmId = t4.rmId
join registerliststatus t5 on t1.status = t5.codeI
join vLicenseAgreement t6 on t6.licId = t3.licId and isnull(t6.registerType,3) = 3
