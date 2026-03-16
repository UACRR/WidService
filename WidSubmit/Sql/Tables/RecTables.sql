use SocWidSubmitEx
go

drop table if exists MsgMapRecWiaWiu
drop table if exists MsgMapRecSipOip
drop table if exists MsgMapRecSsrOsr
drop table if exists MsgMapRecAlt
drop table if exists MsgMapRecPer

drop table if exists RecAck
drop table if exists RecMsg
drop table if exists RecMsgType
drop table if exists RecTrl
drop table if exists RecGrt
drop table if exists RecPer
drop table if exists RecAlt
drop table if exists RecSsrOsr
drop table if exists RecSipOip
drop table if exists RecWiaWiu
drop table if exists RecGrh
drop table if exists RecHdr

drop table if exists Z_RecAck
drop table if exists Z_RecMsg

-- SUBM FILE RECORDS
create table RecHdr(
	Id int identity(1,1) not null primary key clustered,
	SubmissionId int not null,
	RecType varchar(3) null,
	SenderType varchar(2) null,
	SenderId varchar(9) null,
	SenderName varchar(45) null,
	StdVerNr varchar(5) null,
	CreD varchar(8) null,
	CreT varchar(6) null,
	TransmitD varchar(8) null,
	Filler varchar(15) null,
	FileNameRef varchar(29) null
)
alter table RecHdr add constraint FK_RecHdr_SubmissionId foreign key(SubmissionId) references Submission (Id)
go

create table RecGrh(
	Id int identity(1,1) not null primary key clustered,
	RecHdrId int not null,
	RecType varchar(3) null,
	TransType varchar(3) null,
	GrId varchar(5) null,
	VerNr varchar(5) null
)
alter table RecGrh add constraint FK_RecGrh_RecHdrId foreign key(RecHdrId) references RecHdr (Id)
go

create table RecWiaWiu(
	Id int identity(1,1) not null primary key clustered,
	RecGrhId int not null,
	SubmWorkId int not null,
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
	SocWrkType varchar(3) null,
)
alter table RecWiaWiu add constraint FK_RecWiaWiu_RecGrhId foreign key(RecGrhId) references RecGrh (Id)
alter table RecWiaWiu add constraint FK_RecWiaWiu_SubmWorkId foreign key(SubmWorkId) references SubmWork (Id)
go

create table RecSipOip(
	Id int identity(1,1) not null primary key clustered,
	RecWiaWiuId int not null,
	SubmWorkShareId int not null,
	RecType varchar(3) null,
	TransSeqNr varchar(8) null,
	RecSeqNr varchar(8) null,
	Filler5 varchar(9) null,
	IpNr varchar(9) null,
	IpName varchar(45) null,
	IpFstName varchar(30) null,
	IpRole varchar(2) null,
	IpNameNr varchar(11) null,
)
alter table RecSipOip add constraint FK_RecSipOip_RecWiaWiuId foreign key(RecWiaWiuId) references RecWiaWiu (Id)
alter table RecSipOip add constraint FK_RecSipOip_SubmWorkShareId foreign key(SubmWorkShareId) references SubmWorkShare (Id)
go

create table RecSsrOsr(
	Id int identity(1,1) not null primary key clustered,
	RecSipOipId int not null,
	RecType varchar(3) null,
	TransSeqNr varchar(8) null,
	RecSeqNr varchar(8) null,
	Filler3 varchar(9) null,
	RightType varchar(3) null,
	Shares varchar(5) null,
	IpNameNr varchar(11) null,
	Aff varchar(3) null,
)
alter table RecSsrOsr add constraint FK_RecSsrOsr_RecSipOipId foreign key(RecSipOipId) references RecSipOip (Id)
go

