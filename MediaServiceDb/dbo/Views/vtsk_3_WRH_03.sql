

CREATE view [dbo].[vtsk_3_WRH_03] as
with CountObj as 
(
select custId, count(*) as cntObj, max(workDateRH) as workDateRH  
from 
 (select t1.custId, t1.objId, max(t3.workDateRH) as workDateRH
 from CopyRight  t1 
  left join WorkRH t3 on t1.cRightId = t3.cRightId 
 where isnull(t1.status,0) = 0
  group by t1.custId, t1.objId ) as CO
  group by custId
)
,
RH as 
(select t2.custId
from WorkRH t1 
join CopyRight t2 on t1.cRightId = t2.cRightId
--join objectRight t3 on t2.objid = t3.objid and t3.categoryCode = 5
group by t2.custId
)
select t3.custId, isnull(t4.innerCode, t3.custId) as innerCode, isnull(t4.interCode,'') as interCode, t3.name, t5.cntObj, t3.registrDate, 
t5.workDateRH
from RightHolder t4
join vCustomer t3  on t3.custId = t4.custId
join CountObj t5 on t5.custId = t4.custId
left join RH t1 on t1.custId = t4.custId