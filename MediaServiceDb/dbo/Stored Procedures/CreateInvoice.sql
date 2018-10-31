---------------------

CREATE PROCEDURE dbo.CreateInvoice ( @reqId  integer )
AS   
Begin
SET NOCOUNT ON;   --отключение вывода кол-ва строк для оптимизации
declare @Retcode integer, @custId integer, @docNumber varchar(64), @docId integer

 If not exists ( select 1 from request where reqId = @reqId ) 
    Return 1

set @custId = (select reqId from request where reqid = @reqId) 

create table #RT
( 
  reqId           integer not null primary key, 
  payCustId       integer not null, --плательщик
  recCustId       integer not null, --получатель  
  payAnk          integer null,  --версия анкеты 
  recAnk          integer null, 
  r030            char(3) null, 
  Amount          money   null, 
  payMFO          integer null,
  payBankName     varchar(254)  null,
  recMFO          integer null,
  recBankName     varchar(254)  null,
  purpose         varchar(3000) null, --назначение платежа
 )

insert into #RT 
( reqId, payCustId, recCustId,  r030, Amount, payMFO, payBankName, recMFO, recBankName, purpose) 
select  r1.reqId, r1.custId, m1.custId, r1.r030, r1.reqAmount, m1.myMFO, m1.myBankName,  a1.custMFO, a1.custBankName, 'Назначение платежа'
 from ft_PrtmyAnk (NULL) m1, 
  request r1 
  join ft_PrtCustAnk (@reqId, NULL, NULL) a1 on r1.reqId = @reqId and r1.custId = a1.custId  


begin Transaction CreateInvoice 
    BEGIN TRY

set @docNumber = (select dbo.f_docNumber (5))
--Document
 insert into Document 
  ( docTypeCode, docDate, docNumber)    --, docFile, docStatus )
  select 5, convert(date, getdate()), @docnumber

 set @docId = (select docId from document where docNumber = @docNumber and docTypeCode = 5)
  
  insert into docreq (docId, reqId)
     select @docId, @reqId  
 
  insert into invoice ( docId, payCustId, recCustId, payAnk, recAnk, r030, Amount, recMFO, recBankName, purpose )
  select @docId, payCustId, recCustId, payAnk, recAnk, r030, Amount, recMFO, recBankName, purpose 
         from #RT

 IF @@TRANCOUNT > 0 commit tran
END TRY

BEGIN CATCH
  IF @@TRANCOUNT > 0 rollback tran
    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;
    SELECT @ErrorMessage = ERROR_MESSAGE(),
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

RETURN 
END  

--exec dbo.CreateInvoice 55