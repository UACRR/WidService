CREATE function  [dbo].[ft_Tsk_5_8_Consolidated_]  (@beginDate date = NULL, @endDate date = NULL)
RETURNS @RT TABLE
(categoryCode integer, 
 categoryName varchar(200), 
 cmFlagName varchar(200), 
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

declare @TmpRh table
( id integer not null identity primary key, 
  rhCustId integer, 
  objid integer, 
  categoryCode integer,
  amount money, 
  cmCustId integer, 
  rate decimal(10,5), 
  cmFlag integer, 
  cmFlagName varchar(200)
)
insert into @TmpRh (rhCustId, categoryCode, amount, cmCustId, cmFlag, cmFlagName)
 select isnull(rhCustId,-1), categoryCode, sum(amount) as amount, cmCustId, 
       (Case when cmCustId=@myCm Then 0 Else 1 end),
       (Case when cmCustId=@myCm Then @myCmName Else 'Інші Товариства' end)
   --from ft_Tsk_5_DISTRIBUTED ('2019-01-01', NULL, NULL, NULL)  
   from ft_Tsk_5_DISTRIBUTED (@beginDate, @endDate, NULL, NULL) 
   group by  rhCustId, categoryCode, cmCustId

 update @TmpRh set rate = t3.rateCommiss
     from @TmpRh  t1 
	 join AgreementMaster t2 on t2.custId = t1.rhCustId
	 join AgreementAddRH t3 on t3.agrId = t2.agrId and t3.version = t2.version
	 
 insert into @RT (categoryCode, cmFlagName, sCollectm, sCommiss, sDistrib, cmFlag) 
   select categoryCode, max(cmFlagName), sum(amount),  cast(sum(amount*rate/100) as money), sum(amount) - cast(sum(amount*rate/100) as money), cmFlag
    from @TmpRh 
	group by categoryCode, cmFlag
 
 update @RT set categoryName = t2.name
   from @RT t1 
     join vCategory t2 on t2.codeI = t1.categoryCode

RETURN
END

--select  * from ft_Tsk_5_8_Consolidated ('2019-01-01', NULL) --142213,34
--select  * from ft_Tsk_5_8_Consolidated ('2019-01-01', NULL) --142213,34
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_8_Consolidated_] TO [ReportUser]
    AS [dbo];

