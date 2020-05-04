/****** Object:  StoredProcedure [dbo].[pTsk_5_8_ConsolidDetail]    Script Date: 24.06.2019 11:26:46 ******/
CREATE procedure [dbo].[pTsk_5_8_ConsolidDetail] ( @dateBegin date , @dateEnd date, @cmCustId int, @categoryCode integer )
as 
BEGIN
--10		Розподіл	Розподіл  авторської винагороди	"pTsk_5_8_Consolidated /ft_Tsk_5_8_DistribMain "
--Деталізація

declare @RT Table 
--Create Table #RT  
(
id integer not null identity primary key, 
custId integer null, 
rhName varchar(254), 
innerCode varchar(50), 
categoryCode integer, 
cmFlag smallint,
sCollect money, 
sCommiss money, 
sDistrib money,
rateCommiss decimal(10,5),
rhType integer,  --тип код правовлсник/видивництво
rhTypeName varchar(100), --назва типа правовлсник/видавництво
cmCustId integer
)

set  @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set  @dateEnd = isnull(@dateEnd, getdate())
declare @myCm integer

if (@dateBegin>@dateEnd)
	return

delete @RT

insert into @RT (cmCustId, categoryCode, sCollect, custId, cmFlag, rhType, rhName, rateCommiss, sCommiss, sDistrib, innerCode )
 select isnull(cmCustId,-1)
       , categoryCode
	   , sum(amount) as sCollect
	   , t1.rhCustId
	   , max((Case when cmCustId=@myCm Then 0 Else 1 end))
	   , max(isnull(t2.rHolderType,1))
	   , max(t2.name)
	   , max(t2.rateCommiss)
	   , cast(sum(amount*(isnull(t2.rateCommiss,0)/100)) as money) as sCommiss
	   , sum(amount) - cast(sum(amount*isnull(t2.rateCommiss,0)/100) as money) as sDistrib
	   , max(isnull(t2.innerCode, cast(t1.rhCustId as varchar(50))))
   --select sum(amount) from ft_Tsk_5_DISTRIBUTED ('2018-01-01', NULL, 5, NULL)  where cmCustid = 316  and categoryCode = 5 --11506,03
   --from ft_Tsk_5_DISTRIBUTED ('2018-01-01', NULL, 5, NULL) t1
   from ft_Tsk_5_DISTRIBUTED (@dateBegin, @dateEnd, @categoryCode,  NULL )  t1
    left join vCustomerRHolder t2 on t2.custId = t1.rhCustId
   where cmCustId = isnull(@cmCustID, cmCustId)
   group by t1.categoryCode, t1.rhCustId, t1.cmCustId
   having sum(amount) <> 0 
  
    
  update @RT set rhTypeName = t2.name 
  from @RT t1 
   join RHolderType t2 on t2.codeI = t1.rhType

select ROW_NUMBER() OVER(ORDER BY rhType, rhName ASC) id, isnull(t1.rhName, 'НЕ ВИЗНАЧЕНО') as name, 
 t1.innerCode, t1.sCollect, t1.sCommiss, t1.sDistrib, t1.rateCommiss, cmFlag, rhType, rhTypeName, custId
 from @RT t1
 
--select * from @RT
 
RETURN
END

--exec pTsk_5_8_ConsolidDetail '2018-01-01', '2028-01-01', 315, 5




GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pTsk_5_8_ConsolidDetail] TO [robot]
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pTsk_5_8_ConsolidDetail] TO [ReportUser]
    AS [dbo];

