use SocWidSubmit
go

drop table if exists RecGrh
go

CREATE TABLE RecGrh(
	Id int identity(1,1) NOT NULL primary key clustered,
	SubmFileId int not null,
	RecType varchar(3) NULL,
	TransType varchar(3) NULL,
	GrId varchar(5) NULL,
	VerNr varchar(5) NULL
)
GO

ALTER TABLE RecGrh add constraint FK_RecGrh_SubmFileId FOREIGN KEY(SubmFileId)
REFERENCES SubmFile (Id)
go
