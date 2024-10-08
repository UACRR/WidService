use SocWidSubmit
go

create or alter function fnFindIpiAgreement
(
	  @ipBaseNr varchar(13)
	, @rolCde varchar(2)
	, @rgtCde varchar(2)
)
returns int
as
begin

declare @id int = (
	select top 1 Id
	from SocIpi..IpiAgreement
	where IpBaseNr = @ipBaseNr
		and SocCde = 140
		and CreClsCde = 'MW'
		and RolCde = @rolCde
		and RgtCde = @rgtCde
		and getdate() > FromDt
		and getdate() < ToDt
)

return case when @id is not null then 1 else 0 end

end
go