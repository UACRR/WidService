CREATE view [dbo].[vTsk_1_ListCommunity] as 
WITH TmpCount as 
(
select t0.cmCustId, count(*) as cnt from 
(
select cmCustId, custId 
from custCmRight t1  
where getdate() between isnull(dateBegin, '1900-01-01') and isnull(dateEnd, '3000-01-01')
group by cmCustId, custId
union 
--свои правообладатели
select t3.custId as cmCustId, COUNT(DISTINCT t2.custId) AS cnt
from RightHolder t1 
     join TermsOfService t2 on t1.custId = t2.custId and t2.ourService = 1
	 join vCustomer t3 on t3.custId = t3.custId and ankMy = 1
     join AgreementMaster t4 on t2.custId = t4.custId and t4.agrStatus = 2
group by t3.custId, t2.custId
)  t0 
group by t0.cmCustId
)
select t1.custId, t2. innerCode, t2.interCode, t3.name, t3.registrDate, t4.cnt as countAuthors, t5.agrStatus, t6.name as agrStatusName  
from community t1 
join RightHolder t2 on t1.custId = t2.custId
join vcustomer t3 on t2.custId = t3.custId 
join AgreementMaster t5 on t1.custId = t5.custId 
join AgreementStatus t6 on t5.agrStatus = t6.codeI
left join TmpCount t4 on t4.cmCustId = t1.custId