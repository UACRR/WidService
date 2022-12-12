use DDEX
go

drop procedure if exists spGetWidAuthorShares
go

create procedure spGetWidAuthorShares (
  @ddexReportId int
, @reportStartDate date
, @reportEndDate date
, @setCode int
)
as
begin
/*
declare @ddexReportId int = 217
declare @reportStartDate date = '2022-05-01';
declare @reportEndDate date = '2022-05-31';
declare @setCode int = 60
*/

-- /////////////////////////////////// ТАБЛИЦЯ, ЯКУ ТРЕБА ЗАПОВНИТИ
declare @WidAuthorShares tblTypeWidAuthorShares

/*
create table @WidAuthorShares (
	  Wic int
	, IpBaseNr varchar(13)
	, IpNameNr int
	, RoleInWid varchar(3) 
	, MecWidShr decimal(5, 2)
	, MecSoc int
	, MecSocShr decimal(5, 2)
	, PerWidShr decimal(5, 2)
	, PerSoc int
	, PerSocShr decimal(5, 2)
)
*/

-- /////////////////////////////////// ПЕРЕЛІК ТВОРІВ ЗВІТУ ДЛЯ ВКЛЮЧЕННЯ У ІНВОЙС

-- Початковий перелік творів
drop table if exists #ReportWics
select distinct t2.Wic
into #ReportWics
from Ddex..IdentBacklog t1
	join Ddex..IdentMW t2 on t1.mwId = t2.id
where t1.DdexReportId = @ddexReportId
	and isnull(t2.Wic, 0) <> 0

-- Видаляємо твори, у яких серед авторів є такі, що посілаються на гупове імя в IPI
; with DistinctAuthors as (
	select distinct t2.IpNameNr
	from #ReportWics t1 
		join SocWid..widIntrPty t2 on t1.Wic = t2.Wic
),
GroupAuthors as (
	select t2.IpNameNr
	from DistinctAuthors t1
		join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
	group by t2.IpNameNr
	having count(*) > 1
),
WicsToDelete as (
	select distinct t2.Wic
	from #ReportWics t1
		join SocWid..widIntrPty t2 on t1.Wic = t2.WIc
		join GroupAuthors t3 on t2.IpNameNr = t3.IpNameNr
)
delete t1
from #ReportWics t1
	join WicsToDelete t2 on t1.Wic = t2.Wic

-- select * from #ReportWics


--//////////////////////////////////////////////////// ПОЧАТКОВИЙ РОЗПОДІЛ ПРОЦЕНТІВ МІЖ АВТОРАМИ

-- Початкове заповнення
delete from @WidAuthorShares -- для зручності відладки
insert @WidAuthorShares (
	  Wic
	, IpBaseNr
	, IpNameNr
	, RoleInWid
	, MecWidShr
	, MecSoc
	, MecSocShr
	, PerWidShr
	, PerSoc
	, PerSocShr
)
select
	  Wic
	, IpBaseNr
	, IpNameNr
	, IpRole
	, MEC rateMEC
	, MecSoc
	, MecSocShr
	, PER ratePER
	, PerSoc
	, PerSocShr
--into @WidAuthorShares
from (
	select
		  t2.Wic
		, t1.IpBaseNr
		, t2.IpNameNr
		, t2.IpRole
		, t3.RightType
		, isnull(t3.Shares, 0) Shares
		, null MecSoc
		, null MecSocShr
		, null PerSoc
		, null PerSocShr
	from SocIpi..IpiName t1
	    join SocWid..widIntrPty t2 on t1.IpNameNr = t2.IpNameNr
		join SocWid..WidShares t3 on t2.Wic = t3.Wic and t2.RolId = t3.IntrPtyRolid
		join #ReportWics t4 on t2.Wic = t4.Wic
	where isnull(t3.Shares, 0) <> 0
		--and t2.IpRole in ('C',  'A',  'CA', 'E')
) as TableToPivot
pivot (
	sum(Shares)
	for RightType in (MEC, PER)  
) as result

