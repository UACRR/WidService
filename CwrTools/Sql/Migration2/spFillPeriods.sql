use CWR
go

create or alter procedure spFillPeriods
	@endYear int
as
begin
	declare @startYear int = (select max(Year) from Periods)
	if @startYear is null
		set @startYear = datepart(yyyy, getdate())
	else
		set @startYear = @startYear + 1

	declare @curYear int = @startYear
	declare @curMonth int

	while @curYear <= @endYear
	begin

		set @curMonth = 1
		while @curMonth <= 12
		begin
			insert Periods(PeriodType, Year,      Point,     StartDate,                             EndDate)
			values (                1, @curYear,  @curMonth, datefromparts(@curYear, @curMonth, 1), eomonth(datefromparts(@curYear, @curMonth, 1)))

			set @curMonth = @curMonth + 1
		end

		insert Periods(PeriodType, Year,      Point,     StartDate,                     EndDate)
		values (                2, @curYear,  1,		 datefromparts(@curYear, 1, 1),  eomonth(datefromparts(@curYear, 3, 1)))

		insert Periods(PeriodType, Year,      Point,     StartDate,                     EndDate)
		values (                2, @curYear,  2,		 datefromparts(@curYear, 4, 1),  eomonth(datefromparts(@curYear, 6, 1)))

		insert Periods(PeriodType, Year,      Point,     StartDate,                     EndDate)
		values (                2, @curYear,  3,		 datefromparts(@curYear, 7, 1),  eomonth(datefromparts(@curYear, 9, 1)))

		insert Periods(PeriodType, Year,      Point,     StartDate,                     EndDate)
		values (                2, @curYear,  4,		 datefromparts(@curYear, 10, 1),  eomonth(datefromparts(@curYear, 12, 1)))


		insert Periods(PeriodType, Year,      Point,     StartDate,                     EndDate)
		values (                3, @curYear,  1,		 datefromparts(@curYear, 1, 1),  eomonth(datefromparts(@curYear, 6, 1)))

		insert Periods(PeriodType, Year,      Point,     StartDate,                     EndDate)
		values (                3, @curYear,  2,		 datefromparts(@curYear, 7, 1),  eomonth(datefromparts(@curYear, 12, 1)))


		insert Periods(PeriodType, Year,      Point,     StartDate,                     EndDate)
		values (                4, @curYear,  1,		 datefromparts(@curYear, 1, 1),  eomonth(datefromparts(@curYear, 12, 1)))

		set @curYear = @curYear + 1
	end
end
go

-- truncate table Periods
-- exec spFillPeriods 2028
-- select * from Periods