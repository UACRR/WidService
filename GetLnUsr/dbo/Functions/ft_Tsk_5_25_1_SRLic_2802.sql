
CREATE function  [dbo].[ft_Tsk_5_25_1_SRLic_2802] ( @dateBegin date = NULL, @dateEnd date = NULL, @rateCommiss integer = NULL, @cmCustId integer = NULL ,@licCode integer )
--МП по договорах -розшифровка /ft_Tsk_5_25_1_SRLic
-- @rateCommiss - по конкретной комиссии. NULL / -1 - все комиссии
-- @cmCustId - ПО ТОВАРИСТВУ.  0, null - ПО ВСЕМ
RETURNS @RT TABLE
(
id integer identity  primary key,
rateCommiss decimal(7,3), 
rhCustId integer,
rhName varchar(200), 
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
select max(rateCommiss) as rateCommiss, isnull(rhCustId,-1) as rhCustId, sum(Amount) as Amount
from dbo.ft_Tsk_5_Reg_SRMain (@dateBegin, @dateEnd) 
where cmCustId = isnull(@cmCustId, cmCustId)
     and rateCommiss = isnull(@rateCommiss, rateCommiss)
	 and licCode = @licCode 
group by isnull(rhCustId,-1)
)
insert into @RT (rateCommiss, rhCustId, rhName, amount, rowNum)
select t1.rateCommiss, t1.rhcustId, isnull(t4.name, 'Невизначений') as rhName, t1.amount
, ROW_NUMBER() OVER(PARTITION by t1.rateCommiss ORDER BY t1.rateCommiss, t4.name) 
from TabRt t1
left join vCustomer  t4 on t1.rhCustId = t4.custId 
order by t1.rateCommiss, t4.name

RETURN
END
--select * from dbo.ft_Tsk_5_25_1_SRLic (  '2018-01-01',  '3000-01-01', -1, NULL,20) order by rownum

 
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_25_1_SRLic_2802] TO [ReportUser]
    AS [dbo];

