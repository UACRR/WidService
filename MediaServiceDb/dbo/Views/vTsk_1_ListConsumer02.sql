/*==============================================================*/
/* View: vTsk_1_ListConsumer01                                  */
/*==============================================================*/
CREATE view [dbo].[vTsk_1_ListConsumer02] as

with moneyInfo as (
select t1.custId, sum( amount - isnull(destribAmount,0) ) as undistribamount 
from vCustomer t1
join MoneyReceived t2 on t2.custId = t1.custId
WHERE isClient = 1
group by t1.custId
)
, agreeInfo as
(
select t2.custId
, sum( case when t5.usesType = 2 then 1 else 0 end ) as cntSR 
, sum( case when t5.usesType = 1 and t3.licClass = 2 then 1 else 0 end ) as cntBR 
--from vCustomer t1
--join AgreementMaster t2 on t2.custId = t1.custId and t2.agrStatus between 0 and 4 and t2.agrType = 2
from AgreementMaster t2
join LicenseAgreement t3 on t3.agrId = t2.agrId
join AgrLicenseType t4 on t4.codeI = t3.licCode
join UsesKind t5 on t5.codeI = t4.usesKind
WHERE --isClient = 1 
   t2.agrStatus between 0 and 4 and t2.agrType = 2
group by t2.custId
), licenseInfo
as
(
select t2.custId
, max( t2.licStatus ) mainStatus
, sum( case when t2.licVersion = t3.licVersion and t3.licStatus = 2 and getdate() > t3.dateEnd and DATEDIFF(MONTH, getdate(), t3.dateEnd ) <= 2 then 1 else 0 end ) as cntExtraAgr 
, sum( case when t3.licStatus = 0 then 1 else 0 end ) as cntOnEditing
, sum( case when t3.licStatus = 2 then 1 else 0 end ) as cntActive
, sum( case when t3.licStatus = 1 then 1 else 0 end ) as cntOnAccepting
, sum( case when t3.licStatus = 3 then 1 else 0 end ) as cntBlocked
--from vCustomer t1
--join LicenseAgreement t2 on t2.custId = t1.custId
from LicenseAgreement t2
join AgrLicenseType t4 on t2.licCode = t4.codeI and t4.usesKind = 1
left outer join LicenseAgrParam t3 on t3.licId = t2.licId and t3.licVersion >= t2.licVersion
--WHERE isClient = 1
group by t2.custId

)
select t1.custId, t1.INNOKPO, t1.name, ISNULL( t3.cntBR, 0) as countAgree
, ISNULL( t2.undistribamount, 0 ) as undistribamount
, t4.mainStatus
, t4.cntActive
, t4.cntExtraAgr
, t4.cntOnEditing
, t4.cntOnAccepting
, t4.cntBlocked
from vCustomer t1
left join agreeInfo t3 on t3.custId = t1.custId and t3.cntBR > 0
join licenseInfo t4 on t4.custId = t1.custId
left outer join moneyInfo t2 on t2.custId = t1.custId
where isClient = 1