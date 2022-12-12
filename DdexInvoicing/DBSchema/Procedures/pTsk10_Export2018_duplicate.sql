USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[pTsk10_Export2018_duplicate]    Script Date: 12.09.2022 13:03:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[pTsk10_Export2018_duplicate] @CcIdINfileId integer, @rmId integer, @result  varchar(100) OUT, @RetCode integer OUTPUT 
as
--2020-07-21 -Контроль и идентификация
--2020-08-05 недостающие по неизвестной причине (возможно ручное вмешательство)
--2020-08-12 2019 год 1-й квартал
 BEGIN 
--Перенос отчета в Mediservice только по отправленному отчету без ответа (4-й квартал 2018)
SET NOCOUNT ON;
--declare @RetCode integer
set @RetCode = 0
declare @cntAll integer, @cntWIC integer, @cntAuthors integer
declare @ddexReportingPeriodId integer 
set @ddexReportingPeriodId = (select ddexReportingPeriodId from vFileCcidDdex where ccidInFileId = @ccidInFileId)

-- @CcIdInfileId - определяю переменные: файл ddex, квартал и год
if not exists (select  1 from vFileCcidDdex where @CcIdINfileId = ccIdInFileId )  
  BEGIN 
   set @result = 'Помилка ідентифікатора файла!'
   RETURN 1 
  END 
-- -- для дубліката такий вже наявний
--В Mediaservice вношу с минусом
--if exists (select 1 from mediaservice..RegisterCCID where CcidClFileId = -1*@CcIdINfileId )  
--  BEGIN 
--   set @result = 'Помилка! Файл вже передано у локальну базу!'
--   RETURN 1 
--  END 

--declare @CcIdINfileId integer = 16 -  определяю переменные: файл ddex, квартал и год
declare @ddexReportId integer, @quarter integer, @year integer, @cntRows integer, @fileName varchar(100), 
        @custId integer, @licId integer, @licCode integer, @currency char(3)
 
select @ddexReportId = t1.ddexReportId, @quarter = t1.quarter, @year = t1.year, 
       --@fileName = t1.ccidINFileId, 
	   @fileName = t1.ccIdInFileId, 
	   @custId = t1.custId, 
	   @licId = t1.licId, 
	   @licCode = t1.licCode, 
	   @currency = t1.royalty_currency
from vFileCcidDdex  t1 
where ccIdInFileId = @CcIdINfileId

--2020-07-22 Якщо не той рік 
If not exists ( select  1 where @year = 2018 or (@year =2019 and @quarter = 1))
  BEGIN 
    set @result = 'Помилка! Рік не 2018!'
	PRINT N'Рік не 2018 і не 2019 1-й квартал!'
	Return 0
  END 

set @currency = (select max(r030) from mediaservice..KL_R030 t1 where t1.a3 = @currency)

--drop table #CCIDMW 
create table #CCIDMW 
(
 regIItemId  integer not null, 
 ddexReportId	integer not null, 
 ccIdINFileId	integer not null, 
 workcode varchar(50), 
 amountPerfCur numeric(30,10), 
 amountMechCur numeric(30,10), 
 countUse  integer  null,
 WIC     integer   null, 
 objId   integer null,
 itemName      varchar(100)  null,
 performer     varchar(100)  null,
 authorMusic   varchar(100)  null,
 authorText    varchar(100)  null,
 regId         integer null,
 mwId integer null, 
 sales_transaction_id	nvarchar (120) --25-03-2020
 primary key (regIItemId) )

--declare @ccIdInFileId   integer = 9
delete #CCIDMW
insert into #CCIDMW 
 (regIItemId, ddexReportId, ccIdINFileId, workcode, amountPerfCUR, amountMechCUR, countUse, WIC, objId, itemName,  sales_transaction_id)
