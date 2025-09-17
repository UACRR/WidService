use CWR
go

create or alter procedure spDeleteAllData
as
begin
	truncate table RecAlt
	truncate table RecAri
	truncate table RecCom
	truncate table RecEwt
	
	truncate table RecInd
	truncate table RecIns
	truncate table RecIpa
	truncate table RecMsg
	truncate table RecNat
	truncate table RecNct
	truncate table RecNet
	truncate table RecNow
	truncate table RecNpa
	truncate table RecNpn
	truncate table RecNpr
	truncate table RecNvt
	truncate table RecNwn
	truncate table RecOpt
	truncate table RecOpu
	truncate table RecOrn
	truncate table RecOwr
	truncate table RecOwt
	truncate table RecPer
	truncate table RecPwr
	truncate table RecRec
	truncate table RecSpt
	truncate table RecSpu
	truncate table RecSwr
	truncate table RecSwt
	truncate table RecTer
	truncate table RecVer
	truncate table RecXrf

	delete from RecRev
	delete from RecNwr
	delete from RecIsw
	delete from RecExc
	delete from RecAck
	delete from RecAgr

	delete from RecGrt	
	delete from RecGrh
	delete from RecTrl
	delete from RecHdr

	delete from BaseRecTran
	delete from CwrFiles
end