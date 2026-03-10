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

drop table if exists Z_SubmRightHolder

drop table if exists Z_SubmWorkHash
drop table if exists Z_SubmWorkShare
drop table if exists Z_SubmWorkAltName
drop table if exists Z_SubmWorkPerformer
drop table if exists Z_SubmWork

drop table if exists ObjIdToWicIswc

drop table if exists SubmCheckList
drop table if exists SubmWorksAcceptedHash

drop table if exists SubmWorkShare
drop table if exists SubmWorkAltName
drop table if exists SubmWorkPerformer
drop table if exists SubmWork
drop table if exists SubmRightHolder

drop table if exists SubmFile
drop table if exists RespFile
drop table if exists Submission

drop table if exists RightHolder

drop table if exists SubmissionStatus
drop table if exists SubmWorkStatus


create table SubmissionStatus (
	  Id int not null primary key
	, Code varchar(30) not null
)
insert SubmissionStatus(Id, Code)
values
	  ( 0, 'INITIAL')
	, ( 1, 'SUBM_FILE_CREATED')
	, ( 2, 'SUBM_FILE_UPLOAD_FAILED')
	, ( 3, 'SUBM_FILE_UPLOADED')
	, ( 4, 'RESP_FILE_DOWNLOAD_FAILED')
	, ( 5, 'RESP_WRONG_SUBM_FILE')
	, ( 6, 'RESP_FILE_DOWNLOADED')
	, ( 7, 'RESP_FILE_PROCESSING_FAILED')
	, ( 8, 'ISWC_CODES_PASSED_TO_MS')
	, ( 9, 'CLOSED')

create table SubmWorkStatus (
	  Id int not null primary key
	, Code varchar(30) not null
)
insert SubmWorkStatus(Id, Code)
values
	  ( 0, 'NOT_READY')
	, ( 1, 'READY')
	, ( 2, 'SUBMITTED')
	, ( 3, 'ACCEPTED')
	, ( 4, 'ACCEPTED_WARNINGS')
	, ( 5, 'REJECTED')
	, ( 6, 'APPLIED')
	, ( 7, 'COMPLETED')

create table RightHolder (
	  Id				int primary key identity(1, 1)
	, ValidFrom			date not null
	, ValidTo			date not null
	, CreatedAt			datetime not null default(getdate())
	, CustId			int not null
	, RhType			int not null
	, IpBaseNr			varchar(13) null
	, IpNameNr			int null
	, Name				nvarchar(256) not null
	, FstName			nvarchar(256) not null
	, NameForWid		nvarchar(256) not null
	, FstNameForWid		nvarchar(256) not null
	, IsOwn				bit not null default(0)
	, IsActive			bit not null default(1)
	, HasIpiAgreePer	bit null
	, HasIpiAgreeMec	bit null
)
alter table RightHolder add constraint ucRightHolderValidFromCustId unique (ValidFrom, CustId)
alter table RightHolder add constraint ucRightHolderValidToCustId unique (ValidTo, CustId)

create table Submission (
	  Id					int primary key identity(1, 1)
	, StartedAt				datetime not null
	, EndedAt				datetime not null
	, SubmFileName			varchar(32) not null default('')
	, RespFileName			varchar(32) not null default('')
	, ErrorFileName			varchar(32) not null default('')
	, SubmissionStatusId	int not null
	, CreatedAt				datetime not null default(getdate())
	, UpdatedAt				datetime null
)
alter table Submission add constraint fkSubmissionSubmissionStatusID foreign key (SubmissionStatusId) references SubmissionStatus (Id);
go

create table SubmRightHolder (
		  Id int primary key identity(1, 1)
		, SubmissionId int not null
		, RightHolderId int not null
		, SubmAsOwn bit not null
		, CreatedAt datetime not null
)

alter table SubmRightHolder add constraint fkSubmRightHolderSubmission foreign key (SubmissionId) references Submission (Id);
alter table SubmRightHolder add constraint fkSubmRightHolderRightHolder foreign key (RightHolderId) references RightHolder (Id);

go

create table SubmFile (
	  Id int primary key identity(1, 1)
	, Name nvarchar(64)
	, SubmissionId int not null
	, SentAt datetime null
	, CreatedAt datetime not null default(getdate())
	, UpdatedAt datetime null
)
alter table SubmFile add constraint fkSubmFileSubmission foreign key (SubmissionId) references Submission (Id);
go

create table RespFile (
	  Id int primary key identity(1, 1)
	, SubmissionId int not null
	, Name nvarchar(64)
	, ReceivedAt datetime null
	, CreatedAt datetime not null default(getdate())
	, UpdatedAt datetime null
)
alter table RespFile add constraint fkRespFileSubmission foreign key (SubmissionId) references Submission (Id);
go

create table SubmWork (
	  Id int primary key identity(1, 1)
	, SubmissionId int not null
	, ObjId int not null
	, Wic int null
	, Iswc varchar(11) not null
	, Name nvarchar(256)
	, NameForWid nvarchar(256)
	, IsChanged bit not null
	, Status int not null
	, CreatedAt datetime not null default(getdate())
	, UpdatedAt datetime null
)
alter table SubmWork add constraint fkSubmWorkStatus foreign key (Status) references SubmWorkStatus (Id);
alter table SubmWork add constraint fkSubmWorkSubmission foreign key (SubmissionId) references Submission (Id);
alter table SubmWork add constraint ucSubmWorkSubmissionIdObjId unique (SubmissionId, ObjId)
go

