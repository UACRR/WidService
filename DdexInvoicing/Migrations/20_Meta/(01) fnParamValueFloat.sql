use DDEX
go

create or alter function fnParamValueFloat
(
	@paramName nvarchar(64)
)
returns float
as
begin
	return cast((select session_context(@paramName)) as float)
end
go

