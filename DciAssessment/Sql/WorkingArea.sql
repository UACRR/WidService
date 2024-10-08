select * from DciRepAssessment         
select * from DciRepCatField           
select * from DciRepCatSociety         
select * from DciRepCatValidation      
select * from DciRepCatValidationError 
select * from DciRepIntegritySnap      
select * from DciRepIntegritySnapDetail
select count(*) from DciRepWorkCatalog order by Author
select * from DciRepWork               
select * from DciRepIntegrityFailure   

select distinct Author 
into #Author
from DciRepWorkCatalog 
order by Author

select * from #Author order by Author

/*
drop table WorkAutoFouldWorks
select 
	  t2.ObjId as ObjId
	, t1.SocWorkCde as SocWorkCde
	, t1.Title as WidName
	, t1.Iswc as WidIswc
	, t1.Author as WidAuthor
	, t2.Author as LocalAuthor
into WorkAutoFouldWorks
from DciRepWorkCatalog t1
	join ObjectRightTr t2 on t1.Title = t2.Name
where trim(isnull(t1.Author, '')) <> ''
	and t2.Author like concat('%', t1.Author, '%')
order by t1.Author
*/
/*

drop table if exists DciWorkToObjId
select
	  WorkId as WorkId
	, 0 as Wic
	, SocWorkCde as SocWorkCde
	, Title as WidName
	, Iswc as WidIswc
	, Author as WidAuthor
	, 0 as ObjId
	, 0 as Status -- 0 - not processed, 1 - auto found 2 - manually found 3 - not found 4 - found from Smart
into DciWorkToObjId
from DciRepWorkCatalog

; with found as (
	select 
		  t1.WorkId as WorkId
		, t2.ObjId as ObjId
	from DciRepWorkCatalog t1
		join ObjectRightTr t2 on t1.Title = t2.Name
	where trim(isnull(t1.Author, '')) <> ''
		and t2.Author like concat('%', t1.Author, '%')
),
duplicate as (
	select ObjId, count(*) as Cnt
	from found
	group by ObjId
	having count(*) > 1
)
update t1
set t1.ObjId = t2.ObjId, t1.Status = 1
from DciWorkToObjId t1
	join found t2 on t1.WorkId = t2.WorkId
where t2.ObjId not in (select ObjId from duplicate)

; with OwnSubm as (
	select *
	from SocWid..WidSubmission
	where SocCde = 140
)
update t1
set t1.Wic = t2.Wic
from DciWorkToObjId t1
	left join OwnSubm t2 on t1.SocWorkCde = t2.SocWorkCde
where t2.Wic is not null

; with OwnSubm as (
	select *
	from SocWid..WidSubmission
	where SocCde = 140
)
update t1
set t1.Wic = t3.Wic
from DciWorkToObjId t1
	left join OwnSubm t2 on t1.SocWorkCde = t2.SocWorkCde
	join SocWid..WidIswc t3 on (t1.WidIswc = t3.Iswc)
where t2.Id is null

; with OwnSubm as (
	select *
	from SocWid..WidSubmission
	where SocCde = 140
)
update t1
set t1.Wic = t3.Wic
from DciWorkToObjId t1
	left join OwnSubm t2 on t1.SocWorkCde = t2.SocWorkCde
	join SocWid..WidIswc t3 on (t1.WidIswc = t3.PrefIswc)
where t2.Id is null

delete from DciWorkToObjId where Wic = 0

drop table if exists #DciWorkToObjId
select 
	  WorkId
	, Wic
	, SocWorkCde
	, replace(WidName, '''', '''''') as WidName
	, WidIswc
	, replace(WidAuthor, '''', '''''') as WidAuthor
	, ObjId
	, Status 
into #DciWorkToObjId
from DciWorkToObjId

select concat('insert DciWorkToObjId values ('
	, WorkId, ','
	, Wic, ','
	, SocWorkCde, ', '''
	, WidName, ''', '''
	, WidIswc, ''', '''
	, WidAuthor, ''','
	, ObjId, ','
	, Status, ')')
from #DciWorkToObjId


-- Виконувати при завантаженны форми
update t1
set t1.Status = 4, t1.ObjId = t2.ObjId
from DciWorkToObjId t1
	join SocWidSubmit..ObjIdToWic t2 on t1.Wic = t2.Wic
where t1.Status = 0
*/

declare @author varchar(100) = 'KHARCHYSHYN VALERII VOLODYMYROVYCH'
select distinct t1.WidAuthor
from DciWorkToObjId t1
	join SocWid..widIntrPty t2 on t1.Wic = t2.Wic
	join SocIpi..IpiName t3 on t2.IpNameNr = t3.IpNameNr
where concat(t3.Name, ' ', t3.FstName) = @author
order by t1.WidAuthor

select distinct WidAuthor from DciWorkToObjId order by WidAuthor

select top 1000
      t1.WorkId as WorkId
    , t1.objId	as ObjId
    , t1.WidName as WidName
    , t1.WidIswc as Iswc
    , t2.Name as LocalName
    , t2.Author as LocalAuthor
    , t2.Performer as LocalPerformer
	, t1.Status as Status
from DciWorkToObjId t1
    join MediaService..ObjectRight t2 on t1.ObjId = t2.ObjId
where t1.Status <> 0
	and t1.Author = @Author
order by t1.WidName

select * from MediaService..ObjectRight where name like '%стороною%'

select *
from DciRepWorkCatalog t1
	left join WorkAutoFouldWorks t2 on t1.SocWorkCde = t2.SocWorkCde
where t2.LocalCode is null



select *
from MediaService..ObjectRight
where name = 'метро' and author like 'харчишин%'

select *
from DciRepWorkCatalog
where title = 'metro' and author like 'kharchyshyn%'

INTRO:T9214308062
SUPERNATION:T9214308095
TRY KHVYLYNY:T9214306237
МЕТРО(METRO):T9214308175

select
	  t2.objId as SocWorkCde
	, t2.name as LocalName
	, t2.author as LocalAuthor
	, t2.performer as LocalPerformer
	, t1.Title	as WidName
	, t1.author as WidAuthor
	, t1.Iswc	as WidIswc
from DciRepWorkCatalog t1
	join MediaService..ObjectRight t2 on t2.ObjId = t1.SocWorkCde
order by t2.Author


; with OwnSubm as (
	select *
	from SocWid..WidSubmission
	where SocCde = 140
)
update t1
set t1.Wic = t3.Wic
from DciWorkToObjId t1
	left join OwnSubm t2 on t1.SocWorkCde = t2.SocWorkCde
	join SocWid..WidIswc t3 on (t1.WidIswc = t3.Iswc)
where t2.Id is null

; with OwnSubm as (
	select *
	from SocWid..WidSubmission
	where SocCde = 140
)
update t1
set t1.Wic = t3.Wic
from DciWorkToObjId t1
	left join OwnSubm t2 on t1.SocWorkCde = t2.SocWorkCde
	join SocWid..WidIswc t3 on (t1.WidIswc = t3.PrefIswc)
where t2.Id is null