--drop function dbo.ft_Tsk_5_4_RatingRH
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
amount money, 
innerCode varchar(25)
)
AS
BEGIN  --Користувачі

--declare @dateBegin date, @dateEnd date, @cRightKind integer, @category integer
set  @dateBegin =  (Case WHEN isnull(@dateBegin, '1900-01-01') ='1900-01-01'
                    THEN convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102)
                    ELSE @dateBegin END)

set @dateEnd = isnull(@dateEnd, getdate())
set @cRightKind = (Case When isnull(@cRightKind,0) = 0 Then NULL Else @cRightKind end)
set @category = (Case When isnull(@category,0) = 0 Then NULL Else @category end)

declare @myCm integer --, @ourAuthor integer 
set @ourAuthor = (Case When isnull(@ourAuthor,0) = 0 Then NULL Else @ourAuthor end)
set @myCm = (select max(custId) from vMyAnk)

 insert into @RT ( custId, cntObj,  amount, cmCustId )
   select isnull(rhCustId,-1), count(distinct objid) as cntObj, sum(amount) as amount, max(cmCustId)
   --from ft_Tsk_5_DISTRIBUTED ('2019-01-01', '3000-01-01', NULL, NULL)  
   from ft_Tsk_5_DISTRIBUTED (@dateBegin, @dateEnd, @category, @cRightKind) 
   group by  rhCustId

/*
 update @RT set cmCustId = isnull(t2.cmCustId, -1), 
                cmName = isnull(t2.cmName, 'НЕ ВИЗНАЧЕНО') 
    from  @RT t1 
    left join  vCustCmService t2 on t1.custId = t2.custId  
          --and t2.ourService = isnull(@myCm, t2.ourService)
		  
		  and t2.ourService = isnull(NULL, t2.ourService)
*/

  if isnull(@ourAuthor,0) = 1 --наш  
  delete  @RT where cmCustID <> @myCm

  if isnull(@ourAuthor,0) = 2 --не наш  
  delete  @RT where cmCustID = @myCm

  update @RT 
      set cRName = t2.name, 
          interCode = t2.IPI, 
          registrDate = t2.registrDate 
          --,innerCode = t2.innerCode 
       from  @RT t1 
          join  vCustomer t2 on t1.custId = t2.custId
---!
  update @RT 
      set cmName = isnull(t2.name, 'НЕ ВИЗНАЧЕНО')
       from  @RT t1 
          left join  vCustomer t2 on t1.custId = t2.custId

 update @RT 
   set innerCode = t2.innerCode
   from @RT t1 
     join RightHolder t2 on t1.custId = t2.custId
  
 update @RT set cRName = 'НЕ ВИЗНАЧЕНИЙ' where custId = -1

 RETURN
 END

--select sum(amount) from ft_Tsk_5_4_RatingRH__ (0, 0, 0, '2017-01-01', '3000-01-01')  --110868,35
--select sum(amount) from ft_Tsk_5_4_RatingRH (5, 1, 0, '2019-01-01', '3000-01-01')  --110868,35
--select * from ft_Tsk_5_4_RatingRH (0, 1, 0, '2019-01-01', '3000-01-01')  --110868,35
--select 96853.42 + 45120.65
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_4_RatingRH] TO [ReportUser]
    AS [dbo];

