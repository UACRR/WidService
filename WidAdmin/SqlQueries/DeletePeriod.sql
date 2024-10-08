declare @periodId int = 1004;

begin tran
begin try
	delete t1
	from WidTasks t1
		join WidTaskObjects t2 on t1.WidTaskObjectId = t2.Id
		join WidTaskSubjects t3 on t2.WidTaskSubjectId = t3.Id
		join WidUpdatePeriods t4 on t3.WidUpdatePeriodId = t4.Id
	where t4.Id = @periodId

	delete t2
	from WidTaskObjects t2
		join WidTaskSubjects t3 on t2.WidTaskSubjectId = t3.Id
		join WidUpdatePeriods t4 on t3.WidUpdatePeriodId = t4.Id
	where t4.Id = @periodId

	delete t3
	from WidTaskSubjects t3
		join WidUpdatePeriods t4 on t3.WidUpdatePeriodId = t4.Id
	where t4.Id = @periodId

	delete t4
	from WidUpdatePeriods t4
	where t4.Id = @periodId
	
	commit tran
end try
begin catch
	rollback tran
end catch
