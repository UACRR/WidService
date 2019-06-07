
CREATE FUNCTION [dbo].[ft_AccOpenName] ( @accNls varchar(25) )
RETURNS varchar(200)
    WITH EXECUTE AS CALLER 
    
AS
BEGIN
--Формирует название для счета по номеру счета
declare @return varchar(200)
;
WITH RT (balsCode,  cRType, cRKindCode, objId, custId)
AS
(select  
convert(integer,substring(@accNls,1,2)) as balsCode, 
convert(integer,substring(@accNls,3,1)) as cRType, 
convert(integer,substring(@accNls,4,2)) as cRKindCode, 
(Case When substring(@accNls,1,1)='3' Then convert(integer,substring(@accNls,6,10)) Else NULL END) as objId, 
(Case When substring(@accNls,1,1)='2' Then convert(integer,substring(@accNls,6,10)) Else NULL END) as custIdId 
) 
select  @return = 
(
select 
 --rtrim(o1.name) +' <'+ rtrim(k1.cRKindNameUk)+' '+rtrim(k1.cRTypeNameUk)+ '>'
 rtrim(o1.name) +' <'+ rtrim(b1.Name)+' '+ '>'from 
  RT a1 
  join ObjectRight o1 on a1.objId = o1.objId
  join AccountBals b1 on  a1.balsCode = b1.codeI
  --join vCprtKindGroup k1 on k1.cRType = a1.cRType 
  --                  and k1.cRKindCode = a1.cRKindCode
 where a1.balsCode in (30,31)
 union 
select c1.name as custName
from RT a1 
 join AccountBals b1 on a1.balsCode = b1.codeI
 left join vcustomer c1 on a1.custID = c1.custID
 where a1.balsCode in (20,21, 28, 29) 
union
select b1.Name as custName
from RT a1 
 join AccountBals b1 on a1.balsCode = b1.codeI
 where a1.balsCode not in (30, 31, 20,21, 28, 29)  
 )
  
RETURN @return;
END;

--select a1.accId, a1.accName, objid, CustId, dbo.ft_AccountName(accId), dbo.ft_AccOpenName(accnls) from account a1