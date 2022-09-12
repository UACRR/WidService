USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[spDeleteExceptionSet]    Script Date: 12.09.2022 13:08:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[spDeleteExceptionSet] @setCode int, @membersOnly bit
as
begin

delete t1
from ExceptionAdd t1
	join ExceptionMember t2 on t1.excId = t2.id
where t2.setCode = @setCode

delete ExceptionMember
where setCode = @setCode

if @membersOnly = 0
begin
	update DdexReport
	set setCode = null
	where setCode = @setCode

	delete ExceptionSet
	where setCode = @setCode
end
	
end

--exec spDeleteExceptionSet] @setCode int
GO

