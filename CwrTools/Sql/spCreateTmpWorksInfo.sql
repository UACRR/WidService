use CWR 
go

create or alter procedure spCreateTmpWorksInfo
as
begin
-- Хоч один із правовласників має активні права на твір згідно договору з товариством
drop table if exists TmpObjIdsInitial
	select distinct t1.ObjId
	into TmpObjIdsInitial
	from MediaService..CopyRight t1
		join MediaService..RightHolder t2 on t1.CustId = t2.CustId
		join MediaService..AgreementAddRH t3 on t2.CustId = t3.CustId
	where --t1.Status = 1
		--and 
		dbo.fnIsDateInInterval(getdate(), t1.BeginDate, t1.EndDate) = 1
		and t3.agrStatus = 2
		and dbo.fnIsDateInInterval(getdate(), t3.DateBegin, t3.DateEnd) = 1

-- Твори де не визначена роль правовласника
drop table if exists TmpObjIdsUndefinedRole
	select distinct t1.ObjId
	into TmpObjIdsUndefinedRole
	from TmpObjIdsInitial t0
		join MediaService..CopyRight t1 on t0.ObjId = t1.ObjId
		join MediaService..RightHolder t2 on t1.CustId = t2.CustId
		join MediaService..AgreementAddRH t3 on t2.CustId = t3.CustId
	where not (
		t2.rHolderType = 3 and t1.roleCode = 8
		or
		t2.rHolderType = 1 and t1.roleCode in (1, 2, 7, 10)
	)

-- Твори де сума Пуб більше 100%
drop table if exists TmpObjIdsWrongShrPer
	select t1.ObjId, sum(isnull(t1.rate, 0)) as ShrPer
	into TmpObjIdsWrongShrPer
	from TmpObjIdsInitial t0
		join MediaService..CopyRight t1 on t0.ObjId = t1.ObjId
	where
			dbo.fnIsDateInInterval(getdate(), t1.BeginDate, t1.EndDate) = 1
	group by t1.ObjId
	having sum(isnull(t1.rate, 0)) > 100

-- Твори де сума Мех більше 100%
drop table if exists TmpObjIdsWrongShrMec
	select t1.ObjId, sum(isnull(t1.rateMech, 0)) as ShrPer
	into TmpObjIdsWrongShrMec
	from TmpObjIdsInitial t0
		join MediaService..CopyRight t1 on t0.ObjId = t1.ObjId
	where
			dbo.fnIsDateInInterval(getdate(), t1.BeginDate, t1.EndDate) = 1
	group by t1.ObjId
	having sum(isnull(t1.rateMech, 0)) > 100

-- Твори де правовлисники вказані двічі з однаковою творчою роллю
drop table if exists TmpObjIdsWrongDupRoles
	select t1.ObjId, t2.custId, t2.roleCode, count(*) cnt
	into TmpObjIdsWrongDupRoles
	from TmpObjIdsInitial t1
		join MediaService..CopyRight t2 on t1.ObjId = t2.ObjId
	where dbo.fnIsDateInInterval(getdate(), t2.BeginDate, t2.EndDate) = 1
	group by t1.ObjId, t2.custId, t2.roleCode
	having count(*) > 1

-- Твори де видавці вказані двічі
drop table if exists TmpObjIdsWrongPublishers
	select t1.ObjId, t2.custId, count(*) cnt
	into TmpObjIdsWrongPublishers
	from TmpObjIdsInitial t1
		join MediaService..CopyRight t2 on t1.ObjId = t2.ObjId
		join MediaService..RightHolder t3 on t2.CustId = t3.CustId
		join MediaService..AgreementAddRH t4 on t3.CustId = t4.CustId
where t3.rHolderType = 3
	and t4.agrStatus = 2
	and dbo.fnIsDateInInterval(getdate(), t2.BeginDate, t2.EndDate) = 1
	and dbo.fnIsDateInInterval(getdate(), t4.DateBegin, t4.DateEnd) = 1
group by t1.ObjId, t2.custId
having count(*) > 1

-- Твори де вказані невірні ISWC
drop table if exists TmpObjIdsWrongIswcs
	select t1.ObjId, t2.Iswc
	into TmpObjIdsWrongIswcs
	from TmpObjIdsInitial t1
		join MediaService..MediaTrack t2 on t1.ObjId = t2.ObjId
	where dbo.fnCheckIswc(t2.Iswc) = 0


