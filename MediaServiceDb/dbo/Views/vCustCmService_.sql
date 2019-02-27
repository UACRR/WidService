--use MediaService
CREATE view [dbo].[vCustCmService_] as 
--Для замены vCustCmService как долго работающей
--Нужно протестировать на отчетности
select 
t5.name as nameRH, t1.custId, t1.innerCode, t1.interCode, t1.rHolderType, t1.aroundWord, 
t2.CRKindCode, t10.name as crKindName,t10.crGroupCode, t11.name as crGroupName, 
t2.ourService, 
isnull((Case When t2.ourService = 0 Then t4.cmCustId Else t9.custId end),-1) as cmCustId, 
isnull((Case When t2.ourService = 0 Then t6.name Else t9.name end), 'НЕ ВИЗНАЧЕНО') as cmName, 
t4.dateBegin, t4.dateEnd, 
t7.agrStatus as agrStatusRH, t8.agrStatus as agrStatusCM, t7.agrId as agrIdRH, t8.agrId as agrIdCM, 
isnull(t2.ourService,0) as isMy, t10.nameDescript
from RightHolder t1 
left join TermsOfService t2 on t2.custId = t1.custId
left join CustCmRight t4 on t4.custId = t2.custId and t4.cRKindCode = t2.CRKindCode
join vCustomer t5 on t5.custId = t1.custId 
left join vCustomer t6 on t6.custId = t4.cmCustId 
left join AgreementMaster t7 on t7.custId = t1.custId and t7.agrType not in (2,3) 
left join AgreementMaster t8 on t8.custId = t4.cmCustId
left join vMyAnk t9 on t9.custId = t9.custId
join CopyrightKind t10 on t10.codeI = t2.crKindCode 
join CRKindGroup t11 on t11.codeI = t10.crGroupCode
/*
union 
--для связи в отчетах
select 
'НЕ ВИЗНАЧЕНИЙ' as nameRH, -1, NULL as innerCode, NULL as interCode, NULL as rHolderType, NULL as aroundWord, 
t1.codeI, t1.name as crKindName,t1.crGroupCode, t2.name as crGroupName, 
0 as ourService, -1 as cmCustId, 'НЕ ВИЗНАЧЕНО' as cmName, '1900-01-01' dateBegin, '3000-01-01' as dateEnd, 
0 as agrStatusRH, 0 as agrStatusCM, NULL as agrIdRH, NULL as agrIdCM, 
0 as isMy, t1.nameDescript
 from CopyrightKind t1 
   join CRKindGroup t2 on t2.codeI = t1.crGroupCode
*/