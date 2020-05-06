
/*
create table #TmpTabAuthors 
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
*/
CREATE PROCEDURE [dbo].[pTsk10_LoadAuthors_TEST] 
as
begin
SET NOCOUNT ON;
--Загрузка информации авторов из WID_IPI 
--Запись в RepMSWIC, repMSIPI - таблица соответствия ключей.
--Если по какой-то причине остались авторы не открыты - статус = 6 (ошибки синхронизации)
--Алгоритм. Проверяю не обработанные из таблицы  #TmpIPI
/*
drop table #TmpAuthors
*/

declare @RetCode integer = 0, @date datetime = getdate()

create table #TmpId 
(id integer, loadId_S varchar(20), loadId_I integer)

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
--Только Авторы/правовласники (т.е. без исполнителей)
--IP_BASE_NR = interCode --это уникальный международный код. 
--IPInr = IPIBase --это уникальный код автора в WID_IPI, при этом IP_BASE_NR м.б. один и тот же для разных IPInr. , беру максимальный

--Проверяю ОКУ авторов. Если поменялось - закрываю сегодняшним днем старое, открываю завтрашним новое

delete #TmpAuthors
insert into #TmpAuthors (IP_BASE_NR, authorName, lstName, fstName, IPInr, CmCodePER, CmCodeMEC, rhCustId, roleCode )
select max(t1.IP_BASE_NR), max(authorName), max(lstName), max(t1.FSTNAME), 
max(IPInr) as IPInr,  --max(IP_NAME_NR) as IPInr, 
max(CmCodePER), max(CmCodeMEC), max(rhCustId) as rhCustId, max(roleCode) as roleCode
  from ##TmpTabAuthors t1 
  group by IP_BASE_NR

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

--Так как заводят как попало
update #TmpAuthors set rhCustId = t2.custId 
  from #TmpAuthors t1, 
       RightHolder t2 
   --where t1.IPInr = t2.IPIBase 
   where t1.IPInr = t2.interCode 
	   and t1.rhCustId is NULL 

--По ФИО
declare @accuracy float = 0.9, @precision float = 0.001;
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
--      and t2.IPIBase is null  --это только я  проставляю автоматически)  --поиск только не по авторам из WID (они только по IP_base_nr)

BEGIN TRANSACTION INPUTIPI
	BEGIN TRY
    RAISERROR (N'pTsk10_LoadAuthor - BEGIN!', 0, 127) WITH NOWAIT

--declare @RetCode integer = 0, @date datetime = getdate()    
 delete #TmpId
--Правообладатели - Открываю не найденные
 insert into Customer (custType, status, loadId)
  output inserted.custId, inserted.loadId into #TmpId (Id, loadId_I)
  select 5, 0,  convert(integer, IPInr)
    from #TmpAuthors 
    where isnull(rhCustId,0) = 0

 update #TmpAuthors set rhCustId = t2.id, custIdNew = t2.id
   from #TmpAuthors t1,  
        #TmpId t2 
     where  convert(integer, t1.IPInr) = t2.loadId_I 

update ##TmpTabAuthors set rhCustid = t2.rhCustId, custIdNew = t2.custIdNew 
  from ##TmpTabAuthors t1 
    join #TmpAuthors t2 on t1.IPInr = t2.IPInr

insert into RightHolder (custId, rHolderType, interCode, innerCode, IPIBase, comment,  aroundWord) 
   select custIdNew, (Case When roleCode = 8 Then 3 Else 1 END), t1.IP_BASE_NR, custIdNew, t1.IPInr, 'WID_IPI', NULL 
    from #TmpAuthors t1  
	where isnull(t1.custIdNew,0) <> 0

 insert into AnketaExternal (custId, name, firstName, countryCode) 
   select custIdNew, lstName, fstName, NULL
    from #TmpAuthors t1  
	where isnull(custIdNew,0) <> 0

----Регистрация правообладателя
create table #TmpService
(custId integer not null, 
 CRKindCode  integer not null,
 ourService tinyint, 
 primary key (custId, CRKindCode) )

create table #CustCmRight 
(custId integer, 
 custIdNew integer, 
 cRKindCode integer, 
 cmCustId integer, 
 dateBegin date, 
 dateEnd date )

--Если %=0 по механике - без группы 2. Если %=0 по публичке - без групп 1, 2, 4, 5.
declare @myCmCode char(3) 
set @myCmCode = (select left(max(interCode),3) from vMyAnk) 

---Устанавливаю коды соответствия публички и механики
declare @KindGroupPER integer, @KindGroupMEC integer
set @KindGroupPER = (select  max(crGroupCode) from vRelSchemaKindCode where CDE = 'PER' )
set @KindGroupMEC = (select  max(crGroupCode) from vRelSchemaKindCode where CDE = 'MEC' )

--Сначала проверяю то, что есть и сравниваю. Если регистрация отличается - закрываю, ниже открываю
---TermsOfService 
---Мой сервис = 1,  =0 - не мой сервис
delete #TmpService
insert into  #TmpService (custId, CRKindCode, ourService)
select t1.rhCustId, t2.codeI, 
       (Case WHEN isnull(t1.CmCodePER,0) = @myCmCode and t2.crGroupCode = @KindGroupPER THEN 1 
		  ELSE (CASE WHEN isnull(t1.CmCodeMEC,0) = @myCmCode and t2.crGroupCode = @KindGroupMEC THEN 1 ELSE  0 END ) END ) as ourService
	  from  #TmpAuthors t1 
	  full outer join CopyrightKind t2 on t2.codei <> 0

 update TermsOfService set ourService = t1.ourService 
     from  TermsOfService t0 
	   join #TmpService t1 on t1.CustId = t0.custId and t1.CRKindCode  = t0.CRKindCode 
	 where t0.ourService <> t1.ourService 
	 
 insert into TermsOfService (custId, crKindCode, ourService) 
   select  custId, crKindCode, ourService
     from #TmpService t1
	  join #TmpAuthors t2 on t1.custId = t2.rhCustId 
	 where not exists (select  1 from TermsOfService t3 where t1.custId = t3.custId and t1.crKindCode = t3.crKindCode)
	 
