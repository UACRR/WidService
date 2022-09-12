USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[spDdexAdjConsolidatedDistRoyalty]    Script Date: 12.09.2022 13:06:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[spDdexAdjConsolidatedDistRoyalty] (
	  @ddexReportId int
	, @result		varchar(100)	out
	, @RetCode		int				output 
)
as
begin
	--Перенос отчета в Mediservice
--2020-07-08 -- Добавлено ограничение периодом для поиска авторов
--Идентификато mwId  --2020-07-22 по workCode 

set nocount on;
set @RetCode = 1;
declare   @cntAll		int
		, @cntWIC		int
		, @cntAuthors	int
declare @ddexReportingPeriodId int = (select ddexReportingPeriodId from DdexReport where Id = @ddexReportId)

-- @CcIdCLfileId - определяю переменные: файл ddex, квартал и год
if not exists (select null from DdexAdjConsolidatedDetail where DdexReportId = @ddexReportId )  
  begin 
	set @result = 'Помилка ідентифікатора файла!'
	return 1 
  end 

if exists (select null from mediaservice..RegisterCCID where CcIdCLfileId = @ddexReportId )  
  begin 
   set @result = 'Помилка! Файл вже передано у локальну базу!'
   return 1 
  end 

declare @quarter int
	, @year int;
select @quarter = quarter
	, @year = year
from DdexReportingPeriod
where Id = @DdexReportingPeriodId

declare @fileName varchar(100) = cast(@ddexReportId as varchar(100));

declare	@custId int
	, @licId int
select @custId = custId
	, @licId = licId
from DdexReport
where Id = @ddexReportId;

declare @licCode int = (select licCode from vMSCustomerUses where custId = @custId and licId = @licId);

declare @currency char(3) = (select max(r030) from mediaservice..KL_R030 t1 where t1.a3 = 'USD');

drop table if exists #CCIDMW;

create table #CCIDMW 
(
	 regIItemId  int primary key not null, 
	 ddexReportId	int not null, 
	 ccIdClFileId	int not null, 
	 workcode varchar(50), 
	 amountPerfCur numeric(30,10), 
	 amountMechCur numeric(30,10), 
	 countUse  int  null,
	 WIC     int   null, 
	 objId   int null,
	 itemName      varchar(100)  null,
	 performer     varchar(100)  null,
	 authorMusic   varchar(100)  null,
	 authorText    varchar(100)  null,
	 regId         int null,
	 mwId int null, 
	 sales_transaction_id	nvarchar (120) --25-03-2020
)

;with DistinctMw as (
	select WorkCode WorkCode
		, max(SalesTransactionId) SalesTransactionId
	from DdexAdjConsolidatedDetail
	where DdexReportId = @ddexReportId
		and WorkCode is not null
		and AllocatedRevenueCompensated > 0
	group by WorkCode
)
insert into #CCIDMW (
	regIItemId, 
	ddexReportId, 
	ccIdClFileId, 
	workcode, 
	amountPerfCUR, 
	amountMechCUR, 
	countUse, 
	WIC, 
	objId, 
	itemName,  
	sales_transaction_id
)
select row_number() over (order by workcode), 
	@ddexReportId, 
	@ddexReportId, 
	WorkCode,
	0, 
	0,
	0,
	null as WIC,
	null as objId,
	'',
	SalesTransactionId
from DistinctMw
/*
select row_number() over (order by workcode), 
	t1.ddexReportId, 
	t2.FileId, 
	t2.workcode,  
	sum(t2.amount_licensor_perf), 
	sum(t2.amount_licensor_mech),
	sum(t2.use_quantity),
	max((CASE When substring(workCode,1,3) = 'WIc' THEN substring(workCode, CHARINDEX(':', workCode)+1, 10) ELSE NULL END )) as WIC,
	max((CASE When substring(workCode,1,3) = 'obj'  THEN substring(workCode, CHARINDEX(':', workCode)+1, 10) ELSE NULL END)) as objId,
	left(max(t2.work_title), 100),
	max(t2.sales_transaction_id),
from vFileCcidDdex t1
	join CcidClDetail t2 on t2.fileId = t1.ccIdClFileId   
where t1.ccIdCLFileId = @ccIdClFileId  
    and t2.amount_licensor_mech + t2.amount_licensor_perf  > 0
group by t1.ddexReportId, t2.FileId, t2.workcode
*/

