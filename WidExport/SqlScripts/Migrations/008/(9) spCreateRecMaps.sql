use SocWidSubmit
go

create or alter procedure spCreateRecMaps
as
begin

truncate table MapWia
insert MapWia select * from vMapWiaToWork

truncate table MapSip
insert MapSip select * from vMapSipToShare

truncate table MapOip
insert MapOip select * from vMapOipToShare

truncate table MapSsr
insert MapSsr select * from vMapSsrToShare

truncate table MapOsr
insert MapOsr select * from vMapOsrToShare

truncate table MapAlt
insert MapAlt select * from vMapAltToName

truncate table MapPer
insert MapPer select * from vMapPerToPerformer

end
