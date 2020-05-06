
CREATE view vCopyRightHistory as 
(
select t1.parentId, t1.childId, t2.custId as parentCustid, t3.custId as childCustId, t2.objid, 
   t4.name as parentName, t5.name as childName, t2.rate as patentRate, t1.rate as childRate
  from CopyRightHistory t1 
   join CopyRight t2 on t2.cRightId = t1.parentId 
   join CopyRight t3 on t3.cRightId = t1.childId
   join vCustomer t4 on t4.custId = t2.custId 
   join vCustomer t5 on t5.custId = t3.custid 
--where t2.custid = 3331 
)
