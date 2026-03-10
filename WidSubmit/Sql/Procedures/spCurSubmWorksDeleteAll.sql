use SocWidSubmitEx
go


create or alter procedure spCurSubmWorksDeleteAll
as
begin

	delete t3 from SubmWork t2 join SubmWorkShare	 t3 on t2.Id = t3.SubmWorkId	where t2.SubmissionId = dbo.fnCurSubmId()
	delete t3 from SubmWork t2 join SubmWorkAltName   t3 on t2.Id = t3.SubmWorkId	where t2.SubmissionId = dbo.fnCurSubmId()
	delete t3 from SubmWork t2 join SubmWorkPerformer t3 on t2.Id = t3.SubmWorkId	where t2.SubmissionId = dbo.fnCurSubmId()
	delete from SubmWork where SubmissionId = dbo.fnCurSubmId()
end
go

-- exec spCurSubmWorksDeleteAll

