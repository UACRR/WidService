

/*==============================================================*/
/* View: vtsk_3_WRH_01                                          */
/*==============================================================*/
CREATE view [dbo].[vtsk_3_WRH_01] as
with CountObj as 
(
select custId, count(*)  as cntObj from 
 (select t2.custId, t3.objId
 from WorkRH t1 
  left join CopyRight t2 on t1.cRightId = t2.cRightId 
  left join ObjectRight t3 on t3.objId = t2.objId and isnull(t3.status,0) = 0
  group by t2.custId, t3.objId ) as CO
  group by custId
)
, 
RH as 
(select t2.custId
from WorkRH t1 
join CopyRight t2 on t1.cRightId = t2.cRightId 
group by t2.custId
)
select t3.custId, isnull(t4.innerCode, t3.custId) as innerCode, isnull(t4.interCode,'') as interCode, t3.name, t5.cntObj, t3.registrDate
from RH t1 
join vCustomer t3 on t3.custId = t1.custId 
join RightHolder t4 on t4.custId = t1.custId
join CountObj t5 on t1.custId = t5.custId
