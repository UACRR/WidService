use Ddex
go

create or alter procedure spExtendReportAuthors
	@ddexReportId int
as
begin

declare @fileType varchar(100) = (select FileType from DdexReport where Id = @ddexReportId)
if @fileType <> 'tiktok' return

drop table if exists #Residuals
select
	  Wic
	, ObjId
	, 100 - sum(isnull(PerShr, 0) * isnull(PerSocShr, 0)) / 100 as PerRes
	, 100 - sum(isnull(MecShr, 0) * isnull(MecSocShr, 0)) / 100 as MecRes
into #Residuals
from DdexReportAuthors 
where DdexReportId = @ddexReportId
group by Wic, ObjId
union
select t2.Wic, null, 100, 100
from IdentBacklog t1
	join IdentMw t2 on t1.mwId = t2.Id
	left join DdexReportAuthors t3 on t2.Wic = t3.Wic
		and t3.DdexReportId = @ddexReportId
where t1.DdexReportId = @ddexReportId
	and t2.Status = 2
	and isnull(t2.Wic, 0) <> 0
	and t3.Wic is null
union
select null, t2.ObjId, 100, 100
from IdentBacklog t1
	join IdentMw t2 on t1.mwId = t2.Id
	left join DdexReportAuthors t3 on t2.ObjId = t3.ObjId
		and t3.DdexReportId = @ddexReportId
where t1.DdexReportId = @ddexReportId
	and isnull(t2.ObjId, 0) <> 0
	and t3.ObjId is null

declare @custId int = (select custId from MediaService..Customer where custType = 7)
insert DdexReportAuthors (
	  DdexReportId
	, Wic
	, ObjId
	, IpBaseNr
	, CustId
	, IpNameNr
	, PerShr
	, MecShr
	, PerSocShr
	, MecSocShr
	, PerSoc
	, MecSoc
)
select 
	  @ddexReportId		as DdexReportId
	, Wic		as Wic
	, ObjId		as ObjId
	, null		as IpBaseNr
	, @custId	as CustId
	, null		as IpNameNr
	, PerRes	as PerShr
	, MecRes	as MecShr
	, 100		as PerSocShr
	, 100		as MecSocShr
	, 140		as PerSoc
	, 140		as MecSoc
from #Residuals
where PerRes <> 0 or MecRes <> 0

drop table if exists #Residuals

/*
drop table if exists #test
select Wic, ObjId, sum(PerShr * PerSocShr) / 100 as PerShr, sum(MecShr * MecSocShr) / 100 as MecShr
into #test
from DdexReportAuthors 
where DdexReportId = @ddexReportId
group by Wic, ObjId
select * from #test where PerShr <> 100
select * from #test where MecShr <> 100
drop table if exists #test
*/

end
go

-- exec spExtendReportAuthors 1496, 27