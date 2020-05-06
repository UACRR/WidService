
CREATE procedure IO_ImportPartner 
as 
BEGIN 

--Главная процедура загрузки клиентов
SET NOCOUNT ON;

declare @RetCode integer
set @RetCode = 0

---Процедура загрузки информации в таблицу loads..ImportPartner
--drop table #TmpClient
--drop table #TmpId
--drop table #TmpIdEx

----------------------------------------------------------
create table #TmpClient (systemId integer, id integer not null primary key)
create table #TmpId (id integer primary key, custId integer, custType integer, systemId integer)
create table #TmpIdEx (id integer primary key, custId integer, systemId integer)

BEGIN TRAN  IO_partner
BEGIN TRY

 insert into #TmpClient (systemId, id)
  select max(systemid), id 
   from loads..ImportPartner 
    where isnull(WorkFlag,0) = 1 and isnull(custId,0) = 0 
   group by id 

 insert into customer (custType, status, ankVersion, loadId)
 output inserted.custId, inserted.loadId, inserted.custType into #TmpId (custId, id, custType)
 select  isnull(custType,3), 0, 1, t1.Id  
   from loads..ImportPartner t1
       join #TmpClient t2 on t2.systemId = t1.systemId
   where isnull(WorkFlag,0) = 1 and isnull(t1.custId,0) = 0 

update #TmpId set systemId = t2.systemId 
  from  #TmpId t1 
   join #TmpClient t2 on t2.id = t1.id

update  loads..ImportPartner set custId = t2.custId  
   from loads..ImportPartner t1, 
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
    where custType in (1, 2)

 insert into Partner (custid, isMy)
  select t1.custid, t2.isMy
    from #TmpId t1
       join loads..ImportPartner t2 on t2.id = t1.id and isnull(WorkFlag,0) = 1 and t2.systemId = t1.systemId

insert into AnketaCompany 
(custId, version,  status, name, shortName, okpo, modifyDate, modifyLogin,
 jaCity, jaCountry,  jaRegion, jaAddress, 
 faCity, faCountry,  faRegion, faAddress, 
 leCity, leCountry,  leRegion, leAddress, lePostIndex)
select 
 t1.custId, 1,  0, t2.partnerName, t2.shortName, convert(char(10), t2.okpoInn), getdate(), 'dbo',
 faCity, faCountry,  faRegionCode, faAddress, 
 faCity, faCountry,  faRegionCode, faAddress, 
 faCity, faCountry,  faRegionCode, faAddress, convert(varchar(10),lePostIndex)
from #TmpId t1, 
  loads..ImportPartner t2 
 where t1.id = t2.id and isnull(WorkFlag,0) = 1
       and t2.custType = 3 
       and t2.systemId = t1.systemId

insert into AnketaPerson 
( custId, version,status,
  lastName, firstName, surName,
  phoneMobileMain,phoneMobileExtra,phoneHome,eMail,
  citizenship,residency,reCountry,reAddress,inn,
  modifyDate,modifyLogin, 
  reCity,faCountry,faCity,faAddress, faRegion,lang,reRegion,leCountry,leRegion,leCity,leAddress,lePostIndex) 
select t1.custId, 1,0, 
  dbo.ParseStr (REPLACE(partnerName,'ФОП',''), ' ',1), 
  dbo.ParseStr (REPLACE(partnerName,'ФОП',''), ' ',2), 
  dbo.ParseStr (REPLACE(partnerName,'ФОП',''), ' ',3), 
  phoneMobileMain, phoneMobileExtra, phoneHome, eMail,
  '804', 1, faCountry, faAddress, okpoInn, 
  getdate(), 'ADMIN', 
  faCity, faCountry, faCity, faAddress, faRegionCode,'Uk', faRegionCode, faCountry, faRegionCode, faCity, faAddress, lePostIndex
from #TmpId t1
 join  loads..ImportPartner t2 on t1.id = t2.id and t2.systemId = t1.systemId and isnull(WorkFlag,0) = 1
where t1.custType in (1,2) 
    

insert into BankAccount (custId) 
select t1.custId
 from loads..ImportPartner t1 
   join  #TmpId t2 on t1.id = t2.id  and t2.systemId = t1.systemId
 where isnull(t1.custId,0) <> 0 and isnull(t1.WorkFlag,0) = 1
    
/* --если нужно будет для юр.особ
---Директор
insert into Employee (custId, userId, lastName, firstName, surName,  phoneNumber, email)
output inserted.emplid, inserted.custId into #TmpIdEx (id, custId)
select t2.custId, NULL, 
    dbo.ParseStr (t2.bossFIO, ' ', 1), dbo.ParseStr (t2.bossFIO, ' ', 2) ,    dbo.ParseStr (t2.bossFIO, ' ', 3) ,
    t2.bossPhone, t2.bossemail
  from LOADS..ImportPartner t2 
    join  #TmpId t1 on t1.id = t2.id and t2.systemId = t1.systemId 
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
  from loads..ImportPartner t2 
    join  #TmpId t1 on t1.id = t2.id and t1.custType = 3 and t2.systemId = t1.systemId
    where isnull(t2.custid,0) <> 0 and isnull(t2.WorkFlag,0) = 1

insert into RelEmployee (custId, positionCode, emplid)
select custId, 4, id
  from #TmpIdEx 
*/

delete #TmpIdEx 
insert into AgreementMaster (custId, agrStatus, modifyDate, modifyLogin, agrType, version)
select t1.custId, 0, getdate(), 'dbo', 3, 1
   from loads..ImportPartner t1 
   join #TmpId t2 on t2.id = t1.id and t2.systemId = t1.systemId
   where isnull(t1.WorkFlag,0) = 1 and not exists (select 1 from AgreementMaster t2 where t2.custId = t1.custId and agrType = 3)

insert into AgreementAddPartner 
 (agrId,custId,srFirstRate,srMonthRate,pfFirstRate,pfMonthRate,courtRate,noCourtRate,courtCompRate,version,
  agrNumber,agrDate,dateBegin,dateEnd,periodCode,agrStatus,dayForPay,ankVersion,modifyDate,modifyLogin)
select t3.agrId, t2.custId, t1.srFirstRate, t1.srMonthRate, t1.pfFirstRate, t1.pfMonthRate, t1.courtRate, t1.noCourtRate, t1.courtCompRate, 1, 
       'T-'+ltrim(convert(char(10), t1.custId)), getdate(), getdate(), '3000-01-01', 1, 0, 20, 1, getdate(), 'Import'
   from loads..ImportPartner t1 
   join #TmpId t2 on t2.id = t1.id and t2.systemId = t1.systemId
   join AgreementMaster t3 on t3.custId = t2.custId and t3.agrType = 3 
     where isnull(t1.WorkFlag,0) = 1 
     and not exists (select 1 from AgreementAddPartner t4 where t4.agrId = t3.agrId)
 
--Признак выполненной работы
 update loads..ImportPartner set workFlag = 10 
   from loads..ImportPartner t1 
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

--exec IO_ImportPartner 
/*
select * from LOADS..ImportPartner
update LOADS..ImportPartner set workFlag = 1, custid = NULL  where id >5 --between 1 and 5
select * from vcustomer

rollback
*/

