use Ddex
go

-- >>>>>>>>>>>>>> гюл╡╡ярэ рюакхж╡ г оепек╡йнл юбрнп╡б дкъ йнфмнцн опндюфс (оепек╡й дсакч╙рэяъ) 
-- >>>>>>>>>>>>>> ярбнпч╙лн ндмс г оепек╡йнл дкъ рбнп╡б гб╡рс

-- яРБНПЧ╨ЛН РЮАКХЖЧ

drop table if exists DdexReportAuthors
go

create table DdexReportAuthors (
	  Id				int primary key identity(1, 1)
	, DdexReportId		int null
	, Wic				int null
	, ObjId				int null
	, IpBaseNr			varchar(13) null
	, CustId			int null
	, IpNameNr			int null
	, PerShr			decimal(5, 2) null
	, MecShr			decimal(5, 2) null
	, PerSocShr			decimal(5, 2) null
	, MecSocShr			decimal(5, 2) null
	, PerSoc			int null
	, MecSoc			int null
)
go

-- нмнбкемю WID ме л╡ярхрэ гмювмн╞ й╡кэйняр╡ рбнп╡, мю ъй╡ оняхкючрэяъ гб╡рх
-- менау╡дмн дкъ йнфмнцн гб╡рс люрх ╡мтнплюж╡ч, менау╡дмс дкъ ондюкэьнцн пнгонд╡кс

-- яРБНПЧ╨ЛН РЮАКХЖЧ

drop table if exists DdexReportMwInfo
go

create table DdexReportMwInfo (
	  Id				int				primary key identity(1, 1)
	, DdexReportId		int				not null 
	, Wic				int				null
	, ObjId				int				null
	, Title				varchar(100)	null
	, Performers		varchar(100)	null
	, MusicAuthors		varchar(100)	null
	, LyricsAuthors		varchar(100)	null
)
go