--Строю таблицу прав для порции
--Механика
insert #CustCmRight (custId, custIdNew, cRKindCode, cmCustId, dateBegin, dateEnd) 
select  t1.rhCustId, t1.custIdNew, t2.codeI, t3.custId, cast(getdate() as date), '3000-01-01' 
   from #TmpAuthors t1 
	 inner join CopyrightKind t2 on t2.crGroupCode = @KindGroupMEC
	 join Community t3 on t3.interCode = t1.CmCodeMEC 
  where isnull(t1.custIdNew,0) <> 0 

--Публичка
insert #CustCmRight (custId, custIdNew, cRKindCode, cmCustId, dateBegin, dateEnd) 
select  t1.rhCustId, t1.custIdNew, t2.codeI, t3.custId, cast(getdate() as date), '3000-01-01' 
   from #TmpAuthors t1 
	 inner join CopyrightKind t2 on t2.crGroupCode = @KindGroupPER
	 join Community t3 on t3.interCode = t1.CmCodePER 
   where isnull(t1.custIdNew,0) <> 0 

--Удаляю одинаковую регистрацию
delete #CustCmRight 
  from #CustCmRight t1 
   join CustCmRight t2 on t1.custId = t2.custId and t1.cRKindCode = t2.cRKindCode and t1.dateBegin between t2.dateBegin and t2.dateEnd and t1.cmCustId = t2.cmCustId

--Для журнала - фиксирую изменения
create table #TmpIdCm
(custId integer, 
 cRKindCode integer, 
 cmCustIdOld integer, 
 cmCustId integer
)

--Остались изменения и новые
---Закрываю измененное
update CustCmRight set dateEnd = cast(getdate() as date) 
  output inserted.custId, inserted.cRKindCode, deleted.cmCustId, inserted.cmCustId into #TmpIdCm (custId, cRKindCode, cmCustIdOld, cmCustId)
  from CustCmRight t1 
   join #CustCmRight t2 on t1.custId = t2.custId and t1.cRKindCode = t2.cRKindCode and t2.dateBegin between t1.dateBegin and t1.dateEnd 
  where t1.cmCustId <> t2.cmCustId

--Вставляю новое
insert CustCmRight (custId, cRKindCode, cmCustId, dateBegin, dateEnd) 
output inserted.custId, inserted.cRKindCode, inserted.cmCustId into #TmpIdCm (custId, cRKindCode, cmCustId)
select  custId, cRKindCode, cmCustId, dateBegin, '3000-01-01' 
   from #CustCmRight t1 
    
--------------------------------------------------------------------
--Журналы WID для дальнейшей синхронизации данных
--Записываю в таблицы соответствия)
  insert into RepMSIPI (custId, IP_BASE_NR, IPInr, dateCreate) 
  select distinct  t1.custIdNew, t1.IP_BASE_NR, t1.IPInr, @date
    from #TmpAuthors t1 
	where isnull(custIdNew,0) <> 0 
	  and not exists (select  1 from repMSIPI t2 where t2.custId = t1.custIdNew and t2.IP_BASE_NR = t1.IP_BASE_NR)

--Записываю в журнал событий
insert into SystemMessage (modifydate, nameMain, name, keyObj, text, sysname, custId)
 select  getdate(), 'Transfer', 'Зміна реєстрації Автора', t2.rhCustId,
        'Зміна SOC '+ t2.authorName+' '+convert(char(3),t1.cRKindCode) +' '+convert(varchar(10),t1.cmCustIdOld)+'->' +convert(varchar(10),t1.cmCustId),
		 'pTsk10_TransferAuthors', t2.rhCustId
  from #TmpIdCm t1 
   join #TmpAuthors t2 on t1.custid = t2.rhCustId
  where isnull(t2.custIdNew,0) = 0 

insert into SystemMessage (modifydate, nameMain, name, keyObj, text, sysname, custId)
 select  getdate(), 'Transfer', 'Відкриття зовнішніх Автора', t2.custIdNew,
        'Відкриття'+ t2.authorName,
		 'pTsk10_TransferAuthors', t2.custIdNew
  from #TmpAuthors t2 
  where isnull(t2.custIdNew,0) <> 0 

	
  update ##TmpTabAuthors set rhcustId = t2.rhcustId, custIdNew = t2.custIdNew
    from ##TmpTabAuthors t1 
    join #TmpAuthors t2 on t1.IP_Base_nr = t2.IP_Base_nr

  update ##TmpTabAuthors set rhcustId = t2.rhcustId, custIdNew = t2.custIdNew
    from ##TmpTabAuthors t1 
    join #TmpAuthors t2 on t1.IPInr = t2.IPInr 
   where isnull(t1.rhcustId,0) = 0

RAISERROR (N'pTsk10_LoadAuthor - END!', 0, 127) WITH NOWAIT
 --


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
    
------------------------------------------------------
return @Retcode
END

--exec pTsk10_LoadAuthors
--select * from #TmpTabAuthors

