CREATE function  [dbo].[ft_Tsk_5_22_1_BRcm]  (@dateBegin date = NULL, @dateEnd date = NULL, @cmCustId integer = NULL)
-- Відомість розподіл АВ ВП по ТОВ-Деталізація(4.0) 
--@cmCustId = 0, NULL - по всем, - * Відомість розподіл АВ ВП зведена по ТОВ (4.0)
RETURNS @RT TABLE
(
id integer identity  primary key,
cmCustId integer , 
cmName varchar(200), 
rateCommiss decimal(7,3), 
amount money,
rowNum integer
)
as
BEGIN

--Первый день месяца
set @dateBegin = isnull(@dateBegin, (select convert(date, (convert(char(4),year(getdate()))+'-01-'+ substring(convert(char(3),100+MONTH(getdate())),2,2) ))))
set @dateEnd = isnull(@dateEnd, getdate())

set @cmCustId = (Case When isnull(@cmCustId,0) = 0 Then NULL Else @cmCustId end)

;with TabTurn as 
( 
select  isnull(t1.rhCustId,-1) as rhCustId, isnull(t1.cmCustId,-1) as cmCustId, isnull(t2.rateCommiss,0) as rateCommiss, sum(t1.amount) as amount 
from ft_Tsk_5_distributed (@dateBegin, @dateEnd, NULL, NULL) t1, 
     vCustomerRHolder t2 
where t1.rhCustId = t2.custId and  
      t1.cmCustId = isnull(@cmCustId, t1.cmCustId) 
 group by isnull(t1.rhCustId, -1), isnull(t1.cmCustId, -1), t2.rateCommiss
)
insert into @RT (cmCustId, cmName, rateCommiss, amount)
select t3.cmCustId, max(t4.cmName) as cmName, isnull(t3.rateCommiss,0), SUM(amount) as amount
from TabTurn t3 
  join vCommunity t4 on t4.cmCustId = t3.cmCustId
group by t3.cmCustId, t3.rateCommiss 
order by 2,3

update @RT set rowNum = id
update @RT set rowNum = cmCustId where cmCustId<0
update @RT set rowNum = 0  
 from @RT t1 join vCommunity t2 on t1.cmCustId = t2.cmCustId and t2.isMy = 1

RETURN
END

--select * from ft_Tsk_5_22_1_BRcm ('2018-01-01', '2019-12-31', 0)
--select * from ft_Tsk_5_22_BRcm ('2018-01-01', '2018-12-31')