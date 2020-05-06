WITH cte AS (
    SELECT 
        DdexReportId, 
        BlockId, 
        SalesTransactionId, 
		sum(usages) usages,
		sum(netrevenue) netrevenue
     FROM 
        DdexRecordSu
	GROUP BY DdexReportId, BlockId, SalesTransactionId
	having count(*) > 1
)
update t1
set t1.netrevenue = t2.netrevenue, t1.usages = t2.usages
from DdexRecordSu t1 join cte t2 on  t1.DdexReportId = t2.DdexReportId and t1.BlockId = t2.BlockId and t1.SalesTransactionId = t2.SalesTransactionId

WITH cte AS (
    SELECT 
        DdexReportId, 
        BlockId, 
        SalesTransactionId, 
		ROW_NUMBER() OVER (
            PARTITION BY 
                DdexReportId, 
				BlockId, 
				SalesTransactionId
	        ORDER BY 
                 DdexReportId, 
				BlockId, 
				SalesTransactionId
        ) row_num
     FROM 
        DdexRecordSu
)
update t1
set t1.OwnerSuRecordIndex = t2.netrevenue, t1.usages = t2.usages
from DdexRecordLi t1 join cte t2 on  t1.DdexReportId = t2.DdexReportId and t1.BlockId = t2.BlockId and t1.OwnerSuRecordIndex = t2.SalesTransactionId

DELETE FROM cte
WHERE row_num > 1;