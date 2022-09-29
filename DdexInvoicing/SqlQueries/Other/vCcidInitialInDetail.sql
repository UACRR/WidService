alter view vCcidInitialInDetail as
select 
		1 fileId
		, 'ID' RECORD_TYPE
		, 'ORI' transaction_type
		, DdexReportId * 1000000000000 + cast(BlockId as int) * 1000 + recordIndex REF_ID
		, SalesTransactionId SALES_TRANSACTION_ID
		, t1.DspReleaseId RELEASE_ID
		, t1.DspReleaseId RESOURCE_ID --DspResourceId RESOURCE_ID
		, 'PRS' WORKCODE --??? May we skip it?
		, astitle WORK_TITLE
		, cast((UsagesMech + UsagesPerf) as int) USE_QUANTITY
		, t2.netrevenuesum ORIGINAL_RELEASE_REVENUE_BASIS
		, netrevenue ORIGINAL_RESOURCE_REVENUE_BASIS
		, 100 RESOURCE_SHARE
		,  20 CLAIM_LICENSOR_COMBINED
		, RevenueMech * MarketShareMech + RevenuePerf * MarketSharePerf AMOUNT_INVOICED_TOTAL
		, 50 CLAIM_LICENSOR_MECH
		, 50 CLAIM_LICENSOR_PERF
		, RevenueMech * MarketShareMech AMOUNT_LICENSOR_MECH
		, RevenuePerf * MarketSharePerf AMOUNT_LICENSOR_PERF
from vCcidInitialInDetailBase t1 join 
(select dspreleaseid, sum(netrevenue) netrevenuesum from DdexRecordSu group by dspreleaseid) t2 on t2.DspReleaseId = t1.dspreleaseid

--select * from vCcidInitialInDetail order by ORIGINAL_RELEASE_REVENUE_BASIS