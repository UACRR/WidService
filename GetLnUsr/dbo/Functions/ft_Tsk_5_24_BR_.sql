
CREATE function  [dbo].[ft_Tsk_5_24_BR_]  (@dateBegin date = NULL, @dateEnd date = NULL)
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
set  @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())

--declare @dateBegin date, @dateEnd date
--set @dateBegin = '2018-01-01'
--set @dateEnd = '2018-12-31' 

--Все реестры по БП
;with TabRgPeriod as 
(
select t11.custId, t11.periodId, 
 Reg = STUFF (
  (select '; '+ isnull(isnull(t3.number,filename),convert(varchar(10),regId))
    from PaidPeriod t1 
          join RegisterRatedList t2 on t1.periodId = t2.periodId 
          join register t3 on t2.rmId = t3.rmId 
		  where t1.periodId = t11.periodId and @dateBegin <= t1.beginDate and t1.endDate <= @dateEnd 
		  FOR XML PATH ('')),1,1,'') 
from PaidPeriod t11 
join vCustomerClient t44 on t44.custId = t11.custId and t44.isBR = 1
join RegisterRatedList t22 on t11.periodId = t22.periodId 
join register t33 on t22.rmId = t33.rmId
--where @dateBegin <= t11.beginDate and t11.endDate <= @dateEnd 
group by t11.custId, t11.periodId
)
insert into @RT 
(periodId, periodName,month_name, periodYear, clName, INNOKPO, dogNumber, numberInvoice, dateInvoice, amount, n_reglist, agrlicId)
select distinct t2.periodId, t2.periodName, 
dbo.Month_name(MONTH(t2.endDate)),
convert(char(4), year(t2.endDate)) as periodYear, t3.name as clName, t3.INNOKPO, 
t15.agrNumber, t6.numberInvoice, convert(char(10),t6.dateInvoice) as dateInvoice, t1.amount, t7.Reg, t16.agrId
from MoneyPeriodLink t1  
join PaidPeriod t2 on t1.periodId = t2.periodId
join vCustomer t3 on t2.custId = t3.custId
join LicenseAgreement t14 on t1.licId = t14.licId
join AgreementMaster t16 on t14.agrId = t16.agrId
join AgreementAddBR t15 on t15.agrId = t16.agrId and t16.version = t15.version
join MoneyReceived t6 on t1.paidId = t6.paidId and t6.dateInvoice between @dateBegin and @dateEnd
left join TabRgPeriod t7 on t2.periodId = t7.periodId

RETURN
END
--select  id,month_name,periodYear,clName,INNOKPO,dogNumber,numberInvoice,dateInvoice,amount,n_reglist  from ft_Tsk_5_24_BR    ('2018-01-01', '2019-11-30')



GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_24_BR_] TO [ReportUser]
    AS [dbo];

