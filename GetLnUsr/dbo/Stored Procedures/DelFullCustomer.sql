
/****** Object:  StoredProcedure [dbo].[DelFullCustomer]    Script Date: 18.07.2019 16:12:24 ******/
CREATE PROCEDURE [dbo].[DelFullCustomer]   
  @CustId  integer
  AS   
  SET NOCOUNT ON;   --отключение вывода кол-ва строк для оптимизации
BEGIN
----18-07-2019 счетчик
   declare @RetCode integer
   declare @ErrMsg varchar(200)
   set @RetCode = 0

begin tran 
	BEGIN TRY

	print 'CustId = '+cast(@custId as varchar(10))

--//Рахунки та платежі
		delete bankaccount where  custId = @custid 
                delete payturn 
                  from payturn t1 
                    join account t2 on t1.accIdCredit = t2.accId and t2.custId = @custId
		delete bankaccount where  custId = @custid 
                delete payturn 
                  from payturn t1 
                    join account t2 on t1.accIdDebet = t2.accId and t2.custId = @custId
		delete from account where custid = @custid
	--Отчеты
        delete MoneyPeriodLink 
           from MoneyPeriodLink t1 
            join  MoneyReceived t2 on t1.paidId = t2.paidId and t2.custId = @custId 
        delete MoneyReceived where custId = @custId 
        delete RegisterCount  where custId = @custId 
        delete RegisterCount  
           from RegisterCount t1 
            join Register t2 on t1.regId = t2.regId 
            join RegisterRatedList t3 on t2.rmId = t3.rmId
            join paidPeriod t4 on t4.periodId = t3.periodId and t4.custId = @custId
        delete DistributionItem 
           from DistributionItem t1 
            join Register t2 on t1.regId = t2.regId 
            join RegisterRatedList t3 on t2.rmId = t3.rmId
            join paidPeriod t4 on t4.periodId = t3.periodId and t4.custId = @custId
        delete Distribution 
           from Distribution t1 
            join Register t2 on t1.regId = t2.regId 
            join RegisterRatedList t3 on t2.rmId = t3.rmId
            join paidPeriod t4 on t4.periodId = t3.periodId and t4.custId = @custId

        delete RegisterAuthors
            from RegisterAuthors t1 
            join Register t2 on t1.regId = t2.regId 
            join RegisterRatedList t3 on t2.rmId = t3.rmId
            join paidPeriod t4 on t4.periodId = t3.periodId and t4.custId = @custId

        delete RegisterExtra
            from RegisterExtra t1 
            join Register t2 on t1.regId = t2.regId 
            join RegisterRatedList t3 on t2.rmId = t3.rmId
            join paidPeriod t4 on t4.periodId = t3.periodId and t4.custId = @custId

        delete RegisterItem
            from RegisterItem t1 
            join Register t2 on t1.regId = t2.regId 
            join RegisterRatedList t3 on t2.rmId = t3.rmId
            join paidPeriod t4 on t4.periodId = t3.periodId and t4.custId = @custId

        delete Register
            from Register t1 
            join RegisterRatedList t3 on t1.rmId = t3.rmId
            join paidPeriod t4 on t4.periodId = t3.periodId and t4.custId = @custId

        delete RegisterRatedList 
            from RegisterRatedList t1 
            join paidPeriod t4 on t4.periodId = t1.periodId and t4.custId = @custId

        delete paidPeriod where custId = @custId 
--//Конец удаления звітів по клиенту

--//Фиксация
       delete FixStorageDevice 
		  from FixStorageDevice t1 
		   join Fixation t2 on t1.fixId = t2.fixId and clientCustId = @CustId
	 
		delete FixFile
		  from FixFile t1 
		   join Fixation t2 on t1.fixId = t2.fixId and clientCustId = @CustId

		delete Fixation where clientCustId = @CustId
