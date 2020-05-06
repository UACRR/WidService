CREATE procedure getCounter @docType integer, @licType integer = NULL
--Возвращает номер документа по типу документа или лиц.договора 
AS 

 BEGIN 

   declare @Result varchar(25), @counterId integer = 0
   If isnull(@licType, 0) <> 0  
   set @counterId = (select  t1.counterId
     from relCounterDoc t1 
       join CounterNumber t2 on t1.counterId = t2.counterId 
           and @licType = t1.licType )
    Else 
   set @counterId = ( select  t1.counterId
     from RelCounterDoc t1 
       join CounterNumber t2 on t1.counterId = t2.counterId 
           and t1.docType = @docType and isnull(t1.licType,0) = 0)
    
   If @counterId is NULL 
   set @counterId = ( select  t1.counterId
     from RelCounterDoc t1 
       join CounterNumber t2 on t1.counterId = t2.counterId 
           and t1.docType = @docType and isnull(t1.licType,0) = 0)


  BEGIN TRY 
   BEGIN TRANSACTION  
  update CounterNumber 
       set cNum = isnull(cNum,0) +1
	  where counterId = @counterId
   COMMIT 
   END TRY

 
 BEGIN CATCH  
  -- Determine if an error occurred.  
  IF @@TRANCOUNT > 0  
     ROLLBACK  

  -- Return the error information.  
  DECLARE @ErrorMessage nvarchar(4000),  @ErrorSeverity int;  
  SELECT @ErrorMessage = ERROR_MESSAGE(),@ErrorSeverity = ERROR_SEVERITY();  
  RAISERROR(@ErrorMessage, @ErrorSeverity, 1);  
END CATCH;  

   set @Result = (select prefix+substring(convert(char(7),1000000+cNum),2,6)+isnull(symbolN,'')+
      (Case When isnull(templYear,0) = 2 Then  substring(convert(char(4),year(getdate())),3,2) 
           Else Case When  isnull(templYear,0) = 4 Then convert(char(4),year(getdate())) Else '' end end)
       from CounterNumber where counterId = @counterId )
    
 select @Result
END

--exec getCounter 5,33

--select * from counterNumber
--select * from relcounterDoc where docType = 5

--select * from CounterNumber
--update CounterNumber set prefix = 'ГВП/' where counterId = 2
