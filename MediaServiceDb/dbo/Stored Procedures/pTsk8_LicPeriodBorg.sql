CREATE procedure [dbo].[pTsk8_LicPeriodBorg] (@date date = NULL)
as
begin
/*
--Установка признака "Борг" на периоде (status = 3). 
--Устанавливается, если amount - undistribamount - distribamount <> 0 и разница @date и конца периода ( dateEnd ) больше месяца  25-06-2019 (было по undistribamount<>0)
--@date = NULL - getdate()
*/
SET NOCOUNT ON;
declare @RetCode integer
set @RetCode = 0

set @date = isnull(@date, convert(date, getdate()))

declare @procName varchar(100) = 'dbo.pTsk8_LicPeriodBorg (' +convert(char(10), @date)+')'
declare @name varchar(50) = 'БОРГ періоду розрахунку - '+convert(char(10), @date)
 
--PRINT 'Update Period Borg'

  --Запись в журнал 
   insert into SystemMessage (modifydate, nameMain, sysName, keyObj, text, name)  
   select getdate(), 'StarDay', @procName, NULL, 'Встановлення статусу <БОРГ> періоду розрахунку', @name

  create table #PeriodId 
   (id integer not null, 
    licId integer not null,
	custId integer not null
    primary key (id)) 

  BEGIN Transaction PeriodBorg
  BEGIN TRY

 update PaidPeriod set status = 3 
 output inserted.periodId, inserted.licId, inserted.custId into #PeriodId (id, licId, custId)
-- select datediff( month, t1.endDate, getdate() ),*
 from  PaidPeriod t1 
  join LicenseAgreement t2 on t1.licId = t2.licId and t2.licStatus = 2 
  where t1.endDate < getdate() 
        and (amount - undistribamount - distribamount) <> 0
        and  datediff( month, t1.endDate, getdate()) > 1
        and t1.status <> 3  --возможно добавить 7

  IF @@ROWCOUNT <> 0 
  --Запись в журнал
   BEGIN 
   insert into SystemMessage (modifydate, nameMain, sysName, keyObj, text, name) 
   select getdate(), 'StarDay', @procName, NULL, 'Всього  - '+ convert(char(10), (select count(*) from #PeriodId) ), @name

   insert into SystemMessage (modifydate, nameMain, sysName, keyObj, text, name, custId) 
   select getdate(), 'StarDay', @procName, t1.id, 
     (Case when len(t2.periodName)<35 then convert(char(30),t2.periodName) ELSE t2.periodName end )+'	'+
	 'Дог.№'+isnull(t5.licNum,'')+';  '+ 
	 '  Заборгованість '+ ltrim(convert(char(20), convert(money,t2.undistribAmount))) + '  (Шифр - '+ rtrim(ltrim(convert(char(20),t1.Id))) +')', 
        @name, t1.custId
      from #PeriodId t1
         join PaidPeriod t2 on t1.id = t2.periodId 
	 join vcustomer t3 on t3.custId = t2.custId
         join LicenseAgreement t4 on t1.licId = t4.licId 
         join LicenseAgrParam t5 on t5.licId = t4.licId and t5.licVersion = t4.licVersion
    END 

 PRINT 'Update Period Borg count = '+ convert(char(10), @@ROWCOUNT) 

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

--exec dbo.pTsk8_LicPeriodBorg
/*
delete SystemMessage
select * from SystemMessage
select * from PaidPeriod where periodId in (1201,1208,1221)
update PaidPeriod set status = 2 where periodId in (1201,1208,1221)
--exec dbo.pTsk8_StartDay
*/
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pTsk8_LicPeriodBorg] TO [ReportUser]
    AS [dbo];