--//Конец Фиксация


        delete CopyRightHistory 
		  from CopyRightHistory t1 
		   join CopyRight t2 on t2.cRightId = t1.childId and t2.custId = @CustId
		   
        delete CopyRightHistory 
		  from CopyRightHistory t1 
		   join CopyRight t2 on t2.cRightId = t1.parentId and t2.custId = @CustId
   
        delete CopyRight where custId = @custid

		delete AnketaAddNick where custId = @custid  
		delete AnketaPerson where custId = @custid 
		delete AnketaCompany where custId = @custid 

        delete relEmployee 
		  from relEmployee t1 
                  join Employee t2 on t1.emplid = t2.emplId and t2.custId = @custId
		delete Employee where custId = @custId
		delete relEmployee where custId = @custId
		delete userRole where  custId = @custid  

		delete AgreementAddPartner 
		  from AgreementAddPartner t1 
         	   join agreementMaster t2 on t1.agrId = t2.agrId and t2.custId = @custId
		delete AgreementAddRH  
		 from AgreementAddRH t1 
		   join agreementMaster t2 on t1.agrId = t2.agrId and t2.custId = @custId
--//Ген.договора
		delete CustCmRight where custId = @custid 
		delete TermsOfService where custId = @custid 
		delete territoryInclude where custId = @custid 
		delete territoryExclude where custId = @custid 
                delete AnketaAddParam where custId = @custid  

        delete AgreementAddBr 
		  from AgreementAddBr t1 
		  join agreementMaster t2 on t1.agrId = t2.agrId and t2.custId = @custId
		delete AgreementAddPartner where  custId = @custid  
		delete AgreementAddRH where  custId = @custid  
		delete AgreementAddBr where  custId = @custid  
		delete AgreementAddCommunity where  custId = @custid  

		delete Person where custId = @custid 
		delete Company where custId = @custid 
--// Конец Ген.дог

--//Лицензии
      delete license 
		   from license  t1 
		   join LicenseAgreement t2 on t1.licId = t2.licId  
		   where t2.custId = @custid 

      delete license 
		   from license  t1 
		   join clnBusinessPlace t2 on t1.placeId = t2.placeId and t2.custId = @custid  

        delete LicAuthorBr 
            from LicAuthorBr t1 
                 join copyRight t2 on t1.cRightId = t2.cRightId 
            where  t2.custId = @custid 

	delete MusicalDesign 
		   from MusicalDesign t1 
		     join LicenseBigR t2 on t1.licId = t2.licId
			 join LicenseAgreement t3 on t2.licId = t3.licId 
		   where  t3.custId = @custid 

      delete LicenseBigR 
		  from LicenseBigR  t1 
		  join LicenseAgreement t2 on t1.licId = t2.licId  
		  where  custId = @custid 

        delete LicenseAgrParam  
		   from LicenseAgrParam t1 
		    join LicenseAgreement t2 on t1.licId = t2.licId and t2.custId = @custId
        delete LicenseAgreement 
		  from LicenseAgreement t1 join AgreementMaster t2 on t1.agrId = t2.agrId and t2.custId = @CustId
		delete LicenseAgreement where custId = @CustId
		delete AgreementMaster where  custId = @custid  

		delete ClnPlaceHoll 
		   from ClnPlaceHoll  t1 join clnBusinessPlace t2 on t1.placeId = t2.placeId where  t2.custId = @custid  
		delete ClnBusinessPlace where custId = @custid  

--// End Лицензии

 
        delete CustCmRight where custId = @CustId
        delete CustCmRight where cmCustId = @CustId
		delete FileCustomer where  custId = @CustId

		delete myCopyRightType where  custId = @custid 
		delete MyCategory where  custId = @custid 
		delete MyAnketa where  custId = @custid 

		delete PartnerClient where clCustId = @custid  
		delete PartnerClient where custId = @custid  
		delete Partner where custId = @custid  
		delete Client where  custId = @custid 
                delete Authors where custId = @custid 
		delete RightHolder where custId = @custid 
		delete Community where custId = @custid 
		delete AnketaExternal where custId = @custid 
		delete AnketaAddName where custId = @custid 

		delete customer where  custId = @custid 
		
		IF @@TRANCOUNT > 0 commit tran
	END TRY

BEGIN CATCH
  IF @@TRANCOUNT > 0 rollback tran
    set @RetCode = 1
    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;
    SELECT @ErrorMessage = ERROR_MESSAGE(),
           @ErrorSeverity = ERROR_SEVERITY(),
           @ErrorState = ERROR_STATE();

    -- Use RAISERROR inside the CATCH block to return 
    -- error information about the original error that 
    -- caused execution to jump to the CATCH block.
    RAISERROR (@ErrorMessage, -- Message text.
               @ErrorSeverity, -- Severity.
               @ErrorState -- State.
               );
END CATCH

  return @RetCode
END
--exec delFullCustomer 283
