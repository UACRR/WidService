
CREATE view [dbo].[vTSK_1_BRMaster] as 
  select t1.agrid, t1.version, t2.custId, t4.name as custName, t4.shortName, t5.clientGroup, t5.clientBrand, 
     t1.agrDate, t1.agrNumber,t1.dateBegin, t1.dateEnd, t1.agrStatus, 
     t3.name as statusName, t6.licId
    from  AgreementAddBR t1 
     join AgreementMaster t2 on t1.agrId = t2.agrId and t1.version = t2.version
     join AgreementStatus t3 on t1.agrStatus = t3.codeI 
	 join AnketaCompany t4 on t2.custId = t4.custId and t1.ankVersion = t4.version
	 join client t5 on t5.custId = t4.custId 
	 join LicenseAgreement t6 on t6.agrId = t2.agrId and isnull(t6.licClass,0) = 1