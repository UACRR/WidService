use SocWidSubmit
go

drop table if exists RecTrlRsp
go

CREATE TABLE RecTrlRsp (
	Id int identity(1,1) NOT NULL primary key clustered,
	RespFileId int not null,
	RecType varchar(3) NULL,
	GrCnt varchar(5) NULL,
	TransCnt varchar(8) NULL,
	RecCnt varchar(8) NULL
)
GO

ALTER TABLE RecTrlRsp add constraint FK_RecTrlRsp_RespFileId FOREIGN KEY(RespFileId)
REFERENCES RespFile (Id)
go
