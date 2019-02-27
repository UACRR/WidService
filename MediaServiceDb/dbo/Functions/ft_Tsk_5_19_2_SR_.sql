CREATE function [dbo].[ft_Tsk_5_19_2_SR_]  (@dateBegin date = NULL, @dateEnd date = NULL, @custId integer = NULL,  @cmCustId integer = NULL)
--Великі права. Звіт про авторську винагороду по Автору  або авторам з Товариства 
-- @custId - по конкретному правообладателю. 0-все правообладатели за период
-- @cmCustId - по конкретному сообществу, 0-выбрать всесообщества, -1 - не визначено

--Назва використаного твору	Виконавець - П.І.Б. виконавця (співвиконавців) або назва колективу виконавців	Автор музики (П.І.Б.)	Автор тексту (П.І.Б.)	Тривалість звучання твору (хвил. сек.)	Кількість публічних сповіщень твору	Загальна Тривалість звучання твору (хвил. сек.)	Загальга тривалість в секундах	АВ на твір	Доля автора	 АВ автора 	Правовласник	ПІБ Автора	Код Автора	Каталог	Звіт

RETURNS @RT TABLE
(
 id integer not null identity primary key,
 clCustId integer, --назва театру
 clName varchar(200), 
 periodId integer, 
 periodName varchar(100), 
 periodDate varchar(100), 
 regId integer, 
 fileName varchar(100), 
 regIItemId integer,  
 ItemName varchar(200), --назва твору
 objid integer, 
 performer varchar(200), 
 AutorMusic varchar(200),
 AutorText varchar(200),
 durationUse varchar(15), 
 countUse integer, --к-ть 
 fullDuration varchar(15), --datetime, --загальна тривалість
 fullDurationSec integer, -- Загальна тривалість в секундах
 rHcustId integer, 
 cRName varchar(200),   --Наименование правообладателя
 innerCode varchar(25), 
 interCode varchar(25), 
 roleCode integer, 
 roleName varchar(100), 
 Rate decimal (5,2), 
 authAmount money, --АВ за твір
 objAmount money, --зібрано на твір 
 cmCustId integer,
 cmCustIdName varchar(200),
 commRate decimal(5,2), 
 commAmount money, --Комісія rУААСП 
 sborESVRate decimal(5,2), -- Відрахування(19%)
 sborESVMoney money, -- Відрахування(19%)
 sborMiliRate decimal(5,2), -- Відрахування(1.5%)
 sborMiliMoney money, -- Відрахування\r(1.5%%)
 AmountToPay money,  -- До виплати 
 CatalogName varchar(200) --каталог
)
AS
BEGIN  --Користувачі

--declare @dateBegin date, @dateEnd date, @cRightKind integer, @category integer,  @ourAuthor smallint
--Первый день месяца
set  @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())

set @custId = (Case When isnull(@custId,0) = 0 Then NULL Else @custId end)
set @cmCustId = (Case When isnull(@cmCustId,0) = 0 Then NULL Else @cmCustId end)

--Зараховано  на правовласників. Все, что упало на счет 21
--Сразу записать в @RT

--drop table @Tmp31
--create table @Tmp31 
declare @Tmp31  table
(rhCustId integer not null, 
 acc31 integer not null, 
 acc30 integer not null, 
 custId integer not null, 
 clName varchar(200), 
 countUse integer, 
 amount money, 
 primary key (rhCustId, acc31,custId))

--drop table @Tmp31Cl
--create table @Tmp31Cl 
--drop table #Tmp31Cl  
declare @Tmp31Cl  table
(rhCustId integer not null, 
 acc31 integer not null,
 clName varchar(500), 
 countUse integer, 
 primary key (rhCustId, acc31)
 )

