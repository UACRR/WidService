use SocWidSubmit
go

create or alter procedure spWidSubmGroupAdd
as
begin
declare @seqNr int = (select max(SeqNr) from WidSubmGroup)

if @seqNr is null set @seqNr = 1 else set @seqNr = @seqNr + 1

insert WidSubmGroup (
	  SeqNr
	, Name
	, Status
)
values (
	  @seqNr					-- SeqNr
	, concat('Група ', @seqNr)  -- Name
	, 0							-- Status
)

select
	  Id
	, SeqNr
	, Name
	, Status
from WidSubmGroup 
where Id = scope_identity()
end
go