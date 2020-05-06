
CREATE function [dbo].[ft_Tsk_5_DistributedRedRH] (@dateBegin date = NULL, @dateEnd date = NULL, @category integer = NULL, @kindCode integer = NULL, @rhCustId integer = NULL)
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
dateWork date
)
AS
BEGIN  --Користувачі
set  @dateBegin =  (Case WHEN isnull(@dateBegin, '1900-01-01') ='1900-01-01'
                    THEN convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102)
                    ELSE @dateBegin END)
set @dateEnd = isnull(@dateEnd, getdate())
set @kindCode = (Case When isnull(@kindCode,0) = 0 Then NULL Else @kindCode end)
set @category = (Case When isnull(@category,0) = 0 Then NULL Else @category end)
set @rhCustId = (Case When isnull(@rhCustId,0) = 0 Then NULL Else @rhCustId end)
--declare @category integer, @kindCode integer 

--отбираю счета потом
declare @TmpAcc  table 
(accId integer not null primary Key, 
 balsCode integer, 
 kindCode integer, 
 categoryCode integer, 
 objid integer )

--беру только распредделение на авторов
insert into @RT (custId, rhCustId, objid, kindCode, amount, categoryCode, accIdDebet, accIdCredit, clCustId, regId, regItemId, turnId, dateWork)
select a1.custid,a1.custIdRh, a1.objid,a1.kindCode,a1.amount,t3.categoryCode,a1.accIdDebet,a1.accIdCredit,t4.custid,a1.regId, a1.regIItemId, a1.turnId, a1.dateWork from 
   ( select convert(int,substring(t1.accdebet,6,len(t1.accdebet)-5)) custid, t1.custIdRh,convert(int,substring(t1.acccredit,6,len(t1.acccredit)-5)) objid,
	  cast(substring(acccredit, 4,2) as integer) as kindCode,amount,t1.accIdDebet, t1.accIdCredit, --t4.custid,
	   t1.regId, t1.regIItemId, t1.turnId, t1.dateWork  
	   from payturn t1
	   where substring(t1.accdebet,1,2)='21' and
			(substring(t1.accCredit,1,2) = '30' or substring(t1.accCredit,1,2) = '31') and
			t1.dateWork between @dateBegin and @dateEnd
		) a1
    left join PayTurnExtra t4 on t4.turnId = a1.turnId and t4.datework = a1.dateWork
    join ObjectRight  t3 on a1.objid = t3.objId  --17-01-2020
--    left join ObjectRight  t3 on a1.objid = t3.objId  
--17-01-2020	
    where t3.categoryCode = isnull(@category, t3.categoryCode) 
	   and a1.kindCode = isnull(@kindCode, a1.kindCode)
       and a1.custIdRh = isnull(@rhCustId, a1.custIdRh)

insert into @TmpAcc (accId, balsCode, objid, kindCode, categoryCode)
 select distinct  t1.accIdCredit,t2.balscode,t1.objid, t1.kindCode, t1.categoryCode	
  from @RT t1,account t2
 where t2.accid = t1.accIdCredit
UNION 
select distinct  t1.accIdDebet, t2.balscode, t2.objid, cast(substring(t2.accNls, 4,2) as integer) as kindCode, t3.categoryCode	
 from PayTurn t1 
      join account t2 on t2.accid = t1.accIdDebet 
	  join objectRight t3 on t3.objid = t2.objId
where  t1.datework between @dateBegin and @dateEnd
      --t1.datework between '2019-02-01' and '2019-02-28'
      and  t1.accdebet like '31%' and accCredit like '30%' 
      and t3.categoryCode = isnull(@category, t3.categoryCode) 
	  and cast(substring(t1.accDebet, 4,2) as integer) = isnull(@kindCode, cast(substring(t1.accDebet, 4,2) as integer))  --17-01-2020	
	  and @rhCustId is NULL   --все дораспределение только если не для одного автора

--Сообщество теперь берется из платежки
update @RT set cmCustId = t2.custId
   from @RT t1 
       join community t2 on t1.custId = t2.custId 
update @RT set cmCustId = t2.custId
   from @RT t1 
       left join vMyAnk t2  on t2.custId = t2.custId 
	   where t1.cmCustId is NULL

--Нужно добавить зависшие на 31-м счете с учетом дораспределенияБ чтобі в дальнейшем не брать проводки на 31-1, которые дораспределены
;with TabTurnRed as 
(select max(t0.accId) as accId, t1.turnIdRed, t1.dateWorkRed, sum(t1.amount) as amount, 
  max(t0.objid) as objid, max(t0.kindCode) as kindCode, max(t0.categoryCode) as categoryCode
 from @TmpAcc t0 
  join PayTurnRed t1 on t0.accId = t1.accId  --31
  where t1.dateWork  between @dateBegin and @dateEnd 
  group by t1.turnIdRed, t1.dateWorkRed
)
insert into @RT (custId, rhCustId, cmCustId, objid, kindCode, amount, categoryCode, accIdDebet, accIdCredit, clCustId, regId, regItemId, turnId, dateWork)
select -1, isnull(t2.custIdRh, -1), -1, 
        t1.objid, t1.kindCode, t1.amount, t1.categoryCode, t2.accIdDebet, t2.accIdCredit, 
        t3.custid, t2.regId, t2.regIItemId, t2.turnId, t2.dateWork
 from TabTurnRed t1 
   left join payTurn t2 on t2.turnId = t1.turnIdRed and t2.dateWork = t1.dateWorkRed and t2.dateWork  between @dateBegin and @dateEnd
   left join PayTurnExtra t3 on t3.turnid = t2.turnId and t3.datework = t2.dateWork
  

--Для тех, у кот. не проставлен clCustId
update @RT set clCustId = t2.custId, regId = t4.regId, regItemId = t4.regIItemId
  from @RT t1 
	join payTurnRed t3 on t3.turnId = t1.turnId and t3.dateWork = t1.dateWork
	join payTurnExtra t2 on t2.turnid = t3.turnIdRed and t2.dateWork = t3.dateWorkRed
	join PayTurn t4 on t4.turnid = t2.turnid and t4.dateWork = t2.datework
  where isnull(clCustId,0) = 0

--Если схлопнулись на 31-м счете
 delete from @RT 
  where isnull(rhCustId,-1) = -1 and isnull(amount,0) = 0

 /*--Это в ft_Tsk_5_Distributed
--Нужно добавит зависшие на 31-м счете
 insert into @RT (clCustId, objid, kindCode, categoryCode, accIdDebet, accIdCredit,  amount, cmCustId, turnId )
 select -1, max(t1.objid), max(kindCode), max(categoryCode), t1.accId, NULL, 
 (Case WHEN sum(t2.DebOborot) - sum(t2.krdOborot) > 0 Then sum(t2.DebOborot) - sum(t2.krdOborot) Else 0 END) as Amount, -1, NULL
  from @TmpAcc t1 
  join saldoDay t2 on t2.accId = t1.accId and t2.dateBegin between @dateBegin and @dateENd 
  where t1.balsCode = 31
  group by t1.accId 
*/

 RETURN
 END
--select * from ft_Tsk_5_DistributedRedRH ('2019-10-01', '2019-10-31', NULL, NULL, 7794) --142213,34

GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_DistributedRedRH] TO [ReportUser]
    AS [dbo];

