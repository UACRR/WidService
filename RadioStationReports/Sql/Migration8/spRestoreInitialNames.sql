use MediaService
go

create or alter procedure spRestoreInitialNames
as
begin

drop table if exists #CustomerNames
select distinct CustId, Name
into #CustomerNames
from MediaService..vCustomerNameLastFirstSur

drop table if exists #AuthorNames
select distinct ObjId, CustId, AuthorName
into #AuthorNames
from MediaService..Authors

drop table if exists #ProblemAuthors
select t2.ObjId, t1.CustId, t1.Name as OrigName, t2.AuthorName
into #ProblemAuthors
from #CustomerNames t1
	join #AuthorNames t2 on t1.CustId = t2.CustId
where trim(t1.Name) <> trim(t2.authorName)
	and left(t1.Name, 1) <> left(t2.authorName, 1)
	and ascii(left(t1.Name, 1)) > 128
	and ascii(left(t2.authorName, 1)) < 128
	and left(t2.authorName, 1) <> '6'
	and t1.Name <> '√¿…ƒ¿… Ã»’¿…ÀŒ —≈–√≤…Œ¬»◊'
	and t1.CustId <> 293826
order by ObjId, CustId

drop table if exists #ChangePlan
; with NameDiff as (
	select
		  t1.ObjId
		, t1.CustId
		, t1.OrigName as OrigAuthorName
		, t1.authorName as CurAuthorName
		, t2.Name as CurWorkName
		, t3.Name as AltWorkName
		, row_number() over (partition by t1.ObjId, t1.CustId order by t3.Id) as SeqNr
	from #ProblemAuthors t1
		join ObjectRight t2 on t1.ObjId = t2.ObjId
		left join SeekObject t3 on t1.ObjId = t3.ObjId and t3.CodeI = 1
)
select *
into #ChangePlan
from NameDiff
where SeqNr = 1
order by ObjId

; with WorkNameChanges as (
	select distinct 
		  ObjId
		, AltWorkName
		, CurWorkName
	from #ChangePlan 
	where CurWorkName <> AltWorkName
		and ascii(left(AltWorkName, 1)) > 128
		and ascii(left(CurWorkName, 1)) < 128
)
--select *
update t1
set t1.Name = t2.AltWorkName
from ObjectRight t1
	join WorkNameChanges t2 on t1.ObjId = t2.ObjId
--

--select t2.*
update t1
set t1.authorName = t2.OrigAuthorName
from Authors t1
	join #ChangePlan t2 on t1.ObjId = t2.ObjId and t1.CustId = t2.CustId


end
go


-- exec spRestoreInitialNames