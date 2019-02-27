CREATE function  [dbo].[ft_Tsk_5_4_RatingRH__]  (@category integer = NULL, @cRightKind integer = NULL, @ourAuthor integer= NULL, @dateBegin date = NULL, @dateEnd date = NULL)
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
--set  @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))

set @dateEnd = isnull(@dateEnd, getdate())
set @cRightKind = (Case When isnull(@cRightKind,0) = 0 Then NULL Else @cRightKind end)
set @category = (Case When isnull(@category,0) = 0 Then NULL Else @category end)
set @ourAuthor = (Case When isnull(@ourAuthor,0) = 0 Then NULL Else @ourAuthor end)

declare @myCm integer 
set @myCm = (select max(custId) from vmyAnk)

--Розподілено на правовласників
--drop table #TmpT1 
declare @TmpT1 table 
(custId integer not null, 
 cRightKind integer not null, 
 amount money not null, 
 cntObj integer null, 
 cmCustId integer null, 
 cmName varchar(200) null, 
 cRName varchar(200) Null, 
 primary key (custId,  cRightKind) )

--сначала отбираю, чтобы потом проставить комьюнити, сразу долго работает
--declare @dateBegin date, @dateEnd date, @cRightKind integer, @category integer
delete @TmpT1 
insert into @TmpT1 (custId, amount, cntObj, cRightKind)
select isnull(t4.custId,-1),  sum(t1.amount) as amount, count(distinct t3.objid) as cntObj , cast (substring (t2.accnls,4,2) as integer)
 from payTurn t1 
  join Account t2 on t2.balsCode = 30 and 
                     t2.accId = t1.accIdCredit and cast(substring (t2.accnls,4,2) as integer) = isnull(@cRightKind, cast(substring (t2.accnls,4,2) as integer) )
  join objectRight t3 on t3.objid = t2.objId and t3.categoryCode = isnull(@category, t3.categoryCode)
  left join Account t4 on t4.accId = t1.accIdDebet --and t4.balsCode in (21,30)
  --where t1.dateWork between @dateBegin and @dateEnd
 group by t4.custId, cast(substring (t2.accnls,4,2) as integer)
 
 update @TmpT1 
    set cmCustId = t1.cmCustId, cmName = t1.cmName, cRName = t1.nameRH
  from  vCustCmService t1 
    join @TmpT1 t2 on t1.custId = t2.custId

--только наши
 IF isnull(@ourAuthor,0) = 1  
 insert into @RT ( custId, cntObj, cRName, interCode, registrDate, cmCustId, cmName, amount ) 
  select t1.custId, max(t1.cntObj), max(t1.cRName), NULL, NULL, t1.cmCustId, max(t1.cmName), sum(amount)
   from @TmpT1 t1 
    where t1.cmCustId = @myCm and isnull(@ourAuthor,0)=1
    group by t1.custId, t1.cmCustId 
	
--только не наши
 IF isnull(@ourAuthor,0) = 2 
 insert into @RT ( custId, cntObj, cRName, interCode, registrDate, cmCustId, cmName, amount ) 
  select t1.custId, max(t1.cntObj), isnull(max(t1.cRName), 'НЕ ВИЗНАЧЕНИЙ'), NULL, NULL, t1.cmCustId, isnull(max(t1.cmName), 'НЕ ВИЗНАЧЕНО'), sum(amount)
   from @TmpT1 t1 
    where isnull(t1.cmCustId,-1) <> @myCm and isnull(@ourAuthor,0)=2
    group by t1.custId, t1.cmCustId 

 --все
 IF isnull(@ourAuthor,0) = 0 
 insert into @RT ( custId, cntObj, cRName, interCode, registrDate, cmCustId, cmName, amount ) 
  select t1.custId, max(t1.cntObj), isnull(max(t1.cRName), 'НЕ ВИЗНАЧЕНИЙ'), NULL, NULL, isnull(t1.cmCustId,-1), isnull(max(t1.cmName), 'НЕ ВИЗНАЧЕНО') , sum(amount)
   from @TmpT1 t1 
    group by t1.custId, t1.cmCustId 

update @RT 
  set interCode = t2.IPI, 
      registrDate = t2.registrDate
   from @RT t1 
     join vCustomer t2 on t1.custId = t2.custId

update @RT 
  set innerCode = t2.innerCode
   from @RT t1 
     join RightHolder t2 on t1.custId = t2.custId


 RETURN
 END

--select sum(amount) from ft_Tsk_5_4_RatingRH (0, 0, 0, '2019-02-01', '3000-01-01')  --110868,35