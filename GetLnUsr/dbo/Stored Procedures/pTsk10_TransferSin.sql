
CREATE PROCEDURE [dbo].[pTsk10_TransferSin] 
as
begin
SET NOCOUNT ON;
--Загрузка информации по изменениям в WID_IPI 
--Загрузка из таблиц TransferMSIPI, TransferMSWIC
--Сверка соответствия ключей по вьюшкам vRepMSWIC, vRepMSIPI  (было по таблицам, но хочу чтобы наверняка было точно)
--Запись в RepMSWIC, repMSIPI - таблица соответствия ключей.  
--Алгоритм. Проверяю не обработанные из таблицы TransferMSIPI, TransferMSWIC. Обрабатываю и ставлю идентификаторы, статус и дату.

--Отбираю данные для трансфера

declare @retCode integer = 0, @date datetime = getdate()

create table #tmpIPI 
(IP_BASE_NR varchar(20) not null primary key, 
 WIC integer null, 
 custId integer, 
 isMe integer )  --мой для обработки

create table #tmpWIC 
(WIC Integer not null primary key, 
 objid integer, 
 isMe integer)

---Блок Заполнения информации для обработки 
--ОП
delete #tmpWIC
insert into  #tmpWIC (WIC) 
  select WIC 
     from  WID_IPI..TransferObject  
     where isnull(status,0) = 0 
	 group by WIC 

--Идентифицирую по таблице и вьюшке связи
update #tmpWIC set isMe = 1, objid = t2.objid
  from #tmpWIC t1 
--    join RepMsWIC t2 on t1.WIC = t2.WIC 
      join vRepMsWIC t2 on t1.WIC = t2.WIC 

update #tmpWIC set isMe = 1, objid = t2.objid
  from #tmpWIC t1 
      join RepMsWIC t2 on t1.WIC = t2.WIC 
  where isnull(t1.objId,0) = 0 

update #tmpWIC set isMe = 1, objid = t3.objid 
  from #tmpWIC t1 
    join wid_ipi..tblISWC t2 on t1.WIC = t2.WIC     
    join MediaTrack t3 on t3.ISWC = t2.ISWC 

--Авторы  из изменений
 insert into #tmpIPI (IP_Base_nr) 
    select  IP_Base_nr 
       from WID_IPI..TransferIPI t1
       where isnull(status,0) = 0 
         and not exists (Select  1 from #tmpIPI t2 where t1.IP_BASE_NR = t2.IP_BASE_NR) 
      group by IP_Base_nr
 
 update #tmpIPI set isMe = 1, custid = t2.custId 
   from #tmpIPI t1 
--     join RepMsIPI t2 on t1.IP_BASE_NR = t2.IP_BASE_NR 
     join vRepMsIPI t2 on t1.IP_BASE_NR = t2.IP_BASE_NR 
 
 update #tmpIPI set isMe = 1, custid = t2.custId 
   from #tmpIPI t1 
     join RepMsIPI t2 on t1.IP_BASE_NR = t2.IP_BASE_NR 
   where isnull(t1.custId,0) = 0

/*
 update #tmpIPI set isMe = 1,  custid = t2.custId 
   from #tmpIPI t1 
     join vCustomerRHolder t2 on t1.IP_BASE_NR = t2.interCode 

 update #tmpIPI set isMe = 1, custid = t2.custId 
   from #tmpIPI t1 
     join vCustomerRHolder t2 on t1.IP_BASE_NR = t2.IPIBase
*/


--*Загружаю авторов ОП в таблицу трансфера
 insert into #tmpIPI (IP_Base_nr, WIC, isMe) 
    select  IP_Base_nr, max(t1.WIC) as WIC, 1
       from  #tmpWIC t1 
         join WID_IPI..wObjectAuthor t2 on t1.WIC = t2.WIC 
       where isnull(t1.isMe,0) = 1 
          and not exists (select  1 from #tmpIPI t3 where t2.IP_BASE_NR = t3.IP_BASE_NR )
       group by t2.IP_Base_NR 

-------------------------
  begin transaction Transfer 
  BEGIN TRY 

--Забираю и Меняю статус на обработанный
  insert into TransferMsObject (WIC, createDate, status) 
   select  WIC, getdate(), 0
   from #tmpWIC t1
   where t1.isMe = 1 
     and not exists (select  1 from TransferMsObject t2 where t1.WIC = t2.WIC and isnull(t2.status,0) = 0)

  Update WID_IPI..TransferObject set transferDate = getdate(), status = 1, objid = t2.objid
     from WID_IPI..TransferObject t1 
     join #tmpWIC t2 on t2.WIC = t1.WIC 
   where isnull(t1.status,0) = 0

  insert into TransferMsIPI (createDate, IP_BASE_NR, WIC, status) 
   select  getdate(), IP_BASE_NR, WIC, 0a
   from #tmpIPI t1
   where t1.isMe = 1
      and not exists (select  1 from TransferMsIPI t2 where t1.IP_BASE_NR = t2.IP_BASE_NR and isnull(t2.status,0) = 0) 

  Update WID_IPI..TransferIPI set transferDate = getdate(), status = 1, custId = t2.custId
     from WID_IPI..TransferIPI t1 
     join #tmpIPI t2 on t2.IP_BASE_NR = t1.IP_BASE_NR 
   where isnull(t1.status,0) = 0

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

--exec pTsk10_TransferSin
/*
select * from RepMSIPI where dateCreate > '2019-12-10'
select * from RepMSWIC where dateCreate > '2019-12-10'
select * from wid_ipi..transferIPI
select * from wid_ipi..transferObject
select * from transferMSIPI
select * from transferMSObject

*/

