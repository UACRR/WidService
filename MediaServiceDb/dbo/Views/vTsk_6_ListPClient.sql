CREATE VIEW [dbo].[vTsk_6_ListPClient] as
--кол-во договоров клиентов партнера
WITH TmpAgrCount as 
(
select t1.custId, t1.clCustId, count(*) as agrCount 
from PartnerClient t1 
join LicenseAgreement t2 on t1.clCustId = t2.custId and t2.licStatus = 2
group by t1.custId, t1.clCustId
)
, 
--Заборгованість
TmpBorg as 
(
select  t1.custId, t1.clCustId, sum(undistribamount) as sumBorg
from PartnerClient t1 
 join PaidPeriod t2 on t1.clCustId = t2.custId
  group by t1.custId, t1.clCustId
)
select t7.custType, t8.name as custTypeName,  t1.custId, t1.clCustId, t7.INNOKPO, t7.name as clientName, 
isnull(t5.sumBorg,0) as sumBorg, t6.agrCount
from PartnerClient t1 
join vCustomer t3 on t1.custId = t3.custId
left join TmpBorg t5 on t1.custId = t5.custId and t1.clCustId = t5.clCustId
left join TmpAgrCount t6 on t1.custId = t6.custId and t1.clCustId = t6.clCustId
join vCustomer t7 on t1.clCustId = t7.custId
join CustomerType t8 on t7.custType = t8.codeI