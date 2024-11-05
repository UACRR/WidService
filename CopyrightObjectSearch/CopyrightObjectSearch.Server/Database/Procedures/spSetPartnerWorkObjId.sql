use CopyrightObjectSearch
go

create or alter procedure spSetPartnerWorkObjId
	@partnerWorkId int, @objId int
as
begin
	
	-- —кидаЇмо коди в нуль
	if @objId = 0
	begin
		update PartnerWorks
		set FoundObjId = 0, FoundWic = 0, FoundIswc = ''
		where Id = @partnerWorkId

		print 'Return for 0'
		return
	end

	-- ѕерев≥р€Їмо ≥снуванн€ твору
	if (select objId from MediaService..ObjectRight where objId = @objId) is null
	begin
		print 'Return for not exists'
		return
	end

	-- «м≥нюЇмо код —ћј–“
	print '1'
	update PartnerWorks
	set FoundObjId = @objId
	where Id = @partnerWorkId

	-- «м≥нюЇмо код ¬≤ƒ
	print '2'
	update t1
	set t1.FoundWic = isnull(t2.Wic, 0)
	from PartnerWorks t1
		left join MediaService..RepMSWIC t2 on t1.FoundObjId = t2.ObjId
	where t1.Id = @partnerWorkId
		and t1.FoundObjId = @objId

	-- «м≥нюЇмо код ISWC
	print '3'
	update t1
	set t1.FoundIswc = isnull(t2.PrefIswc, '')
	from PartnerWorks t1
		left join SocWid..WidIswc t2 on t1.FoundWic = t2.wic
	where t1.Id = @partnerWorkId

end
go

-- exec spSetParnterWorkObjId

