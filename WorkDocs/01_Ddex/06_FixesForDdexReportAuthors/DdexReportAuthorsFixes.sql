use Ddex
go


create or alter procedure spSysFixDdexReportAuthors
	  @ddexReportId int
	, @reSubmitToMs bit
as
begin

drop table if exists #WrkIdentMwAuthor

select *
into #WrkIdentMwAuthor
from Ddex..IdentMwAuthor
where DdexReportId = @ddexReportId


-- Далі працюємо з авторами для обраного репорту
-- Окремо виконуэмо для разних сполучень MS-WID / PER-MEC

-- !!!!!!!!!!!!! MS-PER
-- Вибираємо авторів в розрізі транзакцій, де проценти яких заявлені, але для того ж автора є транзакції, де його проценти не заявлені
drop table if exists #IncludeAuthorsMsPer
select distinct t1.*
into #IncludeAuthorsMsPer
from #WrkIdentMwAuthor t1
	join #WrkIdentMwAuthor t2 on
		    t1.objId = t2.ObjId
		and t1.Custid = t2.custId
		and t1.SalesTransactionId <> t2.SalesTransactionId
		and t1.IncludPER <> t2.IncludPER
where isnull(t1.objId, 0) <> 0
	and t1.IncludPER = 1
order by t1.objId, t1.SalesTransactionId, t1.custId

-- Таких транзакцій може бути кілька? - перевіряємо (це так, тому наступний код потрібний)
--select ObjId, custId, count(*)
--from #IncludeAuthors
--group by ObjId, custId

-- Таке дійсно можк мати місце, томулишаємо лише одну (довільну) проміж них
drop table if exists #IncludeAuthorsSingleMsPer
select ObjId, custId, min(SalesTransactionId) as SalesTransactionId
into #IncludeAuthorsSingleMsPer
from #IncludeAuthorsMsPer
group by ObjId, custId

-- А тепер для решти транзакцій, повязаних за твором-автором будемо брати процентовку із обраних вище
update t2
set 
	  t2.cmCodePER = t3.cmCodePER
	, t2.IncludPER = t3.IncludPER
	, t2.rateCmPER = t3.ratePER
	, t2.ratePER = t3.rateMEC
from #IncludeAuthorsSingleMsPer t1
	join #WrkIdentMwAuthor t2 on
		    t1.objId = t2.ObjId
		and t1.Custid = t2.custId
		and t1.SalesTransactionId <> t2.SalesTransactionId
	join #WrkIdentMwAuthor t3 on
			t1.objId = t3.ObjId
		and t1.Custid = t3.custId
		and t1.SalesTransactionId = t3.SalesTransactionId
where isnull(t1.objId, 0) <> 0
	and t2.IncludPER = 0

-- Перевіряємо результат (мусить повернути 0)
select count(*)
from #WrkIdentMwAuthor t1
	join #WrkIdentMwAuthor t2 on
		    t1.objId = t2.ObjId
		and t1.Custid = t2.custId
		and t1.SalesTransactionId <> t2.SalesTransactionId
		and t1.IncludPER <> t2.IncludPER
where isnull(t1.objId, 0) <> 0
	and t1.IncludPER = 1


------------------------------------------------------------------------------

-- !!!!!!!!!!!!! MS-MEC
-- Вибираємо авторів в розрізі транзакцій, де проценти яких заявлені, але для того ж автора є транзакції, де його проценти не заявлені
drop table if exists #IncludeAuthorsMsMec
select distinct t1.*
into #IncludeAuthorsMsMec
from #WrkIdentMwAuthor t1
	join #WrkIdentMwAuthor t2 on
		    t1.objId = t2.ObjId
		and t1.Custid = t2.custId
		and t1.SalesTransactionId <> t2.SalesTransactionId
		and t1.IncludMEC <> t2.IncludMEC
where isnull(t1.objId, 0) <> 0
	and t1.IncludMEC = 1
order by t1.objId, t1.SalesTransactionId, t1.custId

-- Таких транзакцій може бути кілька? - перевіряємо (це так, тому наступний код потрібний)
--select ObjId, custId, count(*)
--from #IncludeAuthors
--group by ObjId, custId

-- Таке дійсно можк мати місце, томулишаємо лише одну (довільну) проміж них
drop table if exists #IncludeAuthorsSingleMsMec
select ObjId, custId, min(SalesTransactionId) as SalesTransactionId
into #IncludeAuthorsSingleMsMec
from #IncludeAuthorsMsMec
group by ObjId, custId

