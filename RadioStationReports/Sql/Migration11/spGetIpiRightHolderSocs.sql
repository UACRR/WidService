use SocCisNet
go

create or alter procedure spGetIpiRightHolderSocs (
	  @ipBaseNr			varchar(13)
	, @socPer			int out
	, @beginDatePer		date out
	, @endDatePer		date out
	, @socMec			int out
	, @beginDateMec		date out
	, @endDateMec		date out
)
as
begin

/*
	Вибір товариств для правовласника для договорів які включають Україну
*/

-- ///////////////////////////////////////////// ДОГОВОРИ ПРАВОВЛАСНИКА

-- Активні партнерські товариства
drop table if exists #ActiveSocs
select 
	  t1.InterCode
	, case 
		when getdate() between dateBeginPER and dateEndPER -- є перетин інтервалів для публічки
		then 1 
		else 0 
	  end isPer
	, case
		when getdate() between dateBeginMEC and dateEndMEC -- є перетин інтервалів для механіки
		then 1 
		else 0 
	  end isMec
into #ActiveSocs
from MediaService..Community t1
	join MediaService..AgreementAddCommunity t2 on t1.custId = t2.custId
where  -- лише коли є перетин інтервалів для публічки та/або механіки
	   getdate() between dateBeginPER and dateEndPER
	or getdate() between dateBeginMEC and dateEndMEC

-- Попереднє заповнення таблиці договорів
-- Обираєму договори 
-- (а) з товариствами, для яких є активні договори, 
-- (б) які стосуються музичних творів та механіки і поблічки,
-- (в) мають ролі, що відповідають ролям в WID
-- (г) інтервал дії договору IPI перетинається з періодом звіту (таких може віявитись декілька, буде враховано далі)
drop table if exists #AuthorAgreements1
select 
	  t2.Id AgreeId -- полегшує задачу видалення дуплікатів, унікальне значення
	, t2.IpAgreeNr -- для повязування територій, може дублюватись внаслідок перетину дат і певних неузгоджень
	, t2.IpBaseNr
	, t2.SocCde
	, t2.RolCde
	, t2.RgtCde
	, t2.FromDt
	, t2.ToDt
	, t2.Shr
	, 1 SocPriority -- технічне поле
into #AuthorAgreements1
from SocIpi..IpiAgreement t2
	join #ActiveSocs t3 on cast(t2.SocCde as int) = cast(t3.InterCode as int) -- тільки для товариств з активними договорами
where t2.CreClsCde = 'MW' -- тільки музичні товри
	and t2.RgtCde in ('MR', 'PR') -- тільки механіка і публічка
	and getdate() between t2.FromDt and t2.ToDt  -- тільки активні на періоді звіту
	and IpBaseNr = @ipBaseNr

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
where t2.Tisan in ('WORLD', 'EASTERN EUROPE', 'EUROPE', 'EUROPEAN CONT.', 'UKRAINE')
--order by IpBaseNr, t2.IpAgreeNr

-- Перелік договорів з індикаторами використання територій
drop table if exists #AgreementTerrIndicators
create table #AgreementTerrIndicators  (
	  IpAgreeNr varchar(41)
	
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

-- Лишається дреба досягти того, щоб для кожної пари IpBaseNr-RgtCde лишився єдиний договір
-- Перш за все залишимо договори, які мають дублікати, де різняться лише ОКУ

drop table if exists #AuthorAgreements3

; with UniqueExceptSoc as (
	select 
		  IpBaseNr
		, SocCde
		, RgtCde
		, max(AgreeId) AgreeId
	from #AuthorAgreements2
	group by 
		IpBaseNr
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
		, RgtCde
		, max(SocPriority) SocPriority
	from #AuthorAgreements3
	group by 
		  IpBaseNr
		, RgtCde
)
select t1.*
into #AuthorAgreements4
from #AuthorAgreements3 t1
	join MaxPriority t2 on t1.IpBaseNr = t2.IpBaseNr
		and t1.RgtCde = t2.RgtCde
where t1.SocPriority = t2.SocPriority

-- Тут ще лишається дублювання, тому серед договорів, що лишились, вибираємо перший ліпший
drop table if exists #AuthorAgreements
; with MaxPriority as (
	select 
		  IpBaseNr
		, RgtCde
		, max(AgreeId) AgreeId
	from #AuthorAgreements3
	group by 
		  IpBaseNr
		, RgtCde
)
select t1.*
into #AuthorAgreements
from #AuthorAgreements4 t1
	join MaxPriority t2 on t1.IpBaseNr = t2.IpBaseNr
		and t1.RgtCde = t2.RgtCde
where t1.AgreeId = t2.AgreeId

drop table #AuthorAgreements3
drop table #AuthorAgreements4


--!!! Пошук договорів завершено - select * from #AuthorAgreements

-- Повертаємо результат
drop table if exists #AuthorAgreementsFinal
; with Res as (
	select
		  row_number() over(partition by IpBaseNr, RgtCde order by AgreeId) as SeqNr
		, * 
	from #AuthorAgreements
)
select *
into #AuthorAgreementsFinal
from Res 
where SeqNr = 1

drop table if exists #AuthorAgreements

select
	  @socPer		= SocCde
	, @beginDatePer	= FromDt
	, @endDatePer	= ToDt
from #AuthorAgreementsFinal
where RgtCde = 'PR'

select
	  @socMec		= SocCde
	, @beginDateMec	= FromDt
	, @endDateMec	= ToDt
from #AuthorAgreementsFinal
where RgtCde = 'MR'

drop table if exists #AuthorAgreementsFinal

end
GO


