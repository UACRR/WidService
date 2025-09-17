use CWR
go

create or alter procedure spDeleteAllFiles
as
begin
	delete from RecAlt
	delete from RecAri
	delete from RecCom
	delete from RecEwt
	
	delete from RecInd
	delete from RecIns
	delete from RecIpa
	delete from RecMsg
	delete from RecNat
	delete from RecNct
	delete from RecNet
	delete from RecNow
	delete from RecNpa
	delete from RecNpn
	delete from RecNpr
	delete from RecNvt
	delete from RecNwn
	delete from RecOpt
	delete from RecOpu
	delete from RecOrn
	delete from RecOwr
	delete from RecOwt
	delete from RecPer
	delete from RecPwr
	delete from RecRec
	delete from RecSpt
	delete from RecSpu
	delete from RecSwr
	delete from RecSwt
	delete from RecTer
	delete from RecVer
	delete from RecXrf

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