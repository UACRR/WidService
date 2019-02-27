CREATE procedure [dbo].[pTsk8_LicProlongActive] (@date date = NULL)
as
begin
/*
--Пролонгація договорів
--Активация пролонгированного договора
*/
SET NOCOUNT ON;
declare @RetCode integer
set @RetCode = 0

set @date = isnull(@date,convert(date, getdate()))
declare @procName varchar(100) = 'pTsk8_LicProlongActive (' +convert(char(10), @date)+')'
declare @name varchar(50) = 'Активація пролонгованих договорів - '+convert(char(10), @date)

--PRINT 'Active prolongation'
BEGIN 
--Перевод в активные договора ранее подтвержденные
--Отбор


create table #TabProlong 
(licId integer,
 versOld integer,
 versNew integer, 
 custId integer,
 primary key (licId))

 --declare @date date = convert(date, getdate())
 delete #TabProlong 
 insert into #TabProlong (licId, versOld, versNew, custId)
 select t1.licId, max(t1.licVersion) as oldVers, max(t2.licVersion) as newVers, max(t1.custId) as custId
 from LicenseAgreement t1 
  join LicenseAgrParam t2 on t1.licId = t2.licId and t1.licStatus = t2.licStatus and t2.licStatus = 2  --только для активных договоров
   and t1.licVersion <> t2.licversion
   and t2.dateBegin <= @date
  group by t1.licId 

--Удаляю из отобранных, если даты меньше или равны уже действующего договора
   delete #TabProlong 
     from #TabProlong t1 
     join LicenseAgrParam t2 on t1.licId = t2.licId and t1.versNew = t2.licVersion 
     join LicenseAgrParam t3 on t1.licId = t3.licId and t1.versOld = t3.licVersion 
    where t2.dateBegin<=t3.dateBegin

 declare @rowCnt integer = (select count(*) from #TabProlong)
 PRINT 'Active prolongation count = ' + convert(char(10), @rowCnt)

  --Запись в журнал 
   insert into SystemMessage (modifydate, nameMain, sysName, keyObj, text, name)  
   select getdate(), 'StarDay', @procName, NULL, @name+'. Всього - '+ convert(char(10), @rowCnt), @name

  IF  @rowCnt=0
  return 0
 
 BEGIN TRAN ActiveProlong
 BEGIN TRY
 update LicenseAgrParam set licStatus = 4, modifyDate = getdate() 
  from LicenseAgrParam t1 
   join #TabProlong t2 on t1.licId = t2.licId and t1.licVersion = t2.versOld

 update LicenseAgreement set licVersion = t2.versNew
  from LicenseAgreement t1 
   join #TabProlong t2 on t1.licId = t2.licId and t1.licVersion = t2.versOld

  --Запись в журнал
   insert into SystemMessage (modifydate, nameMain, sysName, keyObj, text, name, custId) 
   select getdate(), 'StarDay', @procName, t3.licId, 
    ' №'+isnull(t3.licNum,'')+'  Діє з '+isnull(convert(char(10), t3.dateBegin,104),'')+'  по ' + isnull(convert(char(10), t3.dateEnd,104),'') +
    '  Cума '+ ltrim(convert(char(20), convert(money,isnull(t3.minAmount,0)))) + ' - Активовано!'+ '  (Шифр - '+ rtrim(ltrim(convert(char(10),t1.licId)))+'/'+rtrim(ltrim(convert(char(10), t1.versNew)))
    , @name, t1.custId
      from #TabProlong t1
	 join vcustomer t2 on t1.custId = t2.custId
         join LicenseAgrParam t3 on t1.licId = t3.licId and t1.versNew = t3.licVersion

 --Откорректировать период новой суммой договора
   update paidPeriod set amount = t4.minAmount 
      from  paidPeriod t1 
       join #TabProlong t2  on t1.licId = t2.licId and @date between t1.beginDate and  t1.endDate  and status not in (6,7) 
       join LicenseAgreement t3 on t3.licId = t2.licId 
       join LicenseAgrParam t4 on t4.licId = t3.licId and t4.licVersion = t2.versNew

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
END

return @Retcode
END
--exec dbo.pTsk8_LicProlongActive
--select * from SystemMessage