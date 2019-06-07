create view vtsk_4_CUSTOMER_PROFITFORYEAR as 
SELECT        t1.custId
, SUM(t2.deboborot) AS yearProfit
FROM dbo.Account AS t1 INNER JOIN
dbo.SaldoDay AS t2 ON t2.accId = t1.accId AND t2.dateBegin >= CAST(DATEADD(DAY, - DATEPART(DAYOFYEAR, GETDATE()) + 1, GETDATE()) AS date)
where t1.balsCode % 10 = 0 
GROUP BY t1.custId