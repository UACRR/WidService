use RadioStationReports
go

create or alter procedure spUpdateWorksFromCisNet
as
begin
	update t1
	set t1.ObjId = t2.ObjId
--	select *
	from Works t1
		join MediaService..CisNetWorks t2 on t1.CisNetWorkCode = t2.WorkCode
	where isnull(t1.CisNetWorkCode, '') <> ''
end