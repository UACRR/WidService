 
CREATE  PROCEDURE [dbo].[Sys_PortalUserDelete] @email varchar(100)
--Объединение анкет правообладателей
as
begin
SET NOCOUNT ON;
------
declare @RetCode integer 
set @RetCode = 0

declare @custId integer = 0, @name varchar(254)

if REPLACE (isnull(@email,''), ' ','') = '' 
  Return @RetCode

 select @custId = t1.custId, @name = t1.name  
    from vcustomer t1 
       join AspNetUsers t2 on t2.id = t1.userId 
   where t2.email = @email  
 
    begin tran DEL
     BEGIN TRY

  update customer set userId = NULL where custId = @custId 
   delete aspNetUsers where email = @email

  print 'Анульовано реєстрацію на порталі:  - ' + @email+' '+@name
   
  insert into SystemMessage  (modifydate, nameMain, name, keyObj, text, sysname, custId) 
  select  getdate(), 'Works',  'Скасування реєстрації на порталі', @custId, 'Анульовано реєстрацію на порталі:  - ' + @email+' ' + isnull(@name,''), 'Sys_PortalUserDelete', @custId
  
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

return @Retcode
END

--exec Sys_PortalUserDelete 't.krapivianska@gmail.com'
--select * from AspNetUsers
--select * from vcustomer where userId = '212be82a-7f2e-4f9c-85a6-8abad81df932'  --3057
--select * from SystemMessage