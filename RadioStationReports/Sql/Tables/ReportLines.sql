use RadioStationReports
go

-- drop table ReportLines

create table ReportLines (
	  Id			int				not null identity(1, 1) primary key clustered 
	, ReportId		int				null
	, LineNr		int				null
	, Name			nvarchar(255)	null
	, Performer		nvarchar(255)	null
	, MusicAuthor	nvarchar(255)	null
	, TextAuthor	nvarchar(255)	null
	, Duration		varchar	(20)	null
	, CountUses		varchar	(10)	null
	, TotalDuration	varchar	(20)	null
	, WorkId		int				null
)
go

alter table ReportLines add constraint fk_ReportLines_Report foreign key(ReportId)
references Reports(Id)
go

alter table ReportLines add  constraint fk_ReportLines_Work foreign key(WorkId)
references Works(Id)
go

