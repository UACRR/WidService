USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[spPrepareDataForIdent]    Script Date: 12.09.2022 13:09:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[spPrepareDataForIdent] @ddexReportId int
as
begin
--declare @ddexReportId int = 8;
--create index idx_IdentReportMwRecords_PriorityIndex on IdentReportMwRecords(PriorityIndex)
declare @fileType varchar(100) = (select FileType from DdexReport where Id = @ddexReportId);

--select @fileType;
if @fileType in ('Usage-Subscription-Music', 'Usage-Subscription-Premium')
begin
	declare @TotalRevenue float = 
		(select sum(netrevenue) 
		from DdexRecordSY_04_01 
		where ddexReportId = @ddexReportId 
			and SubscriberType = 'all'
		)
	--select @totalRevenue totalRevenue

	declare @MusicPlusGEMusicViews int = 
		(select sum(TotalUsages) 
		from DdexRecordSY_05_02 
		where ddexReportId = @ddexReportId 
			and ContentCategory in ('Music', 'GEMusic'))
	--select @MusicPlusGEMusicViews MusicPlusGEMusicViews

	declare @ConstantGrossRevenueValue float = @TotalRevenue / @MusicPlusGEMusicViews;

	update IdentBacklog
	set NetRevenue = @ConstantGrossRevenueValue * Usages
	where ddexReportId = @ddexReportId
end

delete from IdentReportMwRecords where DdexReportId = @ddexReportId

/*
update t2 
set t2.status = 0 
from IdentBacklog t1 
		inner join IdentMW t2 on t2.id = t1.mwId
where t1.DdexReportId = @ddexReportId
*/

-- create redundant table for quick linking IdentBacklog with IdentMwRecords
--declare @ddexReportId int = 1;
insert IdentReportMwRecords(DdexReportId, mwId)
select distinct DdexReportId, mwId
from IdentBacklog
where DdexReportId = @ddexReportId

-- Calculate net revenue per music work
--declare @ddexReportId int = 1;
;with sums as (
--declare @ddexReportId int = 5;
	select t2.mwId, sum(t1.NetRevenue) NetRevenue, count(*) IdentBacklogRecCnt 
	from IdentBacklog t1 
		inner join IdentReportMwRecords t2 on t2.mwId = t1.mwId
	where t1.ddexReportId = @ddexReportId
	group by t2.mwId
)
update t2
set t2.NetRevenue =  t1.NetRevenue, t2.IdentBacklogRecCnt = t1.IdentBacklogRecCnt
from sums t1 
	inner join IdentReportMwRecords t2 on t2.mwId = t1.mwId


-- auto ident records with ISWC
--declare @ddexReportId int = 1;
update t1
set t1.Wic = t2.Wic, t1.status = 2
from IdentReportMwRecords t3
	join IdentMW t1 on t3.mwId = t1.Id
    join SocWid..WidIswc t2 on t1.ISWC = t2.ISWC
where T1.status <> 2 and t3.ddexReportId = @ddexReportId

-- Calculate identification priorities per music work
-- declare @ddexReportId int = 1;
update IdentReportMwRecords 
set PriorityIndex = null
--from IdentReportMwRecords --t1
	--join IdentMw t2 on t2.Id = t1.mwId
where DdexReportId = @ddexReportId

-- declare @ddexReportId int = 1;
;with a AS(
-- declare @ddexReportId int = 5;
SELECT ROW_NUMBER() OVER(ORDER BY t1.NetRevenue DESC) as rn, t1.PriorityIndex
FROM IdentReportMwRecords  t1
	join IdentMW t2 on t1.mwId = t2.Id
where isnull(t2.Wic, 0) = 0 and isnull(t2.ObjId, 0) = 0 and t1.ddexReportId = @ddexReportId
) 
UPDATE a SET PriorityIndex = rn

-- Update statistics from Ident Backlog
-- declare @ddexReportId int = 1;

;with sums as (
-- declare @ddexReportId int = 5;
	select ddexReportId, sum(NetRevenue) NetRevenue, Count(*) count
	from IdentBacklog
	where ddexReportId = @ddexReportId
	group by ddexReportId
)
update t1 
set t1.NetRevenue = t2.NetRevenue,
	t1.SalesTransCnt = t2.count
from DdexReport t1
	join sums t2 on t1.Id = t2.DdexReportId
where t1.Id = @ddexReportId

/*
select 
	sum(NetRevenue) total
	, sum(case when status = 0 then NetRevenue else 0 end) not_processed
	, sum(case when status = 0 then 0 else NetRevenue end) processed
from IdentMw
*/

