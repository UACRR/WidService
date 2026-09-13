use ShareCalc
go

-- >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> АНАЛІЗ ВИКЛЮЧЕНЬ
drop table if exists ExcSocPer
drop table if exists ExcSocMec
drop table if exists ExcRhPer
drop table if exists ExcRhMec
drop table if exists ExcSocAdv
drop table if exists ExcSet


create table ExcSet (
	  Id int primary key nonclustered identity (1, 1)
	, Name nvarchar(62)
	, Dsc nvarchar(256)
	, SrcId int
)
go

create table ExcSocPer (
	  Id int primary key nonclustered identity (1, 1)
	, ExcSetId int
	, SocCde int
	, SrcId int
	, constraint fk_ExcSocPer_ExcSet foreign key (ExcSetId) references ExcSet(Id)
)
go

create table ExcSocMec (
	  Id int primary key nonclustered identity (1, 1)
	, ExcSetId int
	, SocCde int
	, SrcId int
	, constraint fk_ExcSocMec_ExcSet foreign key (ExcSetId) references ExcSet(Id)
)
go

create table ExcRhPer (
	  Id int primary key nonclustered identity (1, 1)
	, ExcSetId int
	, IpNameNr int
	, SrcId int
	, constraint fk_ExcRhPer_ExcSet foreign key (ExcSetId) references ExcSet(Id)
)                       
go

create table ExcRhMec (
	  Id int primary key nonclustered identity (1, 1)
	, ExcSetId int
	, IpNameNr int
	, SrcId int
	, constraint fk_ExcRhMec_ExcSet foreign key (ExcSetId) references ExcSet(Id)
)                       
go

create table ExcSocAdv (
	  Id int primary key nonclustered identity (1, 1)
	, ExcSetId int
	, RhIpBaseNr varchar(13)
	, SocCde int
	, SrcId int
	, constraint fk_ExcSocAdv_ExcSet foreign key (ExcSetId) references ExcSet(Id)
)
go

drop table if exists Shares
create table Shares (
	  Id int primary key nonclustered

	, ObjId int
	, CustId int

	, PerSoc int
	, PerShr decimal(5, 2)
	, PerShrRes decimal(5, 2)
	, PerRhSvcExc bit -- Для своїх - наявність потрібного сервісу від товариства
	, PerSocAgrExc bit -- Для іноземних - навність договору з товариством
	, PerSocExc bit -- Товариство в переліку виключень
	, PerRhExc bit -- Правовласник в переліку виключень
	, PerAdvExc bit -- Для видавців твору за переліком виключених товариств

	, MecSoc int
	, MecShr decimal(5, 2)
	, MecShrRes decimal(5, 2)
	, MecRhSvcExc bit
	, MecSocAgrExc bit
	, MecSocExc bit
	, MecRhExc bit
	, MecAdvExc bit
)
go

-- >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ПОШУК ПРАВОВЛАСНИКІВ В МІЖНАРОДНІЙ БД
drop table if exists Z_RhNames
drop table if exists Z_RhNamesTr
drop table if exists Z_RhFound
drop table if exists Z_RhFoundRanked

create table Z_RhNames (
	  CustId int primary key nonclustered
	, FullNameOrig nvarchar(max)
	, LstNameOrig nvarchar(max)
	, FstNameOrig nvarchar(max)
	, SurNameOrig nvarchar(max)
	, LstName nvarchar(max)
	, FstName nvarchar(max)
	, NameSepIdx int
)
go

create table Z_RhNamesTr (
	  CustId int primary key nonclustered
	, FullNameOrig nvarchar(max)
	, LstName nvarchar(max)
	, FstName nvarchar(max)
	, IpBaseNr varchar(13)
	, FoundBy varchar(32)
)
go

create table Z_RhFound (
	  CustId int
	, IpBaseNr varchar(13)
)
go

create table Z_RhFoundRanked (
	  CustId int
	, Count int
)
go
