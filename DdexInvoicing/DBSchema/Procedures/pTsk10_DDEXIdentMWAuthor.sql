USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[pTsk10_DDEXIdentMWAuthor]    Script Date: 12.09.2022 13:02:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[pTsk10_DDEXIdentMWAuthor] @DdexReportId integer, @isNetRevenue integer = NULL
as
--Процедура формирования IdentMWAuthor - табл.правообладателей и их процентов владения 
--@DdexReportId = ddexreportid
--@isNetRevenue = NULL, 0  - нули не беру, 1 - беру все
--2020-07-15 - CopyRight отбираю только действующие в периоде отчета

begin
SET NOCOUNT ON;
declare @RetCode integer = 0
declare @cntWID integer, @cntMS integer 

--drop table #TmpObj 
create table #TmpObj 
( tmpObjId integer not null identity,
  ddexreportid integer not null, 
  blockid varchar(10) not null, 
  salestransactionid varchar(100) not null, 
  WIC integer null, 
  objid integer null, 
  mwId integer not null,
  ValidityPeriodStart date, 
  ValidityPeriodEnd date, 
  primary key (tmpObjId) 
 )

--drop table #TmpAuthor
create table #TmpAuthor 
(  id                   int                  not null identity,
   DdexReportId         int                  not null,
   BlockId              int                  not null,
   SalesTransactionId   varchar(100)         not null,
   tmpObjId             integer              not null, 
   mwId                 int                  not null,
   WIC                  int                  null,
   objId                int                  null,
   IP_BASE_NR           varchar(13)          null,
   custId               int                  null,
   IPInr                varchar(13)          null,
   ratePER              decimal(5,2)         null,
   rateMEC              decimal(5,2)         null,
   cmCodePER            varchar(3)           null,
   cmCodeMEC            varchar(3)           null,
   rateCmPER            decimal(5,2)         null,
   rateCmMEC            decimal(5,2)         null,
   ValidityPeriodEnd    date                 null,
   ValidityPeriodStart  date                 null,
   roleCode             integer              null,
   primary key (id) 
   )
--drop table #TmpAuthorMS
create table #TmpAuthorMS
(  id                   int                  not null identity,
   DdexReportId         int                  not null,
   BlockId              int                  not null,
   SalesTransactionId   varchar(100)         not null,
   tmpObjId             integer              not null, 
   mwId                 int                  not null,
   WIC                  int                  null,
   objId                int                  null,
   IP_BASE_NR           varchar(13)          null,
   custId               int                  null,
   IPInr                varchar(13)          null,
   ratePER              decimal(5,2)         null,
   rateMEC              decimal(5,2)         null,
   cmCodePER            varchar(3)           null,
   cmCodeMEC            varchar(3)           null,
   rateCmPER            decimal(5,2)         null,
   rateCmMEC            decimal(5,2)         null,
   ValidityPeriodEnd    date                 null,
   ValidityPeriodStart  date                 null,
   roleCode             integer              null,
   primary key (id) 
   )

--Отбираю проидентифицированные записи 
delete #TmpObj  
--delete IdentMWAuthor

RAISERROR ('Отбор!', 0, 1) WITH NOWAIT 

--Определяю даты периода, чтобы права брать только за этот период (хоть одна дата периода пересекается с правами)
--declare @ddexReportId integer = 12
declare @ddexReportingPeriodId integer
	, @periodDateBegin date
	, @periodDateEnd date
	, @month integer
	, @quarter integer
	, @year integer
select @ddexReportingPeriodId = ddexReportingPeriodId from vFileCcidDdex where ddexReportId = @ddexReportId
 
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

--select @periodDateBegin, @periodDateEnd

