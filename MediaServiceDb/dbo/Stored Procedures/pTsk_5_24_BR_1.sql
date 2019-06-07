
CREATE procedure   [dbo].[pTsk_5_24_BR_1] ( @dateBegin date = NULL, @dateEnd date = NULL)
--Реєстр переданого до розподілу роялті по "великим правам"
as
BEGIN
declare  @RT table
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
n_reglist varchar(80),
agrLicId integer
)

--Первый день месяца
set @dateBegin = isnull(@dateBegin, (select convert(date, (convert(char(4),year(getdate()))+'-01-'+ substring(convert(char(3),100+MONTH(getdate())),2,2) ))))
set @dateEnd = isnull(@dateEnd, getdate())

--declare @dateBegin date, @dateEnd date
--set @dateBegin = '2018-01-01'
--set @dateEnd = '2018-12-31' 


select distinct t2.periodId, t2.periodName, 
case (MONTH(t2.endDate))
					when 12 then 'Грудень' 
					when 1 then 'Січень' 
					when 2 then 'Лютий' 
					when 3 then 'Березень' 
					when 4 then 'Квітень' 
					when 5 then 'Травень' 
					when 6 then 'Червень' 
					when 7 then 'Липень' 
					when 8 then 'Серпень' 
					when 9 then 'Вересень' 
					when 10 then 'Жовтень' 
					when 11 then 'Листопад' 
end  month_name,
convert(char(4), year(t2.endDate)) as periodYear, t3.name as clName, t3.INNOKPO, 
t15.agrNumber, t6.numberInvoice, convert(char(10),t6.dateInvoice) as dateInvoice, t1.amount, t7.Reg, t16.agrId
from MoneyPeriodLink t1 ,PaidPeriod t2, vCustomer t3,LicenseAgreement t14, AgreementMaster t16,AgreementAddBR t15,MoneyReceived t6,
(
select t11.custId, t11.periodId, 
 Reg = STUFF (
  (select ';№'+ isnull(isnull(t3.number,filename),convert(varchar(10),regId))
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
) t7
 where
 t1.periodId = t2.periodId
and t2.custId = t3.custId
and t1.licId = t14.licId
and t14.agrId = t16.agrId
and t15.agrId = t16.agrId 
and t16.version = t15.version
and t1.paidId = t6.paidId
and t2.periodId = t7.periodId



RETURN
END
--exec pTsk_5_24_BR_1  '20180101', '20181231'