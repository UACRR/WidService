declare @firstRec int = 1, @lastRec int = 10000;
declare @incr int = 10000;
declare @netRevenue decimal(20,2);
declare @blockNetRevenue decimal(20,2) = 0;
declare @netRevenueAccr decimal(20,2) = 0;
declare @netRevenueTotal decimal(20,2);
declare @recCntTotal int;
declare @ddexReportId int = 5;
declare @margin decimal(20, 2);
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
select t1.NetRevenue
from IdentMw t1 join IdentReportMwRecords t2 on t1.Id = t2.mwId
where t2.ddexReportId = @ddexReportId and t1.PriorityIndex is not null
order by t1.PriorityIndex
 
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
select @ddexReportId, @blockStartRec, @recCntTotal, @blockNetRevenue, @netRevenueAccr, 0, 0

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
