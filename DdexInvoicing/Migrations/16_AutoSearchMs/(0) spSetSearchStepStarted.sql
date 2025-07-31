use AutoSearch
go

create or alter procedure spSetSearchStepStarted
	@stepId int
as
begin
	update SearchSteps set Status = 1 where Id = @stepId
end
go