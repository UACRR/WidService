CREATE view [dbo].[vtsk_3_R_04] as 
with TmpItem as 
(select max(regId) as regId, count(*) as countItem,
sum(Case When isnull(objid,0) = 0 Then 1 Else 0 end) as countNoFound
from RegisterItem 
group by regId
)
select 
t4.custId, t5.name as custName , t3.periodId, t3.periodName, t3.licId, 
t1.regId, t1.createDate, 
isnull(t1.userId, 'dbo') as userWho, 
t10.countItem,  
t10.countNoFound, 
t7.codeI as cRightCode, 
t7.name as cRightName,
t1.rgStatus, 
t2.name as rgStatusName, 
t1.fileName,
t6.*
from paidPeriod t3 
join RegisterRatedList t0 on t0.periodId = t3.periodId 
join register t1 on t1.rmId = t0.rmId 
join RegisterStatus t2 on t1.rgStatus = t2.codeI 
join LicenseAgreement t4 on t3.licId = t4.licId
join vCustomer t5 on t5.custId = t1.custId
join AgrLicenseType t6 on t4.licCode = t6.codeI
join CopyrightKind t7 on t7.codeI = t6.kindCode
join UsesKind t8 on  t6.usesKind  = t8.codeI
join TmpItem t10 on t10.regId = t1.regId
where 
t8.usesType = 2