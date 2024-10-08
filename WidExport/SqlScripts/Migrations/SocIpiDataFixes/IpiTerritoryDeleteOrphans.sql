use SocIpi
go

drop table if exists #OrphanIpAggreeNr
select t1.IpAgreeNr
into #OrphanIpAggreeNr
from IpiTerritory t1
	left join IpiAgreement t2 on t1.IpAgreeNr = t2.IpAgreeNr
where t2.Id is null

delete 
from IpiTerritory 
where IpAgreeNr in (select distinct IpAgreeNr from #OrphanIpAggreeNr)
