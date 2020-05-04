CREATE function  [dbo].[ft_Tsk_5_25_SRLic] (@dateBegin date = NULL, @dateEnd date = NULL,  @rateCommiss integer = NULL, @cmCustId integer = NULL )
--* Роялті до розподілу від користувачів МП по договорах /ft_Tsk_5_25_SRLic
-- @rateCommiss - по конкретной комиссии. NULL / -1 - все комиссии
-- @cmCustId - ПО ТОВАРИСТВУ.  0, null - ПО ВСЕМ
-- 19-07-2019 дорозподіл
RETURNS @RT TABLE
(id integer identity primary key,
licCode integer, 
licName varchar(200), 
amount money, 
rowNum integer
)
as
BEGIN

--Первый день месяца
set @dateBegin = isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())

set @rateCommiss = (Case When isnull(@rateCommiss,-1) = -1 Then NULL Else @rateCommiss end)
set @cmCustId = (Case When isnull(@cmCustId,0) = 0 Then NULL Else @cmCustId end)

--Если лицензи нул - беру по видам использования
;with TabRt as 
(
select licCode,  sum(Amount) as Amount
from ft_Tsk_5_25_2_SRLic (@dateBegin, @dateEnd,@rateCommiss, @cmCustId ) 
group by licCode
)
insert into @RT (licCode, licName, amount, rowNum)
select t1.licCode, isnull(isnull(t2.Name, t3.name),'Дорозподілено АВ') as licName, t1.Amount
, 1--ROW_NUMBER() OVER( ORDER BY 2) 
from TabRt t1
left join AgrLicenseType t2 on t1.licCode = t2.codeI and t1.licCode > 0 
left join CopyrightKind t3 on -1*t1.licCode = t3.codeI and t1.licCode < 0
order by 2

RETURN
END

--select * from dbo.ft_Tsk_5_25_SRLic ('2019-07-19',  '2019-07-19', NULL, NULL) order by rownum

GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_25_SRLic] TO [ReportUser]
    AS [dbo];

