--Великі права
--* Роялті до розподілу від користувачів ВП (1)
CREATE function  [dbo].[ft_Tsk_5_20_1_BR]  (@dateBegin date = NULL, @dateEnd date = NULL)
--Великі права. * Роялті до розподілу від користувачів ВП (1)
--Беру надходження на об'екти права
RETURNS @RT TABLE 
(id integer identity,
custId integer primary key,
clName varchar(200), 
amount money
)

AS
BEGIN  
set @dateBegin = isnull(@dateBegin, (select convert(date, (convert(char(4),year(getdate()))+'-01-01'))))
set @dateEnd = isnull(@dateEnd, getdate())
insert into @RT (custId, clName, amount)
select t4.custId, max(t5.name) as clName, SUM(t1.amount) as amount
from PayTurn t1 
join Account t2 on t1.accIdDebet = t2.accId and t2.balsCode = 30 and t1.accDebet like '301%'
join LicenseBigR t3 on t2.objId = t3.objId
join LicenseAgreement t4 on t3.licId = t4.licId
join vCustomer t5 on t4.custId = t5.custId
where t1.dateOper between @dateBegin and @dateEnd 
group by t4.custId

 RETURN
 END
 --select  * from ft_Tsk_5_20_1_BR (null, null)