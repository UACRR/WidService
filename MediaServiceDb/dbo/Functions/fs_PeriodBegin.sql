--drop FUNCTION dbo.fMyCountry 
CREATE FUNCTION [dbo].[fs_PeriodBegin] (@periodType integer, @date date)
RETURNS date
    WITH EXECUTE AS CALLER 
    as
    BEGIN 
    declare  @result date
    IF @periodType = 1 --Щомісячно 
	  set @result = dateadd(day,1-day(@date),@date) 

     IF @periodType = 2 --Щоквартально 
	  set @result = (dateadd(qq, datediff(qq, 0, @date), 0))  
	  
     IF @periodType = 3 --1 раз на півроку
	  set @result = convert(date, '01.'+convert(char(2), (case when FLOOR (12/month(@date))<=1 Then '07' else '01' end))+'.'+convert(char(4),year(@date)) , 104)

     IF @periodType = 4 --1 раз на рік
	  set @result = convert(date, '01.01.'+convert(char(4),year(@date)))

    IF @periodType = 5 --одноразово
	  set @result = @date

	RETURN @result
END
--select dbo.fs_PeriodBegin (1, getdate())