use SocWidSubmitEx
go

create or alter function fnFullName(
	   @name nvarchar(256)
	,  @fstName varchar(256)
)

returns nvarchar(256)
as
begin
	return left(trim(concat(@name, ' ', @fstName)), 256)
end
go

