CREATE function  [dbo].[ft_Tsk_5_25_2_SRLic] (@dateBegin date = NULL, @dateEnd date = NULL, @rateCommiss integer = NULL, @cmCustId integer = NULL  )
--* МП по договорах - Загальна/ft_Tsk_5_25_2_SRLic
-- @rateCommiss - по конкретной комиссии. NULL / -1 - все комиссии
-- @cmCustId - ПО ТОВАРИСТВУ.  0, null - ПО ВСЕМ
-- 19-07-2019 Дорозподіл
RETURNS @RT TABLE
(
id integer identity  primary key,
rateCommiss decimal(7,3), 
rhCustId integer,
rhName varchar(200), 
cmCustId integer, 
cmName varchar(200), 
licCode integer, 
licCodeName varchar(200),
amount money, 
rowNum integer
)
as
BEGIN

--Первый день месяца
set @dateBegin = isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())

set @rateCommiss = (Case When isnull(@rateCommiss,-1) = -1 Then NULL Else @rateCommiss end)
set @cmCustId = (Case When isnull(@cmCustId,0) = 0 Then NULL Else @cmCustId end)

--create table #TmpRt
declare @TmpRt table 
(
rateCommiss decimal(7,3), 
rhCustId integer not null,
regId integer not null,
cmCustId integer not null, 
licCode integer, 
licCodeName varchar(200) null, 
amount money, 
kindCode integer not null, 
primary key (rhCustId, regId, kindCode, cmCustId )
) 

insert into @TmpRt 
( rhCustId, cmCustId, regId, kindCode,  amount ) 
 select  isnull(rhCustId, -1), isnull(cmCustId, -1), isnull(regId, 0), kindCode,  sum(amount)
  from ft_Tsk_5_DistributedRed (@dateBegin, @dateEnd, 5, NULL)  
  --from ft_Tsk_5_Distributed (@dateBegin, @dateEnd, 5, NULL)  
  --from ft_Tsk_5_DistributedRed ('2019-07-19', '2019-07-19', 5, NULL)  
   where cmCustId  = isnull(@cmCustid, cmCustId) 
    group by rhCustId, regId, cmCustId, kindCode

update @TmpRt 
  set licCode = t2.licCode, licCodeName = t2.licCodeName
    from @TmpRt t1
         join vRegister t2 on t2.regId = t1.regId 

update @TmpRt set rateCommiss = t2.rateCommiss 
     from @TmpRt t1 
          join vCustomerRHolder t2 on t2.custId = t1.rhCustId

insert into @RT (rateCommiss, rhCustId, rhName, cmCustId, cmName, licCode, licCodeName, amount, rowNum)
 select  rateCommiss, rhCustId, isnull(t2.name, 'Не визначений') as rhName, 
         cmCustId, isnull(t3.name, 'НЕ ВИЗНАЧЕНО') as cmName,isnull(licCode,-100), isnull(licCodeName, 'Дорозподілено АВ'), amount, 
         ROW_NUMBER() OVER( ORDER BY t3.name, t1.rateCommiss, t2.name) 
   from @TmpRt  t1 
     left join vCustomer t2 on t2.custId = t1.rhCustId 
	 left join vCustomer t3 on t3.custId = t1.cmCustId
	 where isnull(t1.rateCommiss,0) = isnull(@rateCommiss, isnull(t1.rateCommiss,0))

RETURN
END
--select * from dbo.ft_Tsk_5_25_2_SRLic ( '2019-07-19',  '2019-07-19', NULL, NULL)  --order by rownum  237721,40
--select  sum(amount) from ft_Tsk_5_DistributedRed ('2019-07-19', '2019-07-19', 5, NULL) 
--select sum(amount) from ft_Tsk_5_DistributedRed ('2019-01-01',  '3000-01-01', 5, NULL)  

GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_25_2_SRLic] TO [ReportUser]
    AS [dbo];

