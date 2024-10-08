use SocWidSubmit
go

create or alter function fnGetRhRoleName
(
	  @rhRole int
)
returns nvarchar(100)
as
begin

declare @name nvarchar(100) = (
	select name
	from MediaService..CreativeRoleType
	where codeI = @rhRole
)

return case when @name is null then '' else @name end

end
go

-- select dbo.fnGetRhRoleName(1000)