-- Коррекція null, що можуть зявитись при транспонуванні
update @WidAuthorShares
set 
	  MecWidShr = isnull(MecWidShr, 0)
	, PerWidShr = isnull(PerWidShr, 0)

-- Обробляємо твори з сумою процентів механіки, що перевищує 100
; with Over100 as (
	select wic
	from @WidAuthorShares
	group by Wic
	having sum(MecWidShr) > 100
)
update t1
set t1.MecWidShr = 0
from @WidAuthorShares t1
	join Over100 t2 on t1.Wic = t2.Wic

-- Обробляємо твори з сумою процентів публічки, що перевищує 100
; with Over100 as (
	select wic
	from @WidAuthorShares
	group by Wic
	having sum(PerWidShr) > 100
)
update t1
set t1.PerWidShr = 0
from @WidAuthorShares t1
	join Over100 t2 on t1.Wic = t2.Wic

-- Видаляємо записи з нульовими процентами
delete @WidAuthorShares
where MecWidShr = 0
	and PerWidShr = 0

-- Видаляємо записи для незрозумілих ролей
delete @WidAuthorShares
where RoleInWid not in ('C',  'A',  'CA', 'E')

-- Щоб не мати проблем з подвоюванням рядків, суммуємо за ключем (Wic IpBaseNr IpNameNr RoleInWid)
drop table if exists #Sums
select 
	  Wic
	, IpBaseNr
	, IpNameNr
	, RoleInWid
	, sum(MecWidShr)  MecWidShr
	, sum(PerWidShr)  PerWidShr
into #Sums
from @WidAuthorShares
group by 
	  Wic
	, IpBaseNr
	, IpNameNr
	, RoleInWid

-- Повністю замінюємо рядки на відповідні рядки з сумами
delete @WidAuthorShares
insert @WidAuthorShares (
	  Wic
	, IpBaseNr
	, IpNameNr
	, RoleInWid
	, MecWidShr
	, MecSoc
	, MecSocShr
	, PerWidShr
	, PerSoc
	, PerSocShr
)
select
	  Wic
	, IpBaseNr
	, IpNameNr
	, RoleInWid
	, MecWidShr
	, null MecSoc
	, null MecSocShr
	, PerWidShr
	, null PerSoc
	, null PerSocShr
from #Sums

-- Видаляєму таблиці, які більше не потрібні
drop table #Sums
drop table #ReportWics	

------------------------------------------------ select * from @WidAuthorShares order by Wic

-- ///////////////////////////////////////////// ДОГОВОРИ АВТОРІВ

--!!!!! Спеціальні виключення для товариств в цій процедурі врахувуємо лише для преоритезації товариств
-- Активні договори товариства
drop table if exists #ActiveSocs
select 
	  InterCode
	, case 
		when @reportStartDate <= dateEndPER and @reportEndDate >= dateBeginPER -- є перетин інтервалів для публічки
		then 1 
		else 0 
	  end isPer
	, case
		when @reportStartDate <= dateEndMEC and @reportEndDate >= dateBeginMEC -- є перетин інтервалів для механіки
		then 1 
		else 0 
	  end isMec
into #ActiveSocs
from vMSCommunity
where  -- лише коли є перетин інтервалів для публічки та/або механіки
	   @reportStartDate <= dateEndPER and @reportEndDate >= dateBeginPER
	or @reportStartDate <= dateEndMEC and @reportEndDate >= dateBeginMEC

-- Попереднє заповнення таблиці договорів
-- Обираєму договори 
-- (а) з товариствами, для яких є активні договори, 
-- (б) які стосуються музичних творів та механіки і поблічки,
-- (в) мають ролі, що відповідають ролям в WID
-- (г) інтервал дії договору IPI перетинається з періодом звіту (таких може віявитись декілька, буде враховано далі)
drop table if exists #AuthorAgreements1
; with AuthorRoles as (
	select distinct 
		  IpBaseNr
		, RoleInWid
	from @WidAuthorShares
),
ExcSocs as (
	select cast(IPInr as int) SocCde
	from ExceptionMember
	where setCode = @setCode
		and excType = 1
)
select 
	  t2.Id AgreeId -- полегшує задачу видалення дуплікатів, унікальне значення
	, t2.IpAgreeNr -- для повязування територій, може дублюватись внаслідок перетину дат і певних неузгоджень
	, t1.IpBaseNr
	, t1.RoleInWid
	, t2.SocCde
	, t2.RolCde
	, t2.RgtCde
	, t2.FromDt
	, t2.ToDt
	, t2.Shr
	, case when t4.SocCde is null then 1 else 0 end SocPriority -- технічне поле
