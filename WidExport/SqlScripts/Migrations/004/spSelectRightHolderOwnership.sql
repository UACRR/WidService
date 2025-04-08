use SocWidSubmit
go

create or alter procedure spSelectRightHolderOwnership
as
begin

; with TmpRightHolders  as (
	select distinct CustId
	from WidSubmGroupWorkShare
	where IpNameNr is not null
)
insert RightHolderOwnership (CustId, RightHolderOwnershipTypeId)
select t1.CustId, 'D'
from TmpRightHolders t1
	left join RightHolderOwnership t2 on t1.CustId = t2.CustId
where t2.CustId is null

; with TmpRightHolders  as (
	select t1.CustId, max(t2.IpBaseNr) as IpBaseNr, max(t2.IpNameNr) as IpNameNr, t1.RightHolderOwnershipTypeId
	from RightHolderOwnership t1
		join WidSubmGroupWorkShare t2 on t1.CustId = t2.CustId
	group by t1.CustId, t1.RightHolderOwnershipTypeId
)
select 
	  t1.CustId
	, t1.IpBaseNr
	, t1.IpNameNr
	, trim(concat(t2.Name, ' ', t2.FstName)) as Name
	, t1.RightHolderOwnershipTypeId
from TmpRightHolders t1
	join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr

end
go

-- exec spSelectRightHolderOwnership