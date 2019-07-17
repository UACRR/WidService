--use MediaService
--go 
--update LOADS..ImportCommunity set workFlag = 1 

CREATE PROCEDURE Import_Community
as
begin

--Открытие Издателей  с анкетой и договором

SET NOCOUNT ON;
declare @RetCode integer
set @RetCode = 0

declare @id integer, @custId integer, @idp varchar(4) 
declare cur cursor for  select id from LOADS..ImportCommunity where workFlag = 1 and custId is NULL 

create table #TabId (custId integer not null)
create table #TmpIdEx (id integer, custId integer)
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
         select  3, 0, 1
           from LOADS..ImportCommunity
		   where id = @id
        
	 update LOADS..ImportCommunity
            set custId = t1.custId 
           from #TabId t1
            where id = @id  

	   set @custId = (select custId 
	         from LOADS..ImportCommunity 
			 where id = @id)

	   insert into Company (custId, version)
	   select @custId, 1

      insert into AnketaCompany 
    	 ( custId, version,  status, 
           name, shortName, okpo, 
           jaCountry, jaRegion, jaCity, jaAddress, 
		   faCountry, faRegion, faCity, faAddress, 
           leCountry, leRegion, leCity, leAddress, lePostIndex, 
           modifyDate,modifyLogin ) 
       select 
           custId, 1, 0,  
           name, shortName, okpo, 
           jaCountry, jaRegion, jaCity, jaAddress, jaCountry, jaRegion, jaCity, jaAddress,
           jaCountry, jaRegion, jaCity, jaAddress, lePostIndex, 
           getdate(), 'Admin' 
       from LOADS..ImportCommunity 
        where id = @id


     delete #TmpIdEx
     ---Директор
     insert into Employee (custId, userId, lastName, firstName, surName,  phoneNumber, email)
        output inserted.emplid, inserted.custId into #TmpIdEx (id, custId)
        select t2.custId, NULL, 
        dbo.ParseStr (t2.bossFIO, ' ', 1), dbo.ParseStr (t2.bossFIO, ' ', 2) ,    dbo.ParseStr (t2.bossFIO, ' ', 3) ,
        t2.bossPhone, t2.bossemail
      from LOADS..ImportCommunity t2 
        where t2.id = @id

      insert into RelEmployee (custId, positionCode, emplid)
       select custId, 1, id
       from #TmpIdEx 

    --Контактна особа
     delete #TmpIdEx
     insert into Employee (custId, userId, lastName, firstName, surName,  phoneNumber, email, comment)
      output inserted.emplid, inserted.custId into #TmpIdEx (id, custId)
      select t2.custId, NULL, 
           dbo.ParseStr (t2.contactPerFio, ' ', 1),  dbo.ParseStr (t2.contactPerFio, ' ', 2),  dbo.ParseStr (t2.contactPerFio, ' ', 3),   
           t2.contactPerFio, t2.contactPerEmail, t2.ContactPerComment
        from loads..ImportCommunity t2 
        where t2.id = @id 

     insert into RelEmployee (custId, positionCode, emplid)
      select custId, 4, id
      from #TmpIdEx 


-------------------
       insert into Community (custid, interCode)
          select custid, @id
           from #TabId 

		
	--Договор
       insert into AgreementMaster (custId, agrStatus, modifyDate, modifyLogin, agrType, version)
       select custId, 0, getdate(), 'Admin', 4, 1 
	   from  LOADS..ImportCommunity t1  
	   where id = @id 

     insert into AgreementAddCommunity 
       ( agrId, version, rateCourt, rateCommiss, custId, 
         agrNumber, agrDate, dateBegin, dateEnd, periodCode, dayForPay, 
         ankVersion, agrStatus, 
         modifyDate, modifyLogin) 
        select t2.agrId, t2.version, isnull(t1.rateCourt,0), isnull(rateCommiss, 0), t2.custId, 
               t1.agrNum, t1.agrDate, t1.agrDateBegin, t1.agrDateEnd, periodCode, dayForPay, 
               1, 0, 
               getdate(), 'Admin'
        from LOADS..ImportCommunity t1  
            join AgreementMaster t2 on t2.custId = t1.custId 
        where t1.id = @id 

----Выполнила!
   update LOADS..ImportCommunity set workFlag = 10 where id = @id and custid = @custId 


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

 Begin Tran
 insert into bankaccount 
  (custId,accountNumber,currency,transitNumber,mfo,mfoName,mfoOkpo)
   select t1.custId, t1.accountNumber, '980', t1.transitNumber, t1.mfo, t1.mfoName, t1.mfoOkpo 
   from LOADS..ImportCommunity t1 
     where  not exists (select  1 from bankaccount t2 where t2.custId = t1.custId )
    
  update AgreementAddRH set getCode = 1 
    from AgreementAddRH t1 
     left join BankAccount t2 on t1.custId = t2.custId 
	where isnull(t2.mfo,'')=''

  update AgreementAddRH set getCode = 2 
    from AgreementAddRH t1 
     left join BankAccount t2 on t1.custId = t2.custId 
	where isnull(t2.mfo,'') <> ''
 commit

return @Retcode
END

-----------------------------------------------
/*
 update LOADS..ImportCommunity set workFlag = 1 where isnull (workFlag,0) != 10
 exec Import_Community  
*/
-----------------------------------------------
--rollback