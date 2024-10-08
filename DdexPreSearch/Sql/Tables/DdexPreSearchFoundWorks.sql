use Ddex_Mw_Search
go

--drop table DdexPreSearchFoundWorks
create table DdexPreSearchFoundWorks 
(
	  Id int primary key identity(1, 1)
	, DdexPreSearchReportWorkId int
	, Name nvarchar(1000) null
	, Authors nvarchar(1000) null
	, Performers nvarchar(1000) null
	, SourceCol varchar(2) not null
	, TargetDb varchar(3) not null
	, TargetTbl varchar(4) not null
	, FoundId int not null
)
go