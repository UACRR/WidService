update MediaService..CopyRight
set BeginDate = datefromparts(1900, 1, 1)
where BeginDate is null

update MediaService..CopyRight
set EndDate = datefromparts(3000, 1, 1)
where EndDate is null


; with CoAuthors as (
	select distinct t1.CustId as CustIdAuthor, t3.CustId as CustIdCoAuthor
	from vMsRightHoldersActive t1
		join MediaService..CopyRight t2 on t1.CustId = t2.CustId
			and getdate() between t2.BeginDate and t2.EndDate
		join MediaService..CopyRight t3 on t2.ObjId = t3.ObjId
			and getdate() between t3.BeginDate and t3.EndDate
)
insert Z_LostIpiCodes
select
	  t3.CustId												as [Код правовласника]
	, t3.FullName											as [Назва правовласника]
	, t4.CustId												as [Код співавтора]
	, t4.FullName											as [Назва співавтора]
	, MediaService.dbo.ClrTranslitFromUkrToLat(t4.FullName) as [Назва співавтора транслітерована]
	, isnull(t5.InterCode, '')								as IpBaseNr
	, isnull(t5.IPIBase, '')								as IpNameNr
	, 0														as FoundIn
	, 0														as IsFinal
from CoAuthors t1
	join MediaService..RightHolder t2 on t1.CustIdCoAuthor = t2.CustId
	join MediaService..vCustomerNameDetailed t3 on t1.CustIdAuthor = t3.CustId
	join MediaService..vCustomerNameDetailed t4 on t1.CustIdCoAuthor = t4.CustId
	join MediaService..RightHolder t5 on t1.CustIdCoAuthor = t5.CustId
	left join Z_LostIpiCodes t6 on t3.CustId = t6.CustIdAuthor
		and t4.CustId = t6.CustIdCoAuthor
where (
		isnull(t2.InterCode, '') = ''
		or isnull(t2.IPIBase, '') = ''
	)
	and t6.CustIdAuthor is null
--order by t3.FullName


