use SmartWorkSearch
go

-- Створюємо інформацію з WID
update t1
set 
	  t1.Name = left(t2.WrkTtl, 100)
	, t1.Authors = left(t3.Authors, 256)
	, t1.Performers = left(t4.Performers, 256)
from FoundWorks t1
	join SocWid..WidTitle t2 on t1.FoundCde = t2.Wic
	join MediaService..vWidAuthorAgg t3 on t2.Wic = t3.Wic
	join MediaService..vWidPerformerAgg t4 on t2.Wic = t4.Wic
where Name is null
	and t1.FoundIn = 'WID'

-- FROM DDEX
; with FromDdex as (
	select distinct
		  Wic as Wic
		, left(Title, 100) as Name
		, left(isnull(MusicAuthors, ''), 256) as Authors
		, left(isnull(Performers, ''), 256) as Performers
	from Ddex..DdexReportMwInfo
)
update t1
set 
	  t1.Name = t2.Name
	, t1.Authors = t2.Authors
	, t1.Performers = t2.Performers
from FoundWorks t1
	join FromDdex t2 on t1.FoundCde = t2.Wic
where t1.Name is null
	and t1.FoundIn = 'WID'

-- FROM MS
update t1
set 
	  t1.Name = left(t2.Name, 100)
	, t1.Authors = left(isnull(t2.author, ''), 256)
	, t1.Performers = left(isnull(t2.performer, ''), 256)
from FoundWorks t1
	join MediaService..ObjectRight t2 on t1.ObjId = t2.objId
where t1.Name is null

-- Якщо знайти не вдалось, скидаємо повязання
delete from FoundWorks
where Name is null

-- Обчислюємо рейти
truncate table SourceWorkRates

; with Rates as (
	select SourceWorkId, Rate from MsReportRows
	union
	select SourceWorkId, Rate from DdexReportRows
),
RatesAgg as (
select 
	  SourceWorkId
	, sum(Rate) as Rate
from Rates
group by SourceWorkId
)
insert SourceWorkRates (RateIdx, SourceWorkId, Rate)
select 
	  row_number() over(order by Rate desc) as RateIdx
	, SourceWorkId
	, Rate
from RatesAgg


/*

select *
from MediaService..ObjectRight
where ObjId = 892798

select * 
from MediaService..RegisterItem t1
	left join MediaService..ObjectRight t2 on t1.ObjId = t2.ObjId
where t1.ObjId = 896843
	and t2.objId is null
*/
