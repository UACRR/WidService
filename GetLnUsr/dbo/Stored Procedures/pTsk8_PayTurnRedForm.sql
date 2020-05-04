CREATE procedure [dbo].[pTsk8_PayTurnRedForm] (@date date = NULL)
as
begin
--Пересчет таблицы PayTurnRed (для отчетности по дораспределению)
SET NOCOUNT ON;
declare @RetCode integer, @cnt integer
set @RetCode = 0

set @date = isnull(@date, convert(date, getdate()))

  BEGIN Transaction PayTurnRed
  BEGIN TRY

 DELETE dbo.PayTurnRed
 exec dbo.PayTurnRedForm

 set @cnt = (select count(*) from PayTurnRed)
 PRINT 'REBUILD PayTurnRedForm = '+ convert(char(10), @cnt ) 

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

--EXEC pTsk8_PayTurnRedForm
