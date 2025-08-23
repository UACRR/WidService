use AutoSearch
go

-- =================================== ¬’≤ƒÕ¿ ≤Õ‘Œ–Ã¿÷≤ﬂ ≤« «¬≤“”
-- SourceWorks
create nonclustered index idx_SourceWorks_WorkId on SourceWorks(WorkId)
create nonclustered index idx_SourceWorks_Name on SourceWorks(Name)

-- SourceNames
create nonclustered index idx_SourceNames_Name on SourceNames(Name)

-- SourceNamesT
create nonclustered index idx_SourceNamesT_Name on SourceNamesT(Name)

-- SourceNameWorks
create nonclustered index idx_SourceNameWorks_SourceNameId on SourceNameWorks(SourceNameId)
create nonclustered index idx_SourceNameWorks_WorkId on SourceNameWorks(WorkId)

create nonclustered index idx_SourcePerformerParts_Name on SourcePerformerParts(Name)

create nonclustered index idx_SourceAuthorParts_Name on SourceAuthorParts(Name)

-- =================================== –Œ¡Œ◊¿ ≤Õ‘Œ–Ã¿÷≤ﬂ ƒÀﬂ ŒÕŒ¬À≈ÕÕﬂ ≤Õ‘Œ–Ã¿÷≤Ø ƒÀﬂ œŒÿ” ”
-- ExtraTargetWorks
create nonclustered index idx_ExtraTargetWorks_WorkId on ExtraTargetWorks(WorkId)
create nonclustered index idx_ExtraTargetWorks_Name on ExtraTargetWorks(Name)
create unique nonclustered index idx_ExtraTargetWorks_WorkId_Name on ExtraTargetWorks(WorkId, Name)


-- TargetNames
create nonclustered index idx_ExtraTargetNames_Name on ExtraTargetNames(Name)

-- TargetNamesT
create nonclustered index idx_ExtraTargetNamesT_Name on ExtraTargetNamesT(Name)

-- TargetNameWorks
create nonclustered index idx_ExtraTargetNameWorks_TargetNameId on ExtraTargetNameWorks(TargetNameId)
create nonclustered index idx_ExtraTargetNameWorks_WorkId on ExtraTargetNameWorks(WorkId)

-- PERFORMERS
create nonclustered index idx_ExtraTargetPerformerParts_Name on ExtraTargetPerformerParts(Name)

create nonclustered index idx_ExtraTargetPerformerPartWorks_TargetPerformerPartWorks on ExtraTargetPerformerPartWorks(TargetPerformerPartId)
create nonclustered index idx_ExtraTargetPerformerPartWorks_WorkId on ExtraTargetPerformerPartWorks(WorkId)
create unique nonclustered index idx_ExtraTargetPerformerPartWorks_TargetPerformerPartId_WorkId on ExtraTargetPerformerPartWorks(TargetPerformerPartId, WorkId)

-- AuthorS
create nonclustered index idx_ExtraTargetAuthorParts_Name on ExtraTargetAuthorParts(Name)

create nonclustered index idx_ExtraTargetAuthorPartWorks_TargetAuthorPartWorks on ExtraTargetAuthorPartWorks(TargetAuthorPartId)
create nonclustered index idx_ExtraTargetAuthorPartWorks_WorkId on ExtraTargetAuthorPartWorks(WorkId)
create unique nonclustered index idx_ExtraTargetAuthorPartWorks_TargetAuthorPartId_WorkId on ExtraTargetAuthorPartWorks(TargetAuthorPartId, WorkId)


-- =================================== ≤Õ‘Œ–Ã¿÷≤ﬂ ƒÀﬂ œŒÿ” ”
-- TargetNames
create unique nonclustered index idx_TargetNamesIdentMw_Name on TargetNamesIdentMw(Name)

-- TargetNamesT
create nonclustered index idx_TargetNamesIdentMwT_Name on TargetNamesIdentMwT(Name)

-- TargetNameWorks
create nonclustered index idx_TargetNameWorksIdentMw_TargetNameId on TargetNameWorksIdentMw(TargetNameId)
create nonclustered index idx_TargetNameWorksIdentMw_WorkId on TargetNameWorksIdentMw(WorkId)
create nonclustered index idx_TargetNameWorksIdentMw_TargetNameId_WorkId on TargetNameWorksIdentMw(TargetNameId, WorkId)
alter table TargetNameWorksIdentMw add constraint fk_TargetNameWorksIdentMw_TargetNameId foreign key (TargetNameId) references TargetNamesIdentMw(TargetNameId);

create unique nonclustered index idx_TargetPerformerPartsIdentMw_Name on TargetPerformerPartsIdentMw(Name)

create nonclustered index idx_TargetPerformerPartWorksIdentMw_TargetPerformerPartWorks on TargetPerformerPartWorksIdentMw(TargetPerformerPartId)
create nonclustered index idx_TargetPerformerPartWorksIdentMw_WorkId on TargetPerformerPartWorksIdentMw(WorkId)

create nonclustered index idx_TargetAuthorPartsIdentMw_Name on TargetAuthorPartsIdentMw(Name)

create nonclustered index idx_TargetAuthorPartWorksIdentMw_TargetAuthorPartWorks on TargetAuthorPartWorksIdentMw(TargetAuthorPartId)
create nonclustered index idx_TargetAuthorPartWorksIdentMw_WorkId on TargetAuthorPartWorksIdentMw(WorkId)
