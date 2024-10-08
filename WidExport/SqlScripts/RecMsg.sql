use SocWidSubmit
go

drop table if exists RecMsg
go

create table RecMsg (
	Id int identity(1,1) not null primary key clustered,
	RespFileId int not null,
	RecType varchar(3) null,
	TransSeqNr varchar(8) null,
	RecSeqNr varchar(8) null,
	MsgType     varchar(1),
	RecSeqNrRef varchar(8),
	RecTypeRef  varchar(3),
	MsgLevel    varchar(1),
	ErrCondNr   varchar(3),
	MsgTxt      varchar(150)
)
GO

ALTER TABLE RecMsg add constraint FK_RecMsg_RespFileId FOREIGN KEY(RespFileId)
REFERENCES RespFile (Id)
go


