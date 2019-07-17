CREATE VIEW [dbo].[vTsk_6_ListPClient] as
--кол-во договоров клиентов партнера
--01-07-2019 - vBorg
--psm 04-07-2019
WITH TmpAgrCount as 
(
select t1.custId, t1.clCustId, 
 count(*) as agrCount, 
 sum(Case WHEN t2.licStatus = 2 Then 1 Else 0 END ) as agrActive
from PartnerClient t1 
join LicenseAgreement t2 on t1.clCustId = t2.custId and t2.licStatus not in (4,10)
group by t1.custId, t1.clCustId
)
select t7.custType, t8.name as custTypeName,  t1.custId, t1.clCustId, t7.INNOKPO, t7.name as clientName, 
--isnull(t5.sumBorg,0) as sumBorg, 
--t5.amountBorg as sumBorg, --psm 04-07-2019
isnull(t5.amountBorg, 0) as sumBorg, 
 rtrim(convert(char(10),t6.agrCount))+'/'+rtrim(convert(char(10), t6.agrActive)) as agrCount
from PartnerClient t1 
join vCustomer t3 on t1.custId = t3.custId
left join vBORG t5 on t5.custId = t1.clCustId --and t1.clCustId = t5.clCustId
left join TmpAgrCount t6 on t1.custId = t6.custId and t1.clCustId = t6.clCustId
join vCustomer t7 on t1.clCustId = t7.custId
join CustomerType t8 on t7.custType = t8.codeI