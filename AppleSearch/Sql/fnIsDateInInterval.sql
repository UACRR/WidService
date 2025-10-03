USE AppleMusic
GO

/****** Object:  UserDefinedFunction [dbo].[fnIsDateInInterval]    Script Date: 25.09.2025 13:17:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create   function [dbo].[fnIsDateInInterval]
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
GO


