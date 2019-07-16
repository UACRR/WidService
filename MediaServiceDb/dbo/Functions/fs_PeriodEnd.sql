CREATE FUNCTION [dbo].[fs_PeriodEnd] (@periodType integer, @date date)
RETURNS date
    WITH EXECUTE AS CALLER 
    as
    BEGIN 
    declare  @result date
    IF @periodType = 1 --Щомісячно 
	  set @result = EOMONTH (@date) 

     IF @periodType = 2 --Щоквартально 
	  set @result = dateadd (day, -1, (dateadd (qq, 1, (dateadd(qq, datediff(qq, 0, @date), 0)) )))
	  
     IF @periodType = 3 --1 раз на півроку
	  set @result = EOMONTH(convert(date, '30.'+convert(char(2), (case when FLOOR (12/month(@date))<=1 Then '12' else '06' end))+'.'+convert(char(4),year(@date)) , 104))

     IF @periodType = 4 --1 раз на рік
	  set @result = convert(date, '31.12.'+convert(char(4),year(@date)),104)

     IF @periodType = 5 --одноразово
	  set @result = EOMONTH (@date)

	RETURN @result
END
--select dbo.fs_PeriodEnd (5, getdate())