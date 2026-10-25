use CWR
go

create or alter procedure spPlanPartnerDeliveries
	@partnerId int
as
begin

	-- Додаємо за потреби записи в таблицю періодів
	declare @curYear int = datepart(yyyy, getdate())
	declare @nextYear int = @curYear + 1
	exec spFillPeriods @nextYear

	-- Тип періода клієнта
	declare @periodTypeId int = (select PeriodType from Partners where Id = @partnerId)

	-- Створюємо перелік файлів для ПОТОЧНОГО року, якщо такий перелік порожній
	if not exists (
		select null
		from CwrPartnerFiles t1
			join Periods t2 on t1.PeriodId = t2.Id
		where t1.PartnerId = @partnerId
			and t2.Year = @curYear
	)
	begin
		insert CwrPartnerFiles (PartnerId, PeriodId, Name, Status, CreatedAt)
		select
			  @partnerId
			, Id
			, ''
			, 1
			, getdate()
		from Periods
		where PeriodType = @periodTypeId
			and Year = @curYear
	end

	-- Створюємо перелік файлів для НАСТУПНОГО року, якщо такий перелік порожній
	if not exists (
		select null
		from CwrPartnerFiles t1
			join Periods t2 on t1.PeriodId = t2.Id
		where t1.PartnerId = @partnerId
			and t2.Year = @nextYear
	)
	begin
		insert CwrPartnerFiles (PartnerId, PeriodId, Name, Status, CreatedAt)
		select
			  @partnerId
			, Id
			, ''
			, 1
			, getdate()
		from Periods
		where PeriodType = @periodTypeId
			and Year = @nextYear
	end

	-- Додаємо записи в перелік файлів до дати наступного періоду від поточної дати
	
	-- declare @periodId int = (
	-- 	select top 1 t1.PeriodId
	-- 	from CwrPartnerFiles t1
	-- 		join Periods t2 on t1.PeriodId = t2.Id
	-- 	where PartnerId = @partnerId
	-- 	order by t2.StartDate desc
	-- )
	-- 
	-- declare @lastPeriodEndDate date = (select EndDate from Periods where Id = @periodId)
	-- declare @curPeriodStartDate date = (
	-- 	select EndDate
	-- 	from Periods
	--     where getdate() between StartDate and EndDate
	-- 		and PeriodType = @periodTypeId
	-- )
	-- 
	-- declare @targetPeriodStartDate date = dateadd(dd, 1, @curPeriodStartDate)
	-- 
	-- insert CwrPartnerFiles (PartnerId, PeriodId, Name, Status, CreatedAt)
	-- select @partnerId, Id, '', 1, getdate() 
	-- from Periods
	-- where StartDate between @lastPeriodEndDate and @targetPeriodStartDate
	-- 	and PeriodType = @periodTypeId
end
go

-- exec spPlanPartnerDeliveries 1