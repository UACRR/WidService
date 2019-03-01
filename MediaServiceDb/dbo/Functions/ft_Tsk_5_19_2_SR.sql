CREATE function [dbo].[ft_Tsk_5_19_2_SR]  (@dateBegin date = NULL, @dateEnd date = NULL, @custId integer = NULL,  @cmCustId integer = NULL)
--Великі права. Звіт про авторську винагороду по Автору  або авторам з Товариства 
-- @custId - по конкретному правообладателю. 0-все правообладатели за период
-- @cmCustId - по конкретному сообществу, 0-выбрать всесообщества, -1 - не визначено

--Назва використаного твору	Виконавець - П.І.Б. виконавця (співвиконавців) або назва колективу виконавців	Автор музики (П.І.Б.)	Автор тексту (П.І.Б.)	Тривалість звучання твору (хвил. сек.)	Кількість публічних сповіщень твору	Загальна Тривалість звучання твору (хвил. сек.)	Загальга тривалість в секундах	АВ на твір	Доля автора	 АВ автора 	Правовласник	ПІБ Автора	Код Автора	Каталог	Звіт

RETURNS @RT TABLE
--create table #RT  
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

--drop table #TmpRH
-- create table #TmpRH 
  declare @TmpRH table 
 (id integer identity not null, 
  turnId integer not null, 
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
  primary Key (rhCustId, turnId,id)) 

declare @TmpObj table
(objid integer not null primary key, 
 amount money )

-----------
--declare @dateBegin date,  @dateEnd date, @custId integer, @cmCustId integer
delete @TmpRH
insert into @TmpRH ( rhCustId, objid, authAmount, regId, regItemId, turnId, accIdDebet, accIdCredit, dateWork, kindCode, clCustId, cmCustId )
select isnull(t1.rhCustId,-1), t1.objid, t1.amount, t1.regId, t1.regItemId, t1.turnId, t1.accIdDebet, t1.accIdCredit, t1.dateWork, t1.kindCode, t1.clCustId, t1.cmCustId
from ft_Tsk_5_DISTRIBUTEDRed (@dateBegin, @dateEnd, 5, NULL) t1
 where isnull(t1.rhCustId,-1) = isnull(@custId, isnull(t1.rhCustId,-1)) and isnull(t1.cmCustId,-1) = isnull(@cmCustId, isnull(t1.cmCustId,-1))
--categoryCode, cmCustId		

--Зібрано на твір
insert into @TmpObj (objid, amount) 
select objid, sum(amount) as amount
  from dbo.ft_Tsk_5_COLLECTED (@dateBegin, @dateEnd, 5, NULL) 
  group by objid

update @TmpRH 
  set objAmount = t2.amount 
  from @TmpRH  t1, 
        @TmpObj t2 
    where t1.objid = t2.objid

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
--Заливаю в результат с комьюнити
delete @RT 
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
   left join TermsOfService t3 on t3.custId = t1.rhCustId and t3.CRKindCode = t1.kindCode 
   left join CustCmRight t4 on t4.custId = t3.custId and t4.cRKindCode = t3.CRKindCode
   left join vMyAnk t5 on t5.custId = t5.custId

  update @RT set cmCustIdName = isnull(t2.name, 'Не ВИЗНАЧЕНО')
   from @RT t1 
     left join vCustomer t2 on t1.cmCustId = t2.custId
 
 update @RT set cRName = t2.name 
  from @RT t1 
     join vcustomer t2 on t1.rHcustId = t2.custId

 update @RT set clName = t2.name 
  from @RT t1 
     join vcustomer t2 on t1.clcustId = t2.custId

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

 RETURN
 END
 --
--select * from ft_Tsk_5_19_2_SR ('2019-01-01', '2019-02-25', NULL, NULL  ) --317419,14