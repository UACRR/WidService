use MediaSericeDataFix
go

create or alter function fnCheckIpBaseNrFormat (
	@ipBaseNr varchar(max)
)
returns int
as
begin
	if @ipBaseNr is null return 0
	if trim(@ipBaseNr) not like @ipBaseNr return 1
	if @ipBaseNr = '' return 0
	if len(@ipBaseNr) <> 13 return 2
	if substring(@ipBaseNr, 1, 1) <> 'I' return 3
	if substring(@ipBaseNr, 2, 1) <> '-' return 4
	if substring(@ipBaseNr, 12, 1) <> '-' return 5
	if try_cast(substring(@ipBaseNr, 13, 1) as int) is null return 6
	if try_cast(substring(@ipBaseNr, 3, 9) as int) = null return 7
	return 0
end
go

--select dbo.fnCheckIpBaseNrFormat('I-000322584-9')
