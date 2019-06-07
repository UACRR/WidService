CREATE function  [dbo].[ft_Tsk_5_22_1_BRcm_]  (@dateBegin date = NULL, @dateEnd date = NULL, @cmCustId integer = NULL)
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
join SaldoDay t2 on t1.accId = t2.accId and @dateBegin <= t2.dateBegin and t2.dateEnd <=@dateEnd
join objectRight t3 on t1.objid = t3.objId and t3.categoryCode = 6 --Большие права
where t1.balsCode = 31
group by t1.objid
)
insert into @RT (cmCustId, cmName, rateCommiss, amount)
select t11.cmCustId, max(t11.cmName) as cmName, isnull(t10.rateCommiss,0), SUM(amount) as amount
from TabTurn t3 
join vLicenseAgreement t2 on t3.objid = t2.objId
join vCustCmService t11 on t11.custId = t3.custId and t2.kindCode = t11.CRKindCode
join vCustomer t7 on t7.custId = t2.custId
left join AgreementMaster t9 on t3.custId = t9.custId --and isnull(t9.agrStatus,0) <> 4 
left join AgreementAddRH t10 on t10.agrId = t9.agrId and t10.version = t9.version
where t11.cmCustId = ISNULL(@cmCustId, t11.cmCustId)
group by t11.cmCustId, t10.rateCommiss 
order by 2,3

update @RT set rowNum = id
update @RT set rowNum = cmCustId where cmCustId<0
update @RT set rowNum = 0  
 from @RT t1 join vCommunity t2 on t1.cmCustId = t2.cmCustId and t2.isMy = 1

RETURN
END

--select * from ft_Tsk_5_22_1_BRcm ('2018-01-01', '2018-12-31', 0)
--select * from ft_Tsk_5_22_BRcm ('2018-01-01', '2018-12-31')