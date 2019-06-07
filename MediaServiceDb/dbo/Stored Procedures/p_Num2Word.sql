
CREATE procedure [p_Num2Word] (@Value money=NULL, @currency char(3)=NULL, @lang char(2)=NULL)
as
    BEGIN 
declare @result table(
howmoney varchar(150)
)
set @Value=isnull(@value,0) 

insert @result select dbo.f_Num2Word (@Value, '980', 'Uk')


select * from  @result
END
--exec p_Num2Word NULL ,'980', 'En'