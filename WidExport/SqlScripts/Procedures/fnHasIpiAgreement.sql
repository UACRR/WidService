use SocWidSubmit
go

create or alter function fnHasIpiAgreement
(
	  @ipBaseNr varchar(13)
	, @rhType int
	, @rhRole int
	, @rgtCde varchar(2)
)
returns int
as
begin

if @rhType = 1 and @rhRole in (1, 5, 6) -- LY
	return dbo.fnFindIpiAgreement(@ipBaseNr, 'LY', @rgtCde)

if @rhType = 1 and @rhRole in (2, 7) -- MC
	return dbo.fnFindIpiAgreement(@ipBaseNr, 'MC', @rgtCde)

if @rhType = 1 and @rhRole in (10) -- LY,MC
	return 
		case
			when dbo.fnFindIpiAgreement(@ipBaseNr, 'LY', @rgtCde) = 1
				and dbo.fnFindIpiAgreement(@ipBaseNr, 'MC', @rgtCde) = 1
			then 1
			else 0
		end

if @rhType = 3 and @rhRole in (8, 9) -- EM
	return dbo.fnFindIpiAgreement(@ipBaseNr, 'EM', @rgtCde)

return 0

end
go


