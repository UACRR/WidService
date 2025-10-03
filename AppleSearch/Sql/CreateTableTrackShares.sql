use AppleMusic
go

create table TrackShares
(
	  TrackDspId varchar(30) primary key
	, ObjId int
	, Wic int
	, PerShr decimal(5, 2)
	, MecShr decimal(5, 2)
)