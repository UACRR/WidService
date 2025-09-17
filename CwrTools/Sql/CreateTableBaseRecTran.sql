use CWR
go

drop table if exists BaseRecTran
create table BaseRecTran (
	  BaseRecTranId int primary key
	, CwrFileId int null
	, RecGrhId int null
	, RecordType char(3)
	, TranSeqNr int
)

alter table BaseRecTran add constraint fk_BaseRecTran_RecGrhId foreign key (RecGrhId) references RecGrh(RecGrhId)