-- А тепер для решти транзакцій, повязаних за твором-автором будемо брати процентовку із обраних вище
update t2
set 
	  t2.cmCodeMEC = t3.cmCodeMEC
	, t2.IncludMEC = t3.IncludMEC
	, t2.rateCmMEC = t3.rateMEC
	, t2.rateMEC = t3.rateMEC
from #IncludeAuthorsSingleMsMec t1
	join #WrkIdentMwAuthor t2 on
		    t1.objId = t2.ObjId
		and t1.Custid = t2.custId
		and t1.SalesTransactionId <> t2.SalesTransactionId
	join #WrkIdentMwAuthor t3 on
			t1.objId = t3.ObjId
		and t1.Custid = t3.custId
		and t1.SalesTransactionId = t3.SalesTransactionId
where isnull(t1.objId, 0) <> 0
	and t2.IncludMEC = 0

-- Перевіряємо результат (мусить повернути 0)
select count(*)
from #WrkIdentMwAuthor t1
	join #WrkIdentMwAuthor t2 on
		    t1.objId = t2.ObjId
		and t1.Custid = t2.custId
		and t1.SalesTransactionId <> t2.SalesTransactionId
		and t1.IncludMEC <> t2.IncludMEC
where isnull(t1.objId, 0) <> 0
	and t1.IncludMEC = 1


------------------------------------------------------------------------------

-- !!!!!!!!!!!!! WID-PER
-- Вибираємо авторів в розрізі транзакцій, де проценти яких заявлені, але для того ж автора є транзакції, де його проценти не заявлені
drop table if exists #IncludeAuthorsWidPer
select distinct t1.*
into #IncludeAuthorsWidPer
from #WrkIdentMwAuthor t1
	join #WrkIdentMwAuthor t2 on
		    t1.Wic = t2.Wic
		and t1.IP_BASE_NR = t2.IP_BASE_NR
		and t1.SalesTransactionId <> t2.SalesTransactionId
		and t1.IncludPER <> t2.IncludPER
where isnull(t1.Wic, 0) <> 0
	and t1.IncludPER = 1
order by t1.Wic, t1.SalesTransactionId, t1.IP_BASE_NR

-- Таких транзакцій може бути кілька? - перевіряємо (це так, тому наступний код потрібний)
--select Wic, IP_BASE_NR, count(*)
--from #IncludeAuthors
--group by Wic, IP_BASE_NR

-- Таке дійсно можк мати місце, томулишаємо лише одну (довільну) проміж них
drop table if exists #IncludeAuthorsSingleWidPer
select Wic, IP_BASE_NR, min(SalesTransactionId) as SalesTransactionId
into #IncludeAuthorsSingleWidPer
from #IncludeAuthorsWidPer
group by Wic, IP_BASE_NR

-- А тепер для решти транзакцій, повязаних за твором-автором будемо брати процентовку із обраних вище
update t2
set 
	  t2.cmCodePER = t3.cmCodePER
	, t2.IncludPER = t3.IncludPER
	, t2.rateCmPER = t3.ratePER
	, t2.ratePER = t3.rateMEC
from #IncludeAuthorsSingleWidPer t1
	join #WrkIdentMwAuthor t2 on
		    t1.Wic = t2.Wic
		and t1.IP_BASE_NR = t2.IP_BASE_NR
		and t1.SalesTransactionId <> t2.SalesTransactionId
	join #WrkIdentMwAuthor t3 on
			t1.Wic = t3.Wic
		and t1.IP_BASE_NR = t3.IP_BASE_NR
		and t1.SalesTransactionId = t3.SalesTransactionId
where isnull(t1.Wic, 0) <> 0
	and t2.IncludPER = 0

-- Перевіряємо результат (мусить повернути 0)
select count(*)
from #WrkIdentMwAuthor t1
	join #WrkIdentMwAuthor t2 on
		    t1.Wic = t2.Wic
		and t1.IP_BASE_NR = t2.IP_BASE_NR
		and t1.SalesTransactionId <> t2.SalesTransactionId
		and t1.IncludPER <> t2.IncludPER
where isnull(t1.Wic, 0) <> 0
	and t1.IncludPER = 1


------------------------------------------------------------------------------

