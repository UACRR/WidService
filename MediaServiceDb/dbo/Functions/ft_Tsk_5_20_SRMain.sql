CREATE function  [dbo].[ft_Tsk_5_20_SRMain]  (@dateBegin date = NULL, @dateEnd date = NULL)
-- Відомість розподіл АВ ВП по ТОВ і комісіям у розрізі об'єктів права і правовласників

RETURNS @RT TABLE
(
id integer identity  primary key,
objId integer, 
--clCustId integer,
CRKindCode integer,
rhCustId integer,
cmCustId integer , 
rateCommiss decimal(7,3), 
amount money
)
as
BEGIN

--Первый день месяца
set  @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())

--declare @dateBegin date, @dateEnd date 
--set @dateBegin = '2018-01-01'
--set @dateEnd  = '2018-12-31'

;with TabTurn as 
( 
select t3.custId, t2.objid, convert(smallint, substring(t2.accnls,3,2)) as CRkindCode, sum(t1.amount) as amount
from PayTurn t1 
join Account t2 on t1.accIdCredit = t2.accId and t2.balsCode in (30,31) 
join Account t3 on t1.accIdDebet = t3.accId and t3.balsCode = 21
join objectRight t4 on t2.objid = t4.objid  and t4.categoryCode = 5  --Малі права
where dateWork between @dateBegin and @dateEnd
group by t3.custId, t2.objId, convert(smallint,substring(t2.accnls,3,2))
union 
select -1, t1.objid, convert(smallint,substring(t1.accnls,3,2)) as kindCode, sum(t2.deboborot) - sum(t2.krdoborot) as amount
from Account t1 
join SaldoDay t2 on t1.accId = t2.accId and @dateBegin <= t2.dateBegin and t2.dateEnd >=@dateEnd
join objectRight t3 on t1.objid = t3.objId and t3.categoryCode = 5 --Малі права
where t1.balsCode = 31
group by t1.objid, convert(smallint,substring(t1.accnls,3,2)) 
)
insert into @RT (objid, CRKindCode, rhCustId, cmCustId, rateCommiss, amount)
select t3.objid, t3.CRkindCode, t3.custId as rhCustId, t11.cmCustId, isnull(t10.rateCommiss,0), amount
from TabTurn t3 
left join vCustCmService t11 on t11.custId = t3.custId and t11.CRKindCode = t3.CRkindCode
left join vCustomer t7 on t7.custId = t3.custId
left join AgreementMaster t9 on t3.custId = t9.custId --and isnull(t9.agrStatus,0) <> 4 
left join AgreementAddRH t10 on t10.agrId = t9.agrId and t10.version = t9.version

RETURN
END

--select * from ft_Tsk_5_20SRMain ('2018-01-01', '2018-12-31')
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_20_SRMain] TO [ReportUser]
    AS [dbo];

