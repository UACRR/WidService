use SocWidSubmitEx
go

create or alter procedure spZ_CreateLostIpiCodesDistinct
as
drop table if exists Z_LostIpiCodesDistinct
; with Temp as (
	select CustIdCoAuthor, min(t2.SeqNr) as SeqNr
	from Z_LostIpiCodes t1
		join Z_AuthorPrio t2 on t1.CustIdAuthor = t2.CustId
	group by CustIdCoAuthor
)
select t3.SeqNr, t1.CustIdCoAuthor, t1.FullNameCoAuthor, t1.FullNameCoAuthorTr, t1.IpBaseNr, t1.IpNameNr, t1.IsFinal
into Z_LostIpiCodesDistinct
from Z_LostIpiCodes t1
	join Z_AuthorPrio t2 on t1.CustIdAuthor = t2.CustId
	join Temp t3 on t2.SeqNr = t3.SeqNr
		and t1.CustIdCoAuthor = t3.CustIdCoAuthor

select *
from Z_LostIpiCodesDistinct
order by SeqNr

go

-- exec spZ_CreateLostIpiCodesDistinct
