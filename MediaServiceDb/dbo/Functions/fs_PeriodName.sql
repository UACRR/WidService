CREATE FUNCTION [dbo].[fs_PeriodName] (@periodType integer, @date date)
RETURNS varchar(50)
    WITH EXECUTE AS CALLER 
    as
    BEGIN 
    declare  @result varchar(50)

    IF @periodType = 1 --Щомісячно 
	  set @result = (select name from MONTHNAME where codeI = MONTH (convert(date,@date)) )+' '+convert(char(4),year(@date))+' р.'

     IF @periodType = 2 --Щоквартально 
	  set @result = convert(char(1), DATEPART (QUARTER, @date)) + ' квартал' + ' '+convert(char(4),year(@date))+' р.'
	  
     IF @periodType = 3 --1 раз на півроку
	  set @result = (case when month(@date)<=7 Then 'Перше' else 'Друге' end)+' півріччя'+' '+convert(char(4),year(@date))+' р.'

     IF @periodType = 4 --1 раз на рік
	  set @result = ''+convert(char(4),year(@date))+' р.'

     IF @periodType = 5 --Одноразово
	  set @result = 'Одноразово '

     --set @result = @result+' '+convert(char(4),year(@date))+' р.'
	
	RETURN @result
END
--select dbo.fs_PeriodName (1, '2019-10-01')