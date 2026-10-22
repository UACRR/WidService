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
	
	-- Додаємо запис в перелік файлів, якщо такий перелік порожній
	if not exists (select null from CwrPartnerFiles)
	begin
		insert CwrPartnerFiles (PartnerId, PeriodId, Name, Status, CreatedAt)
		values (
			  @partnerId
			, (select Id from Periods where PeriodType = @periodTypeId and getdate() between StartDate and EndDate)
			, ''
			, 1
			, getdate()
		)
	end

	-- Додаємо записи в перелік файлів до дати наступного періоду від поточної дати
	
	declare @periodId int = (
		select top 1 t1.PeriodId
		from CwrPartnerFiles t1
			join Periods t2 on t1.PeriodId = t2.Id
		where PartnerId = @partnerId
		order by t2.StartDate desc
	)

	declare @lastPeriodEndDate date = (select EndDate from Periods where Id = @periodId)
	declare @curPeriodStartDate date = (
		select EndDate
		from Periods
	    where getdate() between StartDate and EndDate
			and PeriodType = @periodTypeId
	)

	declare @targetPeriodStartDate date = dateadd(dd, 1, @curPeriodStartDate)
	
	insert CwrPartnerFiles (PartnerId, PeriodId, Name, Status, CreatedAt)
	select @partnerId, Id, '', 1, getdate() 
	from Periods
	where StartDate between @lastPeriodEndDate and @targetPeriodStartDate
		and PeriodType = @periodTypeId
end
go

-- exec spPlanPartnerDeliveries 1