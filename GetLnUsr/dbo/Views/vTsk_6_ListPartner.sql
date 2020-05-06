CREATE VIEW [dbo].[vTsk_6_ListPartner] as
--к-ть клієнтів
with TmpClnCount as 
(
select t1.custId, count( distinct t1.clCustId ) as clnCount 
from PartnerClient t1
join AgreementMaster t2 on t1.custId = t2.custId and t2.agrStatus not in (4,10)
group by t1.custId
)
,
--кол-во договоров клиентов партнера
TmpAgrCount as 
(
select t1.custId, count(*) as agrCount, sum(Case WHEN t2.licStatus = 2 Then 1 Else 0 END ) as agrActive
from PartnerClient t1 
join LicenseAgreement t2 on t1.clCustId = t2.custId and t2.licStatus not in (4,10)
group by t1.custId
)

select t1.custId, t1.agrId,  t3.INNOKPO, t3.name, t1.agrNumber, t1.agrDate, t3.jaCity, t1.agrStatus, t4.name as statusName, 
t5.clnCount, 
--t6.agrCount, 
rtrim(convert(char(10),t6.agrCount))+'/'+rtrim(convert(char(10), t6.agrActive)) as agrCount, 
(Case isnull(t7.isMy,0) when 1 Then 'Так' Else 'Ні' end) as isMy
from agreementAddPartner t1 
join AgreementMaster t2 on t1.agrId = t2.agrId
join vCustomer t3 on t1.custId = t3.custId
left join AgreementStatus t4 on t1.agrStatus = t4.codeI
left join TmpClnCount t5 on t1.custId = t5.custId
left join TmpAgrCount t6 on t1.custId = t6.custId
join Partner t7 on t1.custId = t7.custId