declare @cntRows int = @@ROWCOUNT;

if @cntRows = 0
  begin 
   set @result = 'Помилка  - відсутні записи!'
   return 1 
  end 

 update #CCIDMW 
 set objId = cast(substring(workCode, charindex(':', workCode) + 1, 20) as int)
 where  left(workCode, 5) = 'ObjId';

 update #CCIDMW 
 set WIC = cast(substring(workCode, charindex(':', workCode) + 1, 20) as int)
 where left(workCode, 3) = 'Wic';

 ;with Amounts as 
(
	select 
		WorkCode,
		sum(case when RightsType = 0 then AllocatedRevenueCompensated else 0 end) amountMechCur,
		sum(case when RightsType = 1 then AllocatedRevenueCompensated else 0 end) amountPerfCur,
		sum(AllocatedUsages) countUse
	from DdexAdjConsolidatedDetail
	where DdexReportId = @ddexReportId
		and WorkCode is not null
		and AllocatedRevenueCompensated > 0
	group by WorkCode
)
update t1  
set 
	t1.amountMechCur = t2.amountMechCur,
	t1.amountPerfCur = t2.amountPerfCur,
	t1.countUse = t2.countUse
from #CCIDMW t1 
	join Amounts t2 on t1.WorkCode = t2.WorkCode

update t1  
set 
	t1.itemName = left(t2.work_title, 100)
from #CCIDMW t1 
	join CcidInDetail t2 on t1.sales_transaction_id = t2.sales_transaction_id
  
 update #CCIDMW  set mwId  = t2.id
   from #CCIDMW t1 
   join IdentMW t2 on t1.objid = t2.objId

 update #CCIDMW  set mwId  = t2.id
   from #CCIDMW t1 
   join IdentMW t2 on t1.WIC = t2.WIC

 update #CCIDMW  set mwId  = t2.mwId 
   from #CCIDMW t1 
    join IdentBacklog t2 on t2.DdexReportId = @ddexReportId 
	      and t1.sales_transaction_id = t2.SalesTransactionId
    where t1.mwId is null 

 update #CCIDMW  set WIC = t2.WIC, objId = t2.objId
   from #CCIDMW t1 
   join IdentMW t2 on t1.mwId = t2.Id
  where t1.WIC is NULL and t1.objId is NULL 
-->

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

--select * from #CCIDMW

--select sum(amountMechCur + amountPerfCur)  from #CCIDMW
drop table if exists #CCIDAuthor

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
    join IdentMWAuthor t2 on isnull(t1.WIC,0) = isnull(t2.WIC,0) and isnull(t1.objid,0) = isnull(t2.objid,0)
    join vFileCcidDdex t3 on t2.DdexReportId = t3.ddexReportId and  t3.ddexReportingPeriodId = ddexReportingPeriodId --2020-07-08
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

declare @periodId integer, @rmId integer, @regId integer

drop table if exists #tmpId

create table #tmpId (id integer not null primary key) 

BEGIN TRAN InsDDEXReport
 BEGIN TRY 

set @periodId = (
 select max(periodId)
  from MediaService..PaidPeriod t1 
  join dbo.ft_DateQuarter (@quarter, @year) t3 on 1=1 
  where licId = @licId and t1.custId = @custId 
        and t1.beginDate = t3.dateBegin and t1.endDate = t3.dateEnd )

