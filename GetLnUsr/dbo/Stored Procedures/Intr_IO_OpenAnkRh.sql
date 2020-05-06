
CREATE PROCEDURE Intr_IO_OpenAnkRh 
as
begin

--Открытие правообладателей с анкетой и договором
SET NOCOUNT ON;
declare @RetCode integer
set @RetCode = 0

create table #TmpRH 
(id integer not null identity, 
 rhName  varchar(200), 
 cmFlag integer, --1-наш 
 custId integer, 
 cmCustId integer, 
 innerCode varchar(25), 
 interCode varchar(25), 
 primary key (id) )

 delete #TmpRH 

---------------------------------------
----Контроль
----Авторы уже есть
 update LOADS..ImportObject set custid = t2.custid 
    from LOADS..ImportObject t1 
	   join vCustomer t2 on Replace(t1.authorName,' ','') = Replace(t2.name,' ','') collate Ukrainian_100_CI_AS
     where isnull(workFlag,0) = 1 
          and isnull(errFlag,0) = 0 
          and isnull(t1.custId,0) = 0 

---------------------------------------
----- Для открытия правообладателей ------
insert into #TmpRH ( rhName, cmFlag, cmCustId, interCode, innerCode) 
select  authorNameOpen, max(isnull(cmFlag,0)) as cmFlag, max(cmCustId),  max(ipi), max(authorInnerCode)
  from LOADS..ImportObject   
   where isnull(roleCode,0)<>3 
         and isnull(custId,0) = 0
         and isnull(folkType,0) not in (2,3) 
         and isnull(workFlag,0) = 1  --открываю только помеченные
         and isnull(errFlag,0) = 0   --нет ошибок
  group by authorNameOpen

--drop table #TabId
create table #TabId (custId integer not null)

declare @id integer, @custId integer, @idp varchar(10), @cmFlag integer
declare cur cursor for  select id from #TmpRH  where isnull(custid,0) = 0  --and id in (101110,100310) ---and cmFlag = 1  --не исполнители свои

open cur                                                   

    fetch cur into   @Id
                                                  
    while @@fetch_status = 0                                                   
    BEGIN 

     begin Tran Intr1 
     BEGIN TRY

     delete #TabId 

     set @idp = convert(char(4),@id)
	 print @idp

       set @cmFlag = (select max(cmFlag) from #TmpRH  where id = @id)

       --Вставляю новые
       insert into customer (custType, status, ankVersion)
         output inserted.custId  into #TabId (custId)
         select  (Case @cmFlag When 1 Then 1 Else 5 end ) -- физлицо или внешний правообладатель, 
                 , 0, 1 
           from #TmpRH 
		   where id = @id

       set @custId = (select max(custId) from #TabId )

        update #TmpRH 
             set custId = @custId 
             where id = @id  

      insert into RightHolder (custId, rHolderType, aroundWord, innerCode, interCode) 
		 select custId,  1, 1, innerCode, interCode
		   from #TmpRH t1  
		   where id = @id 

    IF @cmFlag = 1 --наш
     BEGIN

	   insert into Person (custId, version)
	   select @custId, 1

       insert into AnketaPerson 
		(custId, version, status, 
		 lastName, firstName, surName,
		 citizenship, residency, reCountry, faCountry, 
		 modifyDate,modifyLogin )
         select  t1.custId, 1, 0, 
                 --ФИО
                 (select dbo.ParseStr (t1.rhName, ' ', 1)), 
                 (select dbo.ParseStr (t1.rhName, ' ', 2)), 
                 (select dbo.ParseStr (t1.rhName, ' ', 3)), 
		 (Case cmFlag When 1 Then 804 else NULL end ), --citizenship
		 (Case cmFlag When 1 Then 1 else NULL end ),   --residency
		 (Case cmFlag When 1 Then 804 else NULL end ), --reCountry
		 (Case cmFlag When 1 Then 804 else NULL end ), --faCountry
		 getdate(), 'Input_3'
		  from #TmpRH t1 
			 where id = @id

	--Договор с правовласником (для нашего comminity)
	insert into AgreementMaster (custId, agrStatus, modifyDate, modifyLogin, agrType, version)
		select @custId, 0, getdate(), 'input_3', 
                       1, 
                       1
                   from #TmpRH 
  		   where id = @id 

        insert into AgreementAddRH 
	    (agrId, custId, rateCommiss, rateCourt, version,agrNumber,agrDate, dateBegin, dateEnd, periodCode, dayForPay, ankVersion, agrStatus, getCode, modifyDate,modifyLogin)
		select t2.agrId, t1.custId, NULL, NULL,  
			   1, 
			   --'Tech3-'+convert(varchar(10), t2.custId),  
			    'T/'+isnull(innerCode, convert(varchar(10), t2.custId)),  
			    cast(getdate() as date), 
                           cast(getdate() as date), '3000-01-01', 
			   1, 20, 1, 0, NULL, getdate(), 'Input_3'
		   from #TmpRH t1  
		    join AgreementMaster t2 on t1.custId = t2.custId 
		   where t1.id = @id 

   END 

  ELSE 
---Чужие правовласники (из др.сообщества)
    BEGIN 
      insert into AnketaExternal (custId,name, countryCode, innOkpo)
         select  t1.custId, t1.RhName, NULL, NULL
		  from #TmpRH t1 
			 where id = @id

    END 

    --Права 
    insert into TermsOfService (custId, crKindCode, ourService) 
		   select  @custId, t1.codeI, (Case  @cmFlag WHEN 0 Then 0 Else 1 END)
		    from CopyrightKind t1

    --Сообщества
    insert into CustCmRight (custid, crKindCode, cmCustId, dateBegin, dateEnd) 
      select t1.custid, t2.codeI, t1.cmCustid, getdate(), '3000-01-01'
         from #TmpRH t1 
              left outer join CopyRightKind t2 on t2.codeI > 0 
        where t1.id = @id  
              and isnull(t1.cmCustid,0) <> 0 
              and isnull(t1.custId,0) <> 0 
              and isnull(@cmFlag,0) <> 1
              
   --Проставляю ключи CustId
    update LOADS..ImportObject set custId = @custId
	     from LOADS..ImportObject t1 
		 join #TmpRH t2 on t1.authorNameOpen = t2.rhName
        	      and t2.id = @id

----------------------------------------------------
  set  @idp = cast(@custId as varchar(10)) 
  print @idp
----------------------------------------------------

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

--exec Intr_IO_OpenAnkRh 
 