-- Підсумкові твори
drop table if exists TmpObjIdsFinal
; with WrongObjIds as (
	select ObjId
	from TmpObjIdsUndefinedRole
	union
	select ObjId
	from TmpObjIdsWrongShrPer
	union
	select ObjId
	from TmpObjIdsWrongShrMec
	union
	select ObjId
	from TmpObjIdsWrongDupRoles
	union
	select ObjId
	from TmpObjIdsWrongPublishers
	union
	select ObjId
	from TmpObjIdsWrongIswcs
)
select ObjId
into TmpObjIdsFinal
from TmpObjIdsInitial
where ObjId not in (select ObjId from WrongObjIds)

-- TmpWorksNwr
drop table if exists TmpWorksNwr
select 
	  trim(
		left(
			AutoSearch.dbo.ClrTranslitFromUkrToLat(
				replace(t2.Name, char(9), '')
			)
			, 60
		)
	  ) as WorkTitle
	, t1.ObjId as SubmWorkNr
	, t3.Iswc as ISWC
	, 'POP' as MwDistCat
	, 'ORI' as VersionType
into TmpWorksNwr
from TmpObjIdsFinal t1
	join MediaService..ObjectRight t2 on t1.ObjId = t2.ObjId
	join MediaService..MediaTrack t3 on t2.ObjId = t3.ObjId
where t2.Name is not null

-- TmpWorksSpu
drop table if exists TmpWorksSpu
select 
	  t1.ObjId
	, cast(row_number() over (partition by t1.ObjId order by t2.CustId) as int) as PublisherSequenceNr
	, t2.CustId as IpNr
	, AutoSearch.dbo.ClrTranslitFromUkrToLat(t5.shortName) as PublisherName
--	, null as PublisherUnknownIndicator
	, 'E' as PublisherType -- ???
--	, null as TaxIDNr
	, t3.IPIBase as PublisherIPNameNr
--	, null as SubmAgrNr
	, '140' as AffSocNrPR
	, cast(t2.rate * 100 as int) as OwnShrPR
	, '140' as SocMR
	, cast(t2.rateMech * 100 as int) as OwnShrMR
--	, null as SocSR
--	, null as OwnShrSR
--	, null as SpecAgrInd
--	, null as FirstRecordingRefusalInd
--	, null as Filler
	, t3.interCode as PublisherIPBaseNr
--	, null as AgrCode
--	, null as SocAgrNr
--	, null as AgrType
--	, null as LicenseIndUSA
	-- t3.*
into TmpWorksSpu
from TmpObjIdsFinal t1
	join MediaService..CopyRight t2 on t1.ObjId = t2.ObjId
	join MediaService..RightHolder t3 on t2.CustId = t3.CustId
	join MediaService..AgreementAddRH t4 on t3.CustId = t4.CustId
	join MediaService..vCustomerNamesShort t5 on t4.CustId = t5.CustId
where t3.rHolderType = 3
	and t4.agrStatus = 2
	and dbo.fnIsDateInInterval(getdate(), t2.BeginDate, t2.EndDate) = 1
	and dbo.fnIsDateInInterval(getdate(), t4.DateBegin, t4.DateEnd) = 1
	and isnull(t2.rate, 0) + isnull(t2.rateMech, 0) > 0
order by t1.ObjId

-- TmpWorksOpu
drop table if exists TmpWorksOpu
select 
	  t1.ObjId
	, cast(row_number() over (partition by t1.ObjId order by t2.CustId) as int) as PublisherSequenceNr
	, t2.CustId as IpNr
	, AutoSearch.dbo.ClrTranslitFromUkrToLat(t5.shortName) as PublisherName
--	, null as PublisherUnknownIndicator
	, 'E' as PublisherType -- ???
--	, null as TaxIDNr
	, t3.IPIBase as PublisherIPNameNr
--	, null as SubmAgrNr
	, '140' as AffSocNrPR
	, cast(t2.rate * 100 as int) as OwnShrPR
	, '140' as SocMR
	, cast(t2.rateMech * 100 as int) as OwnShrMR
--	, null as SocSR
--	, null as OwnShrSR
--	, null as SpecAgrInd
--	, null as FirstRecordingRefusalInd
--	, null as Filler
	, t3.interCode as PublisherIPBaseNr
--	, null as AgrCode
--	, null as SocAgrNr
--	, null as AgrType
--	, null as LicenseIndUSA
	-- t3.*
