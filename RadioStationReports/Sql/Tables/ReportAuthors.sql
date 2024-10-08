use RadioStationReports
go

-- drop table ReportAuthors

create table ReportAuthors (
	  Id			int				not null identity(1, 1) primary key clustered 
	, ReportId		int				null
	, FoundIn		char(1)			null
	, FoundCde		int				null
	, IpBaseNr		varchar(13)		null
	, CustId		int				null
	, IpNameNr		int				null
	, PerShr		decimal(5, 2)	null
	, MecShr		decimal(5, 2)	null
	, PerSocShr		decimal(5, 2)	null
	, MecSocShr		decimal(5, 2)	null
	, PerSoc		int				null
	, MecSoc		int				null
)
go

alter table ReportAuthors add constraint fk_ReportAuthors_Report foreign key(ReportId)
references Reports(Id)
go

