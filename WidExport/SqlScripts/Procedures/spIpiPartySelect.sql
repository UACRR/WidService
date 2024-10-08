use SocWidSubmit
go

create or alter procedure spIpiPartySelect
	@nameStart varchar(100)
as
begin
declare @filter varchar(102)
if trim(@nameStart) = ''
	return
else
	set @filter= @nameStart

drop table if exists #Parties
; with IpBaseNumbers as (
	select distinct IpBaseNr
	from SocIpi..IpiName
	where Name like @filter
)
select top 100 
	  t1.IpBaseNr													as IpBaseNr
	, case when t2.NameType = 'PA' then t2.IpNameNr else null end	as MainIpNameNr
	, case when t2.NameType = 'PA' then t2.Name else null end		as MainName
	, case when t2.NameType = 'PA' then t2.FstName else null end	as MainFstName
	, case when t2.NameType <> 'PA' then t2.IpNameNr else null end	as FoundIpNameNr
	, case when t2.NameType <> 'PA' then t2.Name else null end		as FoundName
	, case when t2.NameType <> 'PA' then t2.FstName else null end	as FoundFstName
into #Parties
from IpBaseNumbers t1
	join SocIpi..IpiName t2 on t1.IpBaseNr = t2.IpBaseNr
		and t2.Name like @filter
		
update t1
set
	  t1.MainIpNameNr = t2.IpNameNr
	, t1.MainName = t2.Name
	, t1.MainFstName = t2.FstName
from #Parties t1
	join SocIpi..IpiName t2 on t1.IpBaseNr = t2.IpBaseNr
		and t2.NameType = 'PA'
where t1.MainIpNameNr is null

; with DuplcateIpBaseNr as (
	select IpBaseNr
	from #Parties
	group by IpBaseNr
	having count(*) > 1
)
delete t1
from #Parties t1
	join DuplcateIpBaseNr t2 on t1.IpBaseNr = t2.IpBaseNr
where t1.FoundIpNameNr is not null

select
	  IpBaseNr
	, MainIpNameNr
	, MainName
	, MainFstName
	, FoundIpNameNr
	, FoundName
	, FoundFstName
from  #Parties
order by MainName

drop table #Parties

end
go

-- exec spIpiPartySelect 'KHARCHYSH'
