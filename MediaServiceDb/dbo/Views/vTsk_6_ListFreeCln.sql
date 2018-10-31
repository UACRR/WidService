
create VIEW [dbo].[vTsk_6_ListFreeCln] as
with TmpClnFree as 
(
select custId as clCustId from Client t1 
  where not exists (select 1 from PartnerClient t2 where t1.custId = t2.clCustId)
)
select max(t3.INNOKPO) as INNOKPO, max(t3.name) as clientName, t1.clCustId, count(*) as agrCount, max(jaRegion) as jaRegion, max(t4.name) as regionName, max(t3.jacity) as jacity
from TmpClnFree t1 
left join LicenseAgreement t2 on t1.clCustId = t2.custId and t2.licStatus = 2
join vCustomer t3 on t1.clCustId = t3.custId 
join Region t4 on t3.jaRegion = t4.codeI
group by t1.clCustId