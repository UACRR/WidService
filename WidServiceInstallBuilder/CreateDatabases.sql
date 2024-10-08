create login WidReplicationService with password=N'WidReplicationServicePwd'
go

create database SocWidTest
go
use SocWidTest
go
create user WidReplicationService for login WidReplicationService with default_schema=dbo
go


