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

--declare @cmCustId integer, @rateCommiss float 

declare  @TabTurn table
(rhCustId integer not null, 
 rhCustIdTurn integer not null, 
 amount money, 
 kindCode char(2) not null, 
 cmCustid integer, 
 rateCommiss decimal(5,2)
 primary key (rhCustId, rhCustIdTurn, kindCode )
)

insert into @TabTurn (rhCustId, rhCustIdTurn, amount, kindCode) 
select  isnull(t3.custId, -1) as rhCustId, isnull(t1.custIdRh, -1) as rhCustIdTurn,
        sum(t1.amount) as amount, 
		convert(integer,substring(t2.accNls,3,2)) as kindCode 
from PayTurn t1 
join Account t2 on t1.accIdCredit = t2.accId and t2.balsCode in (30, 31) 
join Account t3 on t1.accIdDebet = t3.accId and t3.balsCode in (21, 31)
  where dateWork between @dateBegin and @dateEnd
        --dateWork between '2019-12-12' and '2019-12-12'
group by t3.custId, convert(integer,substring(t2.accNls,3,2)), t1.custIdRh

--комиссии
update @TabTurn set rateCommiss = t2.rateCommiss
  from @TabTurn t1 
   join vCustomerRHolder t2 on t1.rhCustId = t2.custId

--ПРоставляю ид.общества 
update @TabTurn set cmCustid = (Case WHEN rhCustId = -1 Then -1 ELSE CASE WHEN rhCustId = rhCustIdTurn Then t2.custId Else rhCustId END END)
  from @TabTurn t1 
   cross join vMyAnk t2 

--select *  from @TabTurn

insert into @RT (rhCustId, rhName,  innerInterCode, amount, cmCustId, cmName, rateCommiss, amountCommiss, rowNum)
select 
max(t1.rhCustIdTurn) as rhCustId, max(isnull(t2.name, 'НЕ ВИЗНАЧЕНИЙ')) as chName,  
max(t2.innerCode + (Case isnull(t2.interCode,'') when '' Then '' Else ' / '+t2.interCode end)) as innerInterCode, 
--sum(Case When t1.rhCustId = -1 Then t1.amount - t10.s_2131 Else amount END), 
sum(t1.amount), 
isnull(t1.cmCustId, -1) as cmCustId, isnull(max(t7.Name), 'НЕ ВИЗНАЧНО') as cmName, 
max(t1.rateCommiss) as rateComiss,
convert(numeric(20,2), sum(t1.amount)*max(isnull(t1.rateCommiss ,0))/100 ) as amountCommiss, 
ROW_NUMBER() OVER( Partition by max(t1.rateCommiss), MAX(t7.Name) ORDER BY max(t1.rateCommiss),max(t7.Name), isnull(max(t2.name), '-')) 
from @TabTurn t1 
 left join vCustomerRHolder t2 on t2.custId = t1.rhCustIdTurn
 --left join AgreementMaster t3 on t1.rhCustId = t3.custId
-- left join AgreementAddRH t4 on t3.agrId = t4.agrId and t3.version = t4.version
-- left join RightHolder t5 on t1.rhCustIdTurn = t5.custId
 left join vCustomerRHolder t7 on t7.custId = t1.cmCustid
where 
     isnull(t1.rateCommiss ,0) = isnull(@rateCommiss, isnull(t1.rateCommiss,0)) and 
	 isnull(t1.cmCustId, -1) = ISNULL(@cmCustId, isnull(t1.cmCustId,-1)) --ISNULL(-1, t6.cmCustId) 
group by isnull(t1.rateCommiss , 0), t1.rhCustIdTurn, isnull(t1.cmCustId,-1)

--, sborESVRate, sborESVMoney, sborMiliRate, sborMiliMoney, AmountToPay
update @RT  
set  sborESVRate = t2.rate, 
     sborESVMoney = (CASE When t7.custType = 1 Then convert(numeric(20,2), t1.amount*t2.rate/100) ELSE 0 end), 
	 sborMiliRate = (CASE When t7.custType = 1 THEN t4.rate ELSE 0 end), 
	 sborMiliMoney =(CASE WHEN t7.custType = 7 THEN convert(numeric(20,2), t1.amount*t4.rate/100) else 0 END), 
	 AmountToPay = amount - convert(numeric(20,2), isnull(amountCommiss,0)) - isnull(convert(numeric(20,2), t1.amount*t2.rate/100), 0) - isnull(convert(numeric(20,2), t1.amount*t4.rate/100),0)
from @RT t1
join vMyAnk t3 on t1.cmCustId = t3.custId
join Customer t7 on t7.custId = t1.rhCustId 
full outer join SystemConstant t2 on t2.codeI = 1
full outer join SystemConstant t4 on t4.codeI = 2
where ISNULL(t1.cmCustId,0) = t3.custId 

 RETURN
 END

GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_30_Booker] TO [ReportUser]
    AS [dbo];

