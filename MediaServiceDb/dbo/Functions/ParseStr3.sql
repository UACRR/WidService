create  FUNCTION  [dbo].[ParseStr3] (@inputStr NVARCHAR(250))
RETURNS @table
     table (outStr NVARCHAR(250))
    
AS
BEGIN
DECLARE @res NVARCHAR(250)
DECLARE  @delimiter NCHAR(1)='.';
DECLARE  @delimiter1 NCHAR(1)=',';


    -- Get the position of first delimiter 
    SET @inputStr =ltrim(rtrim(   @inputStr  ))
	DECLARE @pos INT
	DECLARE @pos2 INT = CHARINDEX(@delimiter, @inputStr) 
		DECLARE @pos1 INT = CHARINDEX(@delimiter1, @inputStr) 
		if (@pos2>@pos1 and @pos1!=0)
		     set @pos=@pos1
				else 
		     set @pos=@pos2

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
	SET @pos2  = CHARINDEX(@delimiter, @inputStr) 
		SET @pos1  = CHARINDEX(@delimiter1, @inputStr) 
			if (@pos2>@pos1 and @pos1!=0)
		     set @pos=@pos1
				else 
		     set @pos=@pos2
    END
	INSERT INTO @table VALUES(@inputStr)
    
	RETURN
 
END;