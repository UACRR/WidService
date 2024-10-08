use SocWidSubmit
go

create or alter procedure spWidSubmGroupSelect
	@groupId int = null
as
begin
if @groupId is null
	select
		  Id
		, SeqNr
		, Name
		, Status
	from WidSubmGroup 
	order by SeqNr
else
	select
		  Id
		, SeqNr
		, Name
		, Status
	from WidSubmGroup
	where Id = @groupId
end
go

-- spWidSubmGroupSelect
