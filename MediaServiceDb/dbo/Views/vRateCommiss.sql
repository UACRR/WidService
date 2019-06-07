create view vRateCommiss as 
 (select distinct rateCommiss from AgreementAddRH where isnull(rateCommiss,0)<>0)