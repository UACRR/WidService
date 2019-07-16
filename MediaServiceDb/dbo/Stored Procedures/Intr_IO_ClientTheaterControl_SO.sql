
CREATE  PROCEDURE Intr_IO_ClientTheaterControl_SO
as
begin

--Импорт КЛИЕНТОВ -ТЕАТРОВ - контроль
--V1

SET NOCOUNT ON;
declare @RetCode integer, @tprt varchar(100)
set @RetCode = 0

 create table #TmpId (id integer, custId integer)
 create table #TmpIdEx (id integer, custId integer)


 BEGIN TRAN IO_TheaterControl
 BEGIN TRY

update LOADS..ImportClientTheater set errFlag = NULL, errComment = NULL  where workFlag = 1

update  LOADS..ImportClientTheater set custId = t2.custId, errFlag = 1, errComment = 'Вже відкриті клієнти'
    from LOADS..ImportClientTheater t1 
      join vcustomer t2 on upper(REPLACE(t2.name,' ','')) = upper(REPLACE(t1.name,' ',''))
     where t1.workFlag = 1

update  LOADS..ImportClientTheater set errFlag = isnull(errFlag,0) + 1, errComment = isnull(errComment,'') + 'OKPO вже існують в Системі'
  from LOADS..ImportClientTheater t1 
  join vcustomer t2 on t2.INNOKPO = t1.OKPO and t2.InnOKPO is not NULL --REPLACE(t2.INNOKPO,' ','') = REPLACE(t1.OKPO,' ','')
 where t1.custId is null and  t1.workFlag = 1

----Place
/*
 update LOADS..ImportClientTheater  set placeCode = t2.codeI, 
              errFlag    = isnull(errFlag,0)+(Case When t2.codeI is NULL Then  1 Else 0 end), 
              errComment = isnull(errComment, '') + (Case When t2.codeI is NULL Then  'Тип майданчика.' Else NULL end) 
  from LOADS..ImportClientTheater t1 
       left join TypePlace t2 on upper(t1.placeCodeName) = upper(t2.name)
  where t1.custid is NULL and  t1.workFlag = 1
 */

 update LOADS..ImportClientTheater  set placeCode = 6 
    where custid is NULL and  workFlag = 1

--Region
 update LOADS..ImportClientTheater  set jaRegionCode = t2.codeI
	  from LOADS..ImportClientTheater t1, 
	   region t2 
	where left(t1.jaRegionName, 7) = left(t2.name,7) collate Ukrainian_100_CI_AS
	   and jaRegionCode Is NULL 
       and t1.custid is NULL  and  t1.workFlag = 1

--Period
 update LOADS..ImportClientTheater  set periodCode = t2.codeI
	  from LOADS..ImportClientTheater t1, 
	   Period t2 
	where left(t1.periodCodeName, 7) = left(t2.name,7) collate Ukrainian_100_CI_AS
	   and periodCode Is NULL 
       and t1.custid is NULL  and t1.workFlag = 1

-----------------------------------------

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
    return @Retcode
    END CATCH

--Проверка
select * from LOADS..ImportClientTheater where isnull(errFlag,0) = 1 

return @Retcode
END

--EXEC Intr_IO_ClientTheaterControl_SO