use MediaService
go

drop procedure if exists spWidIpBasNrSoc
go

create procedure spWidIpBasNrSoc
as
begin
-- Задача - поставити у відповідність Правовласнику (IpBaseNr) міжнародний код ОКУ

-- Створеємо таблицю з метою тестування, якщо вона не була створена зовні
if object_id('tempdb..#IpBaseNrList') is null
begin
	select top 10000
		IpBaseNr
	into #IpBaseNrList
	from SocIpi..IpiBase
end

-- Обмежуємо інформацію для аналізу
-- Одразу включаємо лише договори для музичних творів, механіки або публічки і ролей, що відповідає музичним творам,
-- а також які дійсні на поточну дату
drop table if exists #Agreements1
select 
	  t3.Id -- це буде слугувати ключем для записів таблиці
	, t2.IpBaseNr
	, t2.SocCde
	, t2.RgtCde
	, t2.FromDt -- Знадобиться для вибору останніх договорів
	, t3.TISAN
	, t3.IncExcInd
into #Agreements1
from #IpBaseNrList t1
	join SocIpi..IpiAgreement t2 on t1.IpBaseNr = t2.IpBaseNr
	join SocIpi..IpiTerritory t3 on t2.IpAgreeNr = t3.IpAgreeNr
where t2.CreClsCde = 'MW'
	and t2.RolCde in ('MC', 'LY', 'EM')
	and t2.RgtCde in ('MR', 'PR')
	and t2.FromDt <= getdate()
	and t2.ToDt >= getdate()

-- Одразу маємо дублювання внаслідок договорів для різних ролей
-- Позбавляємось їх
drop table if exists #Agreements2
;with Dist as (
	select 
	      max(Id) Id
		, IpBaseNr
		, SocCde
		, RgtCde
		, FromDt
		, TISAN
		, IncExcInd
	from #Agreements1
	group by
		  IpBaseNr
		, SocCde
		, RgtCde
		, FromDt
		, TISAN
		, IncExcInd
)
select *
into #Agreements2
from Dist

drop table #Agreements1

-- Тут можливе дублювання за інтервалом дії договорів. Вибираємо той, що зареєстрований останнім.
-- І позбавляємость колонки FromDt, яка надалі не потрібна
drop table if exists #Agreements3
;with Dist as (
	select 
	      max(Id) Id
		, IpBaseNr
		, SocCde
		, RgtCde
		, TISAN
		, IncExcInd
	from #Agreements2
	group by
		  IpBaseNr
		, SocCde
		, RgtCde
		, TISAN
		, IncExcInd
)
select *
into #Agreements3
from Dist
-- select * from #Agreements3 where IpBaseNr = 'I-000000109-0'

drop table #Agreements2

-- Що лишається - вибрати одне ОКУ для кожного з типів прав (механіка/публічка)
-- Тут найцікавіше. Приклад:
/*
Id	IpBaseNr	SocCde	RgtCde	TISAN	IncExcInd
11586	I-000000109-0	072	MR	CUBA                	E
11585	I-000000109-0	072	MR	WORLD               	I
11608	I-000000109-0	072	PR	CUBA                	E
11607	I-000000109-0	072	PR	WORLD               	I
11584	I-000000109-0	103	MR	CUBA                	I
11606	I-000000109-0	103	PR	CUBA                	I
*/
-- Якби ми були Кубою, треба було б вибрати ОКУ 103, інтуітивно ясно, чому.
-- Далі зробимо це алгоритмічно для Ураїни врахувуючи ієрархію територій
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
-- Перш за все дишаємо лише ті договорі, в територіях яких згадується те, що стовується України
drop table if exists #Agreements4
select *
into #Agreements4
from #Agreements3
where Tisan in ('WORLD', 'CIS', 'EASTERN EUROPE', 'EUROPE', 'EUROPEAN CONT.', 'UKRAINE')
-- select * from #Agreements4 where IpBaseNr = 'I-000000109-0'

drop table #Agreements3

-- Фіксуємо використання територій для трійці Правовласник-ОКУ-Тип права. Цей набыр зараз вже унікальний,
-- і для посилання на нього можна використовувати Id
drop table if exists #TerrUse
create table #TerrUse  (
	  Id int
	
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

insert #TerrUse (Id)
select Id
from #Agreements4

-- Формуємо індекатори присутності окремих територій
update t1 set t1.WldI = 1 from #TerrUse t1 join #Agreements4 t2 on t1.Id = t2.Id where t2.Tisan = 'WORLD'			and t2.IncExcInd = 'I'
update t1 set t1.CisI = 1 from #TerrUse t1 join #Agreements4 t2 on t1.Id = t2.Id where t2.Tisan = 'CIS'				and t2.IncExcInd = 'I'
update t1 set t1.EeuI = 1 from #TerrUse t1 join #Agreements4 t2 on t1.Id = t2.Id where t2.Tisan = 'EASTERN EUROPE'	and t2.IncExcInd = 'I'
update t1 set t1.EurI = 1 from #TerrUse t1 join #Agreements4 t2 on t1.Id = t2.Id where t2.Tisan = 'EUROPE'			and t2.IncExcInd = 'I'
update t1 set t1.EucI = 1 from #TerrUse t1 join #Agreements4 t2 on t1.Id = t2.Id where t2.Tisan = 'EUROPEAN CONT.'	and t2.IncExcInd = 'I'
update t1 set t1.UkrI = 1 from #TerrUse t1 join #Agreements4 t2 on t1.Id = t2.Id where t2.Tisan = 'UKRAINE'			and t2.IncExcInd = 'I'
							   
