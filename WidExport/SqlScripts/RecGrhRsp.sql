use SocWidSubmit
go

drop table if exists RecGrhRsp
go

CREATE TABLE RecGrhRsp(
	Id int identity(1,1) NOT NULL primary key clustered,
	RespFileId int not null,
	RecType varchar(3) NULL,
	TransType varchar(3) NULL,
	GrId varchar(5) NULL,
	VerNr varchar(5) NULL
)
GO

ALTER TABLE RecGrhRsp add constraint FK_RecGrhRsp_RespFileId FOREIGN KEY(RespFileId)
REFERENCES RespFile (Id)
go
