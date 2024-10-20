-- IpBaseNrNew is copy of current records not affected after latest dump
drop table if exists #IpBaseNrsToAnalyse
select IpBaseNr
into #IpBaseNrsToAnalyse
from SocIpi..IpiBase

drop table if exists #IpBaseNrsUpdatedAfterDUmp
select IpBaseNr
into #IpBaseNrsUpdatedAfterDUmp
from SocIpi..UpdTrans 
where TransD >= datefromparts(2024, 8, 31)

delete t1
from #IpBaseNrsToAnalyse t1
	join #IpBaseNrsUpdatedAfterDUmp t2 on t1.IpBaseNr = t2.IpBaseNr

drop table #IpBaseNrsUpdatedAfterDUmp

drop table if exists IpiBaseCur
select t1.*
into IpiBaseCur
from SocIpi..IpiBase t1
	join #IpBaseNrsToAnalyse t2 on t1.IpBaseNr = t2.IpBaseNr

drop table #IpBaseNrsToAnalyse

create unique index idxIpiBase_IpBaseNr on IpiBase (IpBaseNr);
create unique index idxIpiBaseCur_IpBaseNr on IpiBaseCur (IpBaseNr);