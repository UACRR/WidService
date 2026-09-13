use ShareCalc
go

create or alter procedure spCalcShares
	  @objId int
	, @excSetId int
	, @applyTikTokRules int
as
begin

-- >>>>>>>> ТИМЧАСОВА ТАБЛИЦЯ ПРОЦЕНТІВ
	drop table if exists #Shares
	create table #Shares (
	  Id int primary key nonclustered

	, ObjId int
	, CustId int

	, PerSoc int
	, PerShr decimal(5, 2)
	, PerShrRes decimal(5, 2)
	, PerRhSvcExc bit -- Для своїх - наявність потрібного сервісу від товариства
	, PerSocAgrExc bit -- Для іноземних - навність договору з товариством
	, PerSocExc bit -- Товариство в переліку виключень
	, PerRhExc bit -- Правовласник в переліку виключень
	, PerAdvExc bit -- Для видавців твору за переліком виключених товариств

	, MecSoc int
	, MecShr decimal(5, 2)
	, MecShrRes decimal(5, 2)
	, MecRhSvcExc bit
	, MecSocAgrExc bit
	, MecSocExc bit
	, MecRhExc bit
	, MecAdvExc bit
)

	insert #Shares (Id, ObjId, CustId, PerShr, PerShrRes, MecShr, MecShrRes)
	select cRightId, ObjId, CustId, rate, rate, rateMech, rateMech
	from MediaService..CopyRight
	where Status = 1
		and getdate() between isnull(beginDate, datefromparts(1900, 1, 1)) and isnull(endDate, datefromparts(3000, 1, 1))
		and (isnull(rate, 0) + isnull(rateMech, 0)) > 0
		and ObjId = @objId

-- >>>>>>>> ПЕРЕВІРКА СТАНДАРТНИХ ВИМОГ ДЛЯ ПРАВОВЛАСНИКІВ ТОВАРИСТВА

-- Правовласники товариства
update t1
set t1.PerSoc = 140, t1.MecSoc = 140
-- select *
from #Shares t1
	join MediaService..AgreementAddRh t2 on t1.CustId = t2.CustId
		and t2.AgrStatus = 2

-- Наявність сервісів
-- Відтворення в мережі Інтернет = 5
-- Механічне відтворення в мережі Інтернет = 7
update t1
set t1.PerRhSvcExc = (select case when t2.CustId is null then 1 else 0 end)
--select case when t2.CustId is null then 1 else 0 end
from #Shares t1
	left join MediaService..TermsOfService t2 on t1.CustId = t2.CustId
		and t2.CRKindCode = 5
		and t2.OurService = 1
where t1.PerSoc = 140

update t1
set t1.MecRhSvcExc = (select case when t2.CustId is null then 1 else 0 end)
--select case when t2.CustId is null then 1 else 0 end
from #Shares t1
	left join MediaService..TermsOfService t2 on t1.CustId = t2.CustId
		and t2.CRKindCode = 7
		and t2.OurService = 1
where t1.MecSoc = 140

-- >>>>>>>> ПЕРЕВІРКА СТАНДАРТНИХ ВИМОГ ДЛЯ СТОРОННІХ ПРАВОВЛАСНИКІВ

-- Наявність сервісів
-- Відтворення в мережі Інтернет = 5
-- Механічне відтворення в мережі Інтернет = 7
update t1
set t1.PerSoc = t3.InterCode
--select *
from #Shares t1
	join MediaService..CustCmRight t2 on t1.CustId = t2.CustId
		and t2.CRKindCode = 5
	join MediaService..Community t3 on t2.CmCustId = t3.CustId
where isnull(t1.PerSoc, 0) <> 140

update t1
set t1.PerSoc = null
--select *
from #Shares t1
where isnull(t1.PerSoc, 0) = 99

update t1
set t1.MecSoc = t3.InterCode
--select *
from #Shares t1
	join MediaService..CustCmRight t2 on t1.CustId = t2.CustId
		and t2.CRKindCode = 7
	join MediaService..Community t3 on t2.CmCustId = t3.CustId
where isnull(t1.MecSoc, 0) <> 140

update t1
set t1.PerSoc = t3.InterCode
--select *
from #Shares t1
	join MediaService..CustCmRight t2 on t1.CustId = t2.CustId
		and t2.CRKindCode = 5
	join MediaService..Community t3 on t2.CmCustId = t3.CustId
where isnull(t1.PerSoc, 0) <> 140

update t1
set t1.MecSoc = null
--select *
from #Shares t1
where isnull(t1.MecSoc, 0) = 99

-- Наявність договору з товариством
update t1
set t1.PerSocAgrExc = case
	when t3.CustId is null then 1
	else case when isnull(t3.IsPer, 0) = 1 and getdate() between DateBeginPer and DateEndPer then 0 else 1 end
	end
--select *
from #Shares t1
	join MediaService..Community t2 on t1.PerSoc = t2.InterCode
	left join MediaService..AgreementAddCommunity t3 on t2.CustId = t3.CustId
