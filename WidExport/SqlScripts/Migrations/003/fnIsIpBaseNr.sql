use SocWidSubmit
go

alter function fnIsIpBaseNr (
	@value nvarchar(max)
)
returns int
as
begin
	declare @valueTrimmed nvarchar(max) = trim(@value)
	if len(@valueTrimmed) <> 13
		return 1
	if substring(@valueTrimmed, 1, 2) <> 'I-'
		return 2
	if substring(@valueTrimmed, 12, 1) <> '-'
		return 3
	if isnumeric(substring(@valueTrimmed, 13, 1)) <> 1
		return 4
	if isnumeric(substring(@valueTrimmed, 3, 9)) <> 1
		return 5
	return 0
end
go

-- select dbo.fnIsIpBaseNr('I-002116905-9')
-- select substring('I-002116905-9', 3, 9)
--select isnumeric('0323')

