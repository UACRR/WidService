use SocWidSubmit
go

create or alter procedure spSubmFileClearRecRefs
	@submFileId int
as
begin
	drop table if exists #ObjIds
    
	select cast(substring(SubmWrkNr, 3, 100) as int) as ObjId
	into #ObjIds
    from RecWia 
    where SubmFileId = @submFileId

	update WidSubmGroupWork
	set RecWiaId = null
	where ObjId in (select ObjId from #ObjIds)

	update WidSubmGroupWorkName
	set RecAltId = null
	where ObjId in (select ObjId from #ObjIds)

	update WidSubmGroupWorkPerformer
	set RecPerId = null
	where ObjId in (select ObjId from #ObjIds)

	update WidSubmGroupWorkShare
	set 
		  RecSipId = null
		, RecSsrPerId = null
		, RecSsrMecId = null
		, RecOipId = null
		, RecOsrPerId = null
		, RecOsrMecId = null
	where ObjId in (select ObjId from #ObjIds)

	update WidSubmGroupWork
	set 
		  SubmFileId = null
	where SubmFileId = @submFileId

	drop table if exists #ObjIds
end
go

-- exec spSubmFileClear 1
