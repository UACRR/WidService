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
   left join agreementMaster t60 on t6.custId = t60.custid 
   left join CustCmRight t7 on  t5.custId = t7.custId and t5.CRKindCode = t7.cRKindCode  and cast(getdate() as date) between t7.dateBegin and t7.dateEnd 
   left join AgreementAddCommunity t8 on  t7.cmCustId = t8.custId
   join CRightStatus t11 on  t11.codeI = isnull(t1.status,0) 
   where cast(getdate() as date) between isnull(t1.beginDate,'1900-01-01') and isnull(t1.endDate,'3000-01-01')
      and isnull(t60.agrStatus,0) not in (7,8)

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Используется для оплаты
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vCopyright';

