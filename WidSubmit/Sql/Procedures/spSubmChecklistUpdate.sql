use SocWidSubmitEx
go

create or alter procedure spSubmChecklistUpdate
as
begin
	
	-- SubmWorkStatus
	declare @NOT_READY			int = 0
	declare @READY				int = 1
	declare @SUBMITTED			int = 2
	declare @ACCEPTED			int = 3
	declare @ACCEPTED_WARNINGS	int = 4
	declare @REJECTED			int = 5
	declare @APPLIED			int = 6
	declare @COMPLETED			int = 7

	declare @rhTypeRightHolder int = 1
	declare @rhTypeCommunity int = 2
	declare @rhTypePublisher int = 3

	drop table if exists #CheckList
	select 
		   Id    as SubmWorkId
		,  0	 as HasOwnRightHolder
		,  1	 as RolesDefined
		,  0	 as HasNonPublisher
		,  1	 as AllInIpi
		,  0	 as PubShare0or100
		,  0	 as MecShare0or100
		,  0	 as HasShare
		,  1	 as AllIpiCodesExist
		,  1	 as AllIpiCodesValid
		,  0	 as IsOk
	into #CheckList
	from vCurSubmWorks

	drop table if exists #ShareRightHolders
	select 
		  t2.Id as SubmWorkId
		, t3.Id as RightHolderId
		, t3.CustId
		, t3.RhType
		, t1.RhRole
		, t1.RoleForWid
		, t3.IpBaseNr
		, t3.IpNameNr
		, t3.IsOwn
		, t3.IsActive
		, t3.HasIpiAgreePer
		, t3.HasIpiAgreeMec
		, t1.ShrPer
		, t1.ShrMec
	into #ShareRightHolders
	from SubmWorkShare t1
		join vCurSubmWorks t2 on t1.SubmWorkId = t2.Id
		join vCurRightHolder t3 on t1.RightHolderId = t3.Id

	-- Є автор, що має договри з УАСПП
	; with ValidWorkIds as (
		select distinct SubmWorkId
		from #ShareRightHolders
		where IsOwn = 1
	)
	update t1
	set t1.HasOwnRightHolder = 1
	from #CheckList t1
		join ValidWorkIds t2 on t1.SubmWorkId = t2.SubmWorkId

    -- Для всіх автрів/видавців визначені ролі
	; with InvalidWorkIds as (
		select distinct SubmWorkId
		from SubmWorkShare t1
			join vCurSubmWorks t2 on t1.SubmWorkId = t2.Id
		where t1.RoleForWid = ''
	)
	update t1
	set t1.RolesDefined = 0
	from #CheckList t1
		join InvalidWorkIds t2 on t1.SubmWorkId = t2.SubmWorkId

	-- Є правовласники окрім видавців
	; with ValidWorkIds as (
		select distinct SubmWorkId
		from #ShareRightHolders
		where RhType <> @rhTypePublisher

	)
	update t1
	set t1.HasNonPublisher = 1
	from #CheckList t1
		join ValidWorkIds t2 on t1.SubmWorkId = t2.SubmWorkId

	-- Всі автори/видавці мають коди IPI
	; with InvalidWorkIds as (
		select distinct SubmWorkId
		from #ShareRightHolders
		where (isnull(IpBaseNr, '') = '' or isnull(IpNameNr, 0) = 0)
			and SubmWorkId = 18384
	)
	update t1
	set t1.AllInIpi = 0
	from #CheckList t1
		join InvalidWorkIds t2 on t1.SubmWorkId = t2.SubmWorkId
	-- select * from #CheckList

    -- Сума процентів Пуб нуль або 100
	; with WorkShrPer as (
		select 
			  t2.Id as SubmWorkId
			, sum(ShrPer) as Shr
		from SubmWorkShare t1
			join vCurSubmWorks t2 on t1.SubmWorkId = t2.Id
		group by t2.Id
	)
	update t1
	set t1.PubShare0or100 = 1
	from #CheckList t1
		join WorkShrPer t2 on t1.SubmWorkId = t2.SubmWorkId
	where t2.Shr = 0 or t2.Shr = 100

    -- Сума процентів Мех нуль або 100
	; with WorkShrMec as (
		select 
			  t2.Id as SubmWorkId
			, sum(ShrMec) as Shr
		from SubmWorkShare t1
			join vCurSubmWorks t2 on t1.SubmWorkId = t2.Id
		group by t2.Id
	)
	update t1
	set t1.MecShare0or100 = 1
	from #CheckList t1
		join WorkShrMec t2 on t1.SubmWorkId = t2.SubmWorkId
	where t2.Shr = 0 or t2.Shr = 100

	-- Має проценти
	; with WorkTotalShare as (
		select 
			  t2.Id as SubmWorkId
			, sum(ShrPer + ShrMec) as Shr
		from SubmWorkShare t1
			join vCurSubmWorks t2 on t1.SubmWorkId = t2.Id
		group by t2.Id
	)
	update t1
	set t1.HasShare = 1
	from #CheckList t1
		join WorkTotalShare t2 on t1.SubmWorkId = t2.SubmWorkId
	where t2.Shr > 0
	
	-- Всі автори мають міжнародні коди
	; with InvalidWorkIds as (
		select distinct SubmWorkId
		from #ShareRightHolders
		where isnull(IpBaseNr, '') = '' 
			or isnull(IpNameNr, 0) = 0
	)
	update t1
	set t1.AllIpiCodesExist = 0
	from #CheckList t1
		join InvalidWorkIds t2 on t1.SubmWorkId = t2.SubmWorkId

	-- Коди всіх авторів існують в IPI і мають вірний статус (1) - тимчасово не виконуємо
--	; with InvalidWorkIds as (
--		select t1.SubmWorkId
--			, max(case when t3.SttCde is null then 5 else t3.SttCde end) as SttCde
--		from #ShareRightHolders t1
--			left join SocIpi..IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
--			left join SocIpi..IpiStatus t3 on t2.IpBaseNr = t3.IpBaseNr
--		where isnull(t1.IpBaseNr, '') <> ''
--		group by t1.SubmWorkId
--		having max(case when t3.SttCde is null then 5 else t3.SttCde end) <> 1
--	)
--	update t1
--	set t1.AllIpiCodesValid = 0
--	from #CheckList t1
--		join InvalidWorkIds t2 on t1.SubmWorkId = t2.SubmWorkId
	
	--  В підсумку
	update #CheckList
	set IsOk = 1
	where 
			HasOwnRightHolder		= 1
		and RolesDefined			= 1
		and HasNonPublisher			= 1
		and AllInIpi				= 1
		and PubShare0or100			= 1
		and MecShare0or100			= 1
		and HasShare				= 1
		and AllIpiCodesExist		= 1
		and AllIpiCodesValid		= 1

	-- Заносимо результати в постійну таблицю
	delete t1
	from SubmCheckList t1
		join SubmWork t2 on t1.SubmWorkId = t2.Id
	where t2.SubmissionId = dbo.fnCurSubmId()

	insert SubmCheckList (
	      SubmWorkId
		, HasOwnRightHolder
		, RolesDefined
		, HasNonPublisher
		, AllInIpi
		, PubShare0or100
		, MecShare0or100
		, HasShare
		, AllIpiCodesExist
		, AllIpiCodesValid
		, IsOk
	) 
	select
		  SubmWorkId
		, HasOwnRightHolder
		, RolesDefined
		, HasNonPublisher
		, AllInIpi
		, PubShare0or100
		, MecShare0or100
		, HasShare
		, AllIpiCodesExist
		, AllIpiCodesValid
		, IsOk
	from #CheckList

end
go
