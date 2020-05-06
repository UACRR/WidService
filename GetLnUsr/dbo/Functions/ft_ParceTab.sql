
CREATE FUNCTION [dbo].[ft_ParceTab] (@inputStr NVARCHAR(512), @delimiter NCHAR(1))
--Функция получения таблицы распарсенной строки
RETURNS @RT TABLE
( 
 id integer not null primary key, 
 outStr varchar(512) null
)
 as begin 
    DECLARE @res NVARCHAR(250)

    -- Get the position of first delimiter 
    SET @inputStr=ltrim(rtrim(  @inputStr))
	DECLARE @pos INT = CHARINDEX(@delimiter, @inputStr) 

    -- The variable for saving one value
    DECLARE @value NVARCHAR(512), @i integer = 1
	 
 WHILE (@pos !=0)
     BEGIN
        -- Get a value
        SET @value = SUBSTRING(@inputStr, 1, @pos -1)
        -- put the value inside table
        INSERT INTO @RT (outstr, id) VALUES(@value, @i)
		
        -- shrink the string
        SET @inputStr = ltrim(SUBSTRING(@inputStr, @pos + 1, LEN(@inputStr)))
		set @i = @i+1
        -- Get position for the next delimitet
        SET @pos = CHARINDEX(@delimiter, @inputStr)
    END
	INSERT INTO @RT (outStr, id)  VALUES(@inputStr, @i)   -- Get the desired position from the result table

RETURN 
END  

--select * from ft_ParceTab ('asd,abd,qwe,s',',')

