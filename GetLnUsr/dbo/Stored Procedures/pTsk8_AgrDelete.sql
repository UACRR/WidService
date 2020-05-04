CREATE procedure [dbo].[pTsk8_AgrDelete]
as
begin
/*
--Вилучення договорів зі статусом 10
*/
SET NOCOUNT ON;
declare @RetCode integer
set @RetCode = 0

declare @date date 
set @date = isnull(@date, convert(date, getdate()))
declare @procName varchar(100) = 'pTsk8_AgrDelete'+' (' +convert(char(10), @date)+')'
declare @name varchar(50) = 'Вилучення договорів <вилучений> '+convert(char(10), @date)
declare @cntrRow integer, @cntrRow2 integer

 create table #TabLicId 
  (licId integer not null, 
   licVersion integer not null , 
   isLicFull smallint null,   --признак полного удаления договора
   custId integer not null, 
   isAnk smallint null, --признак удаления анкеты
   status integer null,  --для проставления статуса закрытия вместо удаления
  primary key (licId, licVersion)) 

 create table #TabAgrId 
  (agrId integer not null, 
   custId integer null, 
   agrType integer null, 
   isAnk smallint null, --признак удаления анкеты
   status integer null, --для проставления статуса закрытия вместо удаления
  primary key (agrId)) 

 create table #TabCust 
  (custId integer not null primary key)

set @cntrRow = ( select count(*) from LicenseAgrParam where isnull(licStatus,0) = 10 )
set @cntrRow2 = ( select count(*) from AgreementAddRH where isnull(agrStatus,0) = 10 )+ 
                ( select count(*) from AgreementAddCommunity where isnull(agrStatus,0) = 10 )+
				( select count(*) from AgreementAddPartner where isnull(agrStatus,0) = 10 )+
				( select count(*) from AgreementAddBR where isnull(agrStatus,0) = 10 )

PRINT @name+'. Всього ліц.дог. - '+ convert(char(10),@cntrRow) + 'Всього інших дог. - '+ convert(char(10),@cntrRow2)

  --Запись в журнал о начале
   insert into SystemMessage (modifydate, nameMain, sysName, keyObj, text, name)  
   select getdate(), 'StarDay', @procName, NULL, 
          @name+'. Всього ліц.дог. - '+ convert(char(10),@cntrRow) + 'Всього інших дог. - '+ convert(char(10),@cntrRow2)
		  , @name
 
 If @cntrRow = 0 and @cntrRow2 = 0
 return 0
------ Лицензии ----------
 delete #TabLicId
 insert into #TabLicId (licId, licVersion, custId) 
  select distinct t1.licId, t1.licVersion, t2.custId
   from LicenseAgrParam t1
    join LicenseAgreement t2 on t2.licId = t1.licId 
  where isnull(t1.licStatus,0) = 10 
   
--Проверка на удаление всего договора
;with TmpLic as 
(select t1.licId, t1.licVersion 
    from LicenseAgrParam t1 
     where t1.licStatus = 10 
	   and not exists (select 1 from LicenseAgrParam t2 where t1.licId = t2.licId and t1.licVersion <> t2.licVersion and t2.licStatus <> 10)
)
   update #TabLicId set isLicFull = 1 
    from #TabLicId t1 
	 join TmpLic t2 on t2.licId = t1.licId

--Проверка на удаление анкеты
;with TmpAnk as 
 (  select  distinct t1.custId  
    from LicenseAgreement t1 
	 join LicenseAgrParam t2 on t1.licId = t2.licId and t2.licStatus = 10 
	   and not exists
	     (select 1 from LicenseAgrParam t3 
	          join LicenseAgreement t4  on t4.licId = t3.licId 
			  where  t4.custId = t1.custId and t3.licStatus <> 10 )
	   and not exists (select  1 from AgreementMaster t7 where t7.custId = t1.custId and t7.agrId <> t1.agrId ) -- и нет др.договоров
  )
   update #TabLicId set isAnk = 1 
    from #TabLicId t1 
	 join TmpAnk t2 on t2.custId = t1.custId

