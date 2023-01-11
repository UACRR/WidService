; with Shares as
(
	select 
		   Wic																as Wic
		,  sum(case RightType when 'PER' then isnull(Shares, 0) else 0 end) as rateTotalPER
		,  sum(case RightType when 'MEC' then isnull(Shares, 0) else 0 end) as rateTotalMEC
	from SocWid..widShares
	group by Wic
),
ObjectsR as (
	select 
		  Wic																		as Wic
		, WrkTtl																	as Name
		, timefromparts(isnull(DurHr, 0), isnull(DurMm, 0), isnull(DurSs, 0), 0, 0) as duration
		, VerType																	as specName
		, MwDistrCat																as GenreType
	FROM SocWid..widTitle
)
select -- top 100
	  t1.Wic			as Wic
	, t1.Name			as Name
	, t1.specName		as specName
	, t1.GenreType		as GenreName
	, t1.duration		as duration
	, t2.rateTotalMEC	as rateTotalMEC
	, t2.rateTotalPER	as  rateTotalPER
from ObjectsR t1
	left join Shares t2 on t1.Wic = t2.Wic