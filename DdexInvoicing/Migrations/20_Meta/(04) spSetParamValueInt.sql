use DDEX
go

create or alter procedure spSetParamValueInt
(
	@paramName nvarchar(64), @paramValue int
)
as
begin
	exec sp_set_session_context @paramName, @paramValue
	print concat('Встановлено значення для параметру ',  @paramName, ' = ', dbo.fnParamValueFloat(@paramName));
end
go