use CWR
go

drop table if exists Partners
drop table if exists PartnerGroups

create table PartnerGroups (
	  Id int primary key nonclustered identity(1, 1)
	, Name nvarchar(32) not null
	, IsStandard bit not null default(0)
	, FormatVersion char(3) not null default('V21')
)

create table Partners (
	  Id int primary key nonclustered identity(1, 1)
	, PartnerGroupId int
	, Name nvarchar(32) not null
)
alter table Partners add constraint fk_PartnerGroup foreign key (PartnerGroupId) references PartnerGroups(Id);

insert PartnerGroups (Name, IsStandard, FormatVersion)
values
	  ('Стандартна V21', 1, 'V21')
	, ('Стандартна V22', 1, 'V22')
	, ('MINT', 0, 'V22')

insert Partners (PartnerGroupId, Name)
values
	  (1,'CISAC')
	, (1,'ASCAP')
	, (3, 'MINT')

alter table CwrFiles add constraint fk_CwrFiles_PartnerGroup foreign key (PartnerGroupId) references PartnerGroups(Id);
update CwrFiles set  PartnerGroupId = 3
