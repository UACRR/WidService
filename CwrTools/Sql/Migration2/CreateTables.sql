use CWR
go

drop table if exists Partners
drop table if exists PartnerGroups

create table PartnerGroups (
	  Id int primary key nonclustered identity(1, 1)
	, Name nvarchar(32) not null
	, IsStandard bit
)

create table Partners (
	  Id int primary key nonclustered identity(1, 1)
	, PartnerGroupId int
	, Name nvarchar(32) not null
)
alter table Partners add constraint fk_PartnerGroup foreign key (PartnerGroupId) references PartnerGroups(Id);

insert PartnerGroups (Name, IsStandard)
values
	  ('Стандартна V21', 1)
	, ('Стандартна V22', 1)
	, ('Стандартна V23', 1)
	, ('MINT', 0)

insert Partners (PartnerGroupId, Name)
values
	  (1,'CISAC')
	, (1,'ASCAP')
	, (4, 'MINT')
