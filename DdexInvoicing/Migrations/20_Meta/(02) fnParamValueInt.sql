use DDEX
go

create or alter function fnParamValueInt
(
	@paramName nvarchar(64)
)
returns int
as
begin
	return cast((select session_context(@paramName)) as int)
end
go

