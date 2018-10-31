--drop procedure dbo.DelRequest   
---------------------
CREATE PROCEDURE dbo.DelRequest   
  @ReqId  integer
  AS   
--Удаляет, если деньги не распределены. 
--Откатывает проводки по дебиторке

declare @RetCode integer, @ErrMsg varchar(200) 
set @RetCode = 0
set @ErrMsg = ''

--Проверка на наличие оплат
/*
IF exists ( select 1 from Request where ReqId = @ReqId  and isnull(reqstatus,0) in (4,5,6,7) )
 Begin 
   set @RetCode = 1
   set @ErrMsg = 'Уже выполнены операции, после которых удаление невозможно!'
   Return @Retcode
 end 
*/
BEGIN 
begin Transaction Request 
  BEGIN TRY

/*
 If Exists ( select 1 from Request where ReqId = @ReqId  and isnull(reqstatus,0) = 3)
 begin
  --вызов процедуры отката проводок
   Exec Pay_Pay_1_D29_K19_rollback @reqId
   Return @Retcode
 end
*/
delete from PaymentCase where ReqId = @ReqId

delete from ReqLocationUse where ReqId = @ReqId
delete from RelReqMedia where ReqId = @ReqId
delete from RelMovieEpisode where ReqId = @ReqId
delete from RelGenreMovie where ReqId = @ReqId
delete from RequestMovie where ReqId = @ReqId
delete from RequestOther where ReqId = @ReqId
delete from RelTVEpisode where ReqId = @ReqId
delete from RequestTVRadio where ReqId = @ReqId
delete from RequestInternet where ReqId = @ReqId
delete from RequestAdvertising where ReqId = @ReqId
delete from RelSerialEpisode where ReqId = @ReqId
delete from RelGenreSerial where ReqId = @ReqId 
delete from RequestSerial where ReqId = @ReqId
delete from RelAdaptUseArea where ReqId = @ReqId
delete from RelGenreAdapt where ReqId = @ReqId
delete from ReqAgreement where ReqId = @ReqId
delete from reqTrade where ReqId = @ReqId


update document set docStatus = 99 
 from document t1 
       join DocReq t2 on t1.docId = t2.docId 
 where reqId = @reqId 

update invoice set status = 99 
 from invoice t1 
       join DocReq t2 on t1.docId = t2.docId 
 where reqId = @reqId

delete DocReq where   ReqId = @ReqId 
delete invoice   where status = 99
delete document  where docStatus = 99

delete from RequestAdapt where ReqId = @ReqId
delete from request     where ReqId = @ReqId
--Удаляю все, на кот. нет ссылок
delete ReqCustomer 
    where not exists ( select 1 from  Request q 
             where ReqCustomer.ReqCustId = q.reqCustId ) 



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
exec DelRequest  29
*/--