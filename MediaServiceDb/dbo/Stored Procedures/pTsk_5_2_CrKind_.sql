CREATE procedure [dbo].[pTsk_5_2_CrKind_] (@Type integer = NULL, @dateBegin date = NULL, @dateEnd date = NULL)
--@Type = 0/NULL - всі, 1-Великі права, 2-Малі Права
 as
begin

--Звіт по видам права у розрізі великих та малих прав
set  @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())
set @type = (Case When isnull(@type,0) not in (1,2) Then NULL Else @type end)

declare @result table
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
;with TabKind as 
(
select distinct t1.codeI, t1.name as cRKindName, isnull(t3.usesType ,2) as usesType
from CopyrightKind t1 
left join  AgrLicenseType t2 on t1.codeI = t2.kindCode 
left join UsesKind t3 on t2.usesKind = t3.codeI
)
insert into @result (usesType, usesTypeName, cRKindCode, cRKindName)
select t1.usesType, t2.name, t1.codeI, cRKindName  
  from TabKind t1 
     join UsesType t2 on t1.usesType = t2.codeI 
   where usesType = isnull(@type, usesType)
union 
select 0, '',0, 'Всього'
--------------------------------
declare  @CustUAASP table
(custId integer not null,  
 typeBr smallint null, 
 typeSr smallint null, 
 primary key (custId) )

--Правообладатели УААСП - с договором в статусе 2 
insert into @CustUAASP (custId) 
select distinct t1.custId
from vCustomer t1
  left join AgreementMaster t2 on t1.custId = t2.custId and t2.agrStatus = 2 
where t1.isRHolder = 1 

--Правообладатели Малых и Больших прав (объектов)
;with TabCR as 
( select distinct t1.custId, max((Case When t3.categoryCode = 5 Then 1 else 0 end)) as typeSr, max((Case When t3.categoryCode = 6 Then 1 else 0 end)) as typeBr
 from @CustUAASP t1 
      join CopyRight t2 on t1.custId = t2.custId  
      join objectRight t3 on t2.objid = t3.objid 
  group by t1.custId)

update @CustUAASP 
  set typeBr = t2.typeBr, typeSr = t2.typeSr  
  from @CustUAASP t1 
    join TabCR t2 on t1.custId = t2.custId  

--удаляю лишних (большие или малые права) 
if @type = 1  
delete @CustUAASP where typeSr = 1
if @type = 2  
delete @CustUAASP where typeBr = 1


;with TabCountRH as 
(select count(*) as countRH, crKindCode
 from TermsOfService t1 
   join @CustUAASP t2 on t1.custId  = t2.custId
 where isnull(t1.ourService,0) = 1 
 group by crKindCode)
update @result set countRh = t2.countRH  
  from @result t1 
    join TabCountRH t2 on t1.crKindCode = t2.crKindCode

--------------------------------
create table #Object
( usesType integer, 
  objid integer not null, 
 primary key (objid) )

--объекты наших правообладателей с подтвержденніми правами
 insert into #Object (objid, usesType)
 select t3.objId, max((case t3.categoryCode when 6 then 1 else 2 end)) as usesType
 from @CustUAASP t1 
 join CopyRight t2 on t1.custId = t2.custId AND isnull(t2.status,0) = 1 --!!!
 right join objectRight t3 on t2.objId = t3.objId
 where categoryCode = (Case When isnull(@type,0) = 1 Then 6 Else Case When isnull(@type,0) = 2 Then 5 Else categoryCode end end)
 group by t3.objId

--Собрано по объектам права наших правообладателей
; with TabObj as 
(select t1.usesType, convert(integer, substring(t2.accNls,4,2)) as crKindCode, 
        t1.objid, accId 
  from #Object t1 join Account t2 on t1.objid = t2.objid 
  where t2.accNls like '30%'
)
update @result set sPaid = amount 
 from @result t1 join 
(
select  t1.usesType, t1.crKindCode, sum(t2.amount) as amount
from TabObj t1 
 join PayTurn t2 on t1.accId = t2.accIdDebet 
   where accDebet like '30%' and accCredit like '22%'
        and t2.dateOper between  @dateBegin and @dateEnd
 group by t1.crKindCode, t1.usesType ) t77 on t1.cRKindCode = t77.crKindCode and t1.usesType = t77.usesType

--Собрано комиссий от авторов
;with TabCommiss as 
(select sum(t2.amount) as amount 
from account t1 
join PayTurn t2 on t1.accId = t2.accIdDebet and t1.balsCode = 11 and t2.dateOper between @dateBegin  and @dateEnd
join account t3 on t2.accIdCredit = t3.accId and t3.balsCode = 21
join @CustUAASP t4 on t3.custId = t4.custId
)
update @result set sComm = isnull(t2.amount,0), 
                   sPaid = (select sum(isnull(sPaid,0)) from @result where cRKindCode <> 0)
  from TabCommiss t2 
  where  cRKindCode = 0 
 
update @result set countRh = (select max(isnull(countRh,0)) from @result )
  where  cRKindCode = 0 
 
select usesType, usesTypeName, cRKindCode, cRKindName, countRh, sPaid,  sComm 
 from @result
 order by usesType,cRKindCode
end

--exec pTsk_5_2_CrKind 1
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pTsk_5_2_CrKind_] TO [ReportUser]
    AS [dbo];

