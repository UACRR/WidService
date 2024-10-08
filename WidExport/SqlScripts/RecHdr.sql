use SocWidSubmit
go

drop table if exists RecHdr
go

create table RecHdr (
	Id int identity(1,1) NOT NULL primary key clustered,
	SubmFileId int not null,
	RecType varchar(3) NULL,
	SenderType varchar(2) NULL,
	SenderId varchar(9) NULL,
	SenderName varchar(45) NULL,
	StdVerNr varchar(5) NULL,
	CreD varchar(8) NULL,
	CreT varchar(6) NULL,
	TransmitD varchar(8) NULL,
	Filler varchar(15) NULL,
	FileNameRef varchar(29) NULL
)
go

ALTER TABLE dbo.RecHdr add constraint FK_RecHdr_SubmFileId FOREIGN KEY(SubmFileId)
REFERENCES dbo.SubmFile (Id)
go



