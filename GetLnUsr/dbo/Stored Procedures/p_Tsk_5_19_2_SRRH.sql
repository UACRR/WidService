CREATE procedure  [dbo].[p_Tsk_5_19_2_SRRH] @dateBegin date , @dateEnd date , @custId integer , @innerCode varchar(25) , @interCode varchar(25)
, @IPIBase varchar(25) 
--Звіт про авторську винагороду по конкретному автору Автору за период
-- @custId - по конкретному правообладателю. 
-- Как ft_Tsk_5_19_2_SR, но расширены параметры. Если не указан ни один параметр для автора - не работает
as 
BEGIN


create  TABLE #RTH
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


create  TABLE #RT
--create table #RT  
(
 id integer not null identity primary key,
 clCustId integer, --назва театру
 clName varchar(254), 
 periodId integer, 
 periodName varchar(100), 
 periodDate varchar(100), 
 regId integer, 
 fileName varchar(100), 
 regIItemId integer,  
 ItemName varchar(200), --назва твору
 objid integer, 
 performer varchar(254), 
 AutorMusic varchar(254),
 AutorText varchar(254),
 durationUse varchar(15), 
 countUse integer, --к-ть 
 --fullDuration varchar(15), --datetime, --загальна тривалість
 --fullDurationSec integer, -- Загальна тривалість в секундах
 licId integer, 
 licNum varchar(25), 
 series varchar(10), 
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
 cmCustIdName varchar(254),
 commRate decimal(5,2), 
 commAmount money, --Комісія rУААСП 
 sborESVRate decimal(5,2), -- Відрахування(19%)
 sborESVMoney money, -- Відрахування(19%)
 sborMiliRate decimal(5,2), -- Відрахування(1.5%)
 sborMiliMoney money, -- Відрахування\r(1.5%%)
 AmountToPay money,  -- До виплати 
 CatalogName varchar(200), --каталог
 rhCustType integer, 
 IPIBase varchar(25)  --соответствует IP_Name_NR/IPInr
)

--
--set  @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))

set  @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate())-2)+'.01.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())

If  ( @custId is NULL and @innerCode is NULL and @interCode is NULL and @IPIBase is NULL ) 
BEGIN

insert into #RT 
( clCustId, clName, periodId, periodName, periodDate, regId, fileName, regIItemId, ItemName, objid, countUse,
  durationUse, rHcustId,  authAmount, cmCustId, objAmount, 
  licId, licNum, series 
)
select 
  NULL,NULL, NULL, NULL, NULL,NULL,NULL, NULL, NULL, NULL, NULL,
  NULL, NULL,  NULL, 
 NULL,NULL, 
 NULL, NULL, NULL

 select * from #RT
 Return
end

set @custId = (Case When isnull(@custId,0) = 0 Then NULL Else @custId end)
--set @cmCustId = (Case When isnull(@cmCustId,0) = 0 Then NULL Else @cmCustId end)

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
  licId integer, 
  licNum varchar(25), 
  series varchar(10),
  rhCustType integer,
  IPIBase varchar(25)
 primary Key (rhCustId, turnId,id)) 

declare @TmpObj table
(objid integer not null, 
 amount money, 
 regId integer not null, 
 regItemId integer not null 
 primary key (objid, regId, regItemId)
 )

declare @TmpCustId table 
( custId integer not null primary key,
  rNum integer  )

insert into @TmpCustId  (custId, rNum)
 select  t1.custId, ROW_NUMBER() OVER (Order by t1.custId)  
 from 
( select  distinct custId 
   from RightHolder t1
   where @custId = t1.custId
 UNION 
 select  distinct custId
   from RightHolder t1
   where @innerCode = t1.innerCode
 UNION 
 select  distinct custId 
   from RightHolder t1
   where @interCode = t1.interCode
 UNION 
 select  distinct custId 
   from RightHolder t1
   where @IPIBase = t1.IPIBase
) t1
-----------

