CREATE procedure [dbo].[MPPay_#DDEX]  @regId int
as
begin
SET NOCOUNT ON;
declare @Distid int
declare @Retcode int
set @Retcode = 0
--select @Distid = distid from distribution 
--where  regId = @regid
--and status = 1
if ((select count(*)  from  distribution
		where  regId = @regid and status = 1) = 0)
		return 0
BEGIN
begin Transaction 
BEGIN TRY
declare  ccc cursor for select distid from distribution where regId = @regid and status = 1
order by distid
open ccc
fetch ccc into @Distid 

while @@fetch_status =0 
BEGIN        ---------1
--select @distid
exec [MPPay2_D301_2_K22__#DDEX] @Distid 
exec [MPPay3_D21_2_K301_#DDEX]
fetch ccc into @Distid 
END         ----------1
close ccc   
deallocate ccc 
update Register set rgStatus =4
where regId = @regid

IF @@TRANCOUNT > 0 commit tran
return 0  

END TRY

BEGIN CATCH
  IF @@TRANCOUNT > 0 rollback tran
begin
SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_SEVERITY() AS ErrorSeverity  
        ,ERROR_STATE() AS ErrorState  
        ,ERROR_PROCEDURE() AS ErrorProcedure  
        ,ERROR_LINE() AS ErrorLine  
        ,ERROR_MESSAGE() AS ErrorMessage;  set @Retcode = 1
end
END CATCH
return 0
END
end
