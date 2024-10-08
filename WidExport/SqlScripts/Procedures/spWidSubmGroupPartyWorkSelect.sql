use SocWidSubmit
go

create or alter procedure spWidSubmGroupPartyWorkSelect
	  @WidSubmGroupId int
	, @IpNameNr int
	, @status int
as
begin
	if @status is null
	begin
	if @IpNameNr = 0
		select
			  t2.Id
			, t1.objId
			, t1.name
			, t1.performer
			, t2.Status
			, t3.Wic
			, t3.Iswc
			, t2.ShouldResubmit
			, t2.ReSubmitIswc
		from MediaService..ObjectRight t1
			join SocWidSubmit..WidSubmGroupWork t2 on t1.objId = t2.ObjId
			left join SocWidSubmit..ObjIdToWic t3 on t1.objId = t3.ObjId
		where t2.WidSubmGroupId = @WidSubmGroupId
		order by t1.name
	else
		select
			  t3.Id
			, t1.objId
			, t1.name
			, t1.performer
			, t3.Status
			, t4.Wic
			, t4.Iswc
			, t3.ShouldResubmit
			, t3.ReSubmitIswc
		from MediaService..ObjectRight t1
			join SocWidSubmit..WidSubmGroupPartyWork t2 on t1.objId = t2.ObjId
			join SocWidSubmit..WidSubmGroupWork t3 on t2.objId = t3.ObjId
			left join SocWidSubmit..ObjIdToWic t4 on t1.objId = t4.ObjId
		where t2.WidSubmGroupId = @WidSubmGroupId
			and t2.IpNameNr = @IpNameNr
		order by t1.name
	end
	else
	begin
	if @IpNameNr = 0
		select
			  t2.Id
			, t1.objId
			, t1.name
			, t1.performer
			, t2.Status
			, t3.Wic
			, t3.Iswc
			, t2.ShouldResubmit
			, t2.ReSubmitIswc
		from MediaService..ObjectRight t1
			join SocWidSubmit..WidSubmGroupWork t2 on t1.objId = t2.ObjId
			left join SocWidSubmit..ObjIdToWic t3 on t1.objId = t3.ObjId
		where t2.WidSubmGroupId = @WidSubmGroupId
			and t2.Status = @status
		order by t1.name
	else
		select
			  t3.Id
			, t1.objId
			, t1.name
			, t1.performer
			, t3.Status
			, t4.Wic
			, t4.Iswc
			, t3.ShouldResubmit
			, t3.ReSubmitIswc
		from MediaService..ObjectRight t1
			join SocWidSubmit..WidSubmGroupPartyWork t2 on t1.objId = t2.ObjId
			join SocWidSubmit..WidSubmGroupWork t3 on t2.objId = t3.ObjId
			left join SocWidSubmit..ObjIdToWic t4 on t1.objId = t4.ObjId
		where t2.WidSubmGroupId = @WidSubmGroupId
			and t2.IpNameNr = @IpNameNr
			and t3.Status = @status
		order by t1.name
	end
end
go

-- spWidSubmGroupSelect
