use MediaService
go

create or alter procedure spImportFromWid
	@regId int
as
begin 

begin -- create tables
	drop table if exists #TmpWIC
	create table #TmpWIC 
	(WIC integer not null primary key, 
	 objid integer null)

	drop table if exists #TmpObjectRight
	create table #TmpObjectRight 
	(WIC integer not null, 
	 objId integer,
	 genreType integer,  --41
	 name varchar(254),
	 iswc varchar(11), 
	 author varchar(254),
	 lyrics varchar(254),
	 composers varchar(256),
	 performers varchar(254),
	 genre varchar(254), 
	 specType integer,   --MOD = 3, ORI = 1 
	 duration time
	 primary key (WIC)
	)


	drop table if exists #TmpObjectAuthor
	create table #TmpObjectAuthor
	(WIC integer not null, 
	 seqNr smallint not null, 
	 IP_BASE_NR varchar(13), 
	 lstName varchar(254),
	 fstName varchar(254),
	 authorName varchar(254), 
	 IPInr varchar(11), 
	 authorRole varchar(100), 
	 roleCode integer, 
	 ratePER numeric(10,5), 
	 rateMEC numeric(10,5), 
	 rhCustId integer,
	 custIdNew integer, 
	 perId integer,  --Исполнитель
	 cRightId integer null, 
	 objid integer null, 
	 id integer not null identity, 
	 custIdSub integer, 
	 dateEndSub date
	primary key (WIC, seqNr) 
	)

	drop table if exists #TmpAuthors
	create table #TmpAuthors 
	(IPInr varchar(11) not null,
	 IP_BASE_NR varchar(13), 
	 lstName varchar(254),
	 fstName varchar(254),
	 authorName varchar(254), 
	 rhCustId integer,
	 custIdNew integer, 
	 roleCode integer,
	 CmCodePER varchar(10), --community
	 CmCodeMEC varchar(10), --community
	 CmCustIdPER integer, --community
	 CmCustIdMEC integer, --community
	 isAnk smallint null --открывать анкету
	primary key (IPInr ) 
	)

	drop table if exists #TmpPerformer
	create table #TmpPerformer
	(id integer not null identity primary key, 
	 WIC integer, 
	 seqNr int,
	 name varchar(254), 
	 ISRC varchar(20), 
	 perId integer null
	)

	--Альтернативные названия из базы
	drop table if exists #TmpSeekObject
	create table #TmpSeekObject 
	(WIC integer, 
	 name varchar(100), 
	 codeI integer, 
	 primary key (WIC, name) 
	)

end

insert into #TmpWIC (Wic)
select distinct Wic  
from RegisterItem 
where regId = 976
	and isnull(Wic, 0) <> 0 and isnull(ObjId, 0) = 0

if @@rowcount = 0
	return

--Если уже загружали раньше такие WIC
update #TmpWIC
set ObjId = t2.ObjId 
from #TmpWIC t1 
     join RepMsWic t2 on t1.Wic = t2.Wic 

--Проставляю сразу в RegisterItem
update RegisterItem
set ObjId = t2.ObjId 
from RegisterItem t1 
    join #TmpWIC t2 on t2.Wic = t1.Wic 
where isnull(t2.ObjId, 0) <> 0
	and t1.ObjId is null
	and t1.RegId = 976

delete #TmpWIC where isnull(ObjId, 0) <> 0

if (select count(*) from #TmpWIC) = 0 
	return

-----Заполняю таблицы для загрузки
--Объекты права
delete from #TmpObjectRight
insert #TmpObjectRight (
	  Wic
	, genreType
	, name
	, iswc
	, author
	, lyrics
	, composers
	, performers
	, genre
	, specType   --MOD = 3, ORI = 1 
	, duration
)
select 
	  t1.WIC
	, 41
	, t2.WrkTtl
	, t3.ISWC
	, t4.Authors
	, t5.TextWriters
	, t6.Composers
	, t7.Performers
	, t2.MwDistrCat 
	, 1 --(Case When specName ='MOD' then 3 else 1 END), 
	, NULL --duration 
 from #TmpWIC  t1
    join SocWid..WidTitle t2 on t1.Wic = t2.Wic
	left join vWidPrefIswc t3 on t1.Wic = t3.Wic
	left join vWidAuthorAgg t4 on t1.Wic = t4.Wic
	left join vWidTextWriterAgg t5 on t1.Wic = t5.Wic
	left join vWidComposerAgg t6 on t1.Wic = t6.Wic
	left join vWidPerformerAgg t7 on t1.Wic = t7.Wic

	--select top 10 * from [dbo].[vWidSrObjectRight]