into #AuthorAgreements1
from AuthorRoles t1
	join SocIpi..IpiAgreement t2 on t1.IpBaseNr = t2.IpBaseNr
		and (
			   (t1.RoleInWid = 'C' and t2.RolCde = 'MC')
			or (t1.RoleInWid = 'A' and t2.RolCde = 'LY')
			or (t1.RoleInWid = 'E' and t2.RolCde = 'EM')
			or (t1.RoleInWid = 'CA' and t2.RolCde in ('MC', 'LY')) -- відповідність ролей
		)
	join #ActiveSocs t3 on cast(t2.SocCde as int) = cast(t3.InterCode as int) -- тільки для товариств з активними договорами
	left join ExcSocs t4 on t2.SocCde = t4.SocCde -- для приоритизації товариств
where t2.CreClsCde = 'MW' -- тільки музичні товри
	and t2.RgtCde in ('MR', 'PR') -- тільки механіка і публічка
	and @reportStartDate <= t2.ToDt and @reportEndDate >= t2.FromDt  -- тільки активні на періоді звіту

drop table #ActiveSocs
--------------------------------------------------- select * from #AuthorAgreements1

-- //////////////////////////////////// ДОГОВРИ, ЩО СТОСУЮТЬСЯ УКРАЇНИ
/* Ієрархія територій, до яких відноситься Україна
  UKRAINE (Ukr)
	CIS (Cis)
	EASTERN EUROPE (Eeu)
		EUROPE
		EUROPEAN CONT.  
			EUROPE
	EUROPE (Eur)
	EUROPEAN CONT. (Euc)
	WORLD (Wld)
*/

drop table if exists #AgreementTerritories

-- Попередній список територій, що стосуються України, з поміж територій вибраних договорів
select 
	  t2.IpAgreeNr
	, t2.tisan
	, t2.IncExcInd
into #AgreementTerritories
from #AuthorAgreements1 t1
	join SocIpi..IpiTerritory t2 on t1.IpAgreeNr = t2.IpAgreeNr
where t2.Tisan in ('WORLD', 'CIS', 'EASTERN EUROPE', 'EUROPE', 'EUROPEAN CONT.', 'UKRAINE')
--order by IpBaseNr, t2.IpAgreeNr

-- Перелік договорів з індикаторами використання територій
drop table if exists #AgreementTerrIndicators
create table #AgreementTerrIndicators  (
	  IpAgreeNr varchar(26)
	
	, WldI bit default(0)
	, CisI bit default(0)
	, EeuI bit default(0)
	, EurI bit default(0)
	, EucI bit default(0)
	, UkrI bit default(0)

	, WldE bit default(0)
	, CisE bit default(0)
	, EeuE bit default(0)
	, EurE bit default(0)
	, EucE bit default(0)
	, UkrE bit default(0)
)

insert #AgreementTerrIndicators (IpAgreeNr)
select distinct IpAgreeNr
from #AgreementTerritories

