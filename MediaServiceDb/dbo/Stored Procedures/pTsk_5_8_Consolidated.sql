CREATE procedure  [dbo].[pTsk_5_8_Consolidated]  (@beginDate date = NULL, @endDate date = NULL)

AS

Begin 
--9. Розподіл авторської
--Зведена
set  @beginDate =  isnull(@beginDate, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @endDate = isnull(@endDate, getdate())

if @beginDate>@endDate
		return

declare @myCm integer, @myCmName varchar(100)
set @myCm = (select max(custId) from vMyAnk)
set @myCmName = (select max(name) from vMyAnk)

declare @RT TABLE 
(categoryCode integer, 
 categoryName varchar(200), 
 cmName varchar(200), 
 cmCustId integer,
 cmFlag integer, 
 sCollectm money, 
 sCommiss money,
 sDistrib money
)

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

 select * from @RT order by categoryCode, cmFlag, cmName

 end
-- exec pTsk_5_8_Consolidated '2018-01-01', null
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pTsk_5_8_Consolidated] TO [ReportUser]
    AS [dbo];

