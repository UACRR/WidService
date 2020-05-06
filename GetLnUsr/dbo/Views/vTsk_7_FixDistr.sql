create view vTsk_7_FixDistr 
as
with TabDistr as 
(
select t6.objid, t7.name as objectName, t7.author, t7.performer, 
t9.amount as amountDistObj, t8.distId, t3.regId, t6.regIItemId, t4.licId, t1.periodId, t2.rmId
from PaidPeriod t1 
join RegisterRatedList t2 on t1.periodId = t2.periodId 
join Register t3 on t3.rmid = t2.rmid
join LicenseAgreement t4 on t1.licId = t4.licId 
join Fixation t5 on t5.licId = t4.licId
join RegisterItem t6 on t3.regId = t6.regId 
join ObjectRight t7 on t7.objid = t6.objId
left join distribution t8 on t8.regId = t3.regId 
left join DistributionItem t9 on t9.distId = t8.distId and t9.regId = t6.regId and t9.regIItemId = t6.regIItemId
)
, 
--Платежи
TabTurn as 
(
select t3.custId, sum(t1.amount) as amount
from PayTurn t1 
join TabDistr t2 on t1.distId = t2.distId and t1.regId = t2.regId and t1.regIItemId = t2.regIItemId
join Account t3 on t1.accIdDebet = t3.accId 
group by t3.custId 
)
select t1.licId, t1.regId, t1.objId, t1.objectName, t1.author, t1.performer, t2.custId, t4.name as rhName, isnull(t3.amount,0) as amount, t1.periodId, t1.rmId, t1.distId
from TabDistr t1 
left join RegisterCount t2 on t2.regId = t1.regId and t2.regIItemId = t1.regIItemId
left join TabTurn t3 on t3.custId = t2.custId
left join vCustomer t4 on t2.custId = t4.custId

