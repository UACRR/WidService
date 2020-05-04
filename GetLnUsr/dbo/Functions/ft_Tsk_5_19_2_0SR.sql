
CREATE function  [dbo].[ft_Tsk_5_19_2_0SR]  (@dateBegin date = NULL, @dateEnd date = NULL, @cmCustId integer = NULL)
--Великі права. Звіт про авторську винагороду по Автору  або авторам з Товариства 
-- @cmCustId - по конкретному сообществу, 0-выбрать всесообщества

RETURNS @RT TABLE
(
 id integer not null identity primary key,
 rhCustId integer, 
 rhName varchar(254), 
 interCode varchar(25), 
 amount money, 
 cmCustIdName varchar(200), 
 commRate decimal(5,2), 
 countryName varchar(100), --країна
 cntObjId integer,  --кол-во объектов
 rhTypeName varchar(100),  --тип правовласника
 cmCustId integer, 
 rhType integer, 
 countryCode varchar(5)
 )
AS
BEGIN  

--declare @dateBegin date, @dateEnd date, @cRightKind integer, @category integer,  @ourAuthor smallint
--Первый день месяца
--set  @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.01.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())

set @cmCustId = (Case When isnull(@cmCustId,0) = 0 Then NULL Else @cmCustId end)
declare @myCmCustId integer = (select max(custid) from vmyank)

--declare @dateBegin date = '2019-10-01',  @dateEnd date= '2019-10-30', @custId integer, @cmCustId integer, @myCmCustId integer = 138

insert into @RT (rhCustId, cntObjId, amount, cmCustId) 
select a1.custIdRh, count(distinct a1.objId), sum(a1.amount), max(cmCustId) as cmCustId
   from 
   ( select t1.custIdRh, convert(int,substring(t1.acccredit,6,len(t1.acccredit)-5)) objid,
	   t1.accIdDebet, t1.accIdCredit, --t4.custid,
	   t1.regId, t1.regIItemId, t1.turnId, t1.dateWork, 
	   isnull(t2.cmCustId,@myCmCustId) as cmCustId , t1.amount
	   from payturn t1
	    join PayTurnExtra t2 on t1.turnId = t2.turnid and t1.dateWork = t2.datework 
	   where 
	        t1.dateWork between @dateBegin and @dateEnd and
	        substring(t1.accdebet,1,2)='21' and
			substring(t1.accCredit,1,2) in ( '30', '31') and 
			isnull(t2.cmCustId, @myCmCustId) = isnull(@cmCustId, isnull(t2.cmCustId, @myCmCustId))
		) a1
   where a1.cmCustId = isnull(@cmCustId, a1.cmCustId) 
   group by a1.custIdRh--, a1.cmCustId

/*
update @RT 
 set rhType = t2.rHolderType, rhTypeName = t3.name, commRate = t11.rateCommiss, interCode = t2.interCode
 from @RT t1 
  join RightHolder t2 on t1.rhCustId = t2.custId
  join RHolderType t3 on t2.rHolderType = t3.codeI
  left join AgreementMaster t10 on t1.rhCustId = t10.custId 
  left join AgreementAddRH t11 on t11.agrId = t10.agrId and t11.version = t10.version

 update @RT 
 set countryCode = t2.countryCode, rhName = t2.name
 from @RT t1 
  join vCustomer t2 on t1.rhCustId = t2.custId

update @RT 
 set cmCustIdName = t2.name
 from @RT t1 
  join vCustomer t2 on t1.cmCustId = t2.custId

*/

update @RT 
 set rhType = t2.rHolderType, commRate = t2.rateCommiss, interCode = t2.interCode, countryCode = t2.countryCode, rhName = t2.name
   from @RT t1 
   join vCustomerRH t2 on t1.rhCustId = t2.custId

update @RT set rhTypeName = t2.name 
  from @RT t1 
  join RHolderType t2 on t1.rhType = t2.codeI

update @RT  set rhType = t2.rHolderType, commRate = t2.rateCommiss, interCode = t2.interCode,  cmCustIdName = t2.name
  from @RT t1 
  join vCustomerCommunity t2 on t1.cmCustId = t2.CustId

update @RT set countryName = t2.countryName 
 from @RT t1
  join Country t2 on t1.countryCode = t2.countryCode


 RETURN
 END


GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_19_2_0SR] TO [ReportUser]
    AS [dbo];

