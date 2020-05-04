create view vActiveRequest as

with d_maxAmount as
( 
select reqid, max(amount) as amount , sum( case when isnull(amount,0) = 0 then 1 else 0 end ) as cnt_0
from ReqAgreement t1 
where custIdRh = custID
group by reqid
), 
d_clnAmmount as 
( 
select t1.reqid, t1.rAgrId ,t1.costOffer, t1.tradeId 
from ReqAgreement t1 
join ( select reqid, max(rAgrId) as rAgrId 
			  from ReqAgreement 
			  where custIdRh is null 
			  group by reqid ) t2 on t2.rAgrId = t1.rAgrId 
),
d_clnTradeId as 
(
select t1.reqid, max(t1.tradeId) as tradeId 
from ReqTrade t1
join d_clnAmmount t2 on t1.rAgrId = t2.rAgrId
group by t1.reqid 
),
d_tradeClnSum as 
(
select t2.reqId, t2.costClient, t2.status from d_clnTradeId t1
join reqTrade t2 on t2.tradeId = t1.tradeId
),
d_tradeRHSum as
(
select t1.reqId, max(t1.costRHolder) as costRHolder 
from ReqTrade t1 
join d_clnTradeId t2 on t2.reqId = t1.reqId and t1.tradeId > t2.tradeId
group by t1.reqId
)

select t1.reqId, t1.reqstatus
, case when t2.cnt_0 > 0 then 'Договірна' else cast(t2.amount as varchar(32)) end as amountRH
, t3.costOffer as amountClient
, t4.costClient
, t4.status
, t5.costRHolder
, t6.statusNameUk 
from request t1
left outer join d_maxAmount t2 on t2.reqId = t1.reqId
left outer join d_clnAmmount t3 on t3.reqId = t1.reqId
left outer join d_tradeClnSum t4 on t4.reqId = t1.reqId
left outer join d_tradeRHSum t5 on t5.reqId = t1.reqId
left outer join TradeStatus t6 on t6.statusCode = t4.status
