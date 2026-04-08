use SocWidSubmitEx
go

create or alter view vCurSubmRecWiaWiu
as
	select t2.SubmissionId, t3.RecHdrId, t3.GrId, t4.*
	from Submission t1
		join RecHdr t2 on t1.Id = t2.SubmissionId
		join RecGrh t3 on t2.Id = t3.RecHdrId
		join RecWiaWiu t4 on t3.Id = t4.RecGrhId
	where t1.Id = dbo.fnCurSubmId()
go