delete @TmpRH
declare @i integer = 1, @maxN integer = (select max(rNum) from @TmpCustId), @custIdP integer = 0

 WHILE @i<=@maxN 
 BEGIN 

 set @custIdP = (select custId from @TmpCustId where rNum = @i) 

--declare @dateBegin date,  @dateEnd date, @custId integer, @cmCustId integer
exec p_Tsk_5_DistributedRedH @dateBegin, @dateEnd, NULL, NULL, @custIdP
insert into @TmpRH ( rhCustId, objid, authAmount, regId, regItemId, turnId, accIdDebet, accIdCredit, dateWork, kindCode, clCustId, cmCustId )
select isnull(t1.rhCustId,-1), t1.objid, t1.amount, t1.regId, t1.regItemId, t1.turnId, t1.accIdDebet, t1.accIdCredit, t1.dateWork, t1.kindCode, t1.clCustId, t1.cmCustId
from #RTH t1
truncate table #RTH
 set @i = @i+1
 END

--счета и ОП с оплатой на счет 30
;with TabObj as 
( select objid from @TmpRH group by objid ), 
      TabAcc as 
(select t1.accId, t1.objid--, cast(substring(accnls, 4,2) as integer) as kindCode, t2.categoryCode
   from TabObj t0 
     join account t1 on t1.objid = t0.objid 
   where t1.balsCode = 30  
      --  and cast(substring(accnls, 3,2) as integer) = isnull(@kindCode , cast(substring(accnls, 3,2) as integer))
)
 insert into @TmpObj (objid, amount, regId, regItemId)
  select t3.objid, sum(amount), isnull(t1.regId,0), isnull(t1.regIItemId,0)
   from PayTurn t1 
    join Account t2 on t2.accId = t1.accIdCredit and t2.balsCode = 22
    join TabAcc t3 on t3.accId = t1.accIdDebet    
   where t1.dateWork between @dateBegin and @dateEnd
   group by t3.objid, t1.regId, t1.regIItemId

update @TmpRH 
  set objAmount = t2.amount 
  from @TmpRH  t1, 
        @TmpObj t2 
    where t1.objid = t2.objid 
	    and t1.regId = t2.regId 
		and t1.regItemId = t2.regItemId

--клиента проставляю по данным отчета 
update @TmpRH 
  set cLCustId = t4.custId, 
      periodId = t4.periodId, 
      periodName = t4.periodName, 
      periodDate = convert(char(12), t4.beginDate)+'-'+convert(char(12), t4.endDate), 
      fileName = t2.fileName, 
	  licId = t4.licId
  from @TmpRH  t1 
   join register t2 on t1.regId = t2.regId 
   join RegisterRatedList t3 on t3.rmid = t2.rmId
   join PaidPeriod t4 on t4.periodId = t3.periodId

--Название из звита
update @TmpRH 
   set ItemName = t2.ItemName,  
       countUse  = t2.countUse, 
	   durationUse = t2.durationUse
  from @TmpRH t1 
  join RegisterItem t2 on t1.regId = t2.regId and t1.regItemId = t2.regIItemId 

--Название из ObjectRight
update @TmpRH 
   set ItemName = t2.name
  from @TmpRH t1 
  join ObjectRight t2 on t1.objid = t2.objId where t1.ItemName is NULL

 update @TmpRH set licNum = t3.licNum, series = t4.series 
    from @TmpRH t1 
	  join LicenseAgreement t2 on t2.licId = t1.licId 
	  join LicenseAgrParam t3  on t3.licId = t2.licId 
	  join AgrLicenseType t4 on t4.codeI = t2.licCode
