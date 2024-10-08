use SocIpi
go

drop table if exists #Dup
select IpAgreeNr, FromDt, ToDt, Shr, count(*) cnt
into #Dup
from IpiAgreement
group by IpAgreeNr, FromDt, ToDt, Shr
having count(*) > 1

drop table if exists #DupIds
select *
into #DupIds
from IpiAgreement
where IpAgreeNr in (select IpAgreeNr from #Dup)

drop table if exists #IdsToPreserve
select IpAgreeNr, max(Id) Id
into #IdsToPreserve
from #DupIds
group by IpAgreeNr

drop table if exists #IdsToRemove
select Id
into #IdsToRemove
from #DupIds
where Id not in (select Id from #IdsToPreserve)

delete from IpiAgreement where Id in (select Id from #IdsToRemove)

--drop table if exists #Dup
