
delete [dbo].[WidSubmGroupWorkPerformer] where isnull(LocalName, '') = ''
update RespFileErr set IsFixed = 1 where RespFileErr = 6