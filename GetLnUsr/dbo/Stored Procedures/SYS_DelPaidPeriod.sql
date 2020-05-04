--------------------
CREATE PROCEDURE [dbo].[SYS_DelPaidPeriod]  @periodid integer 
--Удаление периода со всеми отчетами и расчетными листами и распределением ДО ОПЛАТЫ 
  AS   
  SET NOCOUNT ON;   
BEGIN
   declare @RetCode integer
   declare @MsgStr varchar(200)
   set @RetCode = 0


--Проверка на наличие проводок по отчету
IF exists ( 
 select 1 
   from vRegister t1  
   where periodId = @periodid 
   and exists (select  1 from PayTurn t2 where t1.regId = t2.regId) 
) 
 Begin 
   set @RetCode = 1
   set @MsgStr = isnull(@MsgStr,'') + ' ' +'Відбулась оплата звіту - вилучити період не можливо! '
 end 

--если ли такой период
IF not exists ( 
 select 1 
   from PaidPeriod t1  
   where periodId = @periodid 
) 
 Begin 
   set @RetCode = 1
   set @MsgStr = isnull(@MsgStr,'') + ' ' +'Відсутній період! '
 end 


  If @Retcode <> 0 
   Begin 
     Set @MsgStr = ' Операцію перевано!   '+ isnull(@MsgStr,'')
	 RAISERROR
    (N'%s',
    10, -- Severity.
    1, -- State.
    @MsgStr  -- First substitution argument.
     ); -- Second substitution argument.
    Return @RetCode
   end

create table #TmpRegister 
(regId integer not null primary key)

  insert into #TmpRegister  (regid) 
  select regId 
  from vRegister where periodId = @periodId 


begin tran 
	BEGIN TRY

----Распределение периода
  delete RegisterCount 
    from  RegisterCount t1 
	    join #TmpRegister t2 on t1.regId = t2.regId 

  delete DistributionItem 
    from  DistributionItem t1 
 	    join #TmpRegister t2 on t1.regId = t2.regId 

 delete Distribution
    from  Distribution t1 
 	    join #TmpRegister t2 on t1.regId = t2.regId 

---Отвязать деньги
   delete MoneyPeriodLink 
     where periodId = @periodid

----Отчеты периода
    delete RegisterCCIDAuthor 
	   from RegisterCCIDAuthor  t1 
	     join #TmpRegister t2 on t1.regId = t2.regId 

    delete RegisterCCIDMW 
	   from RegisterCCIDMW  t1 
	     join #TmpRegister t2 on t1.regId = t2.regId 

    delete RegisterCCID
	   from RegisterCCID t1 
	     join #TmpRegister t2 on t1.regId = t2.regId 

     delete RegisterItem
	   from RegisterItem  t1 
	     join #TmpRegister t2 on t1.regId = t2.regId 

    delete Register
	   from Register t1 
	     join #TmpRegister t2 on t1.regId = t2.regId 

    delete RegisterRatedList
	   from RegisterRatedList t1 
	     join paidPeriod t2 on  t2.periodId = @periodId and t1.periodId = t2.periodId

    delete PaidPeriod 
	 where periodId = @periodId 

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

  set @MsgStr = isnull(@MsgStr,'') + convert(varchar(10), (select count(*) from #TmpRegister))+' - вилучено звітів періоду!'
  
  print @MsgStr
  
  return @RetCode
END

--exec SYS_DelPaidPeriod 6923
--select * from vRegister where regid = 1375
--select * from PaidPeriod
commit