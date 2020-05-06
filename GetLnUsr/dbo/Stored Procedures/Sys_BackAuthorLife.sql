
CREATE PROCEDURE Sys_BackAuthorLife @custIdForLife integer
--права возвращают @custIdForLife
as
begin
SET NOCOUNT ON;
------
declare @RetCode integer 
set @RetCode = 0

 begin tran DEL
 BEGIN TRY

 update AgreementMaster set agrStatus = 0 
  where custId = @custIdForLife and agrStatus = 7 

 update AgreementAddRH set agrStatus = 0 
    from AgreementAddRH t1 
	   join AgreementMaster t2 on t2.agrId = t1.agrId 
  where t2.custId = @custIdForLife 


 ;with TabCR as 
 ( select  t1.cRightId, t3.endDate
  from CopyRight t1 
    join CopyRightHistory t2 on t2.parentId = t1.cRightId 
	join CopyRight t3 on t3.cRightId = t2.childId 
  where t1.custId = @custIdForLife
 )
update CopyRight set endDate = t2.endDate
  from CopyRight t1 
    join TabCR t2 on t2.cRightId = t1.cRightId
  where t1.custId = @custIdForLife

 create table #TmpId (id integer not null primary key)
 delete copyRightHistory 
 output deleted.childId into #TmpId (id)
    from copyRightHistory t1 
	  join copyright t2 on t2.cRightId = t1.parentId
	where t2.custId = @custIdForLife

 delete CopyRight 
   from CopyRight t1 
    join #TmpId t2 on t2.id = t1.cRightId
	
 print 'Повернулось: записів правоволодіння - ' + cast (@@rowcount as varchar(20))

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

--exec Sys_BackAuthorLife 1368


