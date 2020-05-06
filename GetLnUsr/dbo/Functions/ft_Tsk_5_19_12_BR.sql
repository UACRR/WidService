CREATE function [dbo].[ft_Tsk_5_19_12_BR] (@cmCustId integer )
 returns  @result table  (
	id							int		identity,
	innerCode			varchar(25),
	nameRH				varchar(100) ,
	cmName				varchar(100) 
 primary key (id )
 )
 as
begin
 if ( @cmCustId = 0)
	insert @result (innercode,nameRH,cmName) 
		select distinct  innercode,nameRH,cmName from vCustCmService order by nameRH
		else
	insert @result (innercode,nameRH,cmName) 
		select distinct innercode,nameRH,cmName from vCustCmService
		where
			cmCustId =@cmCustId
			 order by nameRH
return
end

--select * from [dbo].[ft_Tsk_5_19_12_BR] (0)

GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_19_12_BR] TO [ReportUser]
    AS [dbo];

