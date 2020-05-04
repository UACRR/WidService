
CREATE procedure   [dbo].[pTsk_5_24_BR] ( @dateBegin date = NULL, @dateEnd date = NULL)
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
declare  @reglist table(
--custId			int,
periodId		int,
n_reglist		varchar(80)
)
--Первый день месяца
set  @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())

--declare @dateBegin date, @dateEnd date
--set @dateBegin = '2018-01-01'
--set @dateEnd = '2018-12-31' 


insert @reglist ( -- custId	,
periodId,  n_reglist)
select  --t11.custId, 
t11.periodId, 
  STUFF (
  (select '; '+ isnull(isnull(t3.number,filename),convert(varchar(10),regId))
    from PaidPeriod t1 
          join RegisterRatedList t2 on t1.periodId = t2.periodId 
          join register t3 on t2.rmId = t3.rmId 
		  where t1.periodId = t11.periodId and @dateBegin <= t1.beginDate and t1.endDate <= @dateEnd 
		  FOR XML PATH ('')),1,1,'') 
from PaidPeriod t11 
join RegisterRatedList t22 on t11.periodId = t22.periodId 
join register t33 on t22.rmId = t33.rmId
--where @dateBegin <= t11.beginDate and @dateEnd <= t11.endDate 
--отбираю не как для платежей по дате, а как для периода 
where @dateBegin >= t11.beginDate and @dateEnd <= t11.endDate 
group by t11.custId, t11.periodId

insert into @RT 
(periodId, periodName,month_name, periodYear, clName, INNOKPO, dogNumber, numberInvoice, dateInvoice, amount, agrlicId)
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
end ,
convert(char(4), year(t2.endDate)) as periodYear, t3.name as clName, t3.INNOKPO, 
t15.agrNumber, t6.numberInvoice, convert(char(10),t6.dateInvoice) as dateInvoice, t1.amount, t16.agrId
from MoneyPeriodLink t1 
join PaidPeriod t2 on t1.periodId = t2.periodId
join vCustomer t3 on t2.custId = t3.custId
join LicenseAgreement t14 on t1.licId = t14.licId
join AgreementMaster t16 on t14.agrId = t16.agrId
join AgreementAddBR t15 on t15.agrId = t16.agrId and t16.version = t15.version
join MoneyReceived t6 on t1.paidId = t6.paidId

update @RT
set n_reglist =t2.n_reglist
from @RT t1,@reglist t2
where
t1.periodId=t2.periodId

select  id,month_name,periodYear,clname,INNOKPO,dogNumber,numberinvoice,
dateinvoice,amount,n_reglist  from @RT


RETURN
END
--exec pTsk_5_24_BR null, null


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pTsk_5_24_BR] TO [ReportUser]
    AS [dbo];

