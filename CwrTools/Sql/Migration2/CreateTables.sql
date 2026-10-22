use CWR
go

alter table CwrFiles drop constraint fk_CwrFiles_PartnerGroup;
drop table if exists CwrPartnerFiles
drop table if exists CwrPartnerFilesStatus
drop table if exists Partners
drop table if exists PartnerGroups
drop table if exists Periods
drop table if exists PeriodType
--drop table if exists CwrFiles
go

create table PartnerGroups (
	  Id int primary key nonclustered identity(1, 1)
	, Name nvarchar(32) not null
	, IsStandard bit not null default(0)
	, IsV21 bit not null
	, IsV22 bit not null
	, AddNativeNames bit not null
	, AroundWorldRequired bit not null
)

insert PartnerGroups (Name, IsStandard, IsV21, IsV22, AddNativeNames, AroundWorldRequired)
values
	  ('Стандартна V21', 1, 1, 0, 0, 1)
	, ('Стандартна V22', 1, 0, 1, 0, 1)
	, ('MINT', 0, 0, 1, 1, 1)

go

create table PeriodType (
	  Id int primary key
	, Code varchar(30)
)
insert PeriodType (Id, Code)
values
	  (1, 'Month')
	, (2, 'Quarter')
	, (3, 'HalfYear')
	, (4, 'Year')
go

create table Periods (
	  Id int primary key identity(1, 1)
	, PeriodType int
	, Year int
	, Point int
	, StartDate date
	, EndDate date
)
alter table Periods add constraint fk_Periods_PeriodType foreign key (PeriodType) references PeriodType(Id);
go

create table Partners (
	  Id int primary key nonclustered identity(1, 1)
	, PartnerGroupId int
	, Name nvarchar(32) not null
	, PeriodType int
	, EMail nvarchar(128)
	, FtpUrl nvarchar(128)
	, FtpLogin nvarchar(128)
	, FtpPwd nvarchar(128)
	, FtpPort varchar(16)
)
alter table Partners add constraint fk_Partners_PartnerGroup foreign key (PartnerGroupId) references PartnerGroups(Id);
alter table Partners add constraint fk_Partners_PeriodType foreign key (PeriodType) references PeriodType(Id);

insert Partners (PartnerGroupId, Name, PeriodType, EMail, FtpUrl, FtpLogin, FtpPwd, FtpPort)
values
	  (1, 'ABRAMUS', 1, '', '', '', '', 0)
	, (3, 'MINT', 2, '', '', '', '', 0)
go

-- Column PartnerGroupId and CreatedAt should be inserted manually
alter table CwrFiles add constraint fk_CwrFiles_PartnerGroup foreign key (PartnerGroupId) references PartnerGroups(Id);
update CwrFiles set PartnerGroupId = 1
go

create table CwrPartnerFilesStatus (
	  Id int primary key
	, Code varchar(30)
)
insert CwrPartnerFilesStatus (Id, Code)
values
	  (1, 'Planned')
	, (2, 'Awaiting')
	, (3, 'Sent')
	, (4, 'Accepted')
	, (5, 'Rejected')
go

create table CwrPartnerFiles (
	  Id int primary key nonclustered identity(1, 1)
	, CwrFileId int
	, PartnerId int
	, PeriodId int
	, Name nvarchar(32) not null
	, Status int
	, CreatedAt datetime
	, SentAt datetime
	, AnsweredAt datetime
)
alter table CwrPartnerFiles add constraint fk_CwrPartnerFiles_CwrFileId foreign key (CwrFileId) references CwrFiles(CwrFileId);
alter table CwrPartnerFiles add constraint fk_CwrPartnerFiles_PartnerId foreign key (PartnerId) references Partners(Id);
alter table CwrPartnerFiles add constraint fk_CwrPartnerFiles_PeriodId foreign key (PeriodId) references Periods(Id);
go

alter table CwrFiles drop column if exists Path
alter table CwrFiles drop column if exists RespPath
alter table CwrFiles drop column if exists RespName
alter table CwrFiles drop column if exists Status
go

