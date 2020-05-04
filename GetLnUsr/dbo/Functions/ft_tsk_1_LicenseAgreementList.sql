CREATE function  [dbo].[ft_tsk_1_LicenseAgreementList] ( @strSeek varchar(254) = NULL) 
RETURNS @RT table 
--07-06-2019 Добавлены статусы из отчетов
--24-06-2019 Borg + ... = 0
--09-10-2019 - добавлена схема 3
--29-10-19 добавила usesType = 4 для он-лайн
(
	custId int NULL,
	INNOKPO varchar(254) NULL,
	name varchar(768) NULL,
	countActive int NULL,
	countNoAccept int NULL,
	undistribAmount money NULL,
	statusActive tinyint NULL,
	statusNoAccept tinyint NULL, --не акцептованные
	statusForAccept tinyint  NULL, --на акцепте с портала
	statusProlong tinyint NULL,  --для пролонгации
	statusUndistribute tinyint NULL, --не распределенные
	partnerName varchar(768) NULL,
	clientBrand varchar(100) null, 
	rgStatusOk tinyint null,   --погоджено звіт  rgstatus = 2
	rgStatusRefuse tinyint null, --відхилено звіт  rgstatus = 5
	statusBorg tinyint null, --борг хоч 1 період в стані борг
	amountBorg money not null, --сума боргу
	statusNoReport tinyint null, --Не отримані звіти» (перелік Споживачів, які мають хоча б один період в стані «Прийом звітів») 
	statusNoMoney tinyint null,    --«Не отримані кошти» (перелік Споживачів, які мають хоча б один період в стані «Прийом коштів») 
	unattachAmount money null,    --Не закріплені кошти
	statusUnattach tinyint null
)as 


BEGIN

IF isnull(@strSeek, '') = ''  


BEGIN
;with mV as 
(
select t1.licid, t1.licVersion, t1.licStatus from 
LicenseAgrParam t1, 
(select licId, max(licVersion) as version
 from LicenseAgrParam 
 where licStatus <> 4
 group by licId ) t2  
 where t1.licId = t2.licId and t1.licVersion = t2.version
),
pP as 
(
select licId, sum(amount) as amount, sum(distribAmount) as distribAmount, sum(undistribAmount) as undistribAmount
 from PaidPeriod
  where status <> 6 and 
  (isnull(amount,0) > isnull(distribAmount,0)+isnull(undistribAmount,0) or isnull(undistribAmount,0) <> 0)
  group by licId 
), 
--погоджені та відмовлені звіти
TabRegStat as 
(select t1.licId, max((Case When t3.rgStatus = 2 and t1.status=1 Then 1 Else 0 end)) as rgStatus2, max((Case When t3.rgStatus = 5 Then 1 Else 0 end)) as rgStatus5
   from PaidPeriod t1 
    join RegisterRatedList t2 on t2.periodId = t1.periodId
    join Register t3 on t3.rmId = t2.rmId and t3.rgStatus in (2, 5) 
  where t1.status <>7 
  group by t1.licId
 )
insert into @RT
select 
t1.custId, 
max(t4.INNOKPO) as INNOKPO, 
max(t4.name) as name, 
sum (Case when t1.licStatus = 2 Then 1 Else 0 end) as countActive,      --к-ть діючих угод
sum (Case when (t5.licStatus in (0,1) or t1.licStatus in (0,1)) Then 1 Else 0 end) as countNoAccept,    --к-ть не акцептованих
sum(isnull(t6.undistribAmount,0)) as undistribAmount, 
max((Case when t1.licStatus = 2 Then 1 Else 0 end)) as statusActive,
max((Case when t5.licStatus in (1) Then 1 Else 0 end)) as statusForAccept,  --на акцепте с портала
max((Case when t5.licStatus in (0) Then 1 Else 0 end)) as statusNoAccept,  --не подтвержденные операторские 
max((Case when isnull(t3.dateEnd,'3000-01-01')<=dateadd(day, 60,getdate()) Then 1 Else 0 end)) as statusProlong,
--max((Case when isnull(t6.amount,0) > isnull(t6.distribAmount,0)+isnull(t6.undistribAmount,0) Then 1 Else 0 end)) as statusUndistribute, 
max((Case when isnull(t6.undistribAmount,0) <> 0 Then 1 Else 0 end)) as statusUndistribute, 
max(t8.name) as partnerName,
max(t9.clientBrand) as clientBrand,

