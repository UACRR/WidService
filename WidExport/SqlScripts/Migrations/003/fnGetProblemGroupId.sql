create or alter function fnGetProblemGroupId ()
returns int
as
begin
	return (select Id from WidSubmGroup where GroupType = 'P')
end
go

