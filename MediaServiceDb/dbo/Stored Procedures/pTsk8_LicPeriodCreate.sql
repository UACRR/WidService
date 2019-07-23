CREATE procedure [dbo].[pTsk8_LicPeriodCreate] (@date date = NULL)
as
begin
/*
--@date - поточна дата по замовченню
--Створення періодів договорів для договорів у статусі "активний"
--10-06-2019 --схема 2 формируется без учета суммы договора
*/
SET NOCOUNT ON;
declare @RetCode integer
set @RetCode = 0

set @date = isnull(@date, convert(date,getdate()))
declare @procName varchar(100) = 'dbo.pTsk8_LicPeriodCreate (' +convert(char(10), @date)+')'
declare @name varchar(50) = 'Створення періодів розр. - '+convert(char(10), @date)


--drop table #PaidPeriod
create table #PaidPeriod (
   periodId             int                  identity,
   licId                integer              not null,
   custId               integer              not null,
   periodType           integer              not null,
   beginDate            date                 not null,
   endDate              date                 not null,
   status               int                  not null,
   amount               money                not null,
   undistribamount      money                not null,
   distribamount        money                not null,
   periodName           varchar(100)         not null,
   fagFirst             bit                  null,
   dateActPrint         date                 null,
   lastDateEnd          date                 null, --последняя дата периода
   firstDatePeriod      date                 null, 
   primary key (periodId) 
   )

--declare @date date = convert(date, getdate())
delete #PaidPeriod 

--Отбираю активные лицензии, срок действия которых не истек
--Если схема 2 - не беру сумму по договору
;with TabLic as 
 (select  t1.custId, t1.licId, isnull(t2.dateBegin, '2018-01-01') as dateBegin, 
   isnull(t2.dateEnd, '3000-01-01') as dateEnd,  (Case When isnull(t3.schemaId,0) <> 2 Then isnull(minAmount,0) ELSE 0 END) as minAmount, 
   isnull(periodCode,1) as periodCode
   from LicenseAgreement t1 
        join LicenseAgrParam t2 on t1.licId = t2.licId and t1.licVersion = t2.licVersion 
		join AgrLicenseType t3 on t3.codeI = t1.licCode
     and t1.licStatus = 2 and isnull(t2.dateBegin,'1900-01-01') <= @date 
	 and isnull(t2.dateEnd,'3000-01-01') >= @date
	 and isnull(t1.licClass,0) in (0,1)
  ), 
TabLastPeriod as 
(select licId, max(endDate) as endDate
  from PaidPeriod 
  group by licId
)
 insert into #PaidPeriod 
   (custId, periodType, licId, 
    beginDate, endDate, 
    status, amount, distribamount, undistribamount, 
    periodName, 
    lastDateEnd )
  select t1.custId, t1.periodCode, t1.licId, 
         (CASE WHEN t1.periodCode = 5 Then dbo.fs_PeriodBegin (t1.periodCode, dateBegin) ELSE dbo.fs_PeriodBegin(t1.periodCode, @date) END ) as dateBegin, 
         (CASE WHEN t1.periodCode = 5 Then dbo.fs_PeriodEnd (t1.periodCode, dateEnd) ELSE dbo.fs_PeriodEnd(t1.periodCode, @date) END ) as dateEnd, 
         1 as status, isnull(t1.minAmount,0), 0, 0, 
         dbo.fs_PeriodName(t1.periodCode, @date) + 
		       (Case WHEN t1.periodCode = 5 Then convert(char(10),t1.dateBegin,104)+'-'+convert(char(10),t1.dateEnd,104) Else '' END) as periodName, 
	     t5.endDate
	   from TabLic t1 
    	   left join TabLastPeriod t5 on t5.licId = t1.licId 

--Удаляю, у которых уже есть такой период
  DELETE #PaidPeriod where endDate <= lastDateEnd 

--Проставляю признак первого периода - по наличию в таблице периодов
 update #PaidPeriod set fagFirst = 1 
   from #PaidPeriod t1 
   where not exists ( select  1 from PaidPeriod t2 where t1.licId = t2.licId)

--select * from #PaidPeriod

  declare @rowCnt integer = (select count(*) from #PaidPeriod)

  PRINT 'Creation Period count = '+ convert(char(10), @rowCnt) 

  --Запись в журнал 
   insert into SystemMessage (modifydate, nameMain, sysname, keyObj, text, name )  
   select getdate(), 'StarDay', @procName, NULL, 'Створення періодів розрахунку. Всього - '+ convert(char(10), @RowCnt), @name

  if @rowCnt = 0 
  return 0 

 begin Transaction CreaPeriod
	BEGIN TRY
  insert into PaidPeriod 
   (custId, periodType, licId, beginDate, endDate, status, amount, distribamount, undistribamount, periodName, fagFirst )
  select  custId, periodType, licId, beginDate, endDate, status, amount, distribamount, undistribamount, periodName, fagFirst
    from #PaidPeriod 

  --Запись в журнал
   insert into SystemMessage (modifydate, nameMain, sysname, keyObj, text, name, custId) 
   select getdate(), 'StarDay', @procName, t1.periodId, 
	convert(char(40), t1.periodName) +'  Дог. №'+isnull(t4.licNum,'')+
	 '   Cума '+ ltrim(convert(char(20), convert(money,isnull(t1.Amount,0)))) + ' (Шифр '+ rtrim(ltrim(convert(char(20),t1.periodId))) +')', @name, t1.custId
      from #PaidPeriod t1
	 join vcustomer t2 on t1.custId = t2.custId
         join LicenseAgreement t3 on t1.licId = t3.licId 
         join LicenseAgrParam t4 on t4.licId = t3.licId and t4.licVersion = t3.licVersion

--PRINT 'Creation Period count = '+ convert(char(10), @rowCnt) 

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
 PRINT ' Creation Period faild!!!'

END CATCH
return @Retcode
END


--exec pTsk8_LicPeriodCreate

--select * from paidPeriod --where periodId > 1235
--delete  from paidPeriod where periodId > 1235
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pTsk8_LicPeriodCreate] TO [ReportUser]
    AS [dbo];

