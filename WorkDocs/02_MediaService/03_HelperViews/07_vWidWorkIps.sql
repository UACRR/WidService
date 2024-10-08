use MediaService
go

create or alter view vWidWorkIps
as
with NameToBase as (
	-- За певних обставин одно імя може посилатись на декількох правовласників
	-- Для музичиних творів такого траплятись не мусить, але про всяк випадок треба запобігти дублюванню
	select 
		  IpNameNr		as IpNameNr
		, max(ipBaseNr) as IpBaseNr
	from SocIpi..IpiName
	group by IpNameNr
),
NameRoleSharesPer as (
	select
		  t1.Wic					as Wic
		, t2.IpNameNr				as IpNameNr
		, t2.IpRole					as IpRole
		, t1.RightType				as RightType
		, isnull(sum(t1.Shares), 0)	as PerShare
	from SocWid..widShares t1
		join SocWid.. widIntrPty t2 on t1.Wic = t2.Wic
			and t1.IntrPtyRolid = t2.RolId
		join NameToBase t3 on t2.IpNameNr = t3.IpNameNr
	where t1.RightType = 'PER'
	group by
		  t1.Wic
		, t2.IpNameNr
		, t2.IpRole		
		, t1.RightType
),
NameRoleSharesMec as (
	select
		  t1.Wic					as Wic
		, t2.IpNameNr				as IpNameNr
		, t2.IpRole					as IpRole
		, t1.RightType				as RightType
		, isnull(sum(t1.Shares), 0)	as MecShare
	from SocWid..widShares t1
		join SocWid.. widIntrPty t2 on t1.Wic = t2.Wic
			and t1.IntrPtyRolid = t2.RolId
		join NameToBase t3 on t2.IpNameNr = t3.IpNameNr
	where t1.RightType = 'MEC'
	group by
		  t1.Wic
		, t2.IpNameNr
		, t2.IpRole		
		, t1.RightType
)
select 
	  t1.Wic					as Wic
	, row_number() 
		over(
			partition by t1.Wic 
			order by t4.IpBaseNr
		) 						as SeqNr
	, t4.IpBaseNr				as IpBaseNr
	, t5.Name					as Name
	, t5.FstName				as FstName 
	, t4.IpNameNr				as IpNameNr
	, t1.IpRole					as IpRole
	, isnull(t2.PerShare, 0)	as PerShare
	, isnull(t3.MecShare, 0)	as MecShare
from SocWid.. widIntrPty t1
	left join NameRoleSharesPer t2 on 
			t1.Wic		 = t2.Wic
		and t1.IpNameNr	 = t2.IpNameNr
		and t1.IpRole	 = t2.IpRole
	left join NameRoleSharesMec t3 on 
			t2.Wic		 = t3.Wic
		and t2.IpNameNr  = t3.IpNameNr
		and t2.IpRole	 = t3.IpRole
	join NameToBase t4 on 
			t3.IpNameNr	 = t4.IpNameNr
	join SocIpi..IpiName t5 on
			t4.IpNameNr	 = t5.IpNameNr
go

-- select top 100 * from vWidWorkIps where Wic > 1000 and  Wic < 2000 order by Wic