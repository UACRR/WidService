

create function dbo.fn_vRequestState (@userId varchar(48), @custId int)
RETURNS TABLE
AS
RETURN
(
select 
distinct
t1.reqid
, t1.reqType
, case when t1.reqstatus  in (11,13) and datediff( DAY,  isnull(t1.ReqDate, getdate() ), getdate() ) > 8 then 5 -- Не активные
       when t1.reqstatus  in (11,13) and datediff( DAY,  isnull(t1.ReqDate, getdate() ), getdate() ) <= 8 then 4 -- Новые 
	   when t1.reqstatus = 11 then 3
	   when t1.reqstatus = 12 then 6 -- На согласовании
	   when t1.reqstatus in (2,3) then 7 -- Согласованые
	   else 1 end -- Остальное
	   as stateRequest
from 
Request t1 
left outer join ReqAgreement t2 on t2.reqId = t1.reqId 
left outer join authCustomer(@userId) t3 on ( t3.custID = t2.custID or t3.custID = t1.custID )
where 
t1.reqstatus in (1,2,3,11,12,13)
and t3.custID is not null
and (@custId is null or t3.custID = @custId)

)