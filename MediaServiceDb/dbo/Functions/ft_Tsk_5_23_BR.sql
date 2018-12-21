CREATE function  [dbo].[ft_Tsk_5_23_BR]  (@dateBegin date = NULL, @dateEnd date = NULL)
--Великі права. ВІДОМІСТЬ розподіл авторської винагороди з "великих прав" - Інші товариства (Іноземні автори)
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
 AmountToPay money,  -- До виплати 
 rowNum integer
 )
AS
BEGIN  --Користувачі

--declare @dateBegin date, @dateEnd date, @cRightKind integer, @category integer,  @ourAuthor smallint
--Первый день месяца

set  @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())

--set @custId = (Case When isnull(@custId,0) = 0 Then NULL Else @custId end)
--set @cmCustId = (Case When isnull(@cmCustId,0) = 0 Then NULL Else @cmCustId end)

--Большие права
insert into @RT 
(
 clCustId,  clName, periodId, periodName, periodDate, regId, regIItemId, countUse, ItemName, regAmount, regRate, authAmount,
 rHcustId,  cRName,  innerCode, interCode, roleCode, roleName, roleRate, 
 amount, 
 cmCustId,
 cmCustIdName,
 rowNum)
select distinct
t3.custId as clCustId, --назва театру
t17.name as clName,
t6.periodId, t6.periodName, CONVERT(char(10),t6.beginDate,104) +'-'+convert(char(10), t6.endDate),  --період
t3.regId, --t3.fileName, 
t4.regIItemId,  
t4.countUse, --к-ть вистав
t4.ItemName, --назва твору
t3.regAmount, --сума валового збору
t3.regRate, --ставка роялті
t3.authAmount, --АВ за твір
t7.custId as rHcustId, 
t16.nameRH as cRName,
--t15.name as cRName, 
t8.innerCode, t8.interCode, 
t7.roleCode, 
t9.name as roleName, 
t7.roleRate, 
t1.amount, 
--t13.cmCustId,
--t14.name as cmCustIdName
t16.cmCustId, 
t16.cmName as cmCustIdName,
ROW_NUMBER() OVER(partition by t3.custId ORDER BY t3.custId) 

from PayTurn t1 
join Account t2 on t1.accIdDebet = t2.accId and t2.balsCode = 21
join Register t3 on t1.regId = t3.regId 
join RegisterItem t4 on t4.regId = t3.regId and t1.regIItemId = t4.regIItemId and t4.regId = t1.regid and t4.regIItemId = t1.regIItemId 
join RegisterRatedList t5 on t5.rmId = t3.rmId 
join PaidPeriod t6 on t5.periodId = t6.periodId 
join CopyRight t7 on t4.objId = t7.objId
join RightHolder t8 on t7.custId = t8.custId
join CreativeRoleType t9 on t7.roleCode = t9.codeI
join LicenseBigR t10 on t4.objId = t10.objId 
join LicenseAgreement t11 on t11.licid = t10.licId and t11.licStatus <> 4
join vAgrLicenseType t12 on t11.licCode = t12.licCode
--left join CustCmRight t13 on t7.custId = t13.custId and t12.kindCode = t13.cRKindCode and isnull(t13.dateBegin, '1900-01-01')<'2018-01-01' and '2018-12-01' < ISNULL(t13.dateEnd, '3000-01-01')
--left join vCustomer t14 on t13.cmCustId = t14.custId
--join vCustomer t15 on t7.custId = t15.custId
join vCustCmService t16 on t7.custId = t16.custId and t12.kindCode = t16.CRKindCode
join vCustomer t17 on t6.custId = t17.custId
where t1.dateOper between @dateBegin and @dateEnd 
--    and t2.custId = isnull(@custId, t2.custId) 
--	and t16.cmCustId = ISNULL(@cmCustId, t16.cmCustId)
	and isnull(isMy,0) = 0

 RETURN
 END
 --select  * from ft_Tsk_5_23_BR ('2018-01-01', '2019-01-01' )