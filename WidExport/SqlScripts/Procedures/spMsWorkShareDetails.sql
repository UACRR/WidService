use SocWidSubmit
go

create or alter procedure spMsWorkShareDetails
		@widSubmGroupId int
	  , @cRightId int
	  , @ipNameNr int
as
begin
	--declare @cRightId int = 23
	--declare @ipNameNr int = 3314321

	declare 
		  @custId	int
		, @objId	int
		, @ratePer	decimal(5, 2)
		, @rateMec	decimal(5, 2)
	
	select
		  @custId	= custId
		, @objId	= objId	
		, @ratePer	= rate
		, @rateMec	= rateMech
	from MediaService..CopyRight
	where cRightId = @cRightId

	-- Назва правовласника в локальній базі
	declare @custDisplayName varchar(100)

	select 
		@custDisplayName = trim(concat(lastName, ' ', firstName, ' ', surName))
	from MediaService..AnketaPerson
	where custId = @custId

	if @custDisplayName is null
	begin
		select 
			@custDisplayName = trim(shortName)
		from MediaService..AnketaCompany
		where custId = @custId
	end

	if @custDisplayName is null
	begin
		select 
			@custDisplayName = trim(authorName)
		from MediaService..Authors
		where custId = @custId
	end

	-- Назва правовласника в IPI
	declare @ipNameNrDisplayName varchar(100)

	select 
		@ipNameNrDisplayName = trim(concat(Name, ' ', fstName))
	from SocIpi..IpiName
	where IpNameNr = @ipNameNr

	-- Договори
	declare 
		  @AggrLocal bit
		, @AggrIpiPer bit
		, @AggrIpiMec bit
		, @AggrInvert bit
	
	select
		  @AggrLocal  = AggrLocal
		, @AggrIpiPer = AggrIpiPer
		, @AggrIpiMec = AggrIpiMec
		, @AggrInvert = AggrInvert
	from WidSubmGroupWorkShare
	where WidSubmGroupId = @WidSubmGroupId
		and CopyRightId = @cRightId

	-- Результат
	select
		  @custId				as custId
		, @objId				as objId	
		, @ratePer				as rate
		, @rateMec				as rateMech
		, @custDisplayName		as custDisplayName
		, @ipNameNrDisplayName	as ipNameNrDisplayName
		, @AggrLocal			as aggrLocal	
		, @AggrIpiPer			as aggrIpiPer
		, @AggrIpiMec			as aggrIpiMec
		, @AggrInvert			as aggrInvert
	
	-- Договри IPI
	

end
go

-- exec spIpiPartySelect 'KHARCHYSH'
