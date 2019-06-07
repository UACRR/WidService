
/*==============================================================*/
/* View: vActiveOrders                                          */
/*==============================================================*/
create view vActiveOrders as
with trade_v as 
(
select t1.reqid, max( tradeid ) tradeid, max(t2.reqstatus) as reqstatus
from ReqTrade t1
join Request t2 on t2.reqid = t1.reqid and t2.reqstatus in (0,1,11,12)
group by t1.reqid
),
offers as 
(
select t1.reqId
, max( case when t1.custIdRh = t1.custID and isnull(t1.amount,0) = 0 and  isnull( t1.costOffer,0) = 0  then 0
				 when t1.custIdRh = t1.custID and isnull( t1.costOffer,0) = 0 then t1.amount
				 when t1.custIdRh = t1.custID then t1.costOffer 
				 else 0 end ) as rightHolderOffer
, max( case when t1.custIdRh is null and isnull(t1.amount,0) = 0 and  isnull( t1.costOffer,0) = 0  then 0
				 when t1.custIdRh is null and isnull( t1.costOffer,0) = 0 then t1.amount
				 when t1.custIdRh is null then t1.costOffer 
				 else 0 end ) as clientOffer

from ReqAgreement t1
join trade_v t2 on t2.reqId = t1.reqId
join reqtrade t3 on t3.tradeId = t1.tradeId
where t1.status in (0,1,2,4,3,10)
group by t1.reqId
)
select t1.reqid, t1.createDate, t5.name, t5.author, t5.performer ,t1.workName, t4.status, t4.statusDate, t2.clientOffer, t2.rightHolderOffer 
from 
Request t1
join offers t2 on t2.reqId = t1.reqid
join trade_v t3 on t3.reqId = t1.reqId
join ReqTrade t4 on t4.tradeId = t3.tradeid
join ObjectRight t5 on t1.objId = t5.objId
GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Активные заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vActiveOrders';

