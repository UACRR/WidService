-- Excesive territories = 0, OK
drop table if exists #Missing
select t1.*
into #Missing
from SocIpi_2024_06_01..IpiTerritory t1
	left join SocIpi_2024_08_31..IpiTerritory t2 on t1.IpAgreeNr = t2.IpAgreeNr
where t2.IpAgreeNr is null
order by t1.IpAgreeNr

select * from #Missing

drop table if exists #Missing
---------------------------------------------------------------------
-- Missing territories = 0, OK
drop table if exists #Missing
select t2.*
into #Missing
from SocIpi_2024_06_01..IpiTerritory t1
	right join SocIpi_2024_08_31..IpiTerritory t2 on t1.IpAgreeNr = t2.IpAgreeNr
where t1.IpAgreeNr is null
order by t1.IpAgreeNr

select * from #Missing

drop table if exists #Missing
-----------------------------------------------

--=================== Field by field
-- Tisan - OK
select top 10 * ---t2.IpAgreeNr, t1.Tisan as TisanOld, t2.Tisan as TisanNew
from SocIpi_2024_06_01..IpiTerritory t1
	join SocIpi_2024_08_31..IpiTerritory t2 on t1.IpAgreeNr = t2.IpAgreeNr and t1.Tisan = t2.Tisan
where t1.IncExcInd <> t2.IncExcInd
