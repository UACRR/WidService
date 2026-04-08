use SocWidSubmitEx
go

create or alter view vCurForeignRightHolder
as
select *
from RightHolder
where ValidTo = dbo.fnMaxDate()
	and IsOwn = 0
go

