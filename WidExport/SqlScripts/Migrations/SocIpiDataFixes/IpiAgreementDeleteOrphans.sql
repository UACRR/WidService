use SocIpi
go

drop table if exists #OrphanIpBaseNr
select t1.IpBaseNr
into #OrphanIpBaseNr
from IpiAgreement t1
	left join IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
where t2.Id is null

delete 
from IpiAgreement 
where IpBaseNr in (select distinct IpBaseNr from #OrphanIpBaseNr)
