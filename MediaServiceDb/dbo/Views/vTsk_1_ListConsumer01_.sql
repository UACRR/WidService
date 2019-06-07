CREATE view [dbo].[vTsk_1_ListConsumer01_] as

with moneyInfo as (
select t2.custId, sum( amount - isnull(destribAmount,0) ) as undistribamount 
from vCustomerClient t1
join MoneyReceived t2 on t2.custId = t1.custId
WHERE isSR = 1
group by t2.custId
)
, 
licenseInfo as
(
select t2.custId
, max( t2.licStatus ) mainStatus
, sum( case when t2.licStatus = 2  and DATEDIFF(MONTH, getdate(), t2.dateEnd ) <= 2 then 1 else 0 end ) as cntExtraAgr 
, sum( case when t2.licStatus = 0 then 1 else 0 end ) as cntOnEditing
, sum( case when t2.licStatus = 2 then 1 else 0 end ) as cntActive
, sum( case when t2.licStatus = 1 then 1 else 0 end ) as cntOnAccepting
, sum( case when t2.licStatus = 8 then 1 else 0 end ) as cntBlocked
, sum( case when t2.licStatus in (0,2,1,8) then 1 else 0 end ) as cntSR
from vLicenseAgrParam t2 
WHERE t2.licStatus not in (9,10) and usesType = 2  --малі права
group by t2.custId
)
select t1.custId, t1.INNOKPO, t1.name, ISNULL( t4.cntSR, 0) as countAgree
, ISNULL( t2.undistribamount, 0 ) as undistribamount
, t4.mainStatus
, t4.cntActive
, t4.cntExtraAgr
, t4.cntOnEditing
, t4.cntOnAccepting
, t4.cntBlocked
from vCustomerClient t1
join licenseInfo t4 on t4.custId = t1.custId
left outer join moneyInfo t2 on t2.custId = t1.custId
--where t1.isSR = 1