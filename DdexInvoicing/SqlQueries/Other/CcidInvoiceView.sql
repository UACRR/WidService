declare @blockRange int = 100000;
declare @blockFromId int = 1;
declare @blockToId int = @blockFromId + @blockRange;
declare @year varchar(4) = '2018';
declare @quarter varchar(1) = '4';
declare @fileId int = 1;
declare @ddexReportId int = 5;

declare @lastBlockId int;
select @lastBlockId = max(BlockId) from AS01_01 where fileId = @ddexReportId

delete from CcidDetail where fileId = @fileId


while(@blockFromId <= @lastBlockId)
begin
	insert into CcidDetail(
		  fileId
		, RECORD_TYPE
		, transaction_type
		, REF_ID
		, SALES_TRANSACTION_ID
		, RELEASE_ID
		, RESOURCE_ID
		, WORKCODE
		, WORK_TITLE
		, USE_QUANTITY
		, ORIGINAL_RELEASE_REVENUE_BASIS
		, ORIGINAL_RESOURCE_REVENUE_BASIS
		, RESOURCE_SHARE
		, CLAIM_LICENSOR_COMBINED
		, AMOUNT_INVOICED_TOTAL
		, CLAIM_LICENSOR_MECH
		, CLAIM_LICENSOR_PERF
		, AMOUNT_LICENSOR_MECH
		, AMOUNT_LICENSOR_PERF)
	select @fileId
		, 'ID' RECORD_TYPE
		, 'ORI' TRANSACTION_TYPE
		, @year + '-' 
				+ @quarter + '-' 
				+ cast(ROW_NUMBER() OVER(ORDER BY t1.DspReleaseId, t2.DspResourceId, t1.Usages) 
				as varchar(20)) REF_ID
		, left(t3.SalesTransactionId, 60) SALES_TRANSACTION_ID
		, left(t1.DspReleaseId, 60) RELEASE_ID
		, left(t2.DspResourceId, 60) RESOURCE_ID
		, '???' WORKCODE
		, left(t2.Title, 60) WORK_TITLE 
		, t1.Usages USE_QUANTITY
		, 0 ORIGINAL_RELEASE_REVENUE_BASIS
		, 0  ORIGINAL_RESOURCE_REVENUE_BASIS 
		, 0 RESOURCE_SHARE
		, 0 CLAIM_LICENSOR_COMBINED
		, 0 AMOUNT_INVOICED_TOTAL
		, 0 CLAIM_LICENSOR_MECH
		, 0 CLAIM_LICENSOR_PERF
		, 0 AMOUNT_LICENSOR_MECH
		, 0 AMOUNT_LICENSOR_PERF
	from 
		RU01_01_Splitted t1
		left join AS01_01 t2 on t1.blockid = t2.blockid and t1.fileid = t2.fileid
		left join SU03_02 t3 on t1.blockid = t3.blockid and t1.fileid = t3.fileid
	where cast(t1.blockid as int) >= @blockFromId and cast(t1.blockid as int) < @blockToId

	set @blockFromId = @blockToId
	set @blockToId = @blockFromId + @blockRange

	select @blockFromId

end
--order by t3.SalesTransactionId

;with SumPerMusicWork as (
	select fileId, BlockId, MasterSeqNumber, sum(usages) usages, sum(NetRevenue) NetRevenue
	from SU03_02_Ex
	group by fileId, BlockId, MasterSeqNumber
),
SumPerBlock as (
	select fileId, BlockId, sum(usages) usages, sum(NetRevenue) NetRevenue
	from SU03_02_Ex
	group by fileId, BlockId
),
PercentPerMusicWork as (
	select t2.DdexReportId, t2.BlockId, t2.MusicWorkTitle, sum(t1.RightsPercentMech + t1.RightPercentPerf) RightsPercent 
	from DdexIdentifiedAuthors t1
		left join DdexMusicWorkAuthors t2 on t2.id = t1.DdexMusicWorkAuthorId
	group by t2.DdexReportId, t2.BlockId, t2.MusicWorkTitle
),
SumPerMusicWorkCorrected as (
	select t1.fileId,t1. BlockId, t1.MasterSeqNumber, t1.usages, (t1.NetRevenue * 0.3) NetRevenue
	from SumPerMusicWork t1
),SumPerMusicWorkWithAuthors as (
	select t1.fileId, t1.blockId, t1.ISWC, t1.Title, t1.ComposerAuthor , t2.usages, t2.NetRevenue
	from MW01_01_Master t1
	left join SumPerMusicWorkCorrected t2 on t2.fileId = t1.fileId and t2.BlockId = t1.BlockId and t2.MasterSeqNumber = t1.MasterSeqNumber
)
select * from SumPerMusicWorkWithAuthors