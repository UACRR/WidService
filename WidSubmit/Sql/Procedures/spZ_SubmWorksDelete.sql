use SocWidSubmitEx
go

create or alter procedure spZ_SubmWorksDelete
	  @objIds dbo.typeObjIds readonly
	, @keepWorks int
as
begin

	delete t3 from @objIds t1 join Z_SubmWork t2 on t1.ObjId = t2.ObjId join Z_SubmWorkHash	     t3 on t2.Id = t3.SubmWorkId
	delete t3 from @objIds t1 join Z_SubmWork t2 on t1.ObjId = t2.ObjId join Z_SubmWorkShare	 t3 on t2.Id = t3.SubmWorkId
	delete t3 from @objIds t1 join Z_SubmWork t2 on t1.ObjId = t2.ObjId join Z_SubmWorkAltName   t3 on t2.Id = t3.SubmWorkId
	delete t3 from @objIds t1 join Z_SubmWork t2 on t1.ObjId = t2.ObjId join Z_SubmWorkPerformer t3 on t2.Id = t3.SubmWorkId
	if @keepWorks = 0 delete t2 from @objIds t1 join Z_SubmWork t2 on t1.ObjId = t2.ObjId   
end
go
