declare @taskId int = 5428;

begin tran
begin try
	declare @taskSchediledDt datetime = (select ScheduledAt from WidTasks where Id = @taskId)
	update WidTasks set NextWidTaskId = null where Id = @taskId
	delete from WidTasks where ScheduledAt > @taskSchediledDt
	delete from WidTaskObjects where not exists(select null from WidTasks where WidTaskObjectId = WidTaskObjects.Id)
	delete from WidTaskSubjects where not exists(select null from WidTaskObjects where WidTaskSubjectId = WidTaskSubjects.Id)
	commit tran
end try
begin catch
	rollback tran
end catch
