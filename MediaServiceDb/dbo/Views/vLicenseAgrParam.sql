CREATE view [dbo].[vLicenseAgrParam] as 
--все договора с параметрами в т.ч. закрытые
select 
(case When t8.codeI = 1 Then 3 Else (Case When t8.codeI in (2,3,4) Then 2 else 1 end) end) as registerType,
t10.licStatus,  t1.licStatus as licStatusMain, 
t2.kindCode, t1.licCode, t2.name as licCodeName, 
t1.licId, t1.licType, t3.name as licTypeName, t1.custId, t4.name as clnName, t10.licNum, t10.licDate, t10.dateBegin, 
t10.dateEnd, t10.minAmount, t10.rateAmount, 
t10.isAutoprolog, t10.addRate, t10.indxInfl, t10.periodCode, t5.name as periodName, t10.dayForPay, t1.licClass, t1.agrId, 
t6.datePremiere, t6.fillingRate, t6.performNumb, t6.ticketPriceNC, t6.ticketPriceUSD, t6.isTour, t6.whereTour, 
t6.objId, t7.name as objName,
t2.usesKind, t8.name as usesKindName, t8.usesType, t9.name as usesTypeName, t10.licVersion, t1.licVersion as licVersionMain
--select *
from licenseAgreement t1 
join LicenseAgrParam t10 on t1.licId = t10.licId --and t1.licVersion = t10.licVersion
join AgrLicenseType t2 on t1.licCode = t2.codeI
left outer join LicenseType t3 on t1.licType = t3.codeI
join UsesKind t8 on t2.usesKind = t8.codeI 
join UsesType t9 on t8.usesType = t9.codeI
join vcustomer t4 on t1.custId = t4.custId
left join Period t5 on t10.periodCode = t5.codeI
left join LicenseBigR t6 on t1.licId = t6.licId 
left join ObjectRight t7 on t6.objId = t7.objId