use SocWidSubmit
go

drop table if exists RecTrl
go

CREATE TABLE RecTrl (
	Id int identity(1,1) NOT NULL primary key clustered,
	SubmFileId int not null,
	RecType varchar(3) NULL,
	GrCnt varchar(5) NULL,
	TransCnt varchar(8) NULL,
	RecCnt varchar(8) NULL
)
GO

ALTER TABLE RecTrl add constraint FK_RecTrl_SubmFileId FOREIGN KEY(SubmFileId)
REFERENCES SubmFile (Id)
go
