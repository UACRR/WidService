use MediaService
go

create or alter view  vWidWrkSharesPerAuthor
as
	select
		  t1.Wic as Wic
		, t1.RolId as RolId
		, t1.IpNameNr as IpNameNr
		, t1.IpRole as IpRole
		, sum(case when t2.RightType = 'PER' then t2.Shares else 0 end) as sharePer
		, sum(case when t2.RightType = 'MEC' then t2.Shares else 0 end) as shareMec
	from SocWid..widIntrPty t1
		join SocWid..WidShares t2 on t1.Wic = t2.Wic and t1.RolId = t2.IntrPtyRolid
	group by t1.Wic
		, t1.RolId
		, t1.IpNameNr
		, t1.IpRole
go
