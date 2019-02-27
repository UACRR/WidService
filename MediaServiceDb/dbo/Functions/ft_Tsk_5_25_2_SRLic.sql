CREATE function  [dbo].[ft_Tsk_5_25_2_SRLic] (@dateBegin date = NULL, @dateEnd date = NULL, @rateCommiss integer = NULL, @cmCustId integer = NULL  )
--* МП по договорах - Загальна/ft_Tsk_5_25_2_SRLic
-- @rateCommiss - по конкретной комиссии. NULL / -1 - все комиссии
-- @cmCustId - ПО ТОВАРИСТВУ.  0, null - ПО ВСЕМ
RETURNS @RT TABLE
(
id integer identity  primary key,
rateCommiss decimal(7,3), 
rhCustId integer,
rhName varchar(200), 
cmCustId integer, 
cmName varchar(200), 
licCode integer, 
licCodeName varchar(200),
amount money, 
rowNum integer
)
as
BEGIN

--Первый день месяца
set @dateBegin = isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())

set @rateCommiss = (Case When isnull(@rateCommiss,-1) = -1 Then NULL Else @rateCommiss end)
set @cmCustId = (Case When isnull(@cmCustId,0) = 0 Then NULL Else @cmCustId end)

--Если лицензи нул - беру по видам использования
;with TabRt as 
(
select licCode, max(rateCommiss) as rateCommiss, isnull(rhCustId,-1) as rhCustId, sum(Amount) as Amount, cmCustId
from dbo.ft_Tsk_5_Reg_SRMain (@dateBegin, @dateEnd) 
where cmCustId = isnull(@cmCustId, cmCustId)
     and rateCommiss = isnull(@rateCommiss, rateCommiss)
group by isnull(rhCustId,-1), licCode, cmCustId
)
insert into @RT (rateCommiss, rhCustId, rhName, cmCustId, cmName, licCode, licCodeName, amount, rowNum)
select t1.rateCommiss, t1.rhcustId, isnull(t4.name, 'Невизначений') as rhName, 
t1.cmCustId, t5.cmName, t1.licCode, isnull(t6.name, t7.name), t1.amount
, ROW_NUMBER() OVER( Partition by t5.cmName, isnull(t6.name, t7.name), t1.rateCommiss ORDER BY t5.cmName, isnull(t6.name, t7.name), t1.rateCommiss, t4.name) 
from TabRt t1
left join vCustomer  t4 on t4.custId = t1.rhCustId 
join vCommunity t5 on t5.cmCustId = t1.cmCustId
left join AgrLicenseType t6 on t6.codeI = t1.licCode and t1.licCode > 0 
left join CopyrightKind t7 on t7.codeI = -1*t1.licCode and licCode < 0
order by 
t5.cmName, isnull(t6.name, t7.name), 
t1.rateCommiss
, t4.name

RETURN
END
--select * from dbo.ft_Tsk_5_25_2_SRLic ( '2018-01-01',  '3000-01-01', -1, NULL)  order by rownum