
CREATE function [dbo].[ft_Tsk_5_DISTRIBUTED_CM] (@dateBegin date = NULL, @dateEnd date = NULL, @category integer = NULL, @kindCode integer = NULL, @cmCustId integer = NULL)
--@Type = 0/NULL - всі, 1-Великі права, 2-Малі Права
--@dateBegin date = NULL, @dateEnd date = NULL, при NULL или '1900-01-01' поставит первій день текущего месяца 
--@category integer = NULL - все категории, @crKindCode integer = NULL- все виды использования
--ф-я распределения со счета 30 за период
RETURNS @RT TABLE
(
id integer not null identity primary key,
custId integer, 
clCustId integer, 
rhCustId integer, 
objid integer, 
accIdDebet integer,
accIdCredit integer,
kindCode integer, 
categoryCode integer,
amount money, 
regId integer,
regItemId integer, 
cmCustId integer,
turnId integer, 
--22-07-2019
accdebet varchar(30), 
acccredit varchar(30)
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

declare @myCustId integer = (select max(custId) from myAnketa)

--declare @category integer = 5, @kindCode integer = 2, @dateBegin date = '2018-01-01', @dateEnd date = '2020-01-01', @cmCustId integer = 138
--declare @myCustId integer = (select max(custId) from myAnketa)

--Отбираю распределенные на Авторов за период с учетом параметров
insert into @RT (custId, rhCustId, objid, kindCode, amount, categoryCode, accIdDebet, accIdCredit, clCustId, regId, turnId, regItemId, 
                 accDebet, accCredit, cmCustId)  
  select --t2.custId, --здесь м.б. товариство
   t2.custId, 
   t1.custIdRh, 
   t3.objid, substring(t2.accNls,4,2) as kindCode, t1.amount, t3.categoryCode, t1.accIdDebet, t1.accIdCredit, t4.custid, t1.regId, t1.turnId, t1.regIItemId, 
   t1.accDebet, t1.accCredit, isnull(cmCustId, @myCustId) as cmCustId
   from PayTurn t1 
	join PayTurnExtra t4 on t4.turnId = t1.turnId and t4.dateWork = t1.dateWork and t4.balsDebet = 21 and t4.balsCredit in (30,31)
    join Account t2 on t2.accId = t1.accIdCredit 
	join ObjectRight t3 on t3.objid = t2.objid and t3.categoryCode = isnull(@category, t3.categoryCode) 
   where t1.dateWork between @dateBegin and @dateEnd
         and isnull(t4.cmCustId, @myCustId) = isnull(@cmCustId, isnull(t4.cmCustId, @myCustId))
		 and substring(t2.accNls,4,2) = isnull(@kindCode, substring(t2.accNls,4,2))

If @cmCustId is NULL OR @cmCustId = -1
--declare @category integer = 5, @kindCode integer = 2, @dateBegin date = '2018-01-01', @dateEnd date = '2020-01-01', @cmCustId integer = NULL
--declare @myCustId integer = (select max(custId) from myAnketa)
--Нужно добавит зависшие на 31-м счете
 insert into @RT (clCustId, rhCustId, objid, kindCode, categoryCode, accIdDebet, accIdCredit,  amount, cmCustId, turnId, accDebet )
 select -1, -1, max(t1.objid), max(substring(t1.accNls,4,2)) as kindCode, max(t3.categoryCode), t1.accId, NULL, 
  sum(t2.DebOborot) - sum(t2.krdOborot)  as Amount,
  -1, NULL, 
  max(t1.accNls) as accNls
  from Account t1 
  join ObjectRight t3 on t3.objid = t1.objid and t3.categoryCode = isnull(@category, t3.categoryCode) 
  join saldoDay t2 on t2.accId = t1.accId and t2.dateBegin between @dateBegin and @dateENd 
  where t1.balsCode = 31
        and substring(t1.accNls,4,2) = isnull(@kindCode, substring(t1.accNls,4,2))
  group by t1.accId 

 RETURN
 END
--select * from ft_Tsk_5_DISTRIBUTED_CM ('2018-01-01', '2020-12-30', 5, NULL, 138) 


GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_DISTRIBUTED_CM] TO [ReportUser]
    AS [dbo];

