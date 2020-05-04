CREATE procedure dbo.ppTsk_5_2_CrKind (@Type integer = NULL, @dateBegin date = NULL, @dateEnd date = NULL)
--@Type = 0/NULL - всі, 1-Великі права, 2-Малі Права
 as
begin

--Звіт по видам права у розрізі великих та малих прав
set @dateBegin = isnull(@dateBegin,(select convert(date, (convert(char(4),year(getdate()))+'-01-01'))))
set @dateEnd = isnull(@dateEnd, getdate())
set @type = (Case When isnull(@type,0) not in (1,2) Then NULL Else @type end)

declare @category integer = NULL
set @category = (Case @type When 1 Then 6 else Case @type When 2 then 5 else NULL end end)

create table #result 
( --id integer not null identity, 
 usesType integer, 
 usesTypeName varchar(100), 
 cRKindCode integer not Null, 
 cRKindName varchar(600) NULL, 
 countRh integer null, 
 sPaid money null, 
 sComm money null, 
 primary key (cRKindCode,usesType) )

--Матрица для вывода
delete #result
;with TabKind as 
(
select distinct t1.codeI, t1.name as cRKindName, isnull(t3.usesType ,2) as usesType
from CopyrightKind t1 
left join  AgrLicenseType t2 on t1.codeI = t2.kindCode 
left join UsesKind t3 on t2.usesKind = t3.codeI
)
insert into #result (usesType, usesTypeName, cRKindCode, cRKindName)
select (case  t1.usesType When 1 Then 6 else 5 end), t2.name, t1.codeI, cRKindName  
  from TabKind t1 
     join UsesType t2 on t1.usesType = t2.codeI 
   where usesType = isnull(NULL, usesType)
union 
select 0, '',0, 'Всього'

--------------------------------
---обороті по сбору на обїекті
create table #TabTurn 
(categoryCode integer not null, 
 objid integer not null, 
 crKindCode integer not null,
 cntObj integer, 
 amount money, 
 primary key (objid, crKindCode)
)

insert into #TabTurn  (categoryCode, cntObj, objid, amount, crKindCode)
select max(t1.categoryCode) as categoryCode, count(*) as cntObj, t1.objId, sum(t3.amount) as amount, 
       SUBSTRING(t2.accnls,4,2) as crKindCode
 from ObjectRight t1 
join Account t2 on t1.objId = t2.objId 
join PayTurn t3 on t2.accId = t3.accIdDebet and t3.accDebet like '301%' and t3.accCredit like '22%'
where t1.categoryCode = isnull(@category, t1.categoryCode) 
  and t3.dateOper between @dateBegin and @dateEnd
group by  t1.objId, SUBSTRING(t2.accNls,4,2)

--кол-во правообладателей по отобранный объектам
create table #TabRH
(categoryCode integer,
 objid integer not null, 
 cntRH integer,
 primary key (objid)) 

;with TabObj as 
(
select categoryCode, objId 
  from #TabTurn ) 
insert into #TabRH (categoryCode,objid, cntRH) 
select max(t2.categoryCode), t1.objid, count(*) as cntRH
 from copyRight t1 
 join TabObj t2 on t1.objid = t2.objId
 group by t1.objId

 ---Комиссии
create table #TabRHComm
(custId integer not null,
 categoryCode integer , 
 commAmount money, 
 primary key (custId)) 

delete #TabRhComm
;with TabComm as
(select max(t3.custId) as custID, sum(t2.amount) as amount 
from account t1 
join PayTurn t2 on t1.accId = t2.accIdDebet and t1.balsCode = 11 and t2.dateOper between @dateBegin  and @dateEnd
join account t3 on t2.accIdCredit = t3.accId and t3.balsCode = 21
group by t3.custId) 
,
TabObj as 
(
select categoryCode, objId 
  from #TabTurn ) 
insert into #TabRhComm (categoryCode, custId, commAmount)
select max(t3.categoryCode) as categoryCode, t2.custId, max(amount) as amount
 from TabComm t1  
  join CopyRight t2 on t1.custId = t2.custId 
  join TabObj t3 on t2.objid = t3.objId 
where t3.categoryCode = isnull(@category, t3.categoryCode) 
group by t2.custId

---Результат
/*
insert into #Result
( usesType, 
-- usesTypeName, 
 cRKindCode, 
-- cRKindName, 
 countRh, 
 sPaid, 
 sComm)
select (Case  t1.categoryCode When 5 Then 2 Else 1 end),  
       t1.crKindCode, 
       sum(isnull(t2.cntRH,0)), sum(t1.amount),
       0 --sum(t1.cntObj) as cntObj
 from #TabTurn t1  
 join #TabRH t2 on t1.objid = t2.objid
group by t1.categoryCode, t1.crKindCode
order by t1.categoryCode
*/
;with TabSum as 
(
 select  t1.categoryCode, t1.crKindCode, sum(t1.amount) as amount, sum(isnull(t2.cntRH,0)) as cntRH
  from #TabTurn t1 
 join #TabRH t2 on t1.objid = t2.objid
group by t1.categoryCode, t1.crKindCode
)
update #Result 
 set  countRh=t1.cntRH, 
      sPaid = t1.amount
 from #Result t0 
 join TabSum t1 on t0.cRKindCode = t1.crKindCode and t0.usesType = t1.categoryCode
 
--Итоги с комиссией
update #Result  
  set sComm = (select sum(commAmount)  from #TabRHComm where categoryCode = isnull(NULL, categoryCode) ) ,
      sPaid = (select sum(isnull(sPaid,0)) from #result where cRKindCode <> 0)
where cRKindCode = 0

/*
insert into #Result 
( usesType, usesTypeName, cRKindCode, cRKindName,  countRh,  sPaid,  sComm)
select 0, NULL, 0, NULL, 
(select count(*) from #TabRHComm where categoryCode = isnull(@category, categoryCode)),
(select sum(isnull(sPaid,0)) from #result where cRKindCode <> 0), 
(select sum(commAmount)  from #TabRHComm where categoryCode = isnull(@category, categoryCode) )

update #result 
  set cRKindName = t2.name 
 from #result t1 
  join CopyrightKind t2 on t1.cRKindCode = t2.codeI

update #result 
  set usesTypeName = t2.name 
 from #result t1 
  join  usesType t2 on t1.usesType = t2.codeI
*/

select (Case usesType when 6 then 1 else 2 end), usesTypeName, cRKindCode, cRKindName, countRh, sPaid,  sComm 
 from #result t1
 order by usesType,cRKindCode
end

--exec ppTsk_5_2_CrKind 2
