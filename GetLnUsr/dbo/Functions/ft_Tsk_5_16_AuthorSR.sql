CREATE function  [dbo].[ft_Tsk_5_16_AuthorSR]  ( @dateOper date = NULL, @categoryCode integer = NULL)
--Отчет 27 - по остаткам авторов на дату для переброски
--2019-07-19 - комьюнити не в RightHolder
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

--переброска 21-20 или до нее или после
declare @TmpRT table
(
cmCustId integer, 
authorCustId integer, 
authorName   varchar(100),
dateOper    date,
innerCode	varchar(100),
accId       integer not null,
accNls      varchar(25),
rest        money, 
rateCommiss decimal(10,5), 
amountCommiss money, 
amount  money, 
agrStatus integer, 
agrStatusName varchar(100), 
BigR smallint, 
rhType integer not null,
primary key (accId, rhType)
)

insert into @TmpRT
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
BigR, 
rhType)
select t6.custId, t2.name as rhName, @dateOper, t2.innerCode, t6.accId, t6.accNls, t7.rest,  isnull(t2.rateCommiss,0) as rateCommiss, 
convert(money,t7.rest*t2.rateCommiss/100) as amountComm,
convert(money, t7.rest - t7.rest*t2.rateCommiss/100) as amount, 
t2.agrStatus, t5.name as statusName, (Case When isnull(t2.isBR,0) = 1 Then 6 else 5 end ) as categoryCode, (Case t2.rHolderType WHEN 1 Then 3 Else CASE WHEN t2.rHolderType = 2 Then 1 ELSE 3 END END)
from ACCOUNT t6 
  join SaldoDay t7 on t6.accId = t7.accId and @dateOper between t7.dateBegin and t7.dateEnd
join vCustomerRHolder t2 on t2.custId = t6.custId 
join AgreementStatus t5 on t2.agrStatus = t5.codeI
where t6.balsCode = 21 
  and  isnull(@categoryCode, (Case When isnull(t2.isBR,0) = 1 Then 6 else 5 end )) = (Case When isnull(t2.isBR,0) = 1 Then 6 else 5 end )

insert into @RT 
(authorCustId, authorName, dateOper, innerCode, accId, accNls, rest,  rateCommiss, amountCommiss,  amount, agrStatus, agrStatusName, BigR)
select authorCustId, authorName, dateOper, innerCode, accId, accNls, rest, rateCommiss, amountCommiss, amount, agrStatus, agrStatusName, BigR
 from @TmpRT
 order by rhType, authorName

RETURN 
END

--select * from ft_Tsk_5_16_AuthorSR (NULL, 5)


GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_16_AuthorSR] TO [ReportUser]
    AS [dbo];

