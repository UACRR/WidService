use SocWidSubmitEx
go

drop table if exists Z_SubmRightHolder

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

create table Z_SubmRightHolder (
	  Guid uniqueidentifier
	, RightHolderId int not null
	, SubmAsOwn bit not null
)

create table RightHolder (
	  Id				int primary key identity(1, 1)
	, ValidFrom			date not null
	, ValidTo			date not null
	, CreatedAt			datetime not null default(getdate())
	, CustId			int not null
	, IpBaseNr			varchar(13) null
	, IpNameNr			int null
	, Name				nvarchar(255) not null
	, FstName			nvarchar(255) not null
	, NameForWid		nvarchar(255) not null
	, FstNameForWid		nvarchar(255) not null
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
	, Name nvarchar(256)
	, NameForWid nvarchar(60)
	, IsChanged bit not null
	, CreatedAt datetime not null default(getdate())
	, UpdatedAt datetime null
)
alter table SubmWork add constraint fkSubmWorkSubmission foreign key (SubmissionId) references Submission (Id);
go

create table SubmWorkShare (
	  Id int primary key identity(1, 1)
	, SubmWorkId int not null
	, RightHolderId int not null
	, IpBaseNr varchar(13) null
	, IpNameNr int null
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
	, Name nvarchar(256)
	, NameForWid nvarchar(60)
	, CreatedAt datetime not null default(getdate())
	, UpdatedAt datetime null
)
alter table SubmWorkAltName add constraint fkSubmWorkAltNameWork foreign key (SubmWorkId) references SubmWork (Id);
go

create table SubmWorkPerformer (
	  Id int primary key identity(1, 1)
	, SubmWorkId int not null
	, Name nvarchar(256)
	, NameForWid nvarchar(60)
	, CreatedAt datetime not null default(getdate())
	, UpdatedAt datetime null
)
alter table SubmWorkPerformer add constraint fkSubmWorkPerformerWork foreign key (SubmWorkId) references SubmWork (Id);
go

