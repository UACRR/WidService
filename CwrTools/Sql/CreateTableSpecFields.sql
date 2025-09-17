use CWR
go

drop table if exists SpecFields
create table SpecFields (
	  Id int primary key identity(1, 1)
	, RecordType char(3)
	, Field varchar(64)
	, Start  int
	, Size int
	, Fmt char(1)
	, Req char(1)
	, Description varchar(max)
	, ColName varchar(64)
)

alter table SpecFields add constraint fk_SpecFields_SpecRecords_RecordType foreign key (RecordType) references SpecRecords(RecordType)
alter table SpecFields add constraint fk_SpecFields_SpecFormats_Code foreign key (Fmt) references SpecFormats(Code)
alter table SpecFields add constraint fk_SpecFields_SpecReqs_Code foreign key (Req) references SpecReqs(Code)