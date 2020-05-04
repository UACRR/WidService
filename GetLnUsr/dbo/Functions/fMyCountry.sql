--drop FUNCTION dbo.fMyCountry 
create FUNCTION dbo.fMyCountry ()
RETURNS char(3)
    WITH EXECUTE AS CALLER 
    as
    BEGIN 
    declare  @result char(3)
    set @result = (select countryCode from vCustomer where ankMy = 1)
	RETURN @result
END
--select dbo.fMyCountry()
