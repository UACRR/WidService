-- Excesive IpiStatus = 1539 wrong, update files contains history lost in full dump
drop table if exists #Missing
select t1.*
into #Missing
from SocIpi_2024_06_01..IpiStatus t1
	left join SocIpi_2024_08_31..IpiStatus t2 on t1.IpBaseNr = t2.IpBaseNr
		and t1.FromDt = t2.FromDt
		and t1.ToDt = t2.ToDt
where t2.IpBaseNr is null
order by t1.IpBaseNr

select * from #Missing

select *
from UpdTrans t1
	join RecStn t2 on t1.UpdFileId = t2.UpdFileId and t1.GrId = t2.GrId and t1.TransSeqNr = t2.TransSeqNr
where IpBaseNr = 'I-000165090-2'--in (select IpBaseNr from #Missing)
	and t1.RecType in ('STA', 'STD')
order by IpBaseNr

select *
from SocIpi_2024_08_31..IpiStatus
where IpBaseNr = 'I-000165090-2'

drop table if exists #Missing
---------------------------------------------------------------------
-- Missing IpiStatus = 3, but those where deleted according to update transaction (STD)
drop table if exists #Missing
select t2.*
into #Missing
from SocIpi_2024_06_01..IpiStatus t1
	right join SocIpi_2024_08_31..IpiStatus t2 on t1.IpBaseNr = t2.IpBaseNr
		and t1.FromDt = t2.FromDt
		and t1.ToDt = t2.ToDt
where t1.IpBaseNr is null
order by t1.IpBaseNr

select * from #Missing

select * 
from UpdTrans 
where IpBaseNr in (select IpBaseNr from #Missing)
order by IpBaseNr
drop table if exists #Missing
-----------------------------------------------

--=================== Field by field
-- IpiStatus - OK
select top 10 * ---t2.IpAgreeNr, t1.Tisan as TisanOld, t2.Tisan as TisanNew
from SocIpi_2024_06_01..IpiStatus t1
	join SocIpi_2024_08_31..IpiStatus t2 on t1.IpBaseNr = t2.IpBaseNr
		and t1.FromDt = t2.FromDt
		and t1.ToDt = t2.ToDt
where t1.SttCde <> t2.SttCde

-- !!!! DB after applying updates is not identical but this is caused by some disafreement in the information in update files