max(t10.rgStatus2) as rgStatusOk,  --Погоджені звіти
max(t10.rgStatus5) as rgStatusRefuse,  --Відхилені звіти
0 as statusBorg, 
0 as amountBorg, 
0 as statusNoReport, 
0 as statusNoMoney, 
0 as unattachAmount, 
0 as statusUnattach
from LicenseAgreement t1 
join vAgrLicenseType t2 on t1.licCode = t2.licCode and t2.usesType in (2,3,4)  --29-10-19 добавила 4 для он-лайн
join LicenseAgrParam t3 on t1.licId = t3.licId and t1.licVersion = t3.licVersion and isnull(t3.licStatus,0) not in (9,10) --!26-02-2019
join vCustomer t4 on t1.custId = t4.custId
join mV t5 on t5.licId = t1.licId 
left join pP t6 on t6.licId = t1.licId
left join partnerClient t7 on t7.clCustId  = t1.custId 
left join vcustomer t8 on t8.custId = t7.CustId
left join Client t9 on t1.custid=t9.custid
left join TabRegStat t10 on t10.licId = t1.licId
group by t1.custId

END

Else

Begin

  declare @test varchar(100) = 'test qwerty asdf'
  declare @split table ( value varchar(100) );
  declare @index int;

  set @test = rtrim( ltrim( @strSeek ));

  set @index = charindex(' ', @test );
  while @index > 0 
    begin
        insert into @split values( substring( @test, 1, @index - 1 ) );
        set @test = ltrim(substring( @test, @index, len(@test)) );
        set @index = charindex(' ', @test );
    end

   if( len( @test ) > 0 )
   insert into @split values( @test );

with mV as 
(
select t1.licid, t1.licVersion, t1.licStatus from 
LicenseAgrParam t1, 
(select licId, max(licVersion) as version
 from LicenseAgrParam 
 where licStatus <> 4
 group by licId ) t2  
 where t1.licId = t2.licId and t1.licVersion = t2.version
),
pP as 
(
select licId, sum(amount) as amount, sum(distribAmount) as distribAmount, sum(undistribAmount) as undistribAmount
 from PaidPeriod
  where status <> 6 and 
  (isnull(amount,0) > isnull(distribAmount,0)+isnull(undistribAmount,0) or isnull(undistribAmount,0) <> 0)
  group by licId 
),
--погоджені та відмовлені звіти
TabRegStat as 
(select t1.licId, max((Case When t3.rgStatus = 2 and t1.status = 1 Then 1 Else 0 end)) as rgStatus2, max((Case When t3.rgStatus = 5 Then 1 Else 0 end)) as rgStatus5
   from PaidPeriod t1 
    join RegisterRatedList t2 on t2.periodId = t1.periodId
    join Register t3 on t3.rmId = t2.rmId and t3.rgStatus in (2, 5) 
  where t1.status <>7 
  group by t1.licId
 )
