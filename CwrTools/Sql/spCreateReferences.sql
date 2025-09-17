use CWR
go

create or alter procedure spCreateReferences
	@cwrFileId int
as
begin
--declare @cwrFileId int = (select max(CwrFileId) from CwrFiles)
declare @recHdrId int = (select recHdrId from RecHdr where CwrFileId = @cwrFileId)

-- RecGrh
update RecGrh set RecHdrId = @recHdrId where RecHdrId is null
-- RecTrl
update RecTrl set RecHdrId = @recHdrId where RecHdrId is null
-- RecGrh
update t1 set t1.RecGrhId = t2.RecGrhId from RecGrt t1 join RecGrh t2 on t1.GroupID = t2.GroupID where t1.RecGrhId is null

exec spCreateReferencesAck @cwrFileId
exec spCreateReferencesAgr @cwrFileId
exec spCreateReferencesExc @cwrFileId
exec spCreateReferencesIsw @cwrFileId
exec spCreateReferencesNwr @cwrFileId
exec spCreateReferencesRev @cwrFileId

exec spCreateReferencesAlt @cwrFileId
exec spCreateReferencesAri @cwrFileId
exec spCreateReferencesCom @cwrFileId
exec spCreateReferencesEwt @cwrFileId
exec spCreateReferencesInd @cwrFileId
exec spCreateReferencesIns @cwrFileId
exec spCreateReferencesIpa @cwrFileId
exec spCreateReferencesMsg @cwrFileId
exec spCreateReferencesNat @cwrFileId
exec spCreateReferencesNct @cwrFileId
exec spCreateReferencesNet @cwrFileId
exec spCreateReferencesNow @cwrFileId
exec spCreateReferencesNpa @cwrFileId
exec spCreateReferencesNpn @cwrFileId
exec spCreateReferencesNpr @cwrFileId
exec spCreateReferencesNvt @cwrFileId
exec spCreateReferencesNwn @cwrFileId
exec spCreateReferencesOpt @cwrFileId
exec spCreateReferencesOpu @cwrFileId
exec spCreateReferencesOrn @cwrFileId
exec spCreateReferencesOwr @cwrFileId
exec spCreateReferencesOwt @cwrFileId
exec spCreateReferencesPer @cwrFileId
exec spCreateReferencesPwr @cwrFileId
exec spCreateReferencesRec @cwrFileId
exec spCreateReferencesSpt @cwrFileId
exec spCreateReferencesSpu @cwrFileId
exec spCreateReferencesSwr @cwrFileId
exec spCreateReferencesSwt @cwrFileId
exec spCreateReferencesTer @cwrFileId
exec spCreateReferencesVer @cwrFileId
exec spCreateReferencesXrf @cwrFileId

end