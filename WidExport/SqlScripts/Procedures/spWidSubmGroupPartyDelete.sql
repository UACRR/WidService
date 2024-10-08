use SocWidSubmit
go

create or alter procedure spWidSubmGroupPartyDelete
	@IpNameNr as int
as
begin
	declare @WidSubmGroupId int = (select WidSubmGroupId from WidSubmGroupParty where IpNameNr = @IpNameNr)
	
	delete WidSubmGroupPartyWork 
	where WidSubmGroupId = @WidSubmGroupId
		and IpNameNr = @IpNameNr
	
	delete t1
	from WidSubmGroupWorkName t1
		left join WidSubmGroupPartyWork t2 on t1.ObjId = t2.ObjId
	where t1.WidSubmGroupId = @WidSubmGroupId
		and t2.ObjId is null

	delete t1
	from WidSubmGroupWorkPerformer t1
		left join WidSubmGroupPartyWork t2 on t1.ObjId = t2.ObjId
	where t1.WidSubmGroupId = @WidSubmGroupId
		and t2.ObjId is null

	delete t1
	from WidSubmGroupWorkShare t1
		left join WidSubmGroupPartyWork t2 on t1.ObjId = t2.ObjId
	where t1.WidSubmGroupId = @WidSubmGroupId
		and t2.ObjId is null

	delete t1
	from WidSubmGroupWorkCheckList t1
		left join WidSubmGroupPartyWork t2 on t1.ObjId = t2.ObjId
	where t1.WidSubmGroupId = @WidSubmGroupId
		and t2.ObjId is null

	delete t1
	from WidSubmGroupWork t1
		left join WidSubmGroupPartyWork t2 on t1.ObjId = t2.ObjId
	where t1.WidSubmGroupId = @WidSubmGroupId
		and t2.ObjId is null

	delete WidSubmGroupParty 
	where WidSubmGroupId = @WidSubmGroupId
		and IpNameNr = @IpNameNr

	drop table if exists #WorkIds
end
go

-- exec spWidSubmGroupPartyAdd 0, 'I-004509054-6', 829483205