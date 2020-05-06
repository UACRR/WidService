
create view [dbo].[vTsk_1_BRNotice] as
select t1.licType, t13.name as licTypeName, 
t1.custId, t4.name, t1.agrId, 
t6.licId, t6.licVersion, t6.licNum, t6.licDate, t6.dateBegin as licDateBegin, t6.dateEnd as licDateEnd, t6.licStatus, t7.name as licStatusName, 
t8.objid, t9.name as objName, t9.status as objStatus, t9.genreType, t11.name as genreName
, t12.rate as genreRate72, t8.rate
,t8.datePremiere, t8.fillingRate, t8.performNumb, t8.ticketPriceNC, t8.ticketPriceUSD, t8.isTour, t8.whereTour,
t6.comment
 from 
  LicenseBigR t8 
  join LicenseAgreement t1 on t1.licId = t8.licId 
  join vcustomer t4 on t4.custId = t1.custId 
  join LicenseAgrParam t6 on t6.licId = t1.licId and t6.licVersion = t1.licVersion 
  join agreementStatus t7 on t6.licStatus = t7.codeI
  join ObjectRight t9 on t8.objId = t9.objId
  join GenreType t11 on t9.genreType = t11.codeI
  join RelGenrePercent t12 on t9.genreType = t12.genreType and t9.actCode = t12.actCode
  join licenseType t13 on t1.licType = t13.codeI
  where t1.licClass = 2 and t1.licType = 3
