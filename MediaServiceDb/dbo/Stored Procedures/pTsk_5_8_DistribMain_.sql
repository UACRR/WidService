CREATE procedure [pTsk_5_8_DistribMain_] ( @dateBegin date = NULL, @dateEnd date = NULL,@cmFlag int,@categoryCode integer )
as 
BEGIN

declare @result Table (
id integer not null identity primary key, 
custId integer null, 
categoryCode integer, 
cmFlag smallint,
sCollect money, 
sCommiss money, 
sDistrib money,
rateCommiss decimal(10,5)  
)
 

set @dateBegin = isnull(@dateBegin,(select convert(date, (convert(char(4),year(getdate()))+'-01-01'))))
set @dateEnd = isnull(@dateEnd, getdate())
if  (@categoryCode not in (5,6))
	return
if (@cmFlag not in (0,1))
	return
if (@dateBegin>@dateEnd)
	return

Declare @TmpRT Table
(
id integer not null identity primary key, 
custId integer, 
categoryCode integer, 
cmFlag smallint,
sCollect money, 
sCommiss money, 
sDistrib money,
rateCommiss decimal(10,5)  
)

declare @TabSend table 
(custid integer not null primary key, 
amount money )

declare @TabCommiss table 
(custid integer not null primary key, 
amount money )

insert into @TabCommiss (custId, amount)
select t2.custId, sum(t1.amount) as amount
from payTurn t1 
join account t2 on t2.accId = t1.accIdCredit
where t1.dateOper between @dateBegin and @dateEnd and 
substring(t1.accDebet,1,2) in ('11') and t1.accCredit like '21%'
group by t2.custId

insert into @TabSend  (custId, amount)
select t2.custId, sum(t1.amount) as amount
from payTurn t1 
join account t2 on t2.accId = t1.accIdCredit
where t1.dateOper between @dateBegin and @dateEnd and 
substring(t1.accDebet,1,2) in ('20') and t1.accCredit like '21%'
group by t2.custId

----Нужно упростить с marge

;with TabCollect as  --собрано
(
select 
t2.custId, t5.categoryCode, sum(amount) as amount,
max(t7.rateCommiss) as rateCommiss
from payTurn t1 
join Account t2 on t1.accIdDebet = t2.accId
left join Community t3 on t3.custId = t2.custId 
join Account t4 on t4.accId = t1.accIdCredit
join objectRight t5 on (t4.objid = t5.objid  and @categoryCode=t5.categoryCode)
join RightHolder t6 on t6.custId = t2.custId 
left join AgreementAddRH t7 on t7.custId = t6.custId
where t1.dateOper between @dateBegin and @dateEnd and 
substring(t1.accDebet,1,2) in ('21') and t1.accCredit like '30%'
group by t2.custId, t5.categoryCode
) 
insert into @TmpRT 
(custId,  categoryCode, sCollect, sCommiss, sDistrib, rateCommiss)
select isnull(isnull(t1.custId,t2.custId), t3.custId), t1.categoryCode, 
t1.amount as sCollect, isnull(t2.amount,0) as sCommiss, isnull(t3.amount,0) as sDistrib, 
t1.rateCommiss
from TabCollect t1
left join @TabCommiss t2 on t1.custId = t2.custId
left join @TabSend t3 on t1.custId = t3.custId 

insert into @TmpRT (custid, sCommiss, categoryCode)
select t1.custId, t1.amount, 99
  from @TabCommiss t1 
   where not exists ( select  1 from @TmpRT t2 where t1.custid = t2.custId)

update @TmpRT set sDistrib = t2.amount 
  from @TmpRT t1 join @TabSend t2 on t1.custId = t2.custid

 insert into @TmpRT (custid, sDistrib, categoryCode)
 select t1.custId, t1.amount, 99
  from @TabSend t1 
   where not exists ( select  1 from @TmpRT t2 where t1.custid = t2.custId)

--правообладатели, по которым собрано, их комиссии и их отправленные ср-ва
;with TabDouble as 
(
select custId, count(*) as c from @TmpRT group by custId having count(*)>1 
) 
insert into @result
 (custId, categoryCode, sCollect, sCommiss, sDistrib, rateCommiss)
select t1.custId, isnull(t1.categoryCode,99),
 t1.sCollect, 
 t1.sCommiss*(case when isnull(t2.custId,0) = 0 then 1 else 0 end) as sCommiss, 
 t1.sDistrib*(case when isnull(t2.custId,0) = 0 then 1 else 0 end) as sDistrib, 
 t1.rateCommiss
from @TmpRT t1 
left join TabDouble t2 on t1.custId = t2.custId 
union 
select 
t1.custId, 99, 
 0 as sCollect, 
 max(t1.sCommiss) as sCommiss, 
 max(t1.sDistrib) as sDistrib,
 NULL
from @TmpRT t1 
join TabDouble t2 on t1.custId = t2.custId 
group by t1.custId

update @result set cmFlag = (case When isnull(t2.custId,0) = 0 Then 0 else 1 end)
   from @result t1 
   left join Community t2 on t1.custId = t2.custId
select ROW_NUMBER() OVER(ORDER BY name ASC) id,t2.name,t3.innerCode,t1.sCollect,t1.sCommiss,t1.sDistrib,t1.rateCommiss  from 
(select *  from @result where
@cmFlag=cmFlag  and
@categoryCode=categoryCode ) t1
left join  vCustomer t2 on t1.custid  = t2.custId 
left join  RightHolder t3 on t1.custId=t3.custId


RETURN
END

--exec pTsk_5_8_DistribMain NULL, NULL,0,5