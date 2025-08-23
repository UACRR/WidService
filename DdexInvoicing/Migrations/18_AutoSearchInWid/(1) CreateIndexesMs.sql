use AutoSearch
go

-- =================================== ≤Õ‘Œ–Ã¿÷≤ﬂ ƒÀﬂ œŒÿ” ”
-- TargetWorksMs
create unique nonclustered index idx_TargetNamesMs_Name on TargetNamesMs(Name)

-- TargetNamesT
create nonclustered index idx_TargetNamesMsT_Name on TargetNamesMsT(Name)

-- TargetNameWorks
create nonclustered index idx_TargetNameWorksMs_TargetNameId on TargetNameWorksMs(TargetNameId)
create nonclustered index idx_TargetNameWorksMs_WorkId on TargetNameWorksMs(WorkId)
create nonclustered index idx_TargetNameWorksMs_TargetNameId_WorkId on TargetNameWorksMs(TargetNameId, WorkId)

create unique nonclustered index idx_TargetPerformerPartsMs_Name on TargetPerformerPartsMs(Name)

create nonclustered index idx_TargetPerformerPartWorksMs_TargetPerformerPartWorks on TargetPerformerPartWorksMs(TargetPerformerPartId)
create nonclustered index idx_TargetPerformerPartWorksMs_WorkId on TargetPerformerPartWorksMs(WorkId)

create nonclustered index idx_TargetAuthorPartsMs_Name on TargetAuthorPartsMs(Name)

create nonclustered index idx_TargetAuthorPartWorksMs_TargetAuthorPartWorks on TargetAuthorPartWorksMs(TargetAuthorPartId)
create nonclustered index idx_TargetAuthorPartWorksMs_WorkId on TargetAuthorPartWorksMs(WorkId)

