use SocWidSubmit
go

drop table if exists RecWiu
go

create table RecWiu (
	Id int identity(1,1) not null primary key clustered,
	SubmFileId int not null,
	RecType varchar(3) null,
	TransSeqNr varchar(8) null,
	RecSeqNr varchar(8) null,
	WrkTtl varchar(60) null,
	LngCode varchar(2) null,
	SubmWrkNr varchar(14) null,
	Iswc varchar(11) null,
	CprDate varchar(8) null,
	CprNr varchar(12) null,
	MwDistrCat varchar(3) null,
	Dur varchar(6) null,
	RecInd varchar(1) null,
	TxtMusicRel varchar(3) null,
	CmpType varchar(3) null,
	VerType varchar(3) null,
	ExcType varchar(3) null,
	MusicArr varchar(3) null,
	LyrAdapt varchar(3) null,
	WicCode varchar(10) null,
	UpdDate varchar(8) null,
	FstSendDateToCis varchar(8) null,
	LstSendDateToCis varchar(8) null,
	SocWrkType varchar(3) null
)
GO

ALTER TABLE dbo.RecWiu add constraint FK_RecWiu_SubmFileId FOREIGN KEY(SubmFileId)
REFERENCES dbo.SubmFile (Id)
go



