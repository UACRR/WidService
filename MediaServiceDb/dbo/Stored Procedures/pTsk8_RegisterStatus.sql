CREATE procedure [dbo].[pTsk8_RegisterStatus] 
as
begin
/*
--Установка статуса на отчете - виконано (status = 4).
*/
SET NOCOUNT ON;
declare @RetCode integer
set @RetCode = 0

declare @procName varchar(100) = 'pTsk8_RegisterStatus (' +convert(char(12), getdate())+')'
declare @name varchar(50) = 'Статус звіту <виконано> - '+convert(char(10), getdate())
 
  --Запись в журнал 
--   insert into SystemMessage (modifydate, nameMain, sysName, keyObj, text, name)  
--   select getdate(), 'StarDay', @procName, NULL, 'Встановлення статусу <ВИКОНАНО> по звіту', @name

  create table #tmpId (id integer not null primary key)

  BEGIN Transaction RegisterStatus
  BEGIN TRY

  update Register set rgStatus = 4 
  output inserted.regId into #TmpId (id) 
   from   Register t1 
    where isnull(rgStatus,0) = 3 
	 and exists (select 1 from PayTurn t2 where t2.regId = t1.regId )
   
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