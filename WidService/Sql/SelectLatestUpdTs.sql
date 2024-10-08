; with maxTs as (
	      select max(UpdDt) ts from socWid..IpiBase
	union select max(UpdDt) ts from socWid..IpiMbrAgreeTerr
	union select max(UpdDt) ts from socWid..IpiName
	union select max(UpdDt) ts from socWid..IpiStatus
	union select max(UpdTs) ts from socWid..widAltTtl
	union select max(UpdTs) ts from socWid..widArtist
	union select max(UpdTs) ts from socWid..widComponent
	union select max(UpdTs) ts from socWid..widConflict
	union select max(UpdTs) ts from socWid..widInstn
	union select max(UpdTs) ts from socWid..widInstnDtl
	union select max(UpdTs) ts from socWid..widIntrPty
	union select max(UpdTs) ts from socWid..widIswc
	union select max(UpdTs) ts from socWid..widOrgTtlVrExrp
	union select max(UpdTs) ts from socWid..widShares
	union select max(UpdTs) ts from socWid..widSubmission
	union select max(UpdTs) ts from socWid..widTitle
	union select max(UpdTs) ts from socWid..widWrkOrg
	union select max(UpdTs) ts from socWid..widWtrPubRel
)
select max(ts) from maxTs