-- Сформувати індекатори приналежності до окремих територій
update t1 set t1.WldI = 1 from #AgreementTerrIndicators t1 join #AgreementTerritories t2 on t1.IpAgreeNr = t2.IpAgreeNr where t2.Tisan = 'WORLD'			and t2.IncExcInd = 'I'
update t1 set t1.CisI = 1 from #AgreementTerrIndicators t1 join #AgreementTerritories t2 on t1.IpAgreeNr = t2.IpAgreeNr where t2.Tisan = 'CIS'				and t2.IncExcInd = 'I'
update t1 set t1.EeuI = 1 from #AgreementTerrIndicators t1 join #AgreementTerritories t2 on t1.IpAgreeNr = t2.IpAgreeNr where t2.Tisan = 'EASTERN EUROPE'	and t2.IncExcInd = 'I'
update t1 set t1.EurI = 1 from #AgreementTerrIndicators t1 join #AgreementTerritories t2 on t1.IpAgreeNr = t2.IpAgreeNr where t2.Tisan = 'EUROPE'			and t2.IncExcInd = 'I'
update t1 set t1.EucI = 1 from #AgreementTerrIndicators t1 join #AgreementTerritories t2 on t1.IpAgreeNr = t2.IpAgreeNr where t2.Tisan = 'EUROPEAN CONT.'	and t2.IncExcInd = 'I'
update t1 set t1.UkrI = 1 from #AgreementTerrIndicators t1 join #AgreementTerritories t2 on t1.IpAgreeNr = t2.IpAgreeNr where t2.Tisan = 'UKRAINE'			and t2.IncExcInd = 'I'

update t1 set t1.WldE = 1 from #AgreementTerrIndicators t1 join #AgreementTerritories t2 on t1.IpAgreeNr = t2.IpAgreeNr where t2.Tisan = 'WORLD'			and t2.IncExcInd = 'E'
update t1 set t1.CisE = 1 from #AgreementTerrIndicators t1 join #AgreementTerritories t2 on t1.IpAgreeNr = t2.IpAgreeNr where t2.Tisan = 'CIS'				and t2.IncExcInd = 'E'
update t1 set t1.EeuE = 1 from #AgreementTerrIndicators t1 join #AgreementTerritories t2 on t1.IpAgreeNr = t2.IpAgreeNr where t2.Tisan = 'EASTERN EUROPE'	and t2.IncExcInd = 'E'
update t1 set t1.EurE = 1 from #AgreementTerrIndicators t1 join #AgreementTerritories t2 on t1.IpAgreeNr = t2.IpAgreeNr where t2.Tisan = 'EUROPE'			and t2.IncExcInd = 'E'
update t1 set t1.EucE = 1 from #AgreementTerrIndicators t1 join #AgreementTerritories t2 on t1.IpAgreeNr = t2.IpAgreeNr where t2.Tisan = 'EUROPEAN CONT.'	and t2.IncExcInd = 'E'
update t1 set t1.UkrE = 1 from #AgreementTerrIndicators t1 join #AgreementTerritories t2 on t1.IpAgreeNr = t2.IpAgreeNr where t2.Tisan = 'UKRAINE'			and t2.IncExcInd = 'E'

drop table #AgreementTerritories -- все потрібне вже містить #AgreementTerrIndicators

-- Формуємо договори, які стосуються України
drop table if exists #AuthorAgreements2
; with UkrAgreements as (
	select IpAgreeNr
	from #AgreementTerrIndicators
	where 
		   (UkrE <> 1 and UkrI = 1)
		or (UkrE <> 1 and EucE <> 1 and EucI = 1)
		or (UkrE <> 1 and EucE <> 1 and EeuE <> 1 and EeuI = 1)
		or (UkrE <> 1 and EucE <> 1 and EeuE <> 1 and EurE <> 1 and EurI = 1)
		or (UkrE <> 1 and CisE <> 1 and CisI = 1)
		or (UkrE <> 1 and EucE <> 1 and EeuE <> 1 and EurE <> 1 and CisE <> 1 and WldI = 1)
)
select t1.*
into #AuthorAgreements2
from #AuthorAgreements1 t1
	join UkrAgreements t2 on t1.IpAgreeNr = t2.IpAgreeNr

drop table #AgreementTerrIndicators
drop table #AuthorAgreements1

-------------------------------------------- select * from #AuthorAgreements2

-- Лишається дреба досягти того, щоб для кожної пари IpBaseNr-RoleInWid-RgtCde лишився єдиний договір
-- Перш за все залишимо договори, які мають дублікати, де різняться лише ОКУ

drop table if exists #AuthorAgreements3

