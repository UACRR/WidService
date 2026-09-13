use MediaService
go

create or alter view vIpiAgreementTerrs
as
select t1.IpAgreeNr
	, string_agg(concat(t2.IncExcInd, t2.TisNr), ' ') as Terr
from SocIpi..IpiAgreement t1
	join SocIpi..IpiTerritory t2 on t1.IpAgreeNr = t2.IpAgreeNr
	join SocIpi..IpiStatus t3 on t1.IpBaseNr = t3.IpBaseNr
		and t3.SttCde in (1, 2)
		and t3.FromDt <= getdate()
where getdate() between t1.FromDt and t1.ToDt
group by t1.IpAgreeNr
go