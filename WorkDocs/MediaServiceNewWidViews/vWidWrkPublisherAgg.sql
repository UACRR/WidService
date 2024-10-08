use MediaService
go

create or alter view vWidWrkPublisherAgg
as
with AuthorDistinct as (
	select 
		  t1.Wic												as Wic
		, substring(trim(concat(trim(t2.Name), ' ', trim(t2.FstName)))	
		  , 1, 254) as Name
	from SocWid..widIntrPty t1
		join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
	--where t1.IpRole in ('C', 'A', 'CA')
	where t1.IpRole = 'E'
)
select
	  Wic											 as Wic
	, string_agg(convert(varchar(max), Name), ', ')	 as Authors
from AuthorDistinct
group by Wic
go
