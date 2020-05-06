CREATE procedure [dbo].[p_Tsk_5_19_12_BR] (@cmCustId integer )
as
begin
declare  @result table  (
	id							int		identity,
	innerCode			varchar(25),
	nameRH				varchar(100) ,
	cmName				varchar(100) 
 primary key (id )
 )

  if ( @cmCustId = 0)
	insert @result (innercode,nameRH,cmName) 
		select distinct  innercode,nameRH,cmName from vCustCmService order by nameRH
		else
	insert @result (innercode,nameRH,cmName) 
		select distinct innercode,nameRH,cmName from vCustCmService
		where
			cmCustId =@cmCustId
			 order by nameRH
select * from @result

end

--exec [dbo].[p_Tsk_5_19_12_BR] 0
