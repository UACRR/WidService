use MediaService
go

drop view if exists vWidPublisherAgg
go

create view vWidPublisherAgg
as
with PublisherDistinct as (
	select 
		  t1.Wic												as Wic
		, trim(concat(trim(t2.FstName), ' ', trim(t2.Name)))	as Name
	from SocWid..widIntrPty t1
		join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
	where t1.IpRole = 'E'
)
select
	  Wic											 as Wic
	, string_agg(convert(varchar(max), Name), ', ')	 as Publishers
from PublisherDistinct
group by Wic
go

-- select top 100 * from vWidPublisherAgg