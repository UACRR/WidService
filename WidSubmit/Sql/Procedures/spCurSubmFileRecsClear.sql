use SocWidSubmitEx
go

create or alter procedure spCurSubmFileRecsClear
as
begin
	declare @submId int = (select dbo.fnCurSubmId())
	
	delete trl 
	from RecTrl trl
		join RecHdr hdr on trl.RecHdrId = hdr.Id
	where hdr.SubmissionId = @submId

	delete grt 
	from RecGrt grt
		join RecGrh grh on grt.RecGrhId = grh.Id
		join RecHdr hdr on grh.RecHdrId = hdr.Id
	where hdr.SubmissionId = @submId

	delete per 
	from RecPer per
		join RecWiaWiu wiawiu on per.RecWiaWiuId = wiawiu.Id
		join RecGrh grh on wiawiu.RecGrhId = grh.Id 
		join RecHdr hdr on grh.RecHdrId = hdr.Id
	where hdr.SubmissionId = @submId

	delete alt 
	from RecAlt alt
		join RecWiaWiu wiawiu on alt.RecWiaWiuId = wiawiu.Id
		join RecGrh grh on wiawiu.RecGrhId = grh.Id 
		join RecHdr hdr on grh.RecHdrId = hdr.Id
	where hdr.SubmissionId = @submId

	delete ssrosr
	from RecSsrOsr ssrosr
		join RecSipOip sipoip on ssrosr.RecSipOipId = sipoip.Id
		join RecWiaWiu wiawiu on sipoip.RecWiaWiuId = wiawiu.Id
		join RecGrh grh on wiawiu.RecGrhId = grh.Id 
		join RecHdr hdr on grh.RecHdrId = hdr.Id
	where hdr.SubmissionId = @submId

	delete sipoip
	from RecSipOip sipoip
		join RecWiaWiu wiawiu on sipoip.RecWiaWiuId = wiawiu.Id
		join RecGrh grh on wiawiu.RecGrhId = grh.Id 
		join RecHdr hdr on grh.RecHdrId = hdr.Id
	where hdr.SubmissionId = @submId

	delete wiawiu
	from RecWiaWiu wiawiu
		join RecGrh grh on wiawiu.RecGrhId = grh.Id 
		join RecHdr hdr on grh.RecHdrId = hdr.Id
	where hdr.SubmissionId = @submId

	delete grh
	from RecGrh grh
		join RecHdr hdr on grh.RecHdrId = hdr.Id
	where hdr.SubmissionId = @submId

	delete hdr
	from RecHdr hdr
	where hdr.SubmissionId = @submId

end
go