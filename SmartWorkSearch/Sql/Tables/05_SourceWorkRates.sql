use SmartWorkSearch
go

--drop table SourceWorks

create table SourceWorkRates (
	  Id int primary key identity(1, 1)
	, SourceWorkId int not null
	, Rate int not null
	, RateIdx int not null
)

alter table SourceWorkRates
add constraint fk_SourceWorkRates_SourceWorkId
foreign key (SourceWorkId) references SourceWorks(Id);

create unique index idx_SourceWorkRates_RateIdx
on SourceWorkRates (RateIdx)

