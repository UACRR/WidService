use SocWidSubmit
go

drop table if exists RecOsr
go

create table RecOsr (
	Id int identity(1,1) not null primary key clustered,
	SubmFileId int not null,
	RecType varchar(3) null,
	TransSeqNr varchar(8) null,
	RecSeqNr varchar(8) null,
	Filler3 varchar(9) null,
	RightType varchar(3) null,
	Shares varchar(5) null,
	IpNameNr varchar(11) null,
	Aff varchar(3) null
)
go

ALTER TABLE dbo.RecOsr add constraint FK_RecOsr_SubmFileId FOREIGN KEY(SubmFileId)
REFERENCES dbo.SubmFile (Id)
go


