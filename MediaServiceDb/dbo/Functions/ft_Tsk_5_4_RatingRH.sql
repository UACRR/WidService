--drop function  ft_Tsk_5_4_RatingRH 
CREATE function  [dbo].[ft_Tsk_5_4_RatingRH]  (@category integer = NULL, @cRightKind integer = NULL, @ourAuthor integer= NULL, @dateBegin date = NULL, @dateEnd date = NULL)
--@category - 0,NULL - все; 6-большие права, 5-малые права
--@cRightKind - по справочнику cRightKind; 0,NULL - все
--@ourAuthor NULL, 0 - все; 1-наши, 2 - чужие
RETURNS @RT TABLE
(
id integer not null identity primary key,
custId integer, 
cntObj integer, 
cRName varchar(100), 
interCode varchar(50),
registrDate date,
cmCustId integer, 
cmName varchar(100), 
amount money
)
AS
BEGIN  --Користувачі

--declare @dateBegin date, @dateEnd date, @cRightKind integer, @category integer
set @dateBegin = isnull(@dateBegin, (select convert(date, (convert(char(4),year(getdate()))+'-01-01'))))
set @dateEnd = isnull(@dateEnd, getdate())
set @cRightKind = (Case When isnull(@cRightKind,0) = 0 Then NULL Else @cRightKind end)
set @category = (Case When isnull(@category,0) = 0 Then NULL Else @category end)
set @ourAuthor = (Case When isnull(@ourAuthor,0) = 0 Then NULL Else @ourAuthor end)

--Отобраны категории
declare @TabCategory table  
(codeI integer not null primary key) 
insert into @TabCategory (codeI) 
select t1.codeI 
 from Category t1 
 where t1.codeI = isnull(@category, codeI)

--Отобрана таблица видов 
declare @TabCrKind table  
(codeI integer not null primary key)
insert into @TabCrKind (codeI) 
select codei
  from CopyrightKind
  where codeI = isnull(@cRightKind , codeI)

--кол-во объектов
;with TabCntObj as  
(
select t1.custId, count(*) as cntObj
from copyright t1 
join objectRight t2 on t1.objId = t2.objId and t2.status =1
join @TabCategory t3 on t3.codeI = t2.categoryCode 
where t1.status = 1
group by t1.custId
), 
--обороты по видам права и правообладателям
TabTurn as 
(
select t1.custIdRh as custid, 
  sum(t1.amount) as amount
from PayTurn t1 
join account t2 on t2.accid = t1.accIdDebet  
join account t3 on t3.accid = t1.accIdCredit  
join ObjectRight t4 on t4.objId = t3.objId
join @TabCrKind t5 on t5.codeI = convert(integer,substring(t1.accCredit,4,2) )
join @TabCategory t6 on t6.codeI = t4.categoryCode
where t1.accDebet like '21%' and accCredit like '30%' 
   and t1.dateOper between @dateBegin and @dateEnd
 group by t1.custIdRh
)
insert into @RT 
(custId, cntObj, cRName, interCode, registrDate, cmCustId, cmName, amount)
select distinct t1.custId, 
t2.cntObj, 
t6.name as cRName, t7.interCode, t6.registrDate,
isnull(t9.cmCustId, t12.custId), isnull(isnull(t10.name, t13.name ),'УААСП') as cmName, t1.amount
 from  TabTurn t1 
 left join TabCntObj t2 on t1.custId = t2.custId 
 join vCustomer t6 on t6.custId = t1.custId
 join RightHolder t7 on t7.custId = t6.custId
 left join TermsOfService t8 on t8.custId = t7.custId 
 left join @TabCrKind t11 on t11.codeI = t8.CRKindCode 
 left join CustCmRight t9 on t9.custId = t8.custId and t9.cRKindCode = @cRightKind and @dateBegin >= isnull(t9.dateBegin,'1900-01-01') and @dateEnd <= isnull(t9.dateEnd, '3000-01-01')
 left join Community t12 on t12.custId = t7.custId 
 left join vCustomer t10 on t10.custId = t9.cmCustId  
 left join vCustomer t13 on t13.custId = t12.custId
 where isnull(t9.cmCustId,0) = 
 (case  when isnull(@ourAuthor,0) = 0 Then isnull(isnull(t9.cmCustId,0),t12.custId) Else Case When isnull(@ourAuthor,0) = 1 Then 0 Else  isnull(t9.cmCustId, t12.custId) end end)

 update @RT set cmCustId = t2.custId, cmName = t3.name
   from @RT t1 
   join Community t2 on t1.custId = t2.custId
   join vCustomer t3 on t2.custId = t3.custId


 RETURN
 END

--select  * from ft_Tsk_5_4_RatingRH (0, 0, 1, NULL, NULL)

/*
select t1.custIdRh as custid, t5.name, t4.objId,
  t1.*
from PayTurn t1 
join account t2 on t2.accid = t1.accIdDebet  
join account t3 on t3.accid = t1.accIdCredit  
join ObjectRight t4 on t4.objId = t3.objId
join vCustomer t5 on t1.custIdRh = t5.custId
where t1.accDebet like '21%' and accCredit like '30%' 
*/