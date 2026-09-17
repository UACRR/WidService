drop table if exists #Trans
select BaseRecTranId
into #Trans
from RecSpu
where CwrFileId = 71
union
select BaseRecTranId
from RecOpu
where CwrFileId = 71
union
select BaseRecTranId
from RecSwr
where CwrFileId = 71
union
select BaseRecTranId
from RecOwr
where CwrFileId = 71

drop table if exists #EmptyWorks
select t1.BaseRecTranId, t1.TranSeqNr, WorkTitle, t1.SubmWorkNr
	, t3.roleCode, t3.CustId, t3.ObjId, t3.rate, t3.rateMech, t3.beginDate, t3.endDate
	, t4.Aroundword, t4.InterCode, t4.InnerCode, t4.IPIBase
--	, t5.*
into #EmptyWorks
from RecNwr t1
	left join #Trans t2 on t1.BaseRecTranId = t2.BaseRecTranId
	left join MediaService..CopyRight t3 on t1.SubmWorkNr = t3.ObjId
	left join MediaService..RightHolder t4 on t3.CustId = t4.CustId
--	left join MediaService..AgreementAddRH t5 on t3.CustId = t5.CustId
where CwrFileId = 71
	and t2.BaseRecTranId is null
order by t3.ObjId


select * from #EmptyWorks

select 
	  t1.ObjId
	, t2.CustId as IpNr
	, MediaService.dbo.ClrTranslitFromUkrToLat(isnull(t5.LastName, '')) as WriterLastName
	, MediaService.dbo.ClrTranslitFromUkrToLat(isnull(t5.FirstName, '')) as WriterFirstName
	--, null as WriterUnknownIndicator
	, case
		when t2.roleCode = 1 then 'A'
		when t2.roleCode = 2 then 'C'
		when t2.roleCode = 7 then 'AR'
		when t2.roleCode = 10 then 'CA'
		else ''
	 end									as WriterDesignationCode
	--, null as TaxIDNr
	, isnull(t3.IPIBase, '') as WriterIpNameNr
	, case when t4.CustId is null then '' else '140' end as AffSocNrPR
	, cast(isnull(t2.Rate, 0) * 100 as int) as OwnShrPR
	, case when t4.CustId is null then '' else '140' end as SocMR
	, cast (isnull(t2.rateMech, 0) * 100 as int) as OwnShrMR
	--, null as SocSR
	--, null as OwnShrSR
	--, null as SpecFieldsRevInd
	--, null as FirstRecordingRefusalInd
	--, null as WorkForHireIndicator
	--, null as Filler
	,isnull(t3.interCode, '') as WriterIpBaseNr
	--, null as PersonalNr
	--, null as LicenseIndUSA
from TmpObjIdsFinal t1
	join MediaService..CopyRight t2 on t1.ObjId = t2.ObjId
	join MediaService..RightHolder t3 on t2.CustId = t3.CustId
	join MediaService..AgreementAddRH t4 on t2.CustId = t4.CustId
	join MediaService..vCustomerNamesLastAndFirst t5 on t2.CustId = t5.CustId
	join #EmptyWorks t6 on t1.ObjId = t6.objId
where t3.rHolderType = 1
	and t2.roleCode in (1, 2, 7, 10)
	and t4.agrStatus = 2
	and dbo.fnIsDateInInterval(getdate(), t2.BeginDate, t2.EndDate) = 1
	and dbo.fnIsDateInInterval(getdate(), t4.DateBegin, t4.DateEnd) = 1
	--and isnull(t2.rate, 0) + isnull(t2.rateMech, 0) > 0
order by t1.ObjId


select * from MediaService..ObjectRight where ObjId = 955346

select *
from MediaService..ObjectRight t1
	left join MediaService..CopyRight t2 on t1.ObjId = t2.ObjId
	left join MediaService..RightHolder t3 on t2.CustId = t3.CustId
	left join MediaService..AgreementAddRH t4 on t2.CustId = t4.CustId
where t1.ObjId = 978479

select *
from TmpWorksSpu t1
	left join TmpWorksNwr t2 on t1.ObjId = t2.SubmWorkNr
where t2.SubmWorkNr is null

select *
from TmpWorksOpu t1
	left join TmpWorksNwr t2 on t1.ObjId = t2.SubmWorkNr
where t2.SubmWorkNr is null

select *
from TmpWorksSwr t1
	left join TmpWorksNwr t2 on t1.ObjId = t2.SubmWorkNr
where t2.SubmWorkNr is null

select *
from TmpWorksOwr t1
	left join TmpWorksNwr t2 on t1.ObjId = t2.SubmWorkNr
where t2.SubmWorkNr is null

select *
from TmpWorksAlt t1
	left join TmpWorksNwr t2 on t1.ObjId = t2.SubmWorkNr
where t2.SubmWorkNr is null

select *
from TmpWorksPer t1
	left join TmpWorksNwr t2 on t1.ObjId = t2.SubmWorkNr
where t2.SubmWorkNr is null