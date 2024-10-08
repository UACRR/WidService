use SocWidSubmit
go

drop table if exists RecPer
go

create table RecPer (
	Id int identity(1,1) not null primary key clustered,
	SubmFileId int not null,
	RecType varchar(3) null,
	TransSeqNr varchar(8) null,
	RecSeqNr varchar(8) null,
	PerfArtistLstName varchar(45) null,
	PerfArtistFstName varchar(30) null,
	Filler4 varchar(9) null,
	PerfArtistIpNameNr varchar(11) null
)
go

ALTER TABLE dbo.RecPer add constraint FK_RecPer_SubmFileId FOREIGN KEY(SubmFileId)
REFERENCES dbo.SubmFile (Id)
go


