use SocWidSubmit
go

drop table if exists RecAlt
go

create table RecAlt (
	Id int identity(1,1) not null primary key clustered,
	SubmFileId int not null,
	RecType varchar(3) null,
	TransSeqNr varchar(8) null,
	RecSeqNr varchar(8) null,
	AltTtl varchar(60) null,
	TtlType varchar(3) null,
	LngCode varchar(2) null
)
GO

ALTER TABLE RecAlt add constraint FK_RecRecAlt_SubmFileId FOREIGN KEY(SubmFileId)
REFERENCES SubmFile (Id)
go


