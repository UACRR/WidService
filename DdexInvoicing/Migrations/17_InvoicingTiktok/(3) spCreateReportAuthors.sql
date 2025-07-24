USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[spCreateReportAuthors]    Script Date: 22.07.2025 19:05:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create or alter procedure [dbo].[spCreateReportAuthors] 
	  @DdexReportId int
	, @setId int
as
begin
/*
declare @DdexReportId int = 9
	, @setId int = 2
*/
declare 
	  @RetCode int = 0
	, @cntWID int
	, @cntMS int 

-- >>>>>>>>>>>>>>>> СТВОРЮЄМО КАЛЕНДАРНУ ІНФОРМАЦІЮ ДЛЯ ЗВІТУ
declare 
      @ddexReportingPeriodId	int
	, @periodDateBegin			date
	, @periodDateEnd			date
	, @month					int
	, @quarter					int
	, @year						int

select @ddexReportingPeriodId = ddexReportingPeriodId 
from vFileCcidDdex 
where ddexReportId = @ddexReportId
 
select 
	  @month = month
	, @quarter = quarter
	, @year = year 
from DdexReportingPeriod 
where id = @ddexReportingPeriodId

if @quarter is not null
begin
	select 
		  @periodDateBegin  = dateBegin
		, @periodDateEnd = dateEnd 
	from ft_DateQuarter (@quarter, @year)
end
else
begin
	select @periodDateBegin = datefromparts(@year, @month, 1)
	select @periodDateEnd = eomonth(@periodDateBegin)
end

/*
drop table if exists #Params -- Для полегшення покрокового виконання
select t.*
into #Params
from (
	select
		  @DdexReportId				as DdexReportId
		, @setId					as setId
		, @ddexReportingPeriodId	as ddexReportingPeriodId
		, @periodDateBegin			as periodDateBegin		
		, @periodDateEnd			as periodDateEnd		
		, @month					as month				
		, @quarter					as quarter				
		, @year						as year					
) t
*/
-- <<<<<<<<<<<<<<<< СТВОРЮЄМО КАЛЕНДАРНУ ІНФОРМАЦІЮ ДЛЯ ЗВІТУ

-- >>>>>>>>>>>>>>>> СТВОРЮЄМО ІНФОРМАЦІЮ ПРО ПРОДАЖІ ДЛЯ ІДЕНТИФІКОВАНИХ ТВОРІВ РЕППОРТУ
drop table if exists #ReportSales
create table #ReportSales (
	  Id					int				not null identity(1, 1)
	, Ddexreportid			int				not null 
	, SalesTransactionId	varchar(100)	not null 
	, Wic					int				null 
	, ObjId					int				null 
	, primary key (Id) 
)

insert into #ReportSales  ( 
	  DdexReportId
	, SalesTransactionId
	, ObjId
	, Wic
)
select 
	  t1.DdexReportId										as DdexReportId
	, t1.SalesTransactionId									as SalesTransactionId
	, case when t2.ObjId = 0 then null else t2.ObjId end	as ObjId
	, case when t2.Wic = 0 then null else t2.Wic end		as Wic
from IdentBacklog t1 
	join IdentMW t2 on t1.MwId = t2.Id 
		and (isnull(t2.Wic, 0) + isnull(t2.ObjId, 0)) <> 0
where t1.DdexReportId in ( -- Ускладнення повязане з одночасним оброленням багатьох звітів за період від Дізеру
		select id 
		from ft_AgreementReportIds(@DdexReportId)
	)
-- <<<<<<<<<<<<<<<< СТВОРЮЄМО ІНФОРМАЦІЮ ПРО ПРОДАЖІ ДЛЯ ІДЕНТИФІКОВАНИХ ТВОРІВ РЕППОРТУ

-- >>>>>>>>>>>>>>>> СТВОРЮЄМУ ІНФОРМАЦІЮ ПРО АВТОРІВ КОЖНОГО ПРОДАЖУ ТВОРІВ З WID
/*
declare
      @DdexReportId int
	, @periodDateBegin date
	, @periodDateEnd date
	, @setId int
select 
      @DdexReportId = DdexReportId
	, @periodDateBegin = periodDateBegin
	, @periodDateEnd = periodDateEnd
	, @setId = setId
from #params
*/

drop table if exists #WidAuthors
create table #WidAuthors (  
	 Id                   int                  not null identity(1, 1)
   , DdexReportId         int                  not null
   , Wic                  int                  null
   , IpBaseNr             varchar(13)          null
   , IpNameNr             varchar(13)          null
   , PerShr            decimal(5, 2)		   null
   , MecShr            decimal(5, 2)        null
   , PerSoc               varchar(3)           null
   , MecSoc               varchar(3)           null
   , PerSocShr            decimal(5, 2)          null
   , MecSocShr            decimal(5, 2)          null
   , primary key (id) 
)

