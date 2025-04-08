use SocWidSubmit
go

drop table if exists RightHolderOwnership
create table RightHolderOwnership (
	  CustId int primary key nonclustered
	, RightHolderOwnershipTypeId char(1) not null
)

alter table RightHolderOwnership
add constraint fk_RightHolderOwnership_RightHolderOwnershipType
foreign key (RightHolderOwnershipTypeId)
references RightHolderOwnershipType(Code)