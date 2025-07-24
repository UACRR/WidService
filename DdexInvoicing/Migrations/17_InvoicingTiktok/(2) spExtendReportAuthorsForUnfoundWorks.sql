use Ddex
go

create or alter procedure spExtendReportAuthorsForUnfoundWorks
	@ddexReportId int
as
begin

declare @fileType varchar(100) = (select FileType from DdexReport where Id = @ddexReportId)
if @fileType <> 'tiktok' return

drop table if exists #NotFoundMwIds
select distinct t1.MwId
into #NotFoundMwIds
from IdentBacklog t1
	join IdentMw t2 on t1.MwId = t2.Id
where t1.DdexReportId = @ddexReportId
	and t2.Status <> 2

insert MediaService..ObjectRight (
	  CategoryCode
	, Name
	, Author
	, Performer
	, loadid
)
select 
	  18					as CategoryCode
	, t3.Title				as Name
	, ''					as Author
	, ''					as Performer
	, t3.Id as loadid
from #NotFoundMwIds t1
	left join MediaService..ObjectRight t2 on
			t2.categoryCode = 18
		and loadId = t1.MwId
	join IdentMw t3 on t1.MwId = t3.Id
where t2.categoryCode is null

select * from MediaService..Category

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
	, null		as Wic
	, ObjId		as ObjId
	, null		as IpBaseNr
	, @custId	as CustId
	, null		as IpNameNr
	, 100		as PerShr
	, 100		as MecShr
	, 100		as PerSocShr
	, 100		as MecSocShr
	, 140		as PerSoc
	, 140		as MecSoc
from #NotFoundMwIds t1
	join MediaService..ObjectRight t2 on
			t2.categoryCode = 18
		and loadId = t1.MwId

drop table if exists #NotFoundMwIds

/*
select * 
from DdexReportAuthors t1
	join MediaService..ObjectRight t2 on t1.ObjId = t2.ObjId and t2.categoryCode = 18
where DdexReportId = @ddexReportId
*/
end

go

-- exec spExtendReportAuthorsForUnfoundWorks 1496