IF isnull(@isNetRevenue, 0) = 0 
BEGIN 
insert into #TmpObj  
 ( DdexReportId, BlockId, SalesTransactionId, objId, WIC, mwId, ValidityPeriodStart, ValidityPeriodEnd )
 select distinct  t1.DdexReportId, t1.BlockId, SalesTransactionId, t3.objId, t3.WIC, t3.id, t1.ValidityPeriodStart, t1.ValidityPeriodEnd 
   from IdentBacklog t1 
   join IdentMW t3 on t1.mwId = t3.id and (isnull(t3.WIC,0) + isnull(objid,0)) <> 0
  where --t1.DdexReportId = 1 and t1.BlockId < 10000 --@DdexReportId
        t1.DdexReportId in (select id from ft_AgreementReportIds(@DdexReportId))
		and t1.NetRevenue > 0 
    and not exists 
     (select  1 from IdentMWAuthor t2 where t1.DdexReportId = t2.DdexReportId and t1.BlockId = t2.BlockId and t1.SalesTransactionId = t2.SalesTransactionId)
END 
ELSE 
BEGIN   
insert into #TmpObj  
 ( DdexReportId, BlockId, SalesTransactionId, objId, WIC, mwId, ValidityPeriodStart, ValidityPeriodEnd )
 select t1.DdexReportId, t1.BlockId, SalesTransactionId, t3.objId, t3.WIC, t3.id, t1.ValidityPeriodStart, t1.ValidityPeriodEnd 
   from IdentBacklog t1 
   join IdentMW t3 on t1.mwId = t3.id and (isnull(t3.WIC,0) + isnull(objid,0)) <> 0
  where --t1.DdexReportId = 1 and t1.BlockId < 10000 --@DdexReportId
        t1.DdexReportId in (select id from ft_AgreementReportIds(@DdexReportId))
  and not exists 
     (select  1 from IdentMWAuthor t2 where t1.DdexReportId = t2.DdexReportId and t1.BlockId = t2.BlockId and t1.SalesTransactionId = t2.SalesTransactionId)
END 


RAISERROR ('Авторы WID вносим!', 0, 1) WITH NOWAIT 
delete #TmpAuthor
--Авторы с процентами по WID
insert into  #TmpAuthor 
   (DdexReportId,  BlockId, SalesTransactionId, 
    tmpObjId, mwId, WIC, objId, 
	IP_BASE_NR, IPInr, custId, 
	ratePER, rateMEC, 
	--cmCodePER, cmCodeMEC, rateCmPER, rateCmMEC, 
	ValidityPeriodEnd, ValidityPeriodStart) 
 select  t1.DdexReportId,  t1.BlockId, t1.SalesTransactionId, 
     t1.tmpObjId, t1.mwId, t1.WIC, t1.objid, 
	 t2.IP_BASE_NR, t2.IPInr, NULL, 
	 t2.ratePER, t2.rateMEC, 
	 t1.ValidityPeriodEnd, t1.ValidityPeriodStart
    from #TmpObj t1, 
    WID_IPI..wObjectAuthor t2 
     where t1.WIC = t2.WIC 
         and t2.WIC>0 
		 and isnull(ratePER,0)+isnull(rateMEC,0) <> 0


--Международный код ОКУ-ТОВАРИСТВА
--/*
RAISERROR ('CmCodePER проставляем!', 0, 1) WITH NOWAIT 
update #TmpAuthor set CmCodePER = t2.SOC_CDE, rateCmPER = convert(decimal(5,2),t2.MBR_SHARE/100)
  from #TmpAuthor t1 
       join WID_IPI..wCmAuthor t2 on t1.IP_BASE_NR = t2.IP_BASE_NR and t2.RGT_CDE = 'PR'
  where t1.WIC is not NULL


RAISERROR ('CmCodeMEC проставляем!', 0, 1) WITH NOWAIT 
update #TmpAuthor set CmCodeMEC = t3.SOC_CDE, rateCmMEC = convert(decimal(5,2),t3.MBR_SHARE/100)   
  from #TmpAuthor t1 
	   join WID_IPI..wCmAuthor t3 on t1.IP_BASE_NR = t3.IP_BASE_NR and t3.RGT_CDE = 'MR'
   where t1.WIC is not NULL
--5.26
--*/
/* --закомментировала, т.к. выше скрипт работает быстрее
RAISERROR ('Авторы из MS - CmCode!', 0, 1) WITH NOWAIT 
update #TmpAuthor set CmCodePER = t2.SOC_CDE_PER
                     ,cmCodeMEC = t2.SOC_CDE_MEC
                     ,rateCmPER = convert(decimal(5,2),t2.MBR_SHARE_PER/100)
					 ,rateCmMEC = convert(decimal(5,2),t2.MBR_SHARE_MEC/100)
  from #TmpAuthor t1 
       join WID_IPI..vIP_SOC t2 on t1.IP_BASE_NR = t2.IP_BASE_NR
  where t1.WIC is not NULL 
--7.40
*/

