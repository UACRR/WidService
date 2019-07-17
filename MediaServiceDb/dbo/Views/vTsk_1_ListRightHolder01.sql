CREATE view [dbo].[vTsk_1_ListRightHolder01] (custId, custStatus, agrStatus, innerCode, interCode, name, registrDate, agreementDate, cntObj, yearProfit, country, custType, rHolderType , rHolderTypeName ) as
with 
--24-06-2019 agreementDate
profit AS (SELECT        t1.custId, SUM(t2.deboborot) AS yearProfit
    FROM            dbo.Account AS t1 INNER JOIN
                    dbo.SaldoDay AS t2 ON t2.accId = t1.accId AND t2.dateBegin >= CAST(DATEADD(DAY, - DATEPART(DAYOFYEAR, GETDATE()) + 1, GETDATE()) AS date)
	where t1.custId is not null
    GROUP BY t1.custId)
, 
rhObjects AS ( SELECT        t2.custId, COUNT(DISTINCT t2.objId) AS cntObj
      FROM  dbo.CopyRight AS t2 
	  WHERE GETDATE() BETWEEN t2.beginDate AND t2.endDate
      GROUP BY t2.custId )
    SELECT        t1.custId, 
	--t1.status as custStatus, 
	t1.custStatus, 
	arh.agrStatus, t2.innerCode, t2.interCode, t1.name, isnull(t1.registrDate, cast('1900-01-01' as date))  registrDate, arh.agrDate as agreementDate, ISNULL(t4.cntObj, 0) AS cntObj
	, ISNULL(t3.yearProfit, 0) AS yearProfit
	--, '' as communityName
	, t6.countryNameShort AS country
	, t1.custType
	, isnull(t2.rHolderType, 1) as rHolderType
	, (case when isnull(t2.rHolderType,1) = 1 Then '' else  t7.name end ) as rhTypeName
     FROM            vCustomerRHolder t1 --dbo.vCustomer AS t1 
JOIN                 dbo.RightHolder AS t2 ON t2.custId = t1.custId 
left JOIN            dbo.AgreementMaster AS am ON am.custId = t1.custId 
left JOIN            dbo.AgreementAddRH AS arh ON arh.agrId = am.agrId and arh.version = am.version 
LEFT OUTER JOIN      profit AS t3 ON t3.custId = t1.custId 
LEFT OUTER JOIN      rhObjects AS t4 ON t4.custId = t1.custId 
LEFT JOIN            Country AS t6 ON t6.countryCode = t1.countryCode
left join            RHolderType t7 on t7.codei = t1.rHolderType