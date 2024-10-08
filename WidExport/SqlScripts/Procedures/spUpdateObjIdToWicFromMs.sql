use SocWidSubmit
go

create or alter procedure spUpdateObjIdToWicFromMs
as
begin
	--truncate table SocWidSubmit..ObjIdToWic
	insert into SocWidSubmit..ObjIdToWic (ObjId, Wic, Iswc, Source)
	select ObjId, Wic, null, 1
	from MediaService..RepMSWIC
	where not exists (
		select null
		from SocWidSubmit..ObjIdToWic
		where MediaService..RepMSWIC.ObjId = SocWidSubmit..ObjIdToWic.ObjId
	)

	drop table if exists #ObjIdToIswc
	select ObjId, Iswc
	into #ObjIdToIswc
	from MediaService..MediaTrack
	where trim(isnull(iswc, '')) <> ''
		and not exists (
			select null
			from SocWidSubmit..ObjIdToWic
			where MediaService..MediaTrack.ObjId = SocWidSubmit..ObjIdToWic.ObjId
		)
	
	drop table if exists #ObjIdToWic
	select distinct t1.ObjId, t2.Wic, t1.iswc, 2 as source
	into #ObjIdToWic
	from #ObjIdToIswc t1
		join SocWid..WidIswc t2 on t1.Iswc = t2.Iswc
	union
	select distinct t1.ObjId, t2.Wic, t1.iswc, 2 as source
	from #ObjIdToIswc t1
		join SocWid..WidIswc t2 on t1.Iswc = t2.PrefIswc

	delete from #ObjIdToWic
	where ObjId in (
		select ObjId
		from #ObjIdToWic
		group by ObjId
		having count(*) > 1
	)
	
	insert into SocWidSubmit..ObjIdToWic (ObjId, Wic, Iswc, Source)
	select ObjId, Wic, Iswc, Source
	from #ObjIdToWic

	drop table if exists #ObjIdToIswc
	drop table if exists #ObjIdToWic

	update t1
	set t1.Iswc = t2.PrefIswc
	from SocWidSubmit..ObjIdToWic t1
		join SocWid..WidIswc t2 on t1.Wic = t2.Wic
	where isnull(t1.Iswc, '') = ''
		and isnull(t2.PrefIswc, '') <> ''
end
go

-- select * from SocWidSubmit..ObjIdToWic where isnull(Iswc, '') = ''
--exec spUpdateObjIdToWicFromMs

--select * from SocWid..WidIswc where Wic = 27210041
--select * from SocWid..WidTitle where Wic = 27210041
/*
select *
from SocWidSubmit..ObjIdToWic t1
	left join SocWid..WidIswc t2 on t1.Iswc = t2.Iswc
where isnull(t1.Iswc, '') <> ''
	and t2.Iswc is null
	*/