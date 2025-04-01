use RadioStationReports
go

create or alter procedure spApplyFoundWork
	  @reportId int
	, @lineNr int
	, @objId int out
	, @wic int out
	, @iswc varchar(25) out
	, @nameInReport nvarchar(200)
	, @performerInReport nvarchar(200)
as
begin

set nocount on

/*
	
*/
declare @workId int = (select WorkId from ReportLines where ReportId = @reportId and LineNr = @lineNr)
-- 
-- ьсйю╙лн йндх б гюкефмняр╡ б╡д оепедюмнцн йндс
-- лнфсрэ оепедюбюрхяэ дей╡кэйю йнд╡б, ьсйю╙лн гю оп╡нпхрюрюлх ялюпр, йнд б╡д, йнд ISWC
-- гЮ ЙНДНЛ ялюпр
if @objId is not null
begin
	set @wic = (select Wic from MediaService..RepMSWIC where ObjId = @objId)
	set @iswc = (select Iswc from MediaService..MediaTrack where ObjId = @objId)
	if @wic is null set @wic = (select max(Wic) from SocWid..widSubmission where SocCde = 140 and SocWorkCde = concat('MS', @objId))
	if @wic is null and @iswc is not null 
		set @wic = (select max(Wic) from SocWid..WidIswc where PrefIswc = @Iswc)
	if @wic is not null and @iswc is null 
		set @iswc = (select max(PrefIswc) from SocWid..WidIswc where Wic = @wic)
end
-- гЮ ЙНДНЛ б╡д
else if @wic is not null
begin
	set @objId = (select ObjId from MediaService..RepMSWIC where Wic = @wic)
	set @iswc = (select max(PrefIswc) from SocWid..WidIswc where Wic = @wic)
	if @objId is null and @iswc is not null 
		set @objId = (select ObjId from MediaService..MediaTrack where Iswc = @iswc)
end
-- гЮ ЙНДНЛ Iswc
else if @iswc is not null
begin
	set @objId = (select ObjId from  MediaService..MediaTrack where Iswc = @iswc)
	set @wic = (select max(PrefIswc) from SocWid..WidIswc where Wic = @wic)
	if @objId is not null
	begin
		set @wic = (select Wic from MediaService..RepMSWIC where ObjId = @objId)
		if @wic is null set @wic = (select max(Wic) from SocWid..widSubmission where SocCde = 140 and SocWorkCde = concat('MS', @objId))
		if @wic is null
			set @wic = (select max(Wic) from SocWid..WidIswc where PrefIswc = @Iswc)
	end
	else if @wic is not null
	begin
		set @objId = (select ObjId from MediaService..RepMSWIC where Wic = @wic)
		if @objId is null
			set @objId = (select ObjId from MediaService..MediaTrack where Iswc = @iswc)
		end
end

-- ╡лонпрс╙лн рб╡п г б╡д
if @objId is null and @wic is not null
	exec MediaService..spImportWorkFromWid @wic, 1, @objId out

-- ъйын рб╡п б ялюпр ╡ямс╙ (лнфе ярюрхяэ ын гю йнднл ISWC ДНДЮРХ-ЯРБНПХРХ МЕ БДЮКНЯЭ)
-- дндю╙лн дн мэнцн юкэрепмюр╡бм╡ мюгбх рбнпс ╡ бхйнмюбж╡б
if @objId is not null
begin
	; with NewAltNames as (
		select 1 as CodeI, @nameInReport as Name
		union
		select 1, MediaService.dbo.TransLitFromUkrToLat(@nameInReport)
		union
		select 2, @performerInReport
		union
		select 2, MediaService.dbo.TransLitFromUkrToLat(@performerInReport)
	)
	insert MediaService..SeekObject (CodeI, ObjId, t1.Name, CreateDate)
	select t1.CodeI, @objId, t1.Name, getdate()
	from NewAltNames t1
		left join MediaService..SeekObject t2 on t1.CodeI = t2.CodeI
			and t1.Name = t2.Name
			and t2.ObjId = @objId
	where t2.CodeI is null
end

-- гюмняхлн йндх б рюакхжч рбнп╡б
update Works
set FoundIn = 'M', FoundCde = @objId, Iswc = @iswc
where Id = @workId

-- пнгпюунбс╙лн юбрнпяэй╡ опнжемрх
exec spCreateReportAuthorsMs @reportId, @workId

print concat(@objId, ', ', @wic, ', ', @iswc)
end
go

/*
declare
	  @reportId int = 2135
	, @lineNr int = 3059
	, @objId int = null
	, @wic int = 17206351
	, @iswc varchar(25) = null
	, @nameInReport nvarchar(200) = 'дЕ рЮ кЧАНБ'
	, @performerInReport nvarchar(200) = 'дПСЦЮ пЁЙЮ'
begin try
	begin tran
	exec spApplyFoundWork
		  @reportId
		, @lineNr
		, @objId out
		, @wic out
		, @iswc out
		, @nameInReport
		, @performerInReport

	select @objId, @wic, @iswc

	select * from ReportAuthors where ReportId = @reportId and FoundIn = 'M' and FoundCde = @objId
	rollback tran
end try
begin catch
	rollback tran
end catch



*/
-- 890736, 42884702, T3298652338
-- 890736, 42884702, T3298652338
-- 890736, 42884702, T3298652338