--drop table #TmpRH
-- create table @TmpRH 
 declare @TmpRH table 
 (turnId integer not null, 
  dateWork date, 
  rhCustId integer not null, 
  objid integer null, 
  authAmount money, 
  regId integer, 
  regItemId integer, 
  accIdCredit integer, 
  accIdDebet integer, 
  clCustId integer, 
  clCustName varchar(500), 
  periodId integer, 
  periodName varchar(200), 
  periodDate varchar(100), 
  fileName varchar(200), 
  ItemName varchar(200), 
  countUse integer, 
  durationUse time, 
  kindCode integer, 
  objAmount money, 
  cmCustId integer,
  primary Key (rhCustId, turnId)) 

declare @TmpObj table
(rhCustId integer not null, 
 objid integer null, 
 regid integer not null, 
 regItemId integer not null, 
 amount money, 
 primary key (rhCustId, regId, regItemId)
 )
 -----------
/*
--Все, что упало клиенту
;with TabAccount as 
( select t1.accId, t1.custId, t1.accNls, t1.balsCode
   from Account t1 
   where t1.balsCode= 21 and t1.custId = isnull(@custId, t1.custId)   --221
)  
 insert into @TmpRH ( rhCustId, objid, authAmount, regId, regItemId, turnId, accIdDebet, accIdCredit, dateWork, kindCode )
 select t1.custId, t3.objid, t2.amount, t2.regId, t2.regIItemId, t2.turnId, t2.accIdDebet, t2.accIdCredit, t2.dateWork, convert(integer, substring(t3.accnls,4,2))
 from TabAccount t1 
      left join PayTurn t2 on t1.accid = t2.accIdDebet  and t2.dateWork between @dateBegin and @dateEnd 
      join Account t3 on t3.accId = t2.accIdCredit -- счет 30/31
	  left join ObjectRight t4 on t4.objId = t3.objId and t4.categoryCode = 5  --малые права. Если будут большие - тоже добавится
*/

insert into @TmpRH ( rhCustId, objid, authAmount, regId, regItemId, turnId, accIdDebet, accIdCredit, dateWork, kindCode, clCustId, cmCustId )
select rhCustId, objid, amount, regId, regItemId, turnId, accIdDebet, accIdCredit, dateWork, kindCode, clCustId, cmCustId
from ft_Tsk_5_DISTRIBUTEDRed (@dateBegin, @dateEnd, 5, NULL) where rhCustId = @custId
--categoryCode, cmCustId		

--отобрать нужные комьюнити


------

--клиента проставляю по данным отчета 
update @TmpRH 
  set cLCustId = t4.custId, 
      periodId = t4.periodId, 
      periodName = t4.periodName, 
      periodDate = convert(char(12), t4.beginDate)+'-'+convert(char(12), t4.endDate), 
      fileName = t2.fileName
  from @TmpRH  t1 
   join register t2 on t1.regId = t2.regId 
   join RegisterRatedList t3 on t3.rmid = t2.rmId
   join PaidPeriod t4 on t4.periodId = t3.periodId

--Название их звита
update @TmpRH 
   set ItemName = t2.ItemName,  
       countUse  = t2.countUse, 
	   durationUse = t2.durationUse
  from @TmpRH t1 
  join RegisterItem t2 on t1.regId = t2.regId and t1.regItemId = t2.regIItemId 
      
