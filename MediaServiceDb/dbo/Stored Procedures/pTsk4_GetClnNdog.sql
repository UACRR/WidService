CREATE  procedure pTsk4_GetClnNdog @licId integer, @version integer
as
begin
 declare @RetCode integer, @typeAlg smallint, @custId integer
 set @RetCode = 0

 set @typeAlg  = (select max(typeAlg) from MyAnketa)

-- Номер лиценионного договора для малых прав и больших прав ГО
 update LicenseAgrParam set licNum = isnull(series,'X')+'-'+rtrim(rtrim(convert(char(25),t1.licId))) 
 from LicenseAgrParam t1 
   join LicenseAgreement t2 on t2.licId = t1.licId 
   join AgrLicenseType t3 on  t3.codeI = t2.licCode 
 where  t1.licId = @licId and t1.licVersion = @version
        and isnull(t1.licNum, '') = ''
        and @typeAlg = 1

-- Номер заявки для больших прав ГО - формировать автоматически как порядковый номер Заявки в рамках каждого театра. Редактирование не допустимо.  
-- Если макс. лицензия не число - ставлю кол-во лицензий + 1 
IF @typeAlg = 2 
BEGIN
set @custid = (select max(t2.custId) 
               from LicenseAgrParam t1 
               join LicenseAgreement t2 on t2.licId = t1.licId and t2.licVersion = t1.licVersion
               where t1.licId = @licId and t1.licversion = t1.licVersion )

--print cast(@custId as varchar(25))

;with TabNum as 
--максимальный номер по театру
(
select t2.custid, 
  max((Case When(ISNUMERIC(t1.licNum)) = 0 THEN 0 ELSE CAST(t1.licNum as integer) END)) as licNumI,
  CAST(count(distinct t2.licId) as varchar(25)) as countLicNum
from LicenseAgrParam t1 
 join LicenseAgreement t2 on t2.licId = t1.licId and t2.licVersion = t1.licVersion
 join vAgrLicenseType t3 on  t3.licCode = t2.licCode and usesType = 1 and licClass = 2
 join LicenseBigR t4 on t4.licId = t2.licId
 --where t2.custId = 321
 where t2.custId = @custId 
 group by t2.custId
) 
update LicenseAgrParam set licNum = (CASE WHEN licNumI = 0 THEN countLicNum ELSE licNumI END) + 1
--select t1.licNum, (CASE WHEN licNumI = 0 THEN countLicNum ELSE licNumI END) + 1, *
    from LicenseAgrParam t1 
     join LicenseAgreement t3 on t3.licId = t1.licId and t3.licVersion = t1.licVersion
     join TabNum t2 on t2.custId = t3.custId 
	 join vAgrLicenseType t4 on  t4.licCode = t3.licCode and usesType = 1 and licClass = 2
     join LicenseBigR t5 on t5.licId = t3.licId
   where t1.licId = @licId and t1.licVersion = @version and isnull(t1.licNum ,'') = ''
   --where t1.licId = 1202 and t1.licVersion = 9
END


IF @typeAlg = 1 
--ДЛЯ PO:  номер формировать  =  СерияID/номер заявки
BEGIN
update LicenseAgrParam set licNum = ltrim(rtrim(t4.series))+'-'+ ltrim(rtrim(cast(t3.licId as varchar(25)))) + '/'+ + rtrim(ltrim(licNum))
    from LicenseAgrParam t1 
     join LicenseAgreement t3 on t3.licId = t1.licId and t3.licVersion = t1.licVersion
	 join vAgrLicenseType t4 on  t4.licCode = t3.licCode and usesType = 1 and licClass = 2 and t3.licType = 1
     join LicenseBigR t5 on t5.licId = t3.licId
   where t1.licId = @licId and t1.licVersion = @version and 
     left(licNum, len(t4.series)) <> t4.series
   --where t1.licId = 1202 and t1.licVersion = 9
END

RETURN @RetCode
end

--exec  pTsk4_GetClnNdog 1233, 3
--select licId, licversion, licNum,* from vLicenseAgrParam where custid = 321  licId = 1202 --liccode = 10 
--update MyAnketa set typealg = 1