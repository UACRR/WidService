CREATE PROCEDURE [dbo].[pTsk10_LoadWICRegister] @regId integer  = NULL
as
begin
SET NOCOUNT ON;
--Загрузка информации по WIС из WID_IPI по ид.отчета или все, которые готовы и не загружены
--работает по Register.regStatus = 3. После отработки устанавливает статус 7 (6-ошибка синхонизации)
--Запись в RepMSWIC, repMSIPI - таблица соответствия ключей.  WLObjectAuthor, WLAuthors - журнал загрузки данных, нужно периодически очищать, пока временно для проверки.
--(Распределение работает с 7).
--18-10-2019. DDeX. Без указания @regId работает по всем отчетам кроме алгоритма algorithm=4 (ddex)
--29-10-2019. Сразу перевожу статус
--Если по какой-то причине остались авторы не открыты - стату = 6 (ошибки синхронизации)
/*
drop table #TmpWIC 
drop table #TmpObjectRight 
drop table #TmpObjectAuthor
drop table #TmpAuthors
drop table #TmpPerformer
*/

declare @RetCode integer = 0, @date datetime = getdate()

if exists (select  1 from vMyAnk where typeAlg = 2)  --SO
 BEGIN 
 update Register set rgStatus = 7 
   where rgStatus = 3
 return @Retcode
 END 

--Сразу перевожу статус для идентифицированный по нашей базе
update Register set rgStatus = 7 
  from Register t1 
   where t1.rgStatus = 3
         and not exists (select 1 from RegisterItem t2 where t1.regId = t2.regId and t2.objId is NULL)


declare @accuracy float = 0.9, @precision float = 0.001;

create table #TmpWIC 
(WIC integer not null primary key, 
 objid integer null)

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
--drop table #TmpObjectAuthor
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
--drop table #TmpAuthors 
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

create table #TmpPerformer
(id integer not null identity primary key, 
 WIC integer, 
 seqNr smallint,
 name varchar(254), 
 ISRC varchar(20), 
 perId integer null
)

--Альтернативные названия из базы
create table #TmpSeekObject 
(WIC integer, 
 name varchar(100), 
 codeI integer, 
 primary key (WIC, name) 
)

create table #regId (regid integer not null primary key) 

--Отбираю с какими отчетами работать. Без указания @regId работает по всем отчетам кроме алгоритма algorithm=4 (ddex)
 --declare @regId integer = 7431
 insert into #regId (regId) 
  select regId 
    from Register t1
	where t1.rgStatus in (3, 12)  --12 - для гугла
	    and t1.regId = isnull(@regId, t1.regId) 
        and ( (isnull(t1.algorithmId,0) <> 4 and isnull(@regId,0) = 0) OR (isnull(@regId,0) <> 0) )
		and exists (select 1 from RegisterItem t2 
					    where t2.regId = t1.regId and isnull(WIC,0) <> 0  and isnull(objid,0) = 0)
 
declare cur cursor for select regId from #regId 

open cur                                                   

    fetch cur into   @regId
                                                  
    while @@fetch_status = 0                                                   
    BEGIN 

delete #TmpWIC 
delete #TmpObjectRight 
delete #TmpObjectAuthor
delete #TmpAuthors
delete #TmpPerformer
delete #TmpSeekObject 

insert into #TmpWIC (WIC)
select distinct t0.WIC  
 from RegisterItem t0 
  where regId = @regId
  --where regId = 7431
   and isnull(WIC,0) <> 0 and isnull(objid,0) = 0

IF @@ROWCOUNT >0 
BEGIN 
--Если уже загружали раньше такие WIC
update #TmpWIC set objId = t2.objid 
  from #TmpWIC t1 
     join REPMSWIC t2 on t1.WIC = t2.WIC 

--на всякий случай
update #TmpWIC set objId = t2.objid 
  from #TmpWIC t1 
     join objectRight t2 on t2.loadId = cast(t1.WIC as varchar(10)) and t2.sourceName = 'WID_IPI'
	 and t1.objId is NULL 

