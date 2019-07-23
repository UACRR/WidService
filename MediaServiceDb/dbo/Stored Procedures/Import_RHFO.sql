--use MediaService
--go 
--update LOADS..ImportRHFO set workFlag = 1 

CREATE PROCEDURE Import_RHFO  
as
begin

--Открытие правообладателей с анкетой и договором

SET NOCOUNT ON;
declare @RetCode integer
set @RetCode = 0

declare @id integer, @custId integer, @idp varchar(4) 
declare cur cursor for  select id from LOADS..ImportRHFO where workFlag = 1 and custId is NULL 

create table #TabKind 
(custId integer,
 kindCode integer not null primary key , 
 kindValue integer)

create table #TabId (custId integer not null)

-------------------------------
open cur                                                   

    fetch cur into   @Id
                                                  
    while @@fetch_status = 0                                                   
    BEGIN 

     begin Tran Intr1 
     BEGIN TRY

    delete #TabId 

     set @idp = convert(char(4),@id)
	
	 print @idp
    
         insert into customer (custType, status, ankVersion)
         output inserted.custId into #TabId (custId)
         select  1, 0, 1 
           from LOADS..ImportRHFO
		   where id = @id
        
	 update LOADS..ImportRHFO
            set custId = t1.custId 
           from #TabId t1
            where id = @id  

	   set @custId = (select custId 
	         from LOADS..ImportRHFO 
			 where id = @id)

	   insert into Person (custId, version)
	   select @custId, 1

      insert into AnketaPerson 
    	 ( custId, version, status, lang, 
           firstName, surName, lastName, nikName, sex, birthDate, 
           phoneMobileMain, phoneMobileExtra, phoneHome, eMail, 
           citizenship, residency, inn,
           reCountry, reRegion, reCity, reAddress, 
           faCountry, faRegion, faCity, faAddress, 
           leCountry, leRegion, leCity, leAddress, lePostIndex,
           pFSeries, pFNumber, pFIssuedDate, pFValidity,
           buisNumberRegistration, buisDateRegistration, buisNumberPayer, buisSertNumberPayer, typeVAT,
           banAccId, 
           pUSeries,pUNumber,pUIssuedWho,pUIssuedWhen, 
           modifyDate,modifyLogin ) 
       select 
           custId, 1, 0, 'UK', 
           firstName, surName, lastName, nickName, sexCode, birthDay, 
           phoneMobileMain, phoneMobileExtra, phoneHome, eMail, 
           citizenshipCode, residencyCode, inn,
           reCountryCode, reRegionCode, reCity, reAddress, 
           faCountryCode, faRegionCode, faCity, faAddress, 
           leCountryCode, leRegionCode, leCity, leAddress, leIndex,
           NULL, NULL, NULL, NULL,
           NULL, NULL, NULL, NULL, NULL,
           NULL,  
           pUSeries, pUNumber, pUIssuedWho, pUIssuedWhen, 
           getdate(), 'Load1' 
       from LOADS..ImportRHFO t1 
        where id = @id


        insert into RightHolder (custId, rHolderType, interCode, innerCode, comment,  aroundWord) 
		 select custId, 1, t1.interCode, t1.innerCode, t1.comment, NULL --(Case t1.isWord When 'ТАК' then 1 else 0 end )
		   from LOADS..ImportRHFO t1  
		   where id = @id 
		
	--Договор
	insert into AgreementMaster (custId, agrStatus, modifyDate, modifyLogin, agrType, version)
	select custId, 0, getdate(), 'input', 1, 1 
	   from  LOADS..ImportRHFO t1  
	   where id = @id 

        insert into AgreementAddRH 
           (agrId, custId, rateCommiss, rateCourt, version, 
            agrNumber, agrDate, dateBegin, dateEnd, periodCode, dayForPay, 
            ankVersion, agrStatus, getCode, modifyDate,modifyLogin)
	select t2.agrId, t1.custId, rateCommiss, rateCourt, 1, 
		       --convert(integer, substring(t1.commRate,1, PATINDEX ('%/%',t1.commRate) -1 ) ) as rateCommiss, 
                       --convert(integer, substring(t1.commRate, PATINDEX ('%/%',t1.commRate)+1, 10 ) ) as rateCourt, 
               t1.agrNum, t1.agrDate, t1.agrDateBegin, t1.agrDateEnd, periodCode, dayForPay, 
               1, 0, NULL, getdate(), 'Input1'
         from LOADS..ImportRHFO t1  
 	    join AgreementMaster t2 on t1.custId = t2.custId 
     	   where t1.id = @id 

        --Права (пока не смотрю на файл
 delete #TabKind
 insert into #TabKind (custId, kindCode, kindValue)
 select @custId, 1 as kindCode, (Case When kind1 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHFO where custid = @custid
  union select @custId, 2 as kindCode, (Case When kind2 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHFO where custid = @custid
  union select @custId, 3 as kindCode, (Case When kind3 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHFO where custid = @custid
  union select @custId, 4 as kindCode, (Case When kind4 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHFO where custid = @custid
  union select @custId, 5 as kindCode, (Case When kind5 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHFO where custid = @custid
  union select @custId, 6 as kindCode, (Case When kind6 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHFO where custid = @custid
  union select @custId, 8 as kindCode, (Case When kind8 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHFO where custid = @custid
  union select @custId, 9 as kindCode, (Case When kind9 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHFO where custid = @custid
  union select @custId, 10 as kindCode, (Case When kind10 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHFO where custid = @custid
  union select @custId, 11 as kindCode, (Case When kind11 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHFO where custid = @custid
  union select @custId, 12 as kindCode, (Case When kind12 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHFO where custid = @custid
  union select @custId, 13 as kindCode, (Case When kind13 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHFO where custid = @custid
  union select @custId, 14 as kindCode, (Case When kind14 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHFO where custid = @custid
  union select @custId, 15 as kindCode, (Case When kind15 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHFO where custid = @custid
  union select @custId, 16 as kindCode, (Case When kind16 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHFO where custid = @custid
  union select @custId, 17 as kindCode, (Case When kind17 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHFO where custid = @custid

/*
    insert into TermsOfService (custId, crKindCode, ourService) 
    select  @custId, t1.codeI, 1
             from CopyrightKind t1 
*/
    insert into TermsOfService (custId, crKindCode, ourService) 
    select  t1.custId, t1.kindCode, t1.kindValue
             from #TabKind t1 

----Выполнила!
   update LOADS..ImportRHFO set workFlag = 10 where id = @id and custid = @custId 


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
 fetch cur into   @id
 END                                                   
close cur   
deallocate cur      

return @Retcode
END

-----------------------------------------------
update LOADS..ImportRHFO set workFlag = 1

update LOADS..ImportRHFO set workFlag = 1 where isnull (workFlag,0) != 10



--rollback
--Commit
/*
select * from LOADS..ImportRHFO
select * from vcustomer order by name
--select * from vcustomer
select * from AgreementMaster
select * from AgreementAddRH
-- select 'exec DelFullCustomer ' + cast(custId as char(10)) from vcustomer where custId > 1451
--select 'exec DelObjectRight '+ cast(objid as char(10)) from ObjectRight
--dbcc CHECKIDENT ( customer, RESEED, 1500)
--sp__tablespace2_report mediaservice,3

*/

exec Import_RHFO

/*
select * from LOADS..ImportRHFO where custid is null
select * from vCustomer
select * from vCustomer where custId = 1656
dbcc CHECKIDENT ( customer, RESEED, 1500)
dbcc CHECKIDENT ( AgreementMaster, RESEED, 3500) 
*/

insert into bankaccount 
(custId,accountNumber,currency,transitNumber,mfo,mfoName,mfoOkpo)
select custId, accountNumber, '980', transitNumber, mfo,mfoName,mfoOkpo 
from LOADS..ImportRHFO 

begin tran
update AgreementAddRH set getCode = 1 
  from AgreementAddRH t1 
     left join BankAccount t2 on t1.custId = t2.custId 
	where isnull(t2.mfo,'')=''

update AgreementAddRH set getCode = 2 
  from AgreementAddRH t1 
     left join BankAccount t2 on t1.custId = t2.custId 
	where isnull(t2.mfo,'') <> ''
commit