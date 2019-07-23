
CREATE view  [dbo].[vTsk_1_BRAuthorsDistributed]
as
with TabAvanse as --Сплачено за рахунок авансів
(select  t4.cRightId, max(isnull(t4.prepaySumAuthor,0)) as prepaySumAuthor, sum(isnull(t1.prepaySum,0)) as avanseUsed
  from LicAuthorBR t4 
  join CopyRight t3 on t3.cRightId = t4.cRightId
  left join RegisterCount t1  on t1.objId = t3.objId and t1.custId = t3.custId
  left join RegisterItem t2 on t1.regId = t2.regId and t1.regIItemId = t2.regIItemId
group by t4.cRightId
),
TabPay as 
(select t1.regId, t1.objid, t2.custIdRh as custId, sum(t2.amount) as amount
 from RegisterCount t1 
 join PayTurn t2 on t1.regId = t2.regId and t1.custId = t2.custIdRh and t2.accDebet like '21%' and t2.accCredit like '30%'   --распределение
 join Account t3 on t3.accId = t2.accIdDebet 
group by t1.regId, t1.objid, t2.custIdRh
)
select distinct t1.rmId, t1.regId, t2.objId, t2.itemName, t2.countUse,
t1.regAmount, t3.actCode, t1.authRate, t1.authAmount, 
isnull(t5.prepaySumAuthor,0) as prepaySumAuthor, 
isnull(t5.prepaySumAuthor,0) - isnull(t5.avanseUsed,0) as avanseRest,  
t4.custId,
t6.name as roleName, t7.name as nameRh, 
t4.roleRate, isnull(t8.amount,0) as AmountDistributed, isnull(t5.avanseUsed,0) as avanseUsed, 
t1.musicRate, t1.musicAmount
from 
Register t1 
join RegisterItem t2 on t1.regId = t2.regId and t2.codeItem = 2
join ObjectRight t3 on t3.objid = t2.objid 
join CopyRight t4 on t4.objId = t3.objId
left join TabAvanse t5 on t5.cRightId = t4.cRightId
join CreativeRoleType t6 on t4.roleCode = t6.codeI 
join vCustomer t7 on t4.custId = t7.custId 
left join TabPay t8 on t8.regId = t1.regId and t8.objId = t4.objId and t8.custId = t4.custId 
--order by t1.regId