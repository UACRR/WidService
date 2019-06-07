Create FUNCTION [dbo].[fMyCustId] ()
RETURNS char(3)
    WITH EXECUTE AS CALLER 
    as
    BEGIN 
    declare  @result char(3)
    set @result = (select custId from vCustomer where ankMy = 1)
	RETURN @result
END