insert into @RT
select 
t1.custId, 
max(t4.INNOKPO) as INNOKPO, 
max(t4.name) as name, 
sum (Case when t1.licStatus = 2 Then 1 Else 0 end) as countActive,      --к-ть діючих угод
sum (Case when (t5.licStatus in (0,1) or t1.licStatus in (0,1)) Then 1 Else 0 end) as countNoAccept,    --к-ть не акцептованих
sum(isnull(t6.undistribAmount,0)) as undistribAmount, 
max((Case when t1.licStatus = 2 Then 1 Else 0 end)) as statusActive,
max((Case when t5.licStatus in (1) Then 1 Else 0 end)) as statusForAccept,
max((Case when t5.licStatus in (0) Then 1 Else 0 end)) as statusNoAccept,  --не подтвержденные операторские 
max((Case when isnull(t3.dateEnd,'3000-01-01')<=dateadd(day, 60,getdate()) Then 1 Else 0 end)) as statusProlong,
--max((Case when isnull(t6.amount,0) > isnull(t6.distribAmount,0)+isnull(t6.undistribAmount,0) Then 1 Else 0 end)) as statusUndistribute, 
max((Case when isnull(t6.undistribAmount,0) <> 0  Then 1 Else 0 end)) as statusUndistribute, 
max(t8.name) as partnerName,
max(t9.clientBrand) as clientBrand, 
max(t10.rgStatus2) as rgStatusOk,  --Погоджені звіти
max(t10.rgStatus5) as rgStatusRefuse, --Відхилені звіти
0 as statusBorg, 
0 as amountBorg, 
0 as statusNoReport, 
0 as statusNoMoney, 
0 as unattachAmount, 
0 as statusUnattach
from LicenseAgreement t1 
join vAgrLicenseType t2 on t1.licCode = t2.licCode and t2.usesType in (2,3,4)  --29-10-19 добавила 4 для он-лайн
join LicenseAgrParam t3 on t1.licId = t3.licId and t1.licVersion = t3.licVersion and isnull(t3.licStatus,0) not in (9,10) --!26-02-2019
join vCustomer t4 on t1.custId = t4.custId
join mV t5 on t5.licId = t1.licId 
left join pP t6 on t6.licId = t1.licId
left join partnerClient t7 on t7.clCustId  = t1.custId 
left join vcustomer t8 on t8.custId = t7.CustId
left join Client t9 on t1.custid=t9.custid
left join TabRegStat t10 on t10.licId = t1.licId
--2020-02-26 --для поиска в точках
join License t30 on t1.licId = t30.licId and t1.licVersion = t30.licVersion 
left join ClnBusinessPlace t40 on t30.placeId = t40.placeId
CROSS APPLY @split t33 
 WHERE 
    (t4.name like '%'+t33.value+'%' 
     or t4.INNOKPO like '%'+t33.value+'%' 
     or t8.name like '%'+t33.value+'%' 
     or t9.clientBrand like '%'+t33.value+'%' 
	 or t40.placeName like '%'+t33.value+'%'   --2020-02-26 --для поиска в точках
    )
group by t1.custId

End

--Проставляю признаки statusBorg, amountBorg, statusNoReport, statusNoMoney, unattachAmount
--«Борг» (перелік Споживачів, які мають хоча б один період в стані борг)
--«Не отримані звіти» (перелік Споживачів, які мають хоча б один період в стані «Прийом звітів») 
--«Не отримані кошти» (перелік Споживачів, які мають хоча б один період в стані «Прийом коштів») 
--«Не закріплені кошти» (перелік Споживачів, які кошти, що не вприв'язані до періоду та ліцензії) 
declare  @TabSC table
(custId integer not null, 
 status integer not null, 
 cnt integer, 
 amountBorg money, 
 primary key (custId, status )
 )
delete @TabSC
insert into @TabSC (custId, status, cnt, amountBorg) 
select t2.custId, status,  count(*) as cnt, sum(t2.amount - t2.undistribamount - t2.distribamount ) as amountBorg 
  from @RT t1 
  --from vtsk_1_LicenseAgreementList t1 
  join PaidPeriod t2 on t2.custId = t1.custId 
  where t2.status in (1,2,3) 
  group by t2.custId, t2.status

update @RT set statusBorg = 1, amountBorg = t2.amountBorg 
  from @RT t1 
   join @TabSC t2 on t2.custId = t1.custId and t2.status = 3 and t2.cnt <> 0

update @RT set statusNoReport = t2.status
  from @RT t1 
  join @TabSC t2 on t2.custId = t1.custId and t2.status = 1 and t2.cnt <> 0
 
update @RT set statusNoMoney = 1
  from @RT t1 
  join @TabSC t2 on t2.custId = t1.custId and t2.status = 2 and t2.cnt <> 0

--Незакріплені кошти Клієнтів
;with TabMoney as (
select t0.custId, sum( amount - isnull(destribAmount,0) ) as unattachAmount 
from 
  @RT t0 
  join MoneyReceived t2 on t2.custId = t0.custId
WHERE (amount - isnull(destribAmount,0)) > 0
group by t0.custId
having sum( amount - isnull(destribAmount,0) ) <> 0 
)
update @RT set 	unattachAmount = t2.unattachAmount, statusUnattach = 1 
 from @RT t1 
  join TabMoney t2 on t2.custId = t1.custId 

RETURN
END

--select * from ft_tsk_1_LicenseAgreementList ('Кафе') 
