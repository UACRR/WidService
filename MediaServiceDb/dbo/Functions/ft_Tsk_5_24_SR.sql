CREATE function  [dbo].[ft_Tsk_5_24_SR]  (@dateBegin date = NULL, @dateEnd date = NULL)
--Реєстр переданого до розподілу роялті по "великим правам"
RETURNS @RT TABLE
(
id integer identity primary key, 
periodId integer , 
periodName varchar(25),
month_name varchar(20),
periodYear char(4),  
clName varchar(100), 
INNOKPO varchar(15), 
dogNumber varchar(20), 
numberInvoice varchar(50), 
dateInvoice varchar(10), 
amount money, 
n_reglist varchar(100),
agrLicId integer
)

as
BEGIN
--Первый день месяца
set @dateBegin = isnull(@dateBegin, (select convert(date, (convert(char(4),year(getdate()))+'-01-'+ substring(convert(char(3),100+MONTH(getdate())),2,2) ))))
set @dateEnd = isnull(@dateEnd, getdate())

--declare @dateBegin date, @dateEnd date
--set @dateBegin = '2018-01-01'
--set @dateEnd = '2018-12-31' 

;with TabRgPeriod as 
(
select t11.custId, t11.periodId, 
n_reglist = STUFF (
  (select ','+ isnull(isnull(t3.number,filename),convert(varchar(10),regId))
    from PaidPeriod t1 
          join RegisterRatedList t2 on t1.periodId = t2.periodId 
          join register t3 on t2.rmId = t3.rmId 
		  where t1.periodId = t11.periodId and @dateBegin <= t1.beginDate and t1.endDate <= @dateEnd 
		  FOR XML PATH ('')),1,1,'')
from PaidPeriod t11 
join RegisterRatedList t22 on t11.periodId = t22.periodId 
join register t33 on t22.rmId = t33.rmId
where @dateBegin <= t11.beginDate and t11.endDate <= @dateEnd 
group by t11.custId, t11.periodId
)
insert into @RT 
(periodId, periodName,month_name , periodYear, clName, INNOKPO, dogNumber, numberInvoice, dateInvoice, amount, n_reglist, agrLicId)
select distinct t2.periodId, t2.periodName, 
dbo.Month_name(MONTH(t2.endDate)),
convert(char(4), year(t2.endDate)) as periodYear, t3.name as clName, t3.INNOKPO, 
t4.licNum, t6.numberInvoice, convert(char(10),t6.dateInvoice) as dateInvoice, t1.amount, t7.n_reglist, t4.licId
from MoneyPeriodLink t1 
join PaidPeriod t2 on t1.periodId = t2.periodId
join vCustomer t3 on t2.custId = t3.custId
join vLicenseAgreement t4 on t1.licId = t4.licId and t4.usesType = 2  --малі права
join MoneyReceived t6 on t1.paidId = t6.paidId
left join TabRgPeriod t7 on t2.periodId = t7.periodId

RETURN
END
--select * from ft_Tsk_5_24_SR  ('2018-01-01', '2018-12-31')