--select 1 873 999.27 total, 1 278 390.90 notprocessed, 595 608.37 processed
/*
select 
	sum(NetRevenue) total
from IdentMw
where PriorityIndex < 10000

select 
	sum(NetRevenue) total
from IdentMw
where PriorityIndex >= 10000
*/

--declare @ddexReportId int = 1;
;with stat as (
--declare @ddexReportId int = 5;
select 
	  @ddexReportId ddexReportId
	, count(*) MwCnt
	, sum(case when status = 2 then 0 else 1 end) MwCntUnmatched
	, sum(t2.NetRevenue) NetRevenue
	, sum(case when status = 2 then 0 else t2.NetRevenue end) NetRevenueUnmatched
	, sum(case when ISWC <> '' then 1 else 0 end) MwCntIswcTotal
	, sum(case when ISWC <> '' then t2.NetRevenue else 0 end) MwNetRevenueIswcTotal
	, sum(case when ISWC <> '' and status = 2 then 1 else 0 end) MwCntIswcMatched
	, sum(case when ISWC <> '' and status = 2  then t2.NetRevenue else 0 end) MwNetRevenueIswcMatched
from IdentMw t1 
	join IdentReportMwRecords t2 on t1.Id = t2.mwId
where t2.ddexReportId = @ddexReportId
)
update t1
set t1.MwCnt = t2.MwCnt
	, t1.MwCntUnmatched = t2.MwCntUnmatched
	, t1.NetRevenue = t2.NetRevenue
	, t1.NetRevenueUnmatched = t2.NetRevenueUnmatched
	, t1.MwCntIswcTotal = t2.MwCntIswcTotal
	, t1.MwNetRevenueIswcTotal = t2.MwNetRevenueIswcTotal
	, t1.MwCntIswcMatched = t2.MwCntIswcMatched
	, t1.MwNetRevenueIswcMatched = t2.MwNetRevenueIswcMatched
from ddexReport t1 
	join stat t2 on t1.id = t2.ddexReportId

-- calculated statistics for priority blocks
-- declare @ddexReportId int = 1;
delete from DdexNetRevenueDistr where DdexReportId = @ddexReportId

declare @netRevenue decimal(20,6);
declare @blockNetRevenue decimal(20,6) = 0;
declare @netRevenueAccr decimal(20,6) = 0;
declare @netRevenueTotal decimal(20,6);
declare @recCntTotal int;
declare @margin decimal(20, 6);
declare @recCount int = 0;
declare @blockRecCount int = 0;
declare @blockStartRec int;

select @netRevenueTotal = NetRevenueUnmatched 
	, @recCntTotal = MwCntUnmatched
from ddexReport 
where id = @ddexreportid

set @margin = @netRevenueTotal * 0.95 

DECLARE cMwRecors CURSOR 
LOCAL STATIC READ_ONLY FORWARD_ONLY
FOR     
select NetRevenue
from IdentReportMwRecords
where ddexReportId = @ddexReportId and PriorityIndex is not null
order by PriorityIndex
 
OPEN cMwRecors    
  
FETCH NEXT FROM cMwRecors INTO @netRevenue;
set @blockNetRevenue = 0;
set @netRevenueAccr = 0;
set @recCount = 0;
set @blockRecCount = 0;
set @blockStartRec = 1;
  
WHILE @@FETCH_STATUS = 0 and @netRevenueAccr < @margin
BEGIN    
    set @blockNetRevenue = @blockNetRevenue + @netRevenue;
	set @netRevenueAccr = @netRevenueAccr + @netRevenue;
	set @recCount = @recCount + 1;
	set @blockRecCount = @blockRecCount + 1;
	if @blockRecCount = 1000
	begin
		insert DdexNetRevenueDistr
		select @ddexReportId, @blockStartRec, @recCount, @blockNetRevenue, @netRevenueAccr, 0, 0

		set @blockNetRevenue = 0;
		set @blockRecCount = 0;
		set @blockStartRec = @recCount + 1;
	end
	FETCH NEXT FROM cMwRecors INTO @netRevenue;

END     
CLOSE cMwRecors;    
DEALLOCATE cMwRecors;  
-- cursor

insert DdexNetRevenueDistr
select @ddexReportId, @blockStartRec, @recCntTotal, @netRevenueTotal - @netRevenueAccr, @netRevenueTotal, 0, 0

update DdexNetRevenueDistr
	set share = cast(netRevenue / @netRevenueTotal * 100 as decimal(10, 2))
	, shareAccr = cast(netRevenueAccr / @netRevenueTotal * 100 as decimal(10, 2)) 
from DdexNetRevenueDistr
where ddexReportId = @ddexReportId

/*
select * 
from DdexNetRevenueDistr 
order by firstRec	
*/


end;

-- spPrepareDataForIdent 8
GO

