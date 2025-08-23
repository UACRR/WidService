use AutoSearch
go

exec sp_rename 'TargetNames', 'TargetNamesIdentMw'
exec sp_rename 'TargetNameWorks', 'TargetNameWorksIdentMw'
exec sp_rename 'TargetNamesT', 'TargetNamesIdentMwT'
exec sp_rename 'TargetAuthorParts', 'TargetAuthorPartsIdentMw'
exec sp_rename 'TargetAuthorPartWorks', 'TargetAuthorPartWorksIdentMw'
exec sp_rename 'TargetPerformerParts', 'TargetPerformerPartsIdentMw'
exec sp_rename 'TargetPerformerPartWorks', 'TargetPerformerPartWorksIdentMw'
exec sp_rename 'TargetWorks', 'TargetWorksIdentMw'

drop procedure if exists spUpdateTargetInfo