update t1 set t1.WldE = 1 from #TerrUse t1 join #Agreements4 t2 on t1.Id = t2.Id where t2.Tisan = 'WORLD'			and t2.IncExcInd = 'E'
update t1 set t1.CisE = 1 from #TerrUse t1 join #Agreements4 t2 on t1.Id = t2.Id where t2.Tisan = 'CIS'				and t2.IncExcInd = 'E'
update t1 set t1.EeuE = 1 from #TerrUse t1 join #Agreements4 t2 on t1.Id = t2.Id where t2.Tisan = 'EASTERN EUROPE'	and t2.IncExcInd = 'E'
update t1 set t1.EurE = 1 from #TerrUse t1 join #Agreements4 t2 on t1.Id = t2.Id where t2.Tisan = 'EUROPE'			and t2.IncExcInd = 'E'
update t1 set t1.EucE = 1 from #TerrUse t1 join #Agreements4 t2 on t1.Id = t2.Id where t2.Tisan = 'EUROPEAN CONT.'	and t2.IncExcInd = 'E'
update t1 set t1.UkrE = 1 from #TerrUse t1 join #Agreements4 t2 on t1.Id = t2.Id where t2.Tisan = 'UKRAINE'			and t2.IncExcInd = 'E'

-- select * from #TerrUse

-- Використовуємо отриману інформацію для подальшого звуження переліку договорів
drop table if exists #Agreements5
select 
	  t1.Id
	, t1.IpBaseNr
	, t1.SocCde
	, t1.RgtCde
	-- , t1.TISAN (не має значення тепер)
	--, t1.IncExcInd (не має значення тепер)
into #Agreements5
from #Agreements4 t1
	join #TerrUse t2 on
			t1.Id = t2.Id
		and (
		   (t2.UkrE <> 1 and t2.UkrI = 1)
		or (t2.UkrE <> 1 and t2.EucE <> 1 and t2.EucI = 1)
		or (t2.UkrE <> 1 and t2.EucE <> 1 and t2.EeuE <> 1 and t2.EeuI = 1)
		or (t2.UkrE <> 1 and t2.EucE <> 1 and t2.EeuE <> 1 and t2.EurE <> 1 and t2.EurI = 1)
		or (t2.UkrE <> 1 and t2.CisE <> 1 and t2.CisI = 1)
		or (t2.UkrE <> 1 and t2.EucE <> 1 and t2.EeuE <> 1 and t2.EurE <> 1 and t2.CisE <> 1 and t2.WldI = 1)
		)
-- select * from #Agreements5 where IpBaseNr = 'I-000000109-0'

drop table #Agreements4

-- Фінальний вибір, який дещо ускладнений. Для кожної пари Правовласник-Тип права треба вказати
-- єдиний (перший ліпший) ОКУ, але надати перевагу тим, які містяться в переліку Communities
;with Good as (
	select 
		  IpBaseNr
		, RgtCde
		, Id
	from #Agreements5 t1
		join Community t2 on t1.SocCde = cast(t2.interCode as int)
),
GoodSocId as (
	select 
		  IpBaseNr
		, RgtCde
		, max(Id) Id
	from Good
	group by
		  IpBaseNr
		, RgtCde
),
GoodSocCde as (
	select 
		  t1.IpBaseNr
		, t1.RgtCde
		, t1.SocCde
		, t1.Id
	from #Agreements5 t1
		join GoodSocId t2 on t1.Id = t2.Id
),
Bad as (
	select 
		  IpBaseNr
		, RgtCde
		, Id
	from #Agreements5 t1
		left join Community t2 on t1.SocCde = cast(t2.interCode as int)
	where t2.interCode is null
),
BadSocId as (
	select 
		  IpBaseNr
		, RgtCde
		, max(Id) Id
	from Bad
	group by
		  IpBaseNr
		, RgtCde
),
BadSocCde as (
	select 
		  t1.IpBaseNr
		, t1.RgtCde
		, t1.SocCde
		, t1.Id
	from #Agreements5 t1
		join GoodSocId t2 on t1.Id = t2.Id
),
SocForRight as (
	select 
		  IpBaseNr
		, RgtCde
		, SocCde
		, Id
	from GoodSocCde
	union
	select
		  IpBaseNr
		, RgtCde
		, SocCde
		, Id
	from BadSocCde
),
SocPer as (
	select 
		  t1.IpBaseNr
		, t2.SocCde SocPer
	from #IpBaseNrList t1
		join SocForRight t2 on t1.IpBaseNr = t2.IpBaseNr
			and t2.RgtCde = 'PR'
),
SocMec as (
	select 
		  t1.IpBaseNr
		, t2.SocCde SocMec
	from #IpBaseNrList t1
		join SocForRight t2 on t1.IpBaseNr = t2.IpBaseNr
			and t2.RgtCde = 'MR'
)
select 
	  t1.IpBaseNr
	, t2.SocPer
	, t3.SocMec
from #IpBaseNrList t1
	left join SocPer t2 on t1.IpBaseNr = t2.IpBaseNr
	left join SocMec t3 on t1.IpBaseNr = t3.IpBaseNr
end

/*
Usage example:

-- Вхідна інформація  перелік правовласників
-- Procedure expect table named #IpBaseNrList is filled in
drop table if exists #IpBaseNrList
select top 100
	IpBaseNr
into #IpBaseNrList
from SocIpi..IpiBase
-- select * from #IpBaseNrList

drop table if exists #tmp
create table #tmp (
	  IpBaseNr varchar(13)
	, SocPer int
	, SocMec int
)

insert #tmp (
	  IpBaseNr
	, SocPer
	, SocMec
)
exec spWidIpBasNrSoc

select * from #tmp
drop table #tmp
*/
