/*
select 
	  WIC													as WIC
	, SeqNr													as SeqNr
	, IPINr													as IPINr
	, IP_BASE_NR											as IP_BASE_NR
	, IntrPtyRol											as IntrPtyRol
	, CONCAT(RTRIM(NAME), ' ', FST_NAME)					as authName
	, ratePER												as ratePER
	, rateMEC 												as rateMEC 
from [WID_IPI].[dbo].[v_objects_authors_5_shares]
*/

; with RatePer as (
	select
		  t1.Wic														
		, t1.RolId														
		, t1.IpNameNr													
		, t1.IpRole														
		, sum(t2.Shares) as ratePer
	from SocWid..widIntrPty t1
		join SocWid..widShares t2 on t1.Wic = t2.Wic and t1.RolId = t2.IntrPtyRolid
	where t2.RightType = 'PER'
	group by 
		  t1.Wic
		, t1.RolId
		, t1.IpNameNr
		, t1.IpRole
),
RateMec as (
	select
		  t1.Wic														
		, t1.RolId														
		, t1.IpNameNr	
		, t1.IpRole														
		, sum(t2.Shares) as rateMec
	from SocWid..widIntrPty t1
		join SocWid..widShares t2 on t1.Wic = t2.Wic and t1.RolId = t2.IntrPtyRolid
	where t2.RightType = 'MEC'
	group by 
		  t1.Wic
		, t1.RolId
		, t1.IpNameNr
		, t1.IpRole
)
select --top 100
		  t1.Wic									as WIC					
		, t1.RolId									as SeqNr				
		, t1.IpNameNr								as IPINr
		, t4.IpBaseNr								as IP_BASE_NR
		, t1.IpRole									as IntrPtyRol
		, trim(concat(t4.FstName, ' ', t4.Name))	as authName
		, t1.ratePer								as ratePER
		, t2.rateMec								as rateMEC 
from RatePer t1
	join RateMec t2 on  
	        t1.Wic		= t2.Wic
		and t1.RolId	= t2.RolId
		and t1.IpNameNr = t2.IpNameNr
		and t1.IpRole	= t2.IpRole
	join SocWid..widIntrPty t3 on 
		    t2.Wic		= t3.Wic
		and t2.RolId	= t3.RolId
		and t2.IpNameNr	= t3.IpNameNr
		and t2.IpRole	= t3.IpRole
	join SocIpi..IpiName t4 on t3.IpNameNr = t4.IpNameNr
order by t1.Wic