if @periodId is NULL 
BEGIN 
insert into MediaService..PaidPeriod (custId, periodType, licId, beginDate, endDate, status, amount, distribamount, undistribamount, periodName)
 output inserted.periodId into #tmpId (id) 
 select t1.custid, 2, t1.licId, t3.dateBegin, t3.dateEnd, 1, 0, 0, 0, t3.periodName  
    from DdexReport t1 
	 join dbo.ft_DateQuarter (@quarter, @year) t3 on 1=1
	 --join dbo.ft_DateQuarter (4, 2018) t3 on 1=1
	where t1.Id = @ddexReportId

 set @periodId = (select max(id) from #tmpId )
 END 

delete #tmpId 
 --сам отчет в RegisterRatedList, Register, RegisterCCID, RegisterItem, ...
insert into mediaservice..RegisterRatedList
 ( periodId,  status,  amount,  royalty,  createDate,  userId,  cntReport,  paidAmount)
 output inserted.rmId into #tmpId (id) 
select @periodId, 0, 0, 0, getdate(), 'ADMIN', 1, 0 
set @rmId = ( select max(rmId) from MediaService..RegisterRatedList where periodId = @periodId )

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

 declare @total decimal(20, 6) = (
	select sum(AllocatedRevenueCompensated) 
	from DdexAdjConsolidatedDetail 
	where DdexReportId = @ddexReportId
		and WorkCode is not null
);
 insert into mediaservice..RegisterCCID (
	regId, 
	ddexReportId, 
	CcidClFileId, 
	amountCur, 
	amountCurR, 
	exchangeRate, 
	r030
)
values ( 
	@regId, 
	@ddexReportId, 
	@ddexReportId, 
    round(@total, 2), 
	@total, 
	NULL, 
	@currency
)

insert into mediaservice..RegisterItem 
(regId, regIItemId, objId, codeItem, ItemName, categoryCode, performer, authorMusic, authorText, 
 durationUse, countUse, durationItem, modifyDate, modifyLogin, durationticks, ticks, isAuto, genreType, WIC) 
select @regId, t1.regIItemId, t1.objId, 1, t1.itemName, 5, t1.performer, t1.authorMusic, t1.authorText, 
 NULL, countUse, NULL, getdate(), 'ADMIN', NULL, 0, 0, NULL, t1.WIC
  from #CCIDMW t1

 insert into mediaservice..RegisterCCIDMW
 (regId, regIItemId,  ccIdClFileId,  workcode, amountMech, amountPerf, amountMechCur, amountPerfCur, mwId) 
  select @regId, t1.regIItemId,  t1.ccIdClFileId, t1.workcode, 0, 0, t1.amountMechCur, t1.amountPerfCur, mwId 
      from #CCIDMW t1 
insert into MediaService..RegisterCCIDAuthor 
( regId, regIItemId, regAuthId, IP_BASE_NR, ratePER,  rateMEC,  custId,  cmCodePER,  cmCodeMEC, mwId )
select @regId, t1.regIItemId, t1.regAuthId, t1.IP_BASE_NR, t1.ratePER,  t1.rateMEC,  t1.custId, 
   t1.cmCodePER,  t1.cmCodeMEC, t1.mwId
 from #CCIDAuthor t1 

if @@TRANCOUNT > 0 commit tran
end try

begin catch
  if @@TRANCOUNT > 0 rollback tran
  set @result  = ERROR_MESSAGE()
  set @RetCode = 1;
  return @Retcode 
end catch

--Статистика
set  @cntAll  = (select  count(*) from mediaservice..RegisterItem where regId = @regId)
set  @cntWIC = (select  count(distinct WIC) from mediaservice..RegisterItem where regId = @regId and isnull(objid,0) = 0)
set  @cntAuthors = (select  count(distinct IP_Base_NR) from mediaservice..RegisterCCIDAuthor where regId = @regId and isnull(custId,0) = 0) 

set @result = 'Завантажено звіт Ід='+convert(varchar(10), @regid)
           +'.  Рядків - '+convert(varchar(10),@cntAll)
          +'.  Необхідно синхронізувати творів - '+ convert(varchar(10), @cntWIC)
          +', Авторів - '+convert(varchar(10), @cntAuthors)

set @RetCode = 0;
return @Retcode 
end
GO

