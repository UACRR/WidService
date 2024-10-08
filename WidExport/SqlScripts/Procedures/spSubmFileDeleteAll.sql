use SocWidSubmit
go

create or alter procedure spSubmFileDeleteAll
as
begin
delete from RecOsr
delete from RecOip
delete from RecSsr
delete from RecSip
delete from RecAlt
delete from RecPer
delete from RecWia
delete from RecGrh
delete from RecGrt
delete from RecHdr
delete from RecTrl
delete from WidTrans
delete from SubmFile
end
go

-- exec spSubmFileDeleteAll
