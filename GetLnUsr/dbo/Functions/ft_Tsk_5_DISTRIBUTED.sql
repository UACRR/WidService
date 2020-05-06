
CREATE function [dbo].[ft_Tsk_5_DISTRIBUTED] (@dateBegin date = NULL, @dateEnd date = NULL, @category integer = NULL, @kindCode integer = NULL)
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

--отбираю счета
declare @TmpAcc  table 
(accId integer not null primary Key, 
 balsCode integer, 
 kindCode integer, 
 categoryCode integer, 
 objid integer, 
 accNls varchar(30))  --22-07-2019

insert into @TmpAcc (accId, balsCode, objid, kindCode, categoryCode, accNls)
 select t1.accId,t1.balsCode, t1.objid, cast(substring(accnls, 4,2) as integer) as kindCode, t2.categoryCode, t1.accNls
   from account t1 
   join ObjectRight t2 on t1.objId = t2.objId and t2.categoryCode = isnull(@category, t2.categoryCode)
   where t1.balsCode in ( 30, 31) and 
         cast(substring(accnls, 4,2) as integer) = isnull(@kindCode , cast(substring(accnls, 4,2) as integer))

insert into @RT (custId, rhCustId, objid, kindCode, amount, categoryCode, accIdDebet, accIdCredit, clCustId, regId, turnId, regItemId, 
                 accDebet, accCredit)  
  select --t2.custId, --здесь м.б. товариство
   t2.custId, 
   t1.custIdRh, 
   t3.objid, t3.kindCode, t1.amount, t3.categoryCode, t1.accIdDebet, t1.accIdCredit, t4.custid, t1.regId, t1.turnId, t1.regIItemId, 
   t1.accDebet, t1.accCredit
   from PayTurn t1 
    left join PayTurnExtra t4 on t4.turnId = t1.turnId and t4.dateWork = t1.dateWork
    join Account t2 on t2.accId = t1.accIdDebet and t2.balsCode = 21  --распределение на авторов, в т.ч. со счета 31
    join @TmpAcc t3 on t3.accId = t1.accIdCredit and t3.balsCode in (30, 31)    
   where t1.dateWork between @dateBegin and @dateEnd

--Сообщество берется по обслуживанию
--update @RT set cmCustId = t2.cmCustId 
--   from @RT t1 
--       join vCustCmService t2 on t1.rhCustId = t2.custId and t1.kindCode = t2.crKindCode

--Сообщество теперь берется из платежки
update @RT set cmCustId = t2.custId
   from @RT t1 
       join community t2 on t1.custId = t2.custId 

update @RT set cmCustId = t2.custId
   from @RT t1 
       left join vMyAnk t2  on t2.custId = t2.custId 
	   where t1.cmCustId is NULL

--Нужно добавит зависшие на 31-м счете
 insert into @RT (clCustId, rhCustId, objid, kindCode, categoryCode, accIdDebet, accIdCredit,  amount, cmCustId, turnId, accDebet )
 select -1, -1, max(t1.objid), max(kindCode), max(categoryCode), t1.accId, NULL, 
 --(Case WHEN sum(t2.DebOborot) - sum(t2.krdOborot) > 0 Then sum(t2.DebOborot) - sum(t2.krdOborot) Else 0 END) as Amount,  --19-07-2019 не идет с балансом! 
  sum(t2.DebOborot) - sum(t2.krdOborot)  as Amount,
  -1, NULL, 
  max(t1.accNls) as accNls
  from @TmpAcc t1 
  join saldoDay t2 on t2.accId = t1.accId and t2.dateBegin between @dateBegin and @dateENd 
  where t1.balsCode = 31
  group by t1.accId 

 RETURN
 END
--select * from ft_Tsk_5_DISTRIBUTED ('2019-07-19', NULL, 5, NULL) --141974,07
--select * from ft_Tsk_5_DISTRIBUTED (NULL, NULL, NULL, NULL) --141974,07
--select * from payturn where custidRh <> cast(right(accdebet,6) as integer) and accDebet like '21%'
/*

 select * --sum(deboborot), sum(krdOborot) 
  from account t1 
   join saldoDay t2 on t2.accId = t1.accId and t2.dateBegin between '2019-07-19' and '2019-07-19' 
 where t1.balsCode = 31
 and t2.DebOborot - t2.krdOborot <= 0 
*/

GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_DISTRIBUTED] TO [ReportUser]
    AS [dbo];

