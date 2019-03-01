CREATE procedure [dbo].[pTsk_5_8_DistribMain] ( @dateBegin date = NULL, @dateEnd date = NULL, @cmFlag int,@categoryCode integer )
as 
BEGIN

declare @result Table 
--Create Table #result  
(
id integer not null identity primary key, 
custId integer null, 
categoryCode integer, 
cmFlag smallint,
sCollect money, 
sCommiss money, 
sDistrib money,
rateCommiss decimal(10,5)  
)
 

set  @dateBegin  =  (Case WHEN isnull(@dateBegin , '1900-01-01') ='1900-01-01'
                    THEN convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102)
                    ELSE @dateBegin  END)

set @dateEnd = isnull(@dateEnd, getdate())

if  (@categoryCode not in (5,6))
	return
if (@cmFlag not in (0,1))
	return
if (@dateBegin>@dateEnd)
	return

set @cmFlag = (CASE When @cmFlag = 0 Then NULL else @cmFlag end)

delete @result
insert into @result
( custId,	sCollect,	sCommiss,	sDistrib,	rateCommiss, categoryCode, cmFlag)
select custId,  sCollect, sCommiss,	sDistrib,	rateCommiss, categoryCode, cmFlag
  from ft_Tsk_5_8_DistribMain  ( @dateBegin, @dateEnd, @cmFlag, @categoryCode ) t1 
  --from ft_Tsk_5_8_DistribMain  ( '2019-01-01', '3000-01-01', 0, 5 )  

select ROW_NUMBER() OVER(ORDER BY name ASC) id, isnull(t2.name, 'НЕ ВИЗНАЧЕНО') as name, isnull(t3.innerCode, t1.custId) as innerCode, t1.sCollect, t1.sCommiss, t1.sDistrib, t1.rateCommiss, 
cmFlag
 from 
(select *
from @result where
isnull(@cmFlag,cmFlag)=cmFlag  and
@categoryCode=categoryCode 
) t1
left join  vCustomer t2 on t1.custid  = t2.custId 
left join  RightHolder t3 on t1.custId=t3.custId

RETURN
END



--exec pTsk_5_8_DistribMain '2019-02-27', '2019-02-27', 0, 5