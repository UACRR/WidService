CREATE function  dbo.[ft_Tsk_5_15_RegisterBRSum__]  ( @dateBegin date = NULL, @dateEnd date = NULL)
--Реестры Больших прав за период по Distribution & Registry
RETURNS @RT TABLE
(
id integer not null identity primary key,
custId      integer, --клиент
custName    varchar(100),
periodId    integer,
periodName	varchar(100), 
beginDate	date, 
endDate	    date, 
rmId        integer, 
codeItem	integer, 
itemName	varchar(100), 
objid       integer, 
distId      integer,
authorCustId integer, 
authorName	varchar(100),
rateRole	decimal(5,2),
rate    	decimal(5,2),
amount      money
)
AS
BEGIN  

--declare @dateBegin date, @dateEnd date, @cRightKind integer, @category integer
set @dateBegin = isnull(@dateBegin, (select convert(date, (convert(char(4),year(getdate()))+'-01-01'))))
set @dateEnd = isnull(@dateEnd, getdate())

insert into @RT 
(
custId, 
custName,
beginDate, 
endDate, 
authorCustId, 
authorName,
objid       , 
rateRole	,
rate    	,
amount      
)
select 
max(t1.custId) as custId, 
max(t7.name) as name, 
min(t1.beginDate) as beginDate, max(t1.endDate) as endDate, 
t9.custId as authorCustId, 
max(t8.name) as authorName,
max(t4.objId) as objid, 
max(t9.roleRate) as roleRate, 
max(t9.rate) as rate, 
sum(isnull(t11.amount,0)) as amount
from 
PaidPeriod t1 
join vLicenseAgreement t0 on t1.licId = t0.licId and t0.usesType = 1
join RegisterRatedList t2 on t1.periodId = t2.periodId
join Register t3 on t3.rmId = t2.rmId
join RegisterItem t4 on t4.regId = t3.regId and t4.codeItem = 2
left join Distribution t5 on t3.regId = t5.regId 
--join DistributionItem t6 on t6.distId = t5.distId and t6.regId = t4.regId and t6.regIItemId = t4.regIItemId
join vCustomer t7 on t1.custId = t7.custId
join CopyRight t9 on t4.objId = t9.objId  
join vCustomer t8 on t8.custId = t9.custId 
left join payTurn t11 on t5.distId = t11.distId and t11.accDebet like '21%' and t11.accCredit like '30%' and t9.custId = convert(integer, substring(t11.accDebet,3,10)) 
     and t4.objId = convert(integer, substring(t11.accCredit,6,10))
where @dateBegin <= t1.beginDate and t1.endDate <= @dateEnd
group by t1.custId, t9.custId
order by 2,5
RETURN
END

--select  * from dbo.ft_Tsk_5_15_RegisterBRSum  ('2018-01-01', '2018-12-01')