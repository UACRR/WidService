use SocWidSubmit
go

drop table if exists RespFileErrCode
go

create table RespFileErrCode (
	   Id int primary key clustered identity(1, 1)
	,  ErrCondNr int not null
	, MsgType	varchar(2) not null
	, MsgLevel	varchar(2) not null
	, MsgTxt	varchar(200) not null
	, MsgTxtUkr	nvarchar(200) null
)
go

