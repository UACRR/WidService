CREATE view [dbo].[vTsk_1_BRMusic]
as 
select 
t3.rmId, t3.regId, t6.objId, t6.objName, t6.nameMusician, t6.nameSinger, t6.duration
from PaidPeriod t1 
join registerRatedList t4 on t4.periodId = t1.periodId
join register t3 on t3.rmId = t4.rmId 
join RegisterItem t5 on t5.regId = t3.regId and t5.codeItem = 2
join MusicalDesign t6 on t6.licId = t3.licId
join ObjectRight t7 on t7.objId = t6.objid