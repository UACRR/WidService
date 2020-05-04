
CREATE PROCEDURE [dbo].[IO_ClientControl_GO] 
as begin 

SET NOCOUNT ON;

declare @RetCode integer = 0

---Контроли
------------------------------------------------
--update LOADS..ImportClient set errFlag = NULL, errComment = NULL 

BEGIN Transaction ClientControl
 BEGIN TRY

--Нахожу клиентов уже открытых
update  LOADS..ImportClient set custId = t2.custId, errFlag = 1, errComment = 'Вже відкриті клієнти'
    from LOADS..ImportClient t1 
      join vcustomer t2 on upper(REPLACE(t2.name,' ','')) = upper(REPLACE(t1.name,' ',''))

--Поиск дублей 
update  LOADS..ImportClient 
        set  errFlag = isnull(errFlag,0) + 1,  errComment = isnull(errComment,'') + 'Дублі по назві'
  from LOADS..ImportClient t1, 
  (  select name, count(*) as countZap from LOADS..ImportClient  group by name having count(*) > 1 ) as t2 
 where t1.custId is null 
      and t1.name = t2.name

update  LOADS..ImportClient 
         set  --errFlag = isnull(errFlag,0) + 1, --могут быть одинаковые
             errComment = isnull(errComment,'') + 'OKPO вже існують в Системі'
  from LOADS..ImportClient t1 
  join vcustomer t2 on t2.INNOKPO = t1.OKPO and t2.InnOKPO is not NULL --REPLACE(t2.INNOKPO,' ','') = REPLACE(t1.OKPO,' ','')
 where t1.custId is null

----Place
 update LOADS..ImportClient  set placeCode = t2.codeI, 
              errFlag    = isnull(errFlag,0)+(Case When t2.codeI is NULL Then  1 Else 0 end), 
              errComment = isnull(errComment, '') + (Case When t2.codeI is NULL Then  'Тип майданчика.' Else '' end) 
  from LOADS..ImportClient t1 
       left join TypePlace t2 on upper(t1.placeCodeName) = upper(t2.name)
  where t1.custid is NULL

--Region
 update LOADS..ImportClient  set jaRegionCode = t2.codeI, 
                                 errComment = isnull(errComment, '') + (Case When t2.codeI is NULL Then  'Регіон.' Else '' end) 
	  from LOADS..ImportClient t1 
	     left join region t2 on  left(t1.jaRegionName, 7) = left(t2.name,7) collate Ukrainian_100_CI_AS
       where jaRegionCode Is NULL and t1.custid is NULL

--LicCode
 update LOADS..ImportClient  set licCode = t2.codeI, 
                                 errComment = isnull(errComment, '') + (Case When t2.codeI is NULL Then  'Ліцензія.' Else '' end) 
	  from LOADS..ImportClient t1 
             left join  AgrLicenseType t2 on left(t1.licCodeName, 7) = left(t2.name,7) collate Ukrainian_100_CI_AS
       where licCode Is NULL  and t1.custid is NULL

--Period
 update LOADS..ImportClient  set periodCode = t2.codeI, 
                                 errComment = isnull(errComment, '') + (Case When t2.codeI is NULL Then  'Період.' Else '' end) 
	  from LOADS..ImportClient t1
	    left join Period t2  on  left(t1.periodCodeName, 7) = left(t2.name,7) collate Ukrainian_100_CI_AS
	  where  periodCode Is NULL  and t1.custid is NULL


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

 IF EXISTS (select top 1 1 from LOADS..ImportClient where isnull(errFlag,0) <> 0 )
    BEGIN 
      PRINT 'Знайдено помилки!'
	  --RAISERROR (N'Знайдено помилки!', 16, 127) --WITH NOWAIT
      select * from LOADS..ImportClient where isnull(errComment,'') <>  ''
    END 
  ELSE 
   PRINT 'Помилок не знайдено! Є повідомлення...'
   select * from LOADS..ImportClient where isnull(errComment,'') <>  ''
return @Retcode
END
--exec IO_ClientControl 
