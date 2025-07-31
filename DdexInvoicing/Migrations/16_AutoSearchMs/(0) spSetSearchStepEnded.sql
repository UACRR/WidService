use AutoSearch
go

create or alter procedure spSetSearchStepEnded
	@stepId int
as
begin
	update SearchSteps set Status = 2 where Id = @stepId
end
go