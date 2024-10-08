use SocWidSubmit
go

create or alter procedure spWidSubmGroupUpdateChecklist
	@groupId int
as
begin
	-- WidSubmGroupWorkStatus
	declare @Unprocessed		int = 0   -- Не оброблено
	declare @InWork				int = 1	 -- На розгляді
	declare @Postponed			int = 2	 -- Відкладено
	declare @Accepted			int = 3	 -- Завтверждено до передачі
	declare @Sent				int = 4	 -- Надіслано
	declare @Approved			int = 5	 -- Прийнято
	declare @Rejected			int = 6	 -- Відхилено
	declare @PartApproved		int = 7	 -- Прийнято з зауваженнями
	declare @AlreadyInWid		int = 8	 -- Існує в WID
	declare @ReSent				int = 9	 -- Надіслано повторно
	declare @StatusCompleted	int = 10 -- Передачу завершено

	drop table if exists #CheckList
	select 
		   objId as ObjId
		,  0	 as HasOwnAuthor
		,  1	 as RolesDefined
		,  0	 as HasNonPublisher
		,  1	 as AllInIpi
		,  0	 as PubShare0or100
		,  0	 as MecShare0or100
		,  0	 as HasShare
		,  1	 as NamesApproved
		,  1	 as PerformersApproved
		,  1	 as AllIpiCodesValid
	into #CheckList
	from WidSubmGroupWork
	where WidSubmGroupId = @groupId

	-- Є автор, що має договри з УААСП
	; with ValidObjIds as (
		select distinct objId
		from WidSubmGroupWorkShare
		where AggrIpiPer = 1 or AggrIpiMec = 1
	)
	update t1
	set t1.HasOwnAuthor = 1
	from #CheckList t1
		join ValidObjIds t2 on t1.ObjId = t2.ObjId

    -- Для всіх автрів/видавців визначені ролі
	; with InvalidObjIds as (
		select distinct objId
		from WidSubmGroupWorkShare
		where not (
				   (RhType = 1 and RhRole in (1, 2, 5, 6, 7, 10))
				or (RhType = 3 and RhRole in (8, 9))
			)
	)
	update t1
	set t1.RolesDefined = 0
	from #CheckList t1
		join InvalidObjIds t2 on t1.ObjId = t2.ObjId

	-- Є правовласники окрім видавців
	; with ValidObjIds as (
		select distinct objId
		from WidSubmGroupWorkShare
		where RhType <> 3
	)
	update t1
	set t1.HasNonPublisher = 1
	from #CheckList t1
		join ValidObjIds t2 on t1.ObjId = t2.ObjId

    -- Всі автори/видавці зареєстровані в IPI
	; with InvalidObjIds as (
		select distinct objId
		from WidSubmGroupWorkShare
		where isnull(IpNameNr, '') = ''
	)
	update t1
	set t1.AllInIpi = 0
	from #CheckList t1
		join InvalidObjIds t2 on t1.ObjId = t2.ObjId

    -- Сума процентів Пуб нуль або 100
	; with ValidObjIds as (
		select 
			  WidSubmGroupId
			, ObjId
			, sum(PerShr) as Shr
		from WidSubmGroupWorkShare
		group by WidSubmGroupId
			, ObjId
	)
	update t1
	set t1.PubShare0or100 = 1
	from #CheckList t1
		join ValidObjIds t2 on t1.ObjId = t2.ObjId
	where t2.Shr = 0 or t2.Shr = 100

    -- Сума процентів Мех нуль або 100
	; with ValidObjIds as (
		select 
			  WidSubmGroupId
			, ObjId
			, sum(MecShr) as Shr
		from WidSubmGroupWorkShare
		group by WidSubmGroupId
			, ObjId
	)
	update t1
	set t1.MecShare0or100 = 1
	from #CheckList t1
		join ValidObjIds t2 on t1.ObjId = t2.ObjId
	where t2.Shr = 0 or t2.Shr = 100

	-- Має проценти
	; with ValidObjIds as (
		select 
			  WidSubmGroupId
			, ObjId
			, sum(PerShr + MecShr) as Shr
		from WidSubmGroupWorkShare
		group by WidSubmGroupId
			, ObjId
	)
	update t1
	set t1.HasShare = 1
	from #CheckList t1
		join ValidObjIds t2 on t1.ObjId = t2.ObjId
	where t2.Shr > 0

	-- Всі назви затверджені
	; with InvalidObjIds as (
		select distinct objId
		from WidSubmGroupWorkName
		where IsConfirmed = 0
	)
	update t1
	set t1.NamesApproved = 0
	from #CheckList t1
		join InvalidObjIds t2 on t1.ObjId = t2.ObjId

	-- Всі виконавці затверджені
	; with InvalidObjIds as (
		select distinct objId
		from WidSubmGroupWorkPerformer
		where IsConfirmed = 0
	)
	update t1
	set t1.PerformersApproved = 0
	from #CheckList t1
		join InvalidObjIds t2 on t1.ObjId = t2.ObjId

	-- Коди всіх авторів існують в IPI і мають вірний статус (1)
	; with InvalidObjIds as (
		select t1.WidSubmGroupId as GroupId
			, t1.ObjId
			, max(case when t3.SttCde is null then 5 else t3.SttCde end) as SttCde
		from WidSubmGroupWorkShare t1
			left join SocIpi..IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
			left join SocIpi..IpiStatus t3 on t2.IpBaseNr = t3.IpBaseNr
		where isnull(t1.IpBaseNr, '') <> ''
		group by t1.WidSubmGroupId, t1.ObjId
		having max(case when t3.SttCde is null then 5 else t3.SttCde end) <> 1
	)
	update t1
	set t1.AllIpiCodesValid = 0
	from #CheckList t1
		join InvalidObjIds t2 on t1.ObjId = t2.ObjId
	where t2.GroupId = @groupId

	-- Заносимо результати в постійну таблицю
	
	merge WidSubmGroupWorkCheckList as Target
	using #CheckList as Source
	on Source.ObjId = Target.ObjId
		and Target.WidSubmGroupId = @groupId
 	-- For Inserts
	when not matched by Target then
		insert (
			  WidSubmGroupId
			, ObjId
			, HasOwnAuthor
			, RolesDefined
			, HasNonPublisher
			, AllInIpi
			, PubShare0or100
			, MecShare0or100
			, HasShare
			, NamesApproved
			, PerformersApproved
			, AllIpiCodesValid
		) 
		values (
			  @groupId
			, Source.ObjId
			, Source.HasOwnAuthor
			, Source.RolesDefined
			, Source.HasNonPublisher
			, Source.AllInIpi
			, Source.PubShare0or100
			, Source.MecShare0or100
			, Source.HasShare
			, Source.NamesApproved
			, Source.PerformersApproved
			, Source.AllIpiCodesValid
		)
 	-- For Updates
	when matched then update set
			  Target.HasOwnAuthor		 = Source.HasOwnAuthor		             
			, Target.RolesDefined		 = Source.RolesDefined
			, Target.HasNonPublisher	 = Source.HasNonPublisher
			, Target.AllInIpi			 = Source.AllInIpi
			, Target.PubShare0or100		 = Source.PubShare0or100
			, Target.MecShare0or100		 = Source.MecShare0or100
			, Target.HasShare			 = Source.HasShare
			, Target.NamesApproved		 = Source.NamesApproved
			, Target.PerformersApproved	 = Source.PerformersApproved
			, Target.AllIpiCodesValid	 = Source.AllIpiCodesValid
	;

	--select * from WidSubmGroupWorkCheckList where WidSubmGroupId = @groupId

end
go

-- exec spWidSubmGroupUpdateChecklist 18
