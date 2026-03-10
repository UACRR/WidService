use SocWidSubmitEx
go

drop table if exists RecTrl
drop table if exists RecGrt
drop table if exists RecPer
drop table if exists RecAlt
drop table if exists RecOsr
drop table if exists RecOip
drop table if exists RecSsr
drop table if exists RecSip
drop table if exists RecWiaWiu
drop table if exists RecGrh
drop table if exists RecHdr

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
alter table RecGrh add constraint FK_RecGrh_RecHdr foreign key(RecHdrId) references RecHdr (Id)
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
	TranType char(1) not null,
	GrpSeqNr int null
)
alter table RecWiaWiu add constraint FK_RecWiaWiu_RecGrh foreign key(RecGrhId) references RecGrh (Id)
alter table RecWiaWiu add constraint FK_RecWiaWiu_SubmWork foreign key(SubmWorkId) references SubmWork (Id)
go

create table RecSip(
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
	GrpSeqNr int null
)
alter table RecSip add constraint FK_RecSip_SubmWorkShare foreign key(SubmWorkShareId) references SubmWorkShare (Id)
go

create table RecSsr(
	Id int identity(1,1) not null primary key clustered,
	RecSipId int not null,
	RecType varchar(3) null,
	TransSeqNr varchar(8) null,
	RecSeqNr varchar(8) null,
	Filler6 varchar(9) null,
	RightType varchar(3) null,
	Shares varchar(5) null,
	IpNameNr varchar(11) null,
	Aff varchar(3) null,
	GrpSeqNr int null
)
alter table RecSsr add constraint FK_RecSsr_RecSip foreign key(RecSipId) references RecSip (Id)
go

create table RecOip(
	Id int identity(1,1) not null primary key clustered,
	RecWiaWiuId int not null,
	SubmWorkShareId int not null,
	RecType varchar(3) null,
	TransSeqNr varchar(8) null,
	RecSeqNr varchar(8) null,
	Filler1 varchar(9) null,
	IpNr varchar(9) null,
	IpName varchar(45) null,
	IpFstName varchar(30) null,
	IpRole varchar(2) null,
	IpNameNr varchar(11) null,
	GrpSeqNr int null
)
alter table RecOip add constraint FK_RecOip_RecWiaWiu foreign key(RecWiaWiuId) references RecWiaWiu (Id)
alter table RecOip add constraint FK_RecOip_SubmWorkShare foreign key(SubmWorkShareId) references SubmWorkShare (Id)
go
go

create table RecOsr(
	Id int identity(1,1) not null primary key clustered,
	RecOipId int not null,
	RecType varchar(3) null,
	TransSeqNr varchar(8) null,
	RecSeqNr varchar(8) null,
	Filler3 varchar(9) null,
	RightType varchar(3) null,
	Shares varchar(5) null,
	IpNameNr varchar(11) null,
	Aff varchar(3) null,
	GrpSeqNr int null
)
alter table RecOsr add constraint FK_RecOsr_RecOipu foreign key(RecOipId) references RecOip (Id)
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
	LngCode varchar(2) null,
	GrpSeqNr int null)
alter table RecAlt add constraint FK_RecAlt_RecWiaWiu foreign key(RecWiaWiuId) references RecWiaWiu (Id)
alter table RecAlt add constraint FK_RecAlt_SubmWorkAltName foreign key(SubmWorkAltNameId) references SubmWorkAltName (Id)
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
	GrpSeqNr int null
)
alter table RecPer add constraint FK_RecPer_RecWiaWiu foreign key(RecWiaWiuId) references RecWiaWiu (Id)
alter table RecPer add constraint FK_RecAlt_SubmWorkPerformer foreign key(SubmWorkPerformerId) references SubmWorkPerformer (Id)
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

