use SocCisNet
go

create or alter view vCisNetComposerAgg
as
with AuthorDistinct as (
	select 
		  t1.WorkId											 as WorkId
		, trim(concat(trim(t2.FstName), ' ', trim(t2.Name))) as Name
	from WorkShares t1
		join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
	where t1.IpRole in ('C', 'CA')
)
select
	  WorkId										 as WorkId
	, string_agg(convert(varchar(max), Name), ', ')	 as Composers
from AuthorDistinct
group by WorkId
go

-- select * from vCisNetComposerAgg


