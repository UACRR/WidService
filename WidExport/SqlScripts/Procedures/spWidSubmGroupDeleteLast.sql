use SocWidSubmit
go

create or alter procedure spWidSubmGroupDeleteLast
as
begin
declare @seqNr int = (select max(SeqNr) from WidSubmGroup)

if @seqNr is not null
begin
	declare @WidSubmGroupId int = (select Id from WidSubmGroup where SeqNr = @SeqNr)
	delete WidSubmGroupPartyWork where WidSubmGroupId = @WidSubmGroupId
	delete WidSubmGroupWorkName where WidSubmGroupId = @WidSubmGroupId
	delete WidSubmGroupWorkPerformer where WidSubmGroupId = @WidSubmGroupId
	delete WidSubmGroupWorkShare where WidSubmGroupId = @WidSubmGroupId
	delete WidSubmGroupParty where WidSubmGroupId = @WidSubmGroupId
	delete WidSubmGroupWork where WidSubmGroupId = @WidSubmGroupId
	delete WidSubmGroup where Id = @WidSubmGroupId
end

end
go

-- spWidSubmGroupDeleteLast
