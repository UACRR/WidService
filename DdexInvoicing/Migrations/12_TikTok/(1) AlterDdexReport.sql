use Ddex
go

alter table DdexReport
add IsMasterReport bit null

alter table DdexReport
add Territory char(2) null

update DdexReport
set IsMasterReport = 1

-- select * from DdexReport
update DdexReport
set IsMasterReport = 0
where SalesTransCnt is null
