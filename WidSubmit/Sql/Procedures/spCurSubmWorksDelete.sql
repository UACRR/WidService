use SocWidSubmitEx
go

create or alter procedure spCurSubmWorksDelete
	  @objIds dbo.typeObjIds readonly
	, @keepWorks int
as
begin

	delete t3 from @objIds t1 join SubmWork t2 on t1.ObjId = t2.ObjId join SubmWorkShare	 t3 on t2.Id = t3.SubmWorkId	where t2.SubmissionId = dbo.fnCurSubmId()
	delete t3 from @objIds t1 join SubmWork t2 on t1.ObjId = t2.ObjId join SubmWorkAltName   t3 on t2.Id = t3.SubmWorkId	where t2.SubmissionId = dbo.fnCurSubmId()
	delete t3 from @objIds t1 join SubmWork t2 on t1.ObjId = t2.ObjId join SubmWorkPerformer t3 on t2.Id = t3.SubmWorkId	where t2.SubmissionId = dbo.fnCurSubmId()
	if @keepWorks = 0 delete t2 from @objIds t1 join SubmWork t2 on t1.ObjId = t2.ObjId where t2.SubmissionId = dbo.fnCurSubmId()
end
go