; with UniqueExceptSoc as (
	select 
		  IpBaseNr
		, RoleInWid
		, SocCde
		, RgtCde
		, max(AgreeId) AgreeId
	from #AuthorAgreements2
	group by 
		IpBaseNr
	  , RoleInWid
	  , SocCde
	  , RgtCde
)
select t1.*
into #AuthorAgreements3
from #AuthorAgreements2 t1
where t1.AgreeId in (select AgreeId from UniqueExceptSoc)
--having count(*) > 1

drop table #AuthorAgreements2

-------------------------------------------- select * from #AuthorAgreements3 order by IpBaseNr

-- Вибір договору серед договорів для різних товариств
-- В цьому місці при виборі договорів треба надати перевагу товариствам, які не потрабили до виключень
-- При цьому треба лишити договори для товариств, що потрапили до виключень, бо за певних умов деяких авторів
-- можна бути включити до інвойсу навіть за договором з товариством, що потрапило до виключень

-- Треба мати на увазі, що один і той самий договір може застосовуватись для того самого правовласника двічі для різних ролей в WID (наприклад C і CA)

-- Вибираємо договори для найбільш приорітетних ОКУ
drop table if exists #AuthorAgreements4
; with MaxPriority as (
	select 
		  IpBaseNr
		, RoleInWid
		, RgtCde
		, max(SocPriority) SocPriority
	from #AuthorAgreements3
	group by 
		  IpBaseNr
		, RoleInWid
		, RgtCde
)
select t1.*
into #AuthorAgreements4
from #AuthorAgreements3 t1
	join MaxPriority t2 on t1.IpBaseNr = t2.IpBaseNr
		and t1.RoleInWid = t2.RoleInWid
		and t1.RgtCde = t2.RgtCde
where t1.SocPriority = t2.SocPriority

-- Тут ще лишається дублювання, тому серед договорів, що лишились, вибираємо перший ліпший
drop table if exists #AuthorAgreements
; with MaxPriority as (
	select 
		  IpBaseNr
		, RoleInWid
		, RgtCde
		, max(AgreeId) AgreeId
	from #AuthorAgreements3
	group by 
		  IpBaseNr
		, RoleInWid
		, RgtCde
)
select t1.*
into #AuthorAgreements
from #AuthorAgreements4 t1
	join MaxPriority t2 on t1.IpBaseNr = t2.IpBaseNr
		and t1.RoleInWid = t2.RoleInWid
		and t1.RgtCde = t2.RgtCde
where t1.AgreeId = t2.AgreeId

drop table #AuthorAgreements3
drop table #AuthorAgreements4


--!!! Пошук договорів завершено - select * from #AuthorAgreements

-- ////////////////////////////////////////////// СТВОРЮЄМО ПІДСУМКОВУ ІНФОРМАЦІЮ
update t1
set
	  t1.MecSoc = t2.SocCde
	, t1.MecSocShr = t2.Shr
from @WidAuthorShares t1
	join #AuthorAgreements t2 on t1.IpBaseNr = t2.IpBaseNr
							and t1.RoleInWid = t2.RoleInWid
where t2.RgtCde = 'MR'

update t1
set
	  t1.PerSoc = t2.SocCde
	, t1.PerSocShr = t2.Shr
from @WidAuthorShares t1
	join #AuthorAgreements t2 on t1.IpBaseNr = t2.IpBaseNr
							and t1.RoleInWid = t2.RoleInWid
where t2.RgtCde = 'PR'

delete 
from @WidAuthorShares
where MecSoc is null and PerSoc is null

select * 
from @WidAuthorShares
end
go


-- Procedure using
/*
declare @WidAuthorShares tblTypeWidAuthorShares

insert @WidAuthorShares
exec spGetWidAuthorShares 
  @ddexReportId = 217
, @reportStartDate = '2022-05-01'
, @reportEndDate = '2022-05-31'
, @setCode = 60

select 
	  Wic
	, sum(MecWidShr) MecWidShr
	, sum(PerWidShr) PerWidShr
from @WidAuthorShares
group by Wic

delete from @WidAuthorShares
*/
