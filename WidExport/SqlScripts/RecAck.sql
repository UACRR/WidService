use SocWidSubmit
go

drop table if exists RecAck
go

create table RecAck (
	Id int identity(1,1) not null primary key clustered,
	RespFileId int not null,
	RecType varchar(3) null,
	TransSeqNr varchar(8) null,
	RecSeqNr varchar(8) null,
	CreDRef       varchar(8),
	CreTRef       varchar(6),
	GrpSeqNrRef   varchar(5),
	TransSeqNrRef varchar(8),
	TransTypeRef  varchar(3),
	WrkTtlRef     varchar(60),
	SubmWrkNrRef  varchar(20),
	Iswc          varchar(20),
	PrcsD         varchar(8),
	Status        varchar(2)
)
GO

ALTER TABLE RecAck add constraint FK_RecAck_RespFileId FOREIGN KEY(RespFileId)
REFERENCES RespFile (Id)
go


