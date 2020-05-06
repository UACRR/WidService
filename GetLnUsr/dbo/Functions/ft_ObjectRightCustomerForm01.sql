
CREATE function [dbo].[ft_ObjectRightCustomerForm01] (@objId int)
RETURNS Table
as
RETURN
--25-06-2019 убрали community
(
with listCustId as
(
select distinct custId from ObjectRight t1
join CopyRight t2 on t2.objId = t1.objId
where t1.objId = @objId
union
select distinct custId from ObjectRight t1
join Authors t2 on t2.objId = t1.objId and t2.custId is not null
where t1.objId = @objId
)
select t2.custId, t1.custType, t1.name, t1.isClient, t1.isRHolder, t1.isPartner, t3.innerCode, t3.interCode, t4.countryNameShort as country 
from 
listCustId t2
join vTsk_1_ListRightHolder01 t3 on t3.custId = t2.custId
join vCustomer t1  on t1.custId = t2.custId
left join Country t4 on t4.countryCode = t1.countryCode

)
--select * from ft_ObjectRightCustomerForm01 (7111)
