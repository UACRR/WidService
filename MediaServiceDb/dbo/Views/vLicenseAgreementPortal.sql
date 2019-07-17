
CREATE view [dbo].[vLicenseAgreementPortal] as 
--usesType = 1 -большие права, 2-малі права
select distinct t1.custId, 
      (Case When t3.usesType=1 Then t6.agrNumber Else t2.licNum end) as licNum, 
	  (Case When t3.usesType = 1 Then t6.agrDate Else t2.licDate end) as licDate, 
	  (Case When t3.usesType = 1 Then t6.dateBegin Else t2.dateBegin End) as dateBegin, 
	  (Case When t3.usesType = 1 Then t6.dateEnd Else t2.dateEnd End ) as dateEnd, 
	  t1.licCode, t3.licNmaeSh as licName, 
      t2.rateAmount, t2.minAmount, 
	  (Case When usesType = 1 Then t8.name Else t4.name End) as periodName, 
	  t2.isAutoprolog, 
	  (Case When t3.usesType = 1 Then t6.agrStatus Else t2.licStatus End) as licStatus, 
	  (Case When t3.usesType = 1 Then t7.name Else t5.name End) as licStatusName, 
	  t2.licId, t2.licVersion, t1.licVersion as licVersionMain, t3.usesType
 from LicenseAgreement t1 
  left join LicenseAgrParam t2 on t2.licId = t1.licId 
  join vAgrLicenseType t3 on t3.licCode = t1.licCode 
  left join period t4 on t4.codei = t2.periodCode
  left join AgreementStatus t5 on t5.codeI = isnull(t2.licStatus,0)
  left join AgreementAddBR t6 on t6.agrId = t1.agrId 
  left join AgreementStatus t7 on t7.codeI = t6.agrStatus
  left join period t8 on t8.codeI = t6.periodCode
  where isnull(licClass,0) in (0, 1) and t3.isPortal = 1