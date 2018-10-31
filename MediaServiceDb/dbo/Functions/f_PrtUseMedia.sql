--drop FUNCTION f_PrtUseMedia
CREATE FUNCTION f_PrtUseMedia ( @reqId integer, @lang char(2)=NULL)
RETURNS varchar(8000)
    WITH EXECUTE AS CALLER 
       as
    BEGIN 

declare @return varchar(8000)
set @lang = (Case When @lang is NULL or  @lang not in ('Uk', 'Ru','En') Then 'Uk' Else  @lang end)
set @return = 
(
select 
STUFF (( 
select ', '+useMediaTypeName 
from 
(
select r1.reqid, t1.useMediaTypeName 
from Request r1 
left join RelReqMedia m1 on m1.reqId = r1.reqId
left join vlUseMediaType t1 on m1.useMediaTypeCode = t1.useMediaTypeCode and t1.lang = @lang
where r1.reqId = @reqId 
)  CC 
for XML path ('')) ,1,1,'') as UseMediaName 
)
 RETURN @Return
END
--select dbo.f_PrtUseMedia (112,NULL)