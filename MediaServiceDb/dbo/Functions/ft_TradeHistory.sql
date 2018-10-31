
CREATE function [dbo].[ft_TradeHistory] ( @reqId int, @lang char(2)=NULL )
RETURNS @RT TABLE
(
 id integer not null identity primary key, 
 Num  integer not null, 
 statusDate datetime  null, 
 Custname   varchar(100) null, 
 custId     integer        null, 
 status     integer null, 
 statusName varchar(100) null,
 Amount     money   null, 
 sDate      date null, 
 sTime      char(8) NULL
 )
AS
BEGIN

set @lang = isnull(@lang, 'Uk')
set @lang = (Case When @lang not in ('Uk', 'Ru', 'En') Then 'Uk' Else @lang end)

declare @RhName varchar(50)

set @RhName = (Case When @lang='EN' Then 'Offer from Rightholders ' Else 
        (Case When @lang='RU' Then 'Предложение правообладателей' Else 'Пропозиція правовласників' end) end)

insert into @Rt 

select  1, t1.createdate, @RhName, a1.custID, t1.status, s1.statusName, t1.costRHolder as Amount 
,convert(char(10),t1.createdate,104), convert(char(8), t1.createdate,108)
from (select  max(a1.custID) as custId, max(a1.reqId) as reqId
from reqTrade t1 
join reqAgreement a1 on a1.reqId = t1.reqId and a1.amount = t1.costRHolder
where t1.reqId = @reqId and t1.status = 10 ) a1 
join  ReqTrade t1 on t1.reqId = a1.reqId and t1.status = 10
--join vCustomer v1 on a1.custID = v1.custID
join vlTradeStatus s1 on t1.status = s1.statusCode and s1.lang = @lang

union

select (Case When t1.status in (2, 12) Then 3 Else (Case When t1.status in (10) Then 1 Else 2 end) end), 
 t1.statusdate, 
(Case When t1.status in (12,2) Then '' Else v1.name end), a1.custID, t1.status, s1.statusName, 
(Case When t1.status in (4)  Then t1.costRHolder else t1.costClient end ) as Amount 
,convert(char(10),t1.statusdate,104), convert(char(8), t1.statusdate,108)
from reqTrade t1 
join reqAgreement a1 on t1.reqId = a1.reqId and a1.rAgrId = t1.rAgrId 
join vlTradeStatus s1 on t1.status = s1.statusCode and s1.lang = @lang
join vCustomer v1 on a1.custID = v1.custID
join request r1 on r1.reqId = t1.reqId 
where t1.reqId = @reqId 
  and t1.status in (2,3,4, 8,9, 10, (Case When r1.reqstatus in ( 2,3,4,5,6,7) Then 0 Else r1.reqstatus end))


union  --согласования из reqAgreement

select  2, a1.statusdate, v1.name, a1.custID, a1.status, s1.statusName, 
a1.costOffer as Amount 
,convert(char(10),a1.statusdate,104), convert(char(8),a1.statusdate,108)
from reqTrade t1 
join reqAgreement a1 on t1.reqId = a1.reqId and a1.tradeId = t1.tradeId 
join vlReqAgreementStatus s1 on a1.status = s1.statusCode and s1.lang = @lang
join vCustomer v1 on a1.custID = v1.custID
where t1.reqId = @reqId and a1.status in (2,4)

union  --предложения правообладателей, которых нет в трейдах, т.к. сумма не максимум

select  2, a1.statusdate, v1.name, a1.custID, a1.status, s1.statusName, 
a1.costOffer as Amount 
,convert(char(10),a1.statusdate,104), convert(char(8), a1.statusdate,108)
from reqAgreement a1 
join vlReqAgreementStatus s1 on a1.status = s1.statusCode and s1.lang = @lang
join vCustomer v1 on a1.custID = v1.custID 
where a1.reqId = @reqId and isnull(custIdRh,0)<>0 and a1.status = 3 
and not exists ( select 1 from reqTrade t1 where t1.reqId = a1.reqId and t1.ragrId = a1.rAgrId and a1.costOffer = t1.costRHolder)
order by 1,2 


Return

end

--select * from ft_TradeHistory (118, 'Uk')