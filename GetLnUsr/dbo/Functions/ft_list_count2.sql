CREATE function [dbo].[ft_list_count2] (@datebegin date =NULL, @dateEnd date NULL,@length int )
RETURNS @TABLE
TABLE(OFFSET_ int,
	  OFFSET_str varchar (20)
	  )
AS
BEGIN
declare @i int = 0
DECLARE @counter INT = (SELECT COUNT(*) FROM [ft_Tsk_5_36_Objects] (@datebegin , @dateEnd ))

set @length=ISNULL(@length,10000)

while (@i <=   @counter/@length )
begin
insert @TABLE values(@i,CONVERT(varchar(10),(@i)*@length +1)+' - '+
		case when ( (@i+1)*@length<@counter)
		then (CONVERT(varchar(10),(@i+1)*@length ))
		else
			(CONVERT(varchar(10),@counter ))
		end

)
set @i =@i + 1
end

RETURN
END    
--select * from [dbo].[ft_list_count2] ('20190101','20190815',30000)


GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_list_count2] TO [ReportUser]
    AS [dbo];

