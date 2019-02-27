--select * from Test..GO_InRhFo
--use MediaService
--go 
--drop table #TabId
--update Test..GO_InRhFo set custId = NULL 

CREATE PROCEDURE Intr_OpenAnkRhFO 
as
begin

--Открытие правообладателей с анкетой и договором

SET NOCOUNT ON;
declare @RetCode integer
set @RetCode = 0

declare @id integer, @custId integer, @idp varchar(4) 
declare cur cursor for  select id from Test..GO_InRhFo where custId is NULL 

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
           from Test..GO_InRhFo
		   where id = @id
        
		  update Test..GO_InRhFo
            set custId = t1.custId 
           from #TabId t1
            where id = @id  

	   set @custId = (select custId 
	         from Test..GO_InRhFo 
			 where id = @id)

	   insert into Person (custId, version)
	   select @custId, 1

       insert into AnketaPerson 
		(custId, version, status, 
		 lastName, firstName, surName,
		 nikName, --sex, 
		 birthDate, inn, 
		 citizenship, residency, reCountry, faCountry, 
		 modifyDate,modifyLogin )
         select  t1.custId, 1, 0, 
                 --ФИО
                 (select dbo.ParseStr (t1.rhName, ' ', 1)), 
                 (select dbo.ParseStr (t1.rhName, ' ', 2)), 
                 (select dbo.ParseStr (t1.rhName, ' ', 3)), 
		 t1.nikName, 
		 t1.birthday, inn,
		 804, 1, 804, 804, 
		 getdate(), 'Input'
		  from Test..GO_InRhFo t1 
			 where id = @id
       
        insert into RightHolder (custId, interCode, rHolderType, aroundWord) 
		 select custId, t1.IPI, 1, (Case t1.isWord When 'ТАК' then 1 else 0 end )
		   from Test..GO_InRhFo t1  
		   where id = @id 
		
		--Договор
		insert into AgreementMaster (custId,agrStatus,modifyDate,modifyLogin,agrType,version)
		select custId, 0, getdate(), 'input', 1, 1 
		   from  Test..GO_InRhFo t1  
		   where id = @id 

        insert into AgreementAddRH 
	    (agrId, custId, rateCommiss, rateCourt, version,agrNumber,agrDate,dateBegin,dateEnd, periodCode, dayForPay, ankVersion, agrStatus, getCode, modifyDate,modifyLogin)
		select t2.agrId, t1.custId,  
		       convert(integer, substring(t1.commRate,1, PATINDEX ('%/%',t1.commRate) -1 ) ) as rateCommiss, 
               convert(integer, substring(t1.commRate, PATINDEX ('%/%',t1.commRate)+1, 10 ) ) as rateCourt, 
			   1, t1.agrNum, t1.agrDate, t1.dateBegin, '3000-01-01', 
			   NULL, NULL, 1, 0, NULL, getdate(), 'Input'
		   from Test..GO_InRhFo t1  
		    join AgreementMaster t2 on t1.custId = t2.custId 
		   where t1.id = @id 

        --Права (пока не смотрю на файл
         insert into TermsOfService (custId, crKindCode, ourService) 
		   select  @custId, t1.codeI, 1
		    from CopyrightKind t1

	  --commit

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
--rollback
--Commit
/*
select * from Test..GO_InRhFo
select * from vcustomer order by name
--select * from vcustomer
select * from AgreementMaster
select * from AgreementAddRH
-- select 'exec DelFullCustomer ' + cast(custId as char(10)) from vcustomer where custId > 1451
--select 'exec DelObjectRight '+ cast(objid as char(10)) from ObjectRight
--dbcc CHECKIDENT ( customer, RESEED, 1500)
--sp__tablespace2_report mediaservice,3

*/
exec Intr_OpenAnkRhFO 
/*
select * from Test..GO_InRhFo where custid is null
select * from vCustomer where custId = 1656
dbcc CHECKIDENT ( customer, RESEED, 1500)
dbcc CHECKIDENT ( AgreementMaster, RESEED, 3500) 
*/