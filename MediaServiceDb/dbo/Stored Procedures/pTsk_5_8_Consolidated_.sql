CREATE procedure  [dbo].[pTsk_5_8_Consolidated_]  (@beginDate date = NULL, @endDate date = NULL)

AS

Begin 
--Користувачі

set @beginDate = isnull(@beginDate, (select convert(date, (convert(char(4),year(getdate()))+'-01-01'))))
set @endDate = isnull(@endDate, getdate())
if @beginDate>@endDate
		return

--учет свод
declare @result Table(
categoryCode			int,
cmFlag						int,
categoryName			varchar(20),
cmFlagName			varchar(20),
sCollectm					money,
sCommiss				money,
sDistrib						money,
primary key (categoryCode,cmFlag)
)

insert @result

select categoryCode, cmFlag,
  (case when categoryCode = 5 Then 'Малі права' else case When categoryCode = 6 then 'Великі права' else '' end end) as categoryName, 
  (case when cmFlag = 0 Then 'Правовласники УААСП' Else 'Інші Правовласники' end) as cmFlagName ,  
	   sum(sCollect) as sCollectm, sum(sCommiss) as sCommiss, sum(sDistrib) as sDistrib
 from dbo.ft_tsk_3_DistribMain(@beginDate, @endDate) 
 group by categoryCode, cmFlag
 order by categoryCode
 
 select * from @result

end
-- exec pTsk_5_8_Consolidated null, null