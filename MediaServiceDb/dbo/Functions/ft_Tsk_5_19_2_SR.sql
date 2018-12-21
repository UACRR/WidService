CREATE function  [dbo].[ft_Tsk_5_19_2_SR]  (@dateBegin date = NULL, @dateEnd date = NULL, @custId integer = NULL,  @cmCustId integer = NULL)
--Великі права. Звіт про авторську винагороду по Автору  або авторам з Товариства 
-- @custId - по конкретному правообладателю. 0-все правообладатели за период
-- @cmCustId - по конкретному сообществу, 0-выбрать всесообщества

--Назва використаного твору	Виконавець - П.І.Б. виконавця (співвиконавців) або назва колективу виконавців	Автор музики (П.І.Б.)	Автор тексту (П.І.Б.)	Тривалість звучання твору (хвил. сек.)	Кількість публічних сповіщень твору	Загальна Тривалість звучання твору (хвил. сек.)	Загальга тривалість в секундах	АВ на твір	Доля автора	 АВ автора 	Правовласник	ПІБ Автора	Код Автора	Каталог	Звіт

RETURNS @RT TABLE
(
 id integer not null identity primary key,
 clCustId integer, --назва театру
 clName varchar(200), 
 periodId integer, 
 periodName varchar(100), 
 periodDate varchar(100), 
-- beginDate, 
-- endDate,  --період
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
 cRName varchar(200), 
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


--Малі права
;with TmpTurn301 as 
(
select t2.objId, t1.amount, t1.regid, regIItemId
 from PayTurn t1 
 join Account t2 on t1.accIdDebet = t2.accId and t2.balsCode = 30
-- where  t1.dateOper between @dateBegin and @dateEnd 
)
insert into @RT 
(
clCustId, clName, periodId, periodName, periodDate, regId, fileName, regIItemId, ItemName, objid, countUse,
objAmount,
performer, AutorMusic,AutorText, durationUse, fullDuration, 
rHcustId, cRName,
innerCode, interCode, roleCode, roleName, Rate, 
authAmount,  cmCustId, cmCustIdName
)
select 
t3.custId as clCustId, --назва клієнта
t17.name as clName,
t6.periodId, t6.periodName, CONVERT(char(10),t6.beginDate,104) +'-'+convert(char(10), t6.endDate),  --період
t3.regId, t3.fileName, 
t4.regIItemId,  
(Case t4.ItemName when t18.name Then t4.itemName Else t18.name+' ('+t4.itemName+' )' end),  --назва твору
t4.objId, 
t4.countUse,  --к-ть 
t13.amount, 
t18.performer, t19.autorMusic, t19.AutorText, 
convert(varchar(15),t4.durationUse), 
NULL, --t4.durationUse*t4.countUse as fullDuration,
t7.custId as rHcustId, 
t16.nameRH as cRName,
t8.innerCode, t8.interCode, 
t7.roleCode, 
t9.name as roleName, 
t7.rate, 
t1.amount, --АВ за твір
t16.cmCustId, 
t16.cmName as cmCustIdName
from PayTurn t1 
join Account t2 on t1.accIdDebet = t2.accId and t2.balsCode = 21 
join Register t3 on t1.regId = t3.regId 
join RegisterItem t4 on t4.regId = t3.regId and t1.regIItemId = t4.regIItemId
join RegisterRatedList t5 on t5.rmId = t3.rmId 
join PaidPeriod t6 on t5.periodId = t6.periodId 
join CopyRight t7 on t4.objId = t7.objId
join RightHolder t8 on t7.custId = t8.custId
join CreativeRoleType t9 on t7.roleCode = t9.codeI
join LicenseAgreement t11 on t11.licid = t6.licId 
join vAgrLicenseType t12 on t11.licCode = t12.licCode and t12.schemaId = 1
join TmpTurn301 t13 on t13.objId = t4.objId and t13.regId = t4.regId and t13.regIItemId = t4.regIItemId
left join vCustCmService t16 on t7.custId = t16.custId and t12.kindCode = t16.CRKindCode
left join vCustomer t17 on t6.custId = t17.custId
join ObjectRight t18 on t4.objid = t18.objid 
left join vObjectRightSR t19 on t18.objId = t19.objid
where t1.dateOper between @dateBegin and @dateEnd and 
    t2.custId = isnull(@custId, t2.custId) 
	and t16.cmCustId = ISNULL(@cmCustId, t16.cmCustId)

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
full outer join taxRate t2 on codei = 1
where ISNULL(t1.cmCustId,0) = t3.custId

update @RT  
set  sborMiliRate = t2.rate, 
	 sborMiliMoney = convert(numeric(20,2), t1.authAmount*t2.rate/100)
from @RT t1
left join vMyAnk t3 on t1.cmCustId = t3.custId
FULL OUTER JOIN taxRate t2 on t2.codeI = 2
where  ISNULL(t1.cmCustId,0) = t3.custId
 
update @RT  
  set AmountToPay = authAmount - isnull(commAmount,0) - isnull(sborESVMoney,0) - isnull(sborMiliMoney,0)
from @RT t1
left join vMyAnk t3 on t1.cmCustId = t3.custId
where ISNULL(t1.cmCustId,0) = t3.custId

 RETURN
 END
 --select  * from ft_Tsk_5_19_2_SR ('2018-01-01', '2019-01-01',0,0 )