-- !!!!!!!!!!!!! WID-MEC
-- Вибираємо авторів в розрізі транзакцій, де проценти яких заявлені, але для того ж автора є транзакції, де його проценти не заявлені
drop table if exists #IncludeAuthorsWidMec
select distinct t1.*
into #IncludeAuthorsWidMec
from #WrkIdentMwAuthor t1
	join #WrkIdentMwAuthor t2 on
		    t1.Wic = t2.Wic
		and t1.IP_BASE_NR = t2.IP_BASE_NR
		and t1.SalesTransactionId <> t2.SalesTransactionId
		and t1.IncludMEC <> t2.IncludMEC
where isnull(t1.Wic, 0) <> 0
	and t1.IncludMEC = 1
order by t1.Wic, t1.SalesTransactionId, t1.IP_BASE_NR

-- Таких транзакцій може бути кілька? - перевіряємо (це так, тому наступний код потрібний)
--select Wic, IP_BASE_NR, count(*)
--from #IncludeAuthors
--group by Wic, IP_BASE_NR

-- Таке дійсно можк мати місце, томулишаємо лише одну (довільну) проміж них
drop table if exists #IncludeAuthorsSingleWidMec
select Wic, IP_BASE_NR, min(SalesTransactionId) as SalesTransactionId
into #IncludeAuthorsSingleWidMec
from #IncludeAuthorsWidMec
group by Wic, IP_BASE_NR

-- А тепер для решти транзакцій, повязаних за твором-автором будемо брати процентовку із обраних вище
update t2
set 
	  t2.cmCodeMEC = t3.cmCodeMEC
	, t2.IncludMEC = t3.IncludMEC
	, t2.rateCmMEC = t3.rateMEC
	, t2.rateMEC = t3.rateMEC
from #IncludeAuthorsSingleWidMec t1
	join #WrkIdentMwAuthor t2 on
		    t1.Wic = t2.Wic
		and t1.IP_BASE_NR = t2.IP_BASE_NR
		and t1.SalesTransactionId <> t2.SalesTransactionId
	join #WrkIdentMwAuthor t3 on
			t1.Wic = t3.Wic
		and t1.IP_BASE_NR = t3.IP_BASE_NR
		and t1.SalesTransactionId = t3.SalesTransactionId
where isnull(t1.Wic, 0) <> 0
	and t2.IncludMEC = 0

-- Перевіряємо результат (мусить повернути 0)
select count(*)
from #WrkIdentMwAuthor t1
	join #WrkIdentMwAuthor t2 on
		    t1.Wic = t2.Wic
		and t1.IP_BASE_NR = t2.IP_BASE_NR
		and t1.SalesTransactionId <> t2.SalesTransactionId
		and t1.IncludMEC <> t2.IncludMEC
where isnull(t1.Wic, 0) <> 0
	and t1.IncludMEC = 1


------------------------------------------------------------------------------

-- >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
 -- Тепер можемо сформувати таблицю для авторів стиснуту на рівень продажів
drop table if exists  #WrkDdexReportAuthors
drop table if exists #SaleAuthorWorks

select
	  row_number() over(order by DdexReportId, blockid, SalesTransactionId) as Id
	, DdexReportId
	, blockid
	, SalesTransactionId
	, case when Wic = 0 then null else Wic end as Wic
	, case when ObjId = 0 then null else ObjId end as ObjId
into #SaleAuthorWorks
from #WrkIdentMwAuthor

; with Ids as (
	select
		  DdexReportId	as DdexReportId
		, Wic			as Wic
		, ObjId			as ObjId
		, max(Id)		as Id
	from #SaleAuthorWorks
	group by
		  DdexReportId
		, Wic
		, ObjId
)
select 
	  t3.DdexReportId				as DdexReportId	
	, t3.Wic						as Wic			
	, t3.ObjId						as ObjId			
	, t3.IP_BASE_NR					as IpBaseNr		
	, t3.custId						as CustId		
	, cast(t3.IPInr as int)			as IpNameNr		
	, t3.ratePER					as PerShr		
	, t3.rateMEC					as MecShr	
	, case when t3.cmCodePER is not null and t3.IncludPER = 1 then 100 else null end				as PerSocShr		
	, case when t3.cmCodeMEC is not null and t3.IncludMEC = 1 then 100 else null end				as MecSocShr		
	, cast(t3.cmCodePER as int)		as PerSoc		
	, cast(t3.cmCodeMEC as int)		as MecSoc	
