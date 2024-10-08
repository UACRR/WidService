declare @subjectId int = 1302;

begin tran
begin try
	update t1 set t1.WidTaskStatusId = 3
	from WidTasks t1
		join WidTaskObjects t2 on t1.WidTaskObjectId = t2.Id
		join WidTaskSubjects t3 on t2.WidTaskSubjectId = t3.Id
	where t3.Id < @subjectId

	update t2 set t2.WidTaskStatusId = 3
	from WidTaskObjects t2
		join WidTaskSubjects t3 on t2.WidTaskSubjectId = t3.Id
	where t3.Id < @subjectId

	update t3 set t3.WidTaskStatusId = 3
	from WidTaskSubjects t3
	where t3.Id < @subjectId


	
	commit tran
end try
begin catch
	rollback tran
end catch

--select * from WidTaskSubjects order by Id