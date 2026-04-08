use SocWidSubmitEx
go

create or alter view vCurSubmRightHolder
as
select t1.*
from SubmRightHolder t1
	join Submission t2 on t1.SubmissionId = t2.Id
		and t2.EndedAt = datefromparts(9999, 12, 31)
go



