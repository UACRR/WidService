use SocWidAdmin

delete from [dbo].[WidTasks]
delete from [dbo].[WidTaskObjects]
delete from [dbo].[WidTaskSubjects]
delete from [dbo].[WidUpdatePeriods]

update WidTasks set WidTaskStatusId = 3
update WidUpdatePeriods set NewWidDumpTs = '2022-05-01'

select * from WidTasks order by ScheduledAt
select * from WidTaskObjects
select * from WidTaskSubjects
select * from WidUpdatePeriods

