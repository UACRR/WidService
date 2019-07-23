CREATE function  [dbo].[ft_Tsk_5_15_RegisterBRSum]  ( @dateBegin date = NULL, @dateEnd date = NULL, @cmCustId integer = NULL)
--Реестры Больших прав за период по Distribution & Registry
--16. Реєстр розподіл авторської винагороди на правовласників з 'великіх прав ' (зведений)
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
cmCustId    integer, 
cmName varchar(100)
)
AS
BEGIN  

--declare @dateBegin date, @dateEnd date, @cRightKind integer, @category integer
set @dateBegin = isnull(@dateBegin, (select convert(date, (convert(char(4),year(getdate()))+'-01-01'))))
set @dateEnd = isnull(@dateEnd, getdate())

insert into @RT 
( custId, custName, beginDate, endDate, authorCustId, authorName, objid, itemName, rateRole, rate, amount, cmCustId, cmName )
select max(custId), max(custName), min(beginDate), max(endDate), authorCustId,  max(authorName), objid, max(itemName), max(rate),
       max(rateRole), sum(amount), cmCustId, max(cmName)
 from dbo.ft_Tsk_5_15_RegisterBR  (@dateBegin, @dateEnd, @cmCustId) 
 group by authorCustId, cmCustId, objid
order by 6,8
RETURN
END

--select  * from dbo.ft_Tsk_5_15_RegisterBRSum ('2010-01-01', '2028-12-01', 0) order by authorName
--select  * from dbo.ft_Tsk_5_15_RegisterBR  ('2010-01-01', '2028-12-01', NULL) --31097,11
--select * from ft_Tsk_5_DISTRIBUTEDRED ('2010-01-01', '2028-12-01', 6, NULL)
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_15_RegisterBRSum] TO [ReportUser]
    AS [dbo];

