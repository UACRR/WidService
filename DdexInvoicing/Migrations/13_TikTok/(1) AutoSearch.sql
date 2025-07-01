use AutoSearch
go

begin
	drop table if exists WorkNames
	create table WorkNames (
		  WorkNameId int primary key identity (1, 1)
		, Name nvarchar(261)
	)
	create nonclustered index idx_WorkNames_Name on WorkNames(Name)

	insert WorkNames (Name)
	select distinct Title
	from Ddex..IdentMw
	where isnull(ObjId, 0) <> 0 or isnull(Wic, 0) <> 0

	drop table if exists WorkNamesT
	create table WorkNamesT (
		  WorkNameId int primary key identity (1, 1)
		, Name nvarchar(261)
	)
	create nonclustered index idx_WorkNamesT_Name on WorkNamesT(Name)

	insert WorkNamesT (Name)
	select distinct MediaService.dbo.TransLitFromUkrToLat(Title)
	from Ddex..IdentMw
	where isnull(ObjId, 0) <> 0 or isnull(Wic, 0) <> 0

	drop table if exists ReportWorkNamesT
	create table ReportWorkNamesT (
		  WorkId int primary key identity (1, 1)
		, Name nvarchar(261)
	)
	create nonclustered index idx_ReportWorkNamesT_Name on ReportWorkNamesT(Name)

	insert ReportWorkNamesT (Name)
	select distinct MediaService.dbo.TransLitFromUkrToLat(Name)
	from ReportWorks

	drop table if exists WorkNameWorks
	create table WorkNameWorks (
		  WorkNameId int
		, WorkId int
		, ObjId int
		, Wic int
	)
	create nonclustered index idx_WorkNameWorks_WorkNameId on WorkNameWorks(WorkNameId)
	create nonclustered index idx_WorkNameWorks_WorkId on WorkNameWorks(WorkId)

	insert WorkNameWorks (WorkNameId, WorkId, ObjId, Wic)
	select distinct t1.WorkNameId, t2.Id, t2.ObjId, t2.Wic
	from WorkNames t1
		join Ddex..IdentMw t2 on t1.Name = t2.Title
	where isnull(t2.ObjId, 0) <> 0 or isnull(t2.Wic, 0) <> 0

	drop table if exists ReportWorks
	create table ReportWorks (
		  Id int primary key identity (1, 1)
		, WorkId int
		, Name nvarchar(261)
		, Authors nvarchar(2054)
		, Performers nvarchar(2054)
		, FoundName nvarchar(261)
		, FoundAuthors nvarchar(2054)
		, FoundPerformers nvarchar(2054)
		, FoundBy  varchar(16)
		, ObjId int
		, Wic int
	)
	create nonclustered index idx_ReportWorks_Name on ReportWorks(Name)

	drop table if exists PerformerNameParts
	create table PerformerNameParts (
		  Id int primary key identity (1, 1)
		, WorkId int
		, NamePart nvarchar(64)
	)

	drop table if exists AuthorNameParts
	create table AuthorNameParts (
		  Id int primary key identity (1, 1)
		, WorkId int
		, NamePart nvarchar(1000)
	)

	drop table if exists ReportWorksInIdentMwFoundByName
	create table ReportWorksInIdentMwFoundByName (
		  Id int primary key identity (1, 1)
		, WorkId int
		, FoundWorkId int
		, FoundBy  varchar(16)
	)
end

use Ddex
go

-- СКИДАЄМО ЗНАЙДЕНІ ТВОРИ ЗВІТУ У НЕЗНАЙДЕНІ
update t2
set t2.ObjId = null, t2.Wic = null, t2.Status = 0
from IdentBacklog t1
	join IdentMw t2 on t1.mwId = t2.Id
where t1.DdexReportId in (select Id from ft_AgreementReportIds(1496))

-- ЗАПОВНЮЄМО ІНФОРМАЦІЮ ДЛЯ ТВОРІВ ІЗ ЗВІТУ
insert AutoSearch..ReportWorks(WorkId, Name, Authors, Performers)
select t2.Id as WorkId, t2.Title, t2.ComposerAuthor, t2.DisplayArtistName
from IdentBacklog t1
	join IdentMw t2 on t1.mwId = t2.Id
where t1.DdexReportId in (select Id from ft_AgreementReportIds(1496))
	and isnull(t2.objId, 0) = 0
	and isnull(t2.Wic, 0) = 0

