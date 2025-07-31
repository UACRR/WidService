use AutoSearch
go

create or alter procedure spResetSearchSteps
	@searchType int
as
begin
	delete from SearchSteps
	if @searchType = 0	insert SearchSteps select * from SearchStepsIdentMw
	else if @searchType = 1	insert SearchSteps select * from SearchStepsMs
	else				insert SearchSteps select * from SearchStepsWid
end
go