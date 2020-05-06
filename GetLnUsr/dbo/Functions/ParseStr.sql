create FUNCTION  [dbo].[ParseStr] (@inputStr NVARCHAR(254), @delimiter NCHAR(1), @position INT)
RETURNS NVARCHAR(254)
AS
BEGIN
    DECLARE @table table (outStr NVARCHAR(250))
    DECLARE @res NVARCHAR(250)

    -- Get the position of first delimiter 
    SET @inputStr=ltrim(rtrim(  @inputStr))
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
	INSERT INTO @table VALUES(@inputStr)   -- Get the desired position from the result table
  
    SELECT @res = t.outStr
    FROM 
        (
            SELECT outStr, ROW_NUMBER() OVER (ORDER BY (SELECT 100)) AS sno
            FROM @table
        ) t
    WHERE t.sno = @position;

    IF (@res IS NULL)
        SET @res = '' 

    RETURN @res;
END;

