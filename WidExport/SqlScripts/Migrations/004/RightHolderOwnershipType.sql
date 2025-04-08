use SocWidSubmit
go

create table RightHolderOwnershipType (
	  Code char(1) primary key nonclustered
	, Description nvarchar(32) not null
)

insert RightHolderOwnershipType
values 
	  ('D', 'Автоматичний розрахунок')
	, ('O', 'Правовласник товариства')
	, ('F', 'Сторонній правовласник')