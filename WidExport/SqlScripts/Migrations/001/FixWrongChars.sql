use SocWidSubmit
go

update WidSubmGroupWorkName set WidName = replace(WidName, 'Å', 'E')
update WidSubmGroupWorkName set WidName = replace(WidName, '¹', '#')
update WidSubmGroupWorkName set WidName = replace(WidName, '…', '...')
update WidSubmGroupWorkName set WidName = replace(WidName, '«', '"')
update WidSubmGroupWorkName set WidName = replace(WidName, '»', '"')
update WidSubmGroupWorkName set WidName = replace(WidName, '’', '''')
update WidSubmGroupWorkName set WidName = replace(WidName, '‘', '''')
update WidSubmGroupWorkName set WidName = replace(WidName, '–', '-')
update WidSubmGroupWorkName set WidName = replace(WidName, ' ', ' ')

declare @FixedErrIds varchar = '5, 13, 4, 3, 11, 10, 15,     8, 1, 7'
update RespFileErr set IsFixed = 1 where RespFileErr in (5, 13, 4, 3, 11, 10, 15,     8, 1, 7)