----Заполняю для тех, которые не нашлись в WID (уже удалились)
insert #TmpObjectRight (
	  Wic
	, genreType
	, name
	, iswc
	, author
	, lyrics
	, composers
	, performers
	, genre
	, specType   --MOD = 3, ORI = 1 
	, duration
)
select
	  t2.Wic
	, 41
	, t1.ItemName
	, null
	, left(t1.authorMusic + isnull(t1.authorText,''), 254)
	, left(t1.authorText,254)
	, left(t1.authorMusic, 254)
	, left(t1.performer,254)
	, 'ПІСНЯ'
    , 1 --(Case When specName ='MOD' then 3 else 1 END), 
	, null --duration 
from #TmpWIC t2
	join  RegisterItem t1 on t2.Wic = t1.Wic 
	left join #TmpObjectRight t3 on t3.Wic = t1.Wic
where t1.regId = 976
	and t3.Wic is null

--Авторы
delete #TmpObjectAuthor 
insert into  #TmpObjectAuthor (
	  Wic
	, seqNr
	, IP_BASE_NR
	, authorName
	, lstName
	, fstName
	, IPInr
	, authorRole
	, roleCode
	, ratePER
	, rateMEC
) 
select
	  t1.Wic											as Wic
	, t1.seqNr											as seqNr
	, trim(t1.IP_BASE_NR)								as IP_BASE_NR
	, left(t1.authName, 254)							as authorName
	, left(t1.authLstName, 254)							as lstName
	, left(t1.authFstName, 254)							as fstName
	, trim(t1.IPInr)									as IPInr
	, t1.IntrPtyRol 									as authorRole
	, dbo.fnCreativeRoleTypeForWic(t1.IntrPtyRol) 		as roleCode
	, t1.ratePer										as ratePER
	, t1.rateMec										as rateMEC
from #TmpWIC t2
	join vWidSrObjectAuthorsEx t1  on t2.Wic = t1.Wic 
 --where isnull(t1.authName, '') <> ''

--Только Авторы/правовласники (т.е. без исполнителей)
delete #TmpAuthors
insert into #TmpAuthors (
	  IP_BASE_NR
	, authorName
	, lstName
	, fstName
	, IPInr
	, roleCode
	, isAnk
)
select 
	  max(IP_BASE_NR)
	, max(authorName)
	, max(lstName)
	, max(fstName)
	, max(IPInr) as IPInr
	, max(roleCode) as roleCode
    , max(case 
			when isnull(ratePER, 0) + isnull(rateMEC, 0) <> 0 then 1 
			else												   0 
		  end
	  )
from #TmpObjectAuthor 
where IP_BASE_NR is not null
group by IP_BASE_NR

; with AuthorSoc as (
	select
		  IpBaseNr	  as IpBaseNr
		, RgtCde	  as RgtCde
		, min(SocCde) as SocCde
	from SocIpi..IpiAgreement
	where RgtCde in ('PR', 'MR')
		and getdate() between FromDt and ToDt
	group by IpBaseNr, RgtCde
)
update #TmpAuthors
set 
	  CmCodePER = t2.SocCde
	, CmCodeMEC = t3.SocCde
from #TmpAuthors t1
	left join AuthorSoc t2 on t1.IP_BASE_NR = t2.IpBaseNr and t2.RgtCde = 'PR'
	left join AuthorSoc t3 on t1.IP_BASE_NR = t3.IpBaseNr and t2.RgtCde = 'MR'

--У нас д.б. открыты ОКУ иностранные
update #TmpAuthors 
set
	  CmCustIdMEC = t2.custId
	, CmCustIdPER = t3.custId
from #TmpAuthors t1 
    left join community t2 on t2.interCode = t1.CmCodeMEC 
	left join community t3 on t3.interCode =  t1.CmCodePER  

--AUTHORS - ИДЕНТИФИКАЦИЯ
--По IPInr = IPIBase и IP_BASE_NR
update #TmpAuthors
set rhCustId = t2.custId 
from #TmpAuthors t1
    join RightHolder t2 on t1.IP_BASE_NR = trim(t2.interCode)

