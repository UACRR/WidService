use CWR
go

create or alter function fnCheckIswc
(
	@iswc varchar(max)
)
returns bit
as
begin
	if @iswc is null
		return 1

	if len(trim(@iswc)) = 0
		return 1

	if len(@iswc) <> 11
		return 0

	declare @curChar char(1) = substring(@iswc, 1, 1)
	if ascii(@curChar) <> ascii('T')
		return 0

	declare @idx int = 2
	while @idx <= 11
	begin
		set @curChar = substring(@iswc, @idx, 1)
		if ascii(@curChar) not between 48 and 57
			return 0
		set @idx = @idx + 1
	end

	return 1

end
go

-- select dbo.fnCheckIswc('T1067522323')

