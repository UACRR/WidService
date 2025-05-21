use MediaService
go

create or alter view vWidWorkShares
as

with RightHolder as (
	select distinct Wic, IpNameNr, IpRole
	from SocWid..widIntrPty
--	where Wic = 42540164
)
, Per as (
	select t1.Wic, t2.IpNameNr, t2.IpRole, t1.Shares
	from SocWid..WidShares t1
		join SocWid..widIntrPty t2 on 
				t1.Wic = t2.Wic
			and t1.IntrPtyRolid = t2.RolId
	where t1.RightType = 'PER'
), Mec as (
	select t1.Wic, t2.IpNameNr, t2.IpRole, t1.Shares
		from SocWid..WidShares t1
			join SocWid..widIntrPty t2 on 
					t1.Wic = t2.Wic
				and t1.IntrPtyRolid = t2.RolId
		where t1.RightType = 'MEC'
)
select t1.Wic, t4.Name, t4.FstName, t1.IpNameNr, t1.IpRole, t2.Shares as SharePer, t3.Shares as ShareMec
from RightHolder t1
	left join Per t2 on t1.Wic = t2.Wic
		and t1.IpNameNr = t2.IpNameNr
		and t1.IpRole = t2.IpRole
	left join Mec t3 on t1.Wic = t3.Wic
		and t1.IpNameNr = t3.IpNameNr
		and t1.IpRole = t3.IpRole
	join SocIpi..IpiName t4 on t1.IpNameNr = t4.IpNameNr

go

/*
select * 
from vWidWorkShares t1
	--left join RightHolder t2 on t1.IpNameNr = t2.IPIBase
where t1.Wic = 41165942 -- 26309936 41165942 42540164
	--and t2.CustId is null
*/


