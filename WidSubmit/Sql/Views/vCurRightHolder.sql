use SocWidSubmitEx
go

create or alter view vCurRightHolder
as
select *
from RightHolder
where ValidTo = dbo.fnMaxDate()
go

