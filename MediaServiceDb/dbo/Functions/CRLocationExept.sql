--drop FUNCTION CRLocationExept 
CREATE FUNCTION CRLocationExept ( @cRightId integer)
RETURNS varchar(3000)
    WITH EXECUTE AS CALLER 
	as
    BEGIN 
    declare @Location varchar(3000), @locExId integer
    set @locExId = 0
	set @Location = ''
    WHILE (SELECT isnull(min(locExId),0) FROM LocationExept where cRightId = @cRightId and locExId > @locExId) > 0
    BEGIN
    set @locExId = (SELECT isnull(min(locExId),0) 
          FROM LocationExept where cRightId = @cRightId and locExId>@locExId ) 
    set @Location = @Location +', '+ isnull(( select 
                  (Case When isnull(u.CountryCode,0) = 0 Then 
                    isnull(rtrim(c.continentNameUk),'') Else '' end) +
                    isnull(rtrim(r.countrynameUk),'') 
                       from LocationExept u 
                        left join Continent c on u.continentCode = c.continentCode 
						left join Country r on u.countryCode = r.countryCode 
		        where crightId=@cRightId and locExId = @locExId), '')

    END
	set @Location = rtrim(ltrim(substring(@Location,2,3000)))
 RETURN @Location
END
--select dbo.CRLocationExept(7)