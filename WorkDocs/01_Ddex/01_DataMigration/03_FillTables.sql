use Ddex
go

-- >>>>>>>>>>>>>> ЗАМІІСТЬ ТАБЛИЦІ З ПЕРЕЛІКОМ АВТОРІВ ДЛЯ КОЖНОГО ПРОДАЖУ (ПЕРЕЛІК ДУБЛЮЄТЬСЯ) 
-- >>>>>>>>>>>>>> СТВОРЮЄМО ОДНУ З ПЕРЕЛІКОМ ДЛЯ ТВОРІВ ЗВІТУ

drop table if exists ##SaleAuthorWorks

select
	  row_number() over(order by DdexReportId, blockid, SalesTransactionId) as Id
	, DdexReportId
	, blockid
	, SalesTransactionId
	, case when Wic = 0 then null else Wic end as Wic
	, case when ObjId = 0 then null else ObjId end as ObjId
into ##SaleAuthorWorks
from IdentMwAuthor

; with Ids as (
	select
		  DdexReportId	as DdexReportId
		, Wic			as Wic
		, ObjId			as ObjId
		, max(Id)		as Id
	from ##SaleAuthorWorks
	group by
		  DdexReportId
		, Wic
		, ObjId
)
insert DdexReportAuthors (
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
	  t3.DdexReportId				as DdexReportId	
	, t3.Wic						as Wic			
	, t3.ObjId						as ObjId			
	, t3.IP_BASE_NR					as IpBaseNr		
	, t3.custId						as CustId		
	, cast(t3.IPInr as int)			as IpNameNr		
	, t3.ratePER					as PerShr		
	, t3.rateMEC					as MecShr		
	, t3.rateCmPER					as PerSocShr		
	, t3.rateCmMEC					as MecSocShr		
	, cast(t3.cmCodePER as int)		as PerSoc		
	, cast(t3.cmCodeMEC as int)		as MecSoc		
from Ids t1
	join ##SaleAuthorWorks t2 on t1.Id = t2.Id
	join IdentMwAuthor t3 on 
			t2.DdexReportId = t3.DdexReportId
		and t2.BlockId = t3.BlockId
		and t2.SalesTransactionId = t3.SalesTransactionId

drop table ##SaleAuthorWorks
go

-- ДЕЯКІ АВТОРИ НЕ МАЮТЬ IpBaseNr - проставляємо з IpNameNr
-- !!! В старій WID нічого знайти не вдається, беремо з оновленого IPI
update DdexReportAuthors
set IpBaseNr = t2.IpBaseNr
from DdexReportAuthors t1
	join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
where isnull(t1.Wic, 0) <> 0
	and t1.IpBaseNr is null

-- ОНОВЛЕНА WID НЕ МІСТИТЬ ЗНАЧНОЇ КІЛЬКОСТІ ТВОРІ, НА ЯКІ ПОСИЛАЮТЬСЯ ЗВІТИ
-- НЕОБХІДНО ДЛЯ КОЖНОГО ЗВІТУ МАТИ ІНФОРМАЦІЮ, НЕОБХІДНУ ДЛЯ ПОДАЛЬШОГО РОЗПОДІЛУ

-- Дадаємо записи для кожного твору репорту без деталізації

; with Works as (
	select distinct 
		  DdexReportId											as DdexReportId
		, case when t2.Wic = 0 then null else t2.Wic end		as WIc
		, case when t2.ObjId = 0 then null else t2.ObjId end	as ObjId
	from IdentBacklog t1
		join IdentMw t2 on t1.mwId = t2.Id
)
insert DdexReportMwInfo (
	  DdexReportId
	, Wic
	, ObjId
)
select 
	  DdexReportId  as DdexReportId
	, Wic			as Wic
	, ObjId			as ObjId
from Works

-- Прописуємо назви творів з WID

update t1  
set 
	t1.Title = left(t2.Ttl, 100)
from DdexReportMwInfo t1 
	join WID_IPI..TblTitle t2 on t1.Wic = t2.Wic

-- Прописуємо назви творів з MS
update t1  
set 
	t1.Title = left(t2.name, 100)
from DdexReportMwInfo t1 
	join MediaService..ObjectRight t2 on t1.objId = t2.objId

-- Прописуємо виконавців з WID
 ; with Perfomer as (
	select
		  Wic
		, left(
			  string_agg (convert(varchar(max), trim(FstNa + ' ' + LstNa)), ', ')
			, 100
		) Performer
	from WID_IPI..TblArtist
	group by Wic
)
update t1  
set t1.Performers = t2.Performer
from DdexReportMwInfo t1 
	join Perfomer t2 on t1.Wic = t2.Wic 

-- Прописуємо композиторів з WID
; with AuthorMusicSingle as (
	select distinct 
		  t1.Wic
		, trim(t2.FST_NAME + ' ' + t2.NAME) Name
	from WID_IPI..TblIntrPty t1
		join WID_IPI..TBLIPINAME t2 on t1.IPINr = t2.IP_NAME_NR
	where t1.IntrPtyRol in ('C', 'CA')
),
AuthorMusic as (
	select
		  Wic
		, left(
			string_agg (convert(varchar(max), Name), ', ')
			, 100
		) AuthorMusic
	from AuthorMusicSingle
	group by Wic
)
update t1  
set t1.MusicAuthors = t2.AuthorMusic
from DdexReportMwInfo t1 
   join AuthorMusic t2 on t1.Wic = t2.Wic

-- Прописуємо поетів з WID
; with AuthorTextSingle as (
	select distinct
		  t1.Wic
		, trim(t2.FST_NAME + ' ' + t2.NAME) Name
	from WID_IPI..TblIntrPty t1
		join WID_IPI..TBLIPINAME t2 on t1.IPINr = t2.IP_NAME_NR
	where t1.IntrPtyRol in ('A', 'CA')
),
AuthorText as (
	select
		  Wic
		, left(
			string_agg (convert(varchar(max), Name), ', ')
			, 100
		) AuthorText
	from AuthorTextSingle
	group by Wic
)
update t1  
set t1.LyricsAuthors = t2.AuthorText
from DdexReportMwInfo t1 
   join AuthorText t2 on t1.Wic = t2.Wic 
 
-- Прописуємо виконавців, поетів і композиторів з MS
update t1  
set 
	  t1.Performers		= left(t2.performers	, 100)
    , t1.MusicAuthors	= left(t2.composers		, 100)
	, t1.LyricsAuthors	= left(t2.lyrics		, 100)
from DdexReportMwInfo t1 
	join MediaService..MediaTrack t2 on t1.objId = t2.objId

	-- >>>>>>>>>>>>>>>>>>>>>>>>> ВИДАЛЯЄМО ЗАПИСИ, ДЛЯ ЯКИХ НЕ ЗНАЙДЕНО ІНФОРМАЦІЇ
delete DdexReportMwInfo
where Title is null
go

-- ============================= СКРИПТ ЗАВЕРШЕНО
--select * from DdexReportMwInfo where ObjId is null order by Wic, DdexReportId