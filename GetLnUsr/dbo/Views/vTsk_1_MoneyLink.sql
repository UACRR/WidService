create view vTsk_1_MoneyLink as 
with TabLink as
(select t1.paidId, max(t2.numberInvoice) as numberInvoice, t1.periodId, sum(t1.amount) as amountLink, t2.moneyType 
 from MoneyPeriodLink t1 
 join MoneyReceived t2 on t1.paidId = t2.paidId
 group by t1.paidId, t1.periodId, moneyType )
select t1.paidId,  t1.numberInvoice, t3.name as moneyTypeName, t2.periodName, t2.amount as amountPeriod, t1.amountLink, (t2.amount - t1.amountLink )as periodBorg
 from TabLink t1 
 join PaidPeriod t2 on t1.periodId = t2.periodId
 join MoneyType t3 on t1.moneyType = t3.codeI
