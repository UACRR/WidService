CREATE function  [dbo].[ft_Tsk_5_8_Consolidated]  (@beginDate date = NULL, @endDate date = NULL)
RETURNS @RT TABLE
(categoryCode integer, 
 categoryName varchar(200), 
 cmName varchar(200), 
 cmCustId integer,
 cmFlag integer, 
 sCollectm money, 
 sCommiss money,
 sDistrib money
)
AS
BEGIN 

declare @myCm integer, @myCmName varchar(100)

set  @beginDate =  (Case WHEN isnull(@beginDate, '1900-01-01') ='1900-01-01'
                    THEN convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102)
                    ELSE @beginDate END)

set @endDate = isnull(@endDate, getdate())
set @myCm = (select max(custId) from vMyAnk)
set @myCmName = (select max(name) from vMyAnk)


 insert into @RT (cmCustId, categoryCode, cmFlag, sCollectm, sCommiss, sDistrib)
 select   t1.cmCustId
        , categoryCode
		, (Case when cmCustId=@myCm Then 0 Else 1 end)
		--, (Case when cmCustId=138 Then 0 Else 1 end)
		, sum(amount) as sCollectm
		, cast(sum(amount*(isnull(t2.rateCommiss,0)/100)) as money) as sCommiss
		, sum(amount) - cast(sum(amount*isnull(t2.rateCommiss,0)/100) as money) as sDistrib
   --from ft_Tsk_5_DISTRIBUTED ('2019-01-01', NULL, NULL, NULL)  t1
   from ft_Tsk_5_DISTRIBUTED (@beginDate, @endDate, NULL, NULL)  t1
     left join vCustomerRHolder t2 on t2.custId = t1.custId
   group by  t1.cmCustId, categoryCode

 
 update @RT set categoryName = t2.name
   from @RT t1 
     join vCategory t2 on t2.codeI = t1.categoryCode

 update @RT set cmName = t2.name
   from @RT t1 
     join vCustomerCommunity t2 on t2.custId = t1.cmCustId

RETURN
END

--select  * from ft_Tsk_5_8_Consolidated ('2018-01-01', NULL) order by categoryCode, cmFlag, cmName --142213,34 
--select  * from ft_Tsk_5_8_Consolidated ('2019-01-01', NULL) --142213,34