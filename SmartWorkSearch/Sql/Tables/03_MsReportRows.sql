use SmartWorkSearch
go

--drop table SourceWorks

create table ReportRows (
	  ReportId int not null
	, RowId int not null
	, SourceId int not null -- 0 - MS, 1 -  DDEX
	, Rate int not null
	, SourceWorkId int null
	, CreatedAt datetime not null
	, primary key (ReportId, RowId, SourceId)
)

alter table ReportRows
add constraint fk_ReportRows_SourceWorkId
foreign key (SourceWorkId) references SourceWorks(Id);

