CREATE view [vTsk_1_BRMoneyItem] as
 select t1.periodId, t1.periodName, t4.objid, t4.ItemName, t3.authAmount, 0 as flag
  from PaidPeriod t1 
  join RegisterRatedList t2 on t1.periodId = t2.periodId
  join Register t3 on t2.rmId = t3.rmId
  join RegisterItem t4 on t3.regId = t4.regId and t4.codeItem = 2
 