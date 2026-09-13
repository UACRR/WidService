use SocWidSubmitEx
go

create or alter procedure spZ_CreateNoAuthorInfo
as
begin

drop table if exists Z_NoAuthorInfo
; with CustWorks as ( -- Активні автори товариства і їх проблемні твори
	select distinct t4.CustId, t1.ObjId
	from Z_CheckList t1
		join MediaService..CopyRight t2 on t1.ObjId = t2.ObjId
			and getdate() between t2.BeginDate and t2.EndDate
		join MediaService..RightHolder t3 on t2.CustId = t3.CustId
			and t3.AroundWord = 1
		join MediaService..AgreementAddRH t4 on t2.CustId = t4.CustId
			and t4.AgrStatus = 2 
	where t1.HasNonPublisher = 0
)
select
	  t1.CustId			as AuthorCode
	, t2.Name			as AuthorName
	, t1.ObjId			as WorkCode
	, t3.Name			as WorkName
into Z_NoAuthorInfo
from CustWorks t1
	join MediaService..vCustomerNameDetailed t2 on t1.CustId = t2.CustId
	join MediaService..MediaTrack t3 on t1.ObjId = t3.ObjId
end
go
-- exec spZ_CreateNoAuthorInfo

-- select distinct t1.AuthorCode, t1.AuthorName, WorkCode, WorkName, t2.CustId as CoAuthorCode, t2.AuthorName as CoAuthorName
-- from Z_NoAuthorInfo t1
-- 	join MediaService..Authors t2 on t1.WorkCode = t2.ObjId
-- order by t1.AuthorName, WorkName, t2.AuthorName
-- 
-- select distinct AuthorCode, AuthorName
-- from Z_NoAuthorInfo
-- order by AuthorName

