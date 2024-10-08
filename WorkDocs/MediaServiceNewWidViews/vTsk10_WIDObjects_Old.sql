use MediaService
go

create or alter view  vTsk10_WIDObjects_Old 
as
select WIC, ISWC, name, genreName, authors as author, performers as performer, rateTotalMEC, rateTotalPER from [WID_IPI_].[dbo].[wObject]
go
