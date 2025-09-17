use CWR
go

create or alter function fnIsDateInInterval
(
	  @curDate datetime
	, @startDate datetime
	, @endDate datetime
)
returns bit
as
begin
	return case 
		when @curDate between 
			    isnull(@startDate, datefromparts(1900, 1, 1))
			and isnull(@endDate, datefromparts(3000, 1, 1)) 
		then 1 
		else 0 
	end

end
go

