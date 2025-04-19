drop table if exists #CheckInfoFromWorkBook
; with NoDup as (
	select
		  row_number() over(partition by Name, Performers order by CheckValue desc ) as SeqNr
		, Name
		, Performers
		, CheckValue
	from CheckInfoFromWorkBook
	where Name <> ''
)
select Name, Performers, CheckValue
into #CheckInfoFromWorkBook
from NoDup
where SeqNr = 1

update t2
set t2.CheckValue = t1.CheckValue
from #CheckInfoFromWorkBook t1
	join Works t2 on t1.Name = t2.Name and t1.Performers = t2.Performers

insert Works (
        Name			
      , Authors
      , Performers
      , NameT
      , AuthorsT
      , PerformersT
      , FoundIn
      , ObjId
      , Wic
      , Iswc
      , Share
      , IsProcessed
      , CheckValue
)
select
        t1.Name													as Name			
      , ''														as Authors
      , t1.Performers											as Performers
      , MediaService.dbo.TransLitFromUkrToLat(t1.Name)			as NameT
      , ''														as AuthorsT
      , MediaService.dbo.TransLitFromUkrToLat(t1.Performers)	as PerformersT
      , null													as FoundIn
      , null													as ObjId
      , null													as Wic
      , null													as Iswc
      , null													as Share
      , 1 														as IsProcessed
      , t1.CheckValue											as CheckValue
from #CheckInfoFromWorkBook t1
	left join Works t2 on t1.Name = t2.Name and t1.Performers = t2.Performers
where t2.Id is null

update Works
set
	  Authors = ''
	, AuthorsT = ''
	, NameT = MediaService.dbo.TransLitFromUkrToLat(Name)
	, PerformersT = MediaService.dbo.TransLitFromUkrToLat(Performers)

update Works set CheckValue = 100 where CheckValue > 0
update Works set CheckValue = 100 where Share > 0 and (CheckValue = 0 or CheckValue is null)
update Works set CheckValue = 0 where Share = 0 and (CheckValue = 100 or CheckValue is null)
