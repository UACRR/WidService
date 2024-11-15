use RadioStationReports
go

create table RadioStations (
	  Id int not null identity(1, 1)
	, Name nvarchar(100) not null
)
go

delete from RadioStations
insert RadioStations (name)
values
	  ('KISS FM')
	, ('Power Fm')
	, ('rap_songs')
	, ('retromusic_songs')
	, ('rock_songs')
	, ('sport_songs')
	, ('SUN FM')
	, ('ukraine_songs')
	, ('Аврора')
	, ('Байрактар')
	, ('Бізнес Радіо')
	, ('Богуслав ФМ')
	, ('Гетьман Львів')
	, ('Джаз')
	, ('Кюмол')
	, ('Мелодія')
	, ('Море Фм')
	, ('Наше Радіо')
	, ('Радіо Марія Р-3046')
	, ('Радіо Мелодія')
	, ('Радіо Релакс')
	, ('Радіо Рокс')
	, ('Радіо Україна')
	, ('Регіон плюс')
	, ('Рокс')
	, ('Тернопіль')
	, ('Хіт Фм')