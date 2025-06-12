use MediaService
go

create or alter view vCisNetTextWriterAgg
as
with AuthorDistinct as (
	select 
		  t1.WorkCode											as WorkCode
		, trim(concat(trim(t2.FstName), ' ', trim(t2.Name)))	as Name
	from SocCisNet..WorkRightHolders t1
		join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
	where t1.IpRole in ('A', 'CA')
)
select
	  WorkCode										 as WorkCode
	, string_agg(convert(varchar(max), Name), ', ')	 as TextWriters
from AuthorDistinct
group by WorkCode
go

-- select * from vCisNetAuthorAgg


