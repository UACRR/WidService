

CREATE view [dbo].[vTsk_1_BRBidAuthors] as 
select 
t1.licId, t1.licVersion,
t1.custid, --Клиента
t4.cRightId, t5.name as roleName, t6.name as authorName, t7.innerCode, t7.interCode, 
t6.countryCode, t12.countryName, 
roleRate, 
t3.r030, t3.prepayType, t8.name as prepayTypeName, t3.prepaySum,  --сумма для театра
t9.workTypeRH, t10.name as workTypeRHName, t9.workCommentRH, 
t9.workTypeCl, t11.name as workTypeRHCl, t9.workCoommentCl
from LicenseAgreement t1 
join LicenseBigR t2 on t1.licId = t2.licId  
join CopyRight t4 on t2.objId = t4.objId and isnull(t4.endDate,'3000-01-01') >= getdate()
left join LicAuthorBR t3 on t3.cRightId = t4.cRightId
join CreativeRoleType t5 on t4.roleCode = t5.codeI
join vCustomer t6 on t4.custId = t6.custId
left join RightHolder t7 on t4.custId = t7.custId
left join PrePayType t8 on t3.prepayType = t8.codeI
left join WorkRH t9 on t4.cRightId = t9.cRightId 
left join WorkType t10 on t9.workTypeRH = t10.codeI
left join WorkType t11 on t9.workTypeRH = t11.codeI
left join Country t12 on t6.countryCode = t12.countryCode