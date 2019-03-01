CREATE function  [dbo].[ft_Tsk_5_22_2_BRcm]  (@dateBegin date = NULL, @dateEnd date = NULL, @cmCustId integer = NULL, @rateCommiss decimal(7,3) = NULL)
-- Відомість розподіл АВ ВП розшифровка (4.3) 
--ВІДОМІСТЬ "Розподіл авторської винагороди на авторів  з "великих прав"  по товариству та регістру

RETURNS @RT TABLE
(
id integer identity  primary key,
rhCustId integer,
rhCustIdName varchar(100), 
innerInterCode varchar(60), 
cmCustId integer, 
cmName varchar(100), 
rateCommiss decimal(7,3), 
amount money,
rowNum integer 
)
as
BEGIN

--Первый день месяца
set  @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())

--declare @dateBegin date, @dateEnd date 
--set @dateBegin = '2018-01-01'
--set @dateEnd  = '2018-12-31'
;with TabTurn as 
(
select  isnull(t1.rhCustId,-1) as rhCustId, isnull(t1.cmCustId,-1) as cmCustId, isnull(t2.rateCommiss,0) as rateCommiss, sum(t1.amount) as amount 
from ft_Tsk_5_distributed (@dateBegin, @dateEnd, NULL, NULL) t1, 
     vCustomerRHolder t2 
where t1.rhCustId = t2.custId and  
      t1.cmCustId = isnull(@cmCustId, t1.cmCustId) 
      and isnull(t2.rateCommiss,0) = isnull(@rateCommiss, isnull(t2.rateCommiss,0))
  group by isnull(t1.rhCustId, -1), isnull(t1.cmCustId, -1), t2.rateCommiss
)
insert into @RT (rhCustId, rhCustIdName, innerInterCode, cmCustId, cmName, rateCommiss, amount, rowNum)
select t1.rhCustId,  isnull(t7.name,'НЕВИЗНАЧЕНИЙ') as rhCustIdName, 
isnull(t11.innerCode, convert(varchar(10),t1.rhCustId)) + (CASE isnull(t11.interCode,'') WHEN '' Then '' else '/'+(t11.interCode) END),
t1.cmCustId, t2.cmName, isnull(t1.rateCommiss,0), t1.amount, 
ROW_NUMBER() OVER(partition by t2.cmName, t1.rateCommiss ORDER BY t7.name, t1.rateCommiss, t7.Name)   
from 
TabTurn as t1
left join vCommunity t2 on t2.cmCustId = t1.cmCustId 
left join vCustomer t7 on t7.custId = t1.rhCustId 
left join AgreementMaster t9 on t9.custId = t1.rhCustId --and isnull(t9.agrStatus,0) <> 4 
left join RightHolder t11 on t11.custId = t1.rhCustId

RETURN
END

--select * from ft_Tsk_5_22_2_BRcm ('2018-01-01', '2019-12-31', -1, NULL) order by rowNum
--select id,rhCustId,rhCustIdName,innerInterCode,cmCustId,amount,rateCommiss from ft_Tsk_5_22_2_BRcm ('2018-01-01', '2018-12-31', NULL, NULL) order by rowNum