


CREATE function  [dbo].[ft_Tsk_5_19_1_BR]  (@dateBegin date = NULL, @dateEnd date = NULL, @custId integer = NULL,  @cmCustId integer = NULL)
--Великі права. Звіт про авторську винагороду по Автору  або авторам з Товариства 
-- @custId - по конкретному правообладателю. 0-все правообладатели за период
-- @cmCustId - по конкретному сообществу, 0-выбрать всесообщества

RETURNS @RT TABLE
--create table #RT
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
-- fileName, 
 regIItemId integer,  
 countUse integer, --к-ть вистав
 ItemName varchar(200), --назва твору
 regAmount money, --сума валового збору
 regRate decimal (5,2), --ставка роялті
 authAmount money, --АВ за твір
 rHcustId integer, 
 cRName varchar(200), 
 innerCode varchar(25), 
 interCode varchar(25), 
 roleCode integer, 
 roleName varchar(100), 
 roleRate decimal (5,2), 
 amount money, 
 cmCustId integer,
 cmCustIdName varchar(200), 
 commRate decimal(5,2), 
 commAmount money, --Комісія rУААСП 
 sborESVRate decimal(5,2), -- Відрахування(19%)
 sborESVMoney money, -- Відрахування(19%)
 sborMiliRate decimal(5,2), -- Відрахування(1.5%)
 sborMiliMoney money, -- Відрахування\r(1.5%%)
 AmountToPay money, -- До виплати 
 objId integer
 )
AS
BEGIN  --Користувачі

--Первый день месяца
set  @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())

set @custId = (Case When isnull(@custId,0) = 0 Then NULL Else @custId end)
set @cmCustId = (Case When isnull(@cmCustId,0) = 0 Then NULL Else @cmCustId end)

--declare @dateBegin date = '2018-01-01', @dateEnd date = '2021-01-01', @cRightKind integer, @category integer,  @ourAuthor smallint, @custId integer, @cmCustId integer

--Большие права
insert into @RT 
   --insert into #RT 
(clCustId,  regId, regIItemId,  rhCustId, amount, cmCustId, t1.objid)
select  t1.clCustId,  t1.regId, t1.regItemId,  isnull(t1.rhCustId,-1), t1.amount, isnull(t1.cmCustId,-1), t1.objid
from ft_Tsk_5_DISTRIBUTEDRedRH (@dateBegin, @dateEnd, 6, NULL, @custId) t1
--from ft_Tsk_5_DISTRIBUTEDRed ('2019-01-01', '2019-03-01', 6, NULL) t1
 where isnull(t1.rhCustId,-1) = isnull(@custId, isnull(t1.rhCustId,-1)) and isnull(t1.cmCustId,-1) = isnull(@cmCustId, isnull(t1.cmCustId,-1))
--categoryCode, cmCustId		

update @RT  
  set clName = t2.name 
   from @RT t1 
     join vCustomer t2 on t1.clCustId = t2.custId
  
update @RT  
  set cRName = isnull(t3.name, 'НЕ ВИЗНАЧЕНИЙ'), innerCode = t2.innerCode, interCode = t2.interCode 
   from @RT t1 
     left join vCustomerRHolder t2 on t1.rHcustId = t2.custId
	 left join vCustomer t3 on t1.rHcustId = t3.custId

update @RT 
  set periodId = t4.PeriodId, 
      periodName = t4.periodName, 
	  periodDate = convert(varchar(10), t4.beginDate)+' -  '+   convert(varchar(10), t4.endDate), 
	  countUse = t5.countUse,    --к-ть вистав
	  ItemName =  t5.ItemName,   --назва твору
	  regAmount = t2.regAmount,  --сума валового збору
	  authAmount = t2.authAmount, 
	  regRate = t2.regRate      --ставка роялті 
 from @RT  t1 
   join Register t2 on t1.regId = t2.regId 
   join RegisterRatedList t3 on t3.rmId = t2.rmid 
   join paidPeriod t4 on t4.periodId = t3.periodId 
   join RegisterItem t5 on t5.regId = t2.regId 

   --Если ставка роялти в листе не проставлена - ошибка, но заполню здесь
   update @RT set regRate = t3.rate 
     from @RT t1
	    join LicenseAgreement t2 on t2.custId = t1.clCustId
	    join LicenseBigR t3 on t3.licId = t2.licId and t3.objid = t1.objid 
	  where isnull(t1.regRate,0) = 0
	      
   update @RT 
      set roleCode = t2.roleCode, 
	      roleName = t3.name,  
		  roleRate = t2.roleRate
     from @RT  t1 
	  join CopyRight t2 on t2.objid = t1.objId and t2.custId = t1.rhCustId
	  join CreativeRoleType t3 on t3.codeI = t2.roleCode

  update @RT set cmCustIdName = isnull(t2.name , 'НЕ ВИЗНАЧЕНО')
     from @RT t1 
	    left join vCustomer t2 on t2.custId = t1.cmCustId

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
full outer join SystemConstant t2 on codei = 1
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
 --select  * from ft_Tsk_5_19_1_BR ('2018-01-01', '2021-03-01', 1394, NULL)  --80737,12

GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_19_1_BR] TO [ReportUser]
    AS [dbo];

