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
 rowNum integer, 
 objid integer
 )
AS
BEGIN  --Користувачі

--declare @dateBegin date, @dateEnd date, @cRightKind integer, @category integer,  @ourAuthor smallint
--Первый день месяца

set  @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())

--set @custId = (Case When isnull(@custId,0) = 0 Then NULL Else @custId end)
--set @cmCustId = (Case When isnull(@cmCustId,0) = 0 Then NULL Else @cmCustId end)

declare  @TmpRt table
(id integer not null identity, 
 clCustId integer, 
 cmCustId integer, 
 rhCustId integer not null, 
 objid integer, 
 regId integer, 
 regItemId integer, 
 amount money ,
 primary key (id, rhCustid))

 insert into @TmpRt (clCustId, cmCustId, rhCustId, objid, regId, regItemId, amount)
  select clCustId, cmCustId, rhCustId, objid, t1.regId, t1.regItemId, t1.amount  
 --from ft_Tsk_5_DistributedRed (@dateBegin, @dateEnd, 6,NULL)
 from ft_Tsk_5_DistributedRed ('2019-02-01', NULL, 6,NULL) t1 
 left join vMyAnk t2 on t2.custId = t2.custId 
 where t1.cmCustId <> t2.custId

 insert into @RT 
( clCustId,  clName,  regId, regIItemId, rHcustId,  cRName,  innerCode, interCode, amount, cmCustId, cmCustIdName, rowNum, objid) 
 select  t1.clCustId, t2.name as clName, t1.regId, t1.regItemid, t1.rhCustId, isnull(t4.name, 'НЕ ВИЗНАЧЕНИЙ') as crName, t3.innerCode, t3.interCode, t1.amount, 
         t1.cmCustId, isnull(t5.name, 'НЕ ВИЗНАЧЕНО') as cmCustIdName, 
		 ROW_NUMBER() OVER(partition by t4.name ORDER BY t4.name ), t1.objid
   from @TmpRt t1 
    left join vCustomerClient t2 on t2.custId = t1.clcustId 
	left join vCustomerRHolder t3 on t3.custId = t1.rhCustId
	left join vcustomer t4 on t4.custId = t3.custId  
	left join vCustomer t5 on t5.custId = t1.cmCustId  

update @RT set  periodId = t4.periodId, 
                periodName = t5.periodName, 
                periodDate = convert(varchar(10),t5.beginDate,104)+' - '+convert(varchar(10),t5.endDate,104), 
				countUse = t3.countUse, 
				ItemName = t3.ItemName, 
				regAmount = t2.regAmount, 
				regRate = t2.regRate, 
				authAmount = t2.authAmount
     from @Rt t1 
	  join register t2 on t2.regId = t1.regId 
	  join RegisterItem t3 on t3.regId = t2.regId and t3.objId = t1.objid
	  join RegisterRatedList t4 on t4.rmId = t2.rmId 
	  join PaidPeriod t5 on t5.periodId = t4.periodId

				
update @RT set  roleCode = t2.roleCode, 
                roleName = t3.name, 
				roleRate = t2.roleRate 
		from  @RT t1 
		  join copyright t2 on t2.objid = t1.objid and t2.custid = t1.rHcustId
		  join CreativeRoleType t3 on t3.codeI = t2.roleCode

 
 RETURN
 END
 --select  * from ft_Tsk_5_23_BR ('2018-02-01', '2019-12-01' )
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_23_BR] TO [ReportUser]
    AS [dbo];

