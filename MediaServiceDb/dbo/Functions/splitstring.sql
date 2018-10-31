CREATE FUNCTION dbo.splitstring ( @stringToSplit VARCHAR(MAX), @delimiter char(1) )
RETURNS
 @returnList TABLE ([Name] [nvarchar] (500))
AS
BEGIN

 DECLARE @name NVARCHAR(255)
 DECLARE @pos INT

 WHILE CHARINDEX(@delimiter, @stringToSplit) > 0
 BEGIN
  SELECT @pos  = CHARINDEX(@delimiter, @stringToSplit)  
  SELECT @name = SUBSTRING(@stringToSplit, 1, @pos-1)

  INSERT INTO @returnList 
  SELECT LTRIM(RTRIM( @name ))

  SELECT @stringToSplit = LTRIM(SUBSTRING(@stringToSplit, @pos+1, LEN(@stringToSplit)-@pos))
 END

 INSERT INTO @returnList
 SELECT LTRIM(@stringToSplit)

 RETURN
END