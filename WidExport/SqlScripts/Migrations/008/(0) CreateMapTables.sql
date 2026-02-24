use SocWidSubmit
go

drop table if exists MapWia
create table MapWia (
	  RecWiaId int not null
	, WidSubmGroupWorkId int not null
)
alter table MapWia add constraint pk_MapWia						primary key (RecWiaId, WidSubmGroupWorkId);
alter table MapWia add constraint fk_MapWia_RecWiaId			foreign key (RecWiaId) references RecWia(Id);
alter table MapWia add constraint fk_MapWia_WidSubmGroupWorkId  foreign key (WidSubmGroupWorkId) references WidSubmGroupWork(Id);

go

drop table if exists MapSip
create table MapSip (
	  RecSipId int not null
	, WidSubmGroupWorkShareId int not null
)
alter table MapSip add constraint pk_MapSip							primary key (RecSipId, WidSubmGroupWorkShareId);
alter table MapSip add constraint fk_MapSip_RecSipId				foreign key (RecSipId) references RecSip(Id);
alter table MapSip add constraint fk_MapSip_WidSubmGroupWorkShareId foreign key (WidSubmGroupWorkShareId) references WidSubmGroupWorkShare(Id);

go

drop table if exists MapOip
create table MapOip (
	  RecOipId int not null
	, WidSubmGroupWorkShareId int not null
)
alter table MapOip add constraint pk_MapOip							primary key (RecOipId, WidSubmGroupWorkShareId);
alter table MapOip add constraint fk_MapOip_RecOipId				foreign key (RecOipId) references RecOip(Id);
alter table MapOip add constraint fk_MapOip_WidSubmGroupWorkShareId foreign key (WidSubmGroupWorkShareId) references WidSubmGroupWorkShare(Id);

go

drop table if exists MapSsr
create table MapSsr (
	  RecSsrId int not null
	, WidSubmGroupWorkShareId int not null
)
alter table MapSsr add constraint pk_MapSsr							primary key (RecSsrId, WidSubmGroupWorkShareId);
alter table MapSsr add constraint fk_MapSsr_RecSsrId				foreign key (RecSsrId) references RecSsr(Id);
alter table MapSsr add constraint fk_MapSsr_WidSubmGroupWorkShareId foreign key (WidSubmGroupWorkShareId) references WidSubmGroupWorkShare(Id);

go

drop table if exists MapOsr
create table MapOsr (
	  RecOsrId int not null
	, WidSubmGroupWorkShareId int not null
)
alter table MapOsr add constraint pk_MapOsr							primary key (RecOsrId, WidSubmGroupWorkShareId);
alter table MapOsr add constraint fk_MapOsr_RecOsrId				foreign key (RecOsrId) references RecOsr(Id);
alter table MapOsr add constraint fk_MapOsr_WidSubmGroupWorkShareId foreign key (WidSubmGroupWorkShareId) references WidSubmGroupWorkShare(Id);

go

drop table if exists MapAlt
create table MapAlt (
	  RecAltId int not null
	, WidSubmGroupWorkNameId int not null
)
alter table MapAlt add constraint pk_MapAlt							primary key (RecAltId, WidSubmGroupWorkNameId);
alter table MapAlt add constraint fk_MapAlt_RecAltId				foreign key (RecAltId) references RecAlt(Id);
alter table MapAlt add constraint fk_MapAlt_WidSubmGroupWorkNameId  foreign key (WidSubmGroupWorkNameId) references WidSubmGroupWorkName(Id);

drop table if exists MapPer
create table MapPer (
	  RecPerId int not null
	, WidSubmGroupWorkPerformerId int not null
)
alter table MapPer add constraint pk_MapPer								primary key (RecPerId, WidSubmGroupWorkPerformerId);
alter table MapPer add constraint fk_MapPer_RecPerId					foreign key (RecPerId) references RecPer(Id);
alter table MapPer add constraint fk_MapPer_WidSubmGroupWorkPerformerId foreign key (WidSubmGroupWorkPerformerId) references WidSubmGroupWorkPerformer(Id);

go

go



go
