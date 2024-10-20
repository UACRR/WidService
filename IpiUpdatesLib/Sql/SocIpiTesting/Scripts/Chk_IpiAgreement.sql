select *
from SocIpi_2024_06_01..IpiAgreement
where IsDeleted = 1

-- 0 excesive names
drop table if exists #Missing
select top 10 t1.*
into #Missing
from SocIpi_2024_06_01..IpiAgreement t1
	left join SocIpi_2024_08_31..IpiAgreement t2 on t1.IpAgreeNr = t2.IpAgreeNr
where t1.IsDeleted = 0 
	and t2.IpAgreeNr is null
order by t1.IpAgreeNr
drop table if exists #Missing
---------------------------------------------------------------------

-- Missing names after update - OK
drop table if exists #Missing
select top 10 t2.*
into #Missing
from SocIpi_2024_06_01..IpiAgreement t1
	right join SocIpi_2024_08_31..IpiAgreement t2 on t1.IpAgreeNr = t2.IpAgreeNr
where t1.IpAgreeNr is null


-- =========================================================================

--=================== Field by field
-- SocCde - OK
select t2.IpAgreeNr, t1.SocCde as Old, t2.SocCde as New
from SocIpi_2024_06_01..IpiAgreement t1
	join SocIpi_2024_08_31..IpiAgreement t2 on t1.IpAgreeNr = t2.IpAgreeNr
where t1.SocCde <> t2.SocCde
	and t1.IsDeleted = 0

