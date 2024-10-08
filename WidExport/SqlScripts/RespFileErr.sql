use SocWidSubmit
go

drop table if exists RespFileErr
go

create table RespFileErr (
      Id            int identity(1,1) not null primary key clustered
	, RecMsgId		int not null
    , SubmRecType   varchar(3) not null
    , SubmRecId     varchar(100) not null
    , RespFileErr   int null
	, IsFixed		bit null
	, NeedNotFix	bit null
)
go

alter table RespFileErr 
add constraint fk_RespFileErr_RecMsg
foreign key (RecMsgId) references RecMsg (Id)

alter table RespFileErr 
add constraint fk_RespFileErr_RespFileErrCode
foreign key (RespFileErr) references RespFileErrCode (Id)

go

