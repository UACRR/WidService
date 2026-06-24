use SocCisNet
go

create or alter procedure spDeleteIncompleteDownloads
as
begin
	drop table if exists #DownloadIds
	select Id into #DownloadIds	from SingleWorkDownloads where ObjId is null

	drop table if exists #WorkIds
	select t1.Id into #WorkIds from Works t1 join #DownloadIds t2 on t1.SingleWorkDownloadId = t2.Id

	delete t1 from WorkShares t1 join #WorkIds t2 on t1.WorkId = t2.Id
	delete t1 from WorkAltNames t1 join #WorkIds t2 on t1.WorkId = t2.Id
	delete t1 from WorkPerformers t1 join #WorkIds t2 on t1.WorkId = t2.Id
	delete t1 from Works t1 join #WorkIds t2 on t1.Id = t2.Id
	delete t1 from SingleWorkDownloads t1 join #DownloadIds t2 on t1.Id = t2.Id
end
go
