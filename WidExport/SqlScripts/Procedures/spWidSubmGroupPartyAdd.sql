use SocWidSubmit
go

create or alter procedure spWidSubmGroupPartyAdd
	  @WidSubmGroupId as int
	, @IpBaseNr as varchar(13)
	, @IpNameNr as int
as
begin
	-- declare @WidSubmGroupId as int = 7
	--declare @IpBaseNr as varchar(13) = 'I-004509062-6'
	--declare @IpNameNr as int = 829484695

	declare @retValOk int = 0
	declare @retValNotFound int = 1
	declare @retValManyFound int = 2
	declare @retValAlreadyAdded int = 3
	declare @retValException int = 4

	-- ШУКАЄМО ObjId ПРАВОВЛАСНИКА НА ОСНОВІ МІЖНАРОДНИХ КОДІВ
	drop table if exists #PartyCustId
	; with partyCustId  as (
		select
		  custId		as custId
		from MediaService..RightHolder
		where cast(IPIBase as int) = @IpNameNr
		union
		select
			  custId		as custId
		from MediaService..RightHolder
		where interCode = @IpBaseNr
	)
	select
		  custId
	into #PartyCustId
	from partyCustId

	declare @cnt int = @@rowcount

	if @cnt = 0
	begin
		return @retValNotFound
	end

	if @cnt > 1
	begin
		return @retValManyFound
	end

	declare @CustId int = (select CustId from #PartyCustId)
	if exists (select null from SocWidSubmit..WidSubmGroupParty where CustId = @CustId)
	begin
		return @retValAlreadyAdded
	end

	-- ШУКАЄМО ПЕРЕЛІК ObjId ЯКИМИ ВОЛОДІЄ ПРАВОВЛАСНИК
	drop table if exists #PartyObjId

	select distinct 
		t3.objId
	into #PartyObjId
	from #PartyCustId t1
		join MediaService..CopyRight t2 on t1.custId = t2.custId
		join MediaService..ObjectRight t3 on t2.objId = t3.objId
--	order by t3.name

	-- ШУКАЄМО ПЕРЕЛІК ObjId ЯКІ ТРЕБА ДОДАТИ ДО ГРУПИ
	drop table if exists #NewObjId

	select objId
	into #NewObjId
	from #PartyObjId
	where ObjId not in (
		select ObjId
		from SocWidSubmit..WidSubmGroupWork
	)

	-- ШУКАЄМО ІНФОРМАЦІЮ ПРО НАЗВИ ДОДАТКОВИХ ТВОРІВ
	drop table if exists #Name
	select
		  null			as SeekObjectId	
		, t1.ObjId		as ObjId
		, t1.Name		as LocalName
		, ''			as WidName		
		, 1				as IsMain		
		, 0				as IsConfirmed
		, 0				as IsDuplicate
		, 'robot'		as CreatedBy		
		, 'robot'		as ModifiedBy	
		, getdate()		as CreatedAt		
		, getdate()		as ModifiedAt
	into #Name
	from MediaService..ObjectRight t1
		join #NewObjId t2 on t1.ObjId = t2.ObjId

	insert #Name (
		  SeekObjectId
		, ObjId
		, LocalName
		, WidName		
		, IsMain		
		, IsConfirmed
		, IsDuplicate
		, CreatedBy	
		, ModifiedBy	
		, CreatedAt	
		, ModifiedAt
	)
	select
		  t1.id			as SeekObjectId
		, t1.ObjId		as ObjId
		, t1.Name		as LocalName
		, ''			as WidName		
		, 0				as IsMain		
		, 0				as IsConfirmed
		, 0				as IsDuplicate
		, 'robot'		as CreatedBy		
		, 'robot'		as ModifiedBy	
		, getdate()		as CreatedAt		
		, getdate()		as ModifiedAt
	from MediaService..SeekObject t1
		join #NewObjId t2 on t1.ObjId = t2.ObjId
	where t1.codeI = 1
		and trim(isnull(t1.Name, '')) <> ''
		and not exists (
			select null
			from #Name t2
			where t2.ObjId = t1.ObjId
				and t2.LocalName = t1.Name
		)

	-- ШУКАЄМО ІНФОРМАЦІЮ ПРО ВИКОНАВЦІВ ДОДАТКОВИХ ТВОРІВ
	drop table if exists #Performer
	select distinct
		  t1.Id			as SeekObjectId
		, t1.ObjId		as ObjId
		, t1.Name		as LocalName
		, ''			as WidName		
		, 0				as IsConfirmed
		, 0				as IsDuplicate
		, 'robot'		as CreatedBy		
		, 'robot'		as ModifiedBy	
		, getdate()		as CreatedAt		
		, getdate()		as ModifiedAt
	into #Performer
	from MediaService..SeekObject t1
		join #NewObjId t2 on t1.ObjId = t2.ObjId
	where t1.CodeI = 2
		and trim(isnull(t1.Name, '')) <> ''

	-- ШУКАЄМО ІНФОРМАЦІЮ ПРО ПРОЦЕНТИ ДОДАТКОВИХ ТВОРІВ
	drop table if exists #Share
	create table #Share(
		 ObjId				int
	   , CopyRightId		int			   not null
	   , CustId				int
	   , IpBaseNr			varchar(13) null
	   , IpNameNr			int null
	   , RhType				int
	   , RhRole				int
	   , PerShr				decimal(5, 2) not null
	   , MecShr				decimal(5, 2) not null
	   , AggrLocal			bit not null
	   , AggrIpiPer			bit not null
	   , AggrIpiMec			bit not null
	   , CreatedBy			varchar(10) not null
	   , ModifiedBy			varchar(10) not null
	   , CreatedAt			datetime not null
	   , ModifiedAt			datetime not null
	)

	drop table if exists #CopyRight
	create table  #CopyRight (
		  cRightId	int not null primary key
		, objid		int 
		, custId	int 
		, roleCode	int
	)

	; with Rights as (
		select 
			  objid		
			, custId	
			, roleCode
			, max(crightId) as crightId
		from MediaService..CopyRight
		group by  objId		
				, custId	
				, roleCode
	)
	insert into #CopyRight (
		  crightId
		, objid
		, custId
		, roleCode
	)
	select 
		  t2.cRightId as crightId
		, t2.objId	  as objid
		, t2.custId	  as custId
		, t2.roleCode as roleCode
	from Rights t1
		join MediaService..CopyRight t2 on t1.crightId = t2.cRightId
		join #NewObjId t3 on t2.objId = t3.ObjId
	where (t2.beginDate <= getdate() and t2.endDate >= getdate()) -- Перевіряємо перетин інтервалів дат

	-- Заповнюємо авторів творів	
	insert into #Share (
		   ObjId
		 , CopyRightId
		 , CustId
		 , IpBaseNr	
		 , IpNameNr
		 , RhType
		 , RhRole
		 , PerShr		
		 , MecShr		
		 , AggrLocal	
		 , AggrIpiPer	
		 , AggrIpiMec	
		 , CreatedBy	
		 , ModifiedBy	
		 , CreatedAt	
		 , ModifiedAt	
	)
	select distinct -- З невідомих причин можливе дублювання інформації
		  t1.ObjId					as ObjId
		, t1.cRightId				as CopyRightId
		, t2.custId					as CustId
		, left(t3.interCode, 13)	as IpBaseNr
		, left(t3.IPIbase, 13)		as IpNameNr
		, t3.rHolderType			as RhType
		, t2.roleCode				as RhRole
		, t2.rate					as PerShr
		, t2.rateMech				as MecShr
		, 0							as AggrLocal	
		, 0							as AggrIpiPer	
		, 0							as AggrIpiMec	
		, 'robot'					as CreatedBy	
		, 'robot'					as ModifiedBy	
		, getdate()					as CreatedAt	
		, getdate()					as ModifiedAt
	from #CopyRight t1 
		join MediaService..CopyRight t2 on t1.cRightId = t2.cRightId 
		join MediaService..RightHolder t3 on t2.custId = t3.custId 
	where isnull(t1.ObjId, 0) <> 0

	drop table #CopyRight

	-- Додатковий пошук міжнародних кодів
	update t1
	set t1.IpNameNr = t2.IPInr
	from #Share t1
		left join MediaService..RepMSIPI t2 on t1.custId = t2.custId
	where t2.custId is not null

	update t1
	set t1.IpNameNr = t2.IpNameNr
	from #Share t1
		join SocIpi..IpiName t2 on t1.IpBaseNr = t2.IpBaseNr and t2.NameType = 'PA'

	update t1
	set t1.IpBaseNr = t2.IpBaseNr
	from #Share t1
		join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
	where t1.IpBaseNr is null

	-- Наявність договору в Ms
	update t1
	set t1.AggrLocal = case when t2.custId is null then 0 else 1 end
	from #Share t1
		left join MediaService..AgreementMaster t2 on t1.custId = t2.custId
			and t2.agrStatus = 2

	-- Наявність договору Пуб в Ipi
	update t1
	set t1.AggrIpiPer = 1
	from #Share t1
		join SocIpi..IpiAgreement t2 on t1.IpBaseNr = t2.IpBaseNr
	where t2.RgtCde = 'PR'
		and t2.CreClsCde = 'MW'
		and RolCde in ('LY', 'MC', 'EM')
		and t2.SocCde = 140
		and getdate() between t2.fromDt and t2.toDt

	-- Наявність договору Мех в Ipi
	update t1
	set t1.AggrIpiMec = 1
	from #Share t1
		join SocIpi..IpiAgreement t2 on t1.IpBaseNr = t2.IpBaseNr
	where t2.RgtCde = 'MR'
		and t2.CreClsCde = 'MW'
		and RolCde in ('LY', 'MC', 'EM')
		and t2.SocCde = 140
		and getdate() between t2.fromDt and t2.toDt

	-- ЗАНОСИМО ІНФОРМАЦІЮ В ПОСТІЙНІ ТАБЛИЦІ БАЗИ ДАНИХ
	declare @retVal int
	
	begin tran
	begin try

		-- WidSubmGroupParty
		insert SocWidSubmit..WidSubmGroupParty (
			  WidSubmGroupId
			, CustId		
			, IpBaseNr		
			, IpNameNr		
		)
		values (
			  @WidSubmGroupId
			, @CustId
			, @IpBaseNr
			, @IpNameNr
		)

		-- WidSubmGroupWork
		insert SocWidSubmit..WidSubmGroupWork (
			  WidSubmGroupId
			, ObjId			
			, Status		
			, ReSubmitIswc
		)
		select
			  @WidSubmGroupId
			, ObjId
			, 0
			, ''
		from #NewObjId t1
		
		-- WidSubmGroupPartyWork
		insert SocWidSubmit..WidSubmGroupPartyWork (
			  WidSubmGroupId
			, IpNameNr
			, ObjId			
		)
		select
			  @WidSubmGroupId
			, @IpNameNr
			, ObjId
		from #PartyObjId t1
		where not exists (
			select null from SocWidSubmit..WidSubmGroupWork t2 where t1.ObjId = t2.ObjId and t2.WidSubmGroupId <> @WidSubmGroupId
		)

		-- WidSubmGroupWorkName
		insert WidSubmGroupWorkName (
			  WidSubmGroupId
			, SeekObjectId
			, ObjId
			, LocalName
			, WidName	
			, IsMain	
			, IsConfirmed
			, IsDuplicate
			, CreatedBy	
			, ModifiedBy
			, CreatedAt	
			, ModifiedAt
		)
		select
			  @WidSubmGroupId
			, SeekObjectId
			, ObjId
			, isnull(LocalName, '')
			, left(isnull(WidName, ''), 60)	
			, IsMain	
			, IsConfirmed
			, IsDuplicate
			, CreatedBy	
			, ModifiedBy
			, CreatedAt	
			, ModifiedAt
		from #Name

		-- WidSubmGroupWorkPerformer
		insert WidSubmGroupWorkPerformer (
			  WidSubmGroupId
			, SeekObjectId
			, ObjId
			, LocalName
			, WidName	
			, IsConfirmed
			, IsDuplicate
			, CreatedBy
			, ModifiedBy
			, CreatedAt
			, ModifiedAt
		)
		select
		      @WidSubmGroupId
			, SeekObjectId
			, ObjId
			, isnull(LocalName, '')
			, left(isnull(WidName, ''), 35)	
			, IsConfirmed
			, IsDuplicate
			, CreatedBy
			, ModifiedBy
			, CreatedAt
			, ModifiedAt
		from #Performer

		-- WidSubmGroupWorkShare
		insert WidSubmGroupWorkShare (
			   WidSubmGroupId
			 , ObjId
			 , CopyRightId 
			 , CustId
			 , IpBaseNr	
			 , IpNameNr
			 , RhType
			 , RhRole
			 , PerShr		
			 , MecShr		
			 , AggrLocal	
			 , AggrIpiPer	
			 , AggrIpiMec	
			 , CreatedBy	
			 , ModifiedBy	
			 , CreatedAt	
			 , ModifiedAt	
		)
		select
			   @WidSubmGroupId
			 , ObjId
			 , CopyRightId  
			 , CustId
			 , IpBaseNr	
			 , IpNameNr
			 , RhType
			 , RhRole
			 , PerShr		
			 , MecShr		
			 , AggrLocal	
			 , AggrIpiPer	
			 , AggrIpiMec	
			 , CreatedBy	
			 , ModifiedBy	
			 , CreatedAt	
			 , ModifiedAt	
		from #Share

		-- Проставляємо статус для творів, що вже існують в WID
		/*
		update t1
		set Status = 8
		from WidSubmGroupWork t1
			join ObjIdToWic t2 on t1.ObjId = t2.ObjId
		where status = 0
		*/

		set @retVal = @retValOk
		commit tran
	end try

	begin catch
		
		rollback tran
		set @retVal = @retValException
		select 
			  error_number() as ErrorNumber
			, error_severity() as ErrorSeverity
			, error_state() as ErrorState
			, error_procedure() as ErrorProcedure
			, error_line() as ErrorLine
			, error_message() as ErrorMessage
	end catch

	drop table if exists #PartyCustId
	drop table if exists #NewObjId
	drop table if exists #Name
	drop table if exists #Performer
	drop table if exists #Share

	return @retVal
end
go

-- declare @res int
-- exec @res = spWidSubmGroupPartyAdd 16, 'I-002207640-8', 458606529
-- select @res