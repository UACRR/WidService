create view vCustCmService as 
select 
t5.name as nameRH, t1.custId, t1.innerCode, t1.interCode, t1.rHolderType, t1.aroundWord, 
t2.CRKindCode, t2.ourService, t4.cmCustId, t6.name as cmName, t4.dateBegin, t4.dateEnd, 
t7.agrStatus as agrStatusRH, t8.agrStatus as agrStatusCM, t7.agrId as agrIdRH, t8.agrId as agrIdCM 
from RightHolder t1 
left join TermsOfService t2 on t1.custId = t2.custId
left join CustCmRight t4 on t4.custId = t2.custId and t4.cRKindCode = t2.CRKindCode
join vCustomer t5 on t1.custId = t5.custId 
left join vCustomer t6 on t4.cmCustId = t6.custId
left join AgreementMaster t7 on t1.custId = t7.custId and t7.agrType not in (2,3) 
left join AgreementMaster t8 on t8.custId = t4.cmCustId