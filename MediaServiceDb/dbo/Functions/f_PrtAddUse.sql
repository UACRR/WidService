--drop FUNCTION f_PrtAddUse
CREATE FUNCTION f_PrtAddUse ( @reqId integer, @lang char(2)=NULL)
RETURNS varchar(8000)
    WITH EXECUTE AS CALLER 
       as
    BEGIN 

declare @return varchar(8000)

set @lang = (Case When @lang is NULL or  @lang not in ('Uk', 'Ru','En') Then 'Uk' Else  @lang end)
set @return = 
(
select dName from 
(select max(isnull(d1.dName,'') + 
     (Case When isnull(d2.dName,'') = ''  Then isnull(d2.dName,'') Else   
     (Case  When isnull(d1.dName,'') = '' Then isnull(d2.dName,'') Else ', '+ d2.dName end)
     end)) as Dname
from Request r1 
join RequestMovie m1 on m1.reqId = r1.reqId
left join vlDicList d1 on d1.dKind = 'useHire' and d1.dCode = m1.UseHire and d1.lang = @lang
left join vlDicList d2 on d2.dKind = 'UseFestival' and d2.dCode = m1.UseFestival and d2.lang = @lang
where m1.reqId = @reqId 
union 
select max(isnull(d1.dName,'') + 
     (Case When isnull(d2.dName,'') = ''  Then isnull(d2.dName,'') Else   
     (Case  When isnull(d1.dName,'') = '' Then isnull(d2.dName,'') Else ', '+ d2.dName end)
     end)) as Dname
from Request r1 
join RequestSerial m1 on m1.reqId = r1.reqId
join vlDicList d1 on d1.dKind = 'useHire' and d1.dCode = m1.UseHire and d1.lang = @lang
join vlDicList d2 on d2.dKind = 'UseFestival' and d2.dCode = m1.UseFestival and d2.lang = @lang
where m1.reqId = @reqId 
) CC 
where dname is not NULL 
)

 RETURN @Return
END

--select  dbo.f_PrtAddUse (112, NULL)