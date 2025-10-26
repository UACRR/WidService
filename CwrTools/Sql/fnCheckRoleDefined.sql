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
		when @customerType = 3 and @creativeRoleCode = 8
			or
			@customerType = 1 and @creativeRoleCode in (1, 2, 7, 10)
		then 1
		else 0
	end

end
go

-- select dbo.fnCheckIswc('T1067522323')

