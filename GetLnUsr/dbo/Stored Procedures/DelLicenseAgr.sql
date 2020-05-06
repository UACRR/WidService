CREATE procedure dbo.DelLicenseAgr 
--------------------
--Удаление лиценщионного договора клиента по @licId
  @licId  integer
  AS   
  SET NOCOUNT ON;   --отключение вывода кол-ва строк для оптимизации
BEGIN
   declare @RetCode integer
   declare @ErrMsg varchar(200)
   set @RetCode = 0

--Проверка на наличие платежей клиента по договору
IF exists ( select 1 from MoneyPeriodLink t0 
              join LicenseAgreement t1 on t1.licId = t0.licId  and t1.licId = @licId )
 Begin 
   set @RetCode = 1
   set @ErrMsg = @ErrMsg + ' ' +'Виявлено платежі по договору!'
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

    delete licPlace where licId = @licId 
    delete license where licId = @licId 
    delete BrRegItem where licId = @licId 
    delete LicenseAgrParam where licId = @licId 
    delete Fixation where licId = @licId 

    delete MoneyPeriodLink where licId = @licId 
    delete PaidPeriod where licId = @licId 
    --условия оплаты: 
    delete LicAuthorBr 
       from LicAuthorBr t1  
       join  CopyRight t2 on t1.cRightId = t2.cRightId 
       join licenseBigR t3 on t2.objId = t3.objId

    delete LicenseBigR where licId = @licId 
    delete LicenseAgreement where licId = @licId 

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

--exec DelLicenseAgr 79
