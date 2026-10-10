USE [DDEX]
GO
/****** Object:  StoredProcedure [dbo].[spDdexUpdateIndentBacklogSharesTikTok]    Script Date: 09.09.2026 15:44:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER   procedure [dbo].[spDdexUpdateIndentBacklogSharesTikTok]
	  @ddexReportId int
as
begin

-- ДЛЯ ЗВІТУ З УКРАЇНИ
begin
-- Проставляємо процентовку для продажів творів з Wid у звіті

drop table if exists #SaleSharesWid -- Через тимчасову таблицю працює швидше
; with WicPerSale as (
	select 
		  t1.DdexReportId
		, t1.BlockId
		, t1.SalesTransactionId
		, t2.Wic
	from IdentBacklog t1
		join IdentMw t2 on t1.MwId = t2.Id
	where isnull(t2.Wic, 0) <> 0
		and t1.DdexReportId = @ddexReportId
),
WicShr as (
	select
		  Wic								as Wic
		, sum(PerShr * (PerSocShr / 100))	as WicPerShr	 -- З поправкою на процент товариства
		, sum(MecShr * (MecSocShr / 100))	as WicMecShr	 -- З поправкою на процент товариства
	from DdexReportAuthors
	where isnull(Wic, 0) <> 0
		and DdexReportId = @ddexReportId
	group by Wic
)
select 
	  t1.DdexReportId			as DdexReportId
	, t1.BlockId				as BlockId
	, t1.SalesTransactionId		as SalesTransactionId
	, t2.Wic					as Wic
	, t3.WicPerShr				as WicPerShr
	, t3.WicMecShr				as WicMecShr
into #SaleSharesWid
from IdentBacklog t1
	join WicPerSale t2 on 
			t1.DdexReportId			= t2.DdexReportId
		and t1.BlockId				= t2.BlockId
		and t1.SalesTransactionId	= t2.SalesTransactionId
	join WicShr t3 on t3.Wic = t2.Wic
where WicPerShr <> 0 or WicMecShr <> 0
--order by t1.NetRevenue desc

-- select * from #SaleSharesWid

update t2 
set 
	  t2.rateTotalPer = t1.WicPerShr
	, t2.rateTotalMec = t1.WicMecShr
from #SaleSharesWid t1
	join IdentBacklog t2 on 
			t1.DdexReportId			= t2.DdexReportId
		and t1.BlockId				= t2.BlockId
		and t1.SalesTransactionId	= t2.SalesTransactionId

drop table #SaleSharesWid

-- Проставляємо процентовку для продажів звіту для творів з Ms

drop table if exists #SaleSharesMs -- Через тимчасову таблицю працює швидше
; with ObjIdPerSale as (
	select 
		  t1.DdexReportId
		, t1.BlockId
		, t1.SalesTransactionId
		, t2.ObjId
	from IdentBacklog t1
		join IdentMw t2 on t1.MwId = t2.Id
	where isnull(t2.ObjId, 0) <> 0
		and t1.DdexReportId = @ddexReportId
	union
	select 
		  t1.DdexReportId
		, t1.BlockId
		, t1.SalesTransactionId
		, t3.ObjId
	from IdentBacklog t1
		join IdentMw t2 on t1.MwId = t2.Id
		join MediaService..ObjectRight t3 on
				t3.categoryCode = 18
			and t3.loadId = t1.MwId
	where isnull(t2.ObjId, 0) = 0
		and t1.DdexReportId = @ddexReportId
),
ObjIdShr as (
	select
		  ObjId								as ObjId
		, sum(PerShr * (PerSocShr / 100))	as ObjIdPerShr	 -- З поправкою на процент товариства
		, sum(MecShr * (MecSocShr / 100))	as ObjIdMecShr	 -- З поправкою на процент товариства
	from DdexReportAuthors
	where isnull(ObjId, 0) <> 0
		and DdexReportId = @ddexReportId
	group by ObjId
)
select 
	  t1.DdexReportId			as DdexReportId
	, t1.BlockId				as BlockId
	, t1.SalesTransactionId		as SalesTransactionId
	, t2.ObjId					as ObjId
	, t3.ObjIdPerShr			as ObjIdPerShr
	, t3.ObjIdMecShr			as ObjIdMecShr
into #SaleSharesMs
from IdentBacklog t1
	join ObjIdPerSale t2 on 
			t1.DdexReportId			= t2.DdexReportId
		and t1.BlockId				= t2.BlockId
		and t1.SalesTransactionId	= t2.SalesTransactionId
	join ObjIdShr t3 on t3.ObjId = t2.ObjId
where ObjIdPerShr <> 0 or ObjIdMecShr <> 0
--order by t1.NetRevenue desc

update t2
set
	  t2.rateTotalPer = t1.ObjIdPerShr
	, t2.rateTotalMec = t1.ObjIdMecShr
from #SaleSharesMs t1
	join IdentBacklog t2 on 
			t1.DdexReportId			= t2.DdexReportId
		and t1.BlockId				= t2.BlockId
		and t1.SalesTransactionId	= t2.SalesTransactionId

drop table #SaleSharesMs
end

-- ДЛЯ ЗВІТІВ З ІНШХ ТЕРИТОРІЙ
begin

-- Обираємо звіти
drop table if exists #ReportIds
select Id
into #ReportIds
from ft_AgreementReportIds(@ddexReportId)
where Id <> @ddexReportId

-- Працюємо з тимчасовою таблицею авторів, де прибрані проценти іноземних авторів
drop table if exists #DdexReportAuthors
select *
into #DdexReportAuthors
from DdexReportAuthors
where DdexReportId = @ddexReportId -- Всі автори повязані з головним звітом

update #DdexReportAuthors
set PerSocShr = 0
where PerSoc <> 140

update #DdexReportAuthors
set MecSocShr = 0
where MecSoc <> 140

-- Проставляємо процентовку для продажів творів з Wid у звіті

drop table if exists #SaleSharesWid1 -- Через тимчасову таблицю працює швидше
; with WicPerSale as (
	select 
		  t1.DdexReportId
		, t1.BlockId
		, t1.SalesTransactionId
		, t2.Wic
	from IdentBacklog t1
		join IdentMw t2 on t1.MwId = t2.Id
	where isnull(t2.Wic, 0) <> 0
		and t1.DdexReportId in (
			select Id 
			from #ReportIds
		)
),
WicShr as (
	select
		  Wic								as Wic
		, sum(PerShr * (PerSocShr / 100))	as WicPerShr	 -- З поправкою на процент товариства
		, sum(MecShr * (MecSocShr / 100))	as WicMecShr	 -- З поправкою на процент товариства
	from #DdexReportAuthors
	where isnull(Wic, 0) <> 0
		and DdexReportId = @ddexReportId
	group by Wic
)
select 
	  t1.DdexReportId			as DdexReportId
	, t1.BlockId				as BlockId
	, t1.SalesTransactionId		as SalesTransactionId
	, t2.Wic					as Wic
	, t3.WicPerShr				as WicPerShr
	, t3.WicMecShr				as WicMecShr
into #SaleSharesWid1
from IdentBacklog t1
	join WicPerSale t2 on 
			t1.DdexReportId			= t2.DdexReportId
		and t1.BlockId				= t2.BlockId
		and t1.SalesTransactionId	= t2.SalesTransactionId
	join WicShr t3 on t3.Wic = t2.Wic
where WicPerShr <> 0 or WicMecShr <> 0
--order by t1.NetRevenue desc

update t2 
set 
	  t2.rateTotalPer = t1.WicPerShr
	, t2.rateTotalMec = t1.WicMecShr
from #SaleSharesWid1 t1
	join IdentBacklog t2 on 
			t1.DdexReportId			= t2.DdexReportId
		and t1.BlockId				= t2.BlockId
		and t1.SalesTransactionId	= t2.SalesTransactionId

drop table #SaleSharesWid1

-- Проставляємо процентовку для продажів звіту для творів з Ms

drop table if exists #SaleSharesMs1 -- Через тимчасову таблицю працює швидше
; with ObjIdPerSale as (
	select 
		  t1.DdexReportId
		, t1.BlockId
		, t1.SalesTransactionId
		, t2.ObjId
	from IdentBacklog t1
		join IdentMw t2 on t1.MwId = t2.Id
	where isnull(t2.ObjId, 0) <> 0
		and t1.DdexReportId in (
			select Id 
			from #ReportIds
		)
),
ObjIdShr as (
	select
		  ObjId								as ObjId
		, sum(PerShr * (PerSocShr / 100))	as ObjIdPerShr	 -- З поправкою на процент товариства
		, sum(MecShr * (MecSocShr / 100))	as ObjIdMecShr	 -- З поправкою на процент товариства
	from #DdexReportAuthors
	where isnull(ObjId, 0) <> 0
		and DdexReportId = @ddexReportId
	group by ObjId
)
select 
	  t1.DdexReportId			as DdexReportId
	, t1.BlockId				as BlockId
	, t1.SalesTransactionId		as SalesTransactionId
	, t2.ObjId					as ObjId
	, t3.ObjIdPerShr			as ObjIdPerShr
	, t3.ObjIdMecShr			as ObjIdMecShr
into #SaleSharesMs1
from IdentBacklog t1
	join ObjIdPerSale t2 on 
			t1.DdexReportId			= t2.DdexReportId
		and t1.BlockId				= t2.BlockId
		and t1.SalesTransactionId	= t2.SalesTransactionId
	join ObjIdShr t3 on t3.ObjId = t2.ObjId
where ObjIdPerShr <> 0 or ObjIdMecShr <> 0
--order by t1.NetRevenue desc

update t2
set
	  t2.rateTotalPer = t1.ObjIdPerShr
	, t2.rateTotalMec = t1.ObjIdMecShr
from #SaleSharesMs1 t1
	join IdentBacklog t2 on 
			t1.DdexReportId			= t2.DdexReportId
		and t1.BlockId				= t2.BlockId
		and t1.SalesTransactionId	= t2.SalesTransactionId

drop table #SaleSharesMs1
end

end

-- exec spDdexUpdateIndentBacklogSharesTikTok @ddexReportId
-- select * from IdentBacklog where DdexReportId = @ddexReportId
