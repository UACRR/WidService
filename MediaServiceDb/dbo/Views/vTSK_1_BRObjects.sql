

CREATE view [dbo].[vTSK_1_BRObjects] as 
select t3.custId, t1.licId, t2.objId, t2.actCode, t2.name, 
t1.rate, t1.rateMusic, t2.categoryCode
 from LicenseBigR t1 
 join ObjectRight t2 on t1.objid = t2.objId
 join LicenseAgreement t3 on t3.licId = t1.licId