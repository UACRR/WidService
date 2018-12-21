CREATE function  dbo.ft_Tsk_5_22_BRcm__  (@dateBegin date = NULL, @dateEnd date = NULL)
-- Відомість розподіл АВ ВП зведена по ТОВ (4.0)
RETURNS @RT TABLE
(
cmCustId integer primary key, 
cmName varchar(200), 
amount money, 
rowNum integer, 
id integer identity
)
as
BEGIN

--Первый день месяца
set @dateBegin = isnull(@dateBegin, (select convert(date, (convert(char(4),year(getdate()))+'-01-'+ substring(convert(char(3),100+MONTH(getdate())),2,2) ))))
set @dateEnd = isnull(@dateEnd, getdate())

/*
declare @datebegin date, @dateEnd date
set @dateBegin = '2018-01-01'
set @dateEnd = '2018-12-31'
*/

insert into @RT (cmCustId, cmName,  amount)
select 
t1.cmCustId, max(t2.cmName) as cmName , SUM(t1.amount) as amount
from dbo.ft_Tsk_5_20_BRMain (@dateBegin, @dateEnd) as t1
join vCommunity t2 on t1.cmCustId = t2.cmCustId
group by t1.cmCustId

update @RT set rowNum = id
update @RT set rowNum = cmCustId where cmCustId < 0
update @RT set rowNum = 0  
 from @RT t1 join vCommunity t2 on t1.cmCustId = t2.cmCustId and t2.isMy = 1

RETURN
END

--select * from ft_Tsk_5_22_BRcm__ ('2018-01-01', '2018-12-31')