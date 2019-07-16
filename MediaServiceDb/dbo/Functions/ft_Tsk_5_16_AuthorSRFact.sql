CREATE function  [dbo].[ft_Tsk_5_16_AuthorSRFact]  ( @dateBegin date = NULL, @dateEnd date = NULL, @categoryCode integer = NULL)
--Реестры Больших прав за период по Distribution & Registry
RETURNS @RT TABLE
(
id integer not null identity primary key,
authorCustId integer, 
authorName   varchar(100),
innerCode	varchar(100),
rateCommiss decimal(10,5), 
amountRest money, 
amountCommiss money, 
amount  money, 
agrStatus integer, 
agrStatusName varchar(100),
BigR smallint 
)
AS
BEGIN  

--declare @dateBegin date, @dateEnd date, @cRightKind integer, @category integer
set @dateBegin = isnull(@dateBegin, (select convert(date, (convert(char(4),year(getdate()))+'-01-01'))))
set @dateEnd = isnull(@dateEnd, getdate())
set @categoryCode = ( Case @categoryCode When 0 then NULL else @categoryCode end)

--commissii
;with TabCommiss as 
(
select t1.custId, sum(t2.amount) as amountComm--, t1.accId, max(t1.accNls) as accNls
from account t1 
join PayTurn t2 on t1.accId = t2.accIdCredit and accDebet like '11%'
where t1.balsCode = 21 
and t2.dateOper between @dateBegin and @dateEnd
group by t1.custId --, accId
),
--переброска 21-20
TabTurn21 as 
(
select t1.custId, sum(t2.amount) as amount, t1.accId, max(t1.accNls) as accNls
from account t1 
join PayTurn t2 on t1.accId = t2.accIdCredit and accDebet like '20%'
where t1.balsCode = 21 
and t2.dateOper between @dateBegin and @dateEnd
group by t1.custId, accId
)
, --Большие/малые права
TabBR as 
(
select t1.custId, max(t3.categoryCode) as  categoryCode
 from TabTurn21 t1 
 join CopyRight t2 on t1.custId = t2.custId 
 join ObjectRight t3 on t2.objId = t3.objId
 group by t1.custId
)

insert into @RT 
(
authorCustId, 
authorName,
innerCode,
rateCommiss, 
amountRest,
amountCommiss, 
amount, 
agrStatus, 
agrStatusName,
BigR
)
select t1.custId, t2.name as rhName, t1.innerCode, isnull(t3.rateCommiss,0) as rateCommiss, t8.amountComm+t7.amount as amountRest,  t8.amountComm,
t7.amount, t4.agrStatus, t5.name as statusName, t9.categoryCode
from RightHolder t1 
join vCustomer t2 on t1.custId = t2.custId 
join AgreementAddRH t3 on t1.custId = t3.custId 
join AgreementMaster t4 on t3.custId = t4.custId 
join AgreementStatus t5 on t4.agrStatus = t5.codeI
join TabTurn21  t7 on t1.custId = t7.custId
left join TabCommiss t8 on t8.custId = t1.custId
join TabBR t9 on t1.custId = t9.custId 
where t9.categoryCode = isnull(@categoryCode, t9.categoryCode)

RETURN 
END
--select * from dbo.ft_Tsk_5_16_AuthorSRFact (NULL, NULL, 0)
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_16_AuthorSRFact] TO [ReportUser]
    AS [dbo];

