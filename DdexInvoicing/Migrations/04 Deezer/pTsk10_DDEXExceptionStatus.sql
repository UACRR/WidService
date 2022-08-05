ALTER PROCEDURE [dbo].[pTsk10_DDEXExceptionStatus] @DdexReportId integer, @setId integer 
as
--Процедура установки статуса исключения. 1-Ок, 2-исключен
--@fileId = ddexreportid, @setId - ид. набора исключений

begin
SET NOCOUNT ON;
declare @RetCode integer = 0

 create table #TmpAuthor
(  id                   int                  not null primary key,
   mwId                 integer              not null,
   IP_BASE_NR           varchar(13)          null,
   IPInr                varchar(13)          null,
   cmCodePER            varchar(3)           null,
   cmCodeMEC            varchar(3)           null,
   excIdPER             int                  null,
   excStatusPER         integer              null,
   excIdMEC             int                  null,
   excStatusMEC         integer              null,
   roleCode             integer              null,
   ratePer	            decimal(5,2)         null,
   rateMec	            decimal(5,2)         null, 
   includPER            bit	                 null,
   includMEC            bit                  null, 
   custId               integer              null
)
create index i_1 on #TmpAuthor(IP_Base_NR)
create index i_2 on #TmpAuthor(IPInr)

--Отбираю идентификаторы для работы
 insert into #TmpAuthor  (id, mwId, IP_Base_Nr, IPInr, cmCodePer, cmCodeMec, roleCode, excStatusPER, excStatusMEC, ratePer, rateMec, custId) 
 select id, mwId, IP_Base_Nr, IPInr, cmCodePer, cmCodeMec, roleCode, 
         (CASE WHEN cmCodePER is NULL then 2 else 1 end), 
		 (CASE When cmCodeMEC is NULL THEN 2 Else 1 end), ratePer, rateMEC, custId
   from IdentMWAuthor
   where DdexReportId  in (select id from ft_AgreementReportIds(@DdexReportId))
     and isnull(excStatusPER,0) = 0
 
 --Исключаются сложно
  --update #TmpAuthor set excId = NULL
--3-если есть E с алг3-> др авторы обслуживаются в ОКУ из ADD или ОКУ не визначено -> Е исключается
--Исключаю ПУБЛИЧКА и МЕХАНИКА отдельно
--  Update #TmpAuthor set  excId = NULL
 Update #TmpAuthor set  excIdPER = t2.id, excStatusPER = 2
    from #TmpAuthor t1 
      join  ExceptionMember t2 on t2.IPInr = t1.IPInr and excType = 3 and t1.roleCode = 8 
    where isnull(t1.excIdPER,0) = 0 
       and t2.setCode = @setId 
       and exists (select  1 
	        from #TmpAuthor t5 
			   join ExceptionAdd t3 on t3.excId = t2.id and t3.interCode = isnull(t1.cmCodePER, t3.interCode)
			  where t1.mwId = t5.mwId and t5.IP_BASE_NR <> t1.IP_BASE_NR and isnull(t5.ratePER,0)<>0 ) 


Update #TmpAuthor set  excIdMEC = t2.id, excStatusMEC = 2
    from #TmpAuthor t1 
      join  ExceptionMember t2 on t2.IPInr = t1.IPInr and excType = 3 and t1.roleCode = 8 
    where isnull(t1.excIdMEC,0) = 0 
       and t2.setCode = @setId 
       and exists (select  1 
	        from #TmpAuthor t5 
			   join ExceptionAdd t3 on  t3.excId = t2.id and t3.interCode = isnull(t1.cmCodeMEC, t3.interCode)
			  where t1.mwId = t5.mwId and t5.IP_BASE_NR <> t1.IP_BASE_NR and isnull(t5.rateMec,0)<>0 ) 

--Исключаются Общества ПУБЛИЧКА и МЕХАНИКА
  Update #TmpAuthor set  excIdPER = t2.id, excStatusPER = 2
    from #TmpAuthor t1 
      join  ExceptionMember t2 on t2.interCode = t1.CmCodePER  and t2.excType = 1 
  where isnull(t1.excIdPER,0) = 0
        and t2.setCode = @setId

  Update #TmpAuthor set  excIdMEC = t2.id, excStatusMEC = 2
    from #TmpAuthor t1 
      join  ExceptionMember t2 on t2.interCode = t1.cmCodeMEC  and t2.excType = 1 
  where isnull(t1.excIdMEC,0) = 0
        and t2.setCode = @setId

--Исключаются Правообладатели ПУБЛИЧКА и МЕХАНИКА
  Update #TmpAuthor set  excIdPER = t2.id, excStatusPER = 2, excIdMEC = t2.id, excStatusMEC = 2
    from #TmpAuthor t1 
      join  ExceptionMember t2 on t1.IPInr = t2.IPInr  and excType = 2 
    where isnull(t1.excIdPER,0) = 0
          and t2.setCode = @setId

