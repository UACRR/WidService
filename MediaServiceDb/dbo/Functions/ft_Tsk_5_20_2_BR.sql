CREATE function  [dbo].[ft_Tsk_5_20_2_BR]  (@dateBegin date = NULL, @dateEnd date = NULL, @custId integer = NULL)
-- Роялті до розподілу від користувачів з "великих прав" за дату по театру
-- @custId - по конкретному правообладателю. 0-все правообладатели за период
RETURNS @RT TABLE
(id integer identity primary key,
crCustId integer , 
crCustIdName varchar(200), 
clCustId integer, 
clName varchar(200), 
objId integer, 
objName varchar(200), 
rateCommiss decimal(7,3), 
amount money,
rowNum integer
)
as
BEGIN

--Первый день месяца
set  @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())

set @custId = (Case When isnull(@custId,0) = 0 Then NULL Else @custId end)

;with TabTurn as 
( 
select t3.custId, t2.objid, sum(t1.amount) as amount
from PayTurn t1 
join Account t2 on t1.accIdCredit = t2.accId and t2.balsCode in (30,31) 
join Account t3 on t1.accIdDebet = t3.accId and t3.balsCode = 21
where dateOper between @dateBegin and @dateEnd
group by t3.custId, t2.objId
)
insert into @RT (clCustId, clName, objId, objName, crCustId, crCustIdName, rateCommiss, amount, rowNum)
select t2.custId as clCustId, t7.name as clName, 
t6.objId, t6.name as objName, 
t5.custId as crCustId, 
t8.name as crCustIdName, 
isnull(t10.rateCommiss, 0),
t3.amount, 
ROW_NUMBER() OVER(partition by t10.rateCommiss,t2.custid ORDER BY t10.rateCommiss,t2.custid) 
from LicenseBigR t1 
join LicenseAgreement t2 on t1.licId = t2.licId 
join ObjectRight t6 on t6.objId = t1.objId
join CopyRight t5 on t5.objId = t6.objId
join AgreementMaster t9 on t5.custId = t9.custId and isnull(t9.agrStatus,0) <> 4 
join AgreementAddRH t10 on t10.agrId = t9.agrId 
left join TabTurn t3 on t3.custId = t5.custId and t3.objId = t5.objId
join vCustomer t7 on t2.custId = t7.custId
join vCustomer t8 on t5.custId = t8.custId
where t2.custId = isnull(@custId, t2.custId)
and isnull(t3.amount,0)<>0  --or t2.licStatus <> 4
order by t10.rateCommiss

RETURN
END

--select * from ft_Tsk_5_20_2_BR (null,null,0)