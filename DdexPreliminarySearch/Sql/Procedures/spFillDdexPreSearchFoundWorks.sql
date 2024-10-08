use Ddex_Mw_Search
go

create or alter procedure spFillDdexPreSearchFoundWorks (
	@ddexReportId int, @blockSeqNr int
)
as
begin

insert DdexPreSearchFoundWorks (
	  DdexPreSearchReportWorkId
	, Name
	, Authors
	, Performers
	, SourceCol
	, TargetDb
	, TargetTbl
	, FoundId
)
select 
	  t1.Id as DdexPreSearchReportWorkId
	, t2.Name as Name
	, t2.Author as Authors
	, t2.performer as Performers
	, 'N' as SourceCol
	, 'MS' as TargetDb
	, 'Main' as TargetTbl
	, t2.objId as FoundId
from DdexPreSearchReportWorks t1
	join MediaService..SeekObject t3 on t1.Name = t3.name and t3.codeI = 1
	join MediaService..ObjectRight t2 on t1.Name = t2.name
where t1.DdexReportId = @ddexReportId
	and t1.BlockSeqNr = @blockSeqNr
	and t1.MwId not in (select MwId from DdexPreSearchFoundWorks)

end
go

exec spFillDdexPreSearchFoundWorks 115, 10
go

select * from DdexPreSearchReportWorks order by MwId
go