declare @WidAuthorShares tblTypeWidAuthorShares

insert @WidAuthorShares
exec spGetWidAuthorShares 
	  @DdexReportId
	, @periodDateBegin
	, @periodDateEnd
	, @setId

; with ReportSaleWics as (
	select distinct
		  DdexReportId
		, Wic
	from #ReportSales
)
insert into #WidAuthors (
	  DdexReportId
	, Wic
	, IpBaseNr   
	, IpNameNr   
	, PerShr  
	, MecShr  
	, PerSoc     
	, MecSoc     
	, PerSocShr  
	, MecSocShr  
) 
select  
	  @DdexReportId		as DdexReportId
	, t2.Wic			as WIC
	, t2.IpBaseNr		as IP_BASE_NR
	, t2.IpNameNr		as IPInr
	, t2.PerWidShr		as ratePER
	, t2.MecWidShr		as rateMEC 
	, t2.PerSoc			as cmCodePER
	, t2.MecSoc			as cmCodeMEC
	, t2.PerSocShr		as rateCmPER
	, t2.MecSocShr		as rateCmMEC
from @WidAuthorShares t2

delete @WidAuthorShares -- очищаємо робочу інформацію
-- <<<<<<<<<<<<<<<<<<<<<<<<<<<< СТВОРЮЄМУ ІНФОРМАЦІЮ ПРО АВТОРІВ КОЖНОГО ПРОДАЖУ ТВОРІВ З WID

-- >>>>>>>>>>>>>>>> СТВОРЮЄМУ ІНФОРМАЦІЮ ПРО АВТОРІВ КОЖНОГО ПРОДАЖУ ТВОРІВ З MS
/*
declare
      @DdexReportId int
	, @periodDateBegin date
	, @periodDateEnd date
	, @setId int
select 
      @DdexReportId = DdexReportId
	, @periodDateBegin = periodDateBegin
	, @periodDateEnd = periodDateEnd
	, @setId = setId
from #params
*/ 
drop table if exists #MsAuthors
create table #MsAuthors(
	 Id                   int              not null identity(1, 1)
   , DdexReportId         int              not null
   , ObjId                int              null
   , IpBaseNr             varchar(13)      null
   , custId               int              null
   , IpNameNr             varchar(13)      null
   , PerShr				  decimal(5, 2)    null
   , MecShr               decimal(5, 2)    null
   , PerSoc		          varchar(3)       null
   , MecSoc		          varchar(3)       null
   , PerSocShr            decimal(5, 2)    null
   , MecSocShr            decimal(5, 2)    null
   , primary key (id) 
)

drop table if exists #CopyRight
create table  #CopyRight (
	  cRightId	int not null primary key
	, objid		int 
	, custId	int 
	, roleCode	int
)

--select top 100 * from vCustCmGroup

-- Знаходимо твори
; with ObjIds as (
	select distinct ObjId
	from #ReportSales
	where ObjId is not null
),
Rights as (
	select 
		  objid		
		, custId	
		, roleCode
		, max(crightId) as crightId
	from MediaService..CopyRight
	group by  objId		
			, custId	
			, roleCode
)
insert into #CopyRight (
	  crightId
	, objid
	, custId
	, roleCode
)
select 
	  t3.cRightId as crightId
	, t3.objId	  as objid
	, t3.custId	  as custId
	, t3.roleCode as roleCode
from ObjIds t1
    join Rights t2 on t1.objid = t2.objId
	join MediaService..CopyRight t3 on t2.crightId = t3.cRightId
where isnull(t1.objId, 0) > 0 -- про всяк випадок, іншого база містити не повинна
	and isnull(t3.rate, 0) + isnull(t3.rateMECH, 0) <> 0 -- про всяк випадок, іншого база містити не повинна
	and (t3.beginDate <= @periodDateEnd and t3.endDate >= @periodDateBegin) -- Перевіряємо перетин інтервалів дат

