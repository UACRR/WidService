use SocWidSubmitEx
go

alter table RecWiaWiu drop column if exists FstSendDateToCis;
alter table RecWiaWiu drop column if exists LstSendDateToCis;
alter table RecWiaWiu drop column if exists SocWrkType;
alter table RecSsrOsr drop column if exists Aff;
go

drop table if exists Z_LostIpNameNrs
create table Z_LostIpNameNrs (
	  CustId				int primary key		         
	, IpBaseNr				varchar(16)    
	, FullNameMs			varchar(256)
	, IpNameNrFound			varchar(16)
	, FullNameIpiFound		varchar(256)
)
go

drop table if exists Z_LostIpiCodes
create table Z_LostIpiCodes (
	  CustIdAuthor int not null
	, FullNameAuthor varchar(256) null
	, CustIdCoAuthor int not null
	, FullNameCoAuthor varchar(256) null
	, FullNameCoAuthorTr varchar(256) null
	, IpBaseNr varchar(16) null
	, IpNameNr varchar(16) null
	, FoundIn int not null
	, IsFinal bit not null
	, primary key clustered (CustIdAuthor asc, CustIdCoAuthor asc)
)
alter table Z_LostIpiCodes add constraint fk_Z_LostIpiCodes_FoundIn foreign key (FoundIn) references Z_LostIpiCodesFoundIn(Code)


drop table if exists Z_LostIpiCodesFoundIn
create table Z_LostIpiCodesFoundIn (
	  Code int primary key
	, Name varchar(16)
	, Description nvarchar(64)
)

insert Z_LostIpiCodesFoundIn
values
      (0, 'NS',		'Не шукався')
	, (1, 'NF',		'Не знайдено')
	, (2, 'IPI',	'Знайдено в локальній БД IPI')
	, (3, 'CisNet', 'Знайдено в додатку CisNet')
	, (4, 'Auto',	'Знайдено автоматичним пошуком в локальній БД IPI')
go

drop table if exists Z_ImportantAuthors
create table Z_ImportantAuthors (
	  CustId int primary key
	, FullName nvarchar(256)
)
go

drop table if exists Z_Cn2RightHolder
create table Z_Cn2RightHolder (
	  CustId	int primary key
	, IpBaseNr	varchar(13)
	, IpNameNr	varchar(13)
	, Name		varchar(90)
	, FstName	varchar(45)
	, IsActive	bit
)
go

drop table if exists Z_Cn2CopyRight
create table Z_Cn2CopyRight (
	  CRightId int primary key
	, ObjId int
	, CustId int
	, ShrPer decimal(5, 2)
	, ShrMec decimal(5, 2)
	, Rol varchar(2)
	, IsActive bit
)
alter table Z_Cn2CopyRight add constraint fk_Z_Cn2CopyRight_CustId foreign key (CustId) references Z_Cn2RightHolder(CustId)
go

drop table if exists IswcRejected
create table IswcRejected (
	  ObjId int primary key
	, ReSubmit bit
)
go

