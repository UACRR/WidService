
CREATE view [dbo].[vRegister] as 
select t3.custId, 
t1.regId, t1.fileName, t1.createDate,  t1.rgStatus,  t1.authAmount, t1.authRate, t1.musicAmount,t1.regAmount, t1.regRate, 
t2.periodId, t1.rmId, t2.status as rlistStatus, t2.royalty, 
t3.periodName, t3.beginDate, t3.endDate,
t3.amount, t3.distribamount, t3.undistribamount, t3.status as periodStatus, 
t4.licId, t4.licCode, t4.licCodeName, t4.licNum, t4.licDate, t4.usesType, t4.usesTypeName
from Register t1 
join RegisterRatedList t2 on t2.rmId = t1.rmId
join PaidPeriod t3 on t3.periodId = t2.periodId 
join vLicenseAgreement t4 on t4.licId = t3.licId