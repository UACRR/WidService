use CWR
go

alter table CwrFiles drop constraint fk_CwrFiles_PartnerGroup;
drop table if exists Partners
drop table if exists PartnerGroups

create table PartnerGroups (
	  Id int primary key nonclustered identity(1, 1)
	, Name nvarchar(32) not null
	, IsStandard bit not null default(0)
	, IsV21 bit not null
	, IsV22 bit not null
	, AddNativeNames bit not null
	, AroundWorldRequired bit not null
)

create table Partners (
	  Id int primary key nonclustered identity(1, 1)
	, PartnerGroupId int
	, Name nvarchar(32) not null
)
alter table Partners add constraint fk_PartnerGroup foreign key (PartnerGroupId) references PartnerGroups(Id);

insert PartnerGroups (Name, IsStandard, IsV21, IsV22, AddNativeNames, AroundWorldRequired)
values
	  ('Стандартна V21', 1, 1, 0, 0, 1)
	, ('Стандартна V22', 1, 0, 1, 0, 1)
	, ('MINT', 0, 0, 1, 1, 1)

insert Partners (PartnerGroupId, Name)
values
	  (1,'CISAC')
	, (1,'ASCAP')
	, (3, 'MINT')

alter table CwrFiles add constraint fk_CwrFiles_PartnerGroup foreign key (PartnerGroupId) references PartnerGroups(Id);
update CwrFiles set  PartnerGroupId = 3
