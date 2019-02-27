CREATE function [dbo].[ft_Tsk_1_ListRightHolder01] (@date date NULL)
RETURNS Table 
Return
(
--(custId, custStatus, agrStatus,innerCode, interCode, name, registrDate, cntObj, yearProfit, community_name, country) as
with comunity_viewbase as 
(
select 
ROW_NUMBER() Over( partition by t3.custId order by t3.cRKindCode) as rowid
,t1.name, t3.custid from vCustomer t1
join Community t2 on t2.custId = t1.custId
join CustCmRight t3 on t3.cmCustId = t1.custId 
)
,comunity_view as
(
select custId, name from comunity_viewbase where rowid = 1
), comunity_items as
(
select t1.custId, max( t2.name ) as name
from TermsOfService t1
join comunity_view t2 on t2.custId = t1.custId
where 
t1.custId in (select custId from TermsOfService where ourService = 0 ) -- Мають зовнішне обслуговування
group by t1.custId 
having sum( case when ourService = 1 then 1 else 0 end ) = 0 -- не мають обслуговування у нас
)
, profit AS (SELECT        t1.custId, SUM(t2.deboborot) AS yearProfit
    FROM            dbo.Account AS t1 INNER JOIN
                    dbo.SaldoDay AS t2 ON t2.accId = t1.accId AND t2.dateBegin >= CAST(DATEADD(DAY, - DATEPART(DAYOFYEAR, GETDATE()) + 1, GETDATE()) AS date)
	where t1.custId is not null
    GROUP BY t1.custId)
, rhObjects AS ( SELECT        t2.custId, COUNT(DISTINCT t2.objId) AS cntObj
      FROM  dbo.CopyRight AS t2 
	  WHERE @date BETWEEN t2.beginDate AND t2.endDate
      GROUP BY t2.custId )
    SELECT        t1.custId, t1.status as custStatus, arh.agrStatus ,t2.innerCode, t2.interCode, t1.name, isnull(t1.registrDate, cast('1900-01-01' as date))  registrDate, ISNULL(t4.cntObj, 0) AS cntObj
	, ISNULL(t3.yearProfit, 0) AS yearProfit
	, t5.name as community_Name
	, t6.countryNameShort AS country
     FROM            dbo.vCustomer AS t1 
INNER JOIN                    dbo.RightHolder AS t2 ON t2.custId = t1.custId 
INNER JOIN                    dbo.AgreementMaster AS am ON am.custId = t1.custId 
INNER JOIN                    dbo.AgreementAddRH AS arh ON arh.agrId = am.agrId and arh.version = am.version 
LEFT OUTER JOIN               profit AS t3 ON t3.custId = t1.custId 
LEFT OUTER JOIN               rhObjects AS t4 ON t4.custId = t1.custId 
LEFT OUTER JOIN				  comunity_items t5 on t5.custid = t1.custid
LEFT JOIN Country AS t6 ON t6.countryCode = t1.countryCode
)