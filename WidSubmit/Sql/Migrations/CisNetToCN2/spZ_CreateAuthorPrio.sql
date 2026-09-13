use SocWidSubmitEx
go

create or alter procedure spZ_CreateAuthorPrio
as

drop table if exists Z_AuthorPrio
select 0 as SeqNr, t1.CustId, t1.FullName, t2.DateBegin as AgrStartDate, 1 as Prio
into Z_AuthorPrio
from SocWidSubmitEx..Z_ImportantAuthors t1
	join MediaService..AgreementAddRH t2 on t1.CustId = t2.CustId 
union
select 0 as SeqNr, t3.CustId, t3.FullName, t2.DateBegin as AgrStartDate, 2 as Prio
from RightHolder t1
	join MediaService.. AgreementAddRH t2 on t1.CustId = t2.CustId
		and t2.agrStatus = 2
	join MediaService..vCustomerNameDetailed t3 on t1.CustId = t3.CustId
	left join SocWidSubmitEx..Z_ImportantAuthors t4 on t1.CustId = t4.CustId
where t4.CustId is null

; with Ordered as (
select row_number() over (order by Prio, AgrStartDate desc) as SeqNr, CustId
from Z_AuthorPrio
)
update t2
set t2.SeqNr = t1.SeqNr
from Ordered t1
	join Z_AuthorPrio t2 on t1.CustId = t2.CustId

update Z_AuthorPrio
set Prio = SeqNr / 20 + 1

go

-- exec spZ_CreateAuthorPrio
-- select * from Z_AuthorPrio order by SeqNr