CREATE function  [dbo].[ft_Tsk_5_15_RegisterBR]  ( @dateBegin date = NULL, @dateEnd date = NULL)
--Реестры Больших прав за период 
-- Беру Р/Л в период и смотрю результат 
RETURNS @RT TABLE
(
id integer not null identity primary key,
custId      integer, --клиент
custName    varchar(100),
periodId    integer,
periodName	varchar(100), 
beginDate	date, 
endDate	    date, 
rmId        integer, 
codeItem	integer, 
itemName	varchar(100), 
objid       integer, 
distId      integer,
authorCustId integer, 
authorName	varchar(100),
rateRole	decimal(5,2),
rate    	decimal(5,2),
amount      money, 
regId integer, 
regItemId integer,
status integer
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
custId      integer, --клиент
custName    varchar(100),
periodId    integer,
periodName	varchar(100), 
beginDate	date, 
endDate	    date, 
rmId        integer, 
codeItem	integer, 
itemName	varchar(100), 
objid       integer, 
distId      integer,
authorCustId integer, 
authorName	varchar(100),
rateRole	decimal(5,2),
rate    	decimal(5,2),
amount      money, 
regId integer, 
regItemId integer,
status integer
)

--Остатки по распределению
insert into @TmpRT
( custId, authorCustId, objid, amount, regId, regItemId )
SELECT 
clCustId, rhCustId, objid, amount, regId, regItemId
 from ft_Tsk_5_DISTRIBUTEDRED (@dateBegin, @dateEnd, 6, NULL) 

declare @TabObj table
(id integer not null identity, 
 objid integer not null, 
 regId integer  null, 
 custId integer null
 primary key (objid, id) )

insert into @TabObj (objid, regId, custId) 
select distinct objid, regId, custId
   from @TmpRT 

update @TmpRT set rate = t2.rate, rateRole = t2.roleRate, status = t2.status
  from @TmpRT  t1 
   join CopyRight t2 on t1.objid = t2.objid and t1.authorCustId = t2.custId
 
--добавляю недостающих авторов
insert into @TmpRT (custId, objid, authorCustId, rate, rateRole, regId, status)
 select distinct t1.custId, t1.objid, t2.custId, t2.rate, t2.roleRate, t1.regId, t2.status
   from @TmpRT t1 
    join CopyRight t2 on t1.objid = t2.objId
	and not exists ( select 1 from @TmpRT t3 where t2.objid = t1.objid and t3.authorCustId = t2.custId )

update @TmpRT 
  set authorName = isnull(t2.name, ' НЕ ВИЗНАЧЕНИЙ') 
   from @TmpRT  t1 
    left join vCustomer t2 on t1.authorCustId = t2.custId

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
   set itemName = t2.name 
    from @TmpRT t1 
	 join objectRight t2 on t1.objid = t2.objid 

insert into @RT (custId, custName, periodId, periodName, beginDate, endDate, rmId, codeItem, itemName, objid, distId, authorCustId, authorName, rateRole, rate, amount, regId,regItemId,status)
select custId, custName, periodId, periodName, beginDate, endDate, rmId, codeItem, itemName, objid, distId, authorCustId, authorName, rateRole, rate, amount, regId,regItemId,status
 from @TmpRT 
 order by custName, beginDate, itemName, authorName

RETURN
END

--select  * from dbo.ft_Tsk_5_15_RegisterBR  ('2019-01-01', '2028-12-01') --31097,11