--Исключаются Правообладатели с custId <> 0, если нет активного договора
  Update #TmpAuthor set  includPER = 0, includMEC = 0
    from #TmpAuthor t1 
      join vMSCustomerRHolder t2 on t1.custId = t2.custId  and t2.agrStatus <> 2 
    where t1.custId is not NULL 

---Исключения по договорам 
--Если не отмечено право Механика или Публичка - исключаю через коеффициент includPER
/* 2020-07-16
update #TmpAuthor 
     set includPER = (CASE When t1.excStatusPER = 1 and isnull(t2.isPER,0) = 1 THEN 1 ELSE 0 END), 
	     includMEC = (CASE When t1.excStatusMEC = 1 and isnull(t3.isMEC,0) = 1 THEN 1 ELSE 0 END)
  from #TmpAuthor t1 
   left join vMSCommunity t2 on t1.cmCodePER = t2.interCode 
   left join vMSCommunity t3 on t1.cmCodeMEC = t3.interCode 
*/
--2020-07-16
--Исключения по договорам Community
--Если даты по мех/перф попадают в период - беру, если нет - не беру, includPER = 1/0 или inclusMec = 1/0
--Определяю даты периода, чтобы права брать только за этот период (хоть одна дата периода пересекается с правами)
declare @ddexReportingPeriodId integer
	, @periodDateBegin date
	, @periodDateEnd date
	, @month integer
	, @quarter integer
	, @year integer
select @ddexReportingPeriodId = ddexReportingPeriodId from vFileCcidDdex where ddexReportId = @ddexReportId
 
select @month = month
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

--Только для проверенніх (excStatusMEC = 1 - проверен)
update #TmpAuthor 
     set includPER = (CASE When t1.excStatusPER = 1 and isnull(t2.isPER,0) = 1 THEN 1 ELSE 0 END), 
	     includMEC = (CASE When t1.excStatusMEC = 1 and isnull(t3.isMEC,0) = 1 THEN 1 ELSE 0 END)
  from #TmpAuthor t1 
   left join vMSCommunity t2 on t1.cmCodePER = t2.interCode 
       and (@periodDateBegin between t2.dateBeginPER and t2.dateEndPER or @periodDateEnd between t2.dateBeginPER and t2.dateEndPER )
   left join vMSCommunity t3 on t1.cmCodeMEC = t3.interCode 
       and (@periodDateBegin between t2.dateBeginMEC and t2.dateEndMEC or @periodDateEnd between t2.dateBeginMEC and t2.dateEndMEC )
-->

---Поправочки по Оле
--временно, пока не откажится  --18-10-2019
update #TmpAuthor set cmCodeMEC = 140, cmCodePER = 140, IncludMEC = 1, IncludPER = 1
  where IP_BASE_NR = 'i-003577688-4'

update #TmpAuthor set cmCodeMEC = 140, cmCodePER = 140, IncludMEC = 1, IncludPER = 1
 from #TmpAuthor
  where IP_BASE_NR = 'i-003842830-5'

update #TmpAuthor set cmCodeMEC = '094', IncludMEC = IncludPER
  where cmCodePER = '094' and cmCodeMEC is NULL 
--Поправочки


-- select * from #TmpAuthor where excId is null
declare @cnt_all integer, @cnt_ExPER integer, @cnt_ExMEC integer
set @cnt_all = (select count(*) from #TmpAuthor)   --всего
set @cnt_ExPER = (select count(*) from #TmpAuthor where excStatusPER = 2) --исключено
set @cnt_ExMEC = (select count(*) from #TmpAuthor where excStatusMEC = 2) --исключено

 update IdentMWAuthor set excStatusPER = t2.excStatusPER, excIdPER = t2.excIdPER,  
                          excStatusMEC = t2.excStatusMEC, excIdMEC = t2.excIdMEC, 
						  IncludMEC = t2.includMEC, IncludPER = t2.includPER, 
						  cmCodeMEC = t2.cmCodeMEC, cmCodePER = t2.cmCodePER   --29-10-2019
   from IdentMWAuthor t1 
      join #TmpAuthor t2 on t1.id = t2.id 
 

 PRINT 'Оброблено: '+convert(varchar(10), @cnt_All)+'. Виключено PER: '+ convert(varchar(10), @cnt_ExPER)+'. Виключено MEC: '+ convert(varchar(10), @cnt_ExMEC)

  return @Retcode
END

--update IdentMWAuthor set excIdPER = NULL, excStatusPER = NULL, excIdMEC = NULL, excStatusMEC = NULL 
--exec pTsk10_DDEXExceptionStatus 1,1 
--select count(*) from IdentMWAuthor where ddexReportId = 1 and excStatus <> 2  --3 433 405/10 879 189
--Оброблено: 14312594. Виключено PER: 3 433 405. Виключено MEC: 1 087 294
--select top 100 * from IdentMWAuthor

GO


