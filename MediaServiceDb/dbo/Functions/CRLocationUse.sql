--drop FUNCTION CRLocationUse 
CREATE FUNCTION CRLocationUse ( @cRightId integer)
RETURNS varchar(3000)
    WITH EXECUTE AS CALLER 
       as
    BEGIN 
    declare @Location varchar(3000), @locUsId integer, @num integer
    set @locUsId = 0
	set @Location = ''
    WHILE (SELECT isnull(min(locUsId),0) FROM vLocationUse where cRightId = @cRightId and locUsId > @locUsId) > 0
    BEGIN
	set @num=@num+1
    set @locUsId = (SELECT isnull(min(locUsId),0) 
          FROM vLocationUse where cRightId = @cRightId and locUsId>@locUsId ) 
    set @Location = @Location +', '+ isnull(( select 
                  (Case When isnull(u.CountryCode,0) = 0 Then 
                    isnull(rtrim(c.continentNameUk),'') Else '' end) +
                    isnull(rtrim(r.countrynameUk),'') 
                       from vLocationUse u 
                        left join Continent c on u.continentCode = c.continentCode 
						left join Country r on u.countryCode = r.countryCode 
		        where crightId=@cRightId and locUsId = @locUsId), '')
    END
	set @Location = rtrim(ltrim(substring(@Location,2,3000)))
 RETURN @Location
END
--select dbo.CRLocationUse(131)