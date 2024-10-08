use RadioStationReports
go


create table Configuration (
	  Id int primary key clustered
	, TemplateFileFullName nvarchar(1000) not null
	, DecimalSep char(1) null
)
go


