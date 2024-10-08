use SocWidSubmit
go

create or alter procedure spWidSubmGroupChangedPerformersSelect
	@objId int
as
begin
; with TmpNew as (
	select *
	from WidSubmGroupWorkPerformer
	where dbo.fnIsChangesGroup(WidSubmGroupId) = 1
		and ObjId = @objId
),
TmpOld as (
	select *
	from WidSubmGroupWorkPerformer
	where dbo.fnIsSystemGroup(WidSubmGroupId) <> 1
		and ObjId = @objId
)
select 
      coalesce(t1.SeekObjectId, t2.SeekObjectId)
	, t1.WidSubmGroupId
	, t1.ObjId
	, t2.LocalName as OldName
	, t1.LocalName as NewName
from TmpNew t1
	full join TmpOld t2 on t1.SeekObjectId = t2.SeekObjectId
order by t1.SeekObjectId
end

-- exec spWidSubmGroupChangedPerformersSelect 894458