use SocWidSubmitEx
go

create or alter procedure spZ_CreateNoShrInfo
as
begin

drop table if exists Z_NoShrInfo
; with CustWorks as ( -- Активні автори товариства і їх проблемні твори
	select distinct t4.CustId, t1.ObjId
	from Z_CheckList t1
		join MediaService..CopyRight t2 on t1.ObjId = t2.ObjId
			and getdate() between t2.BeginDate and t2.EndDate
		join MediaService..RightHolder t3 on t2.CustId = t3.CustId
			and t3.AroundWord = 1
		join MediaService..AgreementAddRH t4 on t2.CustId = t4.CustId
			and t4.AgrStatus = 2 
	where t1.HasShare = 0
)
select
	  t1.CustId			as AuthorCode
	, t2.FullName			as AuthorName
	, t1.ObjId			as WorkCode
	, t3.Name			as WorkName
into Z_NoShrInfo
from CustWorks t1
	join MediaService..vCustomerNameDetailed t2 on t1.CustId = t2.CustId
	join MediaService..MediaTrack t3 on t1.ObjId = t3.ObjId
end
go
-- exec spZ_CreateNoShrInfo

-- select 
-- 	t1.AuthorCode
-- 	, t1.AuthorName
-- 	, WorkCode
-- 	, WorkName
-- 	, t3.CustId as CosAuthorCode
-- 	, t3.FullName as CoAuthorName
-- 	, t2.Rate
-- 	, t2.RateMech
-- 	, t2.RoleCode
-- 	, t2.Status
-- from Z_NoShrInfo t1
-- 	join MediaService..CopyRight t2 on t1.WorkCode = t2.ObjId
-- 		and getdate() between t2.BeginDate and t2.EndDate
-- 	join MediaService..vCustomerNameDetailed t3 on t2.CustId = t3.CustId
-- order by t1.AuthorName, WorkName
-- 
-- select distinct AuthorCode, AuthorName
-- from Z_NoShrInfo
-- order by AuthorName

