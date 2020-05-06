
CREATE function  [dbo].[ft_Tsk_5_19_2_0SR_Do20200120]  (@dateBegin date = NULL, @dateEnd date = NULL, @cmCustId integer = NULL)
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
 cmCustId integer
 )
AS
BEGIN  

--declare @dateBegin date, @dateEnd date, @cRightKind integer, @category integer,  @ourAuthor smallint
--Первый день месяца
--set  @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.01.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())

set @cmCustId = (Case When isnull(@cmCustId,0) = 0 Then NULL Else @cmCustId end)

--Большие права
--придумать с комьюнити, если несколько
--declare @dateBegin date = '2019-10-01',  @dateEnd date= '2019-10-30', @custId integer, @cmCustId integer
insert into @RT (rhCustId, amount, cntObjId, cmCustId) 
 select top 1000 t1.rhCustId,  sum(isnull(t1.amount,0)) as amount, count (distinct t1.objId) as cntObj, max(cmCustId)
 from ft_Tsk_5_DISTRIBUTEDRed (@dateBegin, @dateEnd, 5, NULL) t1 
 where t1.cmCustId = isnull(@cmCustId, t1.cmCustId)
 group by rHcustId
order by 2

update @RT set rhTypeName = t3.name, commRate = t11.rateCommiss
 from @RT t1 
 left join RightHolder t2 on t1.rhCustId = t2.custId
 left join RHolderType t3 on t2.rHolderType = t3.codeI
 join AgreementMaster t10 on t1.rhCustId = t10.custId 
 join AgreementAddRH t11 on t11.agrId = t10.agrId and t11.version = t10.version
 
 update @RT set countryName = t3.countryName, rhName = t2.name, interCode = t2.IPI
 from @RT t1 
  join vCustomer t2 on t1.rhCustId = t2.custId
  left join Country t3 on t2.countryCode = t3.countryCode

 update @RT set  cmCustIdName = t2.Name
 from @RT t1 
  join vCustomer t2 on t1.cmCustId = t2.custId

 

 RETURN
 END
 --select  id, rhcustId, interCode, rhName, cntObjid, amount, commRate, cmCustIdName, countryName, rhTypeName  from ft_Tsk_5_19_2_0SR ('2019-10-01', '2019-10-30', NULL) order by id 

GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_19_2_0SR_Do20200120] TO [ReportUser]
    AS [dbo];

