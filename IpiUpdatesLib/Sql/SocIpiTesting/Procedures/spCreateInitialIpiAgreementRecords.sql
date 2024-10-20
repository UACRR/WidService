use SocIpiTesting
go

create or alter procedure spCreateInitialIpiAgreementRecords
as
begin

	truncate table IpiAgreement

	declare @fileId int = 1;
	declare @lastFileId int  = (select max(Id) from FullDumpFiles)

	while @fileId <= @lastFileId
	begin
		insert IpiAgreement (
				IpAgreeNr
			  , IpBaseNr
			  , SocCde
			  , CreClsCde
			  , RolCde
			  , RgtCde
			  , FromDt
			  , ToDt
			  , SignD
			  , Shr
			  , AmdDt
			  , IsDeleted
		)
		select 
			  concat(
				  t1.IpBaseNr
				, '-'
				, t2.SocCde
				, '-'
				, t2.CreClsCde	
				, '-'
				, t2.RolCde	
				, '-'
				, t2.RgtCde
				, '-'
				, t2.ValidFromD
				, t2.ValidFromT
			  )
																					as IpAgreeNr
			, t1.IpBaseNr															as IpBaseNr
			, t2.SocCde																as SocCde
			, t2.CreClsCde															as CreClsCde
			, t2.RolCde																as RolCde
			, t2.RgtCde																as RgtCde
			, dbo.fncGetDateTimeFromStrings(t2.ValidFromD, t2.ValidFromT)			as FromDt
			, dbo.fncGetDateTimeFromStrings(t2.ValidToD, t2.ValidToT)				as ToDt
			, dbo.fncGetDateFromString(t2.SignD)		 							as SignD
			, cast(t2.Shr / 100 as decimal(5, 2))									as Shr
			, dbo.fncGetDateTimeFromStrings(t2.AmdD, t2.AmdT)						as AmdDt
			, 0																		as IsDeleted
		from RecIpa t1
			join RecMan t2 on t1.FileId = t2.FileId and t1.TransSeqNr = t2.TransSeqNr
		where t1.FileId = @fileId

		set @fileId = @fileId + 1
	end
end

--select distinct cast(Shr / 100 as decimal(5, 2)) from RecMan order by cast(Shr as decimal(5, 2))

-- exec spCreateInitialIpiAgreementRecords