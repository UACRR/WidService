use [RadioStationReports]
go

create or alter procedure spDeleteReport
	@ReportId int
as
begin
	delete from ReportAuthors where ReportId = @ReportId
	delete from ReportLines where ReportId = @ReportId
	delete from Reports where Id = @ReportId
end
go

-- exec spDeleteReport 54