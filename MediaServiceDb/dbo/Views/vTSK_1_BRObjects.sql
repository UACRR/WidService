

CREATE view [dbo].[vTSK_1_BRObjects] as 
select t3.custId, t1.licId, t2.objId, t2.actCode, t2.name + '   ('+rtrim(ltrim(convert(char(10),t2.objId)))+')'  as name, 
t1.rate, t1.rateMusic, t2.categoryCode, t3.licType
 from LicenseBigR t1 
 join ObjectRight t2 on t1.objid = t2.objId
 join LicenseAgreement t3 on t3.licId = t1.licId and t3.licStatus not in (8,4) 
 join LicenseAgrParam t4 on t3.licId = t4.licId and t3.licVersion = t4.licVersion