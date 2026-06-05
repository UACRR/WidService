use CWR
go

create or alter function fnCheckRoleDefined
(
	@customerType int, @creativeRoleCode int
)
returns bit
as
begin
	return case
		when dbo.fnGetCwrRole(@customerType, @creativeRoleCode) = ''
		then 0
		else 1
	end

end
go

-- select dbo.fnCheckRoleDefined(1, 9)

