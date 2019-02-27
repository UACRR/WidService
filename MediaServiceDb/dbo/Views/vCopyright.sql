CREATE view [dbo].[vCopyright] as
select
   t2.categoryCode, 
   t2.objId,
   t2.name,
   t2.author,
   t2.performer,
   t1.cRightId,
   t1.custId,
   t3.name as clnName,
   t1.rate,
   t1.roleRate,
   t1.roleCode,
   t10.cRType,
   t4.name as roleName,
   t5.CRKindCode,
   COALESCE ( t6.rateCommiss, t8.rateCommiss, 0 ) as rateCommiss,
   COALESCE ( t6.rateCourt, t8.rateCourt, 0 ) as rateCourt,
   t7.cmCustId, 
   t1.status, 
   t11.name as statusName
from
   dbo.CopyRight t1
   INNER JOIN dbo.ObjectRight t2 on  t1.objId = t2.objId
   join CreativeRoleType t10 on t1.roleCode = t10.codeI 
   INNER JOIN dbo.vCustomer t3 on  t1.custId = t3.custId
   INNER JOIN dbo.CreativeRoleType t4 on  t1.roleCode = t4.codeI
   left join TermsOfService t5 on  t1.custid = t5.custId
   left join AgreementAddRH t6 on  t1.custId = t6.custId
   left join CustCmRight t7 on  t5.custId = t7.custId and t5.CRKindCode = t7.cRKindCode
   left join AgreementAddRH t8 on  t7.cmCustId = t8.custId
   join CRightStatus t11 on  t11.codeI = isnull(t1.status,0) 
   where getdate() between t1.beginDate and t1.endDate
/*union 
select
   t2.categoryCode, 
   t2.objId,
   t2.name,
   t2.author,
   t2.performer,
   NULL as cRightId,
   NULL as custId,
   NULL as clnName,
   NULL as rate,
   NULL as roleRate,
   NULL as roleCode,
   NULL as cRType,
   NULL as roleName,
   NULL as CRKindCode,
   NULL as rateCommiss,
   NULL as rateCourt,
   NULL as cmCustId, 
   NULL as status,   --как для copyright 
   NULL as statusName
from
   ObjectRight t2 
   left join ObjectStatus t3 on t2.status = t3.codeI
     where not exists (select 1 from CopyRight t1 where t2.objid = t1.objid)
*/
GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Используется для оплаты
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vCopyright';

