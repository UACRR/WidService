use SocWidSubmit
go

drop table if exists RecGrtRsp
go

CREATE TABLE RecGrtRsp (
	Id int identity(1,1) NOT NULL primary key clustered,
	RespFileId int not null,
	RecType varchar(3) NULL,
	GrId varchar(5) NULL,
	TransCnt varchar(8) NULL,
	RecCnt varchar(8) NULL
)
GO

ALTER TABLE RecGrtRsp add constraint FK_RecGrtRsp_RespFileId FOREIGN KEY(RespFileId)
REFERENCES RespFile (Id)
go
