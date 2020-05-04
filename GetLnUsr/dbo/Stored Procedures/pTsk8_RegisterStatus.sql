
CREATE procedure [dbo].[pTsk8_RegisterStatus] 
as
begin
/*
--Установка статуса на отчете - виконано (status = 4). 05-08-2019 - на расчетном листе - виконано
--09-09-2019 - По статусу 7
*/
SET NOCOUNT ON;
declare @RetCode integer
set @RetCode = 0

declare @procName varchar(100) = 'pTsk8_RegisterStatus (' +convert(char(12), getdate(),104)+')'
declare @name varchar(50) = 'Статус звіту <виконано> - '+convert(char(10), getdate(), 104)
 
  --Запись в журнал 
--   insert into SystemMessage (modifydate, nameMain, sysName, keyObj, text, name)  
--   select getdate(), 'StarDay', @procName, NULL, 'Встановлення статусу <ВИКОНАНО> по звіту', @name

  create table #tmpId (id integer not null primary key)

  BEGIN Transaction RegisterStatus
  BEGIN TRY

--Виконано отчет
--Если период закрыт и есть в оплаченных
--Большие права и малые схема = 2 - переводить в выполненные без перехода периода в 7 (periodStatus = 7) и все распределено
--малые схема = 1 - переводить, если periodStatus = 7 и все распределено
  update Register set rgStatus = 4 
  output inserted.regId into #TmpId (id) 
    from Register t1 
          join vregister t3 on t1.regId = t3.regId 
          join PaidPeriod t4 on t3.periodId = t4.periodId and isnull(t4.undistribamount,0) = 0  --02-12-22019
    where isnull(t1.rgStatus,0) = 7 --3 09-09-2019
	      and exists ( select 1 from PayTurn t2 where t2.regId = t1.regId )  --есть оплаченные по отчету
		  and ((t3.periodStatus = 7 and t3.schemaId = 1) or (isnull(t3.schemaId,0) <> 1 ) )     --02-12-2019
  
  IF @@ROWCOUNT <> 0 
  --Запись в журнал
   BEGIN 
   insert into SystemMessage (modifydate, nameMain, sysName, keyObj, text, name, custId) 
   select getdate(), 'WORKSDay', @procName, t1.id, 
       'Звіт ВИКОНАНО -  (Шифр - '+ rtrim(ltrim(convert(char(20),t1.Id))) +')'+' Файл звіту - '+ isnull(t2.fileName, 'б/ф')+ '   '+t3.name, 
        @name, t2.custId
      from #TmpId t1
         join vRegister t2 on t2.regId = t1.id 
	 join vcustomer t3 on t3.custId = t2.custId
    END 
	
 PRINT 'Update Register Status = '+ convert(char(10), @@ROWCOUNT) 

 --Виконано расчетный лист
  update  registerRatedList set status = 3 
    from registerRatedList t1 
	  where not exists (select  1 from register t2 where t2.rmId = t1.rmId and  isnull(t2.rgStatus,0) <> 4 )

--Закрыть период, если все это не схема 1 или 3
/*
  update PaidPeriod set status = 7 --закрыт
   from PaidPeriod t1 
     join vRegister t2 on t1.periodId = t2.periodId
  where t1.status <> 7 and t1.undistribamount = 0 and t1.distribamount = t1.amount and t2.schemaId not in (1,3)
    and not exists (select 1 from RegisterRatedList t2 where t2.periodId = t1.periodId and t2.status <> 3 )
*/


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

--exec pTsk8_RegisterStatus 
/*
select * from SystemMessage
*/
