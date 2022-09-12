USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[pTsk10_AddCcIdCLDdexAdjustment]    Script Date: 12.09.2022 13:01:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[pTsk10_AddCcIdCLDdexAdjustment]  @ccidClFileId  integer 
as BEGIN 
--Определяю период по CCCLFile, в котором потом ищем DspReleaseId DDEX
--declare @ccidClFileId integer = 20
SET NOCOUNT ON;

declare @PeriodId integer, @ccidInFileId integer, @msg varchar(200), @cnt integer, @msgAmount decimal(30,10)
--declare @ccidClFileId integer = 11

set @PeriodId = (select ddexReportingPeriodId from vFileCcidDdex where ccidClFileId = @ccidClFileId)
set @ccidInFileId = (select ccidInFileId from vFileCcidDdex  where ccidClFileId = @ccidClFileId)
--select @ccidInFileId

create table #tmp_ClFilePeriod
(ccidClFileId integer not null primary key )

--Отбираю заклеймленные в периоде файлы
insert into #tmp_ClFilePeriod
 (ccidClFileId) 
 select t1.ccidClFileId
   from vFileCcidDdex t1 where t1.ddexReportingPeriodId = @PeriodId  and ccidClFileId is not NULL


--drop table #tmp_DdexAdjustment_STI
create table #tmp_DdexAdjustment_STI  
(fileId integer,       --@ccidInFileId
salesTransactionId varchar(100), 
type integer, 
allocatedNetRevenue decimal (13,6), 
workCode varchar(39), 
WIC integer, 
objid integer, 
ddexReportId integer, --в каком есть ддексе получали последний раз
mwId integer, 
ccIdInFileId integer,  --в каком отправляли последний раз
release_id nvarchar(60), 
resource_id nvarchar(60),
work_title varchar(60),
primary key (fileId, salesTransactionId, type)
)

--drop table #tmp_WorCodes 
create table #tmp_WorCodes 
( salesTransactionId nvarchar(60), 
  DspReleaseId nvarchar(60), 
  workcode varchar(39),
  ddexReportId integer, --в каком есть ддексе получали последний раз
  mwId integer, 
  ccIdInFileId integer, --в каком отправляли последний раз
  release_id nvarchar(60), 
  resource_id nvarchar(60),
  work_title varchar(60)
 primary key (salesTransactionId, DspReleaseId, workcode) 
)

--отбираю то, что не включено при формировании @ccidCLFileId, но были в инвойсах
delete #tmp_DdexAdjustment_STI

insert into #tmp_DdexAdjustment_STI (fileId, salesTransactionId, type, allocatedNetRevenue, ccidInFileId)
select t1.fileId, salesTransactionId, type, allocatedNetRevenue, t3.fileId
 from DdexAdjustment t1 
  join CcidInDetail t3 on t1.salesTransactionId = t3.sales_transaction_id 
--  where t1.fileId = 12 and 
  where t1.fileId =  @ccidInFileId and  
  not exists 
  (select  1 from CcidClDetail t2 
       where t1.salesTransactionId = t2.sales_transaction_id --and t2.fileId = @ccidClFileId
   )

