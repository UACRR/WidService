ALTER PROCEDURE [dbo].[pTsk10_DDEXFormRate] @DdexReportId integer
as
--Процедура проставляет общий процент по произведению. С учетом исключений.
--@DdexReportId = ddexreportid

begin
SET NOCOUNT ON;
declare @RetCode integer = 0, @cnt_All integer, @cnt_Err integer

--Отбираю для кого ставить %
 create table #TmpLog
(  ddexreportid integer not null, 
   blockid varchar(10) not null, 
   salestransactionid varchar(100) not null, 
   rateTotalPER decimal(5,2), 
   rateTotalMEC decimal(5,2)
   primary key (ddexreportid, blockid, salestransactionid)
)

--Сначала проставляю признак - отбирать не отбирать
--1-отбирать, 0-не отбирать
--Если есть договор с обществом и не попал в исключение - берем.
--Нужно еще добавть проверку на договор с правом

--Отбираю  для работы с учетом исключений
 insert into #TmpLog  ( ddexreportid, blockid, salestransactionid, rateTotalPER, rateTotalMEC) 
 select t1.ddexreportid, t1.blockid, t1.salestransactionid, 
        sum(t1.ratePER * includPER) as rateTotalPER, 
		sum(t1.rateMEC * includMEC) as rateTotalMEC
   from IdentMWAuthor t1
	 join IdentBacklog t2 on  t1.ddexreportid = t2.ddexreportid and t1.blockid = t2.blockid and t1.salestransactionid = t2.salestransactionid 
   where t1.DdexReportId  in (select id from ft_AgreementReportIds(@DdexReportId))
     and t1.excStatusPer > 0  --прошло исключения
   group by t1.ddexreportid, t1.blockid, t1.salestransactionid

 update #TmpLog set rateTotalMEC = 0  where rateTotalMEC > 100 
 update #TmpLog set rateTotalPER = 0  where rateTotalPER > 100 


--Контроль 
--Если отправили уже, а процент изменился - просто сообщение! 
  set @cnt_Err = ( select count(*)  
      from IdentBacklog t1 
      join #TmpLog t2 on t2.DdexReportId = t1.ddexreportid 
	                and t2.BlockId = t1.blockid
  					and t2.SalesTransactionId = t1.salestransactionid
       where t1.DdexReportId  in (select id from ft_AgreementReportIds(@DdexReportId))
			and t1.includedInCCID is not NULL 
             and  (t1.rateTotalMEC <> t2.rateTotalMEC  or  t1.rateTotalPER <> t2.rateTotalPER) )

--только по неотправленным закомментровано, т.е. все  
 update IdentBacklog set rateTotalMEC = t2.rateTotalMEC,
                         rateTotalPER = t2.rateTotalPER
   from IdentBacklog t1 
     join #TmpLog t2 on t2.DdexReportId = t1.ddexreportid 
	                and t2.BlockId = t1.blockid
  		        and t2.SalesTransactionId = t1.salestransactionid
   where t1.DdexReportId  in (select id from ft_AgreementReportIds(@DdexReportId)) --and t1.includedInCCID is NULL 

   set @cnt_All = @@ROWCOUNT

 
 PRINT 'Оброблено: '+convert(varchar(10), @cnt_All)+ '      Контроль: Змінився % у відправлених - '+convert(varchar(10), @cnt_Err)

  return @Retcode
END

--exec pTsk10_DDEXIdentMWAuthor 1
--exec pTsk10_DDEXExceptionStatus 1
--exec pTsk10_DDEXFormRate 1
--select sum(NetRevenue) from IdentBacklog where isnull(rateTotalMEC,0)+isnull(rateTotalPER,0) > 0  --5770.53
--select * from IdentBacklog where isnull(rateTotalMEC,0)+isnull(rateTotalPER,0) > 0  -1485

GO


