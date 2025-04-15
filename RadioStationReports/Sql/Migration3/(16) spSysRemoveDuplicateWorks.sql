use RadioStationReports
go

create or alter procedure spSysRemoveDuplicateWorks
as
begin
drop table if exists #DupNamePerformers
select Name, Performers
into #DupNamePerformers
from Works
group by Name, Performers
having count(*) > 1

drop table if exists #OrderedDupWorks
select
	  row_number() over (partition by t2.Name, t2.Performers order by ObjId desc, wic desc) as SeqNr
	, t2.Id as WorkId
	, t2.Name
	, t2.Performers
into #OrderedDupWorks
from #DupNamePerformers t1
	join WOrks t2 on
			t1.Name		  = t2.Name
		and t1.Performers = t2.Performers

drop table if exists #PrimaryDupWorks
select WorkId, Name, Performers
into #PrimaryDupWorks
from #OrderedDupWorks
where SeqNr = 1

--select t1.WorkId as WorkIdOld, t3.WorkId as WorkIdNew
update t1
set t1.WorkId = t3.WorkId
from ReportLines t1
	join #OrderedDupWorks t2 on t1.WorkId = t2.WorkId
	join #PrimaryDupWorks t3 on
			t2.Name		  = t3.Name
		and t2.Performers = t3.Performers
where t2.SeqNr > 1

delete t1
from Works t1
	join #OrderedDupWorks t2 on t1.Id = t2.WorkId
where t2.SeqNr > 1
end
go

exec spSysRemoveDuplicateWorks

