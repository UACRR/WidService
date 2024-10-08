use SocWidSubmit
go

create or alter procedure spWidSubmGroupWorkUpdateFromMs
	  @groupId int
	, @ObjId as int
as
begin
	--declare @ObjId as int = 8070

	declare @retValOk int = 0
	declare @retValException int = 4

	declare @WidSubmGroupId int = @groupId
	-- ШУКАЄМО ІНФОРМАЦІЮ ПРО НАЗВИ ДОДАТКОВИХ ТВОРІВ
	drop table if exists #Name

	create table #Name (
		  SeekObjectId	int
		, ObjId int
		, LocalName varchar(200)
		, WidName varchar(1200)		
		, IsMain bit	
		, IsConfirmed bit
		, IsDuplicate bit
		, CreatedBy varchar(20)
		, ModifiedBy varchar(20)	
		, CreatedAt	datetime
		, ModifiedAt datetime
	)

	insert into #Name (
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
		  null							as SeekObjectId	
		, ObjId						as ObjId
		, Name						as LocalName
		, ''						as WidName		
		, 1							as IsMain		
		, 0							as IsConfirmed
		, 0							as IsDuplicate
		, 'robot'					as CreatedBy		
		, 'robot'					as ModifiedBy	
		, getdate()					as CreatedAt		
		, getdate()					as ModifiedAt
	from MediaService..ObjectRight t1
	where ObjId = @ObjId

	insert into #Name (
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
		  null			as SeekObjectId
		, ObjId			as ObjId
		, Name			as LocalName
		, ''			as WidName		
		, 0				as IsMain		
		, 0				as IsConfirmed
		, 0				as IsDuplicate
		, 'robot'		as CreatedBy		
		, 'robot'		as ModifiedBy	
		, getdate()		as CreatedAt		
		, getdate()		as ModifiedAt
	from MediaService..SeekObject t1
	where
		    ObjId = @ObjId
		and t1.codeI = 1
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
		  Id			as SeekObjectId
		, ObjId			as ObjId
		, Name			as LocalName
		, ''			as WidName		
		, 0				as IsConfirmed
		, 0				as IsDuplicate
		, 'robot'		as CreatedBy		
		, 'robot'		as ModifiedBy	
		, getdate()		as CreatedAt		
		, getdate()		as ModifiedAt
	into #Performer
	from MediaService..SeekObject
	where ObjId = @ObjId
		and CodeI = 2

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
	where t2.ObjId = @ObjId
		and (t2.beginDate <= getdate() and t2.endDate >= getdate()) -- Перевіряємо перетин інтервалів дат

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

		-- WidSubmGroupWorkName for main name
		update t1
		set t1.LocalName = t2.LocalName
		--select *
		from WidSubmGroupWorkName t1
			join #Name t2 on t1.ObjId = t2.ObjId
		where t2.IsMain = 1

		-- Лишаємо альтеративні назви
		delete from #Name where IsMain = 1

		-- WidSubmGroupWorkName for alt names
		merge WidSubmGroupWorkName as Target
		using #Name as Source
		on Source.SeekObjectId = Target.SeekObjectId
		-- For Inserts
		when not matched by Target then
			insert (
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
			values (
				  @WidSubmGroupId
				, Source.SeekObjectId
				, Source.ObjId
				, isnull(Source.LocalName, '')
				, left(isnull(Source.WidName, ''), 60)	
				, Source.IsMain	
				, Source.IsConfirmed
				, Source.IsDuplicate
				, Source.CreatedBy	
				, Source.ModifiedBy
				, Source.CreatedAt	
				, ModifiedAt
			)
 		-- For Updates
		when matched then update set
				  Target.LocalName	= Source.LocalName		             
		;

		-- WidSubmGroupWorkPerformer
		merge WidSubmGroupWorkPerformer as Target
		using #Performer as Source
		on Source.SeekObjectId = Target.SeekObjectId
		-- For Inserts
		when not matched by Target then
			insert (
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
			values (
				  @WidSubmGroupId
				, Source.SeekObjectId
				, Source.ObjId
				, isnull(Source.LocalName, '')
				, left(isnull(Source.WidName, ''), 60)	
				, Source.IsConfirmed
				, Source.IsDuplicate
				, Source.CreatedBy	
				, Source.ModifiedBy
				, Source.CreatedAt	
				, ModifiedAt
			)
 		-- For Updates
		when matched then update set
				  Target.LocalName	= Source.LocalName		             
		;

		-- WidSubmGroupWorkShare
		; with TargetRecs as (
			select *
			from WidSubmGroupWorkShare
			where ObjId = @ObjId
		)
		merge TargetRecs as Target
		using #Share as Source
		on Source.CopyRightId = Target.CopyRightId
		-- For Inserts
		when not matched by Target then
			insert (
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
			values (
				   @WidSubmGroupId
				 , Source.ObjId
				 , Source.CopyRightId  
				 , Source.CustId
				 , Source.IpBaseNr	
				 , Source.IpNameNr
				 , Source.RhType
				 , Source.RhRole
				 , Source.PerShr		
				 , Source.MecShr		
				 , Source.AggrLocal	
				 , Source.AggrIpiPer	
				 , Source.AggrIpiMec	
				 , Source.CreatedBy	
				 , Source.ModifiedBy	
				 , Source.CreatedAt	
				 , Source.ModifiedAt
			)
 		-- For Updates
		when matched then update set
			   Target.IpBaseNr	  = Source.IpBaseNr	    
			 , Target.IpNameNr	  = Source.IpNameNr
			 , Target.RhType	  = Source.RhType
			 , Target.RhRole	  = Source.RhRole
			 , Target.PerShr	  = Source.PerShr		
			 , Target.MecShr	  = Source.MecShr		
			 , Target.AggrLocal	  = Source.AggrLocal	
			 , Target.AggrIpiPer  = Source.AggrIpiPer	
			 , Target.AggrIpiMec  = Source.AggrIpiMec	
		-- For Delete
		 when not matched by Source then
			delete
		;

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