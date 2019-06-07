CREATE procedure [dbo].[DelAgreement] 
--------------------
--Удаление генеральных договоров клиента по @agrId
  @agrId  integer, 
  @CustId  integer
  AS   
  SET NOCOUNT ON;   --отключение вывода кол-ва строк для оптимизации
BEGIN
   declare @RetCode integer
   declare @ErrMsg varchar(200)
   set @RetCode = 0

--Проверка на наличие остатков
IF exists ( select 1 from MoneyPeriodLink t0 
              join LicenseAgreement t1 on t1.licId = t0.licId  and t1.licClass = 1 and t1.agrId = @agrId )
 Begin 
   set @RetCode = 1
   set @ErrMsg = @ErrMsg + ' ' +'Виявлено платежі по договору!'
 end 

IF exists ( select 1 from LicenseAgreement t0 where t0.agrId = @agrId and t0.licClass <> 1   )
 Begin 
   set @RetCode = 1
   set @ErrMsg = @ErrMsg + ' ' +'Виявлено ліцензійні угоди по головному договору!'
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

       delete AgreementAddBR where agrId = @agrId
       delete AgreementAddCommunity where agrId = @agrId
       delete AgreementAddRH where agrId = @agrId
       delete AgreementAddPartner where agrId = @agrId
       delete LicenseAgreement where agrId = @agrId and licClass = 1 
	   
     IF @@TRANCOUNT > 0 
           commit tran

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

--exec DelAgreement 198