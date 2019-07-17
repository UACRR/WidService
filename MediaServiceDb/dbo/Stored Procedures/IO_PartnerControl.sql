

CREATE PROCEDURE [dbo].[IO_PartnerControl]
as begin 

SET NOCOUNT ON;

declare @RetCode integer = 0

---Контроли
------------------------------------------------
update LOADS..ImportPartner set errFlag = NULL, errComment = NULL where workFlag = 1

BEGIN Transaction PartnerControl
 BEGIN TRY


--Нахожу клиентов уже открытых
update  LOADS..ImportPartner set custId = t2.custId, errFlag = 1, errComment = 'Вже відкриті клієнти'
    from LOADS..ImportPartner t1 
      join vcustomer t2 on upper(REPLACE(t2.name,' ','')) = upper(REPLACE(t1.partnerName ,' ',''))
    where  workFlag = 1 

--Region
--по таблице перекордировки
 update LOADS..ImportPartner  set faRegionCode = t2.codeI, 
                                 errComment = isnull(errComment, '') + (Case When t2.codeI is NULL Then  'Регіон.' Else '' end) 
	  from LOADS..ImportPartner t1 
	     left join region t2 on  left(t1.faRegionName, 7) = left(t2.name,7) collate Ukrainian_100_CI_AS
       where  t1.custid is NULL --and jaRegionCode Is NULL and
	   
update LOADS..ImportPartner  set 
                   errComment = isnull(errComment, '') + (Case When t1.periodCode is NULL Then  'Період.' Else '' end) 
	  from LOADS..ImportPartner t1
	  where  t1.periodCode Is NULL  and t1.custid is NULL

--email
update LOADS..ImportPartner set errFlag = 1, errComment =  isnull(errComment,'') + ' Дубль email!' 
  from LOADS..ImportPartner t1, 
    (select email  from LOADS..ImportPartner  group by email  having count(*) > 1 )  t2 
 where t1.email = t2.email 

update LOADS..ImportPartner set errFlag = 1, errComment =  isnull(errComment,'') + ' Дубль email (є у базі)!' 
  from LOADS..ImportPartner t1, 
       AnketaPerson  t2 
 where t1.email = t2.email 

 update LOADS..ImportPartner set errFlag = 1, errComment =  isnull(errComment,'') + ' Тип клієнта!' 
  where isnull(custType, 0) not in (1,2,3)
 

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

END CATCH

 IF EXISTS (select top 1 1 from LOADS..ImportPartner where isnull(errFlag,0) <> 0 )
    BEGIN 
      PRINT 'Знайдено помилки!'
	  --RAISERROR (N'Знайдено помилки!', 16, 127) --WITH NOWAIT
      select * from LOADS..ImportPartner where isnull(errComment,'') <>  ''
    END 
  ELSE 
   PRINT 'Помилок не знайдено! Є повідомлення...'
   --select * from LOADS..ImportPartner where isnull(errComment,'') <>  ''
return @Retcode
END
--exec IO_PartnerControl 