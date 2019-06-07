--------------------
CREATE PROCEDURE [dbo].[DelCustomer]   
  @CustId  integer
  AS   
  SET NOCOUNT ON;   --отключение вывода кол-ва строк для оптимизации
BEGIN
   declare @RetCode integer
   declare @ErrMsg varchar(200)
   set @RetCode = 0

--Проверка на паблишер
IF exists ( select 1 from Customer t0  where t0.CustId = @CustId and isnull(ankPublish,0) = 1) 
 Begin 
   set @RetCode = 1
   set @ErrMsg = 'Признак Publisher!'
 end 

--Проверка на наличие остатков
IF exists ( select 1 from SaldoDay t0 join Account t1 on (t0.accId = t1.accId) 
              where t1.CustId = @CustId  and isnull(t0.rest,0) <> 0 ) 
 Begin 
   set @RetCode = 1
   set @ErrMsg = @ErrMsg + ' ' +'Виявлено операції по правовласнику!'
 end 

--Проверка на наличие заявок
IF exists ( select 1 from Request t0  where t0.CustId = @CustId ) 
 Begin 
   set @RetCode = 1
   set @ErrMsg = @ErrMsg + ' ' +'Виявлено заявки по клієнту!'
 end 

  If @Retcode <> 0 
   Begin 
     Set @ErrMsg = ' Операцію перевано!   '+ @ErrMsg 
	 RAISERROR
    (N'%s',
    10, -- Severity.
    1, -- State.
    @ErrMsg  -- First substitution argument.
     ); -- Second substitution argument.
    Return @RetCode
   end


begin tran 
	BEGIN TRY

        delete Account   where CustId = @CustId
		delete bankaccount where  custId = @custid 
		delete from account where custid = @custid
        delete CopyRight where custId = @custid
		delete AnketaAddNick where custId = @custid  
		delete AnketaPerson where custId = @custid 
		delete AnketaCompany where custId = @custid 

        delete relEmployee 
		  from relEmployee t1 join Employee t2 on t1.emplid = t2.emplId and t2.custId = @custId
		delete Employee where custId = @custId
		delete relEmployee where custId = @custId
		delete userRole where  custId = @custid  

		delete Person where custId = @custid 
		delete Company where custId = @custid 
		delete Community where custId = @custid 

		delete AgreementAddPartner 
		  from AgreementAddPartner t1 
         	   join agreementMaster t2 on t1.agrId = t2.agrId and t2.custId = @custId
		delete AgreementAddRH  
		 from AgreementAddRH t1 
		   join agreementMaster t2 on t1.agrId = t2.agrId and t2.custId = @custId
        delete AgreementAddBr 
		  from AgreementAddBr t1 
		  join agreementMaster t2 on t1.agrId = t2.agrId and t2.custId = @custId
--Возможно, будет удажено
		delete AgreementAddPartner where  custId = @custid  
		delete AgreementAddRH where  custId = @custid  
		delete AgreementAddBr where  custId = @custid  
		delete AgreementAddCommunity where  custId = @custid  
--Возможно, будет удажено
		delete ClnPlaceHoll 
		   from ClnPlaceHoll  t1 join clnBusinessPlace t2 on t1.placeId = t2.placeId where  t2.custId = @custid  
		delete ClnBusinessPlace where custId = @custid  

		delete CustCmRight where custId = @custid 
		delete TermsOfService where custId = @custid 
		delete territoryInclude where custId = @custid 
		delete territoryExclude where custId = @custid 
        delete AnketaAddParam where custId = @custid  

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
      delete license 
		   from license  t1 
		   join LicenseAgreement t2 on t1.licId = t2.licId  
		   where t2.custId = @custid 
      delete clnPlaceHoll 
		  from clnPlaceHoll t1 join ClnBusinessPlace t2 on t1.placeId = t2.placeId and t2.custId = @CustId
        delete ClnBusinessPlace where custId = @CustId
        delete LicenseAgrParam  
		   from LicenseAgrParam t1 
		    join LicenseAgreement t2 on t1.licId = t2.licId and t2.custId = @custId
        delete LicenseAgreement 
		  from LicenseAgreement t1 join AgreementMaster t2 on t1.agrId = t2.agrId and t2.custId = @CustId
		delete LicenseAgreement where custId = @CustId
		delete AgreementMaster where  custId = @custid  

		delete Client where  custId = @custid 
		delete RightHolder where custId = @custid 
		delete PartnerClient where custId = @custid  
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

--exec delCustomer 198