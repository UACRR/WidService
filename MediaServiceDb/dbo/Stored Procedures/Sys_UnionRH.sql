CREATE PROCEDURE Sys_UnionRH @custIdForDel integer, @custIdMain integer
--Объединение анкет правообладателей
as
begin
SET NOCOUNT ON;
------
declare @RetCode integer 
set @RetCode = 0

    begin tran DEL
     BEGIN TRY

   update copyright  set custid = @custIdMain where custid = @custIdForDel
   print 'Замінено: copyright - ' + cast (@@rowcount as varchar(20))
   update Authors  set custid = @custIdMain where custid = @custIdForDel
   print 'Замінено: Authors - ' + cast (@@rowcount as varchar(20))

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

exec DelFullCustomer @custIdForDel

return @Retcode
END

--exec Sys_UnionRH 1, 2