----------------------------------------------------------------
/*
--c которого поступило (дораспределенные)
delete @Tmp31
;with Tab3031 as 
(select distinct t1.rhCustId,  t2.accIdDebet, t2.accIdCredit, t2.amount
 from @TmpRH t1
  join payTurn t2 on t1.accIdCredit = t2.accIdDebet
--  join Account t3 on t2.acc
  where t1.clCustId is NULL 
)
insert into @Tmp31 (rhCustId, acc31, acc30, custId,  t5.countUse, amount )
select t1.rhCustId,  t1.accIdDebet as acc31, max(t1.accIdCredit) as acc30, t3.custId, sum(isnull(t5.countUse,0)) as countUse, sum(t2.amount)
--t2.turnId, t2.dateWork, t2.accIdDebet, t2.accIdCredit, t2.amount, t3.custId, t2.regId, t5.countUse
 from Tab3031 t1 
  join payTurn t2 on t1.accIdCredit = t2.accIdDebet and t2.dateWork between @dateBegin and @dateEnd --!!!(не учитывать период для дораспределения?)
  join account t3 on t3.accId = t2.accIdCredit 
  left join RegisterItem t5 on t2.regId = t5.regId and t2.regIItemId = t5.regIItemId
 group by t1.rhCustId, t1.accIdDebet, t3.custId

  update @Tmp31 set  clName = t2.name 
     from @Tmp31 t1 
     join vCustomer t2 on t1.custId = t2.custId 
---------------------------------------------------
--собрано по счету, клиенты в одну строку - дораспределение
insert into @Tmp31Cl  (t1.rhCustId, acc31, countUse, clName)
SELECT t1.rhCustId, acc31, sum(countUse),
    abc = STUFF(
                 (SELECT ', ' + clName FROM @Tmp31 t2 where t1.rhCustId = t2.rhCustId and t1.acc31 = t2.acc31 FOR XML PATH ('')), 1, 1, '' 
               ) 
FROM @Tmp31 t1 
GROUP BY t1.rhCustId, acc31

----------------------------------------------------------------
--Проставляю только для дораспределенных
update @TmpRH 
 set clCustName = t2.clname, 
     periodName = dbo.fs_PeriodName (1, t1.dateWork),
     periodDate = convert(char(12), dbo.fs_PeriodBegin (1, t1.dateWork)) + '-'+ convert(char(12), dbo.fs_PeriodEnd (1, t1.dateWork)),
     itemName = t3.name, 
     countUse = t2.countUse
   from @TmpRH t1 
   join @Tmp31Cl t2 on t1.rhCustId = t2.rhCustId and t1.accIdCredit = t2.acc31
   join ObjectRight t3 on t3.objId = t1.objId

-------------------
update @TmpRH 
 set clCustName = t2.Name 
   from @TmpRH t1 
   join vCustomer t2 on t1.clCustid = t2.custId

----------------
--Собрано на объект права всего за период без дораспределения
;with TabAcc30 as 
  (
  select distinct t1.rhCustId, t1.accidCredit, t1.regId, t1.regItemId,t1.objid
     from @TmpRH t1
	 where isnull(t1.regid,0)<> 0 
  )
  insert into @TmpObj (rhCustId, objid, regId, regItemId, amount)
  select max(t1.rhCustId), t1.objid, t1.regId, t1.regItemId, sum(t2.amount) 
	 from TabAcc30 t1 
	  join PayTurn t2 on dateWork between @dateBegin and @dateEnd and 
	    t1.accIdCredit = t2.accIdDebet and t2.regId = t1.regId and t2.regIItemId = t1.regItemId
	  group by t1.objid, t1.regId, t1.regItemId

  ;with TabAcc30 as 
  (
   select t1.rhCustId, t1.acc30, t2.objid  
      from @Tmp31 t1 
	  join account t2 on t1.acc30 = t2.accId
   ) 
    insert into @TmpObj (rhCustId, objid, regId, regItemId, amount)
	select max(t1.rhCustId), t1.objid, 0, 0, sum(t2.amount) 
	 from TabAcc30 t1 
	  join PayTurn t2 on dateWork between @dateBegin and @dateEnd and 
	    t1.acc30 = t2.accIdDebet 
	  group by t1.objid
 
 update @TmpRH set objAmount = t6.amount 
    from @TmpRH t1 
     join @TmpObj t6 on t6.objid = t1.objid and t6.regid = isnull(t1.regId,0) and t6.regItemId = isnull(t1.regItemId,0)

*/
 ------------------------
