use SocWidSubmitEx
go

create or alter procedure spIswcRejected
as
begin
	
	drop table if exists #IswcRejected
	select distinct t2.ObjId, cast(1 as bit) as ReSubmit
	into #IswcRejected
	from RecAck t1
		join MediaService..MediaTrack t2 on t1.SubmWrkNrRef = concat('MS', t2.ObjId)
	where Status in ('FA', 'PA')
		and t1.Iswc = ''
		and isnull(t2.Iswc, '') = ''

	delete t1
	from IswcRejected t1
		left join #IswcRejected t2 on t1.ObjId = t2.ObjId
	where t2.ObjId is null

	insert IswcRejected
	select t1.objId, 1
	from #IswcRejected t1
		left join IswcRejected t2 on t1.ObjId = t2.ObjId
	where t2.ObjId is null

	drop table if exists #IswcRejected
end
go
