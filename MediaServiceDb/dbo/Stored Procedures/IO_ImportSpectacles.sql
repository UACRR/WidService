
CREATE procedure dbo.IO_ImportSpectacles
as 
BEGIN 

--Импорт спектаклей после контроля
SET NOCOUNT ON;

declare @RetCode integer
set @RetCode = 0

--drop table #TmpId
--drop table #TmpIdEx
--drop #TmpTab
----------------------------------------------------------
create table #TmpId (id integer primary key, custId integer,  spectCode integer)
create table #TmpIdEx (id integer primary key, objid integer, licId integer, sysId integer)

BEGIN TRAN  IO_SPECT
BEGIN TRY

create table #TmpTab 
 (
  theaterId integer not null primary key, 
  spectCode integer, 
  spectPerc decimal (10,5),  
  musicPerc decimal (10,5),  
  licNum varchar(50), 
  licDate date, 
  licDatebegin date, 
  licDateEnd date , 
  datePremiere date, 
  actCount integer, 
  clCustId integer, 
  objid integer, 
  agrId integer, 
  licId integer )  

insert into #TmpTab (theaterId, spectCode, spectPerc, musicPerc, licNum, licDate, licDatebegin, licDateEnd, datePremiere, actCount, clCustId, objid)
select theaterId, spectCode, max(spectPerc) as spectPerc, max(musicPerc) as musicPerc, max(licNumber) as licNum, 
  max(licDate) as licDate, max(licDatebegin) as licDatebegin, max(licDateEnd) as licDateEnd, 
  max(datePremiere) as datePremiere, max(actCount) as actCount, 
  max(clCustId) as clCustId, max(objId) as objid 
--  into #tab1
  from LOADS..ImportSpectacle 
  where workFlag = 1 
       and isnull(objid,0) <> 0 and isNull(clCustId,0) <> 0
  group by theaterId, spectCode

 update #TmpTab set agrId = t2.agrId 
     from #TmpTab t1 
      join AgreementMaster t2 on t1.clCustId = t2.custId and t2.agrType = 2

 insert into licenseAgreement 
 (licCode, licType, custId, licStatus, licClass, agrId, licSize, licVersion, prolongVersion) 
  output inserted.custId, inserted.licId, inserted.prolongVersion into #TmpId (custId, id, spectCode)
  select  10, 1, t1.clCustId, 0, 2, agrId, NULL, 1, spectCode 
   from #TmpTab t1
    where  not exists ( select 1 from LicenseBigR t3 where t3.objid = t1.objid )


  update  #TmpTab set licId = t2.Id 
      from #TmpTab t1 
      join #TmpId t2 on t1.spectCode = t2.spectCode 


  update licenseAgreement set prolongVersion = NULL 
    from licenseAgreement t1 
      join  #TmpTab t2 on t2.spectCode = t1.prolongVersion
      join #TmpId t3 on t3.spectCode = t2.spectCode

  insert into LicenseAgrParam
   (licId, licVersion, licNum, licDate, dateBegin, dateEnd, periodCode, dayForPay, licStatus, modifyDate, modifyLogin, ankVersion)
   select  
     t1.licId, 1, isnull(licNum, 'Tech-'+ltrim(convert(varchar(10), licId)) ),  isnull(licDate, '2019-01-01'), isnull(licDateBegin,'2019-01-01'),
	 isnull(licDateEnd, '2022-01-01'), 1, 20, 0, getdate(), 'Import', 1
    from #TmpTab t1
      join #TmpId t3 on t3.spectCode = t1.spectCode
	  
   insert into LicenseBigR 
    ( licId, datePremiere, objId, rate,  langCode, performType, licTerm, rateMusic )
    select  t1.licId, t1.datePremiere, t1.objid, spectPerc, 'Uk', 1, datediff(MONTH, licDateBegin, licDateENd), musicPerc
       from #TmpTab t1
       join #TmpId t3 on t3.spectCode = t1.spectCode

   insert into MusicalDesign ( licId, objid, objName, nameMusician, nameSinger, authorText, duration, numbPerfom )
    output inserted.mdId, inserted.objid, inserted.licId, inserted.actNumb  into #TmpIdEx (id, objid, licId, sysId)
    select t2.licId, t2.objid,  t1.objName, t1.nameMusician, t1.nameSinger, t1.authorText, t1.duration, numbPerfom  
     from loads..ImportSpectacleMusic t1 
       join #TmpTab t2 on t1.theaterId = t2.theaterId and t1.spectCode = t2.spectCode 
       join #TmpId t3 on t3.spectCode = t2.spectCode  
     where isnull(t1.objid,0) <> 0 and isnull(t1.clCustId,0) <> 0 and isnull(t1.objIdBr,0) <> 0
      and not exists ( select  1 from  loads..ImportSpectacleMusic t3 where t3.objidBr = t1.objid )

     update MusicalDesign set actNumb = NULL 
	    from MusicalDesign t1 
		 join #TmpIdEx t2 on t2.sysId = t1.actNumb 

--Признак выполненной работы
   update loads..ImportSpectacleMusic set mdId = t2.Id, workFlag = 10  
     from loads..ImportSpectacleMusic t1 
        join #TmpIdEx t2 on t2.sysId = t1.sysId 
   
   update loads..ImportSpectacle set licId = t2.Id, workFlag = 10  
     from loads..ImportSpectacleMusic t1 
        join #TmpId t2 on t1.spectCode = t2.spectCode 

/*
---Не хватает адресов майданчиков
insert into ClnBusinessPlace (custId, plCode,placeName, placeCountry, placeRegion, placeCity, placeAddress, placePhone)
 select t1.custId, placeCode, placeName, 804, jaRegionCode, jaCity, JaAddress, 
        NULL --replace(dbo.ParseStr(replace (replace(Phone, 'Телефон 1:',''), 'Телефон 2:',''),' ',1), 'Факс:','')
   from loads..ImportClient t1
    join #TmpId t2  on t1.custId = t2.custId  
   where isnull(t1.workFlag,0) = 1 and isnull(placeCode,0) <> 0 and  isnull(t1.custId,0) <> 0 
*/



IF @@TRANCOUNT > 0 commit tran
END TRY


 BEGIN CATCH
   IF @@TRANCOUNT > 0 rollback tran
   PRINT 'OOOO!!!'

     SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_SEVERITY() AS ErrorSeverity  
        ,ERROR_STATE() AS ErrorState  
        ,ERROR_PROCEDURE() AS ErrorProcedure  
        ,ERROR_LINE() AS ErrorLine  
        ,ERROR_MESSAGE() AS ErrorMessage;  

        set @Retcode = 1
    return @Retcode
    END CATCH

return @Retcode
END

/*
--update LOADS..ImportSpectacles set workFlag = 1

--exec dbo.IO_ImportSpectacles

select * from LOADS..ImportSpectacles
select * from LOADS..ImportSpectaclesMusic
*/