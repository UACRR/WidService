use SocWidSubmitEx
go

create or alter view vLostIpNameNrs
as
select
	  t1.CustId															as CustId          
	, left(trim(t1.InterCode), 16)										as IpBaseNr        
	, left(MediaService.dbo.ClrTranslitFromUkrToLat(t2.FullName), 256)	as FullNameMs      
	, left(isnull(cast(t4.IpNameNr as varchar(16)), '')	, 16)			as IpNameNrFound  
	, left(trim(concat(t4.Name, ' ', t4.FstName)), 256)					as FullNameIpiFound
from MediaService.. RightHolder t1
	join MediaService..vCustomerNameDetailed t2 on t1.CustId = t2.CustId
	left join SocIpi..IpiBase t3 on trim(t1.InterCode) = t3.IpBaseNr
	left join SocIpi..IpiName t4 on t3.IpBaseNr = t4.IpBaseNr
		and t4.NameType = 'PA'
where isnull(InterCode, '') <> ''
	and isnull(IPIBase, '') = ''
go

-- select * from vLostIpNameNrs order by FullNameMs, CustId
-- select * into Z_LostIpNameNrs from vLostIpNameNrs order by FullNameMs, CustId