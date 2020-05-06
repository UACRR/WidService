CREATE function [dbo].[ft_list_count] ( @counter integer )
RETURNS @TABLE
TABLE(OFFSET_ int,
	  OFFSET_str varchar (20)
	  )
AS
BEGIN
declare @i int = 0

while (@i <=   @counter/10000 )
begin
insert @TABLE values(@i,CONVERT(varchar(10),(@i)*10000 +1)+' - '+
		case when ( (@i+1)*10000<@counter)
		then (CONVERT(varchar(10),(@i+1)*10000 ))
		else
			(CONVERT(varchar(10),@counter ))
		end

)
set @i =@i + 1
end

RETURN
END    

