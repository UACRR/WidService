select *
from TmpMwInfo t1
	left join DdexReportMwInfo t2 on t1.Wic = t2.Wic
where t2.DdexReportId = 9
	and t1.Wic is not null
	and t2.Wic is null

select *
from TmpMwInfo t1
	left join DdexReportMwInfo t2 on t1.ObjId = t2.ObjId
where t2.DdexReportId = 9
	and t1.ObjId is not null
	and t2.ObjId is null

select *
from TmpAuthorInfo t1
where t1.Wic is not null
	and not exists (
		select null
		from DdexReportAuthors t2
		where t2.DdexReportId = 9
			and t1.Wic = t2.Wic
	)

select *
from TmpAuthorInfo t1
where t1.ObjId is not null
	and not exists (
		select null
		from DdexReportAuthors t2
		where t2.DdexReportId = 9
			and t1.ObjId = t2.ObjId
	)

-- WicPerShr - Adjust Zero Shares
; with ZeroShareWics as (
	select 
	  t1.Wic
	, sum(isnull(t2.PerShr, 0)) PerShr
	, count(*) AuthorCount
	from TmpMwInfo t1
		join TmpAuthorInfo t2 on t1.Wic = t2.Wic
	where t1.Wic is not null
		and t1.AmountPer > 0
	group by t1.Wic
	having sum(isnull(t2.PerShr, 0)) = 0
)
update t2
set PerShr = cast(100.00 / AuthorCount as decimal(5, 2))
from ZeroShareWics t1
	join TmpAuthorInfo t2 on t1.Wic = t2.Wic

-- WicMecShr - Adjust Zero Shares
; with ZeroShareWics as (
	select 
	  t1.Wic
	, sum(isnull(t2.MecShr, 0)) MecShr
	, count(*) AuthorCount
	from TmpMwInfo t1
		join TmpAuthorInfo t2 on t1.Wic = t2.Wic
	where t1.Wic is not null
		and t1.AmountMec > 0
	group by t1.Wic
	having sum(isnull(t2.MecShr, 0)) = 0
)
update t2
set MecShr = cast(100.00 / AuthorCount as decimal(5, 2))
from ZeroShareWics t1
	join TmpAuthorInfo t2 on t1.Wic = t2.Wic

-- ObjIdPerShr - Adjust Zero Shares
; with ZeroShareObjIds as (
	select 
	  t1.ObjId
	, sum(isnull(t2.PerShr, 0)) PerShr
	, count(*) AuthorCount
	from TmpMwInfo t1
		join TmpAuthorInfo t2 on t1.ObjId = t2.ObjId
	where t1.ObjId is not null
		and t1.AmountPer > 0
	group by t1.ObjId
	having sum(isnull(t2.PerShr, 0)) = 0
)
update t2
set PerShr = cast(100.00 / AuthorCount as decimal(5, 2))
from ZeroShareObjIds t1
	join TmpAuthorInfo t2 on t1.ObjId = t2.ObjId

-- ObjIdMecShr - Adjust Zero Shares
; with ZeroShareObjIds as (
	select 
	  t1.ObjId
	, sum(isnull(t2.MecShr, 0)) MecShr
	, count(*) AuthorCount
	from TmpMwInfo t1
		join TmpAuthorInfo t2 on t1.ObjId = t2.ObjId
	where t1.ObjId is not null
		and t1.AmountMec > 0
	group by t1.ObjId
	having sum(isnull(t2.MecShr, 0)) = 0
)
update t2
set MecShr = cast(100.00 / AuthorCount as decimal(5, 2))
from ZeroShareObjIds t1
	join TmpAuthorInfo t2 on t1.ObjId = t2.ObjId


