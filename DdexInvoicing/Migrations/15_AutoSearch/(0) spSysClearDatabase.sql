use AutoSearch
go

create or alter procedure spSysClearDatabase
as
begin

drop table if exists TargetNameWorks
drop table if exists TargetNames
drop table if exists TargetNamesT

drop table if exists TargetPerformerPartWorks
drop table if exists TargetPerformerParts

drop table if exists TargetAuthorPartWorks
drop table if exists TargetAuthorParts

drop table if exists FoundNamesInIdentMw
drop table if exists FoundWorksInIdentMw

drop table if exists SearchSteps
drop table if exists SourceWorks
drop table if exists SourceNames
drop table if exists SourceNamesT
drop table if exists SourceNameWorks
drop table if exists SourcePerformerParts
drop table if exists SourceAuthorParts

drop table if exists ExtraTargetWorks
drop table if exists ExtraTargetNames
drop table if exists ExtraTargetNamesT
drop table if exists ExtraTargetNameWorks
drop table if exists ExtraTargetPerformerParts
drop table if exists ExtraTargetPerformerPartWorks
drop table if exists ExtraTargetAuthorParts
drop table if exists ExtraTargetAuthorPartWorks

drop table if exists TargetWorks

end
go