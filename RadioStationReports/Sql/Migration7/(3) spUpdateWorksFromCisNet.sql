use RadioStationReports
go

create or alter procedure spUpdateWorksFromCisNet
as
begin
	update t1
	set t1.ObjId = t2.ObjId
--	select *
	from Works t1
		join MediaService..CisNetWorks t2 on t1.CisNetWorkId = t2.WorkId
	where isnull(t1.CisNetWorkId, 0) <> 0
end