-- Заповнюємо авторів творів	
insert into #MsAuthors (
	  DdexReportId
	, ObjId 
	, IpBaseNr
	, IpNameNr
	, CustId 
	, PerShr
	, MecShr
	, PerSoc		
	, MecSoc		
	, PerSocShr  
	, MecSocShr  
)
select distinct -- З невідомих причин можливе дублювання інформації
	  @DdexReportId		        as DdexReportId
	, t2.ObjId 					as ObjId 
	, left(t3.interCode, 13)	as IpBaseNr
	, left(t3.IPIbase, 13)		as IpNameNr
	, t2.custId					as CustId 
	, t2.rate					as PerShr
	, t2.rate					as MecShr
	, null						as PerSoc	
	, null						as MecSoc	
	, 100.00					as PerSocShr -- Припускаємо 100% бо нема звідки взяти
	, 100.00					as MecSocShr -- Припускаємо 100% бо нема звідки взяти
from #CopyRight t1 
	join MediaService..CopyRight t2 on t1.objId = t2.objID 
	join MediaService..RightHolder t3 on t2.custId = t3.custId 
where isnull(t1.ObjId, 0) <> 0

drop table #CopyRight

-- Скидаємо в нуль авторські проценти для творів, де сума процентів перевищує 100 (Per)
; with Over100 as (
	select
		  ObjId			as ObjId
		, sum(PerShr)	as Shr
	from #MsAuthors
	group by ObjId
	having sum(PerShr) > 100
)
update #MsAuthors
set PerSocShr = 0.00
from #MsAuthors t1
	join Over100 t2 on t1.ObjId = t2.ObjId

-- Скидаємо в нуль авторські проценти для творів, де сума процентів перевищує 100 (Mec)
; with Over100 as (
	select
		  ObjId			as ObjId
		, sum(MecShr)	as Shr
	from #MsAuthors
	group by ObjId
	having sum(MecShr) > 100
)
update #MsAuthors
set MecSocShr = 0.00
from #MsAuthors t1
	join Over100 t2 on t1.ObjId = t2.ObjId

-- Виключаємо правовласників с custId <> 0, у яких немає активних договорів
Update #MsAuthors
set
	  PerSocShr = 0
	, MecSocShr = 0
from #MsAuthors t1 
    join vMSCustomerRHolder t2 on t1.CustId = t2.CustId  
		and t2.AgrStatus <> 2 
where t1.CustId is not null 

-- Заповнюємо ОКУ авторів для публічки

; with OurRightHolders as (
	select distinct custId
	from MediaService..TermsOfService t1
		join mediaservice..CopyrightKind t2 on t1.CRKindCode = t2.codeI
	where t2.crGroupCode = 1 and ourservice = 1
)
update t1 
set t1.PerSoc = 140
from #MsAuthors t1 
    join OurRightHolders t2 on t1.custId = t2.custId 

; with CustomerSocs as (
	select
		  t1.CustId							as CustId
		, min(cast(t2.interCode as int))	as Soc
	from mediaservice..CustCmRight t1
		join mediaservice..community t2 on t1.cmCustId = t2.custId
	where t1.crKindCode in (
		select crGroupCode
		from mediaservice..CopyrightKind
		where crGroupCode = 1 --(1 - Per, 2 - Mec)
	)
	group by t1.CustId
	--having min(cast(t2.interCode as int)) = 140
	--order by min(cast(t2.interCode as int))
)
update t1 
set t1.PerSoc = t2.Soc
from #MsAuthors t1 
    join CustomerSocs t2 on t1.custId = t2.custId
where t1.PerSoc is null

-- Заповнюємо ОКУ авторів для механіки 

; with OurRightHolders as (
	select distinct custId
	from MediaService..TermsOfService t1
		join mediaservice..CopyrightKind t2 on t1.CRKindCode = t2.codeI
	where t2.crGroupCode = 2 and ourservice = 1
)
update t1 
set t1.MecSoc = 140
from #MsAuthors t1 
    join OurRightHolders t2 on t1.custId = t2.custId 

; with CustomerSocs as (
	select
		  t1.CustId							as CustId
		, min(cast(t2.interCode as int))	as Soc
	from mediaservice..CustCmRight t1
		join mediaservice..community t2 on t1.cmCustId = t2.custId
	where t1.crKindCode in (
		select crKindCode
		from mediaservice..CopyrightKind
		where crGroupCode = 2 --(1 - Per, 2 - Mec)
	)
	group by t1.CustId
)
update t1 
set t1.MecSoc = t2.Soc
from #MsAuthors t1 
    join CustomerSocs t2 on t1.custId = t2.custId
where t1.MecSoc is null

-- > ПЕРЕНЕСЕНЕ З spDdexApplyReportExceptions

--Исключения по договорам Community

update #MsAuthors 
set PerSocShr = 0
from #MsAuthors t1 
	left join vMSCommunity t2 on t1.PerSoc = t2.InterCode 
		and (@periodDateBegin <= t2.dateEndPER and @periodDateEnd >= t2.dateBeginPER)
		and t2.agrStatus = 2
