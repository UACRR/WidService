use SocWid;
go

create nonclustered index idxWidAltTtl						on		widAltTtl(Wic)
create nonclustered index idxWidAltTtlHist					on		widAltTtlHist(Wic)
create nonclustered index idxWidArtist						on		widArtist(Wic)
create nonclustered index idxWidArtistHist					on		widArtistHist(Wic)
create nonclustered index idxWidComponent					on		widComponent(Wic)
create nonclustered index idxWidComponentHist				on		widComponentHist(Wic)
create nonclustered index idxWidConflict					on		widConflict(Wic)
create nonclustered index idxWidConflictHist				on		widConflictHist(Wic)
create nonclustered index idxWidInstn						on		widInstn(Wic)
create nonclustered index idxWidInstnDtl					on		widInstnDtl(Wic)
create nonclustered index idxWidInstnDtlHist				on		widInstnDtlHist(Wic)
create nonclustered index idxWidInstnHist					on		widInstnHist(Wic)
create nonclustered index idxWidIntrPty						on		widIntrPty(Wic)
create nonclustered index idxWidIntrPtyHist					on		widIntrPtyHist(Wic)
create nonclustered index idxWidIswc						on		widIswc(Wic)
create nonclustered index idxWidIswcHist					on		widIswcHist(Wic)
create nonclustered index idxWidOrgTtlVrExrp				on		widOrgTtlVrExrp(Wic)
create nonclustered index idxWidOrgTtlVrExrpHist			on		widOrgTtlVrExrpHist(Wic)
create nonclustered index idxWidShares						on		widShares(Wic)
create nonclustered index idxWidSharesHist					on		widSharesHist(Wic)
create nonclustered index idxWidSubmission					on		widSubmission(Wic)
create nonclustered index idxWidSubmissionHist				on		widSubmissionHist(Wic)
create nonclustered index idxWidTitle						on		widTitle(Wic)
create nonclustered index idxWidTitleHist					on		widTitleHist(Wic)
create nonclustered index idxWidWrkOrg						on		widWrkOrg(Wic)
create nonclustered index idxWidWrkOrgHist					on		widWrkOrgHist(Wic)
create nonclustered index idxWidWtrPubRel					on		widWtrPubRel(Wic)
create nonclustered index idxWidWtrPubRelHist				on		widWtrPubRelHist(Wic)
create nonclustered index idxIpiName_IpNameNr				on		IpiName(IpNameNr)
create nonclustered index idxIpiName_IpBaseNr				on		IpiName(IpBaseNr)
create nonclustered index idxIpiBase_IpBaseNr				on		IpiBase(IpBaseNr)
create nonclustered index idxIpiMbrAgreeTerr_IpBaseNr		on		IpiMbrAgreeTerr(IpBaseNr)
create nonclustered index idxIpiStatus_IpBaseNr				on		IpiStatus(IpBaseNr)
create nonclustered index idxWidArtist_PerfArtistLstName	on		widArtist(PerfArtistLstName)
create nonclustered index idxWidArtist_PerfArtistFstName	on		widArtist(PerfArtistFstName)
create nonclustered index idxWidTitle_WrkTtl				on		widTitle(WrkTtl)
create nonclustered index idxWidIswc_Iswc					on		widIswc(Iswc)
create nonclustered index idxWidIswc_PrefIswc				on		widIswc(PrefIswc)

/*
drop index if exists idxWidAltTtl						  on		widAltTtl
drop index if exists idxWidAltTtlHist					  on		widAltTtlHist
drop index if exists idxWidArtist						  on		widArtist
drop index if exists idxWidArtistHist					  on		widArtistHist
drop index if exists idxWidComponent					  on		widComponent
drop index if exists idxWidComponentHist				  on		widComponentHist
drop index if exists idxWidConflict						  on		widConflict
drop index if exists idxWidConflictHist					  on		widConflictHist
drop index if exists idxWidInstn						  on		widInstn
drop index if exists idxWidInstnDtl						  on		widInstnDtl
drop index if exists idxWidInstnDtlHist					  on		widInstnDtlHist
drop index if exists idxWidInstnHist					  on		widInstnHist
drop index if exists idxWidIntrPty						  on		widIntrPty
drop index if exists idxWidIntrPtyHist					  on		widIntrPtyHist
drop index if exists idxWidIswc							  on		widIswc
drop index if exists idxWidIswcHist						  on		widIswcHist
drop index if exists idxWidOrgTtlVrExrp					  on		widOrgTtlVrExrp
drop index if exists idxWidOrgTtlVrExrpHist				  on		widOrgTtlVrExrpHist
drop index if exists idxWidShares						  on		widShares
drop index if exists idxWidSharesHist					  on		widSharesHist
drop index if exists idxWidSubmission					  on		widSubmission
drop index if exists idxWidSubmissionHist				  on		widSubmissionHist
drop index if exists idxWidTitle						  on		widTitle
drop index if exists idxWidTitleHist					  on		widTitleHist
drop index if exists idxWidWrkOrg						  on		widWrkOrg
drop index if exists idxWidWrkOrgHist					  on		widWrkOrgHist
drop index if exists idxWidWtrPubRel					  on		widWtrPubRel
drop index if exists idxWidWtrPubRelHist				  on		widWtrPubRelHist
drop index if exists idxIpiName_IpNameNr				  on		IpiName
drop index if exists idxIpiName_IpBaseNr				  on		IpiName
drop index if exists idxIpiBase_IpBaseNr				  on		IpiBase
drop index if exists idxIpiMbrAgreeTerr_IpBaseNr		  on		IpiMbrAgreeTerr
drop index if exists idxIpiStatus_IpBaseNr				  on		IpiStatus
drop index if exists idxWidArtist_PerfArtistLstName		  on		widArtist
drop index if exists idxWidArtist_PerfArtistFstName		  on		widArtist
drop index if exists idxWidTitle_WrkTtl					  on		widTitle
drop index if exists idxWidIswc_Iswc					  on		widIswc
drop index if exists idxWidIswc_PrefIswc				  on		widIswc
*/
--select * from sys.tables order by name

