CREATE view [dbo].[vPartner] as
select t1.custId, t1.clCustId, t2.agrId, t2.srFirstRate, t2.srMonthRate, t2.pfFirstRate, t2.pfMonthRate, t2.courtRate, t2.courtCompRate, 
t2.agrDate, t2.agrNumber, t3.agrStatus
from partnerclient t1 
join AgreementAddPartner t2 on t1.custId = t2.custId
join AgreementMaster t3 on t2.custId = t3.custId and t3.version = t2.version