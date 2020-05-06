/****** Object:  UserDefinedFunction [dbo].[ft_Tsk_5_31_GetGive]    Script Date: 19.07.2019 19:06:00 ******/
CREATE function  [dbo].[ft_Tsk_5_31_GetGive]  (@dateBegin date = NULL, @dateEnd date = NULL)
-- Відомість коштів Користувачів, що отримані та розподілені на Правовласників за період 
-- Общая ведомость для Больших и малых прав
-- 2019-07-19 - дораспределения с минусом, чтобы все соответствовало балансу
RETURNS @RT TABLE
(
id integer identity  primary key,
clCustId integer,
clName varchar(200), 
amountCl money,
amountComm money,
amountObj money, 
amountRh money, 
amountNull money,
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

;with TabPay as
(select cast(left(t1.accdebet,2) as integer) as balsDebet, 
       cast (left(t1.acccredit,2) as integer) as balsCredit,
	   sum(t1.amount) as amount, 
	   isnull(t2.custId,-1) as custid
  from payTurn t1 
   join PayTurnExtra t2 on t1.turnId = t2.turnid
     where t1.dateWork between @dateBegin and @dateEnd
	 --where t1.dateWork between '2019-07-19' and '2020-01-31'
     --and t2.custid = 217
  group by cast(left(t1.accdebet,2) as integer), cast (left(t1.acccredit,2) as integer), t2.custid
  )
, TabRT as (
select sum((Case t2.codeI When 5 Then t1.amount else 0 end )) as amountCl, 
        sum((Case t2.codeI When 8 Then t1.amount else 0 end )) as amountComm, 
		sum((Case t2.codeI When 6 Then t1.amount else 0 end )) as amountObj, 
	    sum((Case  When t2.codeI in (3,4) Then t1.amount else 0 end )) as amountRh, --2019-07-19 добавила 4, чтобы шло с балансом
	    --sum((Case t2.codeI When 7 Then t1.amount else 0 end )) as amountNull, ----2019-07-19 не с балансом
		sum((Case t2.codeI When 7 Then t1.amount else case t2.codeI When 4 Then -t1.amount Else 0 end  end )) as amountNull, ----2019-07-19 с балансом
		t1.custid
  from TabPay t1 
    join PayTurnType t2 on t2.balsDbt = t1.balsDebet and t2.balsCrdt = t1.balsCredit 
  where t2.codeI in (6, 5, 3, 4, 8, 7)
  group by t1.custid
 )
insert into @RT ( clCustId, clName, amountCl, amountComm, amountObj, amountRh, amountNull, rowNum )
select  
 t1.custid, isnull(t4.name, '_Дорозподіл ') as clName, t1.amountCl, t1.amountComm, t1.amountObj, t1.amountRh, t1.amountNull, 
 ROW_NUMBER() OVER( ORDER BY t4.name ) 
from TabRT t1 
left join vcustomer t4 on t4.custId = t1.custId
order by 2

RETURN
END

--select * from ft_Tsk_5_31_GetGive ('2019-07-19', '2020-01-31')

GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_31_GetGive] TO [ReportUser]
    AS [dbo];

