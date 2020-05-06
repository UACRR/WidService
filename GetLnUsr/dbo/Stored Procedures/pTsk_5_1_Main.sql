
--exec pTsk_5_1_Main
CREATE procedure [dbo].[pTsk_5_1_Main] (@dateBegin date = NULL, @dateEnd date = NULL)
 as
begin


set @dateBegin =isnull(@dateBegin, (select convert(date, (convert(char(4),year(getdate()))+'-01-01'))))
set @dateEnd = isnull(@dateEnd, getdate())

create table  #result
(id integer not Null, 
 name varchar(100) NULL, 
 countRH integer null, 
 countObj integer null, 
 countUser integer null, 
 countPartner integer null, 
 sPaid money null, 
 sComm money null, 
 sCommPartner money null
 primary key (id) )

--Правообладатели
create table #CustUAASP 
(custId integer not null,  
 type integer Not null      --1-уаасп, 2-не УААСП
 primary key (custId, type) )

create table #Object
( objid integer not null, 
  type integer not null, 
  objStatus integer not null, 
  amount money null
 primary key (objid) )

--Правообладатели УААСП  (1-УАСП, 2 - чужие)
insert into #CustUAASP (custId, type) 
select t1.custId, (Case When isnull(agrStatus,0) = 2 Then 1 else 2 end)
from vCustomer t1
  left join AgreementMaster t2 on t1.custId = t2.custId and t2.agrStatus = 2 
where t1.isRHolder = 1 

--Объекты права + Обороты за период
--1-уаасп, 2-не УААСП
;with TabObj as 
(
 select t3.objId, max(t1.type) as type, max(isnull(t3.status,0)) as objStatus
 from #CustUAASP t1 
 join CopyRight t2 on t1.custId = t2.custId
 right join objectRight t3 on t2.objId = t3.objId
 group by t3.objId
),
TabObjOborot as 
(select t1.objid, sum(t2.deboborot) as amount
from account t1 
join SaldoDay t2 on t1.accId = t2.accId 
where t1.balsCode = 30 and t1.accNls like '301%'
and t2.dateBegin between @dateBegin and  @dateEnd
group by t1.objId 
)
insert into #Object (objid, type,  objStatus, amount)
select t1.objid, isnull(t1.type,2), t1.objStatus, amount
from TabObj t1 
left join TabObjOborot t2 on t1.objid = t2.objid 


insert into #result (id, name, countRH, countObj, countUser, countPartner, sPaid, sComm,  sCommPartner)
select 1, 'Автори УААСП',0,0,0,0,0,0,0
union 
select 2,'Інші правовласники',0,0,0,0,0,0,0
union 
select 3,'Народні',0,0,0,0,0,0,0
union 
select 4,'Не охороняються',0,0,0,0,0,0,0

;with TabCountRH as 
(select type, count(*) as cntRh
 from #CustUAASP 
 group by type
)
update #result set countRh = cntRh
  from #result t1 
  join TabCountRH t2 on t1.id = t2.type

;with TabObj as 
(select type, count(*) as cntRh, sum(isnull(amount,0)) as amount
 from #Object 
 group by type
)
update #result set countObj = cntRh, sPaid = amount
  from #result t1 
  join TabObj t2 on t1.id = t2.type

--Користувачі
update #result set countUser = (select count(*)  
 from vCustomer t1 join agreementMaster t2 on t1.custId = t2.custId and t2.agrStatus = 2
 where t1.isClient = 1)
where id = 1

;with TabCommiss as 
(select t4.type, sum(t2.amount) as amount 
from account t1 
join PayTurn t2 on t1.accId = t2.accIdDebet and t1.balsCode = 11 and t2.dateOper between @dateBegin  and @dateEnd
join account t3 on t2.accIdCredit = t3.accId and t3.balsCode = 21
join #CustUAASP t4 on t3.custId = t4.custId
group by t4.type)
update #result set sComm = t2.amount 
  from #result t1 
  join TabCommiss t2 on t1.id = t2.type

--Партнери
; with TabPartnerS as 
(select sum(amount)  as amount
  from PayTurn t1 
  where t1.dateOper between @dateBegin and @dateEnd 
     and t1.accDebet like '40%' and (t1.accCredit like '21%'  or t1.accCredit like '22%')
)
, TabPartnerC as
(select count(*)  as cntP
 from  partner t1 
 join  agreementMaster t2 on t1.custId = t2.custId and t2.agrStatus = 2 
)
update #result 
set countPartner = (select max(cntP) from TabPartnerC), 
    sCommPartner = (select isnull(max(amount),0) from TabPartnerS) 
where id = 1

--2- Не охорн. 3-народні
;with TabFolk as 
(select count(*) as cntOb, folkType+1 as id
from 
(select max(folkType) as folkType, objId 
 from Authors 
 where folkType in (2,3)
 group by objId, folkType
) t1
group by folkType
)
update #result 
 set countObj = cntOb 
   from #result t1 
      join TabFolk t2 on t1.id = t2.id 
	  
select  name, countRH,  countObj, countUser, countPartner, sPaid, sComm,  sCommPartner 
 from #result
end

--exec pTsk_5_1_Main

GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pTsk_5_1_Main] TO [ReportUser]
    AS [dbo];

