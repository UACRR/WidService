use SocWidSubmit
go

create or alter procedure spWidSubmGroupClearRecRefs
	@groupId int
as
begin
	drop table if exists #ObjIds
    
	select ObjId
	into #ObjIds
    from WidSubmGroupWork 
    where WidSubmGroupId = @groupId 
        and (Status = 3 or ShouldResubmit = 1)

	update WidSubmGroupWork
	set RecWiaId = null
	where WidSubmGroupId = @groupId
		and ObjId in (select ObjId from #ObjIds)

	update WidSubmGroupWorkName
	set RecAltId = null
	where WidSubmGroupId = @groupId
		and ObjId in (select ObjId from #ObjIds)

	update WidSubmGroupWorkPerformer
	set RecPerId = null
	where WidSubmGroupId = @groupId
		and ObjId in (select ObjId from #ObjIds)

	update WidSubmGroupWorkShare
	set 
		  RecSipId = null
		, RecSsrPerId = null
		, RecSsrMecId = null
		, RecOipId = null
		, RecOsrPerId = null
		, RecOsrMecId = null
	where WidSubmGroupId = @groupId
		and ObjId in (select ObjId from #ObjIds)

	drop table if exists #ObjIds
end
go

-- exec spSubmFileClear 1