select ROW_NUMBER() OVER (Order by workcode), t1.ddexReportId, t2.FileId, t2.workcode,  sum(t2.amount_licensor_perf), sum(t2.amount_licensor_mech)
, sum(t2.use_quantity)
, max((CASE When substring(workCode,1,3) = 'WIc' THEN substring(workCode, CHARINDEX(':', workCode)+1, 10) ELSE NULL END )) as WIC
, max((CASE When substring(workCode,1,3) = 'obj'  THEN substring(workCode, CHARINDEX(':', workCode)+1, 10) ELSE NULL END)) as objId
, left(max(t2.work_title), 100)
, max(t2.sales_transaction_id)
 from vFileCcidDdex t1
 join CcidINDetail t2 on t2.fileId = t1.ccIdINFileId   
 where t1.ccIdInFileId = @ccIdInFileId  
      and t2.amount_licensor_mech + t2.amount_licensor_perf  > 0
group by t1.ddexReportId, t2.FileId, t2.workcode

set @cntRows = @@ROWCOUNT  

if @cntRows = 0
  BEGIN 
   set @result = 'Помилка  - відсутні записи!'
   RETURN 1 
  END 

/*--2020-07-22
--Идентификато mwId
 update #CCIDMW  set mwId  = t2.mwId 
   from #CCIDMW t1 
    join IdentBacklog t2 on t2.DdexReportId = @ddexReportId 
	      and t1.sales_transaction_id = t2.SalesTransactionId
*/

--Идентификато mwId  --2020-07-22 по workCode 
/* --2020-08-05 --выше есть
 update #CCIDMW set
   objId = (CASE WHEN left(workCode, 3) = 'obj' THEN cast(substring(workCode, CHARINDEX(':', workCode)+1,20) as integer) ELSE NULL END), 
   WIC = (CASE WHEN left(workCode, 3) = 'wic' THEN cast(substring(workCode, CHARINDEX(':', workCode)+1,20) as integer) ELSE NULL END)
   from #CCIDMW
*/

 update #CCIDMW  set mwId  = t2.id
   from #CCIDMW t1 
   join IdentMW t2 on t1.objid = t2.objId

 update #CCIDMW  set mwId  = t2.id
   from #CCIDMW t1 
   join IdentMW t2 on t1.WIC = t2.WIC


--select * from IdentBacklog t1 where t1.DdexReportId = 9
--select * from vFileCcidDdex where ccidClFileId = 14

 update #CCIDMW  
  set performer = left(t2.performers, 100)
     ,authorMusic = left(t2.composers, 100)
	 ,authorText = left(t2.Lirics, 100)
 from #CCIDMW t1 
   join WID_IPI..wObject t2 on t1.WIC = t2.WIC 

 update #CCIDMW  
  set performer = left(t2.performers, 100)
     ,authorMusic = left(t2.composers, 100)
	 ,authorText = left(t2.lyrics, 100)
 from #CCIDMW t1 
   join MediaService..MediaTrack t2 on t1.objId = t2.objId
   

---Авторы
--drop table #CCIDAuthor
create table #CCIDAuthor (
   regIItemId           integer              not null,
   regAuthId            integer              not null,
   IP_BASE_NR           varchar(13)          collate Ukrainian_100_CI_AS null,
   ratePER              decimal(5,2)         null,
   rateMEC              decimal(5,2)         null,
   custId               integer              null,
   cmCodePER            char(3)              null,
   cmCodeMEC            char(3)              null,
   regId                integer              null,
   WIC                  integer              null, 
   objid                integer              null, 
   mwId                 integer              null,
  primary key (regIItemId, regAuthId)
)

