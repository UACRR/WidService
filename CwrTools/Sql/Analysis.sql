; with Sum1 as (
	select t2.BaseRecTranId, sum(cast(t2.OwnShrPR as int) / 100) as ShrPer, sum(cast(t2.OwnShrMR as int) / 100) as ShrMec
	from RecNwr t1
		join RecSwr t2 on t1.BaseRecTranId = t2.BaseRecTranId
	group by t2.BaseRecTranId
),
Sum2 as (
select t2.BaseRecTranId, sum(cast(t2.OwnShrPR as int) / 100) as ShrPer, sum(cast(t2.OwnShrMR as int) / 100) as ShrMec
from RecNwr t1
	join RecSpu t2 on t1.BaseRecTranId = t2.BaseRecTranId
group by t2.BaseRecTranId
)
select t1.BaseRecTranId, t1.ShrPer, t2.ShrPer, t1.ShrPer + t2.ShrPer, t1.ShrMec + t2.ShrMec
from Sum1 t1
	left join Sum2 t2 on t1.BaseRecTranId = t2.BaseRecTranId
where t1.ShrMec + t2.ShrMec > 100

select *
from RecNwr t1
	left join RecSpu t2 on t1.BaseRecTranId = t2.BaseRecTranId
where t2.BaseRecTranId is null

select *
from RecNwr t1
	left join RecSwr t2 on t1.BaseRecTranId = t2.BaseRecTranId
where t2.BaseRecTranId is null
