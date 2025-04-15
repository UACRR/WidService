use RadioStationReports
go

create or alter procedure spSetReportRegistered
	@reportId int
as
begin
	update Reports set Status = 1 where Id = @reportId
end