-- ЗАПОВНЮЄМО ІНФОРМАЦІЮ ДЛЯ СЛІВ У ВИКОНАВЦІВ
insert AutoSearch..PerformerNameParts(WorkId, NamePart)
select distinct WorkId, value
from AutoSearch..ReportWorks
	cross apply string_split(Performers, ' ')
where len(value) > 2

-- ЗАПОВНЮЄМО ІНФОРМАЦІЮ ДЛЯ СЛІВ У ПРАВОВЛАСНИКІВ
insert AutoSearch..AuthorNameParts(WorkId, NamePart)
select distinct WorkId, value
from AutoSearch..ReportWorks
	cross apply string_split(Authors, ' ')
where len(value) > 2

-- З ТВОРІВ ІЗ IdentMw
--update  AutoSearch..ReportWorks set ObjId = null, Wic = null

-- РЕЗУЛЬТАТ ПОШУКУ ЗА НАЗВОЮ
begin
	insert AutoSearch..ReportWorksInIdentMwFoundByName (WorkId, FoundWorkId, FoundBy)
	select t1.WorkId, t2.Id as FoundWorkId, 'EXACT'
	from AutoSearch..ReportWorks t1
		join IdentMw t2 on t1.Name = t2.Title
			and (
				   isnull(t2.objId, 0) <> 0
				or isnull(t2.Wic, 0) <> 0
			)

	insert AutoSearch..ReportWorksInIdentMwFoundByName (WorkId, FoundWorkId, FoundBy)
	select t1.WorkId, t2.Id as FoundWorkId, 'LIKE'
	from AutoSearch..ReportWorks t1
		join IdentMw t2 on t2.Title like concat(t1.Name, '%')
			and (
				   isnull(t2.objId, 0) <> 0
				or isnull(t2.Wic, 0) <> 0
			)
		left join AutoSearch..ReportWorksInIdentMwFoundByName t3 on t1.WorkId = t3.WorkId
	where t3.WorkId is null

			select top 1000 * from AutoSearch..ReportWorksInIdentMwFoundByName
end

begin
	drop table if exists #FoundWorks
	select t1.WorkId, t2.ObjId, t2.Wic
	into #FoundWorks
	from AutoSearch..ReportWorks t1
		join IdentMw t2 on t1.Name = t2.Title
			and t1.Performers = t2.DisplayArtistName
			and (
				   isnull(t2.objId, 0) <> 0
				or isnull(t2.Wic, 0) <> 0
			)
	where t1.FoundBy is null

	; with Mapped as (
		select distinct WorkId, ObjId, Wic
		from #FoundWorks
	)
	update t1
	set t1.ObjId = t2.ObjId, t1.Wic = t2.Wic, FoundBy = 'IdentMw_N_P'
	from AutoSearch..ReportWorks t1
		join Mapped t2 on t1.WorkId = t2.WorkId
end
go

begin
	drop table if exists #FoundWorks
	select t1.WorkId, t2.ObjId, t2.Wic
	into #FoundWorks
	from AutoSearch..ReportWorks t1
		join IdentMw t2 on t2.Title like concat(t1.Name, '%')
			and t1.Performers = t2.DisplayArtistName
			and (
				   isnull(t2.objId, 0) <> 0
				or isnull(t2.Wic, 0) <> 0
			)
	where t1.FoundBy is null

	; with Mapped as (
		select distinct WorkId, ObjId, Wic
		from #FoundWorks
	)
	update t1
	set t1.ObjId = t2.ObjId, t1.Wic = t2.Wic, FoundBy = 'IdentMw_N(L)_P'
	from AutoSearch..ReportWorks t1
		join Mapped t2 on t1.WorkId = t2.WorkId
end
go

begin
	drop table if exists #FoundWorks
	select t1.WorkId, t3.ObjId, t3.Wic
	into #FoundWorks
	from AutoSearch..ReportWorks t1
		join AutoSearch..PerformerNameParts t2 on t1.WorkId = t2.WorkId
		join IdentMw t3 on
				t1.Name = t3.Title
			and t3.DisplayArtistName like concat('%', t2.NamePart, '%')
			and (
				   isnull(t3.objId, 0) <> 0
				or isnull(t3.Wic, 0) <> 0
			)
	where t1.FoundBy is null

	; with Mapped as (
		select distinct WorkId, ObjId, Wic
		from #FoundWorks
	)
	update t1
	set t1.ObjId = t2.ObjId, t1.Wic = t2.Wic, FoundBy = 'IdentMw_N_P(P)'
	from AutoSearch..ReportWorks t1
		join Mapped t2 on t1.WorkId = t2.WorkId

