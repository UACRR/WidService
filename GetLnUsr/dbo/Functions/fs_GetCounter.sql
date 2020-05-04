
create FUNCTION dbo.fs_GetCounter ( @docType integer, @licType integer)
--Возвращает номер документа по типу документа или лиц.договора 
RETURNS varchar(25)
 WITH EXECUTE AS CALLER 
 as
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
           and t1.docType = @docType )
   
  /*update CounterNumber 
       set cNum = isnull(cNum,0) +1
	  where counterId = @counterId*/

    set @Result = (select prefix+substring(convert(char(7),1000000+cNum+1),2,6)+isnull(symbolN,'')+
      (Case When isnull(templYear,0) = 2 Then  substring(convert(char(4),year(getdate())),3,2) 
           Else Case When  isnull(templYear,0) = 4 Then convert(char(4),year(getdate())) Else '' end end)
       from CounterNumber where counterId = @counterId )

 RETURN @Result
END

--select dbo.Fs_getCounter (5,10)
