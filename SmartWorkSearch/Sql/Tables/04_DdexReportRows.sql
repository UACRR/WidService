use SmartWorkSearch
go

--drop table ReportRows

create table DdexReportRows (
	  DdexReportId int not null
	, BlockId int not null
	, SalesTransactionId varchar(100) not null
	, Rate int not null
	, SourceWorkId int null
	, CreatedAt datetime not null
	, primary key (DdexReportId, BlockId, SalesTransactionId)
)

alter table DdexReportRows
add constraint fk_DdexReportRows_SourceWorkId
foreign key (SourceWorkId) references SourceWorks(Id);

