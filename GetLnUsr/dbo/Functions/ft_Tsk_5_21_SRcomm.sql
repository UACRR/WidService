
CREATE function  [dbo].[ft_Tsk_5_21_SRcomm]  (@dateBegin date = NULL, @dateEnd date = NULL, @rateCommiss decimal(7,3) = NULL)
--* Реєстр до розподілу від користувачів ВП (2.0-регистри)
-- @rateCommiss - по конкретной комиссии. NULL / -1 - все комиссии

RETURNS @RT TABLE
(id integer identity,
crCustId integer , 
crCustIdName varchar(200), 
rateCommiss decimal(7,3), 
amount money, 
rowNum integer ,
primary key (id,rowNum)
)
as
BEGIN

--Первый день месяца
set @dateBegin = isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())

set @rateCommiss = (Case When isnull(@rateCommiss,-1) = -1 Then NULL Else @rateCommiss end)

;with TabRT as
(select 
t1.rhCustId, t1.rateCommiss, 
 sum(t1.amount) as amount
from dbo.ft_Tsk_5_20_SRMain (@dateBegin, @dateEnd) as t1
join vCommunity t2 on t1.cmCustId = t2.cmCustId 
where isnull(t1.rateCommiss,0) = isnull(@rateCommiss, t1.rateCommiss)
group by t1.rateCommiss, t1.rhCustId
)
insert into @RT (crCustId, crCustIdName, rateCommiss, amount, rowNum)
select t1.rhCustId,  t5.name as crCustIdName, t1.rateCommiss, t1.amount, 
ROW_NUMBER() OVER( partition by t1.rateCommiss ORDER BY t1.rateCommiss, t5.Name) 
from TabRT t1 
join vCustomer t5 on t1.rhCustId = t5.custId 

RETURN
END
--	select * from dbo.ft_Tsk_5_21_SRcomm  ( NULL,  NULL, NULL) order by rownum


GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_21_SRcomm] TO [ReportUser]
    AS [dbo];

