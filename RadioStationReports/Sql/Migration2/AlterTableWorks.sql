use RadioStationReports
go

begin try
	begin tran
	drop table if exists WorksNew

	create table WorksNew (
		  Id			int primary key clustered identity (1, 1)
		, Name			nvarchar(1000) 
		, Authors		nvarchar(1000) 
		, Performers	nvarchar(1000) 
		, NameT			nvarchar(1000) 
		, AuthorsT		nvarchar(1000) 
		, PerformersT	nvarchar(1000) 
		, FoundIn		char(1) 
		, ObjId			int 
		, Wic			int 
		, Iswc			varchar(13) 
		, Share			decimal(5, 2) 
		, IsProcessed	bit 
	)

	set identity_insert WorksNew on
	insert WorksNew (
		  Id			
		, Name			
		, Authors		
		, Performers	
		, NameT			
		, AuthorsT		
		, PerformersT	
		, FoundIn		
		, ObjId			
		, Wic			
		, Iswc			
		, Share			
		, IsProcessed	
	)
	select
		  Id						as Id			
		, Name						as Name			
		, Authors					as Authors		
		, Performers				as Performers	
		, NameT						as NameT			
		, AuthorsT					as AuthorsT		
		, PerformersT				as PerformersT	
		, FoundIn					as FoundIn		
		, case 
			when FoundIn = 'M' 
			then FoundCde 
			else null 
		  end						as ObjId			
		, case 
			when FoundIn = 'W' 
			then FoundCde 
			else null 
		  end						as Wic			
		, Iswc						as Iswc			
		, Share						as Share			
		, IsProcessed				as IsProcessed	
	from Works
	set identity_insert WorksNew off
	
	while 0 = 0
	begin
		declare @cntAffected int = 0

		-- Find WIC from SMART
		update t1
		set t1.Wic = t2.Wic
		from WorksNew t1
			join MediaService..RepMSWIC t2 on t1.ObjId = t2.ObjId
		where t1.ObjId is not null
			and t1.Wic is null
		set @cntAffected = @cntAffected + @@rowcount

		-- Find WIC from WID
		update t1
		set t1.Wic = t2.Wic
		from WorksNew t1
			join SocWid..WidSubmission t2 on concat('MS', t1.ObjId) = t2.SocWorkCde
				and t2.SocCde = 140
		where t1.ObjId is not null
			and t1.Wic is null
		set @cntAffected = @cntAffected + @@rowcount

		-- Find ObjId from WIC
		update t1
		set t1.ObjId = t2.ObjId
		from WorksNew t1
			join MediaService..RepMSWIC t2 on t1.Wic = t2.Wic
		where t1.ObjId is null
			and t1.Wic is not null
		set @cntAffected = @cntAffected + @@rowcount

		-- Find ISWC from SMART
		update t1
		set t1.Iswc = replace(replace(t2.Iswc, '-', ''), '.', '')
		from WorksNew t1
			join MediaService..MediaTrack t2 on t1.ObjId = t2.ObjId
				and trim(isnull(t2.Iswc, '')) <> ''
		where t1.Iswc is null
			and t1.ObjId is not null
		set @cntAffected = @cntAffected + @@rowcount

		-- Find ISWC from WID
		update t1
		set t1.Iswc = t2.PrefIswc
		from WorksNew t1
			join SocWid..WidIswc t2 on t1.Wic = t2.Wic
		where t1.Iswc is null
			and t1.Wic is not null
		set @cntAffected = @cntAffected + @@rowcount

		-- Find ObjId from ISWC
		update t1
		set t1.ObjId = t2.ObjId
		from WorksNew t1
			join MediaService..MediaTrack t2 on t1.Iswc = replace(replace(t2.Iswc, '-', ''), '.', '')
		where t1.ObjId is null
			and t1.Iswc is not null
		set @cntAffected = @cntAffected + @@rowcount

		-- Find Wic from ISWC
		update t1
		set t1.Wic = t2.Wic
		from WorksNew t1
			join SocWid..WidIswc t2 on t1.Iswc = t2.Iswc
		where t1.Wic is null
			and t1.Iswc is not null
		set @cntAffected = @cntAffected + @@rowcount

		if @cntAffected = 0
			break
	end

	alter table ReportLines drop constraint fk_ReportLines_Work
	alter table MatchingWorks drop constraint FK_MatchingWorks_Work
	drop table Works

	exec sp_rename 'WorksNew', 'Works'

	alter table ReportLines add constraint fk_ReportLines_Work
		foreign key(WorkId)
		references Works(Id)
	alter table MatchingWorks add constraint FK_MatchingWorks_Work
		foreign key(WorkId)
		references Works(Id)

	print 'Committed'
	commit tran
end try
begin catch
	print 'RolledBack'
	rollback tran
end catch
