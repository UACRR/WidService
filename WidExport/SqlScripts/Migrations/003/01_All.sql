use SocWidSubmit
go


-- WidSubmGroupType
create table WidSubmGroupType (
	  Code char(1) not null primary key clustered
	, Description nvarchar(32)
)
go

insert WidSubmGroupType
values 
	  ('M', 'Головна')
	, ('P', 'Проблемна')
	, ('C', 'Зміни')
go

alter table WidSubmGroup
	add GroupType char(1)
	constraint WidSubmGroup_WidSubmGroupType foreign key (GroupType) references WidSubmGroupType(Code)
go

update WidSubmGroup
set GroupType = 'M'
go

alter table WidSubmGroup
	alter column GroupType char(1) not null
go

-- WidSubmGroupStatus
update WidSubmGroup set status = 0
update WidSubmGroupStatus set Code = 'Active', description = 'Активна' where Id = 0
update WidSubmGroupStatus set Code = 'Closed', description = 'Закрита' where Id = 1
delete WidSubmGroupStatus where Id > 1
go

-- WidSubmTranType
create table WidSubmTranType (
	  Code char(1) not null primary key clustered
	, Description nvarchar(32)
)
go

insert WidSubmTranType
values 
	  ('A', 'Додати твір')
	, ('U', 'Змінити твір')
go

alter table WidSubmGroupWork
	add TranType char(1)
	constraint WidSubmGroupWork_WidSubmTranType foreign key (TranType) references WidSubmTranType(Code)
go

update WidSubmGroupWork
set TranType = 'A'
go

alter table WidSubmGroupWork
	alter column TranType char(1) not null
go

-- RecWia - TranType
alter table RecWia
	add TranType char(1)
	constraint RecWia_WidSubmTranType foreign key (TranType) references WidSubmTranType(Code)
go

update RecWia
set TranType = 'A'
go

alter table RecWia
	alter column TranType char(1) not null
go

-- Standard groups
insert WidSubmGroup (SeqNr, Name, Status, GroupType)
values (-1, 'НЕ ПЕРЕДАНІ ТВОРИ', 0, 'P'), (-2, 'ДОДАТКОВІ І ЗМІНЕНІ ТВОРИ', 0, 'C')

-- Work Hash Table
drop table if exists WidSubmGroupWorkHash
create table WidSubmGroupWorkHash (
      ObjId int primary key clustered
    , HashString nvarchar(max)
)

-- Work Status Changes
update WidSubmGroupWorkStatus set Description = 'Узгоджено' where Id = 3
update WidSubmGroupWorkStatus set Description = 'Надіслано WID' where Id = 4
update WidSubmGroupWorkStatus set Description = 'Прийнято WID' where Id = 5
update WidSubmGroupWorkStatus set Description = 'Відхилено WID' where Id = 6
update WidSubmGroupWorkStatus set Description = 'Прийнято WID умовно' where Id = 7
update WidSubmGroupWorkStatus set Description = 'Існувало в WID' where Id = 8
update WidSubmGroupWorkStatus set Description = 'Завершено' where Id = 10

-- 
update WidSubmGroupWork set ShouldResubmit = 0 where ShouldResubmit is null

-- Changed/Created procedures
-- spWidSubmGroupClose
-- spWidSubmGroupSelect
-- spWidSubmGroupPartySelect
-- spWidSubmGroupPartyWorkSelect
-- spWidSubmGroupPartyCanDelete
-- spWidSubmGroupPreProc