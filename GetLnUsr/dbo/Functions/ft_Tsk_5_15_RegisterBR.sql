

CREATE function  [dbo].[ft_Tsk_5_15_RegisterBR]  ( @dateBegin date = NULL, @dateEnd date = NULL, @cmCustId integer = NULL)
--Реестры Больших прав за период 
-- Беру Р/Л в период и смотрю результат 
---@cmCustId = -1 по Невизначеним товариствам, 0, NULL - по всем товариствам. По товариству.
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
status integer,
cmCustId integer, 
cmName varchar(100)
)
AS
BEGIN  

--declare @dateBegin date, @dateEnd date, @cRightKind integer, @category integer
set  @dateBegin  =  (Case WHEN isnull(@dateBegin , '1900-01-01') ='1900-01-01'
                    THEN convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102)
                    ELSE @dateBegin  END)
set @dateEnd = isnull(@dateEnd, getdate())
set @cmCustId = ( Case When @cmCustId = 0 Then NULL else @cmCustId end )

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
status integer,
cmCustId integer
)

--Остатки по распределению
insert into @TmpRT
( custId, authorCustId, objid, amount, regId, regItemId, cmCustId )
SELECT 
clCustId, rhCustId, objid, amount, regId, regItemId, cmCustId
-- from ft_Tsk_5_DISTRIBUTEDRED (@dateBegin, @dateEnd, 6, NULL) 
 from ft_Tsk_5_DISTRIBUTED_CM (@dateBegin, @dateEnd, 6, NULL, @cmCustId) 
 
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
insert into @TmpRT (custId, objid, authorCustId, rate, rateRole, regId, status, cmCustId)
 select distinct t1.custId, t1.objid, t2.custId, t2.rate, t2.roleRate, t1.regId, t2.status, -1
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

insert into @RT (custId, custName, periodId, periodName, beginDate, endDate, rmId, codeItem, itemName, objid, distId, 
                  authorCustId, authorName, rateRole, rate, amount, regId,regItemId,status, cmCustId, cmName)
select t1.custId, t1.custName, periodId, periodName, beginDate, endDate, rmId, codeItem, itemName, objid, distId, 
       authorCustId, authorName, rateRole, rate, amount, regId,regItemId,status, t1.cmCustId, t2.cmName
 from @TmpRT t1 
 left join vCommunity t2 on t2.cmCustId = t1.cmCustId
  order by custName, beginDate, itemName, authorName

RETURN
END

--select  * from dbo.ft_Tsk_5_15_RegisterBR  ('2019-01-01', '2028-12-01', 138) --31097,11
--select * from ft_Tsk_5_DISTRIBUTEDRED ('2010-01-01', '2028-12-01', 6, NULL)

GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_15_RegisterBR] TO [ReportUser]
    AS [dbo];

