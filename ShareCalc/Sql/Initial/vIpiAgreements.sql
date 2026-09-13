use MediaService
go

create or alter procedure spProcessIpiAgreements
as

drop table if exists ShareCalc..IpiAgreeTerr
select t1.IpAgreeNr
	, string_agg(concat(t2.IncExcInd, t2.TisNr), ' ') as Terr
into ShareCalc..IpiAgreeTerr
from SocIpi..IpiAgreement t1
	join SocIpi..IpiTerritory t2 on t1.IpAgreeNr = t2.IpAgreeNr
	join SocIpi..IpiStatus t3 on t1.IpBaseNr = t3.IpBaseNr
		and t3.SttCde in (1, 2)
		and t3.FromDt <= getdate()
where getdate() between t1.FromDt and t1.ToDt
	and t1.CreClsCde = 'MW'
	and t1.RgtCde in ('PR', 'MR')
	and t1.RolCde in ('LY', 'MC', 'EM')
group by t1.IpAgreeNr

drop table if exists ShareCalc..IpiAgreementsUkr
select *
into ShareCalc..IpiAgreementsUkr
from vIpiAgreements
where IsUkraine = 0

select top 10000 * from ShareCalc..IpiAgreeTerr where IsUkraine = 0