--Проставляю сразу в RegisterItem
 update RegisterItem set objid = t2.objid 
    from RegisterItem t1 
    join #TmpWIC t2 on t2.WIC = t1.WIC 
	  where isnull(t2.objid,0) <> 0 

 delete #TmpWIC where isnull(objid,0) <> 0

  if (select count(*) from #TmpWIC) <> 0 
 BEGIN 
    Print 'Register = '+cast(@regId as varchar(10))

-----Заполняю таблицы для загрузки
--Объекты права
delete #TmpObjectRight 
insert  #TmpObjectRight 
(WIC,  genreType,  --41
 name,  iswc,  author,  lyrics, composers, performers,
 genre, specType,   --MOD = 3, ORI = 1 
 duration
)
select t1.WIC, 41, t1.name, iswc, left(authors,254), left(lirics,254), left(composers, 254), left(performers,254), t1.genreName 
 ,1 --(Case When specName ='MOD' then 3 else 1 END), 
 ,NULL --duration 
 from #TmpWIC  t2
   join  WID_IPI..wObject t1 on t2.WIC = t1.WIC

--Авторы
delete #TmpObjectAuthor 
insert into  #TmpObjectAuthor 
(  WIC, seqNr, 
   IP_BASE_NR, 
   authorName, lstName, fstName, 
   IPInr, authorRole, 
   roleCode, 
   ratePER, rateMEC) 
select t1.WIC, seqNr
       ,IP_BASE_NR
	   ,left(lstName + isnull(' '+(fstname),''), 254), left(lstName,254), left(fstName,254)
	   ,IPInr
	   ,IntrPtyRol 
      /*,(Case  WHEN IntrPtyRol = 'CA' Then 10 ELSE 
                  Case WHEN IntrPtyRol in ('E', 'SE') Then 8 ELSE 
                       CASE WHen IntrPtyRol in ('A', 'AD', 'AR') Then 1 ELSE 2
       END End End )*/
	   ,roleCode 
       ,ratePer
	   ,rateMec
from #TmpWIC t2
  join wid_ipi..wObjectAuthor t1  on t2.WIC = t1.WIC 
 where isnull(t1.lstName,'') <> ''

/*
--Для ddex нужно добавить недостающих авторов из отчета (таблица RegisterCCIDAutho), CUSTID=NULL
insert into #TmpObjectAuthor 
(  WIC, seqNr, 
   IP_BASE_NR, 
   authorName, lstName, fstName, 
   IPInr, authorRole, 
   roleCode, 
   ratePER, rateMEC)  
 select t3.WIC, 0, t1.IP_BASE_NR, '!', '!', '!', '!', 10, t1.ratePER, t1.rateMEC
 from RegisterCCIDAuthor t1 
    join #regId t2 on t1.regId = t2.regId  
    join  RegisterItem t3 on t3.regId = t1.regId and t3.regIItemId = t1.regIItemId 
  where t1.custId is NULL 
    and not exists (select  1 from #TmpObjectAuthor t4 where t4.WIC = t3.WIC and t4.IP_BASE_NR = t1.IP_BASE_NR )
   --and t1.regId = 7431 and t1.regIItemId = 6315
*/

--Только Авторы/правовласники (т.е. без исполнителей)
--IP_BASE_NR = interCode --это будет  международный код, беру максимальный. --это уникальноый код автора в WID_IPI
--IPInr = IPIBase    
delete #TmpAuthors
insert into #TmpAuthors (IP_BASE_NR, authorName, lstName, fstName, IPInr, roleCode, isAnk)
select max(IP_BASE_NR), max(authorName), max(lstName), max(fstName), max(IPInr) as IPInr, max(roleCode) as roleCode, 
       max((Case WHEN isnull(ratePER,0)+isnull(rateMEC,0) <> 0 Then 1 Else 0 END))
  from #TmpObjectAuthor 
--  where IPInr is not NULL
--  group by IPInr
  where IP_BASE_NR is not NULL
  group by IP_BASE_NR

update #TmpAuthors set CmCodePER = t2.SOC_CDE, 
                       CmCodeMEC = t3.SOC_CDE
  from #TmpAuthors t1
       left join WID_IPI..wCmAuthor t2 on t1.IP_Base_nr = t2.Ip_base_nr and t2.RGT_CDE = 'PR'
	   left join WID_IPI..wCmAuthor t3 on t1.IP_Base_nr = t3.Ip_base_nr and t2.RGT_CDE = 'MR'

--У нас д.б. открыты ОКУ иностранные
update #TmpAuthors set CmCustIdMEC = t2.custId, 
                       CmCustIdPER = t3.custId
  from #TmpAuthors t1 
       left join community t2 on t2.interCode = t1.CmCodeMEC 
	   left join community t3 on t3.interCode =  t1.CmCodePER  

--AUTHORS - ИДЕНТИФИКАЦИЯ
--По IPInr = IPIBase и IP_BASE_NR
update #TmpAuthors set rhCustId = t2.custId 
  from #TmpAuthors t1, 
       RightHolder t2 
   --where t1.IPInr = t2.IPIBase 
   where t1.IP_BASE_NR = t2.interCode 
update #TmpAuthors set rhCustId = t2.custId 
  from #TmpAuthors t1, 
       RightHolder t2 
   --where t1.IPInr = t2.IPIBase 
   where t1.IPInr = t2.IPIBase 
	   and t1.rhCustId is NULL 

--По ФИО
--declare @accuracy float = 0.9, @precision float = 0.001;
update #TmpAuthors set rhCustId = t2.custId 
  from #TmpAuthors t1, 
       vCustomerRHolder t2 
   where 
      isnull(t1.rhCustId,0) = 0 
      and left(REPLACE(t1.authorName, ' ',''),3) = left(REPLACE(t2.name, ' ',''),3)
--      and dbo.Ft_tsk_3_Accurace ( t1.lstName, t2.lastName, 0.001 ) >= 0.4
      and dbo.Ft_tsk_3_Accurace ( t1.lstName, t2.lastName, @precision ) >= @accuracy
      and left(t1.fstName,1) = left(t2.firstName,1)
	    and dbo.Ft_tsk_3_Accurace ( REPLACE(t1.fstName, ' ',''), REPLACE(t2.firstName,' ',''), @precision ) >= @accuracy
--      and dbo.Ft_tsk_3_Accurace ( REPLACE(t1.fstName, ' ',''), REPLACE(t2.firstName,' ',''), 0.001 ) >= 0.4
      and t2.IPIBase is null

--проставила идентификацию авторов
update #TmpObjectAuthor set rhCustId = t2.rhCustId 
  from #TmpObjectAuthor t1 
  join #TmpAuthors t2 on t2.IPInr = t1.IPInr
   where isnull(t2.rhCustId,0) <> 0

--Исполнители 
insert into #TmpPerformer (WIC, SeqNr, Name)
 select t2.WIC, t2.SeqNr, t2.lstNa + isnull(' '+t2.fstNa,'') 
   from #TmpWIC t1 
     join WID_IPI..wSeekPerformer t2 on t1.WIC = t2.WIC

---Добавляю альтернативных исполнителей из отчета, если таких нет
insert into #TmpPerformer (WIC, SeqNr, Name) 
 select  t2.WIC, -1, t2.performer
   from #TmpWIC t1 
     join RegisterItem t2 on t1.WIC = t2.WIC 
   where not exists (select  1 from #TmpPerformer t3 where t3.name = t2.performer and t3.wic = t2.wic)

---Идентификация исполнителей
update #TmpPerformer set perId = t2.perId 
  from #TmpPerformer t1,  
       Performer t2 
   where t1.name = t2.perName

 
--Альтернативные названия из базы
insert into #TmpSeekObject (codei, WIC, name) 
  select distinct 1, t1.WIC, t2.name 
    from #TmpWIC t1 
       join WID_IPI..wSeekObject  t2 on t1.WIC = t2.WIC 

--Альтернативные названия из отчета
insert into #TmpSeekObject (codei, WIC, name) 
  select 1, t2.WIC, t2.ItemName  
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

--Журнал записи. Можно удалить после стабилизации задачи
/*
 insert into WLObjectAuthor
( dateCreate, WIC, seqNr, IP_BASE_NR, lstName, fstName, authorName, IPInr, authorRole, roleCode, ratePER, rateMEC, rhCustId, custIdNew, perId,
 cRightId, objid, idLoad, custIdSub, dateEndSub) 
 select @date, WIC, seqNr, IP_BASE_NR, lstName, fstName, authorName, IPInr, authorRole, roleCode, ratePER, rateMEC, rhCustId, custIdNew, perId,
 cRightId, objid, id, custIdSub, dateEndSub
  from #TmpObjectAuthor 

--Журнал записи. Можно удалить после стабилизации задачи
insert into WLAuthors ( createDate, IPInr, IP_BASE_NR, lstName, fstName, custIdNew, roleCode, CmCodePER, CmCodeMEC, cmCustIdPER, cmCustIdMEC ) 
 select @date, IPInr, IP_BASE_NR, lstName, fstName, custIdNew, roleCode, CmCodePER, CmCodeMEC, cmCustIdPER, cmCustIdMEC 
   from #TmpAuthors 
   where isnull(custIdNew,0) <> 0
*/

--Меняю статус на обработанный

update RegisterCCIDAuthor set custId = t2.custId 
  from RegisterCCIDAuthor t1 
    join rightHolder t2 on t2.interCode = t1.IP_BASE_NR
  where t1.regId = @regId  --7431
    and isnull(t1.custId,0) = 0

update Register set rgStatus = 7 
   where regId = @regid and rgStatus in (3, 12)
         and not exists (select 1 from RegisterItem t2 where regId = @regId and objid is NULL)

if exists (select 1 from RegisterCCIDAuthor where regid = @regId and isnull(custId,0) = 0 ) 
  update Register set rgStatus = 6  --помилки синхронізації, нужно разбираться
   where regId = @regid 

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

 set @Retcode = 1
 --return @Retcode
 END CATCH
    

 END 
------------------------------------------------------
END --If @ROWCOUNT > 0
    fetch cur into   @regId
    END                                                   

close cur   
deallocate cur      

return @Retcode
END

--exec pTsk10_LoadWICRegister 7424
