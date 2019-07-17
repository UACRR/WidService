CREATE function  [dbo].[ft_Tsk_5_DISTRIB_AuthorCommunity]  (@beginDate date = NULL, @endDate date = NULL, @cmCustId int = NULL, @categoryCode integer = NULL, @rhType integer = NULL)
--Ф-я для отображения распределения по авторам из комьюнити
--@rhType - тип издательство/правовласник
RETURNS @RT TABLE
(
id integer not null identity primary key, 
rhCustId integer null, 
rhName varchar(254), --название автора/издателя
categoryCode integer, 
cmFlag smallint,    --0-наш, 1-чужой
sCollect money,   --зібрано
sCommiss money,   --сума комісії
sDistrib money,   --распределено
rateCommiss decimal(10,5), --%комисии
cmCustId integer,   --товариство код
cmName varchar(254), --товариство назва
rhType integer,  --тип код правовлсник/видивництво
rhTypeName varchar(100) --назва типа правовлсник/видавництво
)
AS
BEGIN 

declare @myCm integer, @myCmName varchar(100)

set  @beginDate =  (Case WHEN isnull(@beginDate, '1900-01-01') ='1900-01-01'
                    THEN convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102)
                    ELSE @beginDate END)

set @endDate = isnull(@endDate, getdate())
set @myCm = (select max(custId) from vMyAnk)
set @myCmName = (select max(name) from vMyAnk)

insert into @RT (cmCustId, categoryCode, sCollect, rhCustId, cmFlag, rhType, rhName, rateCommiss )
 select isnull(cmCustId,-1), categoryCode, amount, t1.rhCustId, (Case when cmCustId=@myCm Then 0 Else 1 end), isnull(t2.rHolderType,1), t2.name, t2.rateCommiss
   --from ft_Tsk_5_DISTRIBUTED ('2019-01-01', NULL, NULL, NULL)  
   from ft_Tsk_5_DISTRIBUTED (@beginDate, @endDate, NULL, NULL)  t1
    left join vCustomerRHolder t2 on t2.custId = t1.custId
   where categoryCode = isnull(@categoryCode, categoryCode) 
         --and  (Case when cmCustId=@myCm Then 0 Else 1 end) = isnull(@cmFlag, (Case when cmCustId=@myCm Then 0 Else 1 end))
		 and cmCustId = isnull(@cmCustID, cmCustId)
		 and isnull(t2.rHolderType,1) = isnull(@rhType, isnull(t2.rHolderType,1))
 
 update @RT set cmName = t2.name
     from @RT  t1 
      join vCustomerRHolder t2 on t2.custId = t1.cmCustId

 update @RT set rhTypeName = t2.name 
  from @RT t1 
   join RHolderType t2 on t2.codeI = t1.rhType

  update @RT set sCommiss = 	cast(sCollect*isnull(rateCommiss,0)/100 as money), 
                sDistrib = sCollect - cast(sCollect*isnull(rateCommiss,0)/100 as money)

RETURN
END

--select  sum(scollect) from ft_Tsk_5_8_DistribMain ('2019-01-01', NULL, 0, 5) --204003,22
--select  sum(scollect) from ft_Tsk_5_DISTRIB_AuthorCommunity ('2019-01-01', '2028-01-01', 138, 5, NULL) --167746,92

--select  * from ft_Tsk_5_DISTRIB_AuthorCommunity ('2018-01-01', NULL, NULL, NULL, NULL) --142213,34
--select * from ft_Tsk_5_8_DistribMainCommunity ('2018-01-01', NULL, NULL, 6) 
--(@beginDate date = NULL, @endDate date = NULL, @cmCustId int = NULL, @categoryCode integer = NULL, @rhType integer = NULL)

--select sum(amount) from ft_Tsk_5_DISTRIBUTED ('2019-01-01', NULL, NULL, NULL) where cmCustId = 138 and categoryCode = 5  --204003,22