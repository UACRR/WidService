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

declare  @TmpRt table
(id integer identity not null primary key, 
 clCustId integer, 
 objid integer, 
 crCustId integer, 
 amount money, 
 clName varchar(200),
 objName varchar(200),
 crCustIdName varchar(200), 
 rateCommiss decimal(7,3)
 )

insert into @TmpRT (clCustId,  objId,  crCustId, amount)
select t1.clCustId, t1.objid, isnull(t1.rhCustId, -1), sum(t1.amount)
 from ft_Tsk_5_DistributedRed  ( @dateBegin, @dateEnd, 6, NULL) t1 
 where t1.clCustId = isnull(@custId, t1.clCustId)
 group by t1.clCustId, t1.objid, isnull(t1.rhCustId,-1)

update @TmpRT 
   set clName = t2.name 
     from @TmpRT t1 
	  join vCustomer t2 on t1.clCustId = t2.custId

update @TmpRT 
   set crCustIdName = isnull(t2.name, 'НЕ ВИЗНАЧЕНИЙ'), 
       rateCommiss = t3.rateCommiss
     from @TmpRT t1 
	  left join vCustomer t2 on t2.custId = t1.crCustId 
	  left join vCustomerRHolder t3 on t3.custId = t1.crCustId


 update @TmpRT  set objName = t2.name 
    from @TmpRT  t1 
	   join ObjectRight t2 on t2.objid = t1.objid
  
 insert into @RT 
 (crCustId, crCustIdName, clCustId, clName, objId, objName, rateCommiss, amount, rowNum) 
 select  crCustId, crCustIdName, clCustId, clName, objId, objName, rateCommiss, amount, 
 --ROW_NUMBER() OVER(partition by rateCommiss, crCustIdName ORDER BY rateCommiss, crCustIdName) 
  ROW_NUMBER() OVER( ORDER BY rateCommiss, crCustIdName, objName )
  from @TmpRt
  order by rateCommiss, crCustIdName, objName
  
RETURN
END

--select * from ft_Tsk_5_20_2_BR (null,null,0) order by rowNum
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_20_2_BR] TO [ReportUser]
    AS [dbo];

