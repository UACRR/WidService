CREATE view [dbo].[vTsk_1_BRBidAuthors] as 
--объекты ВП
with TabObject as 
(
select t2.objid, t2.licId, t1.licVersion, t1.custId
from LicenseAgreement t1 
join LicenseBigR t2 on t1.licId = t2.licId  
),
--автори та правовласники
TabCRight as 
(
select t1.objid, t1.cRightId, t1.custId, t2.name as rhName, t1.roleCode, roleRate
from CopyRight t1 
join vCustomer t2 on t1.custId = t2.custId
where isnull(t1.endDate,'3000-01-01') >= getdate()
union 
select  t1.objId, NULL as cRight, t1.custId, t1.authorName, t1.roleCode, 0 as rate
from Authors t1 where not exists (select  1 from CopyRight t2 where t1.objId = t2.objId and t1.custId = t2.custId)
)
select 
t1.licId, t1.licVersion,
t1.custid, --Клиента
isnull(t4.cRightId,0) as cRightId, t5.name as roleName, 
t4.rhName + (Case isnull(t4.custId,0) when 0 then ' (б/а)'  else '' end ) as authorName, 
t7.innerCode, t7.interCode, 
t6.countryCode, t12.countryName, 
roleRate, 
t3.r030, t3.prepayType, t8.name as prepayTypeName, t3.prepaySum,  --сумма для театра
t9.workTypeRH, t10.name as workTypeRHName, t9.workCommentRH, 
t9.workTypeCl, t11.name as workTypeRHCl, t9.workCoommentCl,
t4.objId
from TabObject t1 
join TabCRight t4 on t1.objId = t4.objId 
left join LicAuthorBR t3 on t3.cRightId = t4.cRightId
left join CreativeRoleType t5 on t4.roleCode = t5.codeI
left join vCustomer t6 on t4.custId = t6.custId
left join RightHolder t7 on t4.custId = t7.custId
left join PrePayType t8 on t3.prepayType = t8.codeI
left join WorkRH t9 on t4.cRightId = t9.cRightId 
left join WorkType t10 on t9.workTypeRH = t10.codeI
left join WorkType t11 on t9.workTypeRH = t11.codeI
left join Country t12 on t6.countryCode = t12.countryCode