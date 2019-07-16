CREATE function ft_Tsk9_2_RhObjProfit  (@dateBegin date = NULL, @dateEnd date = NULL, @userId varchar(48))
RETURNS @RT TABLE
(
 objid integer not null primary Key, 
 objName varchar(200), 
 genreName varchar(200), 
 duration char(8), 
 specName varchar(100), 
 rate decimal (5,2), 
 amountProfit money,  --Собрано/Заработано
 amountTest money,  --для проверки
 delta money, 
 custId integer 
 )
AS
BEGIN  

--Заработано всего на портале

--Первый день месяца, если NULL
set @dateBegin = Case isnull(@dateBegin, cast('1900-01-01' as date) ) 
    When '1900-01-01' Then convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102) 
    else @dateBegin END 

set @dateEnd = isnull(@dateEnd, getdate())

--можно проверить, что несколько custId и ничего не показывать или показать общую сумму
declare @custId integer = (select max(t2.custId) 
                            from  aspNetUsers t1 
                              join vCustomer t2 on t1.id = t2.userId 
							 where t1.id = @userId)
declare @rateCommiss decimal(10,5) 
set @rateCommiss = (select rateCommiss 
   from AgreementMaster t1 
     join AgreementAddRh t2 on t1.custId = @custId and t1.agrId = t2.agrId and t1.version = t2.version)

--Упало ср-в по объектам
declare  @TmpRT   table 
( objid integer not null, 
  amount money, 
  primary key (objid) ) 

;  with TabAccount as 
 (
select  accId, custId 
  from Account where custId = @custId and balsCode = 21
)
  insert into @TmpRT (objid, amount)
  select isnull(t3.objid,0) as objid, sum(t2.amount)
    from TabAccount t1 
       join PayTurn t2 on t2.dateWork between @dateBegin and @dateEnd and 
                          t1.accId = t2.accIdDebet
	   join Account t3 on t2.accIdCredit = t3.accId
  group by t3.objid

--Result
insert into @RT (objid, objName, genreName, duration, specName, amountProfit,  amountTest, custId) 
 select  t1.objid, t2.name, t3.name, cast(t4.duration as char(8)), t5.name, convert(money,round(t1.amount - t1.amount*@rateCommiss/100,2)), t1.amount, @custId
   from   @TmpRT t1  
      join ObjectRight t2  on t1.objid = t2.objId  
      left join genreType t3 on t3.codeI = t2.genreType   
      left join MediaTrack t4 on t1.objid = t4.objid 
      left join SpecType t5 on t2.specType = t5.codeI 

--Процент владения только подтвержденный
;with TabRate as 
(
select t2.custId, t2.objId, sum(isnull(t2.rate,0))  as rate
   from @RT t1
      join CopyRight t2 on t2.custId = @custId  and t2.objid = t1.objid and t2.status = 1
	  join ObjectRight t3 on t3.objid = t2.objId 
      group by t2.custId, t2.objId
)
 update @RT set rate = t2.rate
   from @RT t1
      join TabRate t2 on t2.objid = t1.objid and t2.custId = t1.custId  

--Корректировка по округлению
declare @delta money 
set @delta = (( select  convert(money,  round(sum(amount) - @rateCommiss*sum(amount)/100,2))  from @TmpRT) - ( select  sum(amountProfit) from @RT ) )

--Сбрасываю на самую большую сумму
update @RT set amountProfit = amountProfit + @delta, delta = @delta
  from @RT 
  where objid = (select max(objid ) from @RT where amountProfit = (select max(amountProfit) from @RT))
  and amountProfit + @delta > 0

RETURN
END
/*
select * from ft_Tsk9_2_RhObjProfit ('2018-01-01', '3000-01-01', '8f1f2428-48b4-4209-a577-1fab339c0d82')
select top 2 objname, genreName, duration, specName, rate, amountCollected from ft_Tsk9_2_RhObjProfit ('2018-01-01', '3000-01-01', '8f1f2428-48b4-4209-a577-1fab339c0d82') order by
*/
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk9_2_RhObjProfit] TO [ReportUser]
    AS [dbo];

