CREATE function  [dbo].[ft_Tsk_5_22_BRcm_]  (@dateBegin date = NULL, @dateEnd date = NULL)
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

;with TabTurn as 
( 
select t3.custId, t2.objid, sum(t1.amount) as amount
from PayTurn t1 
join Account t2 on t1.accIdCredit = t2.accId and t2.balsCode in (30,31) 
join Account t3 on t1.accIdDebet = t3.accId and t3.balsCode = 21
where dateOper between @dateBegin and @dateEnd
group by t3.custId, t2.objId
)
insert into @RT (cmCustId, cmName,  amount)
select 
t11.cmCustId, max(t11.cmName) as cmName, SUM(amount) as amount
from LicenseBigR t1 
join vLicenseAgreement t2 on t1.licId = t2.licId 
join ObjectRight t6 on t6.objId = t1.objId
join CopyRight t5 on t5.objId = t6.objId
join AgreementMaster t9 on t5.custId = t9.custId and isnull(t9.agrStatus,0) <> 4 
join AgreementAddRH t10 on t10.agrId = t9.agrId 
left join TabTurn t3 on t3.custId = t5.custId and t3.objId = t5.objId
join vCustomer t7 on t2.custId = t7.custId
join vCustomer t8 on t5.custId = t8.custId
join vCustCmService t11 on t11.custId = t5.custId and t11.CRKindCode = t2.kindCode
and isnull(t3.amount,0)<>0  --or t2.licStatus <> 4
group by t11.cmCustId

--Додати невизначені
 insert into @RT (cmCustId, cmName,  amount)
   select -1, 'НЕВИЗНАЧЕНІ', sum(amount) 
   from ft_Tsk_5_UnFound (@dateBegin, @dateEnd) 
   where categoryCode = 6

update @RT set rowNum = id
update @RT set rowNum = cmCustId where cmCustId < 0
update @RT set rowNum = 0  
 from @RT t1 join vCommunity t2 on t1.cmCustId = t2.cmCustId and t2.isMy = 1

RETURN
END

--select * from ft_Tsk_5_22_BRcm ('2018-01-01', '2018-12-31')
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_22_BRcm_] TO [ReportUser]
    AS [dbo];

