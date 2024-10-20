use SocIpiTesting
go

create or alter procedure spCreateInitialIpiTerritoryRecords
as
begin

	truncate table IpiTerritory

	declare @fileId int = 1

	while @fileId < 39
	begin
		insert IpiTerritory (
				IpAgreeNr
			  , TisNr
			  , TisNrFromD
			  , Tisan
			  , TisanFromD
			  , IncExcInd
		)
		select 
			  concat(
				  t0.IpBaseNr
				, '-'
				, t1.SocCde
				, '-'
				, t1.CreClsCde	
				, '-'
				, t1.RolCde	
				, '-'
				, t1.RgtCde
				, '-'
				, t1.ValidFromD
				, t1.ValidFromT
			  )
																				as IpAgreeNr
			, t3.TisNr															as TisNr
			, dbo.fncGetDateFromString(t3.TisanValidFrom)						as TisNrFromD
			, t3.Tisan															as Tisan
			, dbo.fncGetDateFromString(t3.TisanValidFrom)						as TisanFromD
			, t3.IncExcInd														as IncExcInd
		from RecIpa t0
			join RecMan t1 on  t0.FileId = t1.FileId
				and t0.TransSeqNr = t1.TransSeqNr
			join RecManList t2 on t1.FileId = t2.FileId
				and t1.TransSeqNr = t2.TransSeqNr
			join RecTma t3 on t2.FileId = t3.FileId
				and t2.TransSeqNr = t3.TransSeqNr
				and t2.RecSeqNr < t3.RecSeqNr
				and t2.NextRecSeqNr > t3.RecSeqNr
		where t0.FileId = @fileId

		set @fileId = @fileId + 1
	end
end


-- exec spCreateInitialIpiTerritoryRecords
-- select count(*) from IpiTerritory