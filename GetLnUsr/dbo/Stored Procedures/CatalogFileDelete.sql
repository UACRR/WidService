
create PROCEDURE [dbo].[CatalogFileDelete] @fileId integer, @result  varchar(100) OUT, @RetCode integer OUTPUT
as
begin
--26-09-2019. Удаление каталога
declare @cnt integer = 0
set @retCode = 0

 if exists (select  1 from CatalogFile where fileId = @fileId and status = 3 )
  BEGIN 
   set @result  = 'Операцію виконати неможливо - створено об''єкти права! Зверніться у підтримку!'
   set @RetCode = 1
   return @RetCode
  END
 

begin Transaction DeleteCatalogFile
       BEGIN TRY

 if exists (select  1 from CatalogFile where fileId = @fileId and rhType = 1 ) -- реестры авторов
 BEGIN 
 delete RHCatalogItem 
  where fileId = @fileId and status <> 3 
 set @cnt = @@ROWCOUNT
 END 

 if exists (select  1 from CatalogFile where fileId = @fileId and rhType = 3 ) -- каталоги издателей
 BEGIN 
 delete PubCatalogItem 
  where fileId = @fileId and status <> 3 
 set @cnt = @@ROWCOUNT
 END 


  delete CatalogFile where fileId = @fileId and status <> 3  

 set @result  = 'Вилучено '+cast(@cnt as varchar(10)) + ' записів.' 
 
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
          
set @result  = 'Операцію перервано! Зверніться у підтримку!'
set @Retcode = 1

END CATCH
return --@Retcode

END
/*
DECLARE @result VARCHAR(100), @RetCode integer;
exec CatalogFileDelete 2169, @result OUTPUT, @RetCode  OUTPUT
select @result, @retCode
*/
