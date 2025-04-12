use [RadioStationReports]
go

create or alter procedure spInsertReportLine
	@ReportId				int,
	@LineNr					int,
	@Name					nvarchar(max),
	@Performer				nvarchar(max),
	@MusicAuthor			nvarchar(max),
	@TextAuthor				nvarchar(max),
	@Duration				nvarchar(max),
	@CountUses				nvarchar(max),
	@TotalDuration			nvarchar(max)
as
begin
	if exists (select null from ReportLines where ReportId = @ReportId and LineNr = @LineNr)
		return

	--declare @Authors nvarchar(max) = concat(@MusicAuthor, '&', @TextAuthor)
	--if trim(@Authors) = '&'
	--begin
	--	set @Authors = ''
	--end
	declare @Authors nvarchar(max) = ''
	declare @WorkId int = (
		select Id 
		from Works 
		where 
				Name		= @Name 
			and Authors		= @Authors
			and Performers	= @Performer
	)
	if @WorkId is null
	begin
		insert Works (
			  Name
			, Authors
			, Performers
		)
		values (
			  @Name
			, @Authors
			, @Performer
		)
		set @WorkId = scope_identity()
	end

	insert ReportLines (
		  ReportId	
		, LineNr		
		, Name		
		, Performer	
		, MusicAuthor
		, TextAuthor	
		, Duration	
		, CountUses	
		, TotalDuration
		, WorkId
	) 
	values (
		  @ReportId	
		, @LineNr		
		, @Name		
		, @Performer	
		, @MusicAuthor
		, @TextAuthor	
		, @Duration	
		, @CountUses	
		, @TotalDuration
		, @WorkId
	)
end
go