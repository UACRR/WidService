use SocWidSubmitEx
go

create or alter procedure spSubmPassIswcToMs
as
begin
	update t2
	set t2.Iswc = t1.Iswc
	from vCurSubmWorks t1
		join MediaService..MediaTrack t2 on t1.ObjId = t2.ObjId
	where isnull(t1.Iswc, '') <> ''
		and isnull(t2.Iswc, '') = ''
end
go

