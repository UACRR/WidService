
CREATE function [dbo].[ft_tsk_3_R_04_ccid] (@beginDate datetime = NULL, @endDate datetime = NULL, @status integer = NULL)
RETURNS TABLE
AS
RETURN
    select * from vtsk_3_R_04_ccid
    where
        (@beginDate is null or createDate >= @beginDate)
        and (@endDate is null or Cast(createDate as Date) <= Cast(@endDate as Date))
        and ((@status is null and rgStatus <> 0) or rgStatus = @status)