create table RecAlt(
	Id int identity(1,1) not null primary key clustered,
	RecWiaWiuId int not null,
	SubmWorkAltNameId int not null,
	RecType varchar(3) null,
	TransSeqNr varchar(8) null,
	RecSeqNr varchar(8) null,
	AltTtl varchar(60) null,
	TtlType varchar(3) null,
	LngCode varchar(2) null
)
alter table RecAlt add constraint FK_RecAlt_RecWiaWiuId foreign key(RecWiaWiuId) references RecWiaWiu (Id)
alter table RecAlt add constraint FK_RecAlt_SubmWorkAltNameId foreign key(SubmWorkAltNameId) references SubmWorkAltName (Id)
go

create table RecPer(
	Id int identity(1,1) not null primary key clustered,
	RecWiaWiuId int not null,
	SubmWorkPerformerId int not null,
	RecType varchar(3) null,
	TransSeqNr varchar(8) null,
	RecSeqNr varchar(8) null,
	PerfArtistLstName varchar(45) null,
	PerfArtistFstName varchar(30) null,
	Filler4 varchar(9) null,
	PerfArtistIpNameNr varchar(11) null,
)
alter table RecPer add constraint FK_RecPer_RecWiaWiuId foreign key(RecWiaWiuId) references RecWiaWiu (Id)
alter table RecPer add constraint FK_RecAlt_SubmWorkPerformerId foreign key(SubmWorkPerformerId) references SubmWorkPerformer (Id)
go

create table RecGrt(
	Id int identity(1,1) not null primary key clustered,
	RecGrhId int not null,
	RecType varchar(3) null,
	GrId varchar(5) null,
	TransCnt varchar(8) null,
	RecCnt varchar(8) null
)
alter table RecGrt add constraint FK_RecGrt_RecGrh foreign key(RecGrhId) references RecGrh (Id)
go
go

create table RecTrl(
	Id int identity(1,1) not null primary key clustered,
	RecHdrId int not null,
	RecType varchar(3) null,
	GrCnt varchar(5) null,
	TransCnt varchar(8) null,
	RecCnt varchar(8) null
)
alter table RecTrl add constraint FK_RecTrl_RecHdr foreign key(RecHdrId) references RecHdr (Id)
go

create table RecAck (
	  Id int identity(1, 1) not null primary key clustered
	, RecWiaWiuId int
	, RecType varchar(3) null
	, TransSeqNr varchar(8) null
	, RecSeqNr varchar(8) null
	, CreDRef varchar(8) null
	, CreTRef varchar(6) null
	, GrpSeqNrRef varchar(5) null
	, TransSeqNrRef varchar(8) null
	, TransTypeRef varchar(3) null
	, WrkTtlRef varchar(60) null
	, SubmWrkNrRef varchar(20) null
	, Iswc varchar(20) null
	, PrcsD varchar(8) null
	, Status varchar(2) null
)
alter table RecAck add constraint fk_RecAck_RecWiaWiuId foreign key(RecWiaWiuId) references RecWiaWiu (Id)
go

create table RecMsgType(
	  Id int identity(1, 1) primary key clustered
	, MsgType varchar(1) NULL
	, MsgLevel varchar(1) NULL
	, ErrCondNr varchar(3) NULL
	, MsgTxt varchar(150) NULL
)
go

create table RecMsg(
	  Id int identity(1, 1) primary key clustered
	, SubmissionId int not null
	, RecType varchar(3) NULL
	, TransSeqNr varchar(8) NULL
	, RecSeqNr varchar(8) NULL
	, RecSeqNrRef varchar(8) NULL
	, RecTypeRef varchar(3) NULL
	, RecMsgTypeId int not null
)
alter table RecMsg add constraint fk_RecMsg_Submission foreign key(SubmissionId) references Submission (Id)
alter table RecMsg add constraint fk_RecMsg_RecMsgType foreign key(RecMsgTypeId) references RecMsgType (Id)
go

-- œŒ—»À¿ÕÕﬂ —œŒ¬≤Ÿ≈Õ‹ ¬≤ƒœŒ¬≤ƒ≤ Õ¿ ¬≤ƒ≤—À¿Õ»… «¿œ»—

