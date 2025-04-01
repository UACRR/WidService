use [RadioStationReports]
go

create or alter procedure spInsertIswcs
	@ReportId int
as
begin
	
	-- Замінюємо посилання зі СМАРТУ на ВІД, де це можливо
	update t2
	set t2.FoundIn = 'W', t2.Wic = t3.Wic
	from ReportLines t1
		join Works t2 on t1.WorkId = t2.Id
		join MediaService..RepMSWIC t3 on t2.ObjId = t3.objId
		join SocWid..WIdTitle t4 on t3.WIc = t4.Wic -- Беремо лише вірні коди в ВІД
	where t1.ReportId = @ReportId
		and t2.FoundIn = 'M'
	
	-- Проставляємо ISWC

	update t2
	set t2.Iswc = trim(isnull(t3.PrefIswc, ''))
	from ReportLines t1
		join Works t2 on t1.WorkId = t2.Id
		left join SocWid..widIswc t3 on t2.Wic = t3.Wic
	where t1.ReportId = @ReportId
		and t2.FoundIn = 'W'

end
go

-- exec spInsertIswcs 54