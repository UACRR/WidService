use ShareCalc
go

create or alter procedure spProcessIpiAgreements
as
declare @from char(8) = (select Name from IpiLastProcessedFile)
if @from is null
begin
	print 'spProcessIpiAgreementsAll'
	exec spProcessIpiAgreementsAll
end
else
begin
	print 'spProcessIpiAgreementsUpdated'
	exec spProcessIpiAgreementsUpdated
end
go

-- exec spProcessIpiAgreements

