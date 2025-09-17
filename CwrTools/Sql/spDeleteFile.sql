use CWR
go

create or alter procedure spDeleteFile
	@CwrFileId int
as
begin
	delete from RecAlt where CwrFileId = @CwrFileId
	delete from RecAri where CwrFileId = @CwrFileId
	delete from RecCom where CwrFileId = @CwrFileId
	delete from RecEwt where CwrFileId = @CwrFileId
	
	delete from RecInd where CwrFileId = @CwrFileId
	delete from RecIns where CwrFileId = @CwrFileId
	delete from RecIpa where CwrFileId = @CwrFileId
	delete from RecMsg where CwrFileId = @CwrFileId
	delete from RecNat where CwrFileId = @CwrFileId
	delete from RecNct where CwrFileId = @CwrFileId
	delete from RecNet where CwrFileId = @CwrFileId
	delete from RecNow where CwrFileId = @CwrFileId
	delete from RecNpa where CwrFileId = @CwrFileId
	delete from RecNpn where CwrFileId = @CwrFileId
	delete from RecNpr where CwrFileId = @CwrFileId
	delete from RecNvt where CwrFileId = @CwrFileId
	delete from RecNwn where CwrFileId = @CwrFileId
	delete from RecOpt where CwrFileId = @CwrFileId
	delete from RecOpu where CwrFileId = @CwrFileId
	delete from RecOrn where CwrFileId = @CwrFileId
	delete from RecOwr where CwrFileId = @CwrFileId
	delete from RecOwt where CwrFileId = @CwrFileId
	delete from RecPer where CwrFileId = @CwrFileId
	delete from RecPwr where CwrFileId = @CwrFileId
	delete from RecRec where CwrFileId = @CwrFileId
	delete from RecSpt where CwrFileId = @CwrFileId
	delete from RecSpu where CwrFileId = @CwrFileId
	delete from RecSwr where CwrFileId = @CwrFileId
	delete from RecSwt where CwrFileId = @CwrFileId
	delete from RecTer where CwrFileId = @CwrFileId
	delete from RecVer where CwrFileId = @CwrFileId
	delete from RecXrf where CwrFileId = @CwrFileId

	delete from RecRev where CwrFileId = @CwrFileId
	delete from RecNwr where CwrFileId = @CwrFileId
	delete from RecIsw where CwrFileId = @CwrFileId
	delete from RecExc where CwrFileId = @CwrFileId
	delete from RecAck where CwrFileId = @CwrFileId
	delete from RecAgr where CwrFileId = @CwrFileId

	delete from RecGrt where CwrFileId = @CwrFileId	
	delete from RecGrh where CwrFileId = @CwrFileId
	delete from RecTrl where CwrFileId = @CwrFileId
	delete from RecHdr where CwrFileId = @CwrFileId

	delete from BaseRecTran where CwrFileId = @CwrFileId
	delete from CwrFiles where CwrFileId = @CwrFileId
end