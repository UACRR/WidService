drop table if exists ForeignRightHolders
select t1.*
into ForeignRightHolders
from RightHolderFixed t1
	left join MediaService..AgreementAddRh t2 on t1.CustId = t2.CustId
where IpBaseNrNew is null
	and t2.CustId is null

drop table if exists #Used
select distinct t1.CustId, t3.shortName
into #Used
from ForeignRightHolders t1
	join MediaService..RegisterCCIDAuthor t2 on t1.CustId = t2.CustId
	join MediaService..vCustomerNamesShort t3 on t1.CustId = t3.CustId
where t2.cmCodePER is not null or t2.cmCodeMEC is not null
order by t3.shortName


drop table if exists #Unused
select distinct t1.CustId, t3.shortName
into #Unused
from ForeignRightHolders t1
	left join #Used t2 on t1.CustId = t2.CustId
	join MediaService..vCustomerNamesShort t3 on t1.CustId = t3.CustId
where t2.CustId is null
order by t3.shortName

select *
from #Unused
where CustId = 3874

select * from MediaService..Account where CustId = 3874
