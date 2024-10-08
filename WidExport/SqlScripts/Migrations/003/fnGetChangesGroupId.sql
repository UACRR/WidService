create or alter function fnGetChangesGroupId ()
returns int
as
begin
	return (select Id from WidSubmGroup where GroupType = 'C')
end
go

