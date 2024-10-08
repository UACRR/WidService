use SocWidSubmit
go

drop table if exists RecGrt
go

CREATE TABLE RecGrt (
	Id int identity(1,1) NOT NULL primary key clustered,
	SubmFileId int not null,
	RecType varchar(3) NULL,
	GrId varchar(5) NULL,
	TransCnt varchar(8) NULL,
	RecCnt varchar(8) NULL
)
GO

ALTER TABLE RecGrt add constraint FK_RecGrt_SubmFileId FOREIGN KEY(SubmFileId)
REFERENCES SubmFile (Id)
go
