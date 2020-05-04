


--use MediaService
CREATE view [dbo].[vCustCmService] as 
with TmpCm as 
(
select 
t5.name as nameRH, t1.custId, t1.innerCode, t1.interCode, t1.rHolderType, t1.aroundWord, 
t2.CRKindCode, t2.ourService, 
isnull((Case When t2.ourService = 0 Then t4.cmCustId Else t9.custId end),-1) as cmCustId, 
isnull((Case When t2.ourService = 0 Then t6.name Else t9.name end), 'НЕ ВИЗНАЧЕНО') as cmName, 
t4.dateBegin, t4.dateEnd, 
t7.agrStatus as agrStatusRH, t8.agrStatus as agrStatusCM, t7.agrId as agrIdRH, t8.agrId as agrIdCM
from RightHolder t1 
left join TermsOfService t2 on t1.custId = t2.custId
left join CustCmRight t4 on t4.custId = t2.custId and t4.cRKindCode = t2.CRKindCode
join vCustomer t5 on t1.custId = t5.custId 
left join vCustomer t6 on t4.cmCustId = t6.custId
left join AgreementMaster t7 on t1.custId = t7.custId and t7.agrType not in (2,3) 
left join AgreementMaster t8 on t8.custId = t4.cmCustId
--left join vCustomer t9 on t9.ankMy = 1
left join vMyAnk t9 on t9.custId = t9.custId
/*
union 
select 'НЕВИЗНАЧЕНИЙ', -1, NULL, NULL, NULL, 1, t1.codei, 0, -1, 'НЕ ВИЗНАЧЕНО', '1900-01-01', '3000-01-01', 0, 0, NULL, NULL 
from CopyrightKind t1 
*/
)
select 
t1.nameRH, t1.custId, t1.innerCode, t1.interCode, t1.rHolderType, t1.aroundWord, 
t1.CRKindCode, t3.name as crKindName, t3.crGroupCode, t4.name as crGroupName, t1.ourService, 
cmCustId, 
cmName, 
t1.dateBegin, t1.dateEnd, 
t1.agrStatusRH, t1.agrStatusCM, t1.agrIdRH, t1.agrIdCM, 
t2.ankMy as isMy, t3.nameDescript
from TmpCm t1 
left join vCustomer t2 on t1.cmCustId = t2.custId
join CopyrightKind t3 on t1.CRKindCode = t3.codeI
join CRKindGroup t4 on t3.crGroupCode = t4.codeI
