use SocWidSubmitEx
go

create or alter view vCurSubmRecSsrOsr
as
	select t2.SubmissionId, t3.RecHdrId, t4.RecGrhId, t3.GrId, t5.RecWiaWiuId, t6.*
	from Submission t1
		join RecHdr t2 on t1.Id = t2.SubmissionId
		join RecGrh t3 on t2.Id = t3.RecHdrId
		join RecWiaWiu t4 on t3.Id = t4.RecGrhId
		join RecSipOip t5 on t4.Id = t5.RecWiaWiuId
		join RecSsrOsr t6 on t5.Id = t6.RecSipOipId
	where t1.Id = dbo.fnCurSubmId()
go