where isnull(t1.PerSoc, 0) <> 140
	and t1.PerSoc is not null

update t1
set t1.MecSocAgrExc = case
	when t3.CustId is null then 1
	else case when isnull(t3.IsMec, 0) = 1 and getdate() between DateBeginMec and DateEndMec then 0 else 1 end
	end
--select *
from #Shares t1
	join MediaService..Community t2 on t1.MecSoc = t2.InterCode
	left join MediaService..AgreementAddCommunity t3 on t2.CustId = t3.CustId
where isnull(t1.MecSoc, 0) <> 140
	and t1.MecSoc is not null

-- Для товариства 99
update #Shares
set PerSocAgrExc = 1
	, PerSoc = null
	, PerShrRes = 0
where PerSoc = 99

update #Shares
set MecSocAgrExc = 1
	, MecSoc = null
	, MecShrRes = 0
where MecSoc = 99

-- >>>>>>>> ПЕРЕВІРКА СПЕЦІАЛЬНИХ ВИМОГ
if @excSetId is not null
begin
	-- За товариством
	update t1
	set t1.PerSocExc = (case when t2.SocCde is null then 0 else 1 end)
	--select *
	from #Shares t1
		left join ExcSocPer t2 on t1.PerSoc = t2.SocCde
			and t2.ExcSetId = @excSetId
	where isnull(t1.PerSoc, 0) <> 140
		and t1.PerSoc is not null

	update t1
	set t1.MecSocExc = (case when t2.SocCde is null then 0 else 1 end)
	--select *
	from #Shares t1
		left join ExcSocMec t2 on t1.MecSoc = t2.SocCde
			and t2.ExcSetId = @excSetId
	where isnull(t1.MecSoc, 0) <> 140
		and t1.MecSoc is not null

	-- За правовласником
	update t1
	set t1.PerRhExc = (case when t3.IpNameNr is null then 0 else 1 end)
	--select *
	from #Shares t1
		join MediaService..RightHolder t2 on t1.CustId = t2.CustId
		left join ExcRhPer t3 on t2.IPIBase = t3.IpNameNr
			and t3.ExcSetId = @excSetId
	where isnull(t1.PerSoc, 0) <> 140
		and t1.PerSoc is not null

	update t1
	set t1.MecRhExc = (case when t3.IpNameNr is null then 0 else 1 end)
	--select *
	from #Shares t1
		join MediaService..RightHolder t2 on t1.CustId = t2.CustId
		left join ExcRhMec t3 on t2.IPIBase = t3.IpNameNr
			and t3.ExcSetId = @excSetId
	where isnull(t1.MecSoc, 0) <> 140
		and t1.MecSoc is not null

	-- За видавцем
	drop table if exists #SocCdes
	select distinct t3.SocCde
	into #SocCdes
	from #Shares t1
		join MediaService..RightHolder t2 on t1.CustId = t2.CustId
		join ExcSocAdv t3 on t2.InterCode = t3.RhIpBaseNr
			and t3.ExcSetId = @excSetId

	update t1
	set t1.PerAdvExc = (case when t2.SocCde is null then 0 else 1 end)
	--select *
	from #Shares t1
		left join #SocCdes t2 on t1.PerSoc = t2.SocCde
	where isnull(t1.PerSoc, 0) <> 140
		and t1.PerSoc is not null

	update t1
	set t1.MecAdvExc = (case when t2.SocCde is null then 0 else 1 end)
	--select *
	from #Shares t1
		left join #SocCdes t2 on t1.MecSoc = t2.SocCde
	where isnull(t1.MecSoc, 0) <> 140
		and t1.MecSoc is not null

end

-- >>>>>>>> РОЗАХУНОК ОСТАТОЧНИХ ПРОЦЕНТІВ
update #Shares
set PerShrRes = 0
where PerSoc is null
	or PerShr			= 1
	or PerShrRes		= 1
	or PerRhSvcExc		= 1
	or PerSocAgrExc		= 1
	or PerSocExc		= 1
	or PerRhExc			= 1
	or PerAdvExc		= 1

update #Shares
set MecShrRes = 0
where MecSoc is null
	or MecShr			= 1
	or MecShrRes		= 1
	or MecRhSvcExc		= 1
	or MecSocAgrExc		= 1
	or MecSocExc		= 1
	or MecRhExc			= 1
	or MecAdvExc		= 1

-- >>>>>>>> ЗАСТОСУВАННЯ РЕЗУЛЬТАТІ
delete from Shares where ObjId = @objId
insert Shares
select * from #Shares

-- >>>>>>>> ПРАВИЛА ТІКТОК
if @applyTikTokRules = 1
begin
	exec ShareCalc..spAddWorkExtras @objId
end

end
go

-- exec spCalcShares 339626, 17, 1
-- select * from Shares where ObjId = 339626

