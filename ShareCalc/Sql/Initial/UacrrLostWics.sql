use ShareCalc
go

-- Втрачені твори ВІД
drop table if exists UacrrLostWics
select distinct t1.Wic, 0 as ObjId,  0 as MatchedBy
into UacrrLostWics
from SocWid..WidTitle t1
	join SocWid..WidSubmission t2 on t1.Wic = t2.Wic
		and SocCde = '140'
		and left(SocWorkCde, 2) <> 'MS'
		and TrTyp = 'WIA'
	left join MediaService..RepMSWIC t3 on t1.Wic = t3.WIc
where t3.Wic is null

-- >>>>>>>>>>>>>>>>>>>>>>>>  UKR
-- Знайдені за унікальним співпадінням назви
drop table if exists #MatchedByName
; with Wics as (
	select t1.Wic
	from UacrrLostWics t1
		join SocWid..WidTitle t2 on t1.Wic = t2.Wic
		join MediaService..MediaTrack t3 on isnull(t3.Name, '') <> ''
			and MediaService.dbo.ClrTranslitFromUkrToLat(t3.Name) = t2.WrkTtl
	group by t1.Wic
	having count(*) = 1
),
Pairs as (
	select t1.Wic, t4.ObjId
	from Wics t1
		join SocWid..WidTitle t2 on t1.Wic = t2.Wic
		join MediaService..vWidComposerAggInv t3 on t1.Wic = t3.Wic
		join MediaService..MediaTrack t4 on isnull(t4.Name, '') <> ''
			and MediaService.dbo.ClrTranslitFromUkrToLat(t4.Name) = t2.WrkTtl
)
select *
into #MatchedByName
from Pairs

update t2
set t2.ObjId = t1.ObjId, t2.MatchedBy = 1
from #MatchedByName t1
	join UacrrLostWics t2 on t1.Wic = t2.Wic

drop table if exists #MatchedByName

-- Знайдені за унікальним співпадінням назви і прізвища автора

drop table if exists #MatchedByNameMultiUnique
drop table if exists #MatchedByNameMulti

; with Wics as (
	select t1.Wic
	from UacrrLostWics t1
		join SocWid..WidTitle t2 on t1.Wic = t2.Wic
		join MediaService..MediaTrack t3 on isnull(t3.Name, '') <> ''
			and MediaService.dbo.ClrTranslitFromUkrToLat(t3.Name) = t2.WrkTtl
	group by t1.Wic
	having count(*) > 1
)
select t1.Wic, t4.ObjId
into #MatchedByNameMulti
from Wics t1
	join SocWid..WidTitle t2 on t1.Wic = t2.Wic
	join MediaService..vWidComposerAggInv t3 on t1.Wic = t3.Wic
	join MediaService..MediaTrack t4 on isnull(t4.Name, '') <> ''
		and MediaService.dbo.ClrTranslitFromUkrToLat(t4.Name) = t2.WrkTtl

; with WidAuthorNames as (
	select distinct t1.Wic, t1.ObjId, trim(concat(t3.Name, ' ', t3.FstName)) as Name
	from #MatchedByNameMulti t1
		join SocWid..widIntrPty t2 on t1.Wic = t2.WIc
		join SocIpi..IpiName t3 on t2.IpNameNr = t3.IpNameNr
),
MsAuthorNames as (
	select distinct t1.Wic, t1.ObjId, MediaService.dbo.ClrTranslitFromUkrToLat(t3.FullName) as Name
	from #MatchedByNameMulti t1
		join MediaService..CopyRight t2 on t1.ObjId = t2.ObjId
		join MediaService..vCustomerNameDetailed t3 on t2.CustId = t3.CustId
),
MatchedWics as (
	select t1.Wic
	from WidAuthorNames t1
		join MsAuthorNames t2 on t1.Wic = t2.Wic
			and t1.ObjId = t2.ObjId
			and t2.Name like concat('%', t1.Name, '%')
	group by t1.Wic
	having count(*) = 1
)
select t1.Wic, t1.ObjId
into #MatchedByNameMultiUnique
from WidAuthorNames t1
	join MsAuthorNames t2 on t1.Wic = t2.Wic
		and t1.ObjId = t2.ObjId
		and t2.Name like concat('%', t1.Name, '%')
	join MatchedWics t3 on t1.Wic = t3.Wic

update t2
set t2.ObjId = t1.ObjId, t2.MatchedBy = 2
--select distinct t1.Wic
from #MatchedByNameMultiUnique t1
	join UacrrLostWics t2 on t1.Wic = t2.Wic

drop table if exists #MatchedByNameMultiUnique
drop table if exists #MatchedByNameMulti

----------------------------------------------------------------------------

-- >>>>>>>>>>>>>>>>>>>>>>>>  RUS
-- Знайдені за унікальним співпадінням назви
drop table if exists #MatchedByNameRus
; with Wics as (
	select t1.Wic
	from UacrrLostWics t1
		join SocWid..WidTitle t2 on t1.Wic = t2.Wic
		join MediaService..MediaTrack t3 on isnull(t3.Name, '') <> ''
			and MediaService.dbo.ClrTranslitFromRusToLat(t3.Name) = t2.WrkTtl
	group by t1.Wic
	having count(*) = 1
),
Pairs as (
	select t1.Wic, t4.ObjId
	from Wics t1
		join SocWid..WidTitle t2 on t1.Wic = t2.Wic
		join MediaService..vWidComposerAggInv t3 on t1.Wic = t3.Wic
		join MediaService..MediaTrack t4 on isnull(t4.Name, '') <> ''
			and MediaService.dbo.ClrTranslitFromRusToLat(t4.Name) = t2.WrkTtl
)
select *
into #MatchedByNameRus
from Pairs

update t2
set t2.ObjId = t1.ObjId, t2.MatchedBy = 3
from #MatchedByNameRus t1
	join UacrrLostWics t2 on t1.Wic = t2.Wic
where t2.ObjId = 0

drop table if exists #MatchedByNameRus

-- VIA ISWC - no sense, just one work found
select *
from UacrrLostWics t1
	left join SocWid..WidIswc t2 on t1.Wic = t2.Wic
	left join MediaService..MediaTrack t3 on t2.Iswc = t3.Iswc
where t3.ObjId is not null
	and t1.ObjId = 0