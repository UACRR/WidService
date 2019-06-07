CREATE procedure  [dbo].[pTsk_5_8_Consolidated]  (@beginDate date = NULL, @endDate date = NULL)

AS

Begin 
--Користувачі

set  @beginDate =  (Case WHEN isnull(@beginDate, '1900-01-01') ='1900-01-01'
                    THEN convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102)
                    ELSE @beginDate END)

set @endDate = isnull(@endDate, getdate())

if @beginDate>@endDate
		return

declare @myCmName varchar(100)
set @myCmName = (select max(name) from vMyAnk)

--select categoryCode, cmFlag, categoryName, cmFlagName, sCollectm, sCommiss, sDistrib
-- from ft_Tsk_5_8_Consolidated (@beginDate, @endDate )

select t1.categoryCode, t1.cmFlag, max(t2.name) as categoryName, 
       (Case When cmFlag = 0 Then  @myCmName else 'Інші товариства'  END) as cmFlagName,
       sum(isnull(sCollect,0)) as sCollectm, 
       sum(isnull(sCommiss,0)) as sCommiss, sum(isnull(sDistrib,0)) as sDistrib
 from ft_Tsk_5_8_DistribMain (@beginDate, @endDate,NULL, NULL ) t1 
 join vCategory t2 on t2.codeI = t1.categoryCode
 group by categoryCode, cmFlag

 end
-- exec pTsk_5_8_Consolidated null, null