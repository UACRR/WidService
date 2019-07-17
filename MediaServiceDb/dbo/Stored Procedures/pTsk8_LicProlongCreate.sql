CREATE procedure [dbo].[pTsk8_LicProlongCreate] (@date date = NULL)
as
begin
/*
--Пролонгація договорів
--1) По параметру автопролонгації - статус=1 (на підтвердження), 2) по даті початку договору, строк дії якого ще не наступив на момент підтвердження. 
*/
SET NOCOUNT ON;
declare @RetCode integer
set @RetCode = 0

set @date = isnull(@date, convert(date, getdate()))
declare @procName varchar(100) = 'pTsk8_LicProlongCreate'+' (' +convert(char(10), @date)+')'
declare @name varchar(50) = 'Створення договорів пролонгації - '+convert(char(10), @date)
declare @cntrRow integer

--PRINT 'Creation prolongation'

--drop table #LicenseAgrParam 
create table #LicenseAgrParam (
   licId                integer              not null,
   licVersion           integer              not null,
   licNum               varchar(50)          null,
   licDate              date                 null,
   dateBegin            date                 null,
   dateEnd              date                 null,
   minAmount            money                null,
   rateAmount           numeric(10,5)        null,
   isAutoprolog         bit                  null,
   addRate              numeric(10,5)        null,
   indxInfl             numeric(10,5)        null,
   periodCode           integer              null,
   dayForPay            integer              null,
   licStatus            integer              null,
   modifyDate           datetime             null,
   modifyLogin          varchar(48)          null,
   ankVersion           integer              null,
   comment              varchar(2048)        null,
   custId               integer              null,
   minAmountOld			money                null,
   versOld             integer              null, 
   primary key (licId, licVersion)
)

/*
declare @date date
set @date = isnull(@date, convert(date, getdate()))
declare @procName varchar(100) = 'pTsk8_LicProlongCreate'+' (' +convert(char(10), @date)+')'
declare @name varchar(50) = 'Створення договорів пролонгації - '+convert(char(10), @date)
*/
--declare @date date = dateadd (month, 10, getdate())
delete #LicenseAgrParam 

--макс.версія ліцензії
;with TabLicVers as 
(
select licId, max(licVersion) as licversion 
  from LicenseAgrParam 
  group by licId
)
insert into #LicenseAgrParam (licId, licVersion, dateBegin, dateEnd, minAmount, addRate, rateAmount, indxInfl, dayForPay, isAutoprolog, periodCode, licStatus, 
                             modifyDate, modifyLogin, comment, custId, minAmountOld, licNum, licDate, versOld) 
select t1.licId, isnull(t5.licVersion,0)+1, dateadd(day, 1, t2.dateEnd) as dateBegin, dateadd(year, 1, t2.dateEnd) as dateEnd,
--( Case isnull(addRate,0) When 0  THEN round(t4.rate*t2.minAmount/100 + t2.minAmount,2) --индекс инфляции. Пока берем с договора
 ( Case isnull(addRate,0) When 0  THEN round(t2.indxInfl*t2.minAmount/100 + t2.minAmount, 2) --индекс инфляции. Пока берем с договора
   Else convert(money, round(t2.minAmount+t2.minAmount * t2.addRate/100,2)) end ) as minAmount
 ,t2.addRate, t2.rateAmount, t2.indxInfl, t2.dayForPay, t2.isAutoprolog, t2.periodCode, 0 as licStatus,  --было 1
  getdate(), 'dbo', 'Start'+convert(char(10), getdate(),104)+isnull(t2.comment ,''), 
  t1.custId, t2.minAmount, 
  t2.licNum, t2.licDate, t2.licVersion
from LicenseAgreement t1 
join LicenseAgrParam t2 on t1.licId = t2.licId and t1.licVersion = t2.licVersion and t1.licStatus = 2 and isAutoprolog = 1 
--left join SystemConstant t4 on codeI = 3  --индекс инфляции. Пока берем с договора
left join TabLicVers t5 on t1.licId = t5.licId
where t1.licStatus=2 and t2.dateEnd <= @date
--и нет договоров активных или на акцепте с датой окончания больше заданной 
and not exists ( select  1 from LicenseAgrParam t3 
                 where t1.licId = t3.licId and t3.licStatus in (0, 1, 2) and t1.licVersion <> t3.licVersion and t3.dateEnd >= @date)

  --Запись в журнал 
   insert into SystemMessage (modifydate, nameMain, sysName, keyObj, text, name)  
   select getdate(), 'StarDay', @procName, NULL, 'Створення договорів пролонгації до акцепту. Всього договорів - '+ convert(char(10), @@ROWCOUNT), @name
 
 If @@ROWCOUNT = 0
 return 0

 begin Transaction CreaProlong
	BEGIN TRY

   insert into SystemMessage (modifydate, nameMain, sysName, keyObj, text, name, custId) 
   select getdate(), 'StarDay', @procName, licId, 
    'Дог. №'+isnull(t1.licNum,'')+'  '+convert(char(10), t1.dateBegin,104)+'  по ' +convert(char(10), t1.dateEnd,104)+
	 ' Cума '+ ltrim(convert(char(20), convert(money,minAmount)))+' (Попередня - '+ ltrim(convert(char(20), convert(money,minAmountOld)))+') - Не підтверджений!'
      , @name, t1.custId
      from #LicenseAgrParam t1
	 join vcustomer t2 on t1.custId = t2.custId

	--Запись договоров
   insert into LicenseAgrParam (licId, licVersion, dateBegin, dateEnd, minAmount, addRate, rateAmount, indxInfl, dayForPay, isAutoprolog, periodCode, licStatus, 
       modifyDate, modifyLogin, comment, licNum, licDate) 
	select  licId, licVersion, dateBegin, dateEnd, minAmount, addRate, rateAmount, indxInfl, dayForPay, isAutoprolog, periodCode, licStatus, 
            modifyDate, modifyLogin, comment, licNum, licDate 
     from #LicenseAgrParam

  --Лицензия с майданчиками
  insert license (placeId, licId, licVersion, lNum, lDate) 
  select  t1.placeId, t2.licId, t2.licVersion, t1.lNum, @date
    from license t1 
	 join #LicenseAgrParam t2 on t1.licId = t2.licId and t1.licVersion = t2.versOld

  --Откорректировать период новой суммой договора
   update paidPeriod set amount = t2.minAmount 
      from  paidPeriod t1 
       join #LicenseAgrParam t2  on t1.licId = t2.licId and @date between t1.beginDate and  t1.endDate  and status not in (6,7) 

set @cntrRow = (select count(*) from #LicenseAgrParam)
PRINT 'Creation prolongation count = '+ convert(char(10), @cntrRow) 

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

--exec pTsk8_LicProlongCreate
--select * from SystemMessage
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pTsk8_LicProlongCreate] TO [ReportUser]
    AS [dbo];

