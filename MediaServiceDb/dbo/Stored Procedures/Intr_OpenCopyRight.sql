--Авторы-объекты-процент
--drop table #TmpRH
--Открытие CopyRight со статусом=3 - заблоковано. Должны быть выполнены скрипты открытия правообладателей и объектов
/*
alter table test..Go_InCRight 
add cRightId integer 

update test..Go_InCRight set cRightId = NULL
*/
---------------------------------------
CREATE PROCEDURE Intr_OpenCopyRight 
as
begin
--Внесение процентов
SET NOCOUNT ON;

declare @RetCode integer
set @RetCode = 0

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
         select  t1.custId, t1.objid, 1, t1.rate, 0, '1900-01-01', '3000-01-01', getdate(), getdate(), t1.roleCode, 
                 (Case  t2.custType WHEN 5 Then 0 Else 1 END), --Статус для чужих анкет не подтвержденный, для своих - подтвержденный
                 cast(t1.id as char(10))  --чтобы записать ключи
           from test..Go_InCRight t1
                join vCustomer t2 on t1.custId = t2.custId 
            where isnull(t1.cRightId,0) = 0 and  isnull(t1.custId,0)<>0 and isnull(t1.objid,0)<>0 and isnull(t1.roleCode,0) not in (0,3) 

          update test..Go_InCRight  
             set cRightId = t2.cRightId
             from  test..Go_InCRight t1 
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

--exec Intr_OpenCopyRight 
--select * from test..GO_InCRight where isnull(crightId,0) = 0 and isnull(roleCode,0) <> 3