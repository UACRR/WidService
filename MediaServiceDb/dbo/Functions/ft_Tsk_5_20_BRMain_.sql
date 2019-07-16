CREATE function  [dbo].[ft_Tsk_5_20_BRMain_]  (@dateBegin date = NULL, @dateEnd date = NULL)
-- Відомість розподіл АВ ВП по ТОВ і комісіям у розрізі об'єктів права ф правовласників
RETURNS @RT TABLE
(
id integer identity  primary key,
objId integer, 
clCustId integer,
rhCustId integer,
cmCustId integer , 
rateCommiss decimal(7,3), 
amount money
)
as
BEGIN

--Первый день месяца
set  @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))set @dateEnd = isnull(@dateEnd, getdate())

;with TabTurn as 
( 
select t3.custId, t2.objid, sum(t1.amount) as amount
from PayTurn t1 
join Account t2 on t1.accIdCredit = t2.accId and t2.balsCode in (30,31) 
join Account t3 on t1.accIdDebet = t3.accId and t3.balsCode = 21
join objectRight t4 on t2.objid = t4.objid  and t4.categoryCode = 6  --Большие права
where dateWork between @dateBegin and @dateEnd
group by t3.custId, t2.objId
union 
select -1, t1.objid, sum(t2.deboborot) - sum(t2.krdoborot) as amount
from Account t1 
join SaldoDay t2 on t1.accId = t2.accId and @dateBegin <= t2.dateBegin and t2.dateEnd >=@dateEnd
join objectRight t3 on t1.objid = t3.objId and t3.categoryCode = 6 --Большие права
where t1.balsCode = 31
group by t1.objid
)
insert into @RT (objid, clCustId, rhCustId, cmCustId, rateCommiss, amount)
select t3.objid, t2.custId as clCustId, t3.custId as rhCustId, t11.cmCustId, isnull(t10.rateCommiss,0), amount
from TabTurn t3 
join vLicenseAgreement t2 on t3.objid = t2.objId
join vCustCmService t11 on t11.custId = t3.custId and t2.kindCode = t11.CRKindCode
join vCustomer t7 on t7.custId = t2.custId
left join AgreementMaster t9 on t3.custId = t9.custId --and isnull(t9.agrStatus,0) <> 4 
left join AgreementAddRH t10 on t10.agrId = t9.agrId and t10.version = t9.version

RETURN
END

--select * from ft_Tsk_5_20_BRMain ('2018-01-01', '2018-12-31')
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_20_BRMain_] TO [ReportUser]
    AS [dbo];

