use CWR 
go

create or alter procedure spCreateTmpWorksInfo
as
begin
-- Хоч один із правовласників має активні права на твір згідно договору з товариством
drop table if exists TmpObjIdsInitial
	select distinct t1.ObjId
	into TmpObjIdsInitial
	from MediaService..ObjectRight t1
		join MediaService..CopyRight t2 on t1.ObjId = t2.ObjId
			and getdate() between t2.beginDate and t2.EndDate
		join vRightHoldersOwnActive t3 on t2.CustId = t3.CustId
			--and t3.aroundWord = 1 --!!! MINT
	where t1.categoryCode = 5

--select * from TmpObjIdsInitial where ObjId = 324330                                                                            

-- Проблемні твори
exec spCreateTmpWrongWorks
-- select * from TmpWrongWorks where ObjId = 936522

-- Підсумкові твори
drop table if exists TmpObjIdsFinal
	select ObjId
	into TmpObjIdsFinal
	from TmpObjIdsInitial
	where ObjId not in (select ObjId from TmpWrongWorks)

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
	, isnull(t3.Iswc, '') as ISWC
	, 'POP' as MwDistCat
	, 'ORI' as VersionType
into TmpWorksNwr
from TmpObjIdsFinal t1
	join MediaService..ObjectRight t2 on t1.ObjId = t2.ObjId
	left join MediaService..MediaTrack t3 on t2.ObjId = t3.ObjId

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
	, t3.aroundWord as AroundWorld
into TmpWorksSpu
from TmpObjIdsFinal t1
	join MediaService..CopyRight t2 on t1.ObjId = t2.ObjId
	join MediaService..RightHolder t3 on t2.CustId = t3.CustId
	join MediaService..AgreementAddRH t4 on t3.CustId = t4.CustId
		--and t3.aroundWord = 1 --!!! MINT
	join MediaService..vCustomerNamesShort t5 on t4.CustId = t5.CustId
where t3.rHolderType = 3
	and t4.agrStatus = 2
	and dbo.fnIsDateInInterval(getdate(), t2.BeginDate, t2.EndDate) = 1
	and dbo.fnIsDateInInterval(getdate(), t4.DateBegin, t4.DateEnd) = 1
	-- and isnull(t2.rate, 0) + isnull(t2.rateMech, 0) > 0
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
	, '   ' as AffSocNrPR
	, cast(t2.rate * 100 as int) as OwnShrPR
	, '   ' as SocMR
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
		--and t3.aroundWord = 1 --!!! MINT
	join MediaService..vCustomerNamesShort t5 on t3.CustId = t5.CustId
	left join TmpWorksSpu t6 on t1.ObjId = t6.ObjId
		and t2.CustId = t6.IpNr
where t3.rHolderType = 3
	and dbo.fnIsDateInInterval(getdate(), t2.BeginDate, t2.EndDate) = 1
	-- and isnull(t2.rate, 0) + isnull(t2.rateMech, 0) > 0
	and t6.ObjId is null
order by t1.ObjId

-- TmpWorksSwr
drop table if exists TmpWorksSwr
select 
	  t2.CopyRightId as CopyRightId
	, t1.ObjId
	, t2.CustId as IpNr
	, AutoSearch.dbo.ClrTranslitFromUkrToLat(isnull(t3.LastName, '')) as WriterLastName
	, AutoSearch.dbo.ClrTranslitFromUkrToLat(isnull(t3.FirstName, '')) as WriterFirstName
	--, null as WriterUnknownIndicator
	, dbo.fnGetCwrRole(1, t2.RoleCode)  as WriterDesignationCode
	--, null as TaxIDNr
	, t2.IpNameNr as WriterIpNameNr
	, '140' as AffSocNrPR
	, cast(t2.PerShr * 100 as int) as OwnShrPR
	, '140' as SocMR
	, cast (t2.MecShr * 100 as int) as OwnShrMR
	--, null as SocSR
	--, null as OwnShrSR
	--, null as SpecFieldsRevInd
	--, null as FirstRecordingRefusalInd
	--, null as WorkForHireIndicator
	--, null as Filler
	, t2.IpBaseNr as WriterIpBaseNr
	--, null as PersonalNr
	--, null as LicenseIndUSA
	, t2.aroundWord as AroundWorld
