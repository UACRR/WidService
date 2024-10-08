drop table if exists #MissingChanges

; with LastChanges as (
	select t3.Id as IpiNameNrId, max(t2.Id) as RecNcnId
	from UpdTrans t1
		join RecNcn t2 on t1.UpdFileId = t2.UpdFileId
			and t1.GrId = t2.GrId
			and t1.TransSeqNr = t2.TransSeqNr
		join IpiName t3 on t1.IpBaseNr = t3.IpBaseNr
			and cast(t2.IpNameNr as int) = t3.IpNameNr
	where t1.RecType = 'NCU'
	group by t3.Id
)
select 
	  t3.Id as RecNcnId
	, t2.Id as IpiNameNrId
into #MissingChanges
--select t2.Name, t3.Name, t2.FstName, t3.FstName, t2.NameType, t3.NameType
from LastChanges t1
	join IpiName t2 on t1.IpiNameNrId = t2.Id
	join RecNcn t3 on t1.RecNcnId = t3.Id
where not (t2.Name = t3.Name and t2.FstName = t3.FstName and t2.NameType = t3.NameType)

select t2.Name, t3.Name, t2.FstName, t3.FstName, t2.NameType, t3.NameType
from #MissingChanges t1
	join IpiName t2 on t1.IpiNameNrId = t2.Id
	join RecNcn t3 on t1.RecNcnId = t3.Id

update t2
set
	  t2.Name = t3.Name
	, t2.FstName = t3.FstName
	, t2.NameType = t3.NameType
from #MissingChanges t1
	join IpiName t2 on t1.IpiNameNrId = t2.Id
	join RecNcn t3 on t1.RecNcnId = t3.Id


