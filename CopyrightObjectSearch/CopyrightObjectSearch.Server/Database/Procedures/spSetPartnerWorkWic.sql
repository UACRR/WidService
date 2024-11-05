use CopyrightObjectSearch
go

create or alter procedure spSetPartnerWorkWic
	@partnerWorkId int, @wic int
as
begin

-- —кидаЇмо коди в нуль
	if @wic = 0
	begin
		update PartnerWorks
		set FoundObjId = 0, FoundWic = 0, FoundIswc = ''
		where Id = @partnerWorkId
		return
	end

	-- ѕерев≥р€Їмо ≥снуванн€ твору
	if (select wic from SocWid..WidTitle where Wic = @wic) is null
	begin
		return
	end

	-- «м≥нюЇмо код WID
	update PartnerWorks
	set FoundWic = @wic
	where Id = @partnerWorkId

	-- «м≥нюЇмо код —ћј–“
	update t1
	set t1.FoundObjId = isnull(t2.objId, 0)
	from PartnerWorks t1
		left join MediaService..RepMSWIC t2 on t1.FoundWic = t2.wic
	where t1.Id = @partnerWorkId
		and t1.FoundWic = @wic

	-- «м≥нюЇмо код ISWC
	update t1
	set t1.FoundIswc = isnull(t2.PrefIswc, '')
	from PartnerWorks t1
		left join SocWid..WidIswc t2 on t1.FoundWic = t2.wic
	where t1.Id = @partnerWorkId
		and t1.FoundWic = @wic


end
go

