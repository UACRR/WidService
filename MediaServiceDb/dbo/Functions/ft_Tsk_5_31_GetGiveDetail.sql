--drop functionft_Tsk_5_31_GetGiveSR
CREATE function  [dbo].[ft_Tsk_5_31_GetGiveDetail]  (@custId integer, @dateBegin date = NULL, @dateEnd date = NULL)
-- Відомість коштів Користувачів, що отримані та розподілені на Правовласників за період 
RETURNS @RT TABLE
(
id integer identity  primary key,
dateWork date,
nd varchar(25), 
ndDate date,
accDebet varchar(25),
accCredit varchar(25),
amount money, 
payNote varchar(300),
regId integer, 
fileName varchar(200), 
rowNum integer
)
as
BEGIN

--Первый день месяца
set  @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())

--declare @dateBegin date, @dateEnd date 
--set @dateBegin = '2018-01-01'
--set @dateEnd  = '2018-12-31'

--Надіслано клієнтами
insert into @Rt
(t1.dateWork, nd, ndDate, accDebet, accCredit, amount, payNote, regId, fileName, rowNum)
select t1.dateWork, t1.nd, t1.ndDate, t1.accDebet, t1.accCredit, t1.Amount, t5.name +' '+isnull(t1.payNote,''), t1.regId, t4.fileName, 
ROW_NUMBER() OVER( ORDER BY dateWork, t1.turnId) 
from payTurn t1 
join PayTurnExtra t11 on t1.turnId = t11.turnid
join account t2 on t1.accIdDebet = t2.accId
join account t3 on t1.accIdCredit = t3.accId
left join register t4 on t1.regId = t4.regId
join PayTurnType t5 on t5.balsDbt = t2.balsCode and t5.balsCrdt = t3.balsCode
where --(t2.custId = @custId or t3.custId = @custId)
t11.custid = @custId
and t1.dateWork between @dateBegin and @dateEnd

RETURN
END

--select * from ft_Tsk_5_31_GetGiveDetail (134, '2018-01-01', '2028-12-31') order by rowNum