RAISERROR ('Авторы из MS!', 0, 1) WITH NOWAIT 
--Авторы с процентами по MS
--2020-07-15 -- проверка прав в периоде
create table  #TmpCRightId
(cRightId integer not null primary key, 
 objid integer, 
 custId integer, 
 roleCode integer )
 
delete #TmpCRightId

 

/*--2020-07-15 до
insert into  #TmpAuthorMS
   (DdexReportId,  BlockId, SalesTransactionId, 
    tmpObjId, mwId, WIC, objId, 
	IP_BASE_NR, IPInr, custId, 
	ratePER, rateMEC, 
	--cmCodePER, cmCodeMEC, rateCmPER, rateCmMEC, 
	ValidityPeriodEnd, ValidityPeriodStart) 
 select  t1.DdexReportId,  t1.BlockId, t1.SalesTransactionId, 
     t1.tmpObjId, t1.mwId, t1.WIC, t1.objid, 
	 left(t3.interCode,13), left(t3.IPIbase,13), t2.custId, 
	 t2.rate, t2.rate, --t2.rateMECH, 
	 t1.ValidityPeriodEnd, t1.ValidityPeriodStart
    from #TmpObj t1, 
    MEDIASERVICE..copyright t2 
	join MEDIASERVICE..RightHolder t3 on t2.custId = t3.custId 
     where t1.objId = t2.objID 
	     --and t2.endDate >= t1.ValidityPeriodEnd  --так было до 2020-07-15
         and isnull(t1.objId, 0) > 0 
		 and isnull(t2.rate,0)+isnull(t2.rateMECH,0) <> 0
		 and --2020-07-15 -- проверка прав в периоде
		 ( @periodDateBegin between t2.beginDate and t2.endDate
		    or  @periodDateEnd between t2.beginDate and t2.endDate )
*/

--Из-за того, что может попасть закрытие и открытие прав в один период делаю через промежуточную таблицу
--Отбираю все, которые попадают по дате. В pTsk10_DDEXExceptionStatus отсеку, если комьюнити или договор не попадают
insert into #TmpCRightId (crightId, objid, custId, roleCode) 
select max(t2.cRightId), t2.objId, t2.custId, t2.roleCode
    from #TmpObj t1  
      join MEDIASERVICE..copyright t2 on t1.objid = t2.objId 
    where --and t2.endDate >= t1.ValidityPeriodEnd  --так было до 2020-07-15
          isnull(t1.objId, 0) > 0 
		  and isnull(t2.rate,0)+isnull(t2.rateMECH,0) <> 0 
		  and --2020-07-15 -- проверка прав в периоде
         ( @periodDateBegin between t2.beginDate and t2.endDate
		    or  @periodDateEnd between t2.beginDate and t2.endDate
			or  t2.beginDate between @periodDateBegin and @periodDateEnd
			or  t2.endDate between @periodDateBegin and  @periodDateEnd 
   		)
   group by t2.objId, t2.custId, t2.roleCode

