drop table if exists #DupRightHolders
; with DupInterCodes as (
	select interCode as IpBaseNr
	from RightHolder
	where IsNull(interCode, '') <> ''
	group by interCode
	having count(*) > 1
)
select t2.*, t3.Name
into #DupRightHolders
from DupInterCodes t1
	join RightHolder t2 on t1.IpBaseNr = t2.interCode
	join vCustomerNames t3 on t2.custId = t3.custId

select *
from #DupRightHolders
order by InterCode

