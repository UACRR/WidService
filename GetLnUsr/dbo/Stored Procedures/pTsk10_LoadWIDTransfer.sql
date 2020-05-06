/****** Object:  StoredProcedure [dbo].[pTsk10_LoadWICRegister]    Script Date: 21.11.2019 13:55:21 ******/
CREATE PROCEDURE [dbo].[pTsk10_LoadWIDTransfer] 
as
begin
SET NOCOUNT ON;
--Загрузка информации по изменениям в WID_IPI 
--Запись в RepMSWIC, repMSIPI - таблица соответствия ключей.  WLObjectAuthor, WLAuthors - журнал загрузки данных, нужно периодически очищать, пока временно для проверки.
--Если по какой-то причине остались авторы не открыты - статус = 6 (ошибки синхронизации)
/*
drop table #TmpWIC 
drop table #TmpObjectRight 
drop table #TmpObjectAuthor
drop table #TmpAuthors
drop table #TmpPerformer
*/

declare @RetCode integer = 0, @date datetime = getdate()

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
--IP_BASE_NR = interCode --это уникальный международный код, беру максимальный. 
--IPInr = IPIBase --это уникальный код автора в WID_IPI, при этом IP_BASE_NR м.б. один и тот же для разных IPInr
delete #TmpAuthors
insert into #TmpAuthors (IP_BASE_NR, authorName, lstName, fstName, IPInr, CmCodePER, CmCodeMEC)
select max(IP_BASE_NR), max(authorName), max(Name), max(t1.FST_NAME), max(IP_NAME_NR) as IPInr, max(CmCodePER), max(CmCodeMEC)
  from vWIDTransfer t1 
  where isnull(status,0) = 0 
  group by IP_BASE_NR

--Уже можно убрать
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
      and t2.IPIBase is null  --это только я  проставляю автоматически)

BEGIN TRANSACTION INPUTWID
	BEGIN TRY
    RAISERROR (N'pTsk10_InputWID - BEGIN!', 0, 127) WITH NOWAIT
   
    exec pTsk10_InputIPI
   
  RAISERROR (N'pTsk10_InputIPI - END!', 0, 127) WITH NOWAIT
 --
 
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
update WID_IPI..TransferIPI set status = 1, transferDate = getdate() 
  from WID_IPI..TransferIPI t1 
      join #TmpAuthors t2 on t2.IP_BASE_NR = t1.IP_BASE_NR 
  where isnull(status,0) = 0

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
    
return @Retcode
END

--exec pTsk10_LoadWIDTransfer
 
