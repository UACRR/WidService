
CREATE view [dbo].[vtsk_1_LicenseAgreementList] as
with mV as 
--WIN-форма отображения клиентов малых прав
(
select t1.licid, t1.licVersion, t1.licStatus from 
LicenseAgrParam t1, 
(select licId, max(licVersion) as version
 from LicenseAgrParam 
 where licStatus <> 4
 group by licId ) t2  
 where t1.licId = t2.licId and t1.licVersion = t2.version
),
pP as 
(
select licId, sum(amount) as amount, sum(distribAmount) as distribAmount, sum(undistribAmount) as undistribAmount
 from PaidPeriod
  where status <> 6 and 
  (isnull(amount,0) > isnull(distribAmount,0)+isnull(undistribAmount,0) or isnull(undistribAmount,0) <> 0)
  group by licId 
)
select 
t1.custId, 
max(t4.INNOKPO) as INNOKPO, 
max(t4.name) as name, 
sum (Case when t1.licStatus = 2 Then 1 Else 0 end) as countActive,      --к-ть діючих угод
sum (Case when (t5.licStatus in (0,1) or t1.licStatus in (0,1)) Then 1 Else 0 end) as countNoAccept,    --к-ть не акцептованих
sum(t6.undistribAmount) as undistribAmount, 
max((Case when t1.licStatus = 2 Then 1 Else 0 end)) as statusActive,
max((Case when t5.licStatus in (0,1) Then 1 Else 0 end)) as statusNoAccept,
max((Case when isnull(t3.dateEnd,'3000-01-01')<=dateadd(day, 60,getdate()) Then 1 Else 0 end)) as statusProlong,
max((Case when isnull(t6.amount,0) > isnull(t6.distribAmount,0)+isnull(t6.undistribAmount,0) Then 1 Else 0 end)) as statusUndistribute, 
max(t8.name) as partnerName
from LicenseAgreement t1 
join vAgrLicenseType t2 on t1.licCode = t2.licCode and t2.usesType in (2,3)
join LicenseAgrParam t3 on t1.licId = t3.licId and t1.licVersion = t3.licVersion and isnull(t3.licStatus,0) not in (9,10) --!26-02-2019
join vCustomer t4 on t1.custId = t4.custId
join mV t5 on t5.licId = t1.licId 
left join pP t6 on t6.licId = t1.licId
left join partnerClient t7 on t7.clCustId  = t1.custId 
left join vcustomer t8 on t8.custId = t7.CustId
group by t1.custId


--select * from  vtsk_1_LicenseAgreementList