set @cnt = @@ROWCOUNT
set @msgAmount = (select sum(allocatedNetRevenue) from #tmp_DdexAdjustment_STI )
set @msg = 'Внесено записів із CcidInDetail: ' + trim(cast(@cnt as varchar(15)))+ ' на суму: '+trim(cast(@msgAmount as varchar(30)))+'  '

--отбираю то, что не включено при формировании @ccidCLFileId, не были в инвойсах
insert into #tmp_DdexAdjustment_STI (fileId, salesTransactionId, type, allocatedNetRevenue)
select fileId, salesTransactionId, type, allocatedNetRevenue
 from DdexAdjustment t1 
--  where t1.fileId = 12 and 
  where t1.fileId =  @ccidInFileId and  
  not exists 
  (select  1 from CcidClDetail t2 
       where t1.salesTransactionId = t2.sales_transaction_id --and t2.fileId = @ccidClFileId
	   )
	and not exists (select  1 from CcidInDetail t3 where t3.sales_transaction_id = t1.salesTransactionId)

--2 мин, нужно убыстрить
  delete #tmp_WorCodes 
  insert into #tmp_WorCodes 
  (salesTransactionId, DspReleaseId, workcode, ddexReportId, ccIdInFileId, mwId, release_id, resource_id, work_title ) 
  select distinct t1.salesTransactionId, t2.DspReleaseId, max(t3.workcode) as workCode, 
      max(t2.DdexReportId), max(t3.fileId), max(t2.mwId), 
	  max(t3.release_id), max(t3.resource_id), max(t3.work_title)
 from  #tmp_DdexAdjustment_STI t1 
    join IdentBacklog t2 on t1.salesTransactionId = t2.SalesTransactionId 
	join ccidIndetail t3 on t2.DspReleaseId = t3.release_id 
	join vFileCcidDdex t4 on t2.DdexReportId = t4.ddexReportId
	join vFileCcidDdex t5 on t3.fileId = t5.ccIdInFileId and t5.ddexReportingPeriodId = t4.ddexReportingPeriodId
 group by t1.salesTransactionId, t2.DspReleaseId

update #tmp_DdexAdjustment_STI set workcode = t2.workCode, ddexReportId = t2.ddexReportId, 
             ccIdInFileId = isnull(t1.ccIdInFileId, -1*t2.ccIdInFileId), 
			 mwId = t2.mwId, 
			 release_id = t2.release_id, resource_id = t2.resource_id, work_title = t2.work_title
  from #tmp_DdexAdjustment_STI t1 
    join #tmp_WorCodes t2 on t1.salesTransactionId = t2.salesTransactionId

--Расшифровываю коды
update #tmp_DdexAdjustment_STI 
    set WIC = ( Case When left(workCode,3) = 'wic' Then substring (workCode, 5, 15) Else NULL END),  
	    objId = ( Case When left(workCode,3) = 'obj' Then substring (workCode, 7, 15) Else NULL END)
   from #tmp_DdexAdjustment_STI

---Нужно вставить в ccidClDetail
--begin tran
insert into ccidClDetail 
( fileId, --ref_id, 
    record_type, transaction_type, claim_licensor_combined,
  sales_transaction_id, release_id, resource_id,
  workcode, work_title, 
  use_quantity, applied_tariff,  
  royalty,  
  amount_invoiced_total, 
  claim_licensor_mech, claim_licensor_perf, 
  amount_licensor_mech, amount_licensor_perf, 
  ccidInfileId
  )
select
 @ccidClFileId, 
 -1, '-1', 1, 
 salesTransactionId, release_id, resource_id, 
 workCode, work_title, 
 1,1, 
 allocatedNetRevenue,
 allocatedNetRevenue, 
 1, 1, 
 0, allocatedNetRevenue, 
 ccidInfileId
from #tmp_DdexAdjustment_STI 
--commit
--rollback 

set @cnt = @@ROWCOUNT
set @msgAmount = (select sum(allocatedNetRevenue) from #tmp_DdexAdjustment_STI )
set @msg = isnull(@msg,'')+'Внесено записів: ' + trim(cast(@cnt as varchar(15)))+ ' на суму: '+trim(cast(@msgAmount as varchar(30)))
print @msg
RAISERROR(13001,1,1,15,@msg);

Return 0
END 

--exec pTsk10_AddCcIdCLDdexAdjustment 11
--select * from ccidClDetail  where fileId = 20 and record_type = '-1'

GRANT EXEC
    ON OBJECT::[dbo].[pTsk10_AddCcIdCLDdexAdjustment] TO [DdexRobot], [robot]
    AS [dbo];

GO

