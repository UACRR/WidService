use Ddex
go

create or alter procedure spSelectRhExtras
	@ddexReportId int
as
begin

drop table if exists #RhZeroShr
; with RhZeroShr as (
	select distinct  CustId, IpBaseNr, PerSoc, MecSoc
	from Ddex..DdexReportAuthors
	where DdexReportId = @ddexReportId
		and isnull(PerSocShr, 0) = 0 
		and isnull(MecSocShr, 0) = 0
)
select t1.*, t2.FullName
into #RhZeroShr
from RhZeroShr t1
	join MediaService..vCustomerNameDetailed t2 on t1.CustId = t2.CustId
where t1.CustId is not null
union
select t1.*, trim(concat(t3.Name, ' ', t3.FstName)) as FullName
from RhZeroShr t1
	join SocIpi..IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
	join SocIpi..IpiName t3 on t1.IpBaseNr = t3.IpBaseNr
where t1.CustId is null

select
	  t1.CustId
	, t1.IpBaseNr
	, t1.FullName
	, concat(trim(t3.Name), ' (', t1.PerSoc, ')') as PerSoc
	, concat(trim(t3.Name), ' (', t1.MecSoc, ')') as MecSoc
	, (case when t2.IpBaseNr is null then '' else 'Y' end) as [Збираємо?]
from #RhZeroShr t1
	left join SocIpiEx..RhExtraPay t2 on t1.IpBaseNr = t2.IpBaseNr
	join SocIpi..DicSoc t3 on t1.PerSoc = t3.Cde
order by t1.FullName

end
go

-- exec spSelectRhExtras 1581

select *
	from Ddex..DdexReportAuthors
	where DdexReportId = 1581
		and CustId = 283471
