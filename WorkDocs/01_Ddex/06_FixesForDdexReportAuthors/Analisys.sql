select * from RegisterCCIDAuthor
where regId = 920 and ratePER is null

select *
from RegisterCCID
where regId = 920

select *
from Ddex..DdexReport
where Id = 36

SELECT *
FROM [DDEX]..[DdexAdjConsolidatedDetail] t1
	left join Ddex..IdentBacklog t2 on t1.SalesTransactionId = t2.SalesTransactionId
where t1.ddexreportid = 36 and t2.SalesTransactionId is null and AllocatedRevenueCompensated <> 0

-- SUMS !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
; with Sums as (
	select DdexReportId, Wic, sum(0.01 * PerShr * isnull(PerSocShr, 0) + 0.01 * MecShr*isnull(mecsocshr, 0)) * 0.5 as Sum
	from DdexReportAuthors
	where DdexReportId = 36
	group by DdexReportId, Wic
)
select *
from Sums
where sum = 0

; with Sums as (
	select 
		  DdexReportId
		, ObjId
		, sum(0.01 * PerShr * isnull(PerSocShr, 0) + 0.01 * MecShr*isnull(mecsocshr, 0)) * 0.5 as Sum
	from DdexReportAuthors
	where DdexReportId = 36
	group by DdexReportId, ObjId
)
select  sum(AllocatedRevenueCompensated)
from Sums t1
	join DdexAdjConsolidatedDetail t2 on t1.DdexReportId = t2.DdexReportId
		and concat('ObjId:', t1.ObjId) = t2.WorkCode
where sum = 0

; with Sums as (
	select 
		  DdexReportId
		, Wic
		, sum(0.01 * PerShr * isnull(PerSocShr, 0) + 0.01 * MecShr*isnull(mecsocshr, 0)) * 0.5 as Sum
	from DdexReportAuthors
	where DdexReportId = 36
	group by DdexReportId, Wic
)
select  sum(AllocatedRevenueCompensated)
from Sums t1
	join DdexAdjConsolidatedDetail t2 on t1.DdexReportId = t2.DdexReportId
		and concat('Wic:', t1.Wic) = t2.WorkCode
where sum = 0

select sum(AllocatedRevenueCompensated)
from DdexAdjConsolidatedDetail
where DdexReportId = 36

-- <<<<<<<<<<<<<<<<<<<<   SUMS !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
drop table if exists #NoRightWorks
-- Твори без прав
; with Sums as (
	select 
		  DdexReportId
		, ObjId
		, sum(0.01 * PerShr * isnull(PerSocShr, 0) + 0.01 * MecShr*isnull(mecsocshr, 0)) * 0.5 as Sum
	from DdexReportAuthors
	--where DdexReportId = 33
	group by DdexReportId, ObjId
)
select t2.*
into #NoRightWorks
from Sums t1
	join DdexAdjConsolidatedDetail t2 on t1.DdexReportId = t2.DdexReportId
		and concat('ObjId:', t1.ObjId) = t2.WorkCode
where sum = 0

-- перший з них ObjId = 66839
select *
from MediaService..ObjectRight
where ObjId = 66839
-- >> це СТЕЖЕЧКА	=> ІВАН ФРАНКО, СОЛОВІЙ ХРИСТИНА ІВАНІВНА	=> ХРИСТИНА СОЛОВІЙ

select *
from Ddex..DdexReportAuthors
where DdexReportId  = 33
	and ObjId = 66839
-- >> Висновок - заявлений автор один, договір на укарїну з товариством 140, автор потрапив в виключення, код автора I-003577688-4

select *
from SocIpi..IpiName
where IpBaseNr = 'I-003577688-4'
-- >> Висновок - I-003577688-4 э SUPERSYMETRIA

select *
from MediaService..CopyRight t1
	join MediaService..RightHolder t2 on t1.custId = t2.custId
where ObjId = 66839
-- >> Висновок - визначально авторів двоє, але всі проценти належать I-003577688-4

select *
from MediaService..CopyRight t1
	join MediaService..RightHolder t2 on t1.custId = t2.custId
	join SocIpi..IpiBase t3 on t2.interCode = t3.IpBaseNr
	join SocIpi..IpiAgreement t4 on t3.IpBaseNr = t4.IpBaseNr
	--join SocIpi..IpiTerritory t5 on t4.IpAgreeNr = t5.IpAgreeNr
where t3.IpBaseNr = 'I-003577688-4'
	and t1.ObjId = 66839
	and t4.RgtCde in ('MR', 'PR')
	and getdate() between t4.FromDt and t4.ToDt
-- >> Висновок - на механіку активний договір з 140, на публічку - з 140 і 94

select t4.*, t5.*
from MediaService..CopyRight t1
	join MediaService..RightHolder t2 on t1.custId = t2.custId
	join SocIpi..IpiBase t3 on t2.interCode = t3.IpBaseNr
	join SocIpi..IpiAgreement t4 on t3.IpBaseNr = t4.IpBaseNr
	join SocIpi..IpiTerritory t5 on t4.IpAgreeNr = t5.IpAgreeNr
where t3.IpBaseNr = 'I-003577688-4'
	and t1.ObjId = 66839
	and t4.RgtCde in ('MR', 'PR')
	and getdate() between t4.FromDt and t4.ToDt
-- >> Висновок - э договори з украъною

select count(*) --t4.*
from CcidInDetail t1
	--join CcidInFile t2 on t1.fileId = t2.fileId
	--join CcidInvoice t3 on t2.ccidInvoiceId = t3.Id
	join #NoRightWorks t4 on t4.SalesTransactionId = t1.sales_transaction_id
		--and t4.WorkCode = t1.workcode
--where amount_invoiced_total = 0 and AllocatedRevenueCompensated <> 0
where amount_invoiced_total <> 0
order by t4.DdexReportId

select max(t1.DdexReportId)
from #NoRightWorks t1
	join DdexReportAuthors t2 on t1.WorkCode = concat('ObjId:', t2.ObjId)
order by t1.WorkCode

-- Але проценти ми заявили

select distinct ddexreportid from DdexReportAuthors where PerSoc = 140 and PerSocShr is null --and isnull(wic, 0) <> 0

select distinct WorkCode from #NoRightWorks
----------------------------------------

select sum(AllocatedRevenueCompensated)
from DdexAdjConsolidatedDetail t1
	join DdexReportAuthors t2 on t1.DdexReportId = t2.DdexReportId
		and t1.WorkCode = concat('Wic:', t2.Wic)
where t1.DdexReportId = 42
	and Wic <> 0
	and isnull(PerSocShr, 0) = 0
	and isnull(mecsocshr, 0) = 0
	and t1.AllocatedRevenueCompensated <> 0
order by t2.Wic
  
select sum(AllocatedRevenueCompensated)
from DdexAdjConsolidatedDetail
where DdexReportId = 42

select * 
from DdexAdjConsolidatedDetail
where DdexReportId = 36
	and AllocatedRevenueCompensated > 0
	and isnull(workcode, '') = ''

select * 
 from Ddex..DdexReport t1
	join Ddex..DdexReportingPeriod t2 on t1.ddexReportingPeriodId = t2.Id
where custId = 39556
order by year, quarter

select *
from DdexAdjConsolidatedDetail
where DdexReportId = 42

select max(DdexReportId) from DdexAdjConsolidatedDetail