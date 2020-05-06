
CREATE PROCEDURE SYS_UnBindPayment @custId integer, @docNum varchar(100), @docDate date
as
begin

-----Процедура отвязки платежа от клиента

SET NOCOUNT ON;
declare @RetCode integer = 0, @paidId integer 

create table #TmpId 
(paidId integer not null primary key) 

--declare @custId integer = 44402, @docNum varchar(100) ='271', @docDate date = '2019-10-30'
insert into #TmpId  (paidId) 
select paidid from ExternalPay 
where custid = @custId and docNum = @docNum and docDate = @docDate 

if exists (select count(*) from #TmpId  having count(*) > 1 )
 BEGIN 
  Print 'Більше одного запису! Обробка не можлива!' 
  set @RetCode  = 1 
  RETURN @Retcode 
END 

set @paidId = (select max(paidId) from #TmpId)

--проверяю, что не привязано к договору и периоду
if exists 
(select 1 
 from MoneyPeriodLink 
    where paidId = @paidId 
 ) 
 BEGIN 
  Print 'Виконано розподіл! Обробка не можлива!' 
  set @RetCode  = 1 
  RETURN @Retcode 
END 

BEGIN TRANSACTION Del_MoneyReceived
 BEGIN TRY

update ExternalPay set custId = NULL 
  where paidId = @paidId
delete from MoneyReceived where paidId = @paidId

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

PRINT 'Виконано - PaidId = '+convert(varchar(10),@paidId) 
return @Retcode
END

--exec SYS_UnBindPayment 44402, '271', '2019-10-30'


