
CREATE FUNCTION dbo.ft_PrtRHolder (@reqId integer)
RETURNS @RT TABLE
( 
  id integer not null identity primary key,
  reqId integer not null, 
  objId integer not null,
  rHcustId integer not null, 
  rHcustName varchar(254) null, 
  rHiNNOKPO varchar(15) null,
  rateCR decimal(10,5) null, 
  ratePF decimal(10,5) null, 
  rHSign varchar(512) null
)
  as
  BEGIN 
--declare @reqId integer 
--set @reqId = 115
-- set @lang = (Case When @lang is NULL or  @lang not in ('Uk', 'Ru','En') Then 'Uk' Else  @lang end)
Insert into @RT
select 
 r1.reqId 
, r1.objId
, c1.custId
, max(u1.name) as custName
, max(u1.iNNOKPO) as oKPOINN
, sum(Case When rt1.cRType = 1 Then rate else 0 end ) as rateCr
, sum(Case When rt1.cRType = 2 Then rate else 0 end ) as ratePf
,'Signature...'
from Request r1 
join CopyRight c1 on r1.objid = c1.objid 
join creativeRole e1 on e1.creativeRoleId = c1.creatiiveRoleId
join creativeRoleType rt1 on e1.crRoleCode = rt1.code
--join TermsOfService of1 on c1.custId = of1.custid 
join vCustomer u1 on c1.custId = u1.custID
--join RelReqObj j1 on j1.reqType = r1.reqType and j1.cRKindCode = of1.cRKindCode
where r1.reqId = @reqId 
and r1.reqDate between isnull(c1.beginDate,'1900-01-01') and isnull(c1.endDate, '3000-01-01')
group by r1.reqId, r1.objId, c1.custId, rt1.cRType

RETURN 
END  

--select * from dbo.ft_PrtRHolder (178)