delete #CCIDAuthor
;with TabData as 
(
select max(t1.regIItemId) as regIItemId, isnull(t2.IP_BASE_NR,'') as IP_BASE_NR
   ,max(Case When t1.amountPerfCur = 0 Then 0 Else t2.ratePer * t2.IncludPER END) as ratePer
   ,max(Case When t1.amountMechCur = 0 Then 0 Else t2.rateMEC * t2.IncludMEC END) as rateMEC 
   ,isnull(t2.custId,0) as custId, t2.cmCodePER, t2.cmCodeMEC
   ,isnull(t2.WIC,0) as WIC, isnull(t2.objid,0) as objId, max(t1.mwId) as mwId
  from #CCIDMW t1 
    join IdentMWAuthor t2 on t1.ddexReportId = t2.ddexReportId and isnull(t1.WIC,0) = isnull(t2.WIC,0) and isnull(t1.objid,0) = isnull(t2.objid,0)
    --join vFileCcidDdex t3 on t2.DdexReportId = t3.ddexReportId and  t3.ddexReportingPeriodId = ddexReportingPeriodId --2020-07-08
	group by isnull(t2.WIC,0), isnull(t2.objid,0), isnull(t2.IP_BASE_NR,''), isnull(t2.custId,0), t2.cmCodePER, t2.cmCodeMEC
)
insert into #CCIDAuthor
 (regIItemId, regAuthId, IP_BASE_NR, ratePER, rateMEC, custId, cmCodePER, cmCodeMEC, WIC, objid , mwId) 
select t1.regIItemId, ROW_NUMBER() OVER (Order by t1.regIItemId)
   ,IP_BASE_NR
   ,ratePer, rateMEC, custId, cmCodePER, cmCodeMEC, 
   (CASE WHEN isnull(WIC,0) = 0 THEN NULL ELSE WIC END), (CASE WHEN isnull(objid,0) = 0 THEN NULL ELSE objid END),
   mwId 
  from TabData t1 

