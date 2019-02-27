CREATE function [dbo].[ft_Tsk9_1_RhProfit]  (@dateBegin date = NULL, @dateEnd date = NULL, @userId varchar(48))
RETURNS @RT TABLE
(
 rhCustId integer, 
 rhName varchar(200), 
 interCode varchar(25), 
 amountCollected money,  --Собрано/Заработано
 amountAvailable money,  --Доступено к выплате
 amountTax money--,  --Расчетная сумма налогов  
-- rateCourt decimal(10,5), 	
-- rateCommiss decimal(10,5), 
-- amountTest money
 )
AS
BEGIN  

--Первый день месяца, если NULL
set @dateBegin = Case isnull(@dateBegin, cast('1900-01-01' as date) ) 
    When '1900-01-01' Then convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102) 
    else @dateBegin END 

set @dateEnd = isnull(@dateEnd, getdate())

--Конец предідущего месяґца (на начало текущего месяца)
declare @dateBeginMonth date = cast (dateadd(day,1-day(getdate())-1,getdate()) as date)

--можно проверить, что несколько custId и ничего не показывать или показать общую сумму
declare @custId integer = (select max(t2.custId) 
                            from  aspNetUsers t1 
                              join vCustomer t2 on t1.id = t2.userId 
							 where t1.id = @userId)

declare @rateCommiss decimal(10,5) 
set @rateCommiss = (select rateCommiss 
   from AgreementMaster t1 
     join AgreementAddRh t2 on t1.custId = @custId and t1.agrId = t2.agrId and t1.version = t2.version)


insert into @RT (rhCustId, rhName, interCode, amountCollected, amountAvailable, amountTax )--, rateCourt, rateCommiss)
select t2.custId, t2.name, IPI, 0, 0, 0 --, rateCourt, rateCommiss
  from  vCustomer t2 
   join AgreementMaster t3 on t2.custId = t3.custId 
   join AgreementAddRH t4 on t3.agrId = t4.agrId and t3.version = t4.version  
  where t2.custId = @custId 

;with TabAccount as 
( select t1.accId, t1.custId, t1.accNls, t1.balsCode
   from Account t1 
   where t1.custId = @custId  --221
),  
--amountCollected -зібрано
TabCollected as 
(select t1.custId, sum(amount) as amountCollected
 from TabAccount t1 
      join PayTurn t2 on t1.accid = t2.accIdDebet and t2.accDebet like '21%' and accCredit like '%3%' --заработано 
                      and t2.dateWork between @dateBegin and @dateEnd 
 where t1.custId = @custId
 group by t1.custId
),
--amountAvailable -доступно
TabAvailable as 
(select t1.custId, sum(t2.rest) as amountAvailable
 from TabAccount t1 
      join SaldoDay t2 on t1.accid = t2.accId and t1.balsCode = 20 --Доступно 
           and @dateBeginMonth between t2.dateBegin and t2.dateEnd 
 where t1.custId = @custId
 group by t1.custId
)
update @RT set amountCollected = t1.amountCollected - round(t1.amountCollected*isnull(@rateCommiss,1)/100,2) , 
               amountAvailable = isnull(t2.amountAvailable,0), 
               amountTax = isnull(convert(money, round((t2.amountAvailable*t3.rate/100+t2.amountAvailable*t4.rate/100),2)),0)  --налоги, 
			   --,amountTest = t1.amountCollected 
--select t1.custId, t1.amountCollected, t2.amountAvailable, convert(money, round((t2.amountAvailable*t3.rate/100+t2.amountAvailable*t4.rate/100),2)) as amountTax
  from TabCollected  t1 
     left join TabAvailable t2 on t1.custId = t2.custId 
     left join SystemConstant t3 on t3.codeI in (1) --esv
	 left join SystemConstant t4 on t4.codeI in (2) --military

RETURN
END
/*
 select * from dbo.ft_Tsk9_1_RhProfit ('2018-01-01', '3000-01-01', '8f1f2428-48b4-4209-a577-1fab339c0d82')
 select * from ft_Tsk_5_19_2_SR ('2018-01-01', '3000-01-01', 206, 0)
 select * from ft_Tsk_5_19_2_0SR ('2018-01-01', '3000-01-01', 0) --2957.68 --2772.19
 select * from ft_Tsk_5_19_1_BR ('2018-01-01', '3000-01-01', 206, 0)
 select * from ft_Tsk_5_19_1_0BR ('2018-01-01', '3000-01-01', NULL)
 */
 --select * from vCustomer where custId = 221 --userId = '8f1f2428-48b4-4209-a577-1fab339c0d82' --206