-- RESP FILE RECORDS
/*
create table RecHdrRsp(
	Id int identity(1,1) not null primary key clustered,
	RespFileId int not null,
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
go

create table RecGrhRsp(
	Id int identity(1,1) not null primary key clustered,
	RespFileId int not null,
	RecType varchar(3) null,
	TransType varchar(3) null,
	GrId varchar(5) null,
	VerNr varchar(5) null
)
go

create table RecAck(
	Id int identity(1,1) not null primary key clustered,
	RespFileId int not null,
	RecType varchar(3) null,
	TransSeqNr varchar(8) null,
	RecSeqNr varchar(8) null,
	CreDRef varchar(8) null,
	CreTRef varchar(6) null,
	GrpSeqNrRef varchar(5) null,
	TransSeqNrRef varchar(8) null,
	TransTypeRef varchar(3) null,
	WrkTtlRef varchar(60) null,
	SubmWrkNrRef varchar(20) null,
	Iswc varchar(20) null,
	PrcsD varchar(8) null,
	Status varchar(2) null
)
go

create table RecMsg(
	Id int identity(1,1) not null primary key clustered,
	RespFileId int not null,
	RecType varchar(3) null,
	TransSeqNr varchar(8) null,
	RecSeqNr varchar(8) null,
	MsgType varchar(1) null,
	RecSeqNrRef varchar(8) null,
	RecTypeRef varchar(3) null,
	MsgLevel varchar(1) null,
	ErrCondNr varchar(3) null,
	MsgTxt varchar(150) null
)
go

create table RecGrtRsp(
	Id int identity(1,1) not null primary key clustered,
	RespFileId int not null,
	RecType varchar(3) null,
	GrId varchar(5) null,
	TransCnt varchar(8) null,
	RecCnt varchar(8) null
)
go

create table RecTrlRsp(
	Id int identity(1,1) not null primary key clustered,
	RespFileId int not null,
	RecType varchar(3) null,
	GrCnt varchar(5) null,
	TransCnt varchar(8) null,
	RecCnt varchar(8) null
)
go

-- RESP DETAIL RECORDS

create table RecAckStatus(
	Code varchar(2) not null,
	Description nvarchar(30) not null
)
go


create table RecMsgLevel(
	Code varchar(2) not null,
	Description nvarchar(30) not null
)
go

create table RecMsgType(
	Code varchar(2) not null,
	Description nvarchar(30) not null
)
go

-- KEYS



alter table RecAck add constraint FK_RecAck_RespFileId foreign key(RespFileId)
references RespFile (Id)
go

alter table RecAlt add constraint FK_RecRecAlt_SubmFileId foreign key(SubmFileId)
references SubmFile (Id)
go

alter table RecGrh add constraint FK_RecGrh_SubmFileId foreign key(SubmFileId)
references SubmFile (Id)
go

alter table RecGrhRsp add constraint FK_RecGrhRsp_RespFileId foreign key(RespFileId)
references RespFile (Id)
go

alter table RecGrt add constraint FK_RecGrt_SubmFileId foreign key(SubmFileId)
references SubmFile (Id)
go

alter table RecGrtRsp add constraint FK_RecGrtRsp_RespFileId foreign key(RespFileId)
references RespFile (Id)
go

alter table RecHdr add constraint FK_RecHdr_SubmFileId foreign key(SubmFileId)
references SubmFile (Id)
go

alter table RecHdrRsp add constraint FK_RecHdrRspr_RespFileId foreign key(RespFileId)
references RespFile (Id)
go

alter table RecMsg add constraint FK_RecMsg_RespFileId foreign key(RespFileId)
references RespFile (Id)
go

alter table RecOip add constraint FK_RecOip_SubmFileId foreign key(SubmFileId)
references SubmFile (Id)
go

alter table RecOsr add constraint FK_RecOsr_SubmFileId foreign key(SubmFileId)
references SubmFile (Id)
go

alter table RecPer add constraint FK_RecPer_SubmFileId foreign key(SubmFileId)
references SubmFile (Id)
go

alter table RecSip add constraint FK_RecSip_SubmFileId foreign key(SubmFileId)
references SubmFile (Id)
go

alter table RecSsr add constraint FK_RecSsr_SubmFileId foreign key(SubmFileId)
references SubmFile (Id)
go

alter table RecTrl add constraint FK_RecTrl_SubmFileId foreign key(SubmFileId)
references SubmFile (Id)
go

alter table RecTrlRsp add constraint FK_RecTrlRsp_RespFileId foreign key(RespFileId)
references RespFile (Id)
go

alter table RecWia add constraint FK_RecWia_SubmFileId foreign key(SubmFileId)
references SubmFile (Id)
go

alter table RecWia add constraint RecWia_WidSubmTranType foreign key(TranType)
references WidSubmTranType (Code)
go

alter table RecWiu add constraint FK_RecWiu_SubmFileId foreign key(SubmFileId)
references SubmFile (Id)
go
go
*/