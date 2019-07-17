CREATE function  [dbo].[ft_Tsk_5_24_SR__]  (@dateBegin date = NULL, @dateEnd date = NULL)
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
agrLicId integer, 
custId integer,
paidId integer
)
--Идти по платежам за период и показать распределение по периодам
as
BEGIN
--Первый день месяца
set  @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())

--Платежи 
insert into @RT (periodId, periodName, month_name, periodYear, 
                 clName, INNOKPO, numberInvoice, dateInvoice, amount, agrLicId, custId, paidId)
select  t3.periodId, t3.periodName, dbo.Month_name(MONTH(t3.endDate)), convert(char(4), year(t3.endDate)) as periodYear, 
        t4.name as custName, t4.innokpo, t1.numberInvoice, t1.dateInvoice, isnull(t2.amount,t1.amount), t3.licId, t1.custId, t1.paidId
from MoneyReceived t1 
 left join MoneyPeriodLink t2 on t2.paidId = t1.paidId 
 left join paidPeriod t3 on t3.periodId = t2.periodId
 join vCustomer t4 on t1.custId = t4.custId
where t1.dateInvoice  between @dateBegin and @dateEnd

update @RT set dogNumber = t2.licNum
  from @RT t0  
    join LicenseAgreement t1 on t1.licId = t0.agrLicId
    join LicenseAgrParam t2 on t2.licId = t1.licId and t2.licVersion = t1.licVersion

;with TabRgPeriod as 
(
select t11.custId, t11.periodId, '№'+max(cast( t22.rmId as varchar(10))) as rmNum,
n_reglist = STUFF (
  (select distinct ','+ isnull(isnull(cast(t3.number as varchar(100)),filename),convert(varchar(100),regId))
    from @RT t1 
          join RegisterRatedList t2 on t1.periodId = t2.periodId 
          join register t3 on t2.rmId = t3.rmId 
		  where t1.periodId = t11.periodId 
		  FOR XML PATH ('')),1,1,'')
from @RT t11 
join RegisterRatedList t22 on t11.periodId = t22.periodId 
join register t33 on t22.rmId = t33.rmId
group by t11.custId, t11.periodId
)
update @RT set n_reglist = rmNum+' '+t2.n_reglist
from @RT t1 
join TabRgPeriod t2 on t1.periodId = t2.periodId 

RETURN
END
--select * from ft_Tsk_5_24_SR__  ('2018-01-01', '2019-02-19') order by custid, dateinvoice, periodId
--select * from MoneyPeriodLink 
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_24_SR__] TO [ReportUser]
    AS [dbo];

