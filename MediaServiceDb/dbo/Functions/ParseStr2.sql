CREATE FUNCTION  [dbo].[ParseStr2] (@inputStr NVARCHAR(250), @delimiter NCHAR(1))
RETURNS @table
     table (outStr NVARCHAR(250))
    
AS
BEGIN
DECLARE @res NVARCHAR(250)

    -- Get the position of first delimiter 
    SET @inputStr =ltrim(rtrim(   @inputStr  ))
	DECLARE @pos INT = CHARINDEX(@delimiter, @inputStr) 

    -- The variable for saving one value
    DECLARE @value NVARCHAR(250)
	  
	WHILE (@pos !=0)
    BEGIN
        -- Get a value
        SET @value = SUBSTRING(@inputStr, 1, @pos -1)

        -- put the value inside table
        INSERT INTO @table VALUES(@value)

        -- shrink the string
        SET @inputStr = ltrim(SUBSTRING(@inputStr, @pos + 1, LEN(@inputStr)))

        -- Get position for the next delimitet
        SET @pos = CHARINDEX(@delimiter, @inputStr)
    END
	INSERT INTO @table VALUES(@inputStr)
    
	RETURN
 
END;