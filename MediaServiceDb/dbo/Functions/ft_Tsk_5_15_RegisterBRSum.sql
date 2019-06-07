CREATE function  [dbo].[ft_Tsk_5_15_RegisterBRSum]  ( @dateBegin date = NULL, @dateEnd date = NULL)
--Реестры Больших прав за период по Distribution & Registry
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
amount      money
)
AS
BEGIN  

--declare @dateBegin date, @dateEnd date, @cRightKind integer, @category integer
set @dateBegin = isnull(@dateBegin, (select convert(date, (convert(char(4),year(getdate()))+'-01-01'))))
set @dateEnd = isnull(@dateEnd, getdate())

insert into @RT 
( custId, custName, beginDate, endDate, authorCustId, authorName, objid, itemName, rateRole, rate, amount )
select max(custId), max(custName), min(beginDate), max(endDate), authorCustId,  max(authorName), objid, max(itemName), max(rate), max(rateRole), sum(amount)
 from dbo.ft_Tsk_5_15_RegisterBR  (@dateBegin, @dateEnd) 
 group by authorCustId, objid
order by 6,8
RETURN
END

--select  * from dbo.ft_Tsk_5_15_RegisterBRSum ('2019-01-01', '2028-12-01')
--select  * from dbo.ft_Tsk_5_15_RegisterBR  ('2019-01-01', '2028-12-01') --31097,11