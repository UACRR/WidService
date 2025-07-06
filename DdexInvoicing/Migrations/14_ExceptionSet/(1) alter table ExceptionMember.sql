use Ddex
go 

alter table ExceptionMember
add ForPer bit default(1)
go

alter table ExceptionMember
add ForMec bit default(1)
go

update ExceptionMember set ForPer = 1, ForMec = 1
go
