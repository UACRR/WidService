CREATE view vRelObjPerformer as (
select t1.objid, t1.perId, t2.perName
 from RelObjPerformer t1 join Performer t2 on t1.perId = t2.perId
union
 select t1.objid, 0 as perId, t1.performers
 from  MediaTrack t1
)