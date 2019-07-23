CREATE function ft_Tsk_1_ListRightHolder01_ (@status integer NULL, @strSeek varchar(254) = NULL) 
--Правовласники - окно
--@status = NULL - все, -1-без договора
RETURNS @RT table 
(custId integer not null primary key, 
 custStatus integer, 
 agrStatus integer, 
 innerCode varchar(50), 
 interCode varchar(50), 
 name varchar(254), 
 registrDate date, 
 cntObj integer, 
 yearProfit money, 
 community_Name varchar(254), 
 country varchar(100), 
 custType integer)
 as BEGIN 
--CREATE view [dbo].[vTsk_1_ListRightHolder01] (custId, custStatus, agrStatus,innerCode, interCode, name, registrDate, cntObj, yearProfit, community_name, country) as

IF isnull(@strSeek, '') = ''  
BEGIN 
;with 
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

insert into @RT (custId, custStatus, agrStatus,innerCode, interCode, name, registrDate, cntObj, yearProfit, community_name, country, custType)
SELECT t1.custId, t1.status as custStatus, arh.agrStatus ,t2.innerCode, t2.interCode, t1.name, 
       isnull(t1.registrDate, cast('1900-01-01' as date))  registrDate, ISNULL(t4.cntObj, 0) AS cntObj
	, ISNULL(t3.yearProfit, 0) AS yearProfit
	--, t5.cmName as communityName
	, '' as community_name
	, t6.countryNameShort AS country, t1.custType
     FROM            dbo.vCustomer AS t1 
JOIN                    dbo.RightHolder AS t2 ON t2.custId = t1.custId 
left JOIN                    dbo.AgreementMaster AS am ON am.custId = t1.custId 
left JOIN                    dbo.AgreementAddRH AS arh ON arh.agrId = am.agrId and arh.version = am.version 
LEFT OUTER JOIN               profit AS t3 ON t3.custId = t1.custId 
LEFT OUTER JOIN               rhObjects AS t4 ON t4.custId = t1.custId 
--LEFT OUTER JOIN				  comunity_items t5 on t5.custid = t1.custid
LEFT JOIN Country AS t6 ON t6.countryCode = t1.countryCode
where isnull(arh.agrStatus, -1) = isnull(@status, isnull(arh.agrStatus, -1))
END
ELSE 
--З Пошуком
BEGIN 
  declare @test varchar(100) = 'test qwerty asdf'
  declare @split table ( value varchar(100) );
  declare @index int;

  set @test = rtrim( ltrim( @strSeek ));

  set @index = charindex(' ', @test );
  while @index > 0 
    begin
        insert into @split values( substring( @test, 1, @index - 1 ) );
        set @test = ltrim(substring( @test, @index, len(@test)) );
        set @index = charindex(' ', @test );
    end

   if( len( @test ) > 0 )
   insert into @split values( @test );

---Сам запрос
;with 
  profit AS 
 (SELECT  t1.custId, SUM(t2.deboborot) AS yearProfit
    FROM   dbo.Account as t1 INNER JOIN
          dbo.SaldoDay as t2 ON t2.accId = t1.accId AND t2.dateBegin >= CAST(DATEADD(DAY, - DATEPART(DAYOFYEAR, GETDATE()) + 1, GETDATE()) AS date)
    where t1.custId is not null
    GROUP BY t1.custId
 ), 
  rhObjects AS 
 ( SELECT        t2.custId, COUNT(DISTINCT t2.objId) AS cntObj
      FROM  dbo.CopyRight AS t2 
      WHERE GETDATE() BETWEEN t2.beginDate AND t2.endDate
      GROUP BY t2.custId 
 )
insert into @RT (custId, custStatus, agrStatus, innerCode, interCode, name, registrDate, cntObj, yearProfit, community_name, country, custType)
SELECT t1.custId, t1.status as custStatus, arh.agrStatus ,t2.innerCode, t2.interCode, t1.name, 
       isnull(t1.registrDate, cast('1900-01-01' as date))  registrDate, ISNULL(t4.cntObj, 0) AS cntObj
	, ISNULL(t3.yearProfit, 0) AS yearProfit
	--, t5.cmName as communityName
	, '' as community_name
	, t6.countryNameShort AS country, t1.custType
 FROM            dbo.vCustomer AS t1 
   JOIN          dbo.RightHolder AS t2 ON t2.custId = t1.custId 
   left JOIN     dbo.AgreementMaster AS am ON am.custId = t1.custId 
   left JOIN     dbo.AgreementAddRH AS arh ON arh.agrId = am.agrId and arh.version = am.version 
   LEFT OUTER JOIN   profit AS t3 ON t3.custId = t1.custId 
   LEFT OUTER JOIN   rhObjects AS t4 ON t4.custId = t1.custId 
--LEFT OUTER JOIN				  comunity_items t5 on t5.custid = t1.custid
   LEFT JOIN Country AS t6 ON t6.countryCode = t1.countryCode
   CROSS APPLY @split t33 
 WHERE isnull(arh.agrStatus, -1) = isnull(@status, isnull(arh.agrStatus, -1))
    and 
    (t1.name like '%'+t33.value+'%' 
     or t6.countryName like '%'+t33.value+'%' 
     or t2.innerCode like '%'+t33.value+'%'  
     or t2.interCode like '%'+t33.value+'%'  
     or arh.agrNumber like '%'+t33.value+'%'  
    )

END 


RETURN 
END
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_1_ListRightHolder01_] TO [ReportUser]
    AS [dbo];

