insert LastUsedCustomers
select distinct t2.CustId, getdate()
from ReportIdToRegId t1
	join MediaService..Register t2 on t1.RegId = t2.RegId