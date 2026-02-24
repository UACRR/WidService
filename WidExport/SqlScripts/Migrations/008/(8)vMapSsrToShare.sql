use SocWidSubmit
go

create or alter view vMapSsrToShare
as
select t0.Id as RecSsrId, t5.Id as WidSubmGroupWorkShare
from RecSsr t0
	join RecSip t1 on
		    t0.TransSeqNr	= t1.TransSeqNr
		and t0.GrpSeqNr		= t1.GrpSeqNr
		and t0.SubmFileId	= t1.SubmFileId
		and t1.RecSeqNr		= case when t0.RecType = 'PER' then t0.RecSeqNr - 1 else t0.RecSeqNr - 2 end
	join RecWia t2 on							 
		    t1.TransSeqNr = t2.TransSeqNr
		and t1.GrpSeqNr = t2.GrpSeqNr
		and t1.SubmFileId = t2.SubmFileId
	join SubmFile t3 on t2.SubmFileId = t3.Id	 
	join WidSubmGroupWork t4 on					 
		    t2.SubmWrkNr = concat('MS', t4.ObjId)
		and t3.WidSubmGroupId = t4.WidSubmGroupId
	join WidSubmGroupWorkShare t5 on
		    t4.ObjId = t5.ObjId
		and t4.WidSubmGroupId = t5.WidSubmGroupId
		and t1.IpNr = t5.CustId
		and t1.IpRole = dbo.fnGetWidRole(t5.RhType, t5.RhRole)
go