use MediaService
go

create or alter procedure spSysCorrectInterCodes
as
begin


-- ВИПРАВЛЕННЯ RepMSIPI

-- Прибираємо зайві пробіли
update RepMSIPI
set IP_BASE_NR = trim(IP_BASE_NR)

-- Прибираємо посилання на невірні IpBaseNr
delete t1
from RepMSIPI t1
	left join SocIpi..IpiBase t2 on t1.IP_BASE_NR = t2.IpBaseNr
where t2.IpBaseNr is null

-- Коригуємо протиречиві посилання на IpNameNr
; with WrongIpiName as (
	select t1.*
	from RepMSIPI t1
		left join SocIpi..IpiName t2 on t1.IPInr = t2.IpNameNr
	where t1.IP_BASE_NR  <> t2.IpBaseNr
)
update t3
set t3.IPInr = t2.IpNameNr
--select *
from WrongIpiName t1
	join SocIpi..IpiName t2 on t1.IP_BASE_NR = t2.IpBaseNr
		and t2.NameType = 'PA'
	join RepMSIPI t3 on t1.IP_BASE_NR = t3.IP_BASE_NR

-- ВИПРАВЛЕННЯ RightHolder для Базового Коду

-- Прибираємо зайві пробіли
update RightHolder
set InterCode = trim(InterCode)

-- Прибираємо нули
update RightHolder
set InterCode = ''
where InterCode is null

-- Прибираємо невірні значення за форматом
update RightHolder
set InterCode = ''
where InterCode <> ''
	and len(InterCode) <> 13

-- Прибираємо невірні посилання на базовий код
update t1
set InterCode = ''
from RightHolder t1
	left join SocIpi..IpiBase t2 on t1.interCode = t2.IpBaseNr
where t1.InterCode <> ''
	and t2.IpBaseNr is null

-- ВИПРАВЛЕННЯ RightHolder для Коду Назви

-- Прибираємо невірні посилання на код назви
update t1
set IPIBase = null
-- select *
from RightHolder t1
	left join SocIpi..IpiName t2 on t1.IPIBase = t2.IpNameNr
where t1.IPIBase is not null
	and t2.IpNameNr is null

-- Додаємо посилання на код назви
update t1
set t1.IPIBase = t2.IpNameNr
--select *
from RightHolder t1
	join SocIpi..IpiName t2 on t1.InterCode = t2.IpBaseNr
		and t2.Nametype = 'PA'
where t1.IPIBase is null

-- Коригуємо протиречиві посилання на IpNameNr
; with WrongIpiName as (
	select t1.interCode, t2.IpBaseNr, t1.IPIBase, IpNameNr
	from RightHolder t1
		left join SocIpi..IpiName t2 on t1.IPIBase = t2.IpNameNr
	where t1.InterCode  <> t2.IpBaseNr
		and t1.interCode <> ''
)
update t3
set t3.IpiBase = t2.IpNameNr
--select *
from WrongIpiName t1
	join SocIpi..IpiName t2 on t1.interCode = t2.IpBaseNr
		and t2.NameType = 'PA'
	join RightHolder t3 on t1.interCode = t3.interCode

-- Поповнюємо базовий код за кодом назви
update t1
set t1.InterCode = t2.IpBaseNr
--select *
from RightHolder t1
	join SocIpi..IpiName t2 on t1.IpiBase = t2.IpNameNr
where t1.InterCode = '' 
	and t1.IpiBase is not null

-- >>>>>>>>>>> ЗБАГАЧУЄМО RepMSIPI
-- Додаємо відсутні
insert RepMSIPI
select t1.CustId, t1.InterCode, t1.IPIBase, getdate()
from RightHolder t1
	left join RepMSIPI t2 on t1.CustId = t2.CustId
where t1.InterCode <> ''
	and t2.CustId is null

-- Коди назви просутні і вірні, нічого не робимо !!!!!!

-- >>>>>>>>>>> ЗБАГАЧУЄМО RightHolder

update t2
set t2.interCode = t1.IP_BASE_NR, t2.IPIBase = t1.IPInr
-- select t1.CustId, t1.IP_BASE_NR, t1.IPInr, getdate()
from RepMSIPI t1
	join RightHolder t2 on t1.CustId = t2.CustId
where t2.interCode = ''

end
go

-- spSysCorrectInterCodes
