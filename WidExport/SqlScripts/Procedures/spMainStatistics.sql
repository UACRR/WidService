use SocWidSubmit
go

create or alter procedure spMainStatistics
as
begin
	declare @total int = (select count(*) from WidSubmGroupWork)

	declare @notProcessed int = (
		select count(*) 
		from WidSubmGroupWork
		where Status not in (0)
	)

	declare @needNotSubmit int = (
		select count(*) 
		from WidSubmGroupWork t1
			join ObjIdToWic t2 on t1.ObjId = t2.ObjId
		where isnull(t2.Iswc, '') <> ''
	)

	declare @submitted int = (
		select count(*) 
		from WidSubmGroupWork
		where Status not in (0, 1, 2, 3)
	)

	select
		  @total			as Total
		, @notProcessed		as NotProcessed
		, @needNotSubmit	as NeedNotSubmit
		, @submitted		as Submitted
end
go

-- spMainStatistics
