CREATE function ft_Tsk9_3_RhCrProfit  (@dateBegin date, @dateEnd date,  @userId varchar(48))
--ФОРМА ДОХОДЫ В РАЗРЕЗЕ ВИДОВ ПРАВ:
RETURNS @RT TABLE
(
 cRightKind integer not null primary Key, 
 cRightName varchar(700), 
 cRGroupType integer,
 cRGroupName varchar(200),
 amountProfit money
 --, 
 --amountTest money, 
 --custId integer,
 --delta money 
 )
AS
BEGIN  

--Первый день месяца, если NULL
set @dateBegin = Case isnull(@dateBegin, cast('1900-01-01' as date) ) 
    When '1900-01-01' Then convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102) 
    else @dateBegin END 

set @dateEnd = isnull(@dateEnd, getdate())

--Определяю пользователя
declare @custId integer = (select max(t2.custId) 
                            from  aspNetUsers t1 
                              join vCustomer t2 on t1.id = t2.userId 
							 where t1.id = @userId)

declare @rateCommiss decimal(10,5) 
set @rateCommiss = (select rateCommiss 
   from AgreementMaster t1 
     join AgreementAddRh t2 on t1.custId = @custId and t1.agrId = t2.agrId and t1.version = t2.version)

--Упало ср-в по видам права
declare  @TmpRT   table 
(  objid integer not null, 
   cRightKind integer , 
   amount money, 
  primary key (objid) ) 

;With TabAccount as 
 (
select  accId, custId 
  from Account where custId = @custId and balsCode = 21
)
  insert into @TmpRT (objid, cRightKind, amount)
  select t3.objid, max((CASE  isnull(t3.objid,0) When 0 THEN 0 Else convert(integer, substring(t2.accCredit,4,2)) END)), sum(t2.amount)
    from TabAccount t1 
       join PayTurn t2 on t2.dateWork between @dateBegin and @dateEnd and 
                          t1.accId = t2.accIdDebet
	   join Account t3 on t2.accIdCredit = t3.accId
  group by t3.objid

--Result
 insert into @RT (cRightKind, cRightName, cRGroupType, cRGroupName, amountProfit) --, amountTest, custId ) 
 select max( t1.cRightKind), max(t2.name), max(t2.crGroupCode), max(t3.name), 
        convert(money,round(sum(t1.amount) - sum(t1.amount)*@rateCommiss/100,2)) --, sum(t1.amount), @custId
   from   @TmpRT t1  
      left join copyRightKind t2  on t1.cRightKind = t2.codeI  
      left join CRKindGroup  t3 on t3.codeI = t2.crGroupCode   
	group by t1.cRightKind

--Корректировка по округлению
declare @delta money 
set @delta = (( select  convert(money,  round(sum(amount) - @rateCommiss*sum(amount)/100,2))  from @TmpRT) - ( select  sum(amountProfit) from @RT ) )

--Сбрасываю на самую большую сумму
 update @RT set amountProfit = amountProfit + @delta--, delta = @delta
  from @RT 
  where cRightKind = (select max(cRightKind ) from @RT where amountProfit = (select max(amountProfit) from @RT))
  and amountProfit + @delta > 0

RETURN
END
/*
select * from ft_Tsk9_3_RhCrProfit ('2018-01-01', '3000-01-01','8f1f2428-48b4-4209-a577-1fab339c0d82') --2366,14
select * from ft_Tsk9_1_RhProfit  ('2018-01-01', '3000-01-01','8f1f2428-48b4-4209-a577-1fab339c0d82') --2366,14	2957,68
*/


GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk9_3_RhCrProfit] TO [ReportUser]
    AS [dbo];

