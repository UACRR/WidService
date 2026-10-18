drop table SpecRecordsUsed
go

with  Res as (select 'RecAck' as Name from RecAck	having count(*) > 0
union select 'RecAgr' as Name from RecAgr	having count(*) > 0
union select 'RecAlt' as Name from RecAlt	having count(*) > 0
union select 'RecAri' as Name from RecAri	having count(*) > 0
union select 'RecCom' as Name from RecCom	having count(*) > 0
union select 'RecEwt' as Name from RecEwt	having count(*) > 0
union select 'RecExc' as Name from RecExc	having count(*) > 0
union select 'RecGrh' as Name from RecGrh	having count(*) > 0
union select 'RecGrt' as Name from RecGrt	having count(*) > 0
union select 'RecHdr' as Name from RecHdr	having count(*) > 0
union select 'RecInd' as Name from RecInd	having count(*) > 0
union select 'RecIns' as Name from RecIns	having count(*) > 0
union select 'RecIpa' as Name from RecIpa	having count(*) > 0
union select 'RecIsw' as Name from RecIsw	having count(*) > 0
union select 'RecMsg' as Name from RecMsg	having count(*) > 0
union select 'RecNat' as Name from RecNat	having count(*) > 0
union select 'RecNct' as Name from RecNct	having count(*) > 0
union select 'RecNet' as Name from RecNet	having count(*) > 0
union select 'RecNow' as Name from RecNow	having count(*) > 0
union select 'RecNpa' as Name from RecNpa	having count(*) > 0
union select 'RecNpn' as Name from RecNpn	having count(*) > 0
union select 'RecNpr' as Name from RecNpr	having count(*) > 0
union select 'RecNvt' as Name from RecNvt	having count(*) > 0
union select 'RecNwn' as Name from RecNwn	having count(*) > 0
union select 'RecNwr' as Name from RecNwr	having count(*) > 0
union select 'RecOpt' as Name from RecOpt	having count(*) > 0
union select 'RecOpu' as Name from RecOpu	having count(*) > 0
union select 'RecOrn' as Name from RecOrn	having count(*) > 0
union select 'RecOwr' as Name from RecOwr	having count(*) > 0
union select 'RecOwt' as Name from RecOwt	having count(*) > 0
union select 'RecPer' as Name from RecPer	having count(*) > 0
union select 'RecPwr' as Name from RecPwr	having count(*) > 0
union select 'RecRec' as Name from RecRec	having count(*) > 0
union select 'RecRev' as Name from RecRev	having count(*) > 0
union select 'RecSpt' as Name from RecSpt	having count(*) > 0
union select 'RecSpu' as Name from RecSpu	having count(*) > 0
union select 'RecSwr' as Name from RecSwr	having count(*) > 0
union select 'RecSwt' as Name from RecSwt	having count(*) > 0
union select 'RecTer' as Name from RecTer	having count(*) > 0
union select 'RecTrl' as Name from RecTrl	having count(*) > 0
union select 'RecVer' as Name from RecVer	having count(*) > 0
union select 'RecXrf' as Name from RecXrf	having count(*) > 0
)
select * into SpecRecordsUsed from Res
