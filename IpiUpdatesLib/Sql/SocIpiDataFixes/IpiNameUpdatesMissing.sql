use SocIpi
go

drop table if exists #MissingChanges

select 
	  t2.Id as RecNcnId
	, t3.Id as IpiNameNrId
into #MissingChanges
from UpdTrans t1
	join RecNcn t2 on t1.UpdFileId = t2.UpdFileId
		and t1.GrId = t2.GrId
		and t1.TransSeqNr = t2.TransSeqNr
	join IpiName t3 on t1.IpBaseNr = t3.IpBaseNr
		and cast(t2.IpNameNr as int) = t3.IpNameNr
where t1.RecType = 'NCU'
	and not (t2.Name = t3.Name and t2.FstName = t3.FstName and t2.NameType = t3.NameType)

drop table if exists #MissingChangesLast
select IpiNameNrId, max(RecNcnId) as RecNcnId
into #MissingChangesLast
from #MissingChanges
group by IpiNameNrId

-- 7580 => 7294
update t1
set 
	  t1.Name = t3.Name
	, t1.FstName = t3.FstName
	, t1.NameType = t3.NameType
--select *
from IpiName t1
	join #MissingChangesLast t2 on t1.Id = t2.IpiNameNrId
	join RecNcn t3 on t2.RecNcnId = t3.Id

