

CREATE procedure [dbo].[pTsk_5_3_Community] (@dateBegin date = NULL, @dateEnd date = NULL)
--@Type = 0/NULL - всі, 1-Великі права, 2-Малі Права
 as
begin

set @dateBegin = isnull(@dateBegin,(select convert(date, (convert(char(4),year(getdate()))+'-01-01'))))
set @dateEnd = isnull(@dateEnd, getdate())

create table   #tmpResult 
 (id integer identity not null, 
 objid integer , 
 amount money, 
 custId integer not null, 
 cmCustId integer Null
 primary Key (id) )

 create table #TabObjPay
 (
 objid		int,
 amount		money,
 primary key (objid)
 )
 create table #TabCmRight(
 custId		int, 
 cmCustId	int,
 primary key ( custId	, cmCustId)
 )


--Обороты - начисления на объекты чужих правообладателей

/*;with TabObjPay as 
(
select t2.objid, sum(t1.amount) as amount
from PayTurn t1 
join Account t2 on t2.accId = t1.accIdDebet
where t1.dateOper between @dateBegin and @dateEnd
and t1.accDebet like '30%' and accCredit like '22%'
group by t2.objId
),
*/
insert #TabObjPay( objid,amount)
select t2.objid, sum(t1.amount) as amount
from PayTurn t1 
join Account t2 on t2.accId = t1.accIdDebet
where t1.dateOper between @dateBegin and @dateEnd
and t1.accDebet like '30%' and accCredit like '22%'
group by t2.objId
 
--Чужие комьюнити
/*
TabCmRight as
(select  t1.custId, t1.cmCustId 
  from CustCmRight t1
  group by t1.custId,t1.cmCustId)


insert into #tmpResult  (objid, amount, custID, cmCustId)
 select t1.objid, t1.amount, t2.custId, t4.cmCustId
 from TabObjPay t1 
 join CopyRight t2 on t1.objid = t2.objid 
 left join TabCmRight t4 on t2.custId = t4.custId
 where not exists (select 1 from  AgreementMaster t3 where t2.custId = t3.custId and t3.agrStatus = 2)
 */
 insert #TabCmRight( custId, cmCustId)
 select distinct t2.custId,t3.cmCustId
 from #TabObjPay t1 ,CopyRight t2 ,CustCmRight t3
 where
 t1.objId = t2.objid	and
 t3.custId = t2.custId

 insert into #tmpResult  (objid, amount, custID, cmCustId)
 select t1.objid, t1.amount, t2.custId, t4.cmCustId
 from #TabObjPay t1
 join CopyRight t2 on t1.objid = t2.objid 
 left join #TabCmRight t4 on t2.custId = t4.custId
 where not exists (select 1 from  AgreementMaster t3 where t2.custId = t3.custId and t3.agrStatus = 2)

;with TabCommiss as   --комиссии от чужих
(select sum(t1.amount) as amountCommiss, t3.cmCustId
from PayTurn t1
join Account t2 on t2.accId = t1.accIdCredit
join #tmpResult t3 on t3.custId = t2.custId
where t1.dateOper between @dateBegin and @dateEnd
and t1.accDebet like '11%' and accCredit like '21%'
group by t3.cmCustId
), 
TabCount as --кол-ва чужих и собрано
(select count(*) as countRH, sum(amount) as amountPaid, t1.cmCustId
 from #tmpResult t1 
group by t1.cmCustId )
select isnull(t3.name,'- Відсутні договори') as nameCommunity, t1.countRH, t1.amountPaid, isnull(t2.amountCommiss,0) as amountCommiss
from TabCount t1 
left join TabCommiss t2 on t1.cmCustId = t2.cmCustId
left join vCustomer t3 on t1.cmCustId = t3.custId
order by t3.name

END

--exec pTsk_5_3_Community '20181024','20201024'

GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pTsk_5_3_Community] TO [ReportUser]
    AS [dbo];

