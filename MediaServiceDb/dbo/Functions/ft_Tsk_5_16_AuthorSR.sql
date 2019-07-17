CREATE function  [dbo].[ft_Tsk_5_16_AuthorSR]  ( @dateOper date = NULL, @categoryCode integer = NULL)
--Реестры Больших прав за период по Distribution & Registry
RETURNS @RT TABLE
(
id integer not null identity primary key,
authorCustId integer, 
authorName   varchar(100),
dateOper    date,
innerCode	varchar(100),
accId       integer,
accNls      varchar(25),
rest        money, 
rateCommiss decimal(10,5), 
amountCommiss money, 
amount  money, 
agrStatus integer, 
agrStatusName varchar(100), 
BigR smallint
)
AS
BEGIN  

--declare @dateBegin date, @dateEnd date, @cRightKind integer, @category integer
set @dateOper = isnull(@dateOper, getdate())
set @categoryCode = ( Case @categoryCode When 0 then NULL else @categoryCode end)

--переброска 21-20
;with TabBR as 
(
select t1.custId, max(t3.categoryCode) as  categoryCode
 from RightHolder t1 
 join CopyRight t2 on t1.custId = t2.custId 
 join ObjectRight t3 on t2.objId = t3.objId
 group by t1.custId
)
insert into @RT 
(
authorCustId, 
authorName,
dateOper,
innerCode,
accId,
accNls,
rest, 
rateCommiss, 
amountCommiss, 
amount, 
agrStatus, 
agrStatusName,
BigR)
select t1.custId, t2.name as rhName, @dateOper, t1.innerCode, t6.accId, t6.accNls, t7.rest,  isnull(t3.rateCommiss,0) as rateCommiss, convert(money,t7.rest*t3.rateCommiss/100) as amountComm,
convert(money, t7.rest - t7.rest*t3.rateCommiss/100) as amount, t4.agrStatus, t5.name as statusName, t9.categoryCode
from RightHolder t1 
join vCustomer t2 on t1.custId = t2.custId 
join AgreementAddRH t3 on t1.custId = t3.custId 
join AgreementMaster t4 on t3.custId = t4.custId 
join AgreementStatus t5 on t4.agrStatus = t5.codeI
join Account t6 on t6.custId = t1.custId and t6.balsCode = 21
join SaldoDay t7 on t6.accId = t7.accId and @dateOper between t7.dateBegin and t7.dateEnd
join TabBR t9 on t1.custId = t9.custId 
where t9.categoryCode = isnull(@categoryCode, t9.categoryCode)
RETURN 
END

--select * from ft_Tsk_5_16_AuthorSR (NULL, 5)
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_16_AuthorSR] TO [ReportUser]
    AS [dbo];

