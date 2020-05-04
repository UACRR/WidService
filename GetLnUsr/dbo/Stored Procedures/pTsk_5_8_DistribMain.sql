CREATE procedure [dbo].[pTsk_5_8_DistribMain] ( @dateBegin date = NULL, @dateEnd date = NULL, @cmFlag int,@categoryCode integer, @cmCustId integer)
as 
BEGIN

declare @result Table 
-- @cmFlag теперь  = cmCustId 13-12-2019
--Create Table #result  
(
id integer not null identity primary key, 
custId integer null, 
categoryCode integer, 
cmFlag smallint,
sCollect money, 
sCommiss money, 
sDistrib money,
rateCommiss decimal(10,5),
cmCustId integer, 
cmCustIdName varchar(100)
)
 


--declare @categoryCode integer = 5, @datebegin date = '2019-12-12', @dateEnd date = '2019-12-12', @cmFlag integer = NULL, @cmCustId integer =2

set  @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())

if  (@categoryCode not in (5,6))
	return
--if (@cmFlag not in (0,1))
--	return

if (@dateBegin>@dateEnd)
	return

--set @cmFlag = (CASE When @cmFlag = 0 Then -1 else @cmFlag end)

delete @result
insert into @result
( custId,	sCollect,	sCommiss,	sDistrib,	rateCommiss, categoryCode, cmFlag, cmCustId)
select custId,  sCollect, sCommiss,	sDistrib,	rateCommiss, categoryCode, cmFlag, cmCustId
  from ft_Tsk_5_8_DistribMain  ( @dateBegin, @dateEnd, @cmFlag, @categoryCode, @cmCustId ) t1 
  --from ft_Tsk_5_8_DistribMain  ( '2019-01-01', '3000-01-01', 0, 5 )  

select ROW_NUMBER() OVER(ORDER BY t2.name ASC) id, isnull(t2.name, 'НЕ ВИЗНАЧЕНО') as name, 
 t1.custId, isnull(t2.innerCode, t1.custId) as innerCode, 
 t1.sCollect, t1.sCommiss, t1.sDistrib, t1.rateCommiss, cmFlag, cmCustId--, t3.name as cmCustIdName
 from 
(select *
from @result t0 where
isnull(@cmFlag, t0.cmFlag) = t0.cmFlag  and
isnull(@cmCustId, t0.cmCustId) = t0.cmCustId and 
@categoryCode = t0.categoryCode 
) t1
left join  vCustomerRHolder t2 on t1.custid  = t2.custId 
left join  vCustomerRHolder t3 on t1.cmCustId  = t3.custId 

RETURN
END



--exec pTsk_5_8_DistribMain '2019-12-12', '2019-12-12', NULL, 5,4441
--select * from ft_Tsk_5_8_DistribMain  ( '2019-12-12', '2019-12-12',0 ,5, 2)

GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pTsk_5_8_DistribMain] TO [ReportUser]
    AS [dbo];