------AgreementMaster---------
--Сначала  по LicenseAgreement  (с призн.полного договора)
  delete #TabAgrId 
  insert into #TabAgrId (agrId, custId, isAnk)
   select distinct t2.agrId, t1.custId, t1.isAnk
     from #TabLicId t1 
     join LicenseAgreement t2 on t2.licId = t1.licId and t1.isLicFull = 1 
	   and not exists (select 1 from LicenseAgreement t3 where t3.agrId = t2.agrId and t3.licId <> t2.licId)


--Помеченные 
  insert into #TabAgrId (agrId)
   select distinct agrId
     from AgreementAddBR t1 where t1.agrStatus = 10 
    
  insert into #TabAgrId (agrId)
   select distinct agrId
     from AgreementAddRH t1 where t1.agrStatus = 10 

  insert into #TabAgrId (agrId)
   select distinct agrId
     from AgreementAddPartner t1 where t1.agrStatus = 10 

  insert into #TabAgrId (agrId)
   select distinct agrId
     from AgreementAddCommunity t1 where t1.agrStatus = 10 

   update #TabAgrId 
	  set custId = t2.custId, agrType = t2.agrType 
	   from #TabAgrId t1 
	    join AgreementMaster t2 on t2.agrId = t1.agrId

--Проверку на полный договор не делаю - нет додатков, т.е. только одна запись д.б. в AgreementAdd...
--Проверка на удаление анкеты
  update #TabAgrId set isAnk = 1 
    from #TabAgrId t1 
	 where not exists ( select 1 from agreementMaster t2 where t2.custId = t1.custId and t2.agrId <> t1.agrId)
	   and not exists ( select  1 from LicenseAgreement t3 join LicenseAgrParam t4 on t3.licId = t4.licId 
	                     where t3.custId = t1.custId and t4.licStatus not in (10) )
------------------------------
--Удаляю анкеты 
delete #TabCust
insert into #TabCust (custId)
 select distinct custId from #TabAgrId where isAnk = 1
 union 
 select distinct custId from #TabLicId where isAnk = 1

