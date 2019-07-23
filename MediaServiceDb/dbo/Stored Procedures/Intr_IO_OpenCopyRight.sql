/*
update loads..ImportObject set cRightId = NULL
*/
---------------------------------------
CREATE PROCEDURE Intr_IO_OpenCopyRight 

as
begin
--Главная процедура рагрузки объектов права 
SET NOCOUNT ON;

declare @RetCode integer
set @RetCode = 0

---Процедура подготовки информации
---Все коды проставляются в таблице заранее
---Открываются с признаком workFlag = 1

--Уже есть авторы и проценты
;with TabCR as 
(
select  t1.custid, t1.objid , sum(t1.rate) as rate, max(cRightId) as cRightId
    from copyright t1
    where getdate() between isnull(t1.begindate, '1900-01-01') and isnull(t1.endDate, '3000-01-01') 
    group by t1.custId, t1.objid 
)
  update loads..ImportObject set cRightId = t2.cRightId 
    from loads..ImportObject t1 
       join TabCR t2 on t2.custId = t1.custid and t1.objid = t2.objid and t1.rate = t2.rate 
     where isnull(workFlag,0) = 1 
          and isnull(t1.errFlag,0) = 1 
          and isnull(t1.cRightId,0) = 0

---Проценти більше 100 - как-то проверить

--drop table #TabId
create table #TabId (cRightId integer not null, id integer)

declare @cRightId integer

    begin tran Ins
     BEGIN TRY

     delete #TabId 

        --Вставляю как підтверджені для имеющих анкет и не підтверджені для чужих
        --CopyRight
	 insert into CopyRight (custId, objId, lBasis, rate, roleRate, beginDate, endDate, createDate, modifyDate, roleCode, status, lBasisComment)
         output inserted.cRightId, cast(inserted.lBasisComment as integer) into #TabId (cRightId, id)
         select  t1.custId, t1.objid, 1, t1.rate, 0, cast(getdate() as date), '3000-01-01', getdate(), getdate(), t1.roleCode, 
                 (Case  t2.custType WHEN 5 Then 0 Else 1 END), --Статус для чужих анкет не подтвержденный, для своих - подтвержденный
                 cast(t1.id as char(10))  --чтобы записать ключи
           from loads..ImportObject t1
                join vCustomer t2 on t1.custId = t2.custId 
            where isnull(t1.cRightId,0) = 0  and  isnull(t1.custId,0)<>0 and isnull(t1.objid,0)<>0 and isnull(t1.roleCode,0) not in (0,3) 
                  and isnull(errFlag,0) = 0 
                  and isnull(workFlag,0) = 1 

          update loads..ImportObject  
             set cRightId = t2.cRightId
             from  loads..ImportObject t1 
                 join #TabId t2 on t1.id = t2.id

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

return @Retcode
END

--exec Intr_IO_OpenCopyRight 