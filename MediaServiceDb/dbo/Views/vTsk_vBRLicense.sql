
/*==============================================================*/
/* View: vTsk_vBRLicense                                        */
/*==============================================================*/
CREATE view [dbo].[vTsk_vBRLicense] as
with tabAuthorBr as 
(
select  br.licid,
min(r030) as r030, 
sum((Case when prepayType = 1 Then (isnull(t1.prepaySum,0)) else 0 end)) as prepayPaush,
sum((Case when prepayType = 2 Then (isnull(t1.prepaySum,0)) else 0 end)) as prepayAvans, 
sum(isnull(t1.prepayRest,0)) as prepayRest
from LicAuthorBR t1 
join CopyRight cr on cr.cRightId = t1.cRightId
join LicenseBigR br on br.objId = cr.objId
group by br.licId
),
tabAuthors as 
(
select  br2.licid, 
Authors = STUFF((select ','+cm1.name 
  from vCustomer cm1 
   join CopyRight cr1 on cr1.custId = cm1.custId
   join LicenseBigR br1 on br1.objId = cr1.objId and br2.licId = br1.licId
   where cm1.custId = cr1.custId FOR XML PATH ('')),1,1,'')
from 
CopyRight cr2 
join LicenseBigR br2 on br2.objId = cr2.objId 
group by br2.licId
)
--,
--select * from RegisterStatus
--select * from registerItem--ItemStatus
/*
tabBorg as 
(select t1.licId, sum(t1.rAmount) as rAmount
  from RegisterItem t1 
  join Register t2 on t1.regId = t2.regId 
 where t2.rgStatus not in (0,3,4)  --and isnull(t1.status,0) = 1
 group by t1.licid
)
*/
select t1.licType, t13.name as licTypeName, 
t1.custId, t4.name, t1.agrId, t3.agrNumber, t3.agrDate, t3.dateBegin, t3.dateEnd, t3.agrStatus, t5.name as agrStatusName, --gen
t6.licId, t6.licVersion, t6.licNum, t6.licDate, t6.dateBegin as licDateBegin, t6.dateEnd as licDateEnd, t6.licStatus, t7.name as licStatusName, 
t8.objid, t9.name as objName, t9.status as objStatus, t9.genreType, t11.name as genreName
, t12.rate as genreRate72, t8.rate
--,t15.rAmount as borg, 
, NULL as borg,  --неможливо підрахувати
t14.r030, t14.prepayPaush, t14.prepayAvans, t14.prepayRest
,t8.datePremiere, t8.fillingRate, t8.performNumb, t8.ticketPriceNC, t8.ticketPriceUSD, t8.isTour, t8.whereTour,
(Case when getdate() <= dateadd(day,60, t6.dateEnd) Then 'Так' Else 'Ні' end) as toProlong,
t6.comment, 
t16.authors
 from LicenseAgreement t1 
  join AgreementMaster t2 on t1.agrId = t2.agrId 
  join AgreementAddBr t3 on t2.agrId = t3.agrId and t2.version = t3.version 
  join vcustomer t4 on t4.custId = t1.custId 
  join agreementStatus t5 on t2.agrStatus = t5.codeI
  join LicenseAgrParam t6 on t6.licId = t1.licId and t6.licVersion = t1.licVersion 
  join agreementStatus t7 on t6.licStatus = t7.codeI
  join LicenseBigR t8 on t1.licId = t8.licId 
  join ObjectRight t9 on t8.objId = t9.objId
  join GenreType t11 on t9.genreType = t11.codeI
  join RelGenrePercent t12 on t9.genreType = t12.genreType and t9.actCode = t12.actCode
  join licenseType t13 on t1.licType = t13.codeI
  left join tabAuthorBr t14 on t14.licId = t6.licId 
  --left join tabBorg t15 on t1.licId = t15.licId 
  left join tabAuthors t16 on t1.licId = t16.licId
  where t1.licClass = 2 and t1.licType = 1
GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'vBRLicense - Список лицензий для больших Прав', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vTsk_vBRLicense';


GO
GRANT SELECT
    ON OBJECT::[dbo].[vTsk_vBRLicense] TO [ReportUser]
    WITH GRANT OPTION
    AS [dbo];

