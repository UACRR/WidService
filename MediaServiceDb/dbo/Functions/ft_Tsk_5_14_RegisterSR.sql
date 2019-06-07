CREATE function  ft_Tsk_5_14_RegisterSR  ( @dateBegin date = NULL, @dateEnd date = NULL)
--Реестры Больших прав за период 
-- Беру Р/Л в период и смотрю результат 
RETURNS @RT TABLE
(
id integer not null identity primary key,
custId integer, 
custName varchar(100),
periodId integer,
periodName	varchar(100), 
beginDate	date, 
endDate	date, 
rmId integer, 
codeItem	integer, 
itemName	varchar(100), 
performer	varchar(100),
authorMusic	varchar(100),
authorText	varchar(100),
amount money,
regId integer, 
regItemId integer,
objid integer 
)
AS
BEGIN  

--declare @dateBegin date, @dateEnd date, @cRightKind integer, @category integer
set  @dateBegin  =  (Case WHEN isnull(@dateBegin , '1900-01-01') ='1900-01-01'
                    THEN convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102)
                    ELSE @dateBegin  END)
set @dateEnd = isnull(@dateEnd, getdate())

declare @TmpRT table 
(
id integer not null identity primary key,
custId integer, 
custName varchar(100),
periodId integer,
periodName	varchar(100), 
beginDate	date, 
endDate	date, 
rmId integer, 
codeItem	integer, 
itemName	varchar(100), 
performer	varchar(100),
authorMusic	varchar(100),
authorText	varchar(100),
amount money,
regId integer, 
regItemId integer,
objid integer 
)

--Остатки по распределению
insert into @TmpRT
( custId, objid, amount, regId, regItemId )
SELECT 
max(clCustId), objid, sum(amount), regId, regItemId
 from ft_Tsk_5_DISTRIBUTEDRED(@dateBegin, @dateEnd, 5, NULL) 
  group by objid, regId, regItemId

/*update @TmpRT 
  set authorName = isnull(t2.name, ' НЕ ВИЗНАЧЕНИЙ') 
   from @TmpRT  t1 
    left join vCustomer t2 on t1.authorCustId = t2.custId
*/
 update @TmpRT
   set custName = t2.name 
   from @TmpRT  t1 
        join vCustomer t2 on t1.custId = t2.custId
 
 update @TmpRT
    set periodId = t3.periodId, 
        periodName = t4.periodName,  
        beginDate = t4.beginDate,  
        endDate = t4.endDate, 
        rmId = t3.rmId
  from @TmpRT t1 
   join Register t2 on t1.regId = t2.regId 
   join RegisterRatedList t3 on t3.rmId = t2.rmId 
   join PaidPeriod t4 on t4.periodId = t3.periodId

   update @TmpRT 
     set performer = t3.performer, 
         authorMusic = t3.authorMusic, 
         authorText = t3.authorText,
         itemName = t3.ItemName
       from @TmpRT t1 
           join registerItem t3 on t3.regId = t1.regId and t3.regIItemId = t1.regItemId

	update @TmpRT set itemName = itemName + ' ('+t2.name+')' 
	 from @TmpRT t1 
	  join ObjectRight t2 on t2.objid = t1.objId  and replace(t2.name,' ','') <> replace(t1.itemName,' ','')

insert into @RT (custId, custName, periodId, periodName, beginDate, endDate, rmId, codeItem, itemName, 
performer, authorMusic, authorText, amount, regId, regItemId, objid)
select custId, custName, periodId, periodName, beginDate, endDate, rmId, codeItem, itemName, 
performer, authorMusic, authorText, amount, regId, regItemId, objid
 from @TmpRT 
 order by itemName, performer, authorMusic, authorText

RETURN
END

--select  * from dbo.ft_Tsk_5_14_RegisterSR  ('2019-01-01', '2028-12-01') --31097,11