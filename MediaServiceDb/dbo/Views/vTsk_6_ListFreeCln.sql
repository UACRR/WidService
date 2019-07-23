CREATE VIEW [dbo].[vTsk_6_ListFreeCln] as
with TmpClnFree as 
(
select custId as clCustId from Client t1 
  where not exists (select 1 from PartnerClient t2 where t1.custId = t2.clCustId)
), 
TmpAgrCnt as 
(select t1.custId, sum(Case When isnull(licClass,0) in (0,2) Then 1 Else 0  END) as agrCount 
  from LicenseAgreement t1 
   join TmpClnFree t2 on t2.clCustId = t1.custId
  where t1.licStatus not in (4,10)
  group by t1.custId
)
select 
max(t3.INNOKPO) as INNOKPO, max(t3.name) as clientName, t1.clCustId, 
--count(*) as agrCount, 
max(agrCount) as agrCount, 
max(jaRegion) as jaRegion, max(t4.name) as regionName, max(t3.jacity) as jacity
from TmpClnFree t1 
join LicenseAgreement t2 on t1.clCustId = t2.custId and t2.licStatus not in (4,10) 
join vCustomer t3 on t1.clCustId = t3.custId 
join Region t4 on t3.jaRegion = t4.codeI
join TmpAgrCnt t5 on t5.custId = t1.clCustId
group by t1.clCustId