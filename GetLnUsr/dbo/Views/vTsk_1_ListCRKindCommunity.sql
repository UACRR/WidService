CREATE view vTsk_1_ListCRKindCommunity
as 
with myAnk as 
(
select custId as mycustId, myName from dbo.ft_PrtmyAnk (NULL) 
)
select t2.custId, t5.name as custName, t1.codeI, t1.name, t2.ourService, 
(Case t2.ourService When 1 Then t8.mycustId else t3.cmCustId  end) as cmCustId, 
(Case t2.ourService When 1 Then t8.myName else t4.name  end) as communityName  
from CopyrightKind t1 
left join TermsOfService t2 on t1.codeI = t2.CRKindCode --and t2.ourService = 1 
left join CustCmRight t3 on t2.CRKindCode = t3.cRKindCode and t2.ourService = 0
left join vCustomer t4 on t4.custId = t3.cmCustId
join vCustomer t5 on t2.custId = t5.custId 
FULL OUTER JOIN myAnk t8 on isnull(t3.cmCustId,t8.mycustId)  = t8.mycustId
