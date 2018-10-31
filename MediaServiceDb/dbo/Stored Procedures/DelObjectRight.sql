---------------------
CREATE PROCEDURE dbo.DelObjectRight   
  @Objid  integer
  AS   

declare @RetCode integer, @ErrMsg varchar(200) 
set @RetCode = 0
set @ErrMsg = ''

BEGIN 

 set @RetCode = 0

--Проверка на наличие остатков
IF exists ( select 1 from SaldoDay t0 join Account t1 on (t0.accId = t1.accId) 
              where t1.ObjId = @ObjId  and isnull(t0.rest,0) <> 0 ) 
 Begin 
   set @RetCode = 1
   set @ErrMsg = 'Виявлено операції по обєкту права!'
 end 

IF exists ( select 1 from request where objid = @objid ) 
 Begin 
   set @RetCode = 1
   set @ErrMsg = @ErrMsg + ' Виявлено заявки на обєкт права!'
 end 

  If @Retcode <> 0 
   Begin 
     Set @ErrMsg = 'Операцію перевано!'+' '+@ErrMsg 
	 RAISERROR
    (N'%s',
    10, -- Severity.
    1, -- State.
    @ErrMsg  -- First substitution argument.
     ); -- Second substitution argument.

   Return @Retcode
   end


begin Transaction DelObj 
  BEGIN TRY

delete Account     where objId = @objid
--!!!Физически удалить файл по пути MediaTrack.path
delete MediaFile 
  from  MediaFile  t0 join MediaTrack t1 on (t0.objid = t1.objid) 
  where t1.objId = @objid
delete MediaTrack  where objId = @objid 
delete relObjGenre where objId = @objid 
delete LocationExept 
  from LocationUse  t0 join CopyRight t1 on ( t0.CrightId = t1.CrightId) 
  where t1.objId = @objid 
delete LocationUse 
  from LocationUse  t0 join CopyRight t1 on ( t0.CrightId = t1.CrightId) 
  where t1.objId = @objid 
delete CopyRight   where objId = @objid
delete ObjectRight where objId = @objid

 IF (@@TRANCOUNT > 0 and @RetCode = 0 ) commit tran
END TRY


BEGIN CATCH
  IF (@@TRANCOUNT > 0 or @RetCode <> 0 ) rollback tran
    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;
    SELECT @ErrorMessage = @ErrMsg + ' '+ERROR_MESSAGE(),
           @ErrorSeverity = ERROR_SEVERITY(),
           @ErrorState = ERROR_STATE();

    -- Use RAISERROR inside the CATCH block to return 
    -- error information about the original error that 
    -- caused execution to jump to the CATCH block.
    RAISERROR (@ErrorMessage, -- Message text.
               @ErrorSeverity, -- Severity.
               @ErrorState -- State.
               );
 set @Retcode = 1

END CATCH

Return @Retcode
END

/*---
exec DelObjectRight  1
*/--