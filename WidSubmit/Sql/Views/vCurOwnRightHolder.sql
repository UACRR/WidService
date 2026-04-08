use SocWidSubmitEx
go

create or alter view vCurOwnRightHolder
as
select *
from RightHolder
where ValidTo = dbo.fnMaxDate()
	and IsOwn = 1
go

