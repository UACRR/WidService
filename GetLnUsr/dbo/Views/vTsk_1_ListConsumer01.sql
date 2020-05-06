
CREATE view [dbo].[vTsk_1_ListConsumer01] as
--Для отображения списка клиентов
with moneyInfo as (
select t2.custId, sum( amount - isnull(destribAmount,0) ) as undistribamount 
from vCustomerClient t1
join MoneyReceived t2 on t2.custId = t1.custId
WHERE isSR = 1
group by t2.custId
)
, 
infoCount as 
(select t1.custId
 , count(*) as cntSR
 , sum( case when t1.licStatus = 2  and DATEDIFF(MONTH, getdate(), t1.dateEnd ) <= 2 then 1 else 0 end ) as cntExtraAgr --для пролонгации
 , sum( case when t1.licStatus = 2 then 1 else 0 end ) as cntActive
 , sum( case when t1.licStatus = 8 then 1 else 0 end ) as cntBlocked
  from vLicenseAgreement t1
  where t1.licStatus not in (9,10,4) 
     and usesType in ( 2,3) --SR
  group by custId
), 
licenseInfo as
(
select t2.custId
, max( t2.licStatus ) mainStatus
--, sum( case when t2.licStatusMain = 2  and DATEDIFF(MONTH, getdate(), t2.dateEnd ) <= 2 then 1 else 0 end ) as cntExtraAgr --для пролонгации
, sum( case when t2.licStatus = 0 then 1 else 0 end ) as cntOnEditing
, sum( case when t2.licStatus = 1 then 1 else 0 end ) as cntOnAccepting
from vLicenseAgrParam t2 
WHERE t2.licStatus not in (9,10) and usesType in (2,3)  --малі права
	 and t2.licVersion>=t2.licVersionMain
group by t2.custId
)
select t1.custId, t1.INNOKPO, t1.name
--, ISNULL( t3.cntSR, 0) as countAgree
, isnull(t3.cntActive,0)+ isnull(t4.cntOnEditing,0) + isnull(t4.cntOnAccepting,0) + isnull(t3.cntBlocked,0) as countAgree
, ISNULL( t2.undistribamount, 0 ) as undistribamount
, t4.mainStatus --нужно убрать, он ни о чем
, t3.cntActive
, t3.cntExtraAgr
, t4.cntOnEditing
, t4.cntOnAccepting
, t3.cntBlocked
from vCustomerClient t1
join licenseInfo t4 on t4.custId = t1.custId
join infoCount t3 on t3.custId = t1.custId
left join moneyInfo t2 on t2.custId = t1.custId
--where t1.isSR = 1
