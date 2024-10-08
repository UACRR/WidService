use Ddex_Mw_Search
go

--drop table DdexPreSearchReportWorks
create table DdexPreSearchReportWorks 
(
	  Id int primary key identity(1, 1)
	, DdexReportId int not null
	, BlockSeqNr int not null
	, MwId int not null
	, Album nvarchar(1000) null
	, Name nvarchar(1000) null
	, Authors nvarchar(1000) null
	, Performers nvarchar(1000) null
	, AlbumT nvarchar(1000) null
	, NameT nvarchar(1000) null
	, AuthorsT nvarchar(1000) null
	, PerformersT nvarchar(1000) null
	, Status int null
)
go