set transaction isolation level read uncommitted

select 
	  t1.Id as PeriodId
	, t1.WidDumpTs as PeriodStart
	, t2.Id as SubjectId
	, t21.Code as SubjectType
	, t2.Db as TargetDb
	, t3.Id as ObjectId
	, t3.ObjectInfo as ObjectInfo
	, t4.Id as TaskId
	, t41.Code as TaskType
	, t42.Code as TaskStatus
from WidUpdatePeriods t1
	join WidTaskSubjects t2 on t1.Id = t2.WidUpdatePeriodId
		join WidTaskSubjectTypes t21 on t2.WidTaskSubjectTypeId = t21.Id
	join WidTaskObjects t3 on t2.Id = t3.WidTaskSubjectId
	join WidTasks t4 on t3.Id = t4.WidTaskObjectId
		join WidTaskTypes t41 on t4.WidTaskTypeId = t41.Id
		join WidTaskStatuses t42 on t4.WidTaskStatusId = t42.Id
order by t4.ScheduledAt desc