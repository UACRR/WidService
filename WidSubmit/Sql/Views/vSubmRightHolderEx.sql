use SocWidSubmitEx
go

create or alter view vSubmRightHolderEx
as
with PublishedRightHolders as (
	select distinct RightHolderId from SubmRightHolder
)
select
	  t1.Id																				as Id		
	, t1.ValidFrom																		as ValidFrom	
	, t1.ValidTo																		as ValidTo	
	, t1.CreatedAt																		as CreatedAt	
	, t1.CustId																			as CustId	
	, t1.IpBaseNr																		as IpBaseNr	
	, t1.IpNameNr																		as IpNameNr	
	, t1.Name																			as Name
	, t1.FstName																		as FstName
	, t1.NameForWid																		as NameForWid
	, t1.FstNameForWid																	as FstNameForWid
	, t1.IsOwn																			as IsOwn
	, t1.IsActive																		as IsActive
	, t1.HasIpiAgreePer																	as HasIpiAgreePer
	, t1.HasIpiAgreeMec																	as HasIpiAgreeMec
	, case when t2.Id is null then cast(0 as bit) else cast(1 as bit) end 				as IsInCurSubm
	, case when t3.RightHolderId is null then cast(0 as bit) else cast(1 as bit) end	as WasPublished
	, t2.SubmissionId																	as SubmissionId
from RightHolder t1
	left join SubmRightHolder t2 on t1.Id = t2.RightHolderId
	left join PublishedRightHolders t3 on t1.Id = t3.RightHolderId
where t1.IsOwn = 1
go

-- select * from vCurSubmRightHolderEx

--select * from SubmRightHolder

-- select t2.* from vCurSubmRightHolder t1 join RightHolder t2 on t1.RightHolderId = t2.Id order by Name
-- 
-- select * from vCurSubmRightHolderEx where IsInCurSubm = 1 order by NAme