into #WrkDdexReportAuthors
from Ids t1
	join #SaleAuthorWorks t2 on t1.Id = t2.Id
	join #WrkIdentMwAuthor t3 on 
			t2.DdexReportId = t3.DdexReportId
		and t2.BlockId = t3.BlockId
		and t2.SalesTransactionId = t3.SalesTransactionId

drop table #SaleAuthorWorks


-- ДЕЯКІ АВТОРИ НЕ МАЮТЬ IpBaseNr - проставляємо з IpNameNr
-- !!! В старій WID нічого знайти не вдається, беремо з оновленого IPI
update #WrkDdexReportAuthors
set IpBaseNr = t2.IpBaseNr
from #WrkDdexReportAuthors t1
	join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
where isnull(t1.Wic, 0) <> 0
	and t1.IpBaseNr is null

drop table if exists #SaleAuthorWorks

-- <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

-- Виходимо, якщо дані ще не передані в СМАРТ
if @reSubmitToMs = 0
	return

-- Скидаємо дані, передані в MediaService

	declare @regId int
	select @regId = regId from MediaService..RegisterCCID
	where DdexReportId = @ddexReportId

	declare @periodId int = (select periodId from MediaService..Register where regId = @regId)
	
	exec MediaService.dbo.MPay_Pay_A_rollback_regId @regId
	exec MediaService.dbo.SYS_DelPaidPeriod @periodId

	
-- >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
begin try
	begin tran

	-- Замінюємо рядки в базі DDEX на нові
	delete from Ddex..DdexReportAuthors
	where DdexReportId = @ddexReportId

	insert Ddex..DdexReportAuthors (
		  DdexReportId
		, Wic
		, ObjId
		, IpBaseNr
		, CustId
		, IpNameNr
		, PerShr
		, MecShr
		, PerSocShr
		, MecSocShr
		, PerSoc
		, MecSoc
	)
	select
		  DdexReportId
		, Wic
		, ObjId
		, IpBaseNr
		, CustId
		, IpNameNr
		, PerShr
		, MecShr
		, PerSocShr
		, MecSocShr
		, PerSoc
		, MecSoc
	from #WrkDdexReportAuthors

	-- Передаємо дані в MediaService
	declare @result	varchar(100)
		, @RetCode int 
	exec ddex.dbo.spDdexAdjConsolidatedDistRoyalty @ddexReportId, @result, @RetCode

	commit tran
end try
begin catch
	rollback tran
end catch

-- <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

end

go


exec spSysFixDdexReportAuthors 9, 0
exec spSysFixDdexReportAuthors 10, 0
exec spSysFixDdexReportAuthors 11, 0
exec spSysFixDdexReportAuthors 15, 0
exec spSysFixDdexReportAuthors 16, 0
exec spSysFixDdexReportAuthors 17, 0
exec spSysFixDdexReportAuthors 18, 0
exec spSysFixDdexReportAuthors 19, 0
exec spSysFixDdexReportAuthors 20, 0
exec spSysFixDdexReportAuthors 24, 0
exec spSysFixDdexReportAuthors 25, 0
exec spSysFixDdexReportAuthors 26, 0
exec spSysFixDdexReportAuthors 27, 0
exec spSysFixDdexReportAuthors 28, 0
exec spSysFixDdexReportAuthors 29, 0
exec spSysFixDdexReportAuthors 30, 0
exec spSysFixDdexReportAuthors 31, 0
exec spSysFixDdexReportAuthors 32, 0
exec spSysFixDdexReportAuthors 33, 0
exec spSysFixDdexReportAuthors 34, 0
exec spSysFixDdexReportAuthors 35, 0
--exec spSysFixDdexReportAuthors 36
exec spSysFixDdexReportAuthors 37, 1
exec spSysFixDdexReportAuthors 38, 1
exec spSysFixDdexReportAuthors 39, 1
exec spSysFixDdexReportAuthors 40, 1
exec spSysFixDdexReportAuthors 41, 1
exec spSysFixDdexReportAuthors 42, 1
exec spSysFixDdexReportAuthors 43, 1
exec spSysFixDdexReportAuthors 44, 1

--select distinct DdexReportId from Ddex..DdexAdjConsolidatedSummary
--select *
--from Ddex..DdexReport t1
--	join Ddex..DdexReportingPeriod t2 on t1.ddexReportingPeriodId = t2.Id
--order by t1.Id
----exec spSysFixDdexReportAuthors 36