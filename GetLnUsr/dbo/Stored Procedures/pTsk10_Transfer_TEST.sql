/****** Object:  StoredProcedure [dbo].[pTsk10_LoadWICRegister]    Script Date: 21.11.2019 13:55:21 ******/
CREATE PROCEDURE [dbo].[pTsk10_Transfer_TEST] 
as
begin
SET NOCOUNT ON;
--Загрузка информации по изменениям в WID_IPI 
--Запись в RepMSWIC, repMSIPI - таблица соответствия ключей.  --WLObjectAuthor, WLAuthors - журнал загрузки данных, нужно периодически очищать, пока временно для проверки.
--Если по какой-то причине остались авторы не открыты - статус = 6 (ошибки синхронизации)
--Алгоритм. Проверяю не обработанные из таблицы TransferIPI, TransferObject. Обрабатываю и ставлю идентификаторы, статус и дату.

--Отбираю данные для трансфера

declare @retCode integer = 0, @date datetime = getdate()

/*
create table ##tmpIPI 
(IP_BASE_NR varchar(20) not null primary key )

create table ##tmpWIC 
(WIC Integer not null primary key)

create table ##tmpSOC 
(SOC varchar(3) not null primary key )

create table ##tmpIPISOC
(IP_BASE_NR varchar(20) not null, 
 SOC varchar(3) not null, 
 primary key (IP_BASE_NR, SOC) )

create table ##tmpTabAuthors 
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

--drop table ##tmpTabObjectAuthor
create table ##tmpTabObjectAuthor
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

create table ##tmpTabPerformer
(id integer not null identity primary key, 
 WIC integer, 
 seqNr smallint,
 name varchar(254), 
 ISRC varchar(20), 
 perId integer null
)

create table ##tmpTabSeekObject 
( WIC integer, 
  name varchar(100), 
  codeI integer, 
  primary key (WIC, name) 
)

create table ##tmpTabObjectRight 
(WIC integer not null, 
 objId integer,
 objIdNew integer, 
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
*/
---Блок Заполнения информации для обработки 
--ОП
delete ##tmpWIC
insert into  ##tmpWIC (WIC) 
  select WIC 
     from  WID_IPI..TransferObject  
     where isnull(status,0) = 0 
	 group by WIC 

--Загружаю авторов ОП в таблицу трансфера
 insert into WID_IPI..TransferIPI (IP_Base_nr) 
    select  IP_Base_nr 
       from  ##tmpWIC t1 
         join WID_IPI..wObjectAuthor t2 on t1.WIC = t2.WIC 
       group by t2.IP_Base_NR 

/*
--Авторы по ОП
 delete ##tmpIPI
 insert into ##tmpIPI (IP_Base_nr) 
    select  IP_Base_nr 
       from  ##tmpWIC t1 
         join WID_IPI..wObjectAuthor t2 on t1.WIC = t2.WIC 
       group by t2.IP_Base_NR 
*/
  
