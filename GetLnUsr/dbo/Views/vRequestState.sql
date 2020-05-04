
/*==============================================================*/
/* View: vRequestState                                          */
/*==============================================================*/
create view vRequestState as
select 
t1.reqid
, t1.reqType
, case when t1.reqstatus  in (0,1,11,12) and datediff( DAY,  isnull(t1.ReqDate, getdate() ), getdate() ) > 14 then 1
       when t1.reqstatus  in (0,1,11,12) and datediff( DAY,  isnull(t1.ReqDate, getdate() ), getdate() ) <= 14 then 2 
	   when t1.reqstatus between 2 and 7 then 3
	   else 4 end as stateRequest
from 
Request t1 where t1.reqstatus in (0,1,2,3,4,5,6,7,11,12)