insert into  #TmpAuthorMS
   (DdexReportId,  BlockId, SalesTransactionId, 
    tmpObjId, mwId, WIC, objId, 
	IP_BASE_NR, IPInr, custId, 
	ratePER, rateMEC, 
	--cmCodePER, cmCodeMEC, rateCmPER, rateCmMEC, 
	ValidityPeriodEnd, ValidityPeriodStart) 
 select  t1.DdexReportId,  t1.BlockId, t1.SalesTransactionId, 
     t1.tmpObjId, t1.mwId, t1.WIC, t1.objid, 
	 left(t3.interCode,13), left(t3.IPIbase,13), t2.custId, 
	 t2.rate, t2.rate, --t2.rateMECH, 
	 t1.ValidityPeriodEnd, t1.ValidityPeriodStart
    from #TmpObj t1 
    join MEDIASERVICE..copyright t2 on t1.objId = t2.objID 
	join #TmpCRightId t7 on t2.cRightId = t7.cRightId
	join MEDIASERVICE..RightHolder t3 on t2.custId = t3.custId 

RAISERROR ('Авторы из MS - CmCodePER!', 0, 1) WITH NOWAIT

drop table if exists #CustCmGroup

select *
into #CustCmGroup
from vCustCmGroup

update #TmpAuthorMS set CmCodePER = t2.interCode
  from #TmpAuthorMS t1 
       join #CustCmGroup t2 on t1.custId = t2.custId and crGroupCode = 1 
  where t1.objId is not NULL

RAISERROR ('Авторы из MS - cmCodeMEC!', 0, 1) WITH NOWAIT 
update #TmpAuthorMS set cmCodeMEC = t2.interCOde
  from #TmpAuthorMS t1 
       join #CustCmGroup t2 on t1.custId = t2.custId and crGroupCode = 2
  where t1.objId is not NULL

drop table #CustCmGroup

RAISERROR ('IdentMWAuthor 1!', 0, 1) WITH NOWAIT 
insert into IdentMWAuthor 
(  DdexReportId,  BlockId,  SalesTransactionId,
   mwId,  WIC,  objId,  IP_BASE_NR,  custId,  IPInr,
   ratePER,  rateMEC,  cmCodePER,  cmCodeMEC,  rateCmPER,
   rateCmMEC,  roleCode, 
   ValidityPeriodEnd,   ValidityPeriodStart)
 select DdexReportId,  BlockId,  SalesTransactionId,
   mwId,  WIC,  objId,  IP_BASE_NR,  custId,  IPInr,
   ratePER,  rateMEC,  cmCodePER,  cmCodeMEC,  rateCmPER,
   rateCmMEC,  roleCode, 
   ValidityPeriodEnd,   ValidityPeriodStart
 from #TmpAuthor 

 set @cntWID = @@ROWCOUNT

 RAISERROR ('IdentMWAuthor 2!', 0, 1) WITH NOWAIT 
 insert into IdentMWAuthor 
(  DdexReportId,  BlockId,  SalesTransactionId,
   mwId,  WIC,  objId,  IP_BASE_NR,  custId,  IPInr,
   ratePER,  rateMEC,  cmCodePER,  cmCodeMEC,  rateCmPER,
   rateCmMEC,  roleCode, 
   ValidityPeriodEnd,   ValidityPeriodStart)
 select DdexReportId,  BlockId,  SalesTransactionId,
   mwId,  WIC,  objId,  IP_BASE_NR,  custId,  IPInr,
   ratePER,  rateMEC,  cmCodePER,  cmCodeMEC,  rateCmPER,
   rateCmMEC,  roleCode, 
   ValidityPeriodEnd,   ValidityPeriodStart
 from #TmpAuthorMS 

 set @cntMS = @@ROWCOUNT

 PRINT 'Зовнішня база - '+convert(char(10),@cntWID)+'   Своя база - '+convert(char(10),@cntMS)

  return @Retcode
END

--exec pTsk10_DDEXIdentMWAuthor 11, 1

--delete IdentMWAuthor
--select * from IdentMWAuthor


GRANT EXEC
    ON OBJECT::[dbo].[pTsk10_DDEXIdentMWAuthor] TO [DdexRobot], [robot]
    AS [dbo];

GO

