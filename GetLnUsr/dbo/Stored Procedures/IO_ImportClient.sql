
CREATE procedure [dbo].[IO_ImportClient] 
as 
BEGIN 

--Главная процедура загрузки клиентов
SET NOCOUNT ON;

declare @RetCode integer
set @RetCode = 0

---Процедура подготовки информации в таблицу loads..ImportClient
--drop table #TmpClient
--drop table #TmpId
--drop table #TmpIdEx

----------------------------------------------------------
create table #TmpClient (sysId integer, id integer not null primary key)
create table #TmpId (id integer primary key, custId integer, custType integer, sysId integer)
create table #TmpIdEx (id integer primary key, custId integer, sysId integer)

BEGIN TRAN  IO_CLIENT
BEGIN TRY

 insert into #TmpClient (sysId, id)
  select max(sysid), id 
   from loads..ImportClient 
    where isnull(WorkFlag,0) = 1 and isnull(custId,0) = 0 
   group by id 

 insert into customer (custType, status, ankVersion, loadId)
 output inserted.custId, inserted.loadId, inserted.custType into #TmpId (custId, id, custType)
 select  isnull(custType,3), 0, 1, t1.Id  
   from loads..ImportClient t1
       join #TmpClient t2 on t2.sysid = t1.sysId
   where isnull(WorkFlag,0) = 1 and isnull(custId,0) = 0 

update #TmpId set sysId = t2.sysId 
  from  #TmpId t1 
   join #TmpClient t2 on t2.id = t1.id

update  loads..ImportClient set custId = t2.custId  
   from loads..ImportClient t1, 
     #TmpId t2 
   where t1.id = t2.id 
     and isnull(WorkFlag,0) = 1

 insert into Company (custid, version)
  select custid, 1
    from #TmpId 
    where custType = 3 

 insert into Person (custid, version)
  select custid, 1
    from #TmpId 
    where custType = 2 

 insert into Client (custid, clientBrand, clientGroup)
  select t1.custid, clientBrand, clientGroup 
    from #TmpId t1
       join loads..ImportClient t2 on t2.id = t1.id and isnull(WorkFlag,0) = 1 and t2.sysId = t1.sysId

update Client set clientBrand = t2.clientBrand, clientGroup = t2.clientGroup
  from client t1 
   join #TmpId t3 on t3.custId = t1.custId
   join loads..ImportClient t2 on t2.Id = t3.id and isnull(WorkFlag,0) = 1 and t2.sysId = t3.sysId

insert into AnketaCompany 
(custId, version,  status, name, shortName, okpo, modifyDate, modifyLogin,
 jaCity, jaCountry,  jaRegion, jaAddress, 
 faCity, faCountry,  faRegion, faAddress, 
 leCity, leCountry,  leRegion, leAddress, lePostIndex)
select 
 t1.custId, 1,  2, t2.name, t2.shortName, convert(char(10), t2.OKPO), getdate(), 'dbo',
 jaCity, jaCountry,  jaRegionCode, jaAddress, 
 jaCity, jaCountry,  jaRegionCode, jaAddress, 
 jaCity, jaCountry,  jaRegionCode, JaAddress, convert(varchar(10),jaIndex)
from #TmpId t1, 
  loads..ImportClient t2 
 where t1.id = t2.id and isnull(WorkFlag,0) = 1
       and t2.custType = 3 
	   and t2.sysId = t1.sysId

insert into AnketaPerson 
(custId, version,status,
  lastName,surName,firstName,
  phoneMobileMain,phoneMobileExtra,phoneHome,eMail,
  citizenship,residency,reCountry,reAddress,inn,
  modifyDate,modifyLogin, 
  reCity,faCountry,faCity,faAddress, faRegion,lang,reRegion,leCountry,leRegion,leCity,leAddress,lePostIndex) 
select t1.custId, 1,0, 
  dbo.ParseStr (REPLACE(name,'ФОП',''), ' ',1), dbo.ParseStr (REPLACE(name,'ФОП',''), ' ',2), dbo.ParseStr (REPLACE(name,'ФОП',''), ' ',3), 
  contactPerPhone, NULL, NULL, contactPerEmail,  
  '804', 1, jaCountry, JaAddress, OKPO, 
  getdate(), 'ADMIN', 
  jaCity, jaCountry, jaCity, JaAddress, jaRegionCode,'Uk', jaRegionCode, jaCountry, jaRegionCode, jaCity, JaAddress, jaIndex
from #TmpId t1
 join  loads..ImportClient t2 on t1.id = t2.id and t2.sysId = t1.sysId and isnull(WorkFlag,0) = 1
where t1.custType = 2 
    

insert into BankAccount (custId,mfo,mfoName,mfoOkpo,accountNumber) 
select t1.custId, mfo,mfoName,mfoOkpo,accountNumber    
 from loads..ImportClient t1 
   join  #TmpId t2 on t1.id = t2.id  and t2.sysId = t1.sysId
 where isnull(t1.custId,0) <> 0 and isnull(t1.WorkFlag,0) = 1
    

