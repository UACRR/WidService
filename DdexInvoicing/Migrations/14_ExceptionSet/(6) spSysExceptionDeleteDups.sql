
create or alter procedure spSysExceptionDeleteDups
as
begin

/*
select setCode, memberName, count(*)
from ExceptionMember
where excType = 1
group by setCode, memberName
having count(*) > 1
order by MemberName
*/

; with #NoDup as (
	select setCode, memberName, max(Id) as Id
	from ExceptionMember
	where excType = 1
	group by setCode, memberName
)
delete t1 
-- select *
from ExceptionMember t1
	left join #NoDup t2 on t1.Id = t2.Id
where t1.excType = 1
	and t2.Id is null

end
go

exec spSysExceptionDeleteDups
go
