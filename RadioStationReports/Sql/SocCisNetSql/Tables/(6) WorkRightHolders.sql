use SocCisNet
go

drop table if exists WorkRightHolders
create table WorkRightHolders (
	  Id int primary key identity(1, 1)
	, SeqNr int
	, IpBaseNr varchar(13)
	, IpNameNr int
	, IpRole varchar(2)
	, FstName varchar(128) not null
	, LstName varchar(128) not null
	, IsLeadingPublisher bit
	, PerSocCde int
	, PerShr decimal(5, 2)
	, MecSocCde int
	, MecShr decimal(5, 2)
	, WorkCode varchar(50) not null

)
go

alter table WorkRightHolders
add constraint fk_WorkRightHolders_WorkCode
foreign key (WorkCode) references Works(WorkCode)
go

create index idxWorkRightHolders_IpBaseNr on WorkRightHolders(IpBaseNr);
go


create index idxWorkRightHolders_IpNameNr on WorkRightHolders(IpNameNr);
go


