select *
from RecSip t1									 -- 6975
	join RecWia t2 on							 -- 6975
		    t1.TransSeqNr = t2.TransSeqNr
		and t1.GrpSeqNr = t2.GrpSeqNr
		and t1.SubmFileId = t2.SubmFileId
	join SubmFile t3 on t2.SubmFileId = t3.Id	 -- 6975
	join WidSubmGroupWork t4 on					 -- 6975
		    t2.SubmWrkNr = concat('MS', t4.ObjId)
		and t3.WidSubmGroupId = t4.WidSubmGroupId
	join WidSubmGroupWorkShare t5 on
		    t4.ObjId = t5.ObjId
		and t4.WidSubmGroupId = t5.WidSubmGroupId
		and t1.IpNr = t5.CustId
where t1.SubmFileId = 20078