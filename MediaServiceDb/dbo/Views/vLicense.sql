CREATE view [dbo].[vLicense] as
select t1.custId, t1.licId, t1.licCode, t2.name as licName,  
t8.licNum, t8.licDate, t8.dateBegin, t8.dateEnd, 
t8.minAmount, t8.rateAmount, isAutoprolog, addRate, indxInfl, 
periodCode, t6.name as pariodName, t1.licStatus, t8.dayForPay, 
t1.licType, t5.name as licTypeName, t7.clCustId, t1.licVersion
from LicenseAgreement t1 
join LicenseAgrParam t8 on t1.licId = t8.licId and t1.licVersion = t8.licVersion
join AgrLicenseType t2 on t1.licCode = t2.codeI 
join CopyrightKind t3 on t2.kindCode = t3.codeI 
join CRKindGroup t4 on t3.crGroupCode = t4.codeI
join LicenseType t5 on t1.licType = t5.codeI
join Period t6 on t8.periodCode = t6.codeI
left join partnerClient t7 on t1.custId = t7.clCustId