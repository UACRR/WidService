CREATE function [dbo].[ft_Tsk_5_FACTToPay] (@dateBegin date = NULL, @dateEnd date = NULL, @category integer = NULL, @cmFlag integer = NULL)
--Выплата на авторов с комиссией за период
--@dateBegin date = NULL, @dateEnd date = NULL, при NULL или '1900-01-01' поставит первій день текущего месяца 
--@category integer = NULL - все категории,
--@cmFlag - NULL,0-все, 1-свои, 2-чужие
RETURNS @RT TABLE
(
id integer not null identity primary key,
custId integer, --получатель
rHolderType integer, --тип получателя
custIdRh integer, --автор
isSR integer,
isBR integer,
amount money,
amountCommiss money,
rateCommiss money
)
AS
BEGIN  --Користувачі
set  @dateBegin =  (Case WHEN isnull(@dateBegin, '1900-01-01') ='1900-01-01'
                    THEN convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102)
                    ELSE @dateBegin END)
set @dateEnd = isnull(@dateEnd, getdate())
set @category = (Case When isnull(@category,0) = 0 Then NULL Else @category end)
set @cmFlag = (Case When isnull(@cmFlag,0) = 0 Then NULL Else ( case when @cmFlag=2 Then 0 else 1 end ) end)
declare @isSR integer = (case when isnull(@category,5)=5 Then 1 else 0 end), 
        @isBR integer = (case when isnull(@category,6)=6 Then 1 else 0 end)

--declare @category integer
--отбираю счета c которых списание
;with TabAcc as 
( 
select t1.accId, t1.custId as custIdRH, t2.isSR, t2.isBR
   from account t1 
   join vCustomerRHolder t2 on  t2.custId = t1.custId --and t2.isSM = @isSM and t2.isBR=@isBR 
   where  t1.balsCode in (21) 
),
 TabCommiss as 
(
select t1.custIdRH, sum(t2.amount) as amountCommiss
from TabAcc t1 
join PayTurn t2 on t1.accId = t2.accIdCredit and accDebet like '11%' 
     and t2.dateWork between @dateBegin and @dateEnd
group by t1.custIdRh
),
 TabToPay as 
--Переброска
(
select t3.custId, t1.custIdRH, sum(t2.amount) as amount
from TabAcc t1 
join PayTurn t2 on t1.accId = t2.accIdCredit and accDebet like '20%' 
     and t2.dateWork between @dateBegin and @dateEnd
join Account t3 on t2.accIdDebet = t3.accId
--where t3.balsCode = 21 
group by t3.custId, t1.custIdRH
)
 insert into @RT (custId, custIdRh, isSR, isBR, amount, amountCommiss )
  select distinct t2.custId, t1.custIdRh, t1.isSR, t1.isBR,  t2.amount, t3.amountCommiss
   from TabAcc t1 
    join TabToPay t2 on t2.custIdRH = t1.custIdRH 
	join TabCommiss t3 on t3.custIdRH = t2.custIdRH 

 update @RT set rHolderType = t2.rHolderType, rateCommiss = t2.rateCommiss
   from @RT t1 
      join vCustomerRHolder t2 on t2.custId = t1.custId

 RETURN
 END
--select * from ft_Tsk_5_FACTToPay ('2018-01-01', NULL, NULL, NULL)
--select * from PayTurn where accDebet like '20%' or accDebet like '11%'
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_FACTToPay] TO [ReportUser]
    AS [dbo];