update #TmpAuthors
set rhCustId = t2.custId 
from #TmpAuthors t1
	join RightHolder t2 on t1.IPInr = trim(t2.IPIBase)
where t1.rhCustId is NULL 

--21-04-2020 Begin
update #TmpAuthors set rhCustId = t2.custId 
from #TmpAuthors t1 
    join vCustomerRHolder t2 on t1.authorName = t2.name
where  isnull(t1.rhCustId,0) = 0 

--21-04-2020 End

--проставила идентификацию авторов
update #TmpObjectAuthor set rhCustId = t2.rhCustId 
  from #TmpObjectAuthor t1 
  join #TmpAuthors t2 on t2.IPInr = t1.IPInr
   where isnull(t2.rhCustId,0) <> 0

--Исполнители 
delete #TmpPerformer
insert into #TmpPerformer (WIC, SeqNr, Name)
 select t2.WIC, t2.SeqNr, t2.PerfArtistLstName + isnull(' '+t2.PerfArtistFstName,'') 
   from #TmpWIC t1 
     join SocWid..WidArtist t2 on t1.WIC = t2.WIC

--select * from WID_IPI_..wSeekPerformer
--select * from SocWid..widArtist

---Добавляю альтернативных исполнителей из отчета, если таких нет
insert into #TmpPerformer (WIC, SeqNr, Name) 
 select  t2.WIC, -1, t2.performer
   from #TmpWIC t1 
     join RegisterItem t2 on t1.WIC = t2.WIC 
   where isnull(performer,'') <> '' and 
     not exists (select  1 from #TmpPerformer t3 where t3.name = t2.performer and t3.wic = t2.wic)

---Идентификация исполнителей
update #TmpPerformer set perId = t2.perId 
  from #TmpPerformer t1,  
       Performer t2 
   where t1.name = t2.perName

 
--Альтернативные названия из базы
delete #TmpSeekObject 
insert into #TmpSeekObject (codei, WIC, name) 
  select distinct 1, t1.WIC, t2.AltTtl 
    from #TmpWIC t1 
       join SOcWid..widAltTtl  t2 on t1.WIC = t2.WIC 

--Альтернативные названия из отчета
insert into #TmpSeekObject (codei, WIC, name) 
  select distinct 1, t2.WIC, t2.ItemName  
   from #TmpWIC t1 
     join RegisterItem t2 on t1.WIC = t2.WIC 
   where not exists (select  1 from #TmpSeekObject t3 where t2.wic = t3.wic and t2.ItemName = t3.name )
    

BEGIN TRANSACTION INPUTWID

	BEGIN TRY
   RAISERROR (N'pTsk10_InputWID - BEGIN!', 0, 127) WITH NOWAIT
   
    exec pTsk10_InputWID 
   
    RAISERROR (N'pTsk10_InputWID - END!', 0, 127) WITH NOWAIT
 --
 update RegisterItem 
  set objid = t2.objid 
  from RegisterItem t1 
     join #TmpObjectRight t2 on t2.WIC = t1.WIC
  where isnull(t1.objid,0) = 0

--Меняю статусы на обработанный или ошибки

if not exists (select  1 from registerItem where regid = 976 and isnull(objid,0) = 0 )
   and not exists (select  1 from RegisterCCIDAuthor where regid = 976 and isnull(custId,0) = 0 )
  update Register set rgStatus = 7 
   where regId = 976 and rgStatus in (3, 12)
         and not exists (select 1 from RegisterItem t2 where regId = 976 and objid is NULL)

--пока не убираю
if exists (select 1 from RegisterCCIDAuthor where regid = 976 and isnull(custId,0) = 0 ) 
 or exists (select 1 from RegisterItem where regid = 976 and isnull(objid,0) = 0 )
  update Register set rgStatus = 6  --помилки синхронізації, нужно разбираться
   where regId = 976 


PRINT 'Ok!'

IF @@TRANCOUNT > 0 commit tran
END TRY

BEGIN CATCH
  IF @@TRANCOUNT > 0 rollback tran
  

   SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_SEVERITY() AS ErrorSeverity  
        ,ERROR_STATE() AS ErrorState  
        ,ERROR_PROCEDURE() AS ErrorProcedure  
        ,ERROR_LINE() AS ErrorLine  
        ,ERROR_MESSAGE() AS ErrorMessage;  

  END CATCH
     
end     
go
