use Ddex
go

create or alter procedure spCreateOrUpdateInvoiceTikTok
	  @ddexReportId int
	, @setId int
	, @fileId int
as
begin
	--exec spCreateReportAuthors @ddexReportId, @setId
	--exec spDdexApplyReportExceptions @ddexReportId, @setId
	--exec spDdexUpdateIndentBacklogSharesTiktok @ddexReportId
	exec spCreateInitialInvoiceTiktok @ddexReportId, @fileId
end
go 

-- exec spCreateOrUpdateInvoiceTikTok 1496, 27, 965