into TmpWorksSwr
from TmpObjIdsFinal t1
	join vWorkRightHoldersCurrent t2 on t1.ObjId = t2.ObjId
		--and t2.AroundWord = 1 --!!! MINT
	join MediaService..vCustomerNamesLastAndFirst t3 on t2.CustId = t3.CustId
where t2.RightHolderType = 1
	and t2.IsOwn = 1
order by t1.ObjId

update t1
set t1.WriterDesignationCode = dbo.fnGetCwrRole(1, t2.CopyRightRoleNew)
from TmpWorksSwr t1
	join Z_CopyRightHistoryOutline t2 on t1.CopyRightId = t2.CopyRightId
where t1.WriterDesignationCode = ''

-- TmpWorksOwr
drop table if exists TmpWorksOwr
select
	  t2.CopyRightId as CopyRightId
	, t1.ObjId
	, t2.CustId as IpNr
	, AutoSearch.dbo.ClrTranslitFromUkrToLat(isnull(t3.LastName, '')) as WriterLastName
	, AutoSearch.dbo.ClrTranslitFromUkrToLat(isnull(t3.FirstName, '')) as WriterFirstName
	--, null as WriterUnknownIndicator
	, dbo.fnGetCwrRole(1, t2.RoleCode) as WriterDesignationCode
	--, null as TaxIDNr
	, t2.IpNameNr as WriterIpNameNr
	, null as AffSocNrPR
	, cast(t2.PerShr * 100 as int) as OwnShrPR
	 , null as SocMR
	, cast (t2.MecShr * 100 as int) as OwnShrMR
	--, null as SocSR
	--, null as OwnShrSR
	--, null as SpecFieldsRevInd
	--, null as FirstRecordingRefusalInd
	--, null as WorkForHireIndicator
	--, null as Filler
	,  t2.IpBaseNr as WriterIpBaseNr
	--, null as PersonalNr
	--, null as LicenseIndUSA
into TmpWorksOwr
from TmpObjIdsFinal t1
	join vWorkRightHoldersCurrent t2 on t1.ObjId = t2.ObjId
		--and t2.aroundWord = 1 --!!! MINT
	join MediaService..vCustomerNamesLastAndFirst t3 on t2.CustId = t3.CustId
where t2.RightHolderType = 1
	and t2.IsOwn = 0
order by t1.ObjId

update t1
set t1.WriterDesignationCode = dbo.fnGetCwrRole(1, t2.CopyRightRoleNew)
from TmpWorksOwr t1
	join Z_CopyRightHistoryOutline t2 on t1.CopyRightId = t2.CopyRightId
where t1.WriterDesignationCode = ''

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
	and AutoSearch.dbo.ClrTranslitFromUkrToLat(Name) <> t3.WorkTitle
	and trim(isnull(name, '')) <> ''
union
select
	  t1.ObjId
	, Name as AltTitle
	, 'AT' as TitleType
	--, null as LangCode
from TmpObjIdsFinal t1
	join MediaService..SeekObject t2 on t1.ObjId = t2.ObjId
	join TmpWorksNwr t3 on t1.ObjId = t3.SubmWorkNr
where t2.codeI = 1
	and Name <> t3.WorkTitle
	and trim(isnull(name, '')) <> ''
order by t1.ObjId
-- select * from TmpWorksAlt order by ObjId
-- TmpWorksPer
drop table if exists TmpWorksPer
select distinct
	  t1.ObjId
	, AutoSearch.dbo.ClrTranslitFromUkrToLat(Name) as LastName
	-- , null as FirstName
	--, null as IpNameNr
	--, null as IpBaseNr
into TmpWorksPer
from TmpObjIdsFinal t1
	join MediaService..SeekObject t2 on t1.ObjId = t2.ObjId
where t2.codeI = 2
	and trim(isnull(name, '')) <> ''
union
select distinct
	  t1.ObjId
	, Name as LastName
	-- , null as FirstName
	--, null as IpNameNr
	--, null as IpBaseNr
from TmpObjIdsFinal t1
	join MediaService..SeekObject t2 on t1.ObjId = t2.ObjId
where t2.codeI = 2
	and trim(isnull(name, '')) <> ''
order by t1.ObjId
-- select * from TmpWorksPer order by ObjId
end
go

-- exec spCreateTmpWorksInfo
