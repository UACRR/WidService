use DDEX
go

create or alter procedure spSetParamValueFloat
(
	@paramName nvarchar(64), @paramValue float
)
as
begin
	exec sp_set_session_context @paramName, @paramValue
	print concat('Встановлено значення для параметру ',  @paramName, ' = ', dbo.fnParamValueFloat(@paramName));
end
go