--use MediaService
--go 
--update LOADS..ImportRHYO set workFlag = 1 

CREATE PROCEDURE Import_RHYO  
as
begin

--Открытие Издателей  с анкетой и договором

SET NOCOUNT ON;
declare @RetCode integer
set @RetCode = 0

declare @id integer, @custId integer, @idp varchar(4) 
declare cur cursor for  select id from LOADS..ImportRHYO where workFlag = 1 and custId is NULL 

create table #TabKind 
(custId integer,
 kindCode integer not null primary key , 
 kindValue integer)

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
           from LOADS..ImportRHYO
		   where id = @id
        
	 update LOADS..ImportRHYO
            set custId = t1.custId 
           from #TabId t1
            where id = @id  

	   set @custId = (select custId 
	         from LOADS..ImportRHYO 
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
       from LOADS..ImportRHYO t1 
        where id = @id


     delete #TmpIdEx
     ---Директор
     insert into Employee (custId, userId, lastName, firstName, surName,  phoneNumber, email)
        output inserted.emplid, inserted.custId into #TmpIdEx (id, custId)
        select t2.custId, NULL, 
        dbo.ParseStr (t2.bossFIO, ' ', 1), dbo.ParseStr (t2.bossFIO, ' ', 2) ,    dbo.ParseStr (t2.bossFIO, ' ', 3) ,
        t2.bossPhone, t2.bossemail
      from LOADS..ImportRHYO t2 
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
        from LOADS..ImportRHYO t2 
        where t2.id = @id 

     insert into RelEmployee (custId, positionCode, emplid)
      select custId, 4, id
      from #TmpIdEx 

--------------------------



        insert into RightHolder (custId, rHolderType, interCode, innerCode, comment,  aroundWord) 
		 select custId, 3, t1.interCode, t1.innerCode, t1.comment, NULL --(Case t1.isWord When 'ТАК' then 1 else 0 end )
		   from LOADS..ImportRHYO t1  
		   where id = @id 
		
	--Договор
	insert into AgreementMaster (custId, agrStatus, modifyDate, modifyLogin, agrType, version)
	select custId, 0, getdate(), 'Admin', 5, 1 
	   from  LOADS..ImportRHYO t1  
	   where id = @id 

        insert into AgreementAddRH 
           (agrId, custId, rateCommiss, rateCourt, version, 
            agrNumber, agrDate, dateBegin, dateEnd, periodCode, dayForPay, 
            ankVersion, agrStatus, getCode, modifyDate,modifyLogin)
	select t2.agrId, t1.custId, rateCommiss, rateCourt, 1, 
               t1.agrNum, t1.agrDate, t1.agrDateBegin, t1.agrDateEnd, periodCode, dayForPay, 
               1, 0, NULL, getdate(), 'Admin'
         from LOADS..ImportRHYO t1  
 	    join AgreementMaster t2 on t1.custId = t2.custId 
     	   where t1.id = @id 

 delete #TabKind
 insert into #TabKind (custId, kindCode, kindValue)
 select @custId, 1 as kindCode, (Case When kind1 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHYO where custid = @custid
  union select @custId, 2 as kindCode, (Case When kind2 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHYO where custid = @custid
  union select @custId, 3 as kindCode, (Case When kind3 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHYO where custid = @custid
  union select @custId, 4 as kindCode, (Case When kind4 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHYO where custid = @custid
  union select @custId, 5 as kindCode, (Case When kind5 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHYO where custid = @custid
  union select @custId, 6 as kindCode, (Case When kind6 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHYO where custid = @custid
  union select @custId, 8 as kindCode, (Case When kind8 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHYO where custid = @custid
  union select @custId, 9 as kindCode, (Case When kind9 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHYO where custid = @custid
  union select @custId, 10 as kindCode, (Case When kind10 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHYO where custid = @custid
  union select @custId, 11 as kindCode, (Case When kind11 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHYO where custid = @custid
  union select @custId, 12 as kindCode, (Case When kind12 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHYO where custid = @custid
  union select @custId, 13 as kindCode, (Case When kind13 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHYO where custid = @custid
  union select @custId, 14 as kindCode, (Case When kind14 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHYO where custid = @custid
  union select @custId, 15 as kindCode, (Case When kind15 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHYO where custid = @custid
  union select @custId, 16 as kindCode, (Case When kind16 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHYO where custid = @custid
  union select @custId, 17 as kindCode, (Case When kind17 = 'ТАК' THEN 1 else 0 END) as kindValue from LOADS..ImportRHYO where custid = @custid

/*
    insert into TermsOfService (custId, crKindCode, ourService) 
    select  @custId, t1.codeI, 1
             from CopyrightKind t1 
*/
    insert into TermsOfService (custId, crKindCode, ourService) 
    select  t1.custId, t1.kindCode, t1.kindValue
             from #TabKind t1 

----Выполнила!
   update LOADS..ImportRHYO set workFlag = 10 where id = @id and custid = @custId 


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
   from LOADS..ImportRHYO t1 
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
 update LOADS..ImportRHYO set workFlag = 1 where isnull (workFlag,0) != 10
exec Import_RHYO  
*/
-----------------------------------------------