end

select FoundBy, count(*)
from AutoSearch..ReportWorks 
group by FoundBy
-- З ТВОРІВ ІЗ СМАРТ
begin
	drop table if exists #ReportWorks
	select t2.Id as WorkId, t2.Title, t2.ComposerAuthor, t2.DisplayArtistName
	into #ReportWorks
	from IdentBacklog t1
		join IdentMw t2 on t1.mwId = t2.Id
	where t1.DdexReportId in (select Id from ft_AgreementReportIds(1496))
		and isnull(t2.objId, 0) = 0
		and isnull(t2.Wic, 0) = 0

	drop table if exists #ReportFoundByNameWorks
	select t1.WorkId, t2.ObjId
	into #ReportFoundByNameWorks
	from #ReportWorks t1
		join MediaService..ObjectRight t2 on t2.Name like concat(t1.Title, '%')
	union
	select t1.WorkId, t2.ObjId
	from #ReportWorks t1
		join MediaService..ObjectRight t2 on MediaService.dbo.TransLitFromUkrToLat(t2.Name) like concat(MediaService.dbo.TransLitFromUkrToLat(t1.Title), '%')
	union
	select t1.WorkId, t2.ObjId
	from #ReportWorks t1
		join MediaService..SeekObject t2 on t2.Name like concat(t1.Title, '%')
			and t2.codeI = 1
	union
	select t1.WorkId, t2.ObjId
	from #ReportWorks t1
		join MediaService..SeekObject t2 on MediaService.dbo.TransLitFromUkrToLat(t2.Name) like concat(MediaService.dbo.TransLitFromUkrToLat(t1.Title), '%')

212980
	select *
	from #ReportFoundByNameWorks t1
		right join #ReportFoundByNameWorksTranslit t2 on t1.WorkId = t2.WorkId
	where t1.WorkId is null

	drop table if exists #ReportFoundWorks
	select t1.WorkId, t1.Title, t1.ComposerAuthor, t1.DisplayArtistName, t2.author as FoundComposerAuthor, t2.ObjId
	into #ReportFoundWorks
	from #ReportWorks t1
		join MediaService..ObjectRight t2 on
				t1.Title = t2.Name
			and t2.performer like concat('%', t1.DisplayArtistName, '%')

	update #ReportFoundWorks
	set ObjId = null
	where ObjId = 0

	; with Mapped as (
		select distinct WorkId, ObjId
		from #ReportFoundWorks
	)
	update t1
	set t1.ObjId = t2.ObjId, Status = 2
	from IdentMw t1
		join Mapped t2 on t1.Id = t2.WorkId

end
go

begin
	drop table if exists #FoundWorks
	; with ByName as (
		select t1.*
		from AutoSearch..ReportWorks t1
			join IdentMw t2 on
				t2.Title like (concat(t1.Name , '%'))
			and (
				   isnull(t2.objId, 0) <> 0
				or isnull(t2.Wic, 0) <> 0
			)
		where t1.FoundBy is null
	)

	select t1.WorkId, t3.ObjId, t3.Wic
	into #FoundWorks
	from AutoSearch..ReportWorks t1
		join AutoSearch..PerformerNameParts t2 on t1.WorkId = t2.WorkId
		join IdentMw t3 on
				t3.Title like (concat(t1.Name , '%'))
			and t3.DisplayArtistName like concat('%', t2.NamePart, '%')
			and (
				   isnull(t3.objId, 0) <> 0
				or isnull(t3.Wic, 0) <> 0
			)
	where t1.FoundBy is null

	; with Mapped as (
		select distinct WorkId, ObjId, Wic
		from #FoundWorks
	)
	update t1
	set t1.ObjId = t2.ObjId, t1.Wic = t2.Wic, FoundBy = 'IdentMw_N(L)_P(P)'
	from AutoSearch..ReportWorks t1
		join Mapped t2 on t1.WorkId = t2.WorkId

end

