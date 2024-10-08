use SocWidSubmit
go

create or alter function fnGetRhTypeName
(
	  @rhType int
)
returns nvarchar(100)
as
begin

if @rhType = 1 return 'Правовласник'
if @rhType = 2 return 'Товариство'
if @rhType = 3 return 'Видавництво'
return ''

end
go