create table SubmWorkShare (
	  Id int primary key identity(1, 1)
	, SubmWorkId int not null
	, RightHolderId int not null
	, RhRole int not null
	, RoleForWid varchar(2) not null
	, ShrPer decimal(5, 2) not null
	, ShrMec decimal(5, 2) not null
	, CreatedAt datetime not null default(getdate())
	, UpdatedAt datetime null
)
alter table SubmWorkShare add constraint fkSubmWorkShareWork foreign key (SubmWorkId) references SubmWork (Id);
alter table SubmWorkShare add constraint fkSubmWorkShareRightHolder foreign key (RightHolderId) references RightHolder (Id);
go

create table SubmWorkAltName (
	  Id int primary key identity(1, 1)
	, SubmWorkId int not null
	, OrigNames nvarchar(256)
	, NameForWid nvarchar(256)
	, CreatedAt datetime not null default(getdate())
	, UpdatedAt datetime null
)
alter table SubmWorkAltName add constraint fkSubmWorkAltNameWork foreign key (SubmWorkId) references SubmWork (Id);
go

create table SubmWorkPerformer (
	  Id int primary key identity(1, 1)
	, SubmWorkId int not null
	, OrigNames nvarchar(256)
	, NameForWid nvarchar(256)
	, CreatedAt datetime not null default(getdate())
	, UpdatedAt datetime null
)
alter table SubmWorkPerformer add constraint fkSubmWorkPerformerWork foreign key (SubmWorkId) references SubmWork (Id);
go

create table SubmWorksAcceptedHash (
	  Id int primary key identity(1, 1)
	, SubmWorkId int not null
	, ObjId int not null
	, HashValue nvarchar(max)
	, CreatedAt datetime not null default(getdate())
	, UpdatedAt datetime null
)
alter table SubmWorksAcceptedHash add constraint fkSubmWorksAcceptedHashWork foreign key (SubmWorkId) references SubmWork (Id);
go

create table SubmCheckList (
	  Id int identity(1, 1) primary key
	, SubmWorkId int not null
	, HasOwnRightHolder bit not null
	, RolesDefined bit not null
	, HasNonPublisher bit not null
	, AllInIpi bit not null
	, PubShare0or100 bit not null
	, MecShare0or100 bit not null
	, HasShare bit not null
	, AllIpiCodesValid bit not null
	, IsOk  bit not null
)
alter table SubmCheckList add constraint ucSubmCheckListSubmIdSubmWorkId unique (SubmWorkId)
alter table SubmCheckList add constraint fkSubmCheckListSubmWork foreign key (SubmWorkId) references SubmWork (Id);
go


create table ObjIdToWicIswc (
	  ObjId int primary key
	, Wic int null
	, Iswc varchar(11) null
)

-- РОБЮЧІ ТАБЛИЦІ

create table Z_SubmRightHolder (
	  Guid uniqueidentifier
	, RightHolderId int not null
	, SubmAsOwn bit not null
)

create table Z_SubmWork (
	  Id int primary key identity(1, 1)
	, SubmissionId int not null
	, ObjId int not null
	, Wic int null
	, Iswc varchar(11) not null
	, Name nvarchar(256)
	, NameForWid nvarchar(256)
	, IsChanged bit not null
	, CreatedAt datetime not null default(getdate())
	, UpdatedAt datetime null
)
alter table Z_SubmWork add constraint ucZ_SubmWorkSubmissionIdObjId unique (SubmissionId, ObjId)
go

create table Z_SubmWorkShare (
	  Id int primary key identity(1, 1)
	, SubmWorkId int not null
	, RightHolderId int not null
	, RhRole int not null
	, RoleForWid varchar(2) not null
	, ShrPer decimal(5, 2) not null
	, ShrMec decimal(5, 2) not null
	, CreatedAt datetime not null default(getdate())
	, UpdatedAt datetime null
)
alter table Z_SubmWorkShare add constraint fkZ_SubmWorkShareWork foreign key (SubmWorkId) references Z_SubmWork (Id);
alter table Z_SubmWorkShare add constraint fkZ_SubmWorkShareRightHolder foreign key (RightHolderId) references RightHolder (Id);
go

create table Z_SubmWorkAltName (
	  Id int primary key identity(1, 1)
	, SubmWorkId int not null
	, OrigNames nvarchar(256)
	, NameForWid nvarchar(256)
	, CreatedAt datetime not null default(getdate())
	, UpdatedAt datetime null
)
alter table Z_SubmWorkAltName add constraint fkZ_SubmWorkAltNameWork foreign key (SubmWorkId) references Z_SubmWork (Id);
go

create table Z_SubmWorkPerformer (
	  Id int primary key identity(1, 1)
	, SubmWorkId int not null
	, OrigNames nvarchar(256)
	, NameForWid nvarchar(256)
	, CreatedAt datetime not null default(getdate())
	, UpdatedAt datetime null
)
alter table Z_SubmWorkPerformer add constraint fkZ_SubmWorkPerformerWork foreign key (SubmWorkId) references Z_SubmWork (Id);
go

create table Z_SubmWorkHash (
	  Id int primary key identity(1, 1)
	, SubmWorkId int not null
	, HashValue nvarchar(max)
	, CreatedAt datetime not null default(getdate())
	, UpdatedAt datetime null
)
alter table Z_SubmWorkHash add constraint fkZ_SubmWorkHashWork foreign key (SubmWorkId) references Z_SubmWork (Id);

go

