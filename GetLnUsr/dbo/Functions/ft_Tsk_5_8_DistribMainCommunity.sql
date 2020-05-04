CREATE function  [dbo].[ft_Tsk_5_8_DistribMainCommunity]  (@beginDate date = NULL, @endDate date = NULL, @cmFlag int, @categoryCode integer )
--0-УААСП, 1-інші
--13. Відомість 'Розподіл авторської винагороди на правовласників з 'великих прав''
RETURNS @RT TABLE
(
id integer not null identity primary key, 
custId integer null, 
categoryCode integer, 
cmFlag smallint,
sCollect money, 
sCommiss money, 
sDistrib money,
rateCommiss decimal(10,5), 
cmCustId integer
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

insert into @RT (custId, categoryCode, sCollect, cmCustId, cmFlag )
 select isnull(cmCustId,-1), categoryCode, sum(amount) as amount, cmCustId, 
       (Case when cmCustId=@myCm Then 0 Else 1 end)
   --from ft_Tsk_5_DISTRIBUTED ('2019-01-01', NULL, NULL, NULL)  
   from ft_Tsk_5_DISTRIBUTED (@beginDate, @endDate, NULL, NULL) 
   where categoryCode = isnull(@categoryCode, categoryCode) 
         and   (Case when cmCustId=@myCm Then 0 Else 1 end) = isnull(@cmFlag, (Case when cmCustId=@myCm Then 0 Else 1 end))
 group by  categoryCode, cmCustId

 update @RT set rateCommiss = t3.rateCommiss
     from @RT  t1 
	 join AgreementMaster t2 on t2.custId = t1.custId
	 join AgreementAddCommunity t3 on t3.agrId = t2.agrId and t3.version = t2.version

 update @RT set sCommiss = 	cast(sCollect*isnull(rateCommiss,0)/100 as money), 
                sDistrib = sCollect - cast(sCollect*isnull(rateCommiss,0)/100 as money)

RETURN
END

--select  sum(scollect) from ft_Tsk_5_8_DistribMain ('2019-01-01', NULL, 0, 5) --142213,34
--select  * from ft_Tsk_5_8_DistribMain ('2019-01-01', NULL, NULL, NULL) --142213,34
--select * from ft_Tsk_5_8_DistribMainCommunity ('2018-01-01', NULL, NULL, 6) 

 
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_8_DistribMainCommunity] TO [ReportUser]
    AS [dbo];

