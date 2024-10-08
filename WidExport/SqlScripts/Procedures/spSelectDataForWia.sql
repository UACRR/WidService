use SocWidSubmit
go

create or alter procedure spSelectDataForWia
	  @groupId int
	, @objId int
as
begin
	select
		  t1.Id				as Id
		, t2.WidName		as WrkTtl
		, t1.ObjId			as SubmWrkNr
		, t1.ReSubmitIswc	as Iswc
	from WidSubmGroupWork t1
		join WidSubmGroupWorkName t2 on t1.WidSubmGroupId = t2.WidSubmGroupId
			and t1.ObjId = t2.ObjId
			and t2.IsMain = 1
	where t1.WidSubmGroupId = @groupId
		and t1.ObjId = @objId
end
go

-- exec spSelectDataForWia 2, 18
