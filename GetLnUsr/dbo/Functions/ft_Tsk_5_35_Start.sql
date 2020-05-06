CREATE function  [dbo].[ft_Tsk_5_35_Start]  (@date date = NULL)
--Звіт про системні повідомлення

RETURNS TABLE 
as RETURN 
(
select id, convert(char(10),modifydate, 104) as mDate, convert(char(12), cast(modifydate as time)) as mTime, 
t1.custId, t2.name as custName, 
t1.name, t1.text 
from systemmessage t1
left join vCustomer t2 on t1.custId = t2.custId
--where cast(modifydate as date) = cast(getdate() as date)
where cast(modifydate as date) = isnull(@date,cast(getdate() as date))
 );
--select * from dbo.ft_Tsk_5_35_Start (NULL)

GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_35_Start] TO [ReportUser]
    AS [dbo];

