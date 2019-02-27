CREATE function [dbo].[ft_Tsk_5_COLLECTED] (@dateBegin date = NULL, @dateEnd date = NULL, @category integer = NULL, @kindCode integer = NULL)
--@Type = 0/NULL - всі, 1-Великі права, 2-Малі Права
--@dateBegin date = NULL, @dateEnd date = NULL, при NULL или '1900-01-01' поставит первій день текущего месяца 
--@category integer = NULL - все категории, @crKindCode integer = NULL- все виды использования
--ф-я сборов на счет 30
RETURNS @RT TABLE
(
id integer not null identity primary key,
clCustId integer, 
objid integer, 
accIdDebet integer,
accIdCredit integer,
kindCode integer, 
categoryCode integer,
amount money,
regId integer, 
regItemId integer
)
AS
BEGIN  --Користувачі
set  @dateBegin =  (Case WHEN isnull(@dateBegin, '1900-01-01') ='1900-01-01'
                    THEN convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102)
                    ELSE @dateBegin END)
set @dateEnd = isnull(@dateEnd, getdate())
set @kindCode = (Case When isnull(@kindCode,0) = 0 Then NULL Else @kindCode end)
set @category = (Case When isnull(@category,0) = 0 Then NULL Else @category end)
--declare @category integer, @kindCode integer 
--отбираю счета
;with TabAcc as 
( 
select t1.accId, t1.objid, cast(substring(accnls, 4,2) as integer) as kindCode, t2.categoryCode
   from account t1 
   join ObjectRight t2 on t1.objId = t2.objId and t2.categoryCode = isnull(@category, t2.categoryCode)
   where  t1.balsCode = 30 and 
          cast(substring(accnls, 3,2) as integer) = isnull(@kindCode , cast(substring(accnls, 3,2) as integer))
)
 insert into @RT (clCustId, objid, kindCode, amount, categoryCode, accIdDebet, accIdCredit, regId, regItemId)
  select t2.custId, t3.objid, t3.kindCode, t1.amount, t3.categoryCode, t1.accIdDebet, t1.accIdCredit, t1.regId, t1.regIItemId
   from PayTurn t1 
    join Account t2 on t2.accId = t1.accIdCredit and t2.balsCode = 22
    join TabAcc t3 on t3.accId = t1.accIdDebet    
   where t1.dateWork between @dateBegin and @dateEnd
 RETURN
 END
--select * from ft_Tsk_5_COLLECTED (NULL, NULL, 6, NULL)