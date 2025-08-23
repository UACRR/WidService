use AutoSearch
go

create or alter view vTargetNamesWid
as
	select t1.*, t3.WrkTtl, t4.AltTtl
	from TargetNamesWid t1
		join TargetNameWorksWid t2 on t1.TargetNameId = t2.TargetNameId
		join SocWid..WidTitle t3 on t2.Wic = t3.Wic
		left join SocWid..WidAltTtl t4 on t2.Wic = t4.Wic
go