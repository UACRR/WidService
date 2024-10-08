use [RadioStationReports]
go

create or alter procedure spImportReport
	  @ReportId	int
as
begin
	drop table if exists #WorkData
	select 
		  t3.Id				as WorkId
		, t3.FoundIn		as FoundIn
		, t3.FoundCde		as FoundCde
		, t3.Iswc			as Iswc
		, t1.ObjId			as NewObjId
		, t1.Wic			as NewWic
		, t1.Iswc			as NewIswc
	into #WorkData
	from SearchFileImportBuf t1
		join ReportLines t2 on  t1.ReportId	= t2.ReportId 
							and t1.LineNr	= t2.LineNr
		join Works t3 on t2.WorkId = t3.Id
	where t1.ReportId = @ReportId

	-- Скидаємо старі значення
	update #WorkData 
	set 
		  FoundIn  = null
		, FoundCde = null
		, Iswc     = null

	--  Проставляємо посилання з ВІД
	update #WorkData 
	set 
		  FoundIn  = 'W'
		, FoundCde = NewWic 
	where NewWic <> 0

	--  Проставляємо посилання з СМАРТ
	update #WorkData 
	set 
		  FoundIn = 'M'
		, FoundCde = NewObjId 
	where NewObjId <> 0 
		and FoundIn is null

	--  Проставляємо Iswc
	update #WorkData 
	set Iswc = NewIswc 
	where NewIswc <> ''

	-- Якщо знайдено в Смарті, але відповідний обєкт існує в ВІД, замінюємо на ВІД
	update t1 
	set 
		  t1.FoundIn = 'W'
		, t1.FoundCde = t2.Wic
	from #WorkData t1
		join MediaService.. RepMSWIC t2 on t1.FoundCde = t2.objId
	where t1.FoundIn = 'M'

	-- Якщо не знайдено ніде шукаємо за кодом Iswc в ВІД
	update t1 
	set 
		  t1.FoundIn = 'W'
		, t1.FoundCde = t2.Wic
	from #WorkData t1
		join SocWid..WidIswc t2 on t1.Iswc = t2.PrefIswc

	-- select * from #WorkData

	-- Заносимо інформацію в постійну таблицю
	update t2
	set 
		  t2.FoundIn	= t1.FoundIn
		, t2.FoundCde	= t1.FoundCde
		, t2.Iswc		= t1.Iswc
	from #WorkData t1
		join Works t2 on t1.WorkId = t2.Id
end
go

-- exec spImportReport 12