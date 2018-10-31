


CREATE function [dbo].[ft_ObjectRightCustomerForm01] (@objId int)
RETURNS Table
as
RETURN
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
select t1.custId, custType, t1.name, isClient, isRHolder, isPartner, t3.community_name, t3.innerCode, t3.interCode, t4.countryNameShort as country from 
vCustomer t1
join vTsk_1_ListRightHolder01 t3 on t3.custId = t1.custId
join listCustId t2 on t2.custId = t1.custId
left join Country t4 on t4.countryCode = t1.countryCode

)