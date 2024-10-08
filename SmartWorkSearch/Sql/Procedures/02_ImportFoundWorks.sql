use SmartWorkSearch
go


-- >>>>>>>>>>>>>>>>>>>>>>>> REGISTER

--delete from SourceWorks where Source = 'Reg'
drop table if exists #RegItemsIds;

-- Записи для !! НЕ !! ДІДЕКС звітів
select t2.regId, t2.regIItemId
into #RegItemsIds
from MediaService..Register t1
	join MediaService..RegisterItem t2 on t1.regId = t2.regId
where t1.custId not in (281215, 281540, 39556)

; with FoundWorkSrc as (
	select 
		  t2.ItemName as Name
		, isnull(t2.AuthorMusic, '') as Authors
		, isnull(t2.Performer, '') as Performers
		, max(t2.ObjId) as ObjId -- тому самому означенню могли були поставлені у відповідь рызні твори
		, max(t2.Wic) as Wic -- тому самому означенню могли були поставлені у відповідь рызні твори
	from #RegItemsIds t1
		join MediaService..RegisterItem t2 on t1.regId = t2.regId and t1.regIItemId = t2.regIItemId
	where ObjId is not null or Wic is not null
	group by t2.ItemName, isnull(t2.AuthorMusic, ''), isnull(t2.Performer, '') 
)
insert into FoundWorks (
	  SourceWorkId
	, Name
	, Authors
	, Performers
	, FoundIn
	, FoundCde
	, ObjId
	, ValidFrom
	, ValidTo
	, CreatedAt
)
select
	  t2.Id as SourceWorkId
	, null as Name
	, null as Authors
	, null as Performers
	, case when t1.Wic is null then 'MS' else 'WID' end as FoundIn
	, case when t1.Wic is null then t1.ObjId else t1.Wic end as FoundCde
	, t1.ObjId as ObjId
	, datefromparts(1900, 1, 1) as ValidFrom
	, datefromparts(9999, 12, 31) as ValidTo
	, getdate() as CreatedAt
from FoundWorkSrc t1
	join SourceWorks t2 on t1.Name = t2.Name
		and isnull(t1.Authors, '') = t2.Authors
		and isnull(t1.Performers, '') = t2.Performers
		and t2.Iswc = ''
where not exists(
		select null from FoundWorks where SourceWorkId = t2.Id
	)
-- <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< REGISTER

-- >>>>>>>>>>>>>>>>>>>>>>>> DDEX
; with FoundWorkSrc as (
	select 
		  Title as Name
		, isnull(ComposerAuthor, '') as Authors
		, isnull(DisplayArtistName, '') as Performers
		, isnull(Iswc, '') as Iswc
		, max(ObjId) as ObjId -- тому самому означенню могли були поставлені у відповідь рызні твори
		, max(Wic) as Wic -- тому самому означенню могли були поставлені у відповідь рызні твори
	from Ddex..IdentMw
	where iif(ObjId = 0, null, ObjId) is not null or iif(Wic = 0, null, Wic) is not null
	group by Title, isnull(ComposerAuthor, ''), isnull(DisplayArtistName, '') , isnull(Iswc, '')
)


insert into FoundWorks (
	  SourceWorkId
	, Name
	, Authors
	, Performers
	, FoundIn
	, FoundCde
	, ObjId
	, ValidFrom
	, ValidTo
	, CreatedAt
)
select
	  t2.Id as SourceWorkId
	, null as Name
	, null as Authors
	, null as Performers
	, case when isnull(t1.Wic, 0) = 0 then 'MS' else 'WID' end as FoundIn
	, case 
			when isnull(t1.Wic, 0) = 0 
			then iif(t1.ObjId = 0, null, t1.ObjId) 
			else iif(t1.Wic = 0, null, t1.Wic) 
		end as FoundCde
	, iif(t1.ObjId = 0, null, t1.ObjId)  as ObjId
	, datefromparts(1900, 1, 1) as ValidFrom
	, datefromparts(9999, 12, 31) as ValidTo
	, getdate() as CreatedAt
from FoundWorkSrc t1
	join SourceWorks t2 on t1.Name = t2.Name
		and isnull(t1.Authors, '') = t2.Authors
		and isnull(t1.Performers, '') = t2.Performers
		and isnull(t1.Iswc, '') = t2.Iswc
where not exists(
		select null from FoundWorks where SourceWorkId = t2.Id
	)

-- <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< DDEX

update t1
set t1.ObjId = t2.ObjId
--select *
from FoundWorks t1
	join MediaService..RepMSWIC t2 on t1.FoundIn = 'WID' and t1.FoundCde = t2.Wic
where t1.ObjId is null

--delete from FoundWorks
/*
select *
from SourceWorks t1
	join FoundWorks t2 on t1.Id = t2.SourceWorkId
where t1.Id = 38410078
order by t1.Id

select count(*) from FoundWorks

select sourceworkid, count(*) from foundworks group by sourceworkid having count(*) > 1 order by count(*) desc

select * from Ddex..IdentMW where objid = 0

select t2.*
from Ddex..IdentMW t1
	join SourceWorks t2 on t1.Title = t2.Name
		and isnull(t1.ComposerAuthor, '') = t2.Authors
		and isnull(t1.DisplayArtistName, '') = t2.Performers
where t2.id = 31999030
*/