---Директор
insert into Employee (custId, userId, lastName, firstName, surName,  phoneNumber, email)
output inserted.emplid, inserted.custId into #TmpIdEx (id, custId)
select t2.custId, NULL, 
    dbo.ParseStr (t2.bossFIO, ' ', 1), dbo.ParseStr (t2.bossFIO, ' ', 2) ,    dbo.ParseStr (t2.bossFIO, ' ', 3) ,
    t2.bossPhone, t2.bossemail
  from LOADS..ImportClient t2 
    join  #TmpId t1 on t1.id = t2.id and t2.sysId = t1.sysId 
    where isnull(t2.custid,0) <> 0 and isnull(t2.WorkFlag,0) = 1
       and t1.custType = 3

 insert into RelEmployee (custId, positionCode, emplid)
 select custId, 1, id
  from #TmpIdEx 

--Контактна особа
 delete #TmpIdEx
--Контактна особа
insert into Employee (custId, userId, lastName, firstName, surName,  phoneNumber, email, comment)
output inserted.emplid, inserted.custId into #TmpIdEx (id, custId)
select t2.custId, NULL, 
       dbo.ParseStr (t2.contactPerFio, ' ', 1),  dbo.ParseStr (t2.contactPerFio, ' ', 2),  dbo.ParseStr (t2.contactPerFio, ' ', 3),   
       t2.contactPerFio, t2.contactPerEmail, t2.ContactPerComment
  from loads..ImportClient t2 
    join  #TmpId t1 on t1.id = t2.id and t1.custType = 3 and t2.sysId = t1.sysId
    where isnull(t2.custid,0) <> 0 and isnull(t2.WorkFlag,0) = 1

insert into RelEmployee (custId, positionCode, emplid)
select custId, 4, id
  from #TmpIdEx 

insert into AgreementMaster (custId, agrStatus, modifyDate, modifyLogin, agrType, version)
select t1.custId, 0, getdate(), 'dbo', 2, 1
   from loads..ImportClient t1 
   join #TmpId t2 on t2.id = t1.id and t2.sysId = t1.sysId
   where isnull(t1.WorkFlag,0) = 1 and not exists (select 1 from AgreementMaster t2 where t2.custId = t1.custId)

delete #TmpIdEx 
insert into LicenseAgreement (licCode, licType, custId, licStatus, licClass, agrId, licSize, licVersion, prolongVersion)
output inserted.custId, inserted.licId, inserted.prolongVersion into #TmpIdEx (custId, id, sysid)
select t1.licCode, 1, t1.custId, 0, 0, t3.agrId, 0, 1, t1.sysId
  from loads..ImportClient t1
    join #TmpId t2 on t2.id = t1.id
    join AgreementMaster t3 on t3.custId = t1.custId
   where  isnull(t1.WorkFlag,0) = 1 and isnull(t1.licCode,0) <> 0 
          and not exists (select 1 from LicenseAgreement t2 where t2.custId = t1.custId)

insert into LicenseAgrParam (licId,licVersion,licNum,licDate,dateBegin,dateEnd, 
            minAmount,rateAmount,isAutoprolog,addRate,indxInfl,
            periodCode,dayForPay,licStatus,modifyDate,modifyLogin,ankVersion, comment)
select t1.id, 1, t2.licNumber, licDate, licDateBegin, licDateEnd, 
            minAmount, rateAmount, isAutoprolong, addRate, indxInf, 
            periodCode, dayForPay, 0, getdate(), 'dbo', 1, t2.CommentAgrParam
  from #TmpIdEx t1 
    join loads..ImportClient t2 on t1.custId = t2.custId and isnull(t2.WorkFlag,0) = 1 and t2.sysId = t1.sysId

	update LicenseAgreement set prolongVersion = NULL 
	 from LicenseAgreement t1 
	  join #TmpIdEx t2 on t2.Id = t1.licId

/*
---Не хватает адресов майданчиков
insert into ClnBusinessPlace (custId, plCode,placeName, placeCountry, placeRegion, placeCity, placeAddress, placePhone)
 select t1.custId, placeCode, placeName, 804, jaRegionCode, jaCity, JaAddress, 
        NULL --replace(dbo.ParseStr(replace (replace(Phone, 'Телефон 1:',''), 'Телефон 2:',''),' ',1), 'Факс:','')
   from loads..ImportClient t1
    join #TmpId t2  on t1.custId = t2.custId  
   where isnull(t1.workFlag,0) = 1 and isnull(placeCode,0) <> 0 and  isnull(t1.custId,0) <> 0 
*/
--Признак выполненной работы
 update loads..ImportClient set workFlag = 10 
   from loads..ImportClient t1 
      join #TmpId t2  on t1.custId = t2.custId and isnull(t1.WorkFlag,0) = 1


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

--exec IO_ImportClient 
/*
select * from LOADS..ImportClient
update LOADS..ImportClient set workFlag = 1, custid = NULL  where id >5 --between 1 and 5

select * from vcustomer
select * from vlicenseAgrParam
rollback
*/
