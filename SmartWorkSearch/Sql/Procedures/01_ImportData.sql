use SmartWorkSearch
go


-- >>>>>>>>>>>>>>>>>>>>>>>> REGISTER

--delete from SourceWorks where Source = 'Reg'
drop table if exists #RegItemsIds

-- Записи для !! НЕ !! ДІДЕКС звітів
select t2.regId, t2.regIItemId
into #RegItemsIds
from MediaService..Register t1
	join MediaService..RegisterItem t2 on t1.regId = t2.regId
where t1.custId not in (281215, 281540, 39556)

-- Відсутні рядки
drop table if exists #MissingReportRows

select t1.RegId, t1.RegIItemId
into #MissingReportRows
from MediaService..RegisterItem t1
	join #RegItemsIds t2 on t1.regId = t2.regId and t1.regIItemId = t2.regIItemId
where not exists (
	select null
	from MsReportRows
	where t1.regId = regId
		and t1.regIItemId = regIItemId
	)


--declare @curDate as datetime = getdate()
-- УНІКАЛЬНІ ТВОРИ
insert into SourceWorks (
	  Name
	, Authors
	, Performers
	, Iswc
	, Source
	, CreatedAt
	, UpdatedAt
)
select distinct 
	  ItemName as Name
	, isnull(AuthorMusic, '') as Authors
	, isnull(Performer, '') as Performers
	, '' as Iswc
	, 'Reg' as Source
	, getdate() as CreatedAt
	, getdate() as UpdatedAt
from MediaService..RegisterItem t1
	join #MissingReportRows t2 on t1.regId = t2.regId and t1.regIItemId = t2.regIItemId
where not exists (
	select null
	from SourceWorks
	where t1.ItemName = Name
		and isnull(t1.AuthorMusic, '') = Authors
		and isnull(t1.Performer, '') = Performers
		and Iswc = ''
	)

--select count(*) from SourceWorks

-- Імпотруємо рядки і повязуємо з творами
insert MsReportRows
select t2.RegId as RegId
	, t2.regIItemId as regIItemId
	, isnull(t2.countUse, 0) as Rate
	, t3.Id as SourceWorkId
	, getdate() as CreatedAt
from #MissingReportRows t1
	join MediaService..RegisterItem t2 on t1.regId = t2.regId and t1.regIItemId = t2.regIItemId
	join SourceWorks t3 on t2.ItemName = t3.Name
		and isnull(t2.AuthorMusic, '') = t3.Authors
		and isnull(t2.Performer, '') = t3.Performers
		and t3.Iswc = ''


drop table #MissingReportRows
-- <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< REGISTER

-- >>>>>>>>>>>>>>>>>>>>>>>> DDEX
-- Відсутні рядки
drop table if exists #MissingReportRows1

select distinct t1.DdexReportId, t1.BlockId, t1.SalesTransactionId
into #MissingReportRows1
from Ddex..IdentBacklog t1
where not exists (
	select null
	from DdexReportRows
	where t1.DdexReportId = DdexReportId
		and t1.BlockId = BlockId
		and t1.SalesTransactionId = SalesTransactionId
	)


--declare @curDate as datetime = getdate()
-- УНІКАЛЬНІ ТВОРИ
insert into SourceWorks (
	  Name
	, Authors
	, Performers
	, Iswc
	, Source
	, CreatedAt
	, UpdatedAt
)
select distinct 
	  t3.Title as Name
	, isnull(t3.ComposerAuthor, '') as Authors
	, isnull(t3.DisplayArtistName, '') as Performers
	, isnull(t3.Iswc, '') as Iswc
	, 'Ddex' as Source
	, getdate() as CreatedAt
	, getdate() as UpdatedAt
from #MissingReportRows1 t1
	join Ddex..IdentBacklog t2 on t1.DdexReportId = t2.DdexReportId and t1.BlockId = t2.BlockId
	join Ddex..IdentMw t3 on t2.mwId = t3.id
where not exists (
	select null
	from SourceWorks
	where t3.Title = Name
		and isnull(t3.ComposerAuthor, '') = Authors
		and isnull(t3.DisplayArtistName, '') = Performers
		and isnull(t3.Iswc, '') = Iswc
	)

--select count(*) from SourceWorks

-- Імпотруємо рядки і повязуємо з творами
insert DdexReportRows
select t1.DdexReportId as DdexReportId
	, t1.BlockId as BlockId
	, t1.SalesTransactionId as SalesTransactionId
	, t2.Usages as Rate
	, t4.Id as SourceWorkId
	, getdate() as CreatedAt
from #MissingReportRows1 t1
	join Ddex..IdentBacklog t2 on t1.DdexReportId = t2.DdexReportId and t1.BlockId = t2.BlockId and t1.SalesTransactionId = t2.SalesTransactionId
	join Ddex..IdentMW t3 on t2.mwId = t3.id
	join SourceWorks t4 on t3.Title = t4.Name
		and isnull(t3.ComposerAuthor, '') = t4.Authors
		and isnull(t3.DisplayArtistName, '') = t4.Performers
		and isnull(t3.ISWC, '') = t4.Iswc

-- <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< DDEX
