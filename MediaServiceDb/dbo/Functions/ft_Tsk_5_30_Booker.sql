CREATE function  [dbo].[ft_Tsk_5_30_Booker]  (@dateBegin date = NULL, @dateEnd date = NULL, @cmCustId integer = NULL, @rateCommiss decimal(7,3))
--* Реєстр розподілу (бухгалтерський)
-- @rateCommiss - по конкретной комиссии, -1-все комиссии
-- @cmCustId - по конкретному сообществу, 0-все всесообщества, -1-не визначені

--Назва використаного твору	Виконавець - П.І.Б. виконавця (співвиконавців) або назва колективу виконавців	Автор музики (П.І.Б.)	Автор тексту (П.І.Б.)	Тривалість звучання твору (хвил. сек.)	Кількість публічних сповіщень твору	Загальна Тривалість звучання твору (хвил. сек.)	Загальга тривалість в секундах	АВ на твір	Доля автора	 АВ автора 	Правовласник	ПІБ Автора	Код Автора	Каталог	Звіт

RETURNS @RT TABLE
(
 id integer not null identity primary key,
 rhCustId integer, 
 rhName varchar(200), 
 innerInterCode varchar(55), 
 amount money, --АВ
 cmCustId integer,
 cmName varchar(200),
 rateCommiss decimal(5,2), 
 amountCommiss money, --Комісія rУААСП 
 sborESVRate decimal(5,2), -- Відрахування(19%)
 sborESVMoney money, -- Відрахування(19%)
 sborMiliRate decimal(5,2), -- Відрахування(1.5%)
 sborMiliMoney money, -- Відрахування\r(1.5%%)
 AmountToPay money,   -- До виплати 
 rowNum integer
 )
AS
BEGIN  --Користувачі

--Первый день месяца
set  @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())

set @cmCustId = (Case When isnull(@cmCustId,0) = 0 Then NULL Else @cmCustId end)
set @rateCommiss = (Case When isnull(@rateCommiss,-1) = -1 Then NULL Else @rateCommiss end)
--Все по правовласнику

;with TabTurn as 
( 
select  isnull(t3.custId, -1) as rhCustId, sum(t1.amount) as amount, convert(integer,substring(t2.accNls,3,2)) as kindCode
from PayTurn t1 
join Account t2 on t1.accIdCredit = t2.accId and t2.balsCode in (30, 31) 
join Account t3 on t1.accIdDebet = t3.accId and t3.balsCode in (21, 31)
  where dateWork between @dateBegin and @dateEnd
        --dateWork between '2019-02-27' and '2019-02-27'
group by t3.custId, convert(integer,substring(t2.accNls,3,2))
)
 insert into @RT (rhCustId, rhName,  innerInterCode, amount, cmCustId, cmName, rateCommiss, amountCommiss, rowNum)
select 
t1.rhCustId, max(isnull(t2.name, 'НЕ ВИЗНАЧЕНИЙ')) as chName,  
max(t5.innerCode + (Case isnull(t5.interCode,'') when '' Then '' Else ' / '+t5.interCode end)) as innerInterCode, 
sum(t1.amount), isnull(t6.cmCustId, -1) as cmCustId, isnull(max(t6.cmName), 'НЕ ВИЗНАЧНО') as cmName, max(t4.rateCommiss) as rateCommiss, convert(numeric(20,2), sum(t1.amount)*max(isnull(t4.rateCommiss,0))/100 ) as amountCommiss, 
 ROW_NUMBER() OVER( Partition by max(t4.rateCommiss),MAX(t6.cmName) ORDER BY max(t4.rateCommiss),max(t6.cmName), isnull(max(t2.name), '-')) 
from TabTurn t1 
 left join vcustomer t2 on t2.custId = t1.rhCustId
 left join AgreementMaster t3 on t1.rhCustId = t3.custId
 left join AgreementAddRH t4 on t3.agrId = t4.agrId and t3.version = t4.version
 left join RightHolder t5 on t1.rhCustId = t5.custId
 --left join vCustCmService t6 on t1.rhCustId = t6.custId and t1.kindCode = t6.CRKindCode
 left join vTermsOfService t6 on isnull(t6.rhCustId, -1) = isnull(t1.rhCustId,-1) and t6.crKindCode = t1.kindCode 
where 
     isnull(t4.rateCommiss,0) = isnull(@rateCommiss, isnull(t4.rateCommiss,0)) and 
	 isnull(t6.cmCustId, -1) = ISNULL(@cmCustId, isnull(t6.cmCustId,-1)) --ISNULL(-1, t6.cmCustId) 
group by isnull(t4.rateCommiss, 0), t1.rhCustId, isnull(t6.cmCustId,-1)

--, sborESVRate, sborESVMoney, sborMiliRate, sborMiliMoney, AmountToPay
update @RT  
set  sborESVRate = t2.rate, 
     sborESVMoney = convert(numeric(20,2), t1.amount*t2.rate/100), 
	 sborMiliRate = t4.rate, 
	 sborMiliMoney = convert(numeric(20,2), t1.amount*t4.rate/100), 
	 AmountToPay = amount - convert(numeric(20,2), isnull(amountCommiss,0)) - isnull(convert(numeric(20,2), t1.amount*t2.rate/100), 0) - isnull(convert(numeric(20,2), t1.amount*t4.rate/100),0)
from @RT t1
join vMyAnk t3 on t1.cmCustId = t3.custId
full outer join SystemConstant t2 on t2.codeI = 1
full outer join SystemConstant t4 on t4.codeI = 2
where ISNULL(t1.cmCustId,0) = t3.custId

 RETURN
 END

--select  * from ft_Tsk_5_30_Booker ('2019-02-27', '2019-02-27', 0, -1 ) order by rowNum
--select  rhName, innerInterCode, cmName, amount, sborESVMoney, sborMiliMoney, amountCommiss, amountToPay from ft_Tsk_5_30_Booker ('2018-01-01', '2019-01-01',0,20 ) order by rowNum
--select  * from ft_Tsk_5_30_Booker (NULL, '2019-01-01',0, -1  ) order by rowNum
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_30_Booker] TO [ReportUser]
    AS [dbo];

