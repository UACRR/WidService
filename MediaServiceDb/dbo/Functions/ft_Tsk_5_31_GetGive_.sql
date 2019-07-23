--drop function ft_Tsk_5_GetGive
CREATE function  [dbo].[ft_Tsk_5_31_GetGive_]  (@dateBegin date = NULL, @dateEnd date = NULL)
-- Відомість коштів Користувачів, що отримані та розподілені на Правовласників за період 
-- Общая ведомость для Больших и малых прав
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

--drop table #Tmp3022
--create table #Tmp3022
declare @Tmp3022 table
(id integer not null identity, 
accIddebet integer, 
accIdCredit integer, 
amountObj money, 
amountComm money, 
regId integer, 
regIItemId integer, 
custId integer, 
primary key (accIdDebet, accIdCredit, id))

--drop table #Tmp213 
--create table #Tmp213 
declare @Tmp213 table 
(clCustId integer not null, 
 amountRh money not null, 
 amountNull money not null, 
 primary key (clCustId) )

--delete #Tmp3022
--insert into @Tmp3022 
insert into @Tmp3022 
(accIdDebet, accIdCredit, amountObj, amountComm, regId, regIItemId, custId)
select  t1.accIdDebet, t1.accIdCredit, --t1.accdebet, t1.acccredit,
        (Case left(accDebet,2) when '30' Then t1.amount Else 0 end) as amountObj, 
              (Case left(accDebet,2) when '30' Then 0 Else t1.amount end) as amountComm, 
              t1.regId, t1.regIItemId, t2.custId
   from PayTurn t1 
     join Account t2 on t2.accid = t1.accIdCredit --клиенти
  where t1.dateWork between @dateBegin and @dateEnd  and --'2019-01-31' and '2019-01-31' and 
         t1.accCredit like '22%'

--delete #Tmp213
;with TabTT as 
(select distinct t1.custId as clCustId, 
    (Case isnull(t2.custId,0) When 0 Then 0 Else t1.amountObj End) as amountRh, 
       (Case isnull(t2.custId,0) When 0 Then t1.amountObj Else 0 End) as amountNull
  from @Tmp3022 t1 
    left join PayTurn t3 on t3.dateWork between @dateBegin and @dateEnd and --'2019-01-31' and '2019-01-31' and 
                t1.accIdDebet = t3.accIdCredit and t1.regId = t3.regId and t1.regIItemId = t3.regIItemId 
   left join Account t2 on t2.accid = t3.accIdDebet --правообладатели
 )
insert into @Tmp213 (clCustId, amountRh, amountNull)
select  clCustId, sum(amountRh), sum(amountNull)
  from TabTT 
  group by clCustId
   
--Надіслано клієнтами
;with TabCln as 
(select t2.custId, sum(t1.amount) as amountCl
from PayTurn t1 
join Account t2 on t1.accIdDebet = t2.accId and t2.balsCode = 22
where t1.dateWork between @dateBegin and @dateEnd and 
   t1.accCredit like '10%'
group by t2.custId )
, 
--Зараховано на об'єкти права
TabObj as 
(
select t1.custId as clCust, sum(amountObj) as amountObj, sum(amountComm) as amountComm
from @Tmp3022 t1 
 group by t1.custId
), 
--Розподіл на правовласників
TabRh as
(
select 
 amountRh, 
 amountNull, 
 clCustId
from @Tmp213 
), 
TabR as 
(select  
isnull(t1.custId, t2.clCust) as clCustId,  
isnull(t1.amountCl,0) as amountCl, 
t2.amountComm as amountComm,
t2.amountObj as amountObj, 
t3.amountRh as amountRh, 
t3.amountNull as amountNull 
from TabCln t1 
full outer join TabObj t2 on t1.custId = t2.clCust
full outer join TabRh t3 on t3.clCustId = t2.clCust
)
insert into @RT ( clCustId, clName, amountCl, amountComm, amountObj, amountRh, amountNull, rowNum )
select  
 t1.clCustId, max(t4.name) as clName, sum(isnull(t1.amountCl,0)), sum(isnull(t1.amountComm,0)), sum(isnull(t1.amountObj,0)), sum(isnull(t1.amountRh,0)), sum(isnull(t1.amountNull,0)), 
 ROW_NUMBER() OVER( ORDER BY max(t4.name) ) 
from TabR t1 
join vcustomer t4 on t4.custId = t1.clCustId
group by t1.clCustId
order by 2

RETURN
END

/*
select * from ft_Tsk_5_31_GetGive_ ('2019-01-31', '2019-01-31') order by rowNum
select * from PayTurn where datework = '2019-01-31' and acccredit like '%134'
--select sum(amount) from PayTurn where datework = '2019-01-31' and acccredit like '%134'
*/
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_31_GetGive_] TO [ReportUser]
    AS [dbo];

