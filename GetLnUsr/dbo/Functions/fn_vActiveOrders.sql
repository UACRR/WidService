

create function dbo.fn_vActiveOrders (@custId int, @isClient int)
RETURNS TABLE
AS 
RETURN
(
-- @isClient -- 0 - Client; 1 - RightHolder
--begin
--declare @isClient int = 1, @custId int = null;

-- последняя карточка торгов для заявки
with validId as 
(
select distinct reqid from ReqAgreement t3 where @custId is not null and t3.custId = @custId
union
select reqid from request where reqstatus in (1,2,3,11,12,13)
),
maxRAgrSum as 
(
select t1.reqId, max(t1.costOffer) as maxCostOffer
from ReqAgreement t1
join validId t2 on t2.reqId = t1.reqId
where
t1.custIdRh = t1.custID
group by t1.reqId
),
maxTradeId as
(
select t1.reqId
,max( case when t1.custIdRh is null then t3.tradeId else 0 end ) as maxTrdIdCln
,max( case when t1.custIdRh = t1.custID and t1.costOffer = t2.maxCostOffer then t3.tradeId else 0 end ) as maxTrdIdRH
from ReqAgreement t1
join maxRAgrSum t2 on t1.custIdRh is null or t1.costOffer = t2.maxCostOffer
join ReqTrade t3 on t3.rAgrId = t1.rAgrId
group by t1.reqId
),
contractId as (
select t1.reqid, max(t2.rAgrId) as rAgrId
from validId t1
join ReqAgreement t2 on t2.reqid = t1.reqid and t2.custID = t2.custIdRh
where isnull(t2.costOffer,0) = 0 and isnull(t2.amount,0) = 0
group by t1.reqid
),
trade_v as 
(
select t1.reqid, t1.tradeid, t1.status 
from ReqTrade t1
join maxTradeId t2 on t1.reqId = t2.reqId and case when isnull(t2.maxTrdIdRH,0) > t2.maxTrdIdCln then t2.maxTrdIdRH else t2.maxTrdIdCln end = t1.tradeId
),
-- по заявке текущее предложение правообладателя и заказчика
offers as 
(
select t1.reqId
, max( case when t1.CustIdRh = t1.custId then (case when isnull(t1.costOffer,0) = 0 then isnull(t1.amount,0) else t1.costOffer end) 
                                    else 0 end ) as rightHolderOffer
, max( case when t1.CustIdRh is null then (case when isnull(t1.costOffer,0) = 0 then isnull(t1.amount,0) else t1.costOffer end) 
                                    else 0 end ) as clientOffer
, max( case when  @custId is null then 0
            when @custId = t1.custid then (case when isnull(t1.costOffer,0) = 0 then isnull(t1.amount,0) else t1.costOffer end) 
			else 0 end ) as myOffer
, max( case when t1.custIdRh = t1.custID then 
				case when isnull(t1.costOffer,0) = 0 and isnull(t1.amount,0 ) = 0 then 1 else 0 end 
			else 0 end) as isContractSum                                                                
, max( case when @custId is null then null 
            when @custId = t1.custId and (@isClient <> 0 and t1.CustIdRh = t1.custId )  then rAgrId 
            when @custId = t1.custId and (@isClient = 0 and t1.CustIdRh is null )  then rAgrId 
            else 0 end ) as rAgrId
, max( case when @custId is null then 1 
            when @custId = t1.custId and (@isClient <> 0 and t1.CustIdRh = t1.custId ) then 1 else 0 end ) as isRH
, max( case when @custId is null then 1 
            when @custId = t1.custId and (@isClient = 0 and t1.CustIdRh is null ) then 1 else 0 end ) as isClient
            
from ReqAgreement t1
where t1.status in (1,2,3,4)
group by t1.reqId
)
select t1.reqid, t1.reqType ,t1.createDate, t1.reqstatus, t1.objid, t5.name, t5.author, t5.performer ,t1.workName, isnull(t3.status,0) as status, 
            t4.statusDate, t2.clientOffer, t2.rightHolderOffer, t2.myOffer, t2.isContractSum, t2.rAgrId 
, t2.isRH, t2.isClient
from 
Request t1
join ObjectRight t5 on t1.objId = t5.objId
left outer join offers t2 on t2.reqId = t1.reqid
left outer join trade_v t3 on t3.reqId = t1.reqId
left outer join ReqTrade t4 on t4.tradeId = t3.tradeid
left outer join contractId t6 on t6.reqId = t1.reqId
where
t1.reqstatus in (1,2,3,11,12,13)
and (@custId is null 
or ( @isClient = 0 and ( t2.isClient = 1 or t1.custID = @custId ))
or ( @isClient = 1 and t2.isRH = 1 ))
)
--end
