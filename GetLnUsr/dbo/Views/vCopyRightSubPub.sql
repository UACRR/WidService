
CREATE view vCopyRightSubPub as 
with TabCR as 
(select t1.custId as custidSub, t2.custId as custIdPub, count(distinct t1.objid) as cntObj
 from copyright t1 
  join copyright t2 on isnull(t1.parentId, t1.crightId) = t2.crightId 
  join RelSubPublish t5 on t5.custIdSub = t1.custId 
  where getdate() between t1.beginDate and t1.endDate
 group by t1.custId, t2.custId  
)
select t1.custidSub, t2.name as custidSubName, t1.custIdPub, (CASE WHEN t1.custIdSUB = t1.custIdPub THEN '' ELSE t3.name END ) as custIdPubName, cntObj 
  from TabCr t1 
  join vCustomer t2 on t1.custidSub = t2.custId 
  join vCustomer t3 on t1.custIdPub = t3.custId 

--select * from vCopyRightSubPub
