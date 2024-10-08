use CopyrightObjectSearch
go

create or alter procedure spSetExternalObjectIswc
	@externalObjectId int, @iswc varchar(13)
as
begin
	update ExternalObjects
	set FoundIswc = @iswc
	where Id = @externalObjectId

	update t1
	set t1.FoundWic = isnull(t2.Wic, 0)
	from ExternalObjects t1
		left join SocWid..WidIswc t2 on t1.FoundIswc = t2.Iswc
	where t1.Id = @externalObjectId

	update t1
	set t1.FoundObjId = isnull(t2.objId, 0)
	from ExternalObjects t1
		left join MediaService..RepMSWIC t2 on t1.FoundWic = t2.wic
	where t1.Id = @externalObjectId

end
go

