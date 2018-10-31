CREATE function  [dbo].[ft_Tsk_5_8_Consolidated]  (@beginDate date = NULL, @endDate date = NULL)
RETURNS TABLE
AS
RETURN
--учет свод
select categoryCode, 
  (case when categoryCode = 5 Then 'Малі права' else case When categoryCode = 6 then 'Великі права' else '' end end) as categoryName, 
  (case when cmFlag = 0 Then 'Правовласники УААСП' Else 'Інші Правовласники' end) as cmFlagName ,  
	   sum(sCollect) as sCollectm, sum(sCommiss) as sCommiss, sum(sDistrib) as sDistrib
 from dbo.ft_tsk_3_DistribMain(@beginDate, @endDate) 
 group by categoryCode, cmFlag
 --order by categoryCode

--select  * from ft_Tsk_5_8_Consolidated (null, null)