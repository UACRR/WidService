--drop table if exists #MissingChanges

select 
	  t2.Id as RecNcnId
	, t3.Id as IpiNameNrId
--into #MissingChanges
from UpdTrans t1
	join RecNcn t2 on t1.UpdFileId = t2.UpdFileId
		and t1.GrId = t2.GrId
		and t1.TransSeqNr = t2.TransSeqNr
	left join IpiName t3 on t1.IpBaseNr = t3.IpBaseNr
		and cast(t2.IpNameNr as int) = t3.IpNameNr
where t1.RecType = 'NCA'
	and t3.Id is null