---2020-08-05 недостающие по неизвестной причине
--select * from #CCIDMW t1 where objId is not NULL and  not exists (select  1 from #CCIDAuthor t2 where t1.objid = t2.objid)
declare @maxregAuthId integer 
set @maxregAuthId = (select max(regAuthId) from #CCIDAuthor)

;with TabData as 
(
select max(t1.regIItemId) as regIItemId, isnull(t2.IP_BASE_NR,'') as IP_BASE_NR
   ,max(Case When t1.amountPerfCur = 0 Then 0 Else t2.ratePer * t2.IncludPER END) as ratePer
   ,max(Case When t1.amountMechCur = 0 Then 0 Else t2.rateMEC * t2.IncludMEC END) as rateMEC 
   ,isnull(t2.custId,0) as custId, t2.cmCodePER, t2.cmCodeMEC
   ,isnull(t2.WIC,0) as WIC, isnull(t2.objid,0) as objId, max(t1.mwId) as mwId
  from #CCIDMW t1 
    join IdentMWAuthor t2 on t1.ddexReportId = t2.ddexReportId and t1.mwId = t2.mwId
    --join vFileCcidDdex t3 on t2.DdexReportId = t3.ddexReportId and  t3.ddexReportingPeriodId = ddexReportingPeriodId --2020-07-08
   where t1.objId is not NULL and  not exists (select  1 from #CCIDAuthor t3 where t1.objid = t3.objid)
  group by isnull(t2.WIC,0), isnull(t2.objid,0), isnull(t2.IP_BASE_NR,''), isnull(t2.custId,0), t2.cmCodePER, t2.cmCodeMEC
)
 insert into #CCIDAuthor
 (regIItemId, regAuthId, IP_BASE_NR, ratePER, rateMEC, custId, cmCodePER, cmCodeMEC, WIC, objid , mwId) 
select t1.regIItemId, @maxregAuthId+ROW_NUMBER() OVER (Order by t1.regIItemId)
   ,IP_BASE_NR
   ,ratePer, rateMEC, custId, cmCodePER, cmCodeMEC, 
   (CASE WHEN isnull(WIC,0) = 0 THEN NULL ELSE WIC END), (CASE WHEN isnull(objid,0) = 0 THEN NULL ELSE objid END),
   mwId 
  from TabData t1 

/*
--Проверка 
 select WIC, regIItemId,  objid, sum(ratePer), sum(rateMec) 
   from #CCIDAuthor 
   group by WIC, objid, regIItemId
   having sum(ratePer) > 100 or sum(rateMec) >100
*/

--Положить в PaidPeriod status = прийом звітів, звіт погоджений
declare 
@periodId integer, 
--@rmId integer, 
@regId integer

create table #tmpId (id integer not null primary key) 

BEGIN TRAN InsDDEXReport
 BEGIN TRY 

--Тестирование
--begin tran
--rollback
--declare @periodId integer, @rmId integer, @regId integer, @custId integer = 46580, @licId integer = 8085, @quarter integer = 4, @year integer = 2018, 
--        @ccidCLFileId integer = 22, @ddexReportId integer = 1, @licCode integer = 33, @cntRows integer, @fileName varchar(100)--, @periodId integer = 6928

--если уже есть период
set @periodId = (
 select max(periodId)
  from MediaService..PaidPeriod t1 
  join dbo.ft_DateQuarter (@quarter, @year) t3 on 1=1 
  where licId = @licId and t1.custId = @custId 
        and t1.beginDate = t3.dateBegin and t1.endDate = t3.dateEnd )

if @periodId is NULL 
  BEGIN 
    set @result = 'Помилка! Період не знайдено!'
	PRINT N'Період не знайдено!'
	Return 0
  END 

-- -- період повинен існувати
--если периода нет - творю
--BEGIN 
--insert into MediaService..PaidPeriod (custId, periodType, licId, beginDate, endDate, status, amount, distribamount, undistribamount, periodName)
-- output inserted.periodId into #tmpId (id) 
-- select t1.custid, 2, t1.licId, t3.dateBegin, t3.dateEnd, 1, 0, 0, 0, t3.periodName  
--    from DdexReport t1 
--	 join dbo.ft_DateQuarter (@quarter, @year) t3 on 1=1
--	 --join dbo.ft_DateQuarter (4, 2018) t3 on 1=1
--	where t1.Id = @ddexReportId

-- set @periodId = (select max(id) from #tmpId )
--END 



/* Тест
declare --@periodId integer, 
        @rmId integer, @regId integer, @custId integer = 46580, @licId integer = 8085, @quarter integer = 4, @year integer = 2018, 
        @ccidCLFileId integer = 22, @ddexReportId integer = 1, @licCode integer = 33, @cntRows integer, @fileName varchar(100), @periodId integer = 6928
*/

-- -- для дубліката RegisterRatedList створений
--delete #tmpId 
----сам отчет в RegisterRatedList, Register, RegisterCCID, RegisterItem, ...
----Несколько отчетов идут на один Р/Л
--insert into mediaservice..RegisterRatedList
-- ( periodId,  status,  amount,  royalty,  createDate,  userId,  cntReport,  paidAmount)
-- output inserted.rmId into #tmpId (id) 
--select @periodId, 0, 0, 0, getdate(), 'ADMIN', 1, 0 
--  where not exists ( select  1 from MediaService..RegisterRatedList where periodId = @periodId ) 

----set @rmId = (select max(id) from #tmpId )
--set @rmId = ( select max(rmId) from MediaService..RegisterRatedList where periodId = @periodId )

delete #tmpId

--Статус = 2 -погоджений
insert into mediaservice..Register
(rmId, countRows, custId, createDate, durationticks, rgStatus, fileName, userId, periodId, 
 regAmount, regRate, regRoyalty, musicAmount, musicRate, authAmount, authRate, paidAmount, 
 licId, schemaId, algorithmId)
output inserted.regId into #tmpId (id) 
select @rmId, isnull(@cntRows,0), @custId, getdate(), 0, 2, @fileName, 'ADMIN', @periodId, 
   0, 0, 0, 0, 0, 0, 0, 0, 
   @licId, t1.schemaId, t1.algorithmId
  from mediaservice..vAgrLicenseType t1
  where t1.licCode = @licCode

 set @regId = (select max(id) from #tmpId)
 delete #tmpId

 insert into mediaservice..RegisterCCID (regId, ddexReportId, CcidClFileId, amountCur, amountCurR, exchangeRate, r030)  --amountCurR
 select @regId, @ddexReportId, -1*@CcIdInfileId , 
        round(t1.sum_amount_licensor,2), t1.sum_amount_licensor, NULL, @currency
   from CcidInTrailer t1 
   where t1.fileId = @CcIdINfileId 

insert into mediaservice..RegisterItem 
(regId, regIItemId, objId, codeItem, ItemName, categoryCode, performer, authorMusic, authorText, 
 durationUse, countUse, durationItem, modifyDate, modifyLogin, durationticks, ticks, isAuto, genreType, WIC) 
select @regId, t1.regIItemId, t1.objId, 1, t1.itemName, 5, t1.performer, t1.authorMusic, t1.authorText, 
 NULL, countUse, NULL, getdate(), 'ADMIN', NULL, 0, 0, NULL, t1.WIC
  from #CCIDMW t1

 insert into mediaservice..RegisterCCIDMW
 (regId, regIItemId,  ccIdClFileId,  workcode, amountMech, amountPerf, amountMechCur, amountPerfCur, mwId) 
  select @regId, t1.regIItemId,  -1*t1.ccIdINFileId, t1.workcode, 0, 0, t1.amountMechCur, t1.amountPerfCur, mwId 
      from #CCIDMW t1 
insert into MediaService..RegisterCCIDAuthor 
( regId, regIItemId, regAuthId, IP_BASE_NR, ratePER,  rateMEC,  custId,  cmCodePER,  cmCodeMEC, mwId )
select @regId, t1.regIItemId, t1.regAuthId, t1.IP_BASE_NR, t1.ratePER,  t1.rateMEC,  t1.custId, 
   t1.cmCodePER,  t1.cmCodeMEC, t1.mwId
 from #CCIDAuthor t1 

/*
select * from mediaservice..RegisterRatedList
select * from mediaservice..RegisterCCID
select * from mediaservice..Register 
select * from mediaservice..registerItem where regid = 7430
select * from mediaservice..registerCCIDMW
select * from mediaservice..registerCCIDAUTHOR
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
          
 set @result  = 'Операцію перервано! Зміни не прийнято!'
set @Retcode = 1

END CATCH

--Статистика
set  @cntAll  = (select  count(*) from mediaservice..RegisterItem where regId = @regId)
set  @cntWIC = (select  count(distinct WIC) from mediaservice..RegisterItem where regId = @regId and isnull(objid,0) = 0)
set  @cntAuthors = (select  count(distinct IP_Base_NR) from mediaservice..RegisterCCIDAuthor where regId = @regId and isnull(custId,0) = 0) 

set @result = 'Завантажено звіт Ід='+convert(varchar(10), @regid)
           +'.  Рядків - '+convert(varchar(10),@cntAll)
          +'.  Необхідно синхронізувати творів - '+ convert(varchar(10), @cntWIC)
          +', Авторів - '+convert(varchar(10), @cntAuthors)


RETURN @Retcode 
END 
/*
declare @retCode integer, @result varchar(200) 
exec pTsk10_Export2018 9, @result OUTPUT, @RetCode  OUTPUT
select @result
*/

/*
select * from vFileCcidDdex where year = 2018
use mediaservice
go 
--exec SYS_DelPaidPeriod 6925
select * from mediaservice..vRegister
select * from mediaservice..RegisterCCID where regid = 7423
select * from mediaservice..RegisterCCIDMW where regid = 7423
select * from mediaservice..Register where regid = 7423 --where rmid = 4290 --regid = 7425
select * from mediaservice..registerItem where regid = 7423
select * from mediaservice..registerCcidAuthor where regid = 7423
select * from MediaService..RegisterRatedList where rmid = 4290  --periodid=6925 --rmid = 4290
select * from MediaService..PaidPeriod 
*/
--4 и 16 
GO

