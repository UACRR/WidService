use [RadioStationReports]
go

create or alter procedure spImportReportLine
	  @ReportId	int
	, @LineNr	int
	, @ObjId	int
	, @Wic		int
	, @Iswc		varchar(13)
as
begin
	declare @FoundIn varchar(1) = (
		case 
			when @ObjId > 0 then 'M'
			else case when @Wic > 0 then 'W' else null end
		end
	)

	declare @FoundCde int = (
		case 
			when @ObjId > 0 then @ObjId
			else case when @Wic > 0 then @Wic else null end
		end
	)

	declare @FoundIswc varchar(13) = (
		case 
			when @Iswc <> '' then @Iswc
			else null
		end
	)

	declare @FoundWic int

	if @FoundCde is null and @FoundIswc is not null
	begin
		set @FoundWic = (select min(Wic) from SocWid..WidIswc where PrefIswc = @FoundIswc)
		if @FoundWic is not null
		begin
			set @FoundIn = 'W'
			set @FoundCde = @FoundWic
		end
	end

	-- Якщо знайдено в Смарті, але відповідний обєкт існує в ВІД, замінюємо на ВІД
	if @FoundIn = 'M'
	begin
		set @FoundWic = (select wic from MediaService.. RepMSWIC where objId = @FoundCde)
		if @FoundWic is not null
		begin
			set @FoundIn = 'W'
			set @FoundCde = @FoundWic
		end
	end

	update t2
	set 
		  t2.FoundIn = @FoundIn
		, t2.FoundCde = @FoundCde
		, t2.Iswc = @FoundIswc
	from ReportLines t1
		join Works t2 on t1.WorkId = t2.Id
	where t1.ReportId = @ReportId
		and t1.LineNr = @LineNr
end
go

-- exec spImportReportLine ???