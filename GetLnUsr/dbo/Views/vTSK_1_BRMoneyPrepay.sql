CREATE view [dbo].[vTSK_1_BRMoneyPrepay] as
select t2.custId, t2.agrId, 
t2.licId, t4.licNum, t4.licDate, 
t3.objid, t5.name as objName, t8.name as roleName, t7.name as authorName, isnull(t1.prepaySumAuthor,0) as prepaySum, 
isnull(prepayUsed,0) as prepayUsed, isnull(t1.prepaySumAuthor,0) - isnull(t1.prepayUsed,0) as prepayRest
from licAuthorBr t1 
join CopyRight t6 on t1.cRightId = t6.cRightId
join LicenseBigR t3 on t6.objId = t3.objId 
-- and t3.licVersion = t2.licVersion
join LicenseAgreement t2 on t3.licId = t2.licId and t2.licType = 1
join LicenseAgrParam t4 on t4.licId = t2.licId and t4.licVersion = t2.licVersion
join ObjectRight t5 on t5.objid = t3.objId
join vCustomer t7 on t6.custId = t7.custId 
join CreativeRoleType t8 on t6.roleCode = t8.codeI 
where t1.prepayType = 2

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Розподіл коштів Аванси - BigRight', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vTSK_1_BRMoneyPrepay';

