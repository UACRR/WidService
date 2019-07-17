
--update LOADS..ImportClientTheater  set custId = NULL
--update LOADS..ImportClientTheater  set workFlag = 1
--select * from LOADS..ImportClientTheater 
--select * from LOADS..SO_Import_ClientTheater0412
--select * from BankAccount order by custid

CREATE PROCEDURE Intr_IO_ClientTheater 
as
begin

--Импорт КЛИЕНТОВ -ТЕАТРОВ

SET NOCOUNT ON;
declare @RetCode integer, @tprt varchar(100)
set @RetCode = 0

 create table #TmpId (id integer, custId integer)
 create table #TmpIdEx (id integer, custId integer)

 BEGIN TRAN IO_Theater
 BEGIN TRY

 insert into customer (custType, status, ankVersion, ankTech)
 output inserted.custId, inserted.ankTech into #TmpId (custId, id)
 select  3, 2, 1, id 
   from LOADS..ImportClientTheater 
   where workFlag = 1 and isnull(custid,0) = 0 and isnull(errFlag,0) = 0 

  insert into Company (custid, version)
  select custid, 1
    from #TmpId 

  insert into Client (custid)
    select custid
     from #TmpId 

 insert into AnketaCompany 
  (custId, version,  status, name, shortName, okpo, 
   modifyDate, modifyLogin,
   jaCity, jaCountry,  jaRegion, jaAddress, faCountry, faCity, faRegion, faAddress, leCity,leCountry, lePostIndex, leRegion, leAddress)
  select 
   t1.custId, 1,  2, t2.name, isnull(t2.shortName, name), cast(cast (convert(float, t2.OKPO) as numeric(20)) as varchar(15)), 
   getdate(), 'dbo',
   jaCity, 804,  jaregionCode, jaAddress, '804', jaCity, jaregionCode, jaAddress, jaCity, 804, leIndex, jaregionCode, JaAddress
  from #TmpId t1, 
    LOADS..ImportClientTheater t2 
  where t1.id = t2.id 

 print 'Імпортовано '+cast(@@ROWCOUNT as varchar(10) )

 update  LOADS..ImportClientTheater set custId = t2.custId  
   from LOADS..ImportClientTheater t1, 
        #TmpId t2 
    where t1.id = t2.id 

---Счета
insert into BankAccount (custId,mfo,mfoName,mfoOkpo,accountNumber) 
select t1.custId, t1.mfo, t1.mfoName, t1.mfoOkpo, t1.accountNumber    
   from LOADS..ImportClientTheater t1 
   join  #TmpId t2 on t1.id = t2.id 
 where isnull(t1.custId,0) <> 0 
       and not exists ( select  1 from BankAccount t3 where t3.custId = t2.custId)

----------Контакти
---Директор
insert into Employee (custId, userId, lastName, firstName, surName,  phoneNumber, email)
output inserted.emplid, inserted.custId into #TmpIdEx (id, custId)
select t1.custId, NULL, 
    dbo.ParseStr (t1.bossFIO, ' ', 1), dbo.ParseStr (t1.bossFIO, ' ', 2) ,    dbo.ParseStr (t1.bossFIO, ' ', 3) ,
    convert(varchar(100), t1.bossPhone), t1.bossemail
  from LOADS..ImportClientTheater t1 
    join  #TmpId t2 on t1.id = t2.id 
    where isnull(t1.custid,0) <> 0

 insert into RelEmployee (custId, positionCode, emplid)
 select custId, 1, id
  from #TmpIdEx

--Контактна особа
 delete #TmpIdEx
--Контактна особа
insert into Employee (custId, userId, lastName, firstName, surName,  phoneNumber, email, comment)
output inserted.emplid, inserted.custId into #TmpIdEx (id, custId)
select t1.custId, NULL, 
       dbo.ParseStr (t1.contactPerFio, ' ', 1),  dbo.ParseStr (t1.contactPerFio, ' ', 2),  dbo.ParseStr (t1.contactPerFio, ' ', 3),   
       t1.contactPerPhone, t1.contactPerEmail, t1.ContactPerComment
  from LOADS..ImportClientTheater t1 
    join  #TmpId t2 on t1.id = t2.id 
    where isnull(t2.custid,0) <> 0

insert into RelEmployee (custId, positionCode, emplid)
select custId, 4, id
  from #TmpIdEx 
-----------------------------------------------------------------
insert into AgreementMaster (custId,agrStatus,modifyDate,modifyLogin,agrType,version)
select t1.custId, 0, getdate(), 'Admin', 2, 1 
   from LOADS..ImportClientTheater t1
     join  #TmpId t2 on t1.id = t2.id and isnull(t1.custid ,0) <> 0
   where not exists (select 1 from AgreementMaster t2 where t2.custId = t1.custId)

insert into AgreementAddBr (custId, agrId, agrNumber, agrDate, dateBegin,dateEnd, agrStatus, modifyDate, modifyLogin, version, ankVersion )
select t1.custId, t2.agrId, agrNumber, agrDate, agrDateBegin,agrDateEnd, 0, getdate(), 'Admin', 1, 1
   from LOADS..ImportClientTheater t1
    join AgreementMaster t2 on t2.custId = t1.custId
	join  #TmpId t3 on t3.id = t1.id 
     where not exists (select 1 from AgreementAddBr t3 where t3.agrId = t2.agrId)

--Техническая лицензия
delete #TmpIdEx 
insert into LicenseAgreement (licCode,licType,custId,licStatus,licClass,agrId,licSize,licVersion,prolongVersion)
output inserted.custId, inserted.licId into #TmpId (custId, id)
select 28, 1, t1.custId, 0, 1, t3.agrId, 0, 1, NULL
  from LOADS..ImportClientTheater t1
    join #TmpId t2 on t2.custId = t1.custId 
    join AgreementMaster t3 on t3.custId = t1.custId
    where  not exists (select 1 from LicenseAgreement t2 where t2.custId = t1.custId)

insert into LicenseAgrParam 
(licId,licVersion,licNum,licDate,dateBegin,dateEnd,minAmount,rateAmount,isAutoprolog,addRate,indxInfl,periodCode,dayForPay, 
 licStatus, modifyDate,modifyLogin,ankVersion)
select t1.id, 1, t2.agrNumber, t2.agrDate, t2.agrDateBegin, t2.agrDateEnd, NULL, NULL, NULL,NULL, NULL, t2.periodCode, t2.dayForPay, 
  0, getdate(), 'Admin', 1 
  from #TmpIdEx t1 
    join LOADS..ImportClientTheater t2 on t1.custId = t2.custId 

---Майданчики
insert into ClnBusinessPlace (custId, plCode,placeName, placeCountry, placeRegion, placeCity, placeAddress, placePhone)
 select t1.custId, t3.codeI, 'Головна сцена', 804, jaRegionCode, jaCity, JaAddress, NULL
   from LOADS..ImportClientTheater t1
        join  #TmpId t2 on t1.id = t2.id and isnull(t1.custid ,0) <> 0 
        left join typePlace t3 on t3.name like 'Театр%'
    where isnull(t1.custId,0) <> 0 


IF @@TRANCOUNT > 0 commit tran
END TRY

   BEGIN CATCH
     IF @@TRANCOUNT > 0 rollback tran
  

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

--EXEC Intr_IO_ClientTheater 
 
--exec DelFullCustomer 42367
--exec DelFullCustomer 42368