create view vRateCommiss as 
 (select distinct rateCommiss from AgreementAddRH where isnull(rateCommiss,0)<>0)

GO
GRANT SELECT
    ON OBJECT::[dbo].[vRateCommiss] TO [ReportUser]
    AS [dbo];