select FoundBy, count(*)
from AutoSearch..ReportWorks 
group by FoundBy
-- З ТВОРІВ ІЗ СМАРТ
begin
	drop table if exists #ReportWorks
	select t2.Id as WorkId, t2.Title, t2.ComposerAuthor, t2.DisplayArtistName
	into #ReportWorks
	from IdentBacklog t1
		join IdentMw t2 on t1.mwId = t2.Id
	where t1.DdexReportId in (select Id from ft_AgreementReportIds(1496))
		and isnull(t2.objId, 0) = 0
		and isnull(t2.Wic, 0) = 0

	drop table if exists #ReportFoundByNameWorks
	select t1.WorkId, t2.ObjId
	into #ReportFoundByNameWorks
	from #ReportWorks t1
		join MediaService..ObjectRight t2 on t2.Name like concat(t1.Title, '%')
	union
	select t1.WorkId, t2.ObjId
	from #ReportWorks t1
		join MediaService..ObjectRight t2 on MediaService.dbo.TransLitFromUkrToLat(t2.Name) like concat(MediaService.dbo.TransLitFromUkrToLat(t1.Title), '%')
	union
	select t1.WorkId, t2.ObjId
	from #ReportWorks t1
		join MediaService..SeekObject t2 on t2.Name like concat(t1.Title, '%')
			and t2.codeI = 1
	union
	select t1.WorkId, t2.ObjId
	from #ReportWorks t1
		join MediaService..SeekObject t2 on MediaService.dbo.TransLitFromUkrToLat(t2.Name) like concat(MediaService.dbo.TransLitFromUkrToLat(t1.Title), '%')

212980
	select *
	from #ReportFoundByNameWorks t1
		right join #ReportFoundByNameWorksTranslit t2 on t1.WorkId = t2.WorkId
	where t1.WorkId is null

	drop table if exists #ReportFoundWorks
	select t1.WorkId, t1.Title, t1.ComposerAuthor, t1.DisplayArtistName, t2.author as FoundComposerAuthor, t2.ObjId
	into #ReportFoundWorks
	from #ReportWorks t1
		join MediaService..ObjectRight t2 on
				t1.Title = t2.Name
			and t2.performer like concat('%', t1.DisplayArtistName, '%')

	update #ReportFoundWorks
	set ObjId = null
	where ObjId = 0

	; with Mapped as (
		select distinct WorkId, ObjId
		from #ReportFoundWorks
	)
	update t1
	set t1.ObjId = t2.ObjId, Status = 2
	from IdentMw t1
		join Mapped t2 on t1.Id = t2.WorkId

end
go

-- З ТВОРІВ ІЗ СМАРТ - ADVANCED
begin
	drop table if exists #ReportWorks
	select t2.Id as WorkId, t2.Title, t2.ComposerAuthor, t2.DisplayArtistName
	into #ReportWorks
	from IdentBacklog t1
		join IdentMw t2 on t1.mwId = t2.Id
	where t1.DdexReportId in (select Id from ft_AgreementReportIds(1496))
		and isnull(t2.objId, 0) = 0
		and isnull(t2.Wic, 0) = 0

	drop table if exists #ReportWorksPerfParts
	select distinct WorkId, value as PerfPart
	into #ReportWorksPerfParts
	from #ReportWorks
		cross apply string_split(DisplayArtistName, ' ')

	delete from #ReportWorksPerfParts where len(PerfPart) < 3

	select * from #ReportWorksPerfParts order by WorkId

	drop table if exists #ReportFoundWorks
	select t1.WorkId, t1.Title, t1.ComposerAuthor, t1.DisplayArtistName, t3.author as FoundComposerAuthor, t3.ObjId
	into #ReportFoundWorks
	from #ReportWorks t1
		join #ReportWorksPerfParts t2 on t1.WorkId = t2.WorkId
		join MediaService..ObjectRight t3 on
				t1.Title = t3.Name
			and t3.performer like concat('%', t2.PerfPart, '%')

	select distinct * from #ReportFoundWorks order by WorkId
	select distinct WorkId, ObjId from #ReportFoundWorks order by WorkId

	update #ReportFoundWorks
	set ObjId = null
	where ObjId = 0

	; with Mapped as (
		select distinct WorkId, ObjId
		from #ReportFoundWorks
	)
	update t1
	set t1.ObjId = t2.ObjId, Status = 2
	from IdentMw t1
		join Mapped t2 on t1.Id = t2.WorkId

end
go

-- Analysis
select sum(NetRevenue)
from IdentBacklog t1
	join IdentMw t2 on t1.mwId = t2.Id
		and (
			   isnull(t2.objId, 0) <> 0
			or isnull(t2.Wic, 0) <> 0
		)
--where t1.DdexReportId = 1496
where t1.DdexReportId in (select Id from ft_AgreementReportIds(1496))

42975.259977
8980.103157
900
450
450
338.432489
go
