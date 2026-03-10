use SocWidSubmitEx
go

create or alter view vCurSubmWorks
as
select t1.*
from SubmWork t1
	join Submission t2 on t1.SubmissionId = t2.Id
where t2.EndedAt = dbo.fnMaxDate()

go

-- select * from vCurSubmWorks order by ObjId