create table MsgMapRecWiaWiu
(
	  RecMsgId int not null
	, RecWiaWiuId int not null
)
alter table MsgMapRecWiaWiu add constraint pk_MsgMapRecWiaWiu primary key (RecMsgId, RecWiaWiuId)
alter table MsgMapRecWiaWiu add constraint fk_MsgMapRecWiaWiu_RecMsg foreign key(RecMsgId) references RecMsg (Id)
alter table MsgMapRecWiaWiu add constraint fk_MsgMapRecWiaWiu_RecWiaWiu foreign key(RecWiaWiuId) references RecWiaWiu (Id)

create table MsgMapRecSipOip
(
	  RecMsgId int not null
	, RecSipOipId int not null
)
alter table MsgMapRecSipOip add constraint pk_MsgMapRecSipOip primary key (RecMsgId, RecSipOipId)
alter table MsgMapRecSipOip add constraint fk_MsgMapRecSipOip_RecMsg foreign key(RecMsgId) references RecMsg (Id)
alter table MsgMapRecSipOip add constraint fk_MsgMapRecSipOip_RecSipOip foreign key(RecSipOipId) references RecSipOip (Id)

create table MsgMapRecSsrOsr
(
	  RecMsgId int not null
	, RecSsrOsrId int not null
)
alter table MsgMapRecSsrOsr add constraint pk_MsgMapRecSsrOsr primary key (RecMsgId, RecSsrOsrId)
alter table MsgMapRecSsrOsr add constraint fk_MsgMapRecSsrOsr_RecMsg foreign key(RecMsgId) references RecMsg (Id)
alter table MsgMapRecSsrOsr add constraint fk_MsgMapRecSsrOsr_RecSsrOsr foreign key(RecSsrOsrId) references RecSsrOsr (Id)

create table MsgMapRecAlt
(
	  RecMsgId int not null
	, RecAltId int not null
)
alter table MsgMapRecAlt add constraint pk_MsgMapRecAlt primary key (RecMsgId, RecAltId)
alter table MsgMapRecAlt add constraint fk_MsgMapRecAlt_RecMsg foreign key(RecMsgId) references RecMsg (Id)
alter table MsgMapRecAlt add constraint fk_MsgMapRecAlt_RecAlt foreign key(RecAltId) references RecAlt (Id)

create table MsgMapRecPer
(
	  RecMsgId int not null
	, RecPerId int not null
)
alter table MsgMapRecPer add constraint pk_MsgMapRecPer primary key (RecMsgId, RecPerId)
alter table MsgMapRecPer add constraint fk_MsgMapRecPer_RecMsg foreign key(RecMsgId) references RecMsg (Id)
alter table MsgMapRecPer add constraint fk_MsgMapRecPer_RecPer foreign key(RecPerId) references RecPer (Id)

-- RESP FILE RECORDS
create table Z_RecAck (
	  Id int identity(1, 1) not null primary key clustered
	, RecWiaWiuId int
	, RecType varchar(3) null
	, TransSeqNr varchar(8) null
	, RecSeqNr varchar(8) null
	, CreDRef varchar(8) null
	, CreTRef varchar(6) null
	, GrpSeqNrRef varchar(5) null
	, TransSeqNrRef varchar(8) null
	, TransTypeRef varchar(3) null
	, WrkTtlRef varchar(60) null
	, SubmWrkNrRef varchar(20) null
	, Iswc varchar(20) null
	, PrcsD varchar(8) null
	, Status varchar(2) null
)
go

create table Z_RecMsg(
	  Id int identity(1, 1) primary key clustered
	, SubmissionId int not null
	, RecType varchar(3) NULL
	, TransSeqNr varchar(8) NULL
	, RecSeqNr varchar(8) NULL
	, MsgType varchar(1) NULL
	, RecSeqNrRef varchar(8) NULL
	, RecTypeRef varchar(3) NULL
	, MsgLevel varchar(1) NULL
	, ErrCondNr varchar(3) NULL
	, MsgTxt varchar(150) NULL
)

go