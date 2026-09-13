select distinct t3.InterCode
from Z_ReportObjIds t1
	join MediaService..CopyRight t2 on t1.ObjId = t2.ObjId
	join MediaService..RightHolder t3 on t2.CustId = t3.CustId
where isnull(trim(t3.InterCode), '') <> ''

drop table if exists #RaoRightHolders
select *
into #RaoRightHolders
from RaoRightHolders
where isnull(InterCode, '') <> ''

drop table if exists #RhRaoIpiAgreements
select * --distinct t3.IpBaseNr
into #RhRaoIpiAgreements
from #RaoRightHolders t1
	left join SocIpi.. IpiAgreement t2 on t1.InterCode = t2.IpBaseNr
--		and t3.CreClsCde in ('PR', 'MR')
--		and t3.RgtCde = 'MW'
--		and SocCde = 94
where getdate() between t2.FromDt and t2.ToDt
order by t1.InterCode

; with NotRao as (
	select distinct CustId, FullName
	from #RhIpiAgreements
	where SocCde <> 94
),
Rao as (
	select distinct CustId, FullName
	from #RhIpiAgreements
	where SocCde = 94
)
select *
from NotRao t1 join Rao t2 on t1.CustId = t2.CustId
order by FullName

drop table if exists #RaoIpBaseNrs
select * --distinct t3.IpBaseNr
--into #RaoIpBaseNrs
from Shares t1
	join MediaService..RightHolder t2 on t1.CustId = t2.CustId
	left join SocIpi.. IpiAgreement t3 on t2.InterCode = t3.IpBaseNr
		and t3.CreClsCde in ('PR', 'MR')
		and t3.RgtCde = 'MW'
		and SocCde = 94
where isnull(t2.InterCode, '') <> ''
order by t3.IpBaseNr

select * 
from #RaoIpBaseNrs t1