use SocWidSubmit
go

create or alter procedure spSubmFileClearRecRefs
	@submFileId int
as
begin

	if @submFileId = 0 return;
	
	declare @GroupId int = (select WidSubmGroupId from SubmFile where Id = @submFileId)
	
	drop table if exists #ObjIds
    
	select cast(substring(SubmWrkNr, 3, 100) as int) as ObjId
	into #ObjIds
    from RecWia 
    where SubmFileId = @submFileId

	update WidSubmGroupWork
	set   
		  SubmFileId = null
		, RecWiaId = null
	where ObjId in (select ObjId from #ObjIds)
		and WidSubmGroupId = @GroupId

	update WidSubmGroupWorkName
	set RecAltId = null
	where ObjId in (select ObjId from #ObjIds)
		and WidSubmGroupId = @GroupId

	update WidSubmGroupWorkPerformer
	set RecPerId = null
	where ObjId in (select ObjId from #ObjIds)
		and WidSubmGroupId = @GroupId

	update WidSubmGroupWorkShare
	set 
		  RecSipId = null
		, RecSsrPerId = null
		, RecSsrMecId = null
		, RecOipId = null
		, RecOsrPerId = null
		, RecOsrMecId = null
	where ObjId in (select ObjId from #ObjIds)
		and WidSubmGroupId = @GroupId

	drop table if exists #ObjIds
end
go

-- exec spSubmFileClear 1
