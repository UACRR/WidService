use RadioStationReports
go

create or alter function fnNormalizeName (
	@name nvarchar(max)
)
returns nvarchar(max)
as
begin
	--declare @name varchar(max) = 'MS. WORLDWIDE  '
	declare @curIdx int = 1
	declare @len int = len(@name)
	declare @curChar nchar
	declare @curCharCode int
	declare @ret nvarchar(max) = ''
	while @curIdx <= @len
	begin
		set @curChar = substring(@name, @curIdx, 1)
		set @curCharCode = ascii(@curChar)
		--print concat(@curChar, '(', @curCharCode, ')')
		if @curCharCode > 31 set @ret = @ret + @curChar
		set @curIdx = @curIdx + 1
	end
	--print @ret
	return trim(@ret)
end
go