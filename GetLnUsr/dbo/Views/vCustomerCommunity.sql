
CREATE view [dbo].[vCustomerCommunity] as
select t1.custId, t4.shortName as name, t1.innerCode, t1.interCode, 2 as rHolderType, t3.rateCommiss, t3.rateCourt, NULL as isSR, NULL as isBR, 1 as isCm,
  t3.agrDate, t3.dateBeginMEC, t3.dateEndMEC, t3.dateBeginPER, t3.dateEndPER, t3.agrStatus, t4.jaCountry as country   --2020-01-20
 from Community t1 
  left join AgreementMaster t2 on t2.custId = t1.custId 
  left join AgreementAddCommunity t3 on t3.agrId = t2.agrId and t3.version = t2.version
  join AnketaCompany t4 on t4.custid = t2.custId
  union 
 select  -1, 'НЕ ВИЗНАЧЕНО', '999', '999', 2, 0,0, NULL as isSR, NULL as isBR, 1 as isCm, 
    NULL as agrDate, NULL as dateBeginMEC, NULL as dateEndMEC, NULL as dateBeginPER, NULL as dateEndPER, NULL as agrStatus, NULL as country
