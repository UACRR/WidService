use SocWidSubmit
go

drop table if exists RecSip
go

CREATE TABLE RecSip (
	Id int identity(1,1) not null primary key clustered,
	SubmFileId int not null,
	RecType varchar(3) null,
	TransSeqNr varchar(8) null,
	RecSeqNr varchar(8) null,
	Filler5 varchar(9) null,
	IpNr varchar(9) null,
	IpName varchar(45) null,
	IpFstName varchar(30) null,
	IpRole varchar(2) null,
	IpNameNr varchar(11) null
)
go

ALTER TABLE dbo.RecSip add constraint FK_RecSip_SubmFileId FOREIGN KEY(SubmFileId)
REFERENCES dbo.SubmFile (Id)
go


