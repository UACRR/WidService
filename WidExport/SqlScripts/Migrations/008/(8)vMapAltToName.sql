use SocWidSubmit
go

create or alter view vMapAltToName
as
select t1.Id as RecAltId, t5.Id as WidSubmGroupWorkName
from RecAlt t1
		join RecWia t2 on							 
		    t1.TransSeqNr = t2.TransSeqNr
		and t1.GrpSeqNr = t2.GrpSeqNr
		and t1.SubmFileId = t2.SubmFileId
	join SubmFile t3 on t2.SubmFileId = t3.Id	 
	join WidSubmGroupWork t4 on					 
		    t2.SubmWrkNr = concat('MS', t4.ObjId)
		and t3.WidSubmGroupId = t4.WidSubmGroupId
	join WidSubmGroupWorkName t5 on
		    t4.ObjId = t5.ObjId
		and t4.WidSubmGroupId = t5.WidSubmGroupId
		and t1.AltTtl = t5.WidName
go