----------------------------------------------------------------
--Заливаю в результат с комьюнити
delete #RT 
insert into #RT 
( clCustId, clName, periodId, periodName, periodDate, regId, fileName, regIItemId, ItemName, objid, countUse,
  durationUse, rHcustId,  authAmount, cmCustId, objAmount, 
  licId, licNum, series 
)
select 
  t1.clCustId, t1.clCustName, t1.periodId, t1.periodName, t1.periodDate, t1.regId, t1.fileName, t1.regItemId, t1.ItemName, t1.objid, t1.countUse,
  t1.durationUse, t1.rHcustId,  authAmount, 
 ( Case t3.ourService When 1 Then t5.custId ELSE isnull(t4.cmCustId, -1) END ), t1.objAmount, 
 t1.licid, t1.licNum, t1.series
 from @TmpRH t1 
   --join vCustCmService t2 on t1.rHcustId = t2.custId and t1.kindCode = t2.crKindCode
   left join TermsOfService t3 on t3.custId = t1.rhCustId and t3.CRKindCode = t1.kindCode 
   left join CustCmRight t4 on t4.custId = t3.custId and t4.cRKindCode = t3.CRKindCode
   left join vMyAnk t5 on t5.custId = t5.custId

  update #RT set cmCustIdName = isnull(t2.name, 'Не ВИЗНАЧЕНО')
   from #RT t1 
     left join vCustomer t2 on t1.cmCustId = t2.custId
 
 update #RT set cRName = t2.name, rhCustType = t2.custType
  from #RT t1 
     join vcustomer t2 on t1.rHcustId = t2.custId

 update #RT set clName = t2.name 
  from #RT t1 
     join vcustomer t2 on t1.clcustId = t2.custId

update #RT 
 set roleCode = t2.roleCode, 
     roleName = t3.name, 
     rate = t2.rate 
  from #RT t1 
    join copyRight t2 on t2.custId = t1.rhCustId and t1.objid = t2.objId 
    join creativeRoleType t3 on t2.roleCode = t3.codeI

 update #RT set innerCode = t2.innerCode, 
                interCode = t2.interCode, 
				IPIBase  = t2.IPIBase
  from #RT t1 
    join RightHolder t2 on t1.rhCustId = t2.custId 

update #RT set performer = t2.performers, 
               autorMusic = t2.composers, 
		autorText = t2.lyrics
		from #RT t1 
		join MediaTrack t2 on t1.objid = t2.objid 

/*
--Общая сумма дохода на объект права 
--objAmount, --fullDuration, 
*/
---Только для своего комьюнити. 
update #RT  
set  commRate = t2.rateCommiss, 
     commAmount = convert(numeric(20,2), t1.authAmount*t2.rateCommiss/100)
from #RT   t1 
join AgreementAddRH t2 on t1.rHcustId = t2.custId 
left join vMyAnk t3 on t1.cmCustId = t3.custId
where ISNULL(t1.cmCustId,0) = t3.custId

update #RT  
set  sborESVRate = t2.rate, 
     sborESVMoney = convert(numeric(20,2), t1.authAmount*t2.rate/100)
from #RT t1
left join vMyAnk t3 on t1.cmCustId = t3.custId
left join SystemConstant t2 on codei = 1
where ISNULL(t1.cmCustId,0) = t3.custId and t1.rhCustType = 1

update #RT  
set  sborMiliRate = t2.rate, 
	 sborMiliMoney = convert(numeric(20,2), t1.authAmount*t2.rate/100)
from #RT t1
left join vMyAnk t3 on t1.cmCustId = t3.custId
FULL OUTER JOIN SystemConstant t2 on t2.codeI = 2
where  ISNULL(t1.cmCustId,0) = t3.custId and t1.rhCustType = 1
 
update #RT  
  set AmountToPay = authAmount - isnull(commAmount,0) - isnull(sborESVMoney,0) - isnull(sborMiliMoney,0)
from #RT t1
left join vMyAnk t3 on t1.cmCustId = t3.custId
where ISNULL(t1.cmCustId,0) = t3.custId


select * from #RT


 RETURN
 END
 --
--exec p_Tsk_5_19_2_SRRH '2018-01-01', '2019-12-31', NULL, NULL, NULL, NULL

GO
GRANT EXECUTE
    ON OBJECT::[dbo].[p_Tsk_5_19_2_SRRH] TO [robot]
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[p_Tsk_5_19_2_SRRH] TO [ReportUser]
    AS [dbo];

