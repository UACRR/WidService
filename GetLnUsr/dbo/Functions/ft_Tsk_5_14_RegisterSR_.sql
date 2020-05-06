--drop function  dbo.ft_Tsk_5_14_RegisterSR
CREATE function  [dbo].[ft_Tsk_5_14_RegisterSR_]  ( @dateBegin date = NULL, @dateEnd date = NULL)
--Реестры малых прав за период
RETURNS @RT TABLE
(
id integer not null identity primary key,
custId integer, 
custName varchar(100),
periodId integer,
periodName	varchar(100), 
beginDate	date, 
endDate	date, 
rmId integer, 
codeItem	integer, 
itemName	varchar(100), 
performer	varchar(100),
authorMusic	varchar(100),
authorText	varchar(100),
amount money
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
periodId,
periodName, 
beginDate, 
endDate, 
rmId, 
codeItem, 
itemName, 
performer,
authorMusic,
authorText,
amount
)
select 
max(t1.custId), 
max(t7.name), 
t1.periodId, max(t1.periodName), min(t1.beginDate), max(t1.endDate), 
t2.rmId,
max(t4.codeItem) as codeItem, max(t4.itemName), max(t4.performer), max(t4.authorMusic), max(t4.authorText), 
sum(t6.amount)
from 
PaidPeriod t1 
join RegisterRatedList t2 on t1.periodId = t2.periodId
join Register t3 on t3.rmId = t2.rmId
join RegisterItem t4 on t4.regId = t3.regId
join Distribution t5 on t5.regId = t3.regId 
join DistributionItem t6 on t6.distId = t5.distId and t6.regId = t4.regId and t6.regIItemId = t4.regIItemId
join vCustomer t7 on t1.custId = t7.custId
where isnull(codeItem,0) <> 2 and @dateBegin <= t1.beginDate and t1.endDate <= @dateEnd
group by t1.periodId, t2.rmId, t4.objId

 RETURN
 END

--select  * from dbo.ft_Tsk_5_14_RegisterSR  ('2018-01-01', '2018-12-01')

GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_14_RegisterSR_] TO [ReportUser]
    AS [dbo];

