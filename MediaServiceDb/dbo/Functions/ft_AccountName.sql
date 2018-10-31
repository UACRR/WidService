
CREATE FUNCTION [dbo].[ft_AccountName] ( @accId integer )
RETURNS varchar(200)
    WITH EXECUTE AS CALLER 
    
AS
BEGIN
--Формирует название для счета
declare @return varchar(200)


set @return = 
 isnull(
isnull(
(select 
 rtrim(o1.name) +' <'+ rtrim(k1.name)+' '+rtrim(k1.name)+ '>'
 from Account a1
  join ObjectRight o1 on a1.objId = o1.objId 
  join AccountBals b1 on a1.balsCode = b1.codeI
  join CopyrightKind k1 on k1.codeI = substring(accNls,3,1) and k1.codeI = substring(accNls,4,2)
 where a1.balsCode in (30,31) 
     and a1.accId = @accId),
(select c1.name as custName
from Account a1 
 join AccountBals b1 on a1.balsCode = b1.codeI
 left join vcustomer c1 on a1.custID = c1.custID
 where a1.balsCode in (20,21, 28, 29)  and a1.accId = @accId))
,
(select b1.name as custName
from Account a1 
 join AccountBals b1 on a1.balsCode = b1.codeI
 where a1.balsCode not in (30, 31, 20,21, 28, 29)  and a1.accId = @accId))
  
RETURN @return;
END;

--select a1.accId, a1.accName, objid, CustId, dbo.ft_AccountName(accId), dbo.ft_AccOpenName(accnls) from account a1