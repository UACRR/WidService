use MediaService
go

create or alter view vWidSrObjectAuthors
as
select 
		  t1.Wic									as WIC					
		, cast(t1.RolId	as smallint)				as SeqNr				
		, cast(t1.IpNameNr as varchar(11))			as IPINr
		, t2.IpBaseNr								as IP_BASE_NR
		, t1.IpRole									as IntrPtyRol
		, trim(concat(t2.FstName, ' ', t2.Name))	as authName
		, t3.Shares									as ratePER
		, t4.Shares									as rateMEC 
from SocWid..widIntrPty t1
	join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
	left join SocWid..WidShares t3 on t1.Wic = t3.Wic
		and t1.RolId = t3.IntrPtyRolid
		and t3.RightType = 'PER'
	left join SocWid..WidShares t4 on t1.Wic = t4.Wic
		and t1.RolId = t4.IntrPtyRolid
		and t4.RightType = 'MEC'
go

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
