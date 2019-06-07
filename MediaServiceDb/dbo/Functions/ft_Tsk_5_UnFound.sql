CREATE function [dbo].[ft_Tsk_5_UnFound]  (@dateBegin date, @dateEnd date )
RETURNS TABLE
AS
RETURN
SELECT
 max(t3.categoryCode) as categoryCode, t1.objid, max(t3.name) as name,  sum(t2.deboborot) - sum(t2.krdoborot) as amount
from Account t1 
join SaldoDay t2 on t1.accId = t2.accId and @dateBegin <= t2.dateBegin and t2.dateEnd >=@dateEnd
join objectRight t3 on t1.objid = t3.objId
where t1.balsCode = 31
group by t1.objid

--select * from ft_Tsk_5_UnFound ('2018-01-01', '2018-12-31')