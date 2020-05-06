CREATE function  [dbo].[ft_Tsk_5_21_BRcomm]  (@dateBegin date = NULL, @dateEnd date = NULL, @rateCommiss decimal(7,3) = NULL)
--* Реєстр до розподілу від користувачів ВП (2.0-регистри)
-- @rateCommiss - по конкретной комиссии. NULL / -1 - все комиссии

RETURNS @RT TABLE
(id integer identity,
crCustId integer , 
crCustIdName varchar(200), 
clCustId integer, 
clName varchar(200), 
objId integer, 
objName varchar(200), 
rateCommiss decimal(7,3), 
amount money, 
rowNum integer ,
primary key (id,rowNum)
)
as
BEGIN

--Первый день месяца
set @dateBegin = isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())

set @rateCommiss = (Case When isnull(@rateCommiss,-1) = -1 Then NULL Else @rateCommiss end)

/*
insert into @RT (clCustId, clName, objId, objName, crCustId, crCustIdName, rateCommiss, amount, rowNum)
select 
t1.clCustId, t3.name as clName , t1.objid,  t4.name as objName, t1.rhCustId,  t5.name as crCustIdName, t1.rateCommiss, 
 t1.amount, 
 ROW_NUMBER() OVER(ORDER BY t1.rateCommiss, t3.Name, t5.name) 
from dbo.ft_Tsk_5_20_BRMain (@dateBegin, @dateEnd) as t1
join vCommunity t2 on t1.cmCustId = t2.cmCustId
join vCustomer t3 on t1.clCustId = t3.custId
join objectRight t4 on t1.objid = t4.objid 
join vCustomer t5 on rhCustId = t5.custId 
where isnull(t1.rateCommiss,0) = isnull(@rateCommiss, t1.rateCommiss)
order by t1.rateCommiss, t5.Name
*/
;with TabRt as 
(
select  clCustId, max(clName) as clName, objId, max(objName) as objName, crCustId, max(crCustIdName)  as crCustIdName, rateCommiss, sum(amount) as amount
 from ft_Tsk_5_20_2_BR (@dateBegin, @dateEnd, NULL) t1 
 where isnull(t1.rateCommiss,0) = isnull(@rateCommiss, isnull(t1.rateCommiss,0))
 group by t1.clCustId, t1.objId, t1.crCustId, t1.rateCommiss
)
insert into @RT (clCustId, clName, objId, objName, crCustId, crCustIdName, rateCommiss, amount, rowNum)
select  clCustId, clName, objId, objName, crCustId, crCustIdName, rateCommiss, amount,  
 ROW_NUMBER() OVER( ORDER BY t1.rateCommiss, t1.crCustIdName, t1.clName, t1.objName) 
 from ft_Tsk_5_20_2_BR (@dateBegin, @dateEnd, NULL) t1 
 where isnull(t1.rateCommiss,0) = isnull(@rateCommiss, isnull(t1.rateCommiss,0))
 order by t1.rateCommiss, t1.crCustIdName, t1.clName, t1.objName

RETURN
END
--	select * from dbo.ft_Tsk_5_21_BRcomm  ( NULL,  NULL, NULL) order by rownum

GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_21_BRcomm] TO [ReportUser]
    AS [dbo];