where t2.CustId is null

update #MsAuthors 
set MecSocShr = 0
from #MsAuthors t1 
	left join vMSCommunity t2 on t1.MecSoc = t2.InterCode 
		and (@periodDateBegin <= t2.dateEndMec and @periodDateEnd >= t2.dateBeginMec)
		and t2.agrStatus = 2
where t2.CustId is null

-->

---Поправочки по Оле
--временно, пока не откажится  --18-10-2019
update #MsAuthors 
set 
	  PerSoc = 140
	, MecSoc = 140
	, PerSocShr = 100
	, MecSocShr = 100
where IpBaseNr in ('I-003577688-4', 'I-003842830-5')

update #MsAuthors 
set 
	  MecSoc = 094
	, MecSocShr = PerSocShr
where PerSoc = 094
	and MecSoc is null 
--Поправочки

-- Скидаємо в нуль проценти ОКУ 99
update #MsAuthors
set PerSocShr = 0
where ddexReportId = @ddexReportId
	and PerSoc = 99

update #MsAuthors 
set MecSocShr = 0
where ddexReportId = @ddexReportId
	and MecSoc = 99

-- < ПЕРЕНЕСЕНЕ З spDdexApplyReportExceptions

-- <<<<<<<<<<<<<<<<<<<<<<<<<<<<<< ДОДАЄМО ІНФОРМАЦІЮ З ТВОРІВ MS

-- >>>>>>>>>>>>>>>> ЗАПАМ'ЯТОВУЄМО АВТОРІВ З WID
delete DdexReportAuthors
where DdexReportId = @DdexReportId

insert into DdexReportAuthors (  
	  DdexReportId
	, Wic
	, ObjId
	, IpBaseNr
	, CustId
	, IpNameNr
    , PerShr
	, MecShr
	, PerSoc
	, MecSoc
	, PerSocShr
    , MecSocShr
)
select 
	  DdexReportId as DdexReportId
	, Wic		   as Wic
	, null		   as ObjId
	, IpBaseNr	   as IpBaseNr
	, null		   as CustId
	, IpNameNr	   as IpNameNr
	, PerShr	   as PerShr
	, MecShr	   as MecShr
	, PerSoc	   as PerSoc
	, MecSoc	   as MecSoc
	, PerSocShr	   as PerSocShr
	, MecSocShr	   as MecSocShr
from #WidAuthors

-- <<<<<<<<<<<<<<<< ЗАПАМ'ЯТОВУЄМО АВТОРІВ З WID

-- >>>>>>>>>>>>>>>> ЗАПАМ'ЯТОВУЄМО АВТОРІВ З MS
 insert into DdexReportAuthors (
	  DdexReportId
	, Wic
	, ObjId
	, IpBaseNr
	, CustId
	, IpNameNr
    , PerShr
	, MecShr
	, PerSoc
	, MecSoc
	, PerSocShr
    , MecSocShr
)
select 
	  DdexReportId as DdexReportId
	, null		   as Wic
	, ObjId		   as ObjId
	, IpBaseNr	   as IpBaseNr
	, CustId	   as CustId
	, IpNameNr	   as IpNameNr
	, PerShr	   as PerShr
	, MecShr	   as MecShr
	, PerSoc	   as PerSoc
	, MecSoc	   as MecSoc
	, PerSocShr	   as PerSocShr
	, MecSocShr	   as MecSocShr
from #MsAuthors
-- <<<<<<<<<<<<<<<< ЗАПАМ'ЯТОВУЄМО АВТОРІВ З MS

-- >>>>>>>>>>>>>>>> ВИРІВНЮЄМО ПРОЦЕНТИ ДО 100 ЯКЩО ДОЗВОЛЕНО
exec spExtendReportAuthors @ddexReportId
exec spExtendReportAuthorsForUnfoundWorks @ddexReportId
-- <<<<<<<<<<<<<<<< ВИРІВНЮЄМО ПРОЦЕНТИ ДО 100 ЯКЩО ДОЗВОЛЕНО


-- >>>>>>>>>>>>>>>>>> СТВОРЮЄМО ІНФОРМАЦІЮ ДЛЯ МУЗИЧНИХ ТВОРІВ РЕПОРТУ
exec spDdexCreateReportMwInfo @DdexReportId
-- <<<<<<<<<<<<<<<< СТВОРЮЄМО ІНФОРМАЦІЮ ДЛЯ МУЗИЧНИХ ТВОРІВ РЕПОРТУ

return @Retcode
end

GO


-- exec spCreateReportAuthors 1496, 27