--Авторы отдельно из репликации
 insert into ##tmpIPI (IP_Base_nr) 
    select  IP_Base_nr 
       from WID_IPI..TransferIPI t1
       where isnull(status,0) = 0 
         and not exists (Select  1 from ##tmpIPI t2 where t1.IP_BASE_NR = t2.IP_BASE_NR) 
      group by IP_Base_nr

 --Заполняю ОКУ для автров 
 insert into ##tmpIPISOC (SOC, IP_Base_NR)
 select SOC_CDE, t2.IP_Base_NR
    from ##tmpIPI t1 
      join wid_ipi..wCmAuthor t2 on t1.IP_BASE_NR = t2.IP_BASE_NR 
   group by SOC_CDE, t2.IP_Base_NR

-------------------- --Заполняю новые ОКУ  в ##tmpSOC и вызываю  pTsk10_LoadSOC
 insert into ##tmpSOC (SOC)
  select SOC
    from ##tmpIPISOC t1 
    where not exists (select  1 from community t2 where t1.SOC = t2.interCode) 
    group by t1.SOC 

-------------------------
--Блок Обработка информации
--Открываю новые ОКУ
--declare @retCode integer
  exec @retCode = pTsk10_LoadSOC 

 If @retCode <> 0 
  BEGIN 
    Print 'Помилки трансферу ОКУ!!!'
    insert into SystemMessage (modifydate, nameMain, name, keyObj, text, sysname, custId)
    select  getdate(), 'Transfer', 'Помилки трансферу ОКУ!!!', NULL, 'Внесення техн. дог. з ОКУ  ', 'pTsk10_TransferSOC', NULL
   Return @RetCode 
  END 

----------Авторы по IPI.
---Заполняю информацию по авторам. 
delete ##tmpTabAuthors
insert into ##tmpTabAuthors (IP_BASE_NR, authorName, lstName, fstName, IPInr, CmCodePER, CmCodeMEC)
select max(IP_BASE_NR), max(authorName), max(Name), max(t1.FST_NAME), max(IP_NAME_NR) as IPInr, max(CmCodePER), max(CmCodeMEC)
  from vWIDTransferIPI t1 
  where isnull(status,0) = 0 
  group by IP_BASE_NR


update ##tmpTabAuthors set CmCodePER = t2.SOC_CDE, 
                          CmCodeMEC = t3.SOC_CDE
  from ##tmpTabAuthors t1
       left join WID_IPI..wCmAuthor t2 on t1.IP_Base_nr = t2.Ip_base_nr and t2.RGT_CDE = 'PR'
	   left join WID_IPI..wCmAuthor t3 on t1.IP_Base_nr = t3.Ip_base_nr and t2.RGT_CDE = 'MR'

--У нас д.б. открыты ОКУ иностранные
update ##tmpTabAuthors set CmCustIdMEC = t2.custId, 
                       CmCustIdPER = t3.custId
  from ##tmpTabAuthors t1 
       left join community t2 on t2.interCode = t1.CmCodeMEC 
	   left join community t3 on t3.interCode =  t1.CmCodePER  

----В вызываемой процедуре сверка регистрации в ОКУ и открытие новых
--declare @retCode integer
-- exec @retCode = pTsk10_LoadAuthors
 
 If @retCode <> 0 
  BEGIN 
    Print 'Помилки трансферу Авторів!!!'
    insert into SystemMessage (modifydate, nameMain, name, keyObj, text, sysname, custId)
    select  getdate(), 'Transfer', 'Помилки трансферу Авторів!!!', NULL, 'Відкриття анкет зовнішніх авторів - помилка ', 'pTsk10_LoadAuthors', NULL
   Return @RetCode 
  END 
  
------------------------------------------
--Открытие ОП и правовладения

delete ##tmpTabObjectRight 
insert  ##tmpTabObjectRight 
(WIC,  genreType,  name,  iswc,  author,  lyrics, composers, performers,  genre, specType,   --MOD = 3, ORI = 1 
 duration
)
select t1.WIC, 41, t1.name, iswc, left(authors,254), left(lirics,254), left(composers, 254), left(performers,254), t1.genreName 
  ,1 --(Case When specName ='MOD' then 3 else 1 END), 
  ,NULL --duration 
 from ##tmpWIC  t2
 join  WID_IPI..wObject t1 on t2.WIC = t1.WIC

--Авторы права на ОП
delete ##tmpTabObjectAuthor 
insert into  ##tmpTabObjectAuthor 
(  WIC, seqNr, IP_BASE_NR, authorName, lstName, fstName, IPInr, authorRole, roleCode, ratePER, rateMEC) 
select t1.WIC, seqNr,IP_BASE_NR,left(lstName + isnull(' '+(fstname),''), 254), left(lstName,254), left(fstName,254)
	   ,IPInr, IntrPtyRol, roleCode, ratePer, rateMec
  from ##tmpWIC t2
  join wid_ipi..wObjectAuthor t1  on t2.WIC = t1.WIC 
  where isnull(t1.lstName,'') <> ''

 --Авторы д.б. все уже открыты
 update ##tmpTabObjectAuthor set rhCustId = t2.rhCustId 
   from ##tmpTabObjectAuthor t1 
    join ##tmpTabAuthors t2 on t2.IPInr = t1.IPInr

 update ##tmpTabObjectAuthor set rhCustId = t2.CustId 
   from ##tmpTabObjectAuthor t1 
    join RepMSIPI t2 on t2.IP_BASE_NR = t1.IP_BASE_NR

 update ##tmpTabObjectAuthor set rhCustId = t2.custId 
  from ##tmpTabObjectAuthor t1 
   join vCustomerRHolder t2 on t1.IP_Base_NR = t2.interCode 

 update ##tmpTabObjectAuthor set rhCustId = t2.custId 
  from ##tmpTabObjectAuthor t1 
   join vCustomerRHolder t2 on t1.IPInr = t2.IPIBase

--Альтернативные названия из базы
delete ##tmpTabSeekObject
insert into ##tmpTabSeekObject (codei, WIC, name) 
  select distinct 1, t1.WIC, t2.altTtl
    from ##tmpWIC t1 
       join WID_IPI..TblAltTtl  t2 on t1.WIC = t2.WIC 

--Исполнители
insert into ##tmpTabPerformer (WIC, seqNr, name, ISRC) 
  select t2.WIC, max(SeqNr) as SeqNr, trim(t2.LstNa+' '+T2.fstNa) as name, MAX(ISRC) as ISRC
   from ##tmpWIC t1 
     join WID_IPI..TblArtist t2 on t1.WIC = t2.WIC 
    group by t2.WIC, trim(t2.LstNa+' '+fstNa) 

-------
/*
    RAISERROR (N'pTsk10_InputWID - BEGIN!', 0, 127) WITH NOWAIT

    exec pTsk10_LoadObjectRight

    RAISERROR (N'pTsk10_InputWID - END!', 0, 127) WITH NOWAIT
*/
-------

--Меняю статус на обработанный

update WID_IPI..TransferObject  set objid = t1.objid, status = 1, transferDate = getdate()
  from WID_IPI..TransferObject t1 
    join ##tmpWIC t2 on t2.WIC = t1.WIC 
  where t1.status = 0

update WID_IPI..TransferIPI set custId = t1.custId, status = 1, transferDate = getdate() 
  from WID_IPI..TransferIPI t1 
    join ##tmpIPI t2 on t2.IP_BASE_NR = t1.IP_BASE_NR
  where t1.status = 0
  
return @Retcode
END

--exec pTsk10_Transfer_TEST
/*
select * from RepMSIPI where dateCreate > '2019-12-10'
select * from RepMSWIC where dateCreate > '2019-12-10'
select * from wid_ipi..transferIPI
select * from wid_ipi..transferObject
*/
