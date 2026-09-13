use ShareCalc
go

drop table if exists UacrrLostWicRightHolders
; with IpBaseNrs as (
	select distinct t3.IpBaseNr
	from UacrrLostWics t1
		join SocWid..WidIntrPty t2 on t1.Wic = t2.Wic
		join SocIpi..IpiName t3 on t2.IpNameNr = t3.IpNameNr
	where t1.ObjId = 0
)
select distinct t1.IpBaseNr, t2.Name, t2.FstName, cast(t3.CustId as varchar(16)) as CustId, t4.LastName, t4.firstName, t4.SurName, '0' as IsProcessed
into UacrrLostWicRightHolders
from IpBaseNrs t1
	join SocIpi..IpiName t2 on t1.IpBaseNr = t2.IpBaseNr and t2.NameType = 'PA'
	left join MediaService..RightHolder t3 on t1.IpBaseNr = t3.InterCode
	left join MediaService..AnketaPerson t4 on t3.CustId = t4.CustId
--order by Name

drop table if exists UacrrRhNamesMs
create table UacrrRhNamesMs (
	  CustId int primary key
	, Name varchar(255)
	, FirstName varchar(255)
	, SurName varchar(255)
)

insert UacrrRhNamesMs
select CustId, trim(isnull(Name, '')), trim(isnull(FirstName, '')), trim(isnull(SurName, ''))
from MediaService..vCustomerNameDetailed

update UacrrRhNamesMs
set FirstName = MediaService.dbo.ClrGetFirstName(Name)
where FirstName = ''

update UacrrRhNamesMs
set SurName = MediaService.dbo.ClrGetSurName(Name)
where SurName = ''