IF (select count(*) from #TabCust ) > 0 
 BEGIN 
declare @custId integer
declare cur cursor  for  select custId from  #TabCust 
  open cur                                                   
    fetch cur into   @custId
                                                  
    while @@fetch_status = 0                                                   
    BEGIN 

--Перед удалением проверить - нет ли связей с реестром и платежами. Если есть - ставить "закрыто"
------------------------------
     If exists (select 1 from ExternalPay where custId = @custId ) --платежи
	   or exists (select 1 from PaidPeriod t1  join registerRatedList t2  on t1.periodId = t2.periodId  --отчеты
			 where t1.custId = @custId ) 
	   or exists (select 1 from account where custId = @custId )  --счета
	 Begin 
    --Запись в журнал об удалении анкеты
     insert into SystemMessage (modifydate, nameMain, sysName, keyObj, text, name)  
     select getdate(), 'StarDay', @procName, NULL, 
          'Закрито анкету - шифр '+ convert(varchar(20),@custId) + '  '+ t1.name
		  , @name
		 from vCustomer t1 where custId = @custId 
	 update Customer set status = 9 where custId = @custId
      END
     ELSE 
      BEGIN
    --Запись в журнал об удалении анкеты
     insert into SystemMessage (modifydate, nameMain, sysName, keyObj, text, name)  
     select getdate(), 'StarDay', @procName, NULL, 
          'Вилучено анкету - шифр '+ convert(varchar(20),@custId) + '  '+ t1.name
		  , @name
		 from vCustomer t1 where custId = @custId 
	 exec DelFullCustomer @custId
	  END
     if @@ERROR <> 0 
	  Return -1

     fetch cur into @custId
    END                                                   
close cur   
deallocate cur      
END 

------------------------------
delete #TabAgrId where isnull(isAnk,0) = 1
delete #TabLicId where isnull(isAnk,0) = 1
------------------------------
------------------------------
--Перед удалением проверить - нет ли связей с периодом. Если есть - ставить "закрыто"
------------------------------
     update #TabLicId set status = 4
	  from  #TabLicId t1 
	    join PaidPeriod t2 on t1.licId = t2.licId 
		join RegisterRatedList t3 on t3.periodId = t2.periodId

      update LicenseAgrParam set licStatus = 4 
	     from LicenseAgrParam t1 
		   join LicenseAgreement t3 on t3.licId = t1.licId and t3.licVersion = t1.licVersion
		   join #TabLicId t2 on t2.licId = t1.licId 
		   where t2.status = 4

      update LicenseAgreement set licStatus = 4 
	     from LicenseAgreement t1 
		   join #TabLicId t2 on t2.licId = t1.licId
		   where t2.status = 4
      
      set @cntrRow = (select count( distinct licId) from #TabLicId where isnull(isLicFull,0) <> 0 and status = 4)
      PRINT 'Закрито договорів = '+ convert(char(10), @cntrRow) 

   insert into SystemMessage (modifydate, nameMain, sysName, keyObj, text, name)  
   select getdate(), 'StarDay', @procName, NULL, 
          'Закрито договорів = '+ convert(char(10), @cntrRow) 
       , @name

    delete #TabLicId where status = 4

------------------------------
----Удаляю конкретные лицензионные договора
 begin Transaction DelAgreement
	BEGIN TRY

  delete License
    from License t1 
	   join #TabLicId t2 on t1.licId = t2.licId and t1.licVersion = t2.licVersion 

 delete LicenseAgrParam 
    from LicenseAgrParam t1 
	   join #TabLicId t2 on t1.licId = t2.licId and t1.licVersion = t2.licVersion 

 --Большие права
 delete MusicalDesign 
   from MusicalDesign t1 
    join #TabLicId t2 on t1.licId = t2.licId 

 delete RelObjPerformer 
    from RelObjPerformer t1 
    join LicenseBigR t3 on t3.objId = t1.objid
    join #TabLicId t2 on t2.licId = t3.licId 

 delete Authors 
    from Authors t1 
    join LicenseBigR t3 on t3.objId = t1.objid
    join #TabLicId t2 on t2.licId = t3.licId 

 delete LicAuthorBR 
   from LicAuthorBR t1 
   join CopyRight t3 on t3.cRightId = t1.cRightId
   join LicenseBigR t4 on t4.objId = t3.objid
   join #TabLicId t2 on t2.licId = t4.licId 

 delete WorkRH  
    from WorkRH t1 
	join  CopyRight t4 on t4.cRightId = t1.cRightId 
    join LicenseBigR t3 on t3.objId = t4.objid
	 join #TabLicId t2 on t2.licId = t3.licId

 delete CopyRight 
    from CopyRight t1 
    join LicenseBigR t3 on t3.objId = t1.objid
	 join #TabLicId t2 on t2.licId = t3.licId

 delete LicenseBigR 
   from LicenseBigR t1
    join #TabLicId t2 on t1.licId = t2.licId 

 delete ObjectRight 
   from ObjectRight t1 
    join LicenseBigR t3 on t3.objId = t1.objId
    join #TabLicId t2 on t2.licId = t3.licId 

 delete LicenseAgreement 
   from LicenseAgreement t1 
    join #TabLicId t2 on t1.licId = t2.licId and t2.isLicFull = 1

set @cntrRow = (select count( distinct licId) from #TabLicId where isnull(isLicFull,0) <> 0 )
set @cntrRow2 = (select count(*) from #TabAgrId )
PRINT 'Вилучено договорів = '+ convert(char(10), @cntrRow) + 
       '   Вилучено додатків = '+ cast(@cntrRow2 as varchar(20)) 

   insert into SystemMessage (modifydate, nameMain, sysName, keyObj, text, name)  
   select getdate(), 'StarDay', @procName, NULL, 
          'Вилучено договорів = '+ convert(char(10), @cntrRow) + 
       '   Вилучено додатків = '+ cast(@cntrRow2 as varchar(20)) 
       , @name

------Удаляю договора из Agreement с сохранением анкеты и других договоров

---ПРоверяю - можно ли удалить или закрыть 
   --Были реестры
   update #TabAgrId set status = 4 
     from #TabAgrId t1 
	   join paidPeriod t2 on t2.custId = t1.custId 
	   join RegisterRatedList t3 on t3.periodId = t2.periodId

   --Были платежи
    update #TabAgrId set status = 4 
     from #TabAgrId t1,  
	      Account t2 
	where t2.custId = t1.custId 
	   and exists ( select 1 from SaldoDay t3 where t3.accId = t2.accId )

    update AgreementMaster set agrStatus = 4 
	   from AgreementMaster t1 
	      join #TabAgrId t2 on t2.custId = t1.custId 
		  and t2.status = 4

    delete #TabAgrId where status = 4

------------------------------------------------
---Удаляю правообладателя
 delete CustCmRight 
    from CustCmRight  t1 
	  join #TabAgrId t2 on t1.custId = t2.custId  and agrType in (1,5)  --автори та видавництва

 delete TermsOfService 
    from TermsOfService  t1 
	  join #TabAgrId t2 on t1.custId = t2.custId and agrType in (1,5)
 
 delete TerritoryInclude 
    from TerritoryInclude  t1 
	  join #TabAgrId t2 on t1.custId = t2.custId and agrType in (1,5)
 
 delete TerritoryExclude 
    from TerritoryExclude  t1 
	  join #TabAgrId t2 on t1.custId = t2.custId and agrType in (1,5)

 delete Copyright  
    from Copyright   t1 
	  join #TabAgrId t2 on t1.custId = t2.custId and agrType in (1,5)

  delete AgreementAddRH  
    from AgreementAddRH   t1 
	  join #TabAgrId t2 on t1.agrId = t2.agrId and agrType in (1,5)
 
 delete Community  
    from Community   t1 
	  join #TabAgrId t2 on t1.custId = t2.custId and agrType = 4

 delete AgreementAddCommunity
    from AgreementAddCommunity   t1 
	  join #TabAgrId t2 on t1.agrId = t2.agrId and agrType in (4)

 delete RightHolder  
    from RightHolder   t1 
	  join #TabAgrId t2 on t1.custId = t2.custId and agrType in ( 1,4,5) --4 на всякий случай

 delete PartnerClient  
    from PartnerClient   t1 
	  join #TabAgrId t2 on t1.custId = t2.custId and agrType in ( 1,4,5) --4 на всякий случай

  delete AgreementAddPartner
    from AgreementAddPartner   t1 
	  join #TabAgrId t2 on t2.agrId = t1.agrId and t2.agrType in ( 3) --4 на всякий случай

 delete Partner
    from Partner   t1 
	  join #TabAgrId t2 on t2.custId = t1.custId and t2.agrType in ( 3) --4 на всякий случай

  delete PartnerClient  
    from PartnerClient   t1 
	  join #TabAgrId t2 on t2.custId = t1.clCustId and t2.agrType in ( 2) 

  delete LicenseAgreement 
    from LicenseAgreement t1 
	 join AgreementAddBR  t2 on t2.agrId = t1.agrId 
	 join #TabAgrId t3 on t3.custId = t1.custId and t3.agrType in ( 2) 
	 where not exists ( select 1 from LicenseAgreement t4 where t4.custId = t3.custId and t4.licStatus not in (0,9,1,10)) --странно

  delete AgreementAddBR  
    from AgreementAddBR   t1 
	  join #TabAgrId t2 on t2.agrId = t1.agrId and t2.agrType in ( 2) 
    where not exists ( select 1 from LicenseAgreement t3 where t3.custId = t2.custId and t3.licStatus not in (0,9,1,10)) --странно

---------------------------

------Удаляю из AgreementMaster
--Связанные в AgreementMaster, если удаляется полный договор
 delete AgreementMaster 
   from AgreementMaster t1
     join #TabAgrId t3 on t3.agrId = t1.agrId 
	 and not exists (select  1 from agreementAddRH t4 where t4.agrId = t3.agrId) 
	 and not exists (select  1 from agreementAddPartner t5 where t5.agrId = t3.agrId) 
	 and not exists (select  1 from AgreementAddCommunity t6 where t6.agrId = t3.agrId) 
	 and not exists (select  1 from AgreementAddBR t7 where t7.agrId = t3.agrId) 
---------------------------



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

END CATCH
return @Retcode
END

--exec pTsk8_AgrDelete
--select * from SystemMessage
/*
select * from vCustomer where custid = 1391
select * from LicenseAgreement where licStatus = 10
*/
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pTsk8_AgrDelete] TO [ReportUser]
    AS [dbo];