--Заливаю в результат с комьюнити
insert into @RT 
( clCustId, clName, periodId, periodName, periodDate, regId, fileName, regIItemId, ItemName, objid, countUse,
  durationUse, rHcustId,  authAmount, cmCustId, objAmount
)
select 
  t1.clCustId, t1.clCustName, t1.periodId, t1.periodName, t1.periodDate, t1.regId, t1.fileName, t1.regItemId, t1.ItemName, t1.objid, t1.countUse,
  t1.durationUse, t1.rHcustId,  authAmount, 
 ( Case t3.ourService When 1 Then t5.custId ELSE isnull(t4.cmCustId, -1) END ), t1.objAmount
 from @TmpRH t1 
   --join vCustCmService t2 on t1.rHcustId = t2.custId and t1.kindCode = t2.crKindCode
   join TermsOfService t3 on t3.custId = t1.rhCustId and t3.CRKindCode = t1.kindCode 
   left join CustCmRight t4 on t4.custId = t3.custId and t4.cRKindCode = t3.CRKindCode
   left join vMyAnk t5 on t5.custId = t5.custId
/*
--Удаляю комьюнити. Пока так проще
--if isnull(@cmCustId,0) <> 0 
--  delete @RT 
--    where cmCustId <> @cmCustId


 update @RT set cmCustIdName = isnull(t2.name, 'Не ВИЗНАЧЕНО')
   from @RT t1 
     left join vCustomer t2 on t1.cmCustId = t2.custId
 
 update @RT set cRName = t2.name 
  from @RT t1 
     join vcustomer t2 on t1.rHcustId = t2.custId

update @RT 
 set roleCode = t2.roleCode, 
     roleName = t3.name, 
     rate = t2.rate 
  from @RT t1 
    join copyRight t2 on t2.custId = t1.rhCustId and t1.objid = t2.objId 
    join creativeRoleType t3 on t2.roleCode = t3.codeI

 update @RT set innerCode = t2.innerCode, 
                interCode = t2.interCode 
  from @RT t1 
    join RightHolder t2 on t1.rhCustId = t2.custId 

update @RT set performer = t2.performers, 
               autorMusic = t2.composers, 
		autorText = t2.lyrics
		from @RT t1 
		join MediaTrack t2 on t1.objid = t2.objid 

/*
--Общая сумма дохода на объект права 
--objAmount, --fullDuration, 
*/
---Только для своего комьюнити. 
update @RT  
set  commRate = t2.rateCommiss, 
     commAmount = convert(numeric(20,2), t1.authAmount*t2.rateCommiss/100)
from @RT   t1 
join AgreementAddRH t2 on t1.rHcustId = t2.custId 
left join vMyAnk t3 on t1.cmCustId = t3.custId
where ISNULL(t1.cmCustId,0) = t3.custId

update @RT  
set  sborESVRate = t2.rate, 
     sborESVMoney = convert(numeric(20,2), t1.authAmount*t2.rate/100)
from @RT t1
left join vMyAnk t3 on t1.cmCustId = t3.custId
left join SystemConstant t2 on codei = 1
where ISNULL(t1.cmCustId,0) = t3.custId

update @RT  
set  sborMiliRate = t2.rate, 
	 sborMiliMoney = convert(numeric(20,2), t1.authAmount*t2.rate/100)
from @RT t1
left join vMyAnk t3 on t1.cmCustId = t3.custId
FULL OUTER JOIN SystemConstant t2 on t2.codeI = 2
where  ISNULL(t1.cmCustId,0) = t3.custId
 
update @RT  
  set AmountToPay = authAmount - isnull(commAmount,0) - isnull(sborESVMoney,0) - isnull(sborMiliMoney,0)
from @RT t1
left join vMyAnk t3 on t1.cmCustId = t3.custId
where ISNULL(t1.cmCustId,0) = t3.custId
*/
 RETURN
 END
 --
--select  * from ft_Tsk_5_19_2_SR_ ('2018-01-01', '2019-12-01', 0, 138  )