into TmpWorksOpu
from TmpObjIdsFinal t1
	join MediaService..CopyRight t2 on t1.ObjId = t2.ObjId
	join MediaService..RightHolder t3 on t2.CustId = t3.CustId
	join MediaService..vCustomerNamesShort t5 on t3.CustId = t5.CustId
	left join TmpWorksSpu t6 on t1.ObjId = t6.ObjId
		and t2.CustId = t6.IpNr
where t3.rHolderType = 3
	and dbo.fnIsDateInInterval(getdate(), t2.BeginDate, t2.EndDate) = 1
	and isnull(t2.rate, 0) + isnull(t2.rateMech, 0) > 0
	and t6.ObjId is null
order by t1.ObjId

-- TmpWorksSwr
drop table if exists TmpWorksSwr
select 
	  t1.ObjId
	, t2.CustId as IpNr
	, AutoSearch.dbo.ClrTranslitFromUkrToLat(isnull(t5.LastName, '')) as WriterLastName
	, AutoSearch.dbo.ClrTranslitFromUkrToLat(isnull(t5.FirstName, '')) as WriterFirstName
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
into TmpWorksSwr
from TmpObjIdsFinal t1
	join MediaService..CopyRight t2 on t1.ObjId = t2.ObjId
	join MediaService..RightHolder t3 on t2.CustId = t3.CustId
	join MediaService..AgreementAddRH t4 on t2.CustId = t4.CustId
	join MediaService..vCustomerNamesLastAndFirst t5 on t2.CustId = t5.CustId
where t3.rHolderType = 1
	and t2.roleCode in (1, 2, 7, 10)
	and t4.agrStatus = 2
	and dbo.fnIsDateInInterval(getdate(), t2.BeginDate, t2.EndDate) = 1
	and dbo.fnIsDateInInterval(getdate(), t4.DateBegin, t4.DateEnd) = 1
	and isnull(t2.rate, 0) + isnull(t2.rateMech, 0) > 0
order by t1.ObjId

-- TmpWorksOwr
drop table if exists TmpWorksOwr
select 
	  t1.ObjId
	, t2.CustId as IpNr
	, AutoSearch.dbo.ClrTranslitFromUkrToLat(isnull(t5.LastName, '')) as WriterLastName
	, AutoSearch.dbo.ClrTranslitFromUkrToLat(isnull(t5.FirstName, '')) as WriterFirstName
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
	--, null as AffSocNrPR
	, cast(isnull(t2.Rate, 0) * 100 as int) as OwnShrPR
	-- , null as SocMR
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
into TmpWorksOwr
from TmpObjIdsFinal t1
	join MediaService..CopyRight t2 on t1.ObjId = t2.ObjId
	join MediaService..RightHolder t3 on t2.CustId = t3.CustId
	join MediaService..vCustomerNamesLastAndFirst t5 on t3.CustId = t5.CustId
	left join TmpWorksSwr t6 on t1.ObjId = t6.ObjId
		and t2.CustId = t6.IpNr
where t3.rHolderType = 1
	and t2.roleCode in (1, 2, 7, 10)
	and dbo.fnIsDateInInterval(getdate(), t2.BeginDate, t2.EndDate) = 1
	and isnull(t2.rate, 0) + isnull(t2.rateMech, 0) > 0
	and t6.ObjId is null
order by t1.ObjId

-- TmpWorksAlt
drop table if exists TmpWorksAlt
select distinct
	  t1.ObjId
	, AutoSearch.dbo.ClrTranslitFromUkrToLat(isnull(Name, '')) as AltTitle
	, 'AT' as TitleType
	--, null as LangCode
into TmpWorksAlt
from TmpObjIdsFinal t1
	join MediaService..SeekObject t2 on t1.ObjId = t2.ObjId
	join TmpWorksNwr t3 on t1.ObjId = t3.SubmWorkNr
where t2.codeI = 1
	and AutoSearch.dbo.ClrTranslitFromUkrToLat(isnull(Name, '')) <> t3.WorkTitle
order by t1.ObjId

-- TmpWorksPer
drop table if exists TmpWorksPer
select distinct
	  t1.ObjId
	, AutoSearch.dbo.ClrTranslitFromUkrToLat(isnull(Name, '')) as LastName
	-- , null as FirstName
	--, null as IpNameNr
	--, null as IpBaseNr
into TmpWorksPer
from TmpObjIdsFinal t1
	join MediaService..SeekObject t2 on t1.ObjId = t2.ObjId
where t2.codeI = 2
order by t1.ObjId
end
go

-- exec spCreateTmpWorksInfo
