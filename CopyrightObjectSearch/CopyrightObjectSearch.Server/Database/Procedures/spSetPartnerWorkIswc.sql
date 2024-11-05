use CopyrightObjectSearch
go

create or alter procedure spSetPartnerWorkIswc
	@partnerWorkId int, @iswc varchar(13)
as
begin
	update PartnerWorks
	set FoundIswc = @iswc
	where Id = @partnerWorkId

	update t1
	set t1.FoundWic = isnull(t2.Wic, 0)
	from PartnerWorks t1
		left join SocWid..WidIswc t2 on t1.FoundIswc = t2.Iswc
	where t1.Id = @partnerWorkId

	update t1
	set t1.FoundObjId = isnull(t2.objId, 0)
	from PartnerWorks t1
		left join MediaService..RepMSWIC t2 on t1.FoundWic = t2.wic
	where t1.Id = @partnerWorkId

end
go

