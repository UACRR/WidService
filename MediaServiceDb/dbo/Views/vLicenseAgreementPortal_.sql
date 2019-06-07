CREATE view [dbo].[vLicenseAgreementPortal_] as 
with TabAgr as 
(
--Малі права
select t1.custId, t2.licNum, t2.licDate, t2.dateBegin, t2.dateEnd, t1.licCode, 
      t2.rateAmount, t2.minAmount, t2.isAutoprolog, t2.periodCode,  t2.licStatus, t2.licId, t2.licVersion, t1.licVersion as licVersionMain, 0 as agrId, 0 as agrVersion
  from LicenseAgreement t1 
   join LicenseAgrParam t2 on t2.licId = t1.licId 
   --join vAgrLicenseType t3 on 
   where --t2.licStatus not in (10,4) and 
   isnull(licClass,0) = 0 
union 
--Большие права
select  t6.custId, t7.agrNumber, t7.agrDate, t7.dateBegin, t7.dateEnd, t8.licCode, 
  0 as rateAmount, 0 as minAmount, 0 as isAutoprolog, t7.periodCode, t7.agrStatus, 
  t8.licId, t8.licVersion, t8.licVersion as licVersionMain, t6.agrId, t6.version as agrVersion
  from AgreementMaster t6 
   join AgreementAddBR t7 on t7.agrId = t6.agrId 
   join LicenseAgreement t8 on t8.agrId = t7.agrId and t8.licClass = 1
   --where t7.agrStatus not in (10,4)
) 
select t1.custId, t1.licNum, t1.licDate, t1.dateBegin, t1.dateEnd, t1.licCode, t3.licNmaeSh as licName, 
      t1.rateAmount, t1.minAmount, t4.name as periodName, t1.isAutoprolog, t1.licStatus, t5.name as licStatusName, 
	  t1.licId, t1.licVersion, t1.licVersion as licVersionMain--, t1.agrId, t1.agrVersion, t3.usesType
 from TabAgr t1 
     join vAgrLicenseType t3 on t3.licCode = t1.licCode 
     left join period t4 on t4.codei = t1.periodCode
     left join AgreementStatus t5 on